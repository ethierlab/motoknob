function params = mototrak_knob_params(varargin)

    default_params = struct(...
        'rat_id'             , '123',...
        'save_dir'           , 'C:\MotoTrak Files\', ...
        'hit_window'         , 2,...
        'duration'           , 30*60,...
        'init_thresh'        , 5,...
        'knob_pos'           , 1,...
        'hold_time'          , 0,...
        'adapt_hold_time'    , false,...
        'hold_time_min'      , 0,...
        'hold_time_max'      , 1000,...
        'hit_thresh'         , 30,...
        'adapt_hit_thresh'   , false,...
        'hit_thresh_min'     , 20,...
        'hit_thresh_max'     , 70,...
        'hit_ceil'           , 50,...
        'adapt_hit_ceil'     , false,...
        'hit_ceil_min'       , 40,...
        'hit_ceil_max'       , 60,...
        'past_10_trials_succ', false(1,10),...
        'reward_sound'       , 4000 ,...
        'failure_sound'      , 1000,...
        'pellets_pause'      , 1.5,...
        'pause_duration'     , 2,...
        'buffer_dur'         , 1 ...
        );
    
    if nargin
        params = varargin{1};
        %some parameters are provided as argument, fill the rest:
        all_param_names = fieldnames(default_params);
        for i=1:numel(all_param_names)
            if ~isfield(params,all_param_names(i))
                params.(all_param_names{i}) = default_params.(all_param_names{i});
            end
        end
    else
        params = default_params;
    end
    