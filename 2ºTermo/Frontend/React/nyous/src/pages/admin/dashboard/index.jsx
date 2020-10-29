import React, { useEffect } from 'react'
import jwt_decode from 'jwt-decode'
import Menu from '../../../components/menu'
import Rodape from '../../../components/rodape'

const Dashboard = () =>{

    return (
        <>
            <Menu />
            <h1>DashBoard</h1>
            <Rodape />
        </>
    )
}

export default Dashboard