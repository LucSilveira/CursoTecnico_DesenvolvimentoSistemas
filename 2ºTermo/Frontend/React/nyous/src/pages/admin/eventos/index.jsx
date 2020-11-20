import React, { useEffect }  from 'react'
import { useHistory } from 'react-router-dom'
import jwt_decode from 'jwt-decode'
import Menu from '../../../components/menu'
import Rodape from '../../../components/rodape'
import Titulo from '../../../components/titulo'
import { useState } from 'react'
import {Form, Button, Table, Card, Container} from 'react-bootstrap';
import { url} from '../../../utils/constantes'

const Eventos = () => {
    const [id, setId] = useState(0);
    const [tituloEvento, setTituloEvento] = useState('');
    const [dataEvento, setDataEvento] = useState('');
    const [capacidade, setCapacidade] = useState('');
    const [descricao, setDescricao] = useState('');
    const [idLocalizacao, setIdLocalizacao] = useState(0);
    const [idCategoria, setIdCategoria] = useState(0);
    const [eventos, setEventos] = useState([]);
    const [categorias, setCategorias] = useState([]);
    const [localizacoes, setLocalizacoes] = useState([]);

    useEffect(() => {
        listarEventos();
        listarCategorias();
        listarLocalizacoes();
    }, [])

    const listarEventos = () => {
        fetch(url + '/evento', {
            method : 'GET',
            headers : {
                'authorization' : 'Bearer ' + localStorage.getItem('token')
            }
        }).then(response => response.json())
        .then(data => {
            setEventos(data)
            setDataEvento('')
            setDescricao('')
            setTituloEvento('')
            setIdCategoria(0)
            setIdLocalizacao(0)
        })
        .catch(error => console.log(error))
    }

    const listarCategorias = () => {
        fetch(url + '/categoria', {
            method : 'GET',
            headers : {
                'authorization' : 'Bearer ' + localStorage.getItem('token')
            }
        }).then(response => response.json())
        .then(data => {
            setCategorias(data)
        })
        .catch(error => console.log(error))
    }

    const listarLocalizacoes = () => {
        fetch(url + '/localizacao', {
            method : 'GET',
            headers : {
                'authorization' : 'Bearer ' + localStorage.getItem('token')
            }
        }).then(response => response.json())
        .then(data => {
            setLocalizacoes(data)
        })
        .catch(error => console.log(error))
    }

    const salvar = (event) => {
        event.preventDefault();

        const evento = {
            // tituloEvento : tituloEvento,
            'descricao' : descricao,
            'dataEvento' : dataEvento,
            'capacidade' : capacidade,
            'idCategoria' : parseInt(idCategoria),
            'idLocalizacao' : parseInt(idLocalizacao)
        }

        let method = (id === 0 ? 'POST' : 'PUT');
        let urlRequest = (id === 0 ? url + '/categoria' : url + '/categoria' + '/' + id);

        console.log(evento)
        fetch(urlRequest, {
            method : method,
            body : JSON.stringify(evento),
            headers : {
                'authorization' : 'Bearer ' + localStorage.getItem('token'),
                'content-type' : 'application/json',
            }
        })
        .then(response => response.json())
        .then(dados => {
            listarLocalizacoes();
            listarEventos();
            listarCategorias();
        })
        .catch(erro => console.log(erro))
    }

    return (
        <div>
            <Menu />
            <Container>
                <Titulo titulo="Eventos" chamada="Gerencia as seus eventos" />
                <Card>
                    <Card.Body>
                        <Form onSubmit={e => salvar(e)}>
                            <Form.Group controlId="formBasicNome">
                                <Form.Label>Titulo</Form.Label>
                                <Form.Control type="text" value={tituloEvento} onChange={event => setTituloEvento(event.target.value)} placeholder="Nome do evento"></Form.Control>
                            </Form.Group>
                            <Form.Group controlId="formBasicCapacidade">
                                <Form.Label>Capacidade</Form.Label>
                                <Form.Control type="text" value={capacidade} onChange={event => setCapacidade(event.target.value)} placeholder="capacidade de pessoas"></Form.Control>
                            </Form.Group>
                            <Form.Group controlId="formBasicDataCadastro">
                                <Form.Label>Data do evento</Form.Label>
                                <Form.Control type="date" value={dataEvento} onChange={event => setDataEvento(event.target.value)} placeholder="Data do evento"></Form.Control>
                            </Form.Group>
                            <Form.Group controlId="formBasicCategoria">
                                <Form.Label>Categoria</Form.Label>
                                <Form.Control as="select" size="lg" custom defaultValue={idCategoria} onChange={event => setIdCategoria(event.target.value)} >
                                    <option value={0}>Selecione</option>
                                    {
                                        categorias.map((item, index) => {
                                            return(
                                                <option key={index} value={item.idCategoria}>{item.titulo}</option>
                                            )
                                        })
                                    }
                                </Form.Control>
                            </Form.Group>
                            <Form.Group controlId="formBasicLocalizacao">
                                <Form.Label>Localização</Form.Label>
                                <Form.Control as="select" size="lg" custom defaultValue={idLocalizacao} onChange={event => setIdLocalizacao(event.target.value)} >
                                    <option value={0}>Selecione uma localização</option>
                                    {
                                        localizacoes.map((item, index) => {
                                            return <option key={index} value={item.idLocalizacao}>{item.logradouro}, {item.numero}</option>
                                        })
                                    }
                                </Form.Control>
                            </Form.Group>
                            <Form.Group controlId="formBasicUrl">
                                <Form.Label>Descrição</Form.Label>
                                <Form.Control as="textarea" rows={3} value={descricao} onChange={event => setDescricao(event.target.value)}/>
                            </Form.Group>
                            <Button type="submit">Salvar</Button>
                        </Form>
                    </Card.Body>
                </Card>

                <Table striped bordered hover>
                    <thead>
                        <tr>
                            <th>Nome</th>
                            <th>Data do evento</th>
                            <th>Capacidade máxima</th>
                            <th>Descrição</th>
                            <th>Categoria</th>
                            <th>Localização</th>
                            <th>Ações</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            eventos.map((item, index) => {
                                return (
                                    <tr key={index}>
                                        <td>{item.tituloEvento}</td>
                                        <td>{item.dataEvento}</td>
                                        <td>{item.capacidade}</td>
                                        <td>{item.descricao}</td>
                                        {/* <td>{item.idCategoriaNavigation.titulo}</td> */}
                                        {/* <td>{item.idLocalizacaoNavigation.logradouro}</td> */}
                                    </tr>
                                )
                            })
                        }
                    </tbody>
                </Table>
            </Container>
            <Rodape />
        </div>
    )
}

export default Eventos