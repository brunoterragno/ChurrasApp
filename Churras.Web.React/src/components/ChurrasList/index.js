import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';

class ChurrasList extends Component {
  componentDidMount() {}
  render() {
    return <div>Lista de churrascos</div>;
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
