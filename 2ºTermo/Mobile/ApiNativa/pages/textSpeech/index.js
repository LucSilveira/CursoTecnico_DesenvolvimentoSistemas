import React, { useState } from 'react'
import { View, Text, Button, StyleSheet, TextInput } from 'react-native'
import * as Speeach from 'expo-speech'

const TextSpeech = () => {
    const [texto, setTexto] = useState('')

    const speak = () => {
        Speeach.speak(texto);
    }

    return (
        <View style={styles.container}>
            <Text>Tela de voz</Text>
            <TextInput value={texto} onChangeText={txt => setTexto(txt)} style={styles.input}/>
            <Button title="Clique pra hablar" onPress={() => speak()}/>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
      flex: 1,
      backgroundColor: '#FCFCFC',
      alignItems: 'center',
      justifyContent: 'center',
    },
    input : {
        width : '60%',
        height : 35,
        borderColor : 'black',
        borderWidth : 1,
        padding : 5,
        borderRadius : 6
    }
})

export default TextSpeech