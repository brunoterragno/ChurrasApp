import React from 'react';
import styled from 'styled-components';

const Button = styled.button`
  border: 1px solid brown;
  padding: 10px;
  margin: 0px 5px;

  &:hover {
    cursor: pointer;
    background: orangered;
  }
`;

export default ({ text, onClick }) => (
  <Button onClick={onClick}>{text || 'Button'}</Button>
);
