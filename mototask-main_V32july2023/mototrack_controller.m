function [trial_table, crashed] = mototrak_controller(app)

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%
% MotoTrack + Stimulation (V32 july 2023)
%
%
% - Mototrack control
% - Reward at successful trials
%
%   Update (V32 july 2023):
% - send Stimulation command in
%	control(off), random, reward, and manual conditions
%
% TODO: Add more details if required.
%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%% Mototrak and sound initialization
if app.knob_pos.Value > 4 || app.knob_pos.Value < -2
    warning('specified lever position was %.2f, but it must be between -2 and 4 (cm)', app.knob_pos.Value);
    return;
end

% move to specified position
app.moto.autopositioner(-100 * (app.knob_pos.Value - 4.75));

% sounds = speaker_sounds(freqs,duration,amplitude);
reward_sound = speaker_sounds(app.reward_sound, 0.3, 10);
failure_sound = speaker_sounds(app.failure_sound, 0.3, 10);

%% Initialization

% variables for overall stats
num_rewards = 0;
num_trials = 0;
num_stimulations = 0;
historical_HT_max = 0;
historical_hit_thresh_max_vec = [];
start_time = datetime('now');
%
histo_tolerance = app.histo_tolerance.Value;
failure_tolerance = app.failure_tolerance.Value;
MaxTrialNum = app.MaxTrialNum.Value;

%% Random Stimulation Parameters
% stimulate in real-time in certain random trials based on a
% randomly generated array RandStimIndex

if app.StimCond == 2
    stimRate = app.StimRate.Value; % Stimulation rate
    numStim = round(stimRate/100 * MaxTrialNum);
    % Generate a random order of trials
    RandStimOrder = randperm(MaxTrialNum);
    
    % Create a binary array to represent stimulation triggers
    RandStimIndex = false(1, MaxTrialNum);
    RandStimIndex(RandStimOrder(1:numStim)) = true;
end


% pre-allocate table with 500 trials to save trial-based results
sz = [500 9];
varTypes = {'doubleNaN', 'doubleNaN', 'doubleNaN', 'cell',...
    'doubleNaN', 'doubleNaN', 'logical', 'doubleNaN', 'logical'};
varNames = {'start_time', 'init_thresh', 'hit_thresh', 'AngleOrForce',...
    'hold_time', 'duration', 'success', 'peak', 'stim'};
trial_table = table('Size', sz, 'VariableTypes', varTypes, 'VariableNames', varNames);
trial_table = addprop(trial_table, {'ver', 'num_rewards', 'num_trials','num_stimulations', 'start_time', 'mean_peak','historical_HT_max', 'rat_id', 'device'}, {'table', 'table', 'table', 'table', 'table', 'table', 'table', 'table'});
trial_table.Properties.CustomProperties.ver = 1.2;
trial_table.Properties.CustomProperties.start_time = start_time;

historical_HT_max=app.historical_hit_thresh_max;

% variables for task logics
tmp_value_buffer = [nan nan]; % [time value], first row is oldest data
trial_value_buffer = [nan nan]; % [time value]

past_10_trials_succ = false(1, 10);
past_10_trials_peak_vect = nan(1, 10);

past_10_trial_vect = nan(1, 10);
past_10_median_peak = 0;
app.Median_peak = 0;

trial_started = false;
post_trial_pause = false;
current_hold_time = nan;
current_hit_thresh = nan;
app.hit_thresh.Value = nan;
current_init_thresh = nan;
send_pellets = 0;
moduleValue_now = 0;
peak_moduleValue = 0;

stim = false;

success = false;
crashed = false;

experiment_start = tic;
loop_timer = tic;
last_pellet_time = toc(experiment_start);
disp('experiment started!')

try
    %% Main experiment loop
    while (toc(experiment_start) < app.duration.Value * 60 || num_trials < MaxTrialNum) && ~app.stop_session && ishandle(app.MotoTrakKnobUIFigure)
        
        time_now = toc(experiment_start);
        moduleValue_before = moduleValue_now;
        
        moduleValue_now = (app.moto.read_Pull() - app.moto.baseline) * app.moto.slope; % p(1) = slope; p(2) zero-crossing
        
         peak_moduleValue = max(peak_moduleValue, moduleValue_now);
        
        tmp_value_buffer = [tmp_value_buffer(time_now - tmp_value_buffer(:, 1) <= app.buffer_dur, :); time_now moduleValue_now];
        
        
        
        while app.pause_session
            drawnow limitrate; % update GUI and force fig
        end
        
        loop_time = toc(loop_timer);
        if loop_time > 0.1
            fprintf('--- WARNING --- \nlong delay in while loop (%.0f ms)\n', loop_time * 1000);
        end
        loop_timer = tic;
        
        % Initiate Trial
        if ~trial_started && moduleValue_now >= app.init_thresh.Value && moduleValue_before < app.init_thresh.Value
            
            
            
            trial_started = true;
            trial_start_time = time_now;
            current_hold_time = app.hold_time.Value;
            current_hit_thresh = app.hit_thresh.Value;
            current_init_thresh = app.init_thresh.Value;
            peak_moduleValue = moduleValue_now; % don't consider previous
            
            disp('Trial initiated... ');
            num_trials = num_trials + 1;
            
            
            app.NumTrialsCounterLabel.Text = num2str(num_trials);
            
            for i = 1:1
                app.moto.stim();
            end
            
            trial_value_buffer = [tmp_value_buffer(1:end - 1, 1) - trial_start_time, tmp_value_buffer(1:end - 1, 2)];
        end
        
        if trial_started
            trial_time = time_now - trial_start_time;
            trial_value_buffer = [trial_value_buffer; trial_time, moduleValue_now];
            
            
            if post_trial_pause
                %%  STIMULATION box
                switch app.StimCond
                    
                    case 0 % OFF
                        stim = false;
                        
                    case 1 % Reward Stimulation
                        
                        if success && ~stim && ...
                                moduleValue_now > (historical_HT_max - histo_tolerance )
                            
                            num_stimulations = num_stimulations + 1; % Increment the number of stimulations
                            stim = true;
                            app.moto.trigger_stim();
                            disp('Reward Stimulation');
                            fprintf('moduleValue_now = %.1f', moduleValue_now);
                            
                            app.NumStimulationsCounterLabel.Text = num2str(num_stimulations); % Update GUI for the number of stimulations
                            
                        end
                        
                    case 2 % Rand
                        % if Random, Check if it is the Stimulation trial
                        if RandStimIndex(num_trials) && ~stim
                            % Perform the stimulation for the trial
                            stim = true;
                            app.moto.trigger_stim();
                            disp('Random Stimulation...');
                            % Update the GUI for the number of stimulations
                            num_stimulations = num_stimulations + 1;
                            app.NumStimulationsCounterLabel.Text = num2str(num_stimulations);
                        end
                        
                        
                    case 3 % Manual
                        % if Manual, Check if stimulation button pushed
                        if app.StimOrder && ~stim
                            % Perform the stimulation for the trial
                            stim = true;
                            app.moto.trigger_stim();
                            disp('Manual Stimulation...');
                            % Update the GUI for the number of stimulations
                            num_stimulations = num_stimulations + 1;
                            app.NumStimulationsCounterLabel.Text = num2str(num_stimulations);
                        end
                        
                end
                
                
                
                if trial_time - trial_end_time > app.pause_duration && ~send_pellets
                    % Execute once after pause is over, trial is over.
                    % Fill results table and start new trial.
                    % turn OFF stimulation
                    
                    stim = false;
                    trial_table(num_trials, :) = {trial_start_time, current_init_thresh, current_hit_thresh, trial_value_buffer, ...
                        current_hold_time, trial_end_time, success, peak_moduleValue, stim, historical_HT_max};
                    
                    stim = false;
                    
                    set(app.angle_line, 'XData', trial_value_buffer(:, 1), ...
                        'YData', trial_value_buffer(:, 2));
                    ymax = max(app.hit_thresh.Value, peak_moduleValue) * 1.25;
                    ylim(app.moduleValueAxes, [-5 ymax]);
                    
                    peak_moduleValue = max(peak_moduleValue, moduleValue_now);
                    past_10_trials_peak_vect = [past_10_trials_peak_vect(2:end), peak_moduleValue];
                    past_10_trial_vect = [past_10_trial_vect(2:end),moduleValue_now];
                    
                    app.Median_peak = median(past_10_trials_peak_vect, 'omitnan');
                    
                    past_10_median_peak_vect = [past_10_median_peak_vect(2:end), app.Median_peak];

                    app.MedianPeakValueLabel.Text = num2str(app.Median_peak);
                    app.HistoricalHTValueLabel.Text = num2str(app.historical_HT_max);
                    post_trial_pause = false;
                    trial_started = false;
                    success = false;
                    peak_moduleValue = 0;
                    stim = false;
                    trial_value_buffer = [nan nan];
                    
                    if num_trials >= 500
                        disp('Reached maximum experiment duration (500 trials)');
                        app.stop_session = true;
                    end
                end
            else
                
                
                
                % $ failure conditions $
                %%    Failed?
                
                if trial_time > app.hit_window.Value &&....
                        moduleValue_now < app.hit_thresh.Value ||...
                        moduleValue_now <= (peak_moduleValue - failure_tolerance)
                    
                    fprintf('trial failed! :(\n');
                    
                    success = false;
                    post_trial_pause = true;
                    trial_end_time = trial_time;
                    play(failure_sound{1});
                    
                    past_10_trials_succ = [false, past_10_trials_succ(1:end - 1)];
                    
                    % send 2 digital pulses
                    for i = 1:2
                        app.moto.stim();
                    end
                    
                    % if less than 50% sucess rate,decrease hit_thresh by 2 deg.
                    if app.adapt_hit_thresh.Value && sum(past_10_trials_succ) <= 4
                        app.hit_thresh.Value = max(app.hit_thresh_min.Value, app.hit_thresh.Value - 2);
                        update_lines_in_fig(app);
                        fprintf('-> less than 50%% success rate, reduced Hit Threshold to %.0f deg or gram\n', app.hit_thresh.Value);
                    end
                    fprintf('\n');
                end
                
                
                %% SUCCESS?
                % if at least 'hold_time' &&
                if trial_time >= current_hold_time...
                        && (...
                         (app.StimCond == 1 && moduleValue_now > median(past_10_trial_vect,'omitnan'))...
                         ||...
                         (app.StimCond ~= 1 && all(trial_value_buffer(trial_value_buffer(:, 1) >= trial_time - current_hold_time, 2) >= app.hit_thresh.Value)))         
                    %% HERE
                   
                    historical_HT_max = max(historical_HT_max, app.Median_peak);
                    
                    
                    
                    % we have a success
                    fprintf('trial successful! :D\n');
                    
                    play(reward_sound{1});
                    drawnow;
                    success = true;
                    trial_end_time = trial_time;
                    send_pellets = 1;
                    past_10_trials_succ = [true, past_10_trials_succ(1:end - 1)];
                    
                    
                    % Send 3 digital pulses
                    for i = 1:3
                        app.moto.stim();
                        %pause(app.moto.stim_dur+0.01);
                    end
                    
                    %update stats & update gui
                    num_rewards = num_rewards + 1;
                    app.num_pellets = app.num_pellets + 1;
                    app.PelletsdeliveredCounterLabel.Text = sprintf('%d (%.3f g)', ...
                    sum(app.num_pellets) + app.man_pellets, (sum(app.num_pellets) + app.man_pellets) * 0.045); %each pellet 45mg
                    
                    app.NumRewardsCounterLabel.Text = num2str(num_rewards);
                    app.NumStimulationsCounterLabel.Text = num2str(num_stimulations);
                    
                    %force pause
                    post_trial_pause = true;
                    
                    % increase 'hit_thresh'?
                    % adaptive hit thresh
                    if app.adapt_hit_thresh.Value % && sum(past_10_trial_succ)>=7
                        % 70%?
                        if app.hit_thresh.Value <= app.hit_thresh_max.Value
                            app.hit_thresh.Value = min(app.hit_thresh_max.Value, app.hit_thresh_max.Value+2);
                            update_lines_in_fig(app);
                            fprintf('-> Hit Threshold increased to %.0f deg or gram\n', app.hit_thresh.Value);
                        end
                    end
                    
                    fprintf('\n');
                    
                end % END sucess
            end % END post-trial Pause
        end % END if trial started
        
        % give pellets when needed
        if send_pellets && time_now - last_pellet_time > app.pellets_pause
            app.moto.trigger_feeder(1);
            last_pellet_time = time_now;
            send_pellets = send_pellets - 1;
        end
        
        % update time
        app.TimeelapsedCounterLabel.Text = datestr(time_now / 86400, 'HH:MM:SS');
        
        drawnow limitrate; % update GUI and force fig
        
    end % END while
    
    disp('Session Ended');
    trial_table = trial_table(1:num_trials, :);
    mpeak = mean(trial_table.peak, 'omitnan');
    trial_table.Properties.CustomProperties.num_trials = num_trials;
    trial_table.Properties.CustomProperties.num_rewards = num_rewards;
    trial_table.Properties.CustomProperties.mean_peak = mpeak;
    trial_table.Properties.CustomProperties.rat_id = app.rat_id.Value;
    trial_table.Properties.CustomProperties.device = app.module;
    display_results(time_now, num_trials, num_rewards, app.num_pellets, app.man_pellets, mpeak);
    save_results(app, trial_table, crashed);
    
catch ME
    disp('MotoTrak crashed...');
    crashed = true;
    trial_table = trial_table(1:num_trials, :);
    mpeak = mean(trial_table.peak);
    trial_table.Properties.CustomProperties.num_trials = num_trials;
    trial_table.Properties.CustomProperties.num_rewards = num_rewards;
    trial_table.Properties.CustomProperties.mean_peak = mpeak;
    trial_table.Properties.CustomProperties.rat_id = app.rat_id.Value;
    trial_table.Properties.CustomProperties.device = app.module;
    display_results(time_now, num_trials, num_rewards, app.num_pellets, app.man_pellets, mpeak);
    save_results(app, trial_table, crashed, historical_hit_thresh_max_vec);
    rethrow(ME);
end


    function display_results(time,trials,rew,pel,manpel,mpeak)
        fprintf('duration: %s\n\n',datestr(time/86400,'HH:MM:SS'));
        disp('result summary:');
        disp('trials  rewards  pellets');
        fprintf('%d\t\t%d\t\t%d\n',trials, rew, pel+manpel);
        fprintf('manual feeding: %d pellets\n', manpel);
        fprintf('total pellets: %d (%.2f g)\n', pel+manpel, (pel+manpel)*0.045);
        fprintf('Mean Peak Value : %.0f deg or gram\n', mpeak);
    end

    function save_results(app, trial_table, crashed, historical_hit_thresh_max_vec)
        %reset the gui buttons
        app.STARTButton.Enable = true;
        app.STOPButton.Enable = false;
        
        if crashed
            SaveButton = questdlg(sprintf('MotoTrak Controller Crashed!\n Save results?'), 'Sorry about that...', 'Yes','No','Yes');
        else
            SaveButton = questdlg(sprintf('End of behavioral session\nSave results?'), 'End of Session', 'Yes','No','Yes');
        end
        
        if strcmp(SaveButton,'Yes')
            dir_exist = isfolder(fullfile(app.save_dir.Value,app.rat_id.Value));
            if ~dir_exist
                fprintf('Creating new folder for animal %s\n',app.rat_id.Value);
                dir_exist = mkdir(app.save_dir.Value,app.rat_id.Value);
                if ~dir_exist
                    disp('Failed to create new folder in specifiec location');
                end
            end
            
            if dir_exist
                fname = [app.rat_id.Value,'_MotoTrak_Knob_Results_',datestr(datetime('now'),'yyyymmdd_HHMMSS'),'.mat'];
                save(fullfile(app.save_dir.Value, app.rat_id.Value, fname), 'trial_table', 'historical_hit_thresh_max_vec');
                disp('behavior stats and parameters saved successfully');
                
                update_global_stats(app,trial_table);
            else
                disp('behavior stats and parameters not saved');
            end
            
        end
    end

end