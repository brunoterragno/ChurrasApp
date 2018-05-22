import React from 'react';
import styled from 'styled-components';

const Head = styled.header`
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 5px 30px;
  background-color: #f4f4f5;
  border: 1px solid #666;

  &:hover {
    background-color: fuchsia;
  }
`;

export default props => <Head>{props.children}</Head>;
