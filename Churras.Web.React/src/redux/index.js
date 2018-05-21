import { combineReducers } from 'redux-immutable';
import { routerReducer } from 'react-router-redux';
import churrasReducer from './ChurrasReducer';

export default combineReducers({
  churras: churrasReducer,
  router: routerReducer
});
