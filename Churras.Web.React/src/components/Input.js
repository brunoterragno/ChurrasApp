import React from 'react';
import styled from 'styled-components';

const Input = styled.fieldset`
  border: 1px solid orangered;
  display: flex;

  input {
    border: 1px solid pink;
    padding: 5px;
    min-width: 200px;
  }
`;

export default ({ type, placeholder, label }) => (
  <Input>
    <label>{label}</label>
    {type === 'longtext' ? (
      <textarea placeholder={placeholder} />
    ) : (
      <input type={type} placeholder={placeholder} />
    )}
  </Input>
);
