import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Switch, Route, BrowserRouter, Redirect} from 'react-router-dom'
import jwt_decode from 'jwt-decode'

import Home from './pages/home';
import Login from './pages/login';
import Cadastrar from './pages/cadastrar';
import Eventos from './pages/eventos';
import Dashboard from './pages/admin/dashboard';
import EventosCrud from './pages/admin/eventos';
import CategoriasCrud from './pages/admin/categorias';
import NaoEncontrada from './pages/notFound';

const RotaPrivada = ({component : Component, ...rest}) => (
  <Route
    {...rest}
    render = { props => 
        localStorage.getItem('token') !== null ?
          (<Component {...props}/>) : 
          (<Redirect to={{pathname : '/login', state : {from : props.location}}}/>) 
    }
  />
) ;

const RotaPrivadaAdmin = ({component : Component, ...rest}) => (
  <Route
    {...rest}
    render = { props => 
        localStorage.getItem('token') !== null && jwt_decode(localStorage.getItem('token')).Role === 'Administrador' ?
          (<Component {...props}/>) : 
          (<Redirect to={{pathname : '/login', state : {from : props.location}}, localStorage.removeItem('token')}/>)
    }
  />
);

// Objeto para definir nossas rotas
const routing = (
  <BrowserRouter>
    <div>
      <Switch>
        <Route exact path='/' component={Home}/>
        <Route path='/login' component={Login}/>
        <Route path='/cadastrar' component={Cadastrar}/>
        <RotaPrivada path='/eventos' component={Eventos}/>
        <RotaPrivadaAdmin path='/admin/dashboard' component={Dashboard}/>
        <RotaPrivadaAdmin path='/admin/eventos' component={EventosCrud}/>
        <RotaPrivadaAdmin path='/admin/categorias' component={CategoriasCrud}/>
        <Route component={NaoEncontrada}/>
      </Switch>
    </div>
  </BrowserRouter>
)

ReactDOM.render(
  routing,
  document.getElementById('root')
);
