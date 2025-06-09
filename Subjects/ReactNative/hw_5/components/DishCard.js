import React from 'react';
import { View, Text, Image, StyleSheet, TouchableOpacity } from 'react-native';
import { AntDesign } from '@expo/vector-icons';

const DishCard = ({ dish, onAdd }) => (
  <View style={styles.card}>
    <Image source={{ uri: dish.image }} style={styles.image} />
    <View style={styles.info}>
      <Text style={styles.name}>{dish.name}</Text>
      <Text style={styles.description}>{dish.description}</Text>
      <Text style={styles.price}>{dish.price} грн</Text>
      <TouchableOpacity style={styles.button} onPress={onAdd}>
        <AntDesign name="pluscircleo" size={24} color="#4CAF50" />
        <Text style={styles.buttonText}>Додати до кошика</Text>
      </TouchableOpacity>
    </View>
  </View>
);

const styles = StyleSheet.create({
  card: {
    flexDirection: 'row',
    backgroundColor: '#fff',
    borderRadius: 12,
    marginVertical: 8,
    marginHorizontal: 16,
    elevation: 2,
    shadowColor: '#000',
    shadowOpacity: 0.1,
    shadowRadius: 4,
    shadowOffset: { width: 0, height: 2 },
    overflow: 'hidden',
  },
  image: {
    width: 100,
    height: 100,
    borderTopLeftRadius: 12,
    borderBottomLeftRadius: 12,
    resizeMode: 'cover',
    backgroundColor: '#f0f0f0',
    alignSelf: 'center',
  },
  info: {
    flex: 1,
    padding: 12,
    justifyContent: 'center',
  },
  name: {
    fontSize: 18,
    fontWeight: 'bold',
    marginBottom: 4,
  },
  description: {
    color: '#555',
    marginBottom: 6,
  },
  price: {
    color: '#E91E63',
    fontWeight: 'bold',
    fontSize: 16,
    marginBottom: 8,
  },
  button: {
    flexDirection: 'row',
    alignItems: 'center',
    backgroundColor: '#E8F5E9',
    padding: 6,
    borderRadius: 8,
    alignSelf: 'flex-start',
  },
  buttonText: {
    marginLeft: 6,
    color: '#4CAF50',
    fontWeight: 'bold',
  },
});

export default DishCard; 