import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import Ionicons from 'react-native-vector-icons/Ionicons';

import HomeScreen from './screens/HomeScreen';
import CatalogScreen from './screens/CatalogScreen';
import ProfileScreen from './screens/ProfileScreen';

const Tab = createBottomTabNavigator();

export default function App() {
  return (
    <NavigationContainer>
      <Tab.Navigator
        screenOptions={({ route }) => ({
          headerTitleAlign: 'center',
          tabBarIcon: ({ focused, color, size }) => {
            let iconName;
            if (route.name === 'Головна') iconName = focused ? 'home' : 'home-outline';
            else if (route.name === 'Каталог') iconName = focused ? 'list' : 'list-outline';
            else if (route.name === 'Профіль') iconName = focused ? 'person' : 'person-outline';
            return <Ionicons name={iconName} size={size} color={color} />;
          },
          tabBarActiveTintColor: '#8e24aa',
          tabBarInactiveTintColor: 'gray',
          tabBarStyle: { height: 60, paddingBottom: 5, backgroundColor: '#fafafa' },
        })}
      >
        <Tab.Screen name="Головна" component={HomeScreen} />
        <Tab.Screen name="Каталог" component={CatalogScreen} />
        <Tab.Screen
          name="Профіль"
          component={ProfileScreen}
          options={{ tabBarBadge: 3 }}
        />
      </Tab.Navigator>
    </NavigationContainer>
  );
}
