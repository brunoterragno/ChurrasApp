import React, { Component, Fragment } from 'react';
import { connect } from 'react-redux';
import CardList from '../components/CardList';
import Search from '../components/Search';
import { getChurras, deleteChurras } from '../redux/ChurrasReducer';

class ChurrasList extends Component {
  componentDidMount() {
    this.props.getChurras();
  }

  onDeleteClick = id => {
    this.props.deleteChurras(id);
  };

  render() {
    return (
      <Fragment>
        <Search
          placeholder="Escreva algo aqui"
          onChange={val => this.props.getChurras(val)}
        />
        <CardList
          loading={this.props.loading}
          items={this.props.items}
          onDeleteClick={this.onDeleteClick}
        />
        ;
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

const mapDispatchToProps = { getChurras, deleteChurras };

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(ChurrasList);
