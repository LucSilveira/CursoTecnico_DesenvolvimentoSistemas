import React from 'react'
import { Component } from 'react';
import './index.css'

class Titulo extends Component {
    constructor(){
        super()
    }

    render(){
        return(
            <>
                <h1>{this.props.texto}</h1>
                <p className="descricao">{this.props.descricao || "descrição padrão do sistema"}</p>
            </>
        )
    }
}

export default Titulo;