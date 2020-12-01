import React, { useState } from 'react'
import { StyleSheet, View, Text, TextInput, TouchableOpacity } from 'react-native'
import AsyncStorage from '@react-native-async-storage/async-storage';


const Login = ({ navigation }) => {
    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');

    const salvarToken = async (value) => {
        return AsyncStorage.setItem('@nyous', value)
    }

    const Logar = () => {
        fetch('http://192.168.56.1:5000/api/account/login', {
            method : 'POST',
            body : JSON.stringify({
                'email' : email,
                'senha' : senha
            }),
            headers : {
                'content-type' : 'application/json'
            }
        })
        .then(response => response.json())
        .then(data => {

            if(data.status !== 404){
                alert('seja bem vindo !');
                navigation.push('Autenticado')
                salvarToken(data.token)
            }else{
                alert('Email ou senha invalidos!')
            }            
        })
    }

    return (
        <View style={styles.container}>
            <Text>Tela de Login</Text>

            <View style={styles.form}>
                <Text >Email</Text>
                <TextInput 
                    style={styles.input}
                    onChangeText={text => setEmail(text)}
                    value={email} placeholder="Digite um email..."/>

                <Text>Senha</Text>
                <TextInput 
                    style={styles.input}
                    onChangeText={text => setSenha(text)}
                    secureTextEntry={true}
                    value={senha} placeholder="Digite um senha..."/>
            </View>

            <TouchableOpacity
                style={styles.button}
                onPress={Logar}>

                <Text style={styles.textButton}>ENTRAR</Text>
            </TouchableOpacity>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#fff',
        alignItems: 'center',
        justifyContent: 'center',
    },
    input : {
        width : '80%',
        height : 40,
        padding : 5,
        marginTop : 15,
        borderWidth : 1,
        borderColor : 'gray',
        borderRadius : 10
    },
    form : {
        justifyContent : "flex-start",
        marginTop : 15,
        fontSize : 20,
        width : '100%',
        padding : 20
    },
    button : {
        backgroundColor : 'black',
        width : '70%',
        height : 40,
        padding : 5,
        borderRadius : 10,
        marginTop : 20,
        alignItems: 'center',
        justifyContent: 'center',
    },
    textButton : {
        color : 'white'
    }
});

export default Login
