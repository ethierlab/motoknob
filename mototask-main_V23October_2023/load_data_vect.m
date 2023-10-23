function load_data_vect()
    % Open a file dialog to select the file
    [filename, filepath] = uigetfile('*.mat', 'Select Results File');
    
    if isequal(filename, 0) || isequal(filepath, 0)
        % User canceled the file selection
        disp('File selection canceled.');
        return;
    end
    
    % Construct the full file path
    fullpath = fullfile(filepath, filename);
    
    % Load the data from the file
    try
        data = load(fullpath, 'historical_hit_thresh_max_vec');
        historical_hit_thresh_max_vec = data.historical_hit_thresh_max_vec;
        
        % Process the loaded data as needed
        disp('Historical hit threshold loaded successfully.');
    catch
        disp('Error loading the file.');
    end
end
