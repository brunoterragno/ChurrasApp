import React from 'react';
import ReactDOM from 'react-dom';
import Enzyme, { shallow } from 'enzyme';
import Adapter from 'enzyme-adapter-react-16';

import Header from './Header';

Enzyme.configure({ adapter: new Adapter() });

describe('<Header/>', () => {
  it('renders without crashing', () => {
    shallow(<Header />);
  });

  it('set title', () => {
    shallow(<Header>Title</Header>);
  });
});
