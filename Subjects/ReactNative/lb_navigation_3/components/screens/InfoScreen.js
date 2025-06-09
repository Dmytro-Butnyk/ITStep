import {StyleSheet, Text, View} from "react-native";
import React from "react";

const InfoScreen = () => {
    return (
        <View style={styles.screen}>
            <View>
                <Text style={styles.label}>Ім'я: Іван Петренко</Text>
                <Text style={styles.label}>Email: ivan.petrenko@email.com</Text>
                <Text style={styles.label}>Телефон: +380123456789</Text>
            </View>
        </View>
    );
};

export default InfoScreen;

const styles = StyleSheet.create({
    screen: {
        flex: 1,
        padding: 20,
        alignItems: 'center',
    },
    label: {
        fontSize: 16,
        marginBottom: 10,
    },
});
