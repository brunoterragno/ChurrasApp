import React from 'react';

import { storiesOf } from '@storybook/react';
import { action } from '@storybook/addon-actions';
import { linkTo } from '@storybook/addon-links';
import { MemoryRouter } from 'react-router';

import Header from '../components/Header';
import PageButton from '../components/PageButton';
import Card from '../components/Card';
import CardList from '../components/CardList';
import Input from '../components/Input';

storiesOf('Header', module)
  .addDecorator(story => (
    <MemoryRouter initialEntries={['/']}>{story()}</MemoryRouter>
  ))
  .add('without text', () => <Header />);

storiesOf('PageButton', module)
  .add('without text', () => <PageButton />)
  .add('with text', () => <PageButton text="Anterior" />);

storiesOf('Card', module)
  .add('without content', () => <Card />)
  .add('with content', () => (
    <Card
      title="Churras de aniversário!"
      description="Do velit sint eiusmod ut sint pariatur dolore deserunt."
      link="#"
    />
  ));

const items = [
  {
    title: 'item 1',
    description:
      'Reprehenderit dolor do nostrud proident ad duis commodo est consequat et id.',
    link: '#'
  },
  {
    title: 'item 1',
    description:
      'Reprehenderit dolor do nostrud proident ad duis commodo est consequat et id.',
    link: '#'
  },
  {
    title: 'item 1',
    description:
      'Reprehenderit dolor do nostrud proident ad duis commodo est consequat et id.',
    link: '#'
  },
  {
    title: 'item 1',
    description:
      'Reprehenderit dolor do nostrud proident ad duis commodo est consequat et id.',
    link: '#'
  },
  {
    title: 'item 1',
    description:
      'Reprehenderit dolor do nostrud proident ad duis commodo est consequat et id.',
    link: '#'
  },
  {
    title: 'item 1',
    description:
      'Reprehenderit dolor do nostrud proident ad duis commodo est consequat et id.',
    link: '#'
  }
];

storiesOf('CardList', module)
  .add('without items', () => <CardList />)
  .add('with items', () => <CardList items={items.concat(items)} />);

storiesOf('Input', module)
  .add('without values', () => <Input />)
  .add('with label and placeholder', () => (
    <Input placeholder="Insira seu nome" label="Nome" />
  ));
