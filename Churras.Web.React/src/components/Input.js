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

  span {
    color: red;
  }
`;

export default ({
  type,
  placeholder,
  label,
  value,
  errorMessage,
  onChangeValue
}) => (
  <Input>
    <label>{label}</label>
    {type === 'longtext' ? (
      <textarea
        value={value}
        placeholder={placeholder}
        onChange={evt => onChangeValue(evt.target.value)}
      />
    ) : (
      <input
        value={value}
        type={type}
        placeholder={placeholder}
        onChange={evt => onChangeValue(evt.target.value)}
      />
    )}
    {errorMessage && <span>{errorMessage}</span>}
  </Input>
);
