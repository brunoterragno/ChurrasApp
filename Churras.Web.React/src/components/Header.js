import React from 'react';
import styled from 'styled-components';
import { Link } from 'react-router-dom';

const Head = styled.header`
  border: 1px solid red;
`;

export default props => (
  <Head>
    <header>
      <h1>Churras App</h1>
      <nav>
        <Link to="/">Lista de churras</Link> |
        <Link to="/AddEditChurras">Adicionar churras</Link>
      </nav>
    </header>
  </Head>
);
