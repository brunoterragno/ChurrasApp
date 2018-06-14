import React from 'react';
import { connect } from 'react-redux';
import { postChurras } from '../redux/ChurrasReducer';
import Input from '../components/Input';
import PageButton from '../components/PageButton';

const AddEditChurras = ({ newItem, postChurras }) => (
  <div>
    <Input
      placeholder="Nome do evento"
      label="Título"
      errorMessage={newItem.title.error}
    />
    <Input
      placeholder="Dia que vai rolar"
      label="Data"
      errorMessage={newItem.date.error}
    />
    <Input
      placeholder="Descrição do evento"
      label="Descrição"
      errorMessage={newItem.description.error}
    />
    <Input
      placeholder="Dinheiro aqui"
      label="Grana com Drinks"
      errorMessage={newItem.costWithDrink.error}
    />
    <Input
      placeholder="Dinheiro aqui"
      label="Grana sem Drinks"
      errorMessage={newItem.costWithoutDrink.error}
    />
    <PageButton text="Adicionar" onClick={() => postChurras(newItem)} />
  </div>
);

const mapStateToProps = state => {
  return {
    newItem: state
      .get('churras')
      .get('newItem')
      .toJS()
  };
};

const mapDispatchToProps = { postChurras };

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(AddEditChurras);
