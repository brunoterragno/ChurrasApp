import React from 'react';
import { connect } from 'react-redux';
import { postChurras } from '../redux/ChurrasReducer';
import Input from '../components/Input';
import PageButton from '../components/PageButton';

const AddEditChurras = () => (
  <div>
    <Input placeholder="Nome do evento" label="Título" />
    <Input placeholder="Dia que vai rolar" label="Data" />
    <Input placeholder="Descrição do evento" label="Descrição" />
    <Input placeholder="Dinheiro aqui" label="Grana com Drinks" />
    <Input placeholder="Dinheiro aqui" label="Grana sem Drinks" />
    <PageButton text="Adicionar" />
  </div>
);

const mapStateToProps = state => {
  return {};
};

const mapDispatchToProps = { postChurras };

export default connect(mapStateToProps, mapDispatchToProps)(AddEditChurras);
