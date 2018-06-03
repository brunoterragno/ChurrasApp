import React from 'react';
import { connect } from 'react-redux';
import { postChurras } from '../redux/ChurrasReducer';
import Input from '../components/Input';
import PageButton from '../components/PageButton';

const AddEditChurras = () => (
  <div>
    <Input placeholder="Nome do evento" label="Título" />
    <Input placeholder="Descrição do evento" label="Descrição" />
    <PageButton text="Adicionar" />
  </div>
);

const mapStateToProps = state => {
  return {};
};

const mapDispatchToProps = { postChurras };

export default connect(mapStateToProps, mapDispatchToProps)(AddEditChurras);
