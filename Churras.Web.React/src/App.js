import React, { Component } from 'react';
import { withRouter } from 'react-router';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <h1 className="App-title">Churras App</h1>
          <nav>
            <Link to="/">Lista de churras</Link> |
            <Link to="/AddEditChurras">Adicionar churras</Link>
          </nav>
        </header>
        {this.props.children}
      </div>
    );
  }
}

export default withRouter(connect()(App));
