import React, { useState, useEffect } from 'react'
import { useFirebaseApp } from 'reactfire'
import { Container, Form, Button } from 'react-bootstrap'
import logo from '../../assets/img/Logo.svg';
import './style.css'

const Cadastrar = () => {
    const firebase = useFirebaseApp();

    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');

    const cadastrar = (event) => {
        event.preventDefault();
        
        firebase.auth().createUserWithEmailAndPassword(email, senha)
        .then(result => {
            localStorage.setItem('nyous', result.user.refreshToken)
            alert("Usuario cadastrado")
            alert(localStorage.getItem('nyous'))
        }).catch(error => {
            alert(error)
        })
    }

    return (
        <div>
            <Container className='form-height'>
                <Form className='form-signin' onSubmit={event => cadastrar(event)} >
                    <div className='text-center'>
                     <img src={logo} alt='NYOUS' style={{ width : '64px'}} />
                    </div>
                    <br/>
                    <small>Informe os dados Abaixo</small>
                    <hr/>
                    <Form.Group controlId="formBasicEmail">
                        <Form.Label>Email </Form.Label>
                        <Form.Control type="email" placeholder="Informe o email" value={email} onChange={event => setEmail(event.target.value)}  required />
                    </Form.Group>

                    <Form.Group controlId="formBasicPassword">
                        <Form.Label>Senha</Form.Label>
                        <Form.Control type="password" placeholder="Senha" value={senha} onChange={event => setSenha(event.target.value)} required/>
                    </Form.Group>
                    <Button variant="primary" type="submit" >
                        Cadastrar
                    </Button>
                    <br/><br/>
                    <a href='/cadastrar' style={{ marginTop :'30px'}}>Não tenho conta!</a>
                </Form>
            </Container>
        </div>
    )
}

export default Cadastrar;