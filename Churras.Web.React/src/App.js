import React, { Component } from 'react';
import { withRouter } from 'react-router';
import { connect } from 'react-redux';

class App extends Component {
  constructor(props) {
    super(props);
    document.title = 'Churras App!';
  }
  render() {
    return <div>{this.props.children}</div>;
  }
}

export default withRouter(connect()(App));
