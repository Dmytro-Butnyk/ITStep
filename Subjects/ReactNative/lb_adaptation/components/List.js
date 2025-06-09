import {View, Text, StyleSheet, FlatList} from "react-native";
import {useComponentSize} from "../hooks/useComponentSize";
import Item from "./Item";
import {demo} from "../data/demo";


export default function List() {
    const [size, onLayout] = useComponentSize();


    console.log('size', size);
    return (
        // <View
        //     style={styles.container}
        //     onLayout={onLayout}
        // >
        //     {demo.map((item) => (
        //         <Item
        //             key={item.id}
        //             item={item.name}
        //             size={size}
        //         />
        //     ))}
        //
        // </View>

        /* <FlatList
             style={styles.container}
             data={demo}
             renderItem={({item}) => <Item item={item.name} size={size}/>}
             keyExtractor={(item) => item.id.toString()}
         />*/

        <FlatList
            style={styles.container}
            data={demo}
            renderItem={({item}) => <Item item={item.name} size={size}/>}
            keyExtractor={(item) => item.id.toString()}
            onLayout={onLayout}
            numColumns={3}
            columnWrapperStyle ={{justifyContent: 'space-between', gap:10, marginBottom: 10}}
        />
    )
}

const styles = StyleSheet.create({
    container: {
        width: '90%',
        flex: 1,
        backgroundColor: '#fff',
    },
    text: {
        fontSize: 20,
        color: '#000',
        fontWeight: 'bold',
        backgroundColor: '#f00',
    }
});


