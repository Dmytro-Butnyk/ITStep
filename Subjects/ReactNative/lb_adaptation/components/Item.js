import {View, Text, StyleSheet} from "react-native";

export default function Item({item, size}) {
    const generateRandomColor = () => {
        return `#${Math.floor(Math.random() * 0xffffff).toString(16).padStart(6, '0')}`;
    };
    return (
        <View style={[
            styles.container,
            {backgroundColor: generateRandomColor()},
            {width:  size.width / 4},
            {height: size.height / 7}
        ]}>
            <Text style={styles.text}>{item}</Text>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        borderRadius: 10,
        flexGrow: 1,
        alignItems: 'center',
        justifyContent: 'center',
    },
    text: {
        fontSize: 20,
        color: '#fff',
        fontWeight: 'bold',
    }
});