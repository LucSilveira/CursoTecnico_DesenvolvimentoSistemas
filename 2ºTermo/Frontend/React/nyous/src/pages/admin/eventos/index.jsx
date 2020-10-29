import React, { useEffect }  from 'react'
import { useHistory } from 'react-router-dom'
import jwt_decode from 'jwt-decode'
import Menu from '../../../components/menu'
import Rodape from '../../../components/rodape'

const Eventos = () => {
    const history = useHistory()

    useEffect(() => {
        const token = localStorage.getItem('token');

        if(jwt_decode(token).Role !== 'Administrador' && token !== null){
            history.push('/login')
        }
    },[])

    return (
        <>
            <Menu/>
            <h1>Eventos</h1>
            <Rodape/>
        </>
    )
}

export default Eventos