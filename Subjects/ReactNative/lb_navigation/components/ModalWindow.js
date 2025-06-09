import {Button, Modal, Text, View, StyleSheet} from "react-native";
import React from "react";


const ModalWindow = ({modalVisible, setModalVisible}) => {
    return (
        <Modal
            animationType="slide"
            transparent={true}
            visible={modalVisible}
            onRequestClose={() => setModalVisible(false)}
        >
            <View style={styles.modalContainer}>
                <View style={styles.modalContent}>
                    <Text style={styles.modalText}>Modal window</Text>
                    <Button title="Close" onPress={() => setModalVisible(false)}/>
                </View>
            </View>
        </Modal>
    )
}

const styles = StyleSheet.create({
    modalContainer: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
        backgroundColor: 'rgba(0, 0, 0, 0.5)', // затемнение фона
    },
    modalContent: {
        width: 300,
        backgroundColor: '#fff',
        padding: 20,
        borderRadius: 10,
        elevation: 5,
        alignItems: 'center',
    },
    modalText: {
        marginBottom: 20,
        fontSize: 18,
    },
});


export default ModalWindow;