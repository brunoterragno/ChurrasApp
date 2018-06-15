import axios from 'axios';
import { Map } from 'immutable';

import { API_URL } from '../config';
import { getStateWithFieldErrors, getInsertObject } from './helpers';

// Default
axios.defaults.baseURL = API_URL;
axios.defaults.headers.post['Content-Type'] = 'application/json';
axios.defaults.headers.put['Content-Type'] = 'application/json';

// Actions
const CHURRAS_LOAD = 'churras.web.react/churras/LOAD';
const CHURRAS_LOAD_FAIL = 'churras.web.react/churras/LOAD_FAIL';
const CHURRAS_LOAD_SUCCESS = 'churras.web.react/churras/LOAD_SUCCESS';

const CHURRAS_CREATE = 'churras.web.react/churras/CREATE';
const CHURRAS_CREATE_SUCCESS = 'churras.web.react/churras/CREATE_SUCCESS';
const CHURRAS_CREATE_FAIL = 'churras.web.react/churras/CREATE_FAIL';

const CHURRAS_UPDATE = 'churras.web.react/churras/UPDATE';
const CHURRAS_UPDATE_SUCCESS = 'churras.web.react/churras/UPDATE_SUCCESS';
const CHURRAS_UPDATE_FAIL = 'churras.web.react/churras/UPDATE_FAIL';

const CHURRAS_DELETE = 'churras.web.react/churras/REMOVE';
const CHURRAS_DELETE_SUCCESS = 'churras.web.react/churras/DELETE_SUCCESS';
const CHURRAS_DELETE_FAIL = 'churras.web.react/churras/DELETE_FAIL';

// Reducer
const NEW_ITEM = Map({
  loading: false,
  title: { value: null, error: '' },
  date: { value: new Date(), error: '' },
  description: { value: null, error: '' },
  costWithDrink: { value: null, error: '' },
  costWithoutDrink: { value: null, error: '' }
});

const INITIAL_STATE = Map({
  loading: false,
  items: Map([]),
  newItem: NEW_ITEM
});

export default (state = INITIAL_STATE, action = {}) => {
  switch (action.type) {
    // do reducer stuff
    case CHURRAS_LOAD:
      return state.set('loading', true);
    case CHURRAS_LOAD_SUCCESS:
      return state.set('loading', false).set('items', action.payload);
    case CHURRAS_LOAD_FAIL:
      return state.set('loading', false).set('items', []);

    case CHURRAS_CREATE:
      return state.setIn(['newItem', 'loading'], true);
    case CHURRAS_CREATE_SUCCESS:
      return state.set('newItem', NEW_ITEM);
    case CHURRAS_CREATE_FAIL:
      return getStateWithFieldErrors(state, 'newItem', action.payload);

    case CHURRAS_UPDATE:
      return state.setIn(['newItem', 'loading'], true);
    case CHURRAS_UPDATE_SUCCESS:
      return state.set('newItem', NEW_ITEM);
    case CHURRAS_UPDATE_FAIL:
      return getStateWithFieldErrors(state, 'newItem', action.payload);

    case CHURRAS_DELETE:
      return state.set('loading', true);
    case CHURRAS_DELETE_SUCCESS:
      // TODO: remove locally
      return state.set('loading', false).set('items', []);
    case CHURRAS_DELETE_FAIL:
      // TODO: set error
      return state.set('loading', false);

    default:
      return state;
  }
};

// Action Creators
export const loadChurras = () => dispatch => {
  dispatch({
    type: CHURRAS_LOAD
  });
};

export const loadChurrasSuccess = churras => dispatch => {
  dispatch({
    type: CHURRAS_LOAD_SUCCESS,
    payload: churras
  });
};

export const createChurras = () => dispatch => {
  dispatch({
    type: CHURRAS_CREATE,
    payload: null
  });
};

export const createChurrasSuccess = () => dispatch => {
  dispatch({
    type: CHURRAS_CREATE_SUCCESS,
    payload: null
  });
};

export const createChurrasFail = errors => dispatch => {
  dispatch({
    type: CHURRAS_CREATE_FAIL,
    payload: errors
  });
};

export const updateChurras = () => dispatch => {
  dispatch({
    type: CHURRAS_UPDATE,
    payload: null
  });
};

export const deleteChurras = () => dispatch => {
  dispatch({
    type: CHURRAS_DELETE,
    payload: null
  });
};

// side effects, only as applicable
// e.g. thunks, epics, etc
export const getChurras = () => dispatch => {
  dispatch(loadChurras());
  axios
    .get(`barbecues?PageNumber=1&PageSize=20`)
    .then(res => dispatch(loadChurrasSuccess(res.data)))
    .catch(err => console.log(err));
};

export const postChurras = churras => dispatch => {
  dispatch(createChurras());
  axios
    .post('barbecues', JSON.stringify(getInsertObject(churras)))
    .then(res => dispatch(createChurrasSuccess(res.data)))
    .catch(err => dispatch(createChurrasFail(err.response.data.errors)));
};
