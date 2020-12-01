import React, { useEffect, useState } from 'react'
import { View, Text, StyleSheet, StatusBar } from 'react-native'
import * as Contacts from 'expo-contacts';
import { FlatList } from 'react-native-gesture-handler';

const Contatos = () => {
  const [contatos, setContatos] = useState([]);

  useEffect(() => {
    (async () => {
      // Pede ao usuário para verificar se o mesmo permite a aplicação acessar seus contatos
      const { status } = await Contacts.requestPermissionsAsync();
      // verifica se o usuário permitiu
      if (status === 'granted') {
        // armazena os contatos salvos do aparelho
        const { data } = await Contacts.getContactsAsync({
          fields: [Contacts.Fields.Emails],
        });
        // Verifica se há algum contatos
        if (data.length > 0) {
          // Adicionando os contatos na nossa lista
          setContatos(data)
        }
      }
    })();
  }, []);

  const Item = ({nome}) => {
    return (
      <View style={styles.item}>
        <Text style={styles.nome}>{nome}</Text>
      </View>
    )
  }

  const renderItem = ({item}) => {
    return (
      // alert(JSON.stringify(item))
      <Item nome={item.firstName}/>
    )
  }

  return (
      <View style={styles.container}>
          <Text>Tela de contatos</Text>
          <FlatList
            data={contatos}
            renderItem={renderItem}
            keyExtractor={item => item.id}
          />
      </View>
  )
}

const styles = StyleSheet.create({
    container: {
      flex: 1,
      backgroundColor: '#FCFCFC',
      marginTop : StatusBar.currentHeight || 0,
      alignItems: 'center',
      justifyContent: 'center',
    },
    item : {
      backgroundColor : '#f9c2ff',
      padding : 20,
      marginVertical : 8,
      marginHorizontal : 16
    },
    nome : {
      fontSize : 32
    }
  });

export default Contatos;