function historical_HT_max = load_historical_HT_max(rat_id, folder)
%
%   This function looks for the global_stats file in the folder\rat_id
%   folder and returns the historical HT max.
%   It is used to confer memory to the motoknob application.
%
%   Inputs:
%   - rat_id: The ID of the rat.
%   - folder: The folder path where the global_stats file is located.
%
%   Output:
%   - historical_HT_max: The historical HT max.
%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
filename = [folder filesep rat_id filesep rat_id '_global_stats.mat'];
historical_HT_max = [];

if exist([folder filesep rat_id], 'dir') == 7
    disp('A folder was found for this rat');

    if exist(filename, 'file')
        disp(['A global_stats file was found for the rat ' rat_id]);
        load(filename);

        if any(strcmp('Historical_HT_max', global_stats.Properties.VariableNames))
            historical_HT_max = global_stats.Historical_HT_max(end);
        end
    else
        disp(['A global_stats file was not found for the rat ' rat_id]);
    end
else
    disp(['A folder was not found for the rat ' rat_id]);
end
end
