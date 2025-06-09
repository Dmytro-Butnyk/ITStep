import {View, Text, StyleSheet, Animated} from 'react-native';
import {useState, useEffect} from 'react';

function FadeInView(props) {
    const [fadeAnim] = useState(new Animated.Value(0));

    useEffect(() => {
        Animated.timing(
            fadeAnim,
            {
                toValue: 1,
                duration: 3000,
                useNativeDriver: true,
            },
        ).start();
    }, []);

    return (
        <Animated.View style={{...styles.container, ...styles.box, opacity: fadeAnim}}>
            {props.children}
        </Animated.View>
    );
}

function Example_1() {
    return (
        <View style={{...styles.container, flex: 1}}>
            <FadeInView>
                <Text>Example_1</Text>
            </FadeInView>
        </View>
    );
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
});

export {Example_1};
