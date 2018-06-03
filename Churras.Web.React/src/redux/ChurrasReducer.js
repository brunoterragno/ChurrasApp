import axios from 'axios';
import { Map } from 'immutable';

import { API_URL } from '../config';

// Actions
const CHURRAS_LOAD = 'churras.web.react/churras/LOAD';
const CHURRAS_LOAD_FAIL = 'churras.web.react/churras/LOAD_FAIL';
const CHURRAS_LOAD_SUCCESS = 'churras.web.react/churras/LOAD_SUCCESS';
const CHURRAS_CREATE = 'churras.web.react/churras/CREATE';
const CHURRAS_UPDATE = 'churras.web.react/churras/UPDATE';
const CHURRAS_DELETE = 'churras.web.react/churras/REMOVE';

// Reducer
const INITIAL_STATE = Map({
  items: []
});

export default (state = INITIAL_STATE, action = {}) => {
  switch (action.type) {
    // do reducer stuff
    case CHURRAS_LOAD:
      return state.set('items', action.payload);
    default:
      return state;
  }
};

// Action Creators
export const loadChurras = churras => dispatch => {
  dispatch({
    type: CHURRAS_LOAD,
    payload: churras
  });
};

export const createChurras = () => dispatch => {
  dispatch({
    type: CHURRAS_CREATE,
    payload: null
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
  axios
    .get(`${API_URL}/barbecues?PageNumber=1&PageSize=20`)
    .then(res => dispatch(loadChurras(res.data)))
    .catch(err => console.log(err));
};

export const postChurras = churras => dispatch => {
  axios
    .post(`${API_URL}/barbecues`, JSON.stringify(churras))
    .then(res => dispatch(createChurras(res.data)))
    .catch(err => console.log(err));
};
