import {useRef, useEffect, useState} from 'react';
import {View, Button, Image, StyleSheet, Animated, Easing} from 'react-native';

const Example_4 = () => {
    const rotateAnim = useRef(new Animated.Value(0)).current;
    const [isRotating, setIsRotating] = useState(false);
    const rotation = useRef(null);
    const rotate = rotateAnim.interpolate({
        inputRange: [0, 1],
        outputRange: ['0deg', '360deg']
    });

    const startRotation = () => {
        if (isRotating) return;
        setIsRotating(true);

        rotation.current = Animated.loop(
            Animated.timing(
                rotateAnim,
                {
                    toValue: 1,
                    duration: 1500,
                    useNativeDriver: true,
                    easing: Easing.linear,
                }
            )
        );

        rotateAnim.setValue(0);
        rotation.current.start();
    }

    const stopRotation = () => {
        if (!isRotating) return;
        setIsRotating(false);

        // rotateAnim.setValue(0);
        rotation.current.stop();
    }

    return (
        <View style={styles.container}>
            <Animated.View style={{transform: [{ rotate: rotate}]}}>
                <Image
                    source={require('../assets/spinner.png')}
                    style={styles.img}
                />
            </Animated.View>
            <View style={styles.btn}>
                <Button
                    title='Start'
                    onPress={startRotation}
                />
                <Button
                    title='Stop'
                    onPress={stopRotation}
                />
            </View>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        justifyContent: 'center',
        alignItems: 'center'
    },
    img:{
        width: 400,
        height: 400,
        resizeMode: 'stretch',
    },
    btn:{
        flexDirection: 'row',
        justifyContent: 'space-between',
        gap: 10,
    }
})

export {Example_4};