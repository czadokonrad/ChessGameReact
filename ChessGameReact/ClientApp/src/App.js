import React, { Component } from 'react';
import ChessTutorial from './components/ChessTutorial';


export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <ChessTutorial />
    );
  }
}
