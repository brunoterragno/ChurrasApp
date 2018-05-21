import React from 'react';
import ReactDOM from 'react-dom';
import { createStore, applyMiddleware } from 'redux';
import ReduxThunk from 'redux-thunk';
import { routerMiddleware } from 'react-router-redux';
import { composeWithDevTools } from 'redux-devtools-extension';
import reducers from './redux';
import Router, { history } from './router';
import registerServiceWorker from './registerServiceWorker';

const middlewares = applyMiddleware(ReduxThunk, routerMiddleware(history));

const store = createStore(reducers, composeWithDevTools(middlewares));

ReactDOM.render(<Router store={store} />, document.getElementById('root'));

registerServiceWorker();
