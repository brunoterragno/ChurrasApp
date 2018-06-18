import React from 'react';
import { connect } from 'react-redux';
import { postChurras, handleChangeValue } from '../redux/ChurrasReducer';
import Input from '../components/Input';
import PageButton from '../components/PageButton';

const AddEditChurras = ({ newItem, postChurras, handleChangeValue }) => (
  <div>
    <Input
      placeholder="Nome do evento"
      label="Título"
      value={newItem.title.value}
      onChangeValue={value => handleChangeValue('title', value)}
      errorMessage={newItem.title.error}
    />
    <Input
      placeholder="Dia que vai rolar"
      label="Data"
      value={newItem.date.value}
      onChangeValue={value => handleChangeValue('date', value)}
      errorMessage={newItem.date.error}
    />
    <Input
      placeholder="Descrição do evento"
      label="Descrição"
      value={newItem.description.value}
      onChangeValue={value => handleChangeValue('description', value)}
      errorMessage={newItem.description.error}
    />
    <Input
      placeholder="Dinheiro aqui"
      label="Grana com Drinks"
      value={newItem.costWithDrink.value}
      onChangeValue={value => handleChangeValue('costWithDrink', value)}
      errorMessage={newItem.costWithDrink.error}
    />
    <Input
      placeholder="Dinheiro aqui"
      label="Grana sem Drinks"
      value={newItem.costWithoutDrink.value}
      onChangeValue={value => handleChangeValue('costWithoutDrink', value)}
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

const mapDispatchToProps = { postChurras, handleChangeValue };

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(AddEditChurras);
