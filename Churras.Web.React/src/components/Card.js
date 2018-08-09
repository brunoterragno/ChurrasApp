import React from 'react';
import styled from 'styled-components';

const Card = styled.div`
  border: 1px solid fuchsia;
  width: 300px;
  padding: 10px;
  margin: 10px 5px 0px;

  &:hover {
    background: grey;
    cursor: pointer;
  }
`;

const Buttons = styled.div`
  display: flex;
  justify-content: space-between;
`;

export default ({ title, description, link, onDeleteClick }) => (
  <Card>
    <h3>{title || 'Sem título'}</h3>
    <p>{description || 'Sem texto'}</p>
    <Buttons>
      <a href={link}>Saiba mais</a>
      <button onClick={onDeleteClick}>Excluir</button>
    </Buttons>
  </Card>
);
