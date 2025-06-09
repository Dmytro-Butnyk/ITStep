import React from 'react';
import {NavigationContainer} from '@react-navigation/native';
import {createMaterialTopTabNavigator} from '@react-navigation/material-top-tabs';
import {SafeAreaView, Text, View, StyleSheet, StatusBar} from 'react-native';
import InfoScreen from "./components/screens/InfoScreen";
import OrdersScreen from "./components/screens/OrdersScreen";
import SettingsScreen from "./components/screens/SettingsScreen";
import MaterialIcons from 'react-native-vector-icons/MaterialIcons';


const Tab = createMaterialTopTabNavigator();

export default function App() {
    return (
        <NavigationContainer>
            <View style={{flex: 1}}>
                <SafeAreaView style={{backgroundColor: '#4b48bd'}}>
                    <StatusBar barStyle="light-content"/>
                    <View style={styles.header}>
                        <Text style={styles.headerText}>Особистий кабінет</Text>
                    </View>
                </SafeAreaView>

                <Tab.Navigator
                    screenOptions={{
                        tabBarLabelStyle: {fontSize: 14},
                        tabBarIndicatorStyle: {backgroundColor: '#000'},
                        tabBarStyle: {backgroundColor: '#7b79cc'},
                    }}
                    initialRouteName={"Info"}
                >
                    <Tab.Screen name="Info" component={InfoScreen}
                                options={
                                    {
                                        title: "Інформація",
                                        tabBarIcon: ({ color }) => (
                                            <MaterialIcons name="person" size={20} color={color} />
                                        )
                                    }
                                }/>
                    <Tab.Screen name="Orders" component={OrdersScreen}
                                options={
                                    {
                                        title: "Замовлення",
                                        tabBarIcon: ({ color }) => (
                                            <MaterialIcons name="list-alt" size={20} color={color} />
                                        )
                                    }
                                }
                    />
                    <Tab.Screen name="Settings" component={SettingsScreen}
                                options={
                                    {
                                        title: "Налаштування",
                                        tabBarIcon: ({ color }) => (
                                            <MaterialIcons name="settings" size={20} color={color} />
                                        )
                                    }
                                }
                    />
                </Tab.Navigator>
            </View>
        </NavigationContainer>
    );
}

const styles = StyleSheet.create({
    header: {
        padding: 16,
        backgroundColor: '#4b48bd',
        alignItems: 'center',
    },
    headerText: {
        fontSize: 20,
        fontWeight: 'bold',
        color: '#111',
    },
});
