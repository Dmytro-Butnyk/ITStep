import React from 'react';
import { View, Text, StyleSheet, TouchableOpacity } from 'react-native';
import { MaterialIcons } from '@expo/vector-icons';

const CartBar = ({ count, total, onViewOrder }) => (
  <View style={styles.container}>
    <View style={styles.info}>
      <MaterialIcons name="shopping-cart" size={24} color="#fff" />
      <Text style={styles.text}>У кошику: {count} | Сума: {total} грн</Text>
    </View>
    <TouchableOpacity style={styles.button} onPress={onViewOrder}>
      <Text style={styles.buttonText}>Переглянути замовлення</Text>
    </TouchableOpacity>
  </View>
);

const styles = StyleSheet.create({
  container: {
    flexDirection: 'column',
    alignItems: 'stretch',
    backgroundColor: '#4CAF50',
    padding: 12,
    position: 'absolute',
    left: 0,
    right: 0,
    bottom: 0,
    zIndex: 10,
  },
  info: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'center',
    marginBottom: 8,
  },
  text: {
    color: '#fff',
    marginLeft: 8,
    fontWeight: 'bold',
    fontSize: 16,
  },
  button: {
    backgroundColor: '#fff',
    paddingVertical: 10,
    borderRadius: 8,
    minWidth: undefined,
    alignItems: 'center',
  },
  buttonText: {
    color: '#4CAF50',
    fontWeight: 'bold',
    fontSize: 15,
  },
});

export default CartBar; 