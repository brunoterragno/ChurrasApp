import React, { Component, Fragment } from 'react';
import { connect } from 'react-redux';
import CardList from '../components/CardList';
import Search from '../components/Search';
import { getChurras } from '../redux/ChurrasReducer';

class ChurrasList extends Component {
  componentDidMount() {
    this.props.getChurras();
  }
  render() {
    return (
      <Fragment>
        <Search
          placeholder="Escreva algo aqui"
          onChange={val => this.props.getChurras(val)}
        />
        <CardList loading={this.props.loading} items={this.props.items} />;
      </Fragment>
    );
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
