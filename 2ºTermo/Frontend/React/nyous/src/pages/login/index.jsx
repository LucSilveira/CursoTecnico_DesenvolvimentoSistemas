import React, { useState } from 'react'
import Menu from '../../components/menu'
import Rodape from '../../components/rodape'
import {  Button, Container, Form } from 'react-bootstrap'
import logo from '../../assets/img/Logo.svg'
import './index.css'
import { useHistory } from 'react-router-dom'
import jwt_decode from 'jwt-decode'
import {url} from '../../utils/constantes'

const Login = () => {
    let history = useHistory();
    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');

    const Logar = (event) => {
        event.preventDefault();

        fetch(url + '/login', {
            method : 'POST',
            body : JSON.stringify({
                email : email,
                senha : senha
            }),
            headers : {
                'content-type' : 'application/json'
            }
        })
        .then(response => {
            if(response.ok){
                return response.json()
            }

            alert('Email e/ou senha incorretos, verifique os dados informados')
        })
        .then(data => {
            localStorage.setItem('token', data.token);
            let usuario = jwt_decode(data.token);
            
            if(usuario.Role === 'Administrador'){
                history.push('/admin/dashboard')
            }else{
                history.push('/eventos')
            }
        })
        .catch(error => console.log(error))
    }

    return (
        <>
            <Menu />
            <Container className='form-height'>
                <Form className='form-signin' onSubmit={event => Logar(event)}>
                    <div className='text-center'>
                     <img src={logo} alt='NYOUS' style={{ width : '64px'}} />
                    </div>
                    <br/>
                    <small>Informe os dados Abaixo</small>
                    <hr/>
                    <Form.Group controlId="formBasicEmail">
                        <Form.Label>Email </Form.Label>
                        <Form.Control type="email" placeholder="Informe o email" value={email} onChange={e => setEmail(e.target.value)} required />
                    </Form.Group>

                    <Form.Group controlId="formBasicPassword">
                        <Form.Label>Senha</Form.Label>
                        <Form.Control type="password" placeholder="Senha" value={senha} onChange={e => setSenha(e.target.value)} required/>
                    </Form.Group>
                    <Button variant="primary" type="submit" >
                        Enviar
                    </Button>
                    <br/><br/>
                    <a href='/cadastrar' style={{ marginTop :'30px'}}>Não tenho conta!</a>
                </Form>
            </Container>
            <Rodape />
        </>
    )
}

export default Login