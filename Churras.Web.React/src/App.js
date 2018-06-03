import React, { Component } from 'react';
import { withRouter } from 'react-router';
import { connect } from 'react-redux';
import Header from './components/Header';
import Container from './components/Container';

class App extends Component {
  constructor(props) {
    super(props);
    document.title = 'Churras App!';
  }
  render() {
    return (
      <Container>
        <Header>Churras App</Header>
        {this.props.children}
      </Container>
    );
  }
}

export default withRouter(connect()(App));
