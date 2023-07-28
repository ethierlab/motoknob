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
start_time = datetime('now');
% v32
num_stimulations = 0;


% pre-allocate table with MaxTrialNum trials to save trial-based results
sz = [app.MaxTrialNum.Value 10];
varTypes = {'doubleNaN', 'doubleNaN', 'doubleNaN', 'cell',...
    'doubleNaN', 'doubleNaN', 'logical', 'doubleNaN', 'logical','doubleNaN'};

varNames = {'start_time', 'init_thresh', 'hit_thresh', 'AngleOrForce',...
    'hold_time', 'duration', 'success', 'peak', 'stim','Historical_HT'};

trial_table = table('Size', sz, 'VariableTypes', varTypes, 'VariableNames', varNames);

trial_table = addprop(trial_table, {'ver', 'num_rewards', 'num_trials','num_stimulations', 'start_time', 'mean_peak', 'rat_id', 'device','Historical_HT'}, {'table', 'table', 'table', 'table', 'table', 'table', 'table', 'table', 'table'});
trial_table.Properties.CustomProperties.ver = 1.2;
trial_table.Properties.CustomProperties.start_time = start_time;

% variables for task logics
tmp_value_buffer = [nan nan]; % [time value], first row is oldest data
trial_value_buffer = [nan nan]; % [time value]
past_10_trial_succ = false(1, 10);
past_10_trials_peak_vect = nan(1, 10);
past_10_median_peak_vect = nan(1, 10);

current_hold_time = nan;
current_hit_thresh = nan;
Historical_HT = nan;
current_init_thresh = nan;
send_pellets = 0;
moduleValue_now = 0;
peak_moduleValue = 0;

trial_started = false;
post_trial_pause = false;
behavPulse = false;
stim = false;
rand_stim = false;
success = false;
crashed = false;

switch app.DGToutput
    case 'DO_behav'
        behavPulse = true;

    case 'DO_stim'
        switch app.StimCond
            case 'stim_random'
                rand_stim = true;
        end
end


experiment_start = tic;
loop_timer = tic;
last_pellet_time = toc(experiment_start);
disp('experiment started!')

try
    %% Main experiment loop
    while ((toc(experiment_start) < app.duration.Value * 60) || (num_trials < app.MaxTrialNum.Value)) && ~app.stop_session && ishandle(app.MotoTrakKnobUIFigure)

        time_now = toc(experiment_start);
        moduleValue_before = moduleValue_now;

        % read device signal (knob or lever)
        % for lever : same equation Deepshika use
        moduleValue_now = (app.moto.read_Pull() - app.moto.baseline) * app.moto.slope; % p(1) = slope; p(2) zero-crossing

        % TODO: use moto.read_stream()? seems to freeze when tried. are we
        % missing a lot of data points?

        peak_moduleValue = max(peak_moduleValue, moduleValue_now);

        %limit temp buffer size to 'buffer_dur' (1s of data)
        tmp_value_buffer = [tmp_value_buffer(time_now - tmp_value_buffer(:, 1) <= app.buffer_dur, :); time_now moduleValue_now];


        % warn if longer than expected loop delays

        %% Pause Loop
        while app.pause_session
            drawnow limitrate; % update GUI and force fig
        end

        loop_time = toc(loop_timer);
        if loop_time > 0.1
            fprintf('--- WARNING --- \nlong delay in while loop (%.0f ms)\n', loop_time * 1000);
        end
        loop_timer = tic;


        %% trial initiation
        if ~trial_started && moduleValue_now >= app.init_thresh.Value && moduleValue_before < app.init_thresh.Value


            trial_started = true;
            trial_start_time = time_now;

            % read values from GUI
            current_hold_time = app.hold_time.Value;
            current_hit_thresh = app.hit_thresh.Value;
            current_init_thresh = app.init_thresh.Value;
            Historical_HT = app.Historical_HT.Value;



            disp('Trial initiated... ');
            num_trials = num_trials + 1;


            % update GUI
            app.NumTrialsCounterLabel.Text = num2str(num_trials);

            % Output one digital pulse for onset of trial
            if behavPulse
                for i = 1:app.nPulse_init.Value
                    app.moto.stim(1);
                end
            end

            % start recording angle data (%skip last entry, it will be added below after the "if trial_started" section
            trial_value_buffer = [tmp_value_buffer(1:end - 1, 1) - trial_start_time, tmp_value_buffer(1:end - 1, 2)];
        end

        %% ongoing trial
        if trial_started

            trial_time = time_now - trial_start_time;
            trial_value_buffer = [trial_value_buffer; trial_time, moduleValue_now];

            %% Post trial pause
            if post_trial_pause


                %  stimulation on random or HT_max trials?
                if stim
                    %                     && (time_now - last_pellet_time > app.pellets_pause)
                    app.moto.trigger_stim(1);
                    num_stimulations = num_stimulations + 1; % Increment the number of stimulations
                    app.NumStimulationsCounterLabel.Text = num2str(num_stimulations); % Update GUI for the number of stimulations
                    stim = false;
                end


                %% end of post_trial_pause (executes once)
                if trial_time - trial_end_time > app.pause_duration && ~send_pellets
                    % Execute once after pause is over, trial is over.
                    % Fill results table and start new trial.


                    trial_table(num_trials, :) = {trial_start_time, current_init_thresh, current_hit_thresh, trial_value_buffer, ...
                        current_hold_time, trial_end_time, success, peak_moduleValue, stim, Historical_HT};

                    % update angle plot
                    set(app.angle_line, 'XData', trial_value_buffer(:, 1), ...
                        'YData', trial_value_buffer(:, 2));
                    ymax = max(app.hit_thresh.Value, peak_moduleValue) * 1.25;
                    ylim(app.moduleValueAxes, [-5 ymax]);


                    %reset trial variables
                    past_10_trials_peak_vect = [past_10_trials_peak_vect(2:end), peak_moduleValue];

                    app.Median_peak = median(past_10_trials_peak_vect, 'omitnan');
                    past_10_median_peak_vect = [past_10_median_peak_vect(2:end), app.Median_peak];
                    app.MedianPeakValueLabel.Text = num2str(app.Median_peak);
                    %                      app.Historical_HT.Text = num2str(app.Historical_HT.Value);

                    post_trial_pause = false;
                    trial_started = false;
                    success = false;
                    peak_moduleValue = 0;
                    stim = false;
                    trial_value_buffer = [nan nan];

                    if num_trials > app.MaxTrialNum.Value
                        disp(['Reached maximum experiment duration (', num2str(app.MaxTrialNum.Value), ' trials)']);
                        app.stop_session = true;
                    end
                end


            else

                %%    Failed?
                if trial_time > app.hit_window.Value && moduleValue_now < app.hit_thresh.Value
                    %                          || moduleValue_now <= (peak_moduleValue - app.failure_tolerance.Value)

                    fprintf('trial failed! :(\n');
                    fprintf('module Value = %.1f', moduleValue_now);

                    success = false;
                    post_trial_pause = true;
                    trial_end_time = trial_time;
                    play(failure_sound{1});

                    past_10_trial_succ = [false, past_10_trial_succ(1:end - 1)];

                    % send 2 digital pulses
                    if behavPulse
                        for i = 1:app.nPulse_fail.Value
                            app.moto.stim(1);
                        end
                    end

                    % if less than 50% sucess rate,decrease hit_thresh by 2 deg.
                    if app.adapt_hit_thresh.Value && sum(past_10_trial_succ) <= 4
                        app.hit_thresh.Value = max(app.hit_thresh_min.Value, app.hit_thresh.Value - 2);
                        update_lines_in_fig(app);
                        fprintf('-> less than 50%% success rate, reduced Hit Threshold to %.0f deg \n', app.hit_thresh.Value);
                    end
                    fprintf('\n');
                end


                %% SUCCESS?
                % if at least 'hold_time' &&
                if trial_time >= current_hold_time &&...
                        all( trial_value_buffer( trial_value_buffer(:,1)>=trial_time-current_hold_time ,2)>= app.hit_thresh.Value) % if all values during hold time are above hit thresh

                    % we have a success
                    fprintf('trial successful! :D\n');

                    play(reward_sound{1});
                    drawnow;
                    success = true;
                    trial_end_time = trial_time;
                    send_pellets = 1;
                    past_10_trial_succ = [true, past_10_trial_succ(1:end - 1)];


                    % Send 3 digital pulses
                    if behavPulse
                        for i = 1:app.nPulse_success.Value
                            app.moto.stim(1);
                            %                             pause(app.moto.stim_dur);
                        end
                    end

                    %update stats & update gui
                    num_rewards = num_rewards + 1;
                    app.num_pellets = app.num_pellets + 1;
                    app.PelletsdeliveredCounterLabel.Text = sprintf('%d (%.3f g)', sum(app.num_pellets) + app.man_pellets, (sum(app.num_pellets) + app.man_pellets) * 0.045); %each pellet 45mg
                    app.NumRewardsCounterLabel.Text = num2str(num_rewards);
                    app.NumStimulationsCounterLabel.Text = num2str(num_stimulations);

                    %force pause
                    post_trial_pause = true;

                    % increase 'hit_thresh'?
                    % adaptive hit thresh
                    if app.adapt_hit_thresh.Value && sum(past_10_trial_succ)>=7
                        % 70%?
                        if app.hit_thresh.Value <= app.hit_thresh_max.Value
                            app.hit_thresh.Value = min(app.hit_thresh_max.Value, app.hit_thresh.Value+2);
                            update_lines_in_fig(app);
                            fprintf('-> Hit Threshold increased to %.0f deg\n', app.hit_thresh.Value);

                            % Increase Historical hit thresh max?
                            app.Historical_HT.Value = max(app.Historical_HT.Value, app.hit_thresh.Value);
                        end
                    end
                    fprintf('\n');
                end % END sucess

                % stim VTA ?
                if ~rand_stim && ~behavPulse && (peak_moduleValue >= (app.Historical_HT.Value - app.histo_tolerance.Value))
                    stim = true;
                    disp('Conditional Stimulation...\n');
                    fprintf('peak moduleValue = %.1f', peak_moduleValue);
                end
                if rand_stim
                    stim = app.randStimRate.Value/100 > rand();
                    if stim
                        disp('Random Stimulation...');
                    end
                end

            end % END post-trial Pause if/else

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
    trial_table.Properties.CustomProperties.num_stimulations = num_stimulations;
    trial_table.Properties.CustomProperties.mean_peak = mpeak;
    trial_table.Properties.CustomProperties.rat_id = app.rat_id.Value;
    trial_table.Properties.CustomProperties.device = app.module;
    trial_table.Properties.CustomProperties.Historical_HT = app.Historical_HT.Value;
    display_results(time_now, num_trials, num_rewards, num_stimulations, app.num_pellets, app.man_pellets, mpeak, app.Historical_HT.Value);
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
    trial_table.Properties.CustomProperties.Historical_HT = app.Historical_HT.Value;
    display_results(time_now, num_trials, num_rewards, app.num_pellets, app.man_pellets, mpeak, app.Historical_HT.Value);
    save_results(app, trial_table, crashed);
    rethrow(ME);
end
Historical_HT=app.Historical_HT.Value;

    function display_results(time,trials,rew,pel,manpel,mpeak,Historical_HT)
        fprintf('duration: %s\n\n',datestr(time/86400,'HH:MM:SS'));
        disp('result summary:');
        disp('trials  rewards  pellets');
        fprintf('%d\t\t%d\t\t%d\n',trials, rew, pel+manpel);
        fprintf('manual feeding: %d pellets\n', manpel);
        fprintf('total pellets: %d (%.2f g)\n', pel+manpel, (pel+manpel)*0.045);
        fprintf('current historical HT max: %d \n', Historical_HT);
        fprintf('Mean Peak Value: %.0f deg \n', mpeak);
    end

    function save_results(app, trial_table, crashed)
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
                save(fullfile(app.save_dir.Value, app.rat_id.Value, fname), 'trial_table');
                disp('behavior stats and parameters saved successfully');

                update_global_stats(app,trial_table);
            else
                disp('behavior stats and parameters not saved');
            end

        end
    end
end
