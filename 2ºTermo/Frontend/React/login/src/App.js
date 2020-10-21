import React from 'react';
import logo from './logo.svg';
import './App.css';
import Rodape from "./components/rodape"
import Titulo from "./components/titulo"

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <Titulo texto='Login' descricao="Informe os seus dados cadastrados para acessar nosso sistema"/>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Aprender React
        </a>
      </header>
      <Rodape/>
    </div>
  );
}

export default App;
