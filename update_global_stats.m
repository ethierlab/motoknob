function global_stats = update_global_stats(rat_id,folder,trial_table)
%
%       This function looks for global_stats file in the folder\rat_id
%       folder and returns the last hit threshold it is used to confer
%       memory to the motoknob application
%      
%
%       
%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
filename = ([folder filesep rat_id filesep rat_id '_global_stats.mat']);
last_hit_thresh = [];

if exist([folder filesep rat_id]) 

    disp('A folder was found for this rat');

    if exist(filename)

        disp(['A global_stats file was found for the rat ' rat_id]);
        load (filename);

        mean_peak = trial_table.Properties.CustomProperties.mean_peak;
        num_rewards = trial_table.Properties.CustomProperties.num_rewards;
        num_trials= trial_table.Properties.CustomProperties.num_trials;
        start_time = trial_table.Properties.CustomProperties.start_time;
        initial_hit_thresh = trial_table.hit_thresh(1);
        last_hit_thresh = trial_table.hit_thresh(end);

        up_global_stats = table (start_time',num_trials',num_rewards',mean_peak',initial_hit_thresh', last_hit_thresh');
        up_global_stats.Properties.VariableNames = {'Start time','Number of reward','Number of trials','Mean Peak','Initial_hit_thresh','Last_hit_thresh'};
        global_stats = [global_stats;up_global_stats];
        save(filename,'global_stats');
        disp(['The global_stats file was updated for the rat ' rat_id]);

    else
        disp(['A global_stats file was not found for the rat ' rat_id]);

        mean_peak = trial_table.Properties.CustomProperties.mean_peak;
        num_rewards = trial_table.Properties.CustomProperties.num_rewards;
        num_trials= trial_table.Properties.CustomProperties.num_trials;
        start_time = trial_table.Properties.CustomProperties.start_time;
        initial_hit_thresh = trial_table.hit_thresh(1);
        last_hit_thresh = trial_table.hit_thresh(end);

        global_stats = table (start_time',num_trials',num_rewards',mean_peak',initial_hit_thresh', last_hit_thresh');
        global_stats.Properties.VariableNames = {'Start time','Number of reward','Number of trials','Mean Peak','Initial_hit_thresh','Last_hit_thresh'};
        save(filename,'global_stats');
        disp(['A global_stats file was created for the rat ' rat_id]);

    end

else
    disp(['A folder was not found for the rat ' rat_id]);

end

end