function last_hit_thresh = find_last_hit_thresh(rat_id,folder)
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

if exist([folder filesep rat_id]) ==7

    disp('A folder was found for this rat');

    if exist(filename)

        disp(['A global_stats file was found for the rat ' rat_id]);
        load (filename);
        last_hit_thresh=global_stats.Last_hit_thresh(end);

    else
        disp(['A global_stats file was not found for the rat ' rat_id]);

    end

else
    disp(['A folder was not found for the rat ' rat_id]);

end

end
