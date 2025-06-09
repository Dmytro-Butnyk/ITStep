import React from 'react';
import 'react-native-gesture-handler';
import {NavigationContainer} from '@react-navigation/native';
import {createStackNavigator} from '@react-navigation/stack';
import {StatusBar} from "expo-status-bar";
import HomeScreen from "./components/screens/HomeScreen";
import SecondScreen from "./components/screens/SecondScreen";
import ThirdScreen from "./components/screens/ThirdScreen";

const Stack = createStackNavigator();
export default function App() {

    const stackNavigatorScreenOptions = {
        headerStyle: {backgroundColor: '#c88265'},
        headerTintColor: '#000',
        headerTitleStyle: {
            fontWeight: 'bold',
            fontSize: 25,
            fontFamily: 'arial',
        },
        headerTitleAlign: 'center',
    }

    return (
        <>
            <StatusBar/>
            <NavigationContainer>
                <Stack.Navigator
                    initialRouteName={"Home Screen"}
                    screenOptions={stackNavigatorScreenOptions}
                >
                    <Stack.Screen
                        options={{
                            headerTitle: 'Головна сторінка',
                            headerLeft: () => null
                        }}
                        name={"Home Screen"}
                        component={HomeScreen}/>
                    <Stack.Screen
                        options={{
                            headerTitle: 'Друга сторінка',
                            headerLeft: () => null
                        }}
                        name={"Second Screen"}
                        component={SecondScreen}/>
                    <Stack.Screen
                        options={{
                            headerTitle: 'Третя сторінка',
                            headerLeft: () => null
                        }}
                        name={"Third Screen"}
                        component={ThirdScreen}/>
                </Stack.Navigator>
            </NavigationContainer>
        </>
    );
}