import React from 'react';
import { Route, Switch } from 'react-router';
import { Provider } from 'react-redux';
import createHistory from 'history/createBrowserHistory';
import { ConnectedRouter } from 'react-router-redux';

import App from './App';
import ChurrasList from './components/ChurrasList';
import AddEditChurras from './components/AddEditChurras';

export const history = createHistory();

const RouterComponent = ({ store }) => (
  <Provider store={store}>
    <ConnectedRouter history={history}>
      <App>
        <Switch>
          <Route exact path="/" component={ChurrasList} />
          <Route path="/AddEditChurras" component={AddEditChurras} />
        </Switch>
      </App>
    </ConnectedRouter>
  </Provider>
);

export default RouterComponent;
