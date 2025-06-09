import React from 'react';
import {View, Text, StyleSheet, Button} from "react-native";
import NavigationBar from "../NavigationBar";


export default function ThirdScreen({navigation}) {
    return (
        <View style={styles.container}>
            <Text style={styles.text}>Third screen</Text>
            <NavigationBar navigation={navigation}/>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
        backgroundColor: '#fff',
    },
    text: {
        fontSize: 30,
        marginBottom: 20,
        fontWeight: 'bold',
    },
});