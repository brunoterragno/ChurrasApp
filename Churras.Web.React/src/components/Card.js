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

export default ({ title, description, link }) => (
  <Card>
    <h3>{title || 'Sem título'}</h3>
    <p>{description || 'Sem texto'}</p>
    <a href={link}>Saiba mais</a>
  </Card>
);
