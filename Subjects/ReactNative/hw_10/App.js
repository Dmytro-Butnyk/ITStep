import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createDrawerNavigator } from '@react-navigation/drawer';
import { Ionicons } from '@expo/vector-icons';

import TodayScreen from './screens/TodayScreen';
import HistoryScreen from './screens/HistoryScreen';
import TipsScreen from './screens/TipsScreen';
import AboutScreen from './screens/AboutScreen';

const Drawer = createDrawerNavigator();

export default function App() {
  return (
    <NavigationContainer>
      <Drawer.Navigator
        initialRouteName="Today"
        screenOptions={{
          headerShown: true,
        }}
      >
        <Drawer.Screen
          name="Today"
          component={TodayScreen}
          options={{
            drawerLabel: 'Сьогодні',
            drawerIcon: ({ color, size }) => (
              <Ionicons name="today" size={size} color={color} />
            ),
          }}
        />
        <Drawer.Screen
          name="History"
          component={HistoryScreen}
          options={{
            drawerLabel: 'Історія',
            drawerIcon: ({ color, size }) => (
              <Ionicons name="time" size={size} color={color} />
            ),
          }}
        />
        <Drawer.Screen
          name="Tips"
          component={TipsScreen}
          options={{
            drawerLabel: 'Поради',
            drawerIcon: ({ color, size }) => (
              <Ionicons name="bulb" size={size} color={color} />
            ),
          }}
        />
        <Drawer.Screen
          name="About"
          component={AboutScreen}
          options={{
            drawerLabel: 'Про застосунок',
            drawerIcon: ({ color, size }) => (
              <Ionicons name="information-circle" size={size} color={color} />
            ),
          }}
        />
      </Drawer.Navigator>
    </NavigationContainer>
  );
}
