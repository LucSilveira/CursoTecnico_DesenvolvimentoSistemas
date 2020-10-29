import React from 'react'
import { Component } from 'react';

class Titulo extends Component {
    render () {
        return(
            <div className="jumbotron jumbotron-fluid">
                <div className="container">
                <h1 className="display-4">{this.props.titulo}</h1>
                <p className="lead">{this.props.descricao}</p>
                </div>
            </div>
        )
    }
}

export default Titulo