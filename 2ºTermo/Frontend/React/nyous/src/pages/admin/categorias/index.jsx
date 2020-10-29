import React, { useEffect, useState } from 'react'
import {url} from '../../../utils/constantes'
import Menu from '../../../components/menu'
import Rodape from '../../../components/rodape'
import Titulo from '../../../components/titulo'
import { Button, Card, Container, Form, Table } from 'react-bootstrap'

const Categorias = () => {
    const [id, setId] = useState(0);
    const [nome, setNome] = useState('');
    const [urlImagem, setUrlImagem] = useState('');
    const [categorias, setCategorias] = useState([]);

    useEffect(() => {
        listar()
    }, [])

    const listar = () => {
        fetch(url + '/categoria', {
            method : 'GET',
            headers : {
                'authorization' : 'Bearer ' + localStorage.getItem('token')
            }
        }).then(response => response.json())
        .then(data => {
            setCategorias(data)
            setId(0)
            setNome('')
        })
        .catch(error => console.log(error))
    }

    const editar = (event) => {
        event.preventDefault();

        fetch(url + '/categoria/' + event.target.value, {
            method : 'GET',
            headers : {
                'authorization' : 'Bearer ' + localStorage.getItem('token')
            }
        })
        .then(response => response.json())
        .then(dados => {
            console.log(dados)
            setId(dados.idCategoria);
            setNome(dados.titulo);
        })
    }

    const excluir = (event) => {
        event.preventDefault();

        fetch(url + '/categoria/' + event.target.value, {
            method : 'DELETE',
            headers : {
                'authorization' : 'Bearer ' + localStorage.getItem('token')
            }
        })
        .then(response => response.json())
        .then(dados => listar())
    }

    const uploadFile = (event) => {
        event.preventDefault();

        let formdata = new FormData();

        formdata.append('arquivo', event.target.file[0]);

        // metodo de cadastro do professor, copiar depois
        // fetch(url + '/upload', {
        //     method : 'POST',
        //     body : formdata
        // })
        // .then(response => response.json())
        // .then(data => {
        //     setUrlImagem(data.url)
        // })
        // .cath(error => console.log(error))
    }

    const salvar = (event) => {
        event.preventDefault();

        let method = (id === 0 ? 'POST' : 'PUT');
        let urlRequest = (id === 0 ? url + '/categoria' : url + '/categoria' + '/' + id);

        fetch(urlRequest, {
            method : method,
            body : JSON.stringify({
                idCategoria : id,
                titulo : nome
            }),
            headers : {
                'authorization' : 'Bearer ' + localStorage.getItem('token'),
                'content-type' : 'application/json',
            }
        })
        .then(response => response.json())
        .then(dados => listar())
        .catch(erro => console.log(erro))
    }

    return (
        <>
            <Menu/>
            <Container>
                <Titulo titulo="Categorias" chamada="Gerencie suas categorias"/>

                <Card>
                    <Card.Body>
                        <Form onSubmit={e => salvar(e)}>
                            <Form.Group controlId="formBasicNome">
                                <Form.Label>Nome</Form.Label>
                                <Form.Control type="text" value={nome} onChange={e => setNome(e.target.value)} placeholder="Palestras, meetups, ..."/>
                            </Form.Group>
                            {/* <Form.Group>
                                <Form.File id='fileCategoria' label="Imagem da categoria" on Change={e => uploadFile(e)}/>
                                { urlImagem && <img src={urlImagem} style={{ width : '120px'}}/>}
                            </Form.Group> */}
                            <Button type="submit">Salvar</Button>
                        </Form>
                    </Card.Body>
                </Card>

                <Table striped bordered hover>
                    <thead>
                        <tr>
                            <th>Nome</th>
                            <th>Ações</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            categorias.map((categoria, index) => {
                                return (
                                    <tr key={index}>
                                        <td>{categoria.titulo}</td>
                                        <td>
                                            <Button variant="warning" value={categoria.idCategoria} onClick={e => editar(e)}>Editar</Button>
                                            <Button variant="danger" value={categoria.idCategoria} onClick={e => excluir(e)}>Excluir</Button>
                                        </td>
                                    </tr>
                                )
                            })
                        }
                    </tbody>
                </Table>
            </Container>
            <Rodape/>
        </>
    )
}

export default Categorias