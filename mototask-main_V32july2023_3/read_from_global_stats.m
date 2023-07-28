function [last_hit_thresh, last_median_peak, historical_HT] = read_from_global_stats(rat_id,folder,module)
%
% This function looks for global_stats file in the folder\rat_id
% folder and returns the last hit threshold it is used to confer
% memory to the motoknob application
%
%
%
%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
filename = ([folder filesep rat_id filesep rat_id '_global_stats.mat']);
last_hit_thresh = [];
last_median_peak = 0;
historical_HT = 0;

if exist([folder filesep rat_id]) ==7

    disp('A folder was found for this rat');

    if exist(filename)

        disp(['A global_stats file was found for the rat ' rat_id]);
        load (filename);

        for i = 1:size(global_stats, 1)
            if strcmp(module, global_stats.device{i})
               
                last_hit_thresh = global_stats.Last_hit_thresh(i);

                if any(strcmp('Last_median_peak', global_stats.Properties.VariableNames))
                    last_median_peak = global_stats.Last_median_peak(i);
                end

            end

        end
        if any(strcmp('Historical_HT', global_stats.Properties.VariableNames))
            historical_HT = global_stats.Historical_HT(end);
        end

    else
        disp(['A global_stats file was not found for the rat ' rat_id]);

    end

else
    disp(['A folder was not found for the rat ' rat_id]);

end

end
