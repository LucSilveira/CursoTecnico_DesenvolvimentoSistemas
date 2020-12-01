import { StatusBar } from 'expo-status-bar';
import React from 'react';
import { StyleSheet, Text, View } from 'react-native';
import { createDrawerNavigator } from '@react-navigation/drawer';
import { createStackNavigator } from '@react-navigation/stack';
import { NavigationContainer } from '@react-navigation/native';
import 'react-native-gesture-handler';

// Importanto as páginas
import Login from './pages/Login'
import Home from './pages/Home'
import AsyncStorage from '@react-native-async-storage/async-storage';

const Drawer = createDrawerNavigator();
const Stack = createStackNavigator();

const Autenticado = () => {
  return (
    <Drawer.Navigator initialRouteName="Home">
      <Drawer.Screen name="Home" component={Home}/>
      <Drawer.Screen name="Logout" component={Logout}/>
    </Drawer.Navigator>
  )
}

const Logout = ({ navigation }) =>{
  return (
    <View>
      <Text>Deseja realmente sair da aplicação</Text>
      <Button onPress={() => {
        AsyncStorage.removeItem('@nyous');
        navigation.push('Login')
      }} title="SAIR"/>
    </View>
  )
}

export default function App() {
  return (
    <NavigationContainer>
      <Stack.Navigator screenOptions={{ headerShown : false}}>
        <Stack.Screen name="Login" component={Login}/>
        <Stack.Screen name="Autenticado" component={Autenticado} />
      </Stack.Navigator>
    </NavigationContainer>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
