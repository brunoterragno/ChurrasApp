import React from 'react';
import styled from 'styled-components';

const Search = styled.div`
  border: 1px solid greenyellow;
  padding: 5px;
`;

export default ({ placeholder, text, onChange }) => (
  <Search>
    <input
      type="text"
      value={text}
      placeholder={placeholder}
      onChange={evt => onChange(evt.target.value)}
    />
  </Search>
);
