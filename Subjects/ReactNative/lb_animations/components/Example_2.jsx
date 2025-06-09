import {useRef, useEffect} from 'react';
import {View, Text, StyleSheet, Animated} from 'react-native';

const MoveToCenter = (props) => {
    const slideToCenter = useRef(new Animated.Value(500)).current;

    useEffect(() => {
        Animated.timing(
            slideToCenter,
            {
                toValue: 0,
                duration: 5000,
                useNativeDriver: true,
            }
        ).start();
    }, [])

    return (
        <Animated.View style={
            {
                ...styles.container,
                ...styles.box,
                transform: [{translateY: slideToCenter}]
            }}>
            {props.children}
        </Animated.View>
    )
}

const Example_2 = () => {
    return (
        <View style={{...styles.container, flex: 1}}>
            <MoveToCenter>
                <Text>Example_2</Text>
            </MoveToCenter>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        justifyContent: 'center',
        alignItems: 'center',
    },
    box: {
        width: 150,
        height: 150,
        backgroundColor: '#9608b8',
        borderRadius: 10,
    }
})

export {Example_2};