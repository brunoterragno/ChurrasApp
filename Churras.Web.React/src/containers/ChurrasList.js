import React, { Component } from 'react';
import { connect } from 'react-redux';
import CardList from '../components/CardList';
import { getChurras } from '../redux/ChurrasReducer';

class ChurrasList extends Component {
  componentDidMount() {
    this.props.getChurras();
  }
  render() {
    return <CardList loading={this.props.loading} items={this.props.items} />;
  }
}

const mapStateToProps = state => {
  return {
    loading: state.get('churras').get('loading'),
    items: state.get('churras').get('items')
  };
};

const mapDispatchToProps = { getChurras };

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(ChurrasList);
