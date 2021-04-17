import React, { useEffect, useState } from 'react';
import { Container, Form, Button, Card, Table } from 'react-bootstrap';
import { db } from '../../utils/firebaseConfig'

const EventosPages = () => {
    const [eventos, setEventos] = useState([]);
    const [id, setId] = useState(0);
    const [titulo, setTitulo] = useState('');
    const [descricao, setDescricao] = useState('');

    const editar = (event) => {
        event.preventDefault();

        try{

            db.collection('eventos')
                .doc(event.target.value)
                .get()
                .then(result => {
                    setId(result.id)
                    setTitulo(result.data().titulo)
                    setDescricao(result.data().descricao)
                })
        }catch (error){
            alert(error)
        }
    }

    const remover = (event) => {
        event.preventDefault();

        try{

            db.collection('eventos')
                .doc(event.target.value)
                .delete()
                .then(() => {
                    alert('Evento deletado')
                    listar()
                })

        }catch (error){

        }
    }

    const salvar = (event) => {
        event.preventDefault();

        try{

            const evento = {
                titulo : titulo,
                descricao : descricao
            }
    
            if(id === 0){
                db.collection('eventos')
                    .add(evento)
                    .then(() => {
                        alert('Evento Cadastrado')
                        listar();
                        limparCampos()
                    })
                    .catch(error => {
                        alert(error)
                    })
            }else{
                
                db.collection('eventos')
                    .doc(id)
                    .set(evento)
                    .then(() => {
                        alert('Evento Alterado')
                        listar()
                        limparCampos()
                    })
            }

        }catch (error){
            alert(error)
        }
    }

    const limparCampos = () => {
        setId(0)
        setTitulo("")
        setDescricao("")
    }

    const listar = () => {
        try{
            db.collection('eventos')
                .get()
                .then(result => {
                    console.log('Collection eventos', result)
                    const data = result.docs.map(doc => {
                        return {
                            id : doc.id,
                            titulo : doc.data().titulo,
                            descricao : doc.data().descricao
                        }
                    });
                    setEventos(data)
                })
                .catch(error => alert(error))
        }catch (error) {
            alert(error)
        }
    }

    useEffect(() => {
        listar()
    }, [])

    return (
        <div>
            <Container>
                <h1>Eventos</h1>
                <p>Gerencie seus eventos</p>

                <Card>
                        <Card.Body>
                        <Form onSubmit={event => salvar(event)}>
                            <Form.Group controlId="formNome">
                                <Form.Label>Nome</Form.Label>
                                <Form.Control type="text" value={titulo} onChange={event => setTitulo(event.target.value)} />
                            </Form.Group>
                            
                            <Form.Group controlId="formDescricao">
                                <Form.Label>Descrição</Form.Label>
                                <Form.Control as="textarea" rows={3} value={descricao} onChange={event => setDescricao(event.target.value)} />
                            </Form.Group>

                            <Button type="submit" >Salvar</Button>
                        </Form>
                        </Card.Body>
                    </Card>
                    <Card>
                        <Card.Body>
                        <Table bordered>
                            <thead>
                                <tr>
                                    <th>Nome</th>
                                    <th>Descrição</th>
                                    <th>Ações</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    eventos.map((item, index) => {
                                    return (
                                        <tr key={index}>
                                            <td>{item.titulo}</td>
                                            <td>{item.descricao}</td>
                                            <td>
                                                <Button type="button" variant="warning" value={item.id} onClick={ event => editar(event)}>Editar</Button>
                                                <Button type="button" variant="danger" value={item.id} style={{ marginLeft : '30px'}} onClick={ event => remover(event)}>Remover</Button>
                                            </td>
                                        </tr>
                                    )
                                    })
                                }
                            </tbody>
                        </Table>
                        </Card.Body>
                    </Card>
            </Container>
        </div>
    )
}

export default EventosPages;