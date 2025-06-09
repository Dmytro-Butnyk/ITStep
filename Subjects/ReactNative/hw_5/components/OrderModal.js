import React from 'react';
import { View, Text, Modal, StyleSheet, TouchableOpacity, FlatList } from 'react-native';
import { AntDesign } from '@expo/vector-icons';

const OrderModal = ({ visible, cart, onRemove, onClear, onClose }) => (
  <Modal visible={visible} animationType="slide" transparent>
    <View style={styles.overlay}>
      <View style={styles.modal}>
        <Text style={styles.title}>Ваше замовлення</Text>
        {cart.length === 0 ? (
          <Text style={styles.empty}>Кошик порожній</Text>
        ) : (
          <FlatList
            data={cart}
            keyExtractor={(item, index) => item.id + '_' + index}
            renderItem={({ item }) => (
              <View style={styles.item}>
                <Text style={styles.itemText}>{item.name} ({item.price} грн)</Text>
                <TouchableOpacity onPress={() => onRemove(item.id)}>
                  <AntDesign name="delete" size={22} color="#E91E63" />
                </TouchableOpacity>
              </View>
            )}
          />
        )}
        <View style={styles.buttons}>
          <TouchableOpacity style={styles.clearBtn} onPress={onClear}>
            <Text style={styles.clearText}>Очистити</Text>
          </TouchableOpacity>
          <TouchableOpacity style={styles.closeBtn} onPress={onClose}>
            <Text style={styles.closeText}>Закрити</Text>
          </TouchableOpacity>
        </View>
      </View>
    </View>
  </Modal>
);

const styles = StyleSheet.create({
  overlay: {
    flex: 1,
    backgroundColor: 'rgba(0,0,0,0.4)',
    justifyContent: 'center',
    alignItems: 'center',
  },
  modal: {
    width: '85%',
    backgroundColor: '#fff',
    borderRadius: 16,
    padding: 20,
    elevation: 5,
  },
  title: {
    fontSize: 20,
    fontWeight: 'bold',
    marginBottom: 16,
    textAlign: 'center',
  },
  empty: {
    textAlign: 'center',
    color: '#888',
    marginVertical: 24,
  },
  item: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    paddingVertical: 8,
    borderBottomWidth: 1,
    borderBottomColor: '#eee',
  },
  itemText: {
    fontSize: 16,
  },
  buttons: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    marginTop: 18,
  },
  clearBtn: {
    backgroundColor: '#E91E63',
    padding: 10,
    borderRadius: 8,
  },
  clearText: {
    color: '#fff',
    fontWeight: 'bold',
  },
  closeBtn: {
    backgroundColor: '#4CAF50',
    padding: 10,
    borderRadius: 8,
  },
  closeText: {
    color: '#fff',
    fontWeight: 'bold',
  },
});

export default OrderModal; 