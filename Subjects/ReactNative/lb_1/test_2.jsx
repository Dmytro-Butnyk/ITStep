import {View, Text, StyleSheet, FlatList, Image, Dimensions} from "react-native";
import {flowersList} from "./data";

const {width} = Dimensions.get("screen");

export default function Test_2() {
    const SlideItem = ({title, pic}) => {
        return (
            <View style = {styles.slide}>
                <Image source = {pic} style = {{width: 300, height: 350}}/>
                <Text style={{textAlign: "center"}}>{title}</Text>
            </View>
        );
    };

    const renderItem = ({item}) => {
        return (
            <SlideItem title = {item.title} pic = {item.pic}/>
        );
    };

    return (
        <FlatList
            data={flowersList}
            renderItem={renderItem}
            keyExtractor={item => item.title}
            horizontal = {true}
            showsHorizontalScrollIndicator = {false}
        />
    );
};

const styles = StyleSheet.create({
    slide: {
        justifyContent: "center",
        alignItems: "center",
        backgroundColor: "#F5FCFF",
        width: width,
    },
});


