function [trial_table, crashed]  = mototrak_knob_controller(app)
%
%       This function controls a mototrak behavioral experiment, in which
%       the rats are required to turn the knob
%
%       TODO: add more here...
%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%% Mototrak and sound initialization
if app.knob_pos.Value > 4 || app.knob_pos.Value < -2
    warning('specified lever position was %.2f, but it must be between -2 and 4 (cm)',app.knob_pos.Value);
    return;
end

% move to specified position
app.moto.autopositioner(-100*(app.knob_pos.Value-4.75));

%  sounds = speaker_sounds(freqs,duration,amplitude);
reward_sound      = speaker_sounds(app.reward_sound     ,0.3,10);
failure_sound     = speaker_sounds(app.failure_sound    ,0.3,10);

%% Initialization

% variables for overall stats
num_rewards = 0;
num_trials  = 0;
start_time  = datetime('now');
       
% pre-allocate table with 500 trials to save trial-based results
sz = [500 8];
varTypes = {'doubleNaN','doubleNaN','doubleNaN','cell',...
        'doubleNaN','doubleNaN','logical','doubleNaN'};
varNames = {'start_time', 'init_thresh', 'hit_thresh','angle',...
        'hold_time', 'duration', 'success', 'peak'};
trial_table = table('Size',sz,'VariableTypes',varTypes,'VariableNames',varNames);
trial_table = addprop(trial_table,{'ver','num_rewards','num_trials','start_time','mean_peak'},{'table','table','table','table','table'});
trial_table.Properties.CustomProperties.ver = 1.0;
trial_table.Properties.CustomProperties.start_time = start_time;


% % wait until user is ready to start
% uiwait(msgbox('Click OK when ready to start!','Ready?','modal'));

% variables for task logics
tmp_angle_buffer   = [nan nan]; % [time angle], first row is oldest data
trial_angle_buffer = [nan nan]; % [time angle]
past_10_trials_succ= false(1,10);
trial_started      = false;
post_trial_pause   = false;
current_hold_time  = nan;
current_hit_thresh = nan;
current_init_thresh= nan;
send_pellets       = 0;
angle_now          = 0;
peak_angle         = 0;
success            = false;
crashed            = false;

experiment_start=tic;
loop_timer = tic;
last_pellet_time = toc(experiment_start);
disp('experiment started!')

try
    %% Main experiment loop
    while toc(experiment_start)<app.duration.Value*60 && ~app.stop_session && ishandle(app.MotoTrakKnobUIFigure)
        
        time_now     = toc(experiment_start);
        angle_before = angle_now;
        % TODO: use moto.read_stream()? seems to freeze when tried. are we
        % missing a lot of data points?        
        angle_now    = (app.moto.read_Pull()-app.moto.baseline)*app.moto.slope;
        peak_angle   = max(peak_angle, angle_now);        

        %limit temp buffer size to 'buffer_dur' (1s of data)
        tmp_angle_buffer = [tmp_angle_buffer(time_now-tmp_angle_buffer(:,1)<=app.buffer_dur,:); time_now angle_now];
        
        % warn if longer than expected loop delays
        loop_time = toc(loop_timer);
        if loop_time > 0.1
            fprintf('--- WARNING --- \nlong delay in while loop (%.0f ms)\n',loop_time*1000);
        end
        loop_timer = tic;        
        
        %% trial initiation
        if ~trial_started && angle_now >= app.init_thresh.Value && angle_before < app.init_thresh.Value
            trial_started       = true;
            trial_start_time    = time_now;
            current_hold_time   = app.hold_time.Value;
            current_hit_thresh  = app.hit_thresh.Value;
            current_init_thresh = app.init_thresh.Value; 
            peak_angle          = angle_now; % don't consider possible higher pre-trial peaks
            
            disp('Trial initiated... ');
            num_trials =  num_trials+1;
            
            % update GUI
            app.NumTrialsCounterLabel.Text = num2str(num_trials);
            
            % start recording angle data (%skip last entry, it will be added below after the "if trial_started" section
            trial_angle_buffer = [tmp_angle_buffer(1:end-1,1)-trial_start_time tmp_angle_buffer(1:end-1,2)];
        end
        
        %% ongoing trial
        if trial_started
            
            trial_time = time_now-trial_start_time;
            trial_angle_buffer = [trial_angle_buffer; trial_time angle_now];
            
            % update angle plot
            set(app.angle_line,'XData', trial_angle_buffer(:,1),...
                'YData',trial_angle_buffer(:,2));
            ymax = max(app.hit_thresh.Value, peak_angle)*1.25;
            ylim(app.KnobAngleAxes,[-5 ymax]);
            
            if post_trial_pause 
                if trial_time-trial_end_time > app.pause_duration && ~send_pellets 
                    %Executes once after pause is over, trial is over. fill result table and start new trial
                    trial_table(num_trials,:) = {trial_start_time, current_init_thresh, current_hit_thresh, trial_angle_buffer,...
                        current_hold_time, trial_end_time, success, peak_angle};
                    
                    %reset trial variables
                    post_trial_pause   = false;
                    trial_started      = false;
                    success            = false;
                    peak_angle         = 0;
                    trial_angle_buffer = [nan nan];
                    
                    if num_trials >=500
                        disp('Reached maximum experiment duration (500 trials)');
                        app.stop_session = true;
                    end
                    
                end
            else
                
                % Failed?
                if trial_time > app.hit_window.Value && angle_now < app.hit_thresh.Value || angle_now <= peak_angle-10
                    %trial failed
                    fprintf('trial failed! :(\n');
                    post_trial_pause = true;
                    trial_end_time   = trial_time;
                    play(failure_sound{1});
                    
                    past_10_trials_succ = [false past_10_trials_succ(1:end-1)];
                    
                    % send 2 digital pulses
                    for i=1:2
                        app.moto.trigger_stim();
                    end
                    
                    %decrease hit_tresh?
                    if app.adapt_hit_thresh.Value && sum(past_10_trials_succ)<=4
                        % less than 50% success rate, decrease hit threshold by 2 deg.
                        app.hit_thresh.Value = max(app.hit_thresh_min.Value,app.hit_thresh.Value -2);
                        fprintf('-> less than 50%% success rate, reduced Hit Threshold to %.0f deg\n', app.hit_thresh.Value);
                    end
                    fprintf('\n');
                end % end Failed
                
                % Success?
                % if we are at least 'hold_time' past trial init, and if force was always above 'hit_thresh'
                % for the last 'hold_time'...
                if trial_time >= current_hold_time && ...
                        all( trial_angle_buffer( trial_angle_buffer(:,1)>=trial_time-current_hold_time ,2)>= app.hit_thresh.Value)
                    % we have a success
                    fprintf('trial successful! :D\n');
                    
                    play(reward_sound{1});
                    drawnow;
                    success  = true;
                    trial_end_time = trial_time;
                    send_pellets   = 1;
                    past_10_trials_succ = [true past_10_trials_succ(1:end-1)];
                    
                    %send 1 digital pulse
                    app.moto.trigger_stim();
                    
                    %update stats & update gui
                    num_rewards     = num_rewards+1;
                    app.num_pellets     = app.num_pellets+1;
                    app.PelletsdeliveredCounterLabel.Text = sprintf('%d (%.3f g)', ...
                        sum(app.num_pellets)+app.man_pellets, (sum(app.num_pellets)+app.man_pellets)*0.045);
                    app.NumRewardsCounterLabel.Text = num2str(num_rewards);
                    
                    %force pause
                    post_trial_pause = true;

                    %increase hit_thresh?
                    if app.adapt_hit_thresh.Value && sum(past_10_trials_succ)>=7
                        % more than 70% success rate, increase hold time by 2 deg.
                        if app.hit_thresh.Value <= app.hit_thresh_max.Value
                            app.hit_thresh.Value = min(app.hit_thresh_max.Value, app.hit_thresh.Value+2);
                            update_lines_in_fig(app);
                            fprintf('-> more than 70%% success rate, increased Hit Threshold to %.0f deg\n', app.hit_thresh.Value);
                        end
                    end
                    fprintf('\n');  
                end % end Success
                
             end % end Else post-trial pause 
            
        end % if trial started
        
        % give pellets when needed
        if send_pellets && time_now-last_pellet_time>app.pellets_pause
            app.moto.trigger_feeder(1);
            last_pellet_time = time_now;
            send_pellets = send_pellets-1;
        end
                    
        % update Time
        app.TimeelapsedCounterLabel.Text = datestr(time_now/86400,'HH:MM:SS');
  
        drawnow limitrate; %update GUI and force fig
        
    end % End While Loop
    
    %% end of session: display and save results
    disp('Session ended');
    trial_table = trial_table(1:num_trials,:);
    mpeak = mean(trial_table.peak,'omitnan');
    trial_table.Properties.CustomProperties.num_trials  = num_trials;
    trial_table.Properties.CustomProperties.num_rewards = num_rewards;
    trial_table.Properties.CustomProperties.mean_peak   = mpeak;
    trial_table.Properties.CustomProperties.rat_id = rat_id;
    display_results(time_now,num_trials,num_rewards,app.num_pellets,app.man_pellets,mpeak);
    save_results(app,trial_table,crashed);
    
catch ME
    disp('MotoTrak crashed...');
    crashed = true;
    trial_table = trial_table(1:num_trials,:);
    mpeak = mean(trial_table.peak);
    trial_table.Properties.CustomProperties.num_trials  = num_trials;
    trial_table.Properties.CustomProperties.num_rewards = num_rewards;
    trial_table.Properties.CustomProperties.mean_peak   = mpeak;
    trial_table.Properties.CustomProperties.rat_id = rat_id;
    display_results(time_now,num_trials,num_rewards,app.num_pellets,app.man_pellets,mpeak);
    save_results(app,trial_table,crashed);
    rethrow(ME);
end

end

function display_results(time,trials,rew,pel,manpel,mpeak)
    fprintf('duration: %s\n\n',datestr(time/86400,'HH:MM:SS'));
    disp('result summary:');
    disp('trials  rewards  pellets');
    fprintf('%d\t\t%d\t\t%d\n',trials, rew, pel);
    fprintf('manual feeding: %d pellets\n', manpel);
    fprintf('total pellets: %d (%.2f g)\n', pel+manpel, pel+manpel*0.045);
    fprintf('Mean Peak Angle : %.0f deg\n', mpeak);
end
    
function save_results(app,trial_table,crashed)

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
         save(fullfile(app.save_dir.Value,app.rat_id.Value,fname),'trial_table');
        disp('behavior stats and parameters saved successfully');


    else
        disp('behavior stats and parameters not saved');
    end
end

end
