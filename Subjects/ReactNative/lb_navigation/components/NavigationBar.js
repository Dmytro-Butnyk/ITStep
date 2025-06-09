import { Pressable, Text, View, StyleSheet } from "react-native";
import React from "react";

const NavigationBar = ({ navigation }) => {
    return (
        <View style={styles.container}>
            <Pressable style={styles.circle} onPress={() => navigation.navigate('Home Screen')}>
                <Text style={styles.text}>1</Text>
            </Pressable>
            <Pressable style={styles.circle} onPress={() => navigation.navigate('Second Screen')}>
                <Text style={styles.text}>2</Text>
            </Pressable>
            <Pressable style={styles.circle} onPress={() => navigation.navigate('Third Screen')}>
                <Text style={styles.text}>3</Text>
            </Pressable>
        </View>
    );
};

const styles = StyleSheet.create({
    container: {
        flexDirection: 'row',
        justifyContent: 'center',
        gap: 12,
        marginVertical: 20,
    },
    circle: {
        width: 40,
        height: 40,
        borderRadius: 20,
        backgroundColor: '#9608b8',
        justifyContent: 'center',
        alignItems: 'center',
    },
    text: {
        color: '#fff',
        fontWeight: 'bold',
        fontSize: 20,
    },
});

export default NavigationBar;
