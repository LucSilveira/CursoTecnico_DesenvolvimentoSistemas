import React from 'react'
import { Component } from 'react'
import Menu from '../../components/menu'
import Titulo from '../../components/titulo'

class Filmes extends Component {

    constructor(){
        super();

        this.state = {
            url :  'https://5f863a54c8a16a0016e6ae19.mockapi.io/api/movies',
            id : '',
            titulo : '',
            categoria : '',
            ano : '',
            filmes : []
        }
    }

    componentDidMount(){
        this.listar();
    }

    listar(){
        fetch(this.state.url, {
            method : 'GET'
        }).then(response => response.json())
        .then(date => this.setState({filmes : date}))
        .catch(error => console.log(error))
    }

    remover(event){
        event.preventDefault();

        fetch(this.state.url + '/' + event.target.value, {
            method : 'DELETE'
        })
        .then(response => response.json())
        .then(dados => this.listar())
    }

    editar(event){
        event.preventDefault();

        fetch(this.state.url + '/' + event.target.value, {
            method : 'GET'
        })
        .then(response => response.json())
        .then(dados => {
            this.setState({id : dados.id});
            this.setState({nome : dados.nome});
            this.setState({categoria : dados.categoria});
            this.setState({ano : dados.ano});
        })
    }

    salvar(event){
        event.preventDefault();

        const filme = {
            nome : this.state.nome,
            categoria : this.state.categoria,
            ano : this.state.ano,
        }

        let method = (this.state.id === "" ? 'POST' : 'PUT');
        let url = (this.state.id === "" ? this.state.url : this.state.url + '/' + this.state.id);

        fetch(url, {
            method : method,
            body : JSON.stringify(filme),
            headers : {
                'content-type' : 'application/json'
            }
        })
        .then(response => response.json())
        .then(dados => this.listar())
        .catch(erro => console.log(erro))

        this.setState({
            id : '',
            nome : '',
            categoria : '',
            ano : ''
        })
    }

    setNome(event){
        this.setState({nome : event.target.value})
    }
    setCategoria(event){
        this.setState({categoria : event.target.value})
    }
    setAno(event){
        this.setState({ano : event.target.value})
    }

    render() {
        return (
            <>
                <Menu />
                <Titulo titulo="Filmes" descricao="Gerencie seus filmes"/>

                <div className="container">
                    <div className="bd-example" >
                        <form id="formFilme" onSubmit={this.salvar.bind(this)}>
                            <div className="form-group">
                                <label htmlFor="nome">Nome</label>
                                <input type="text" className="form-control" value={this.state.nome} onChange={this.setNome.bind(this)} id="nome" aria-describedby="nome" placeholder="Informe o Nome"/>
                            </div>
                            <div className="form-group">
                                <label htmlFor="categoria">Categoria</label>
                                <input type="text" className="form-control" value={this.state.categoria} onChange={this.setCategoria.bind(this)} id="categoria" placeholder="Informe a Categoria"/>
                            </div>
                            <div className="form-group">
                                <label htmlFor="ano">Ano de Lançamento</label>
                                <input type="text" className="form-control small" value={this.state.ano} onChange={this.setAno.bind(this)} id="anoLancamento" placeholder="Informe o Ano de Lançamento"/>
                            </div>
                            <button type="button" className="btn btn-secondary">Cancelar</button>
                            <button type="submit" className="btn btn-success">Cadastrar</button>
                        </form>
                    </div>

                    <table className="table" style={{marginTop: '40px'}}>
                        <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">Nome</th>
                            <th scope="col">Categoria</th>
                            <th scope="col">Ano Lançamento</th>
                            <th scope="col">Ações</th>
                            <th scope="col"><button type="reset" className="btn btn-primary">Novo Filme</button></th>
                        </tr>
                        </thead>
                        <tbody id="tabela-lista-corpo">
                            {
                                this.state.filmes.map((filme, index) => {
                                    return (
                                        <tr key={index}>
                                            <td>{filme.id}</td>
                                            <td>{filme.nome}</td>
                                            <td>{filme.categoria}</td>
                                            <td>{filme.ano}</td>
                                            <td>
                                                <button type='button' value={filme.id} onClick={this.remover.bind(this)} className="btn btn-danger">Remover</button>
                                                <button type='button' value={filme.id} onClick={this.editar.bind(this)} className="btn btn-warning">Editar</button>
                                            </td>
                                        </tr>
                                    )
                                })
                            }
                        </tbody>
                    </table>
                </div>
            </>
        )
    }
}

export default Filmes