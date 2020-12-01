import React from 'react';
import 'react-native-gesture-handler';
import { NavigationContainer } from '@react-navigation/native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

const Tab = createBottomTabNavigator();

import Contatos from './pages/contatos'
import TextSpeech from './pages/textSpeech'
import Location from './pages/location'

export default function App() {
  return (
    <NavigationContainer>
      <Tab.Navigator>
        <Tab.Screen name="Contatos" component={Contatos}/>
        <Tab.Screen name="TextSpeech" component={TextSpeech}/>
        <Tab.Screen name="Location" component={Location}/>
      </Tab.Navigator>
    </NavigationContainer>
  );
}
