import React from 'react';
import ReactDOM from 'react-dom';
import reportWebVitals from './reportWebVitals';
import firebaseConfig from './utils/firebaseConfig'
import { FirebaseAppProvider } from 'reactfire'
import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css';

import Login from './pages/login'
import Cadastrar from './pages/register'
import EventosPage from './pages/eventos' 

ReactDOM.render(
  <React.StrictMode>
    {/* Instancia do provedor do firebase para rodar a aplicação com o banco integrado */}
    <FirebaseAppProvider firebaseConfig={firebaseConfig}>
      <EventosPage />
    </FirebaseAppProvider>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
