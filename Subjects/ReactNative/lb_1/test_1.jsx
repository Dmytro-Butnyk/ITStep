import {FlatList, StyleSheet, Text, Dimensions} from "react-native";
import {studentsList} from "./data.js";
import {useState} from "react";

const { width } = Dimensions.get("screen");

export default function Test_1() {
    const [selectElement, setSelectElement] = useState("");

    const ListItem = ({text}) => {
        const bgColor = text === selectElement ? "#f00" : "white";
        const textColor = text === selectElement ? "white" : "black";

        return (
            <Text
                style={{...styles.text, backgroundColor: bgColor, color: textColor}}
                onPress={() => {setSelectElement(text); console.log(text)}}
            >{text}</Text>
        );
    };

    return (
        <FlatList
            style={{marginVertical: 100}}
            data={studentsList}
            renderItem={({item}) => <ListItem text={item} />}
            keyExtractor={item => item.toString()}
            ListHeaderComponent={() => <Text style={styles.header}>Students</Text>}
            extraData={selectElement}
        />
    );
};

const styles = StyleSheet.create({
    text: {
        color: '#f00',
        fontSize: 20,
        fontWeight: 'bold',
        padding: 10,
        marginVertical: 5,
        marginHorizontal: 16,
        borderWidth: 2,
        borderColor: '#f00',
        borderRadius: 10,
        width: width * 0.8,
    },
    header: {
        fontWeight: 'bold',
        fontSize: 25,
        textAlign: 'center'
    }
});