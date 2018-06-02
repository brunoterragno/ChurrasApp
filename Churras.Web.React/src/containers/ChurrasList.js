import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import Header from '../components/Header';
import Container from '../components/Container';
import CardList from '../components/CardList';
import { getChurras } from '../redux/ChurrasReducer';

class ChurrasList extends Component {
  componentDidMount() {
    this.props.getChurras();
  }
  render() {
    return (
      <Container>
        <Header>Churras App</Header>
        <CardList items={this.props.items} />
      </Container>
    );
  }
}

const mapStateToProps = state => {
  return {
    items: state.get('churras').get('items')
  };
};

const mapDispatchToProps = { getChurras };

export default connect(mapStateToProps, mapDispatchToProps)(ChurrasList);
