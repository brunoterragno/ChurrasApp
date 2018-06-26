import React, { Fragment } from 'react';
import styled from 'styled-components';
import Card from './Card';
import PageButton from './PageButton';

const CardList = styled.div`
  border: 1px solid blue;
  display: flex;
  flex-wrap: wrap;
  padding: 0px 10px 10px;
  min-height: 300px;
  justify-content: center;

  h1 {
    align-self: center;
    border: 1px solid green;
  }
`;

const ContainerButtons = styled.div`
  border: 1px solid yellowgreen;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 10px;
`;
const displayItems = ({ loading, items }) => {
  if (loading) return <h1>Carregando...</h1>;
  else if (items && items.length > 0)
    return items.map(item => <Card key={item.id} {...item} />);
  else return <h1>Sem items :(</h1>;
};

export default ({ loading, items }) => (
  <Fragment>
    <CardList>{displayItems({ loading, items })}</CardList>
    <ContainerButtons>
      <PageButton text="Anterior" />
      <PageButton text="Próximo" />
    </ContainerButtons>
  </Fragment>
);
