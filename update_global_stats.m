function global_stats = update_global_stats(app,trial_table)
%
%       This function looks for global_stats file in the app.save_dir.Value\app.rat_id.Value
%       app.save_dir.Value and createsor update memory global stat file with the trial table
%       values
%       
%
%
%
%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

filename = ([app.save_dir.Value filesep app.rat_id.Value filesep app.rat_id.Value '_global_stats.mat']);

%verify if the value of adapt hit thresh is true or false to complete the
%global stats table
if app.adapt_hit_thresh.Value == false
    hit_thresh_min = nan;
    hit_thresh_max = nan;
else 
    hit_thresh_min = app.hit_thresh_min.Value;
    hit_thresh_max = app.hit_thresh_max.Value;
end

    %Extract information
    mean_peak = trial_table.Properties.CustomProperties.mean_peak;
    num_rewards = trial_table.Properties.CustomProperties.num_rewards;
    num_trials= trial_table.Properties.CustomProperties.num_trials;
    start_time = trial_table.Properties.CustomProperties.start_time;
    initial_hit_thresh = trial_table.hit_thresh(1);

    %Create table with updated information
    up_global_stats = table (start_time,num_trials,num_rewards,mean_peak,initial_hit_thresh,app.hit_thresh.Value,app.knob_pos.Value,app.hit_window.Value,app.adapt_hit_thresh.Value,hit_thresh_min,hit_thresh_max);
    up_global_stats.Properties.VariableNames = {'Start_time','Number_of_trials','Number_of_reward','Mean_Peak','Initial_hit_thresh','Last_hit_thresh','Knob_position','Hit_window','Adaptive','Adapt_hit_min_thresh','Adapt_hit_max_thresh'};

if ~exist([app.save_dir.Value filesep app.rat_id.Value], 'dir')
    disp(['A folder was not found for the rat ' app.rat_id.Value]);
    mkdir([app.save_dir.Value filesep app.rat_id.Value]);
else
    disp('A folder was found for this rat');
end

%complete existing global stats
if exist(filename,'file')
    
    disp(['A global_stats file was found for the rat ' app.rat_id.Value]);
    global_stats = load(filename);
    global_stats = global_stats.global_stats;
    
    %Check if we have additional variable name than previous file
    global_stats.Properties.VariableNames= strrep(global_stats.Properties.VariableNames, ' ', '_'); %If there is a space variable name it replaces by an underscore
    newvar=~ismember(up_global_stats.Properties.VariableNames,global_stats.Properties.VariableNames);
    for i=find(newvar)
        %if so, add variable to previous table with nan
        global_stats.(up_global_stats.Properties.VariableNames{i})=nan(size(global_stats,1),1);
    end

    %merge the new table
    global_stats = [global_stats;up_global_stats];
    save(filename,'global_stats');
    disp(['The global_stats file was updated for the rat ' app.rat_id.Value]);

    %create global stats
else
    disp(['A global_stats file was not found for the rat ' app.rat_id.Value]);   
    global_stats = up_global_stats;
    save(filename,'global_stats');
    disp(['A global_stats file was created for the rat ' app.rat_id.Value]);
end

