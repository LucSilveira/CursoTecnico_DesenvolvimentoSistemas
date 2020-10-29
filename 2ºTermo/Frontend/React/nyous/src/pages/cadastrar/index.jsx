import React from 'react'
import Menu from '../../components/menu'
import Rodape from '../../components/rodape'
import {  Button, Container, Form } from 'react-bootstrap'
import logo from '../../assets/img/Logo.svg'
import './index.css'

const Cadastrar = () => {

    return (
        <>
            <Menu />
            <Container className='form-height'>
                <Form className='form-signin'>
                    <div className='text-center'>
                     <img src={logo} alt='NYOUS' style={{ width : '64px'}} />
                    </div>
                    <br/>
                    <small>Informe os dados Abaixo</small>
                    <hr/>
                    <Form.Group controlId="formBasicEmail">
                        <Form.Label>Nome </Form.Label>
                        <Form.Control type="text" placeholder="Informe o nome completo" required />
                    </Form.Group>

                    <Form.Group controlId="formBasicEmail">
                        <Form.Label>Email </Form.Label>
                        <Form.Control type="email" placeholder="Informe o email" required />
                    </Form.Group>

                    <Form.Group controlId="formBasicPassword">
                        <Form.Label>Senha</Form.Label>
                        <Form.Control type="password" placeholder="Senha"required/>
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

export default Cadastrar