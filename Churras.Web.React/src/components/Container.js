import React from 'react';
import styled from 'styled-components';

const Container = styled.div`
  padding: 0 10px;
  border: 1px solid yellow;
  @media (min-width: 1020px) {
    max-width: 1000px;
    margin: 0 auto;
    border: 1px solid red;
  }
`;

export default props => <Container>{props.children}</Container>;
