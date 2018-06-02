import React from 'react';
import styled from 'styled-components';

const Container = styled.div`
  border: 1px solid yellow;
`;

export default props => <Container>{props.children}</Container>;
