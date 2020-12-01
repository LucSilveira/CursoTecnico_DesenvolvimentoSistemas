import React, { useEffect, useState } from 'react'
import { StyleSheet, View, Text } from 'react-native'
import AsyncStorage from '@react-native-async-storage/async-storage';
import { createDrawerNavigator } from '@react-navigation/drawer';
import { NavigationContainer } from '@react-navigation/native';


const Home = () => {
    const [token, setToken] = useState('');

    const getToken = async () => {
        setToken( await AsyncStorage.getItem('@nyous'))
    }

    useEffect(() => {
        getToken()
    }, [])

    return (
        <View style={styles.container}>
            <Text>Tela Home</Text>
            <Text>{token}</Text>
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
})

export default Home