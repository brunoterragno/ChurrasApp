import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import Header from '../components/Header';
import Container from '../components/Container';

class ChurrasList extends Component {
  render() {
    return (
      <Container>
        <Header>Churras App</Header>
      </Container>
    );
  }
}

const mapStateToProps = state => {
  return {
    loading: state.get('churras').get('loading'),
    items: state.get('churras').get('items')
  };
};

const mapDispatchToProps = {};

export default connect(mapStateToProps, mapDispatchToProps)(ChurrasList);
