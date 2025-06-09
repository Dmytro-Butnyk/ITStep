import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import ProductListScreen from './screens/ProductListScreen';
import ProductDetailsScreen from './screens/ProductDetailsScreen';
import AboutScreen from './screens/AboutScreen';

const Stack = createStackNavigator();

export default function App() {
  return (
    <NavigationContainer>
      <Stack.Navigator
        initialRouteName="ProductList"
        screenOptions={{
          headerStyle: { backgroundColor: '#4a90e2' },
          headerTintColor: '#fff',
          headerTitleAlign: 'center',
        }}
      >
        <Stack.Screen name="ProductList" component={ProductListScreen} options={{ title: 'Товари' }} />
        <Stack.Screen name="ProductDetails" component={ProductDetailsScreen} options={{ title: 'Деталі товару' }} />
        <Stack.Screen name="About" component={AboutScreen} options={{ title: 'Про застосунок' }} />
      </Stack.Navigator>
    </NavigationContainer>
  );
}
