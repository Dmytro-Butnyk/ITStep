import React from 'react';
import { View, Text, StyleSheet } from 'react-native';

export default function AboutScreen() {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>Про застосунок</Text>
      <Text style={styles.text}>Цей застосунок імітує перегляд товарів у магазині. Ви можете переглядати список товарів, деталі кожного товару, а також дізнатися більше про застосунок на цьому екрані.</Text>
      <Text style={styles.text}>Розроблено для навчального завдання ITStep.</Text>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
    padding: 24,
  },
  title: {
    fontSize: 24,
    fontWeight: 'bold',
    marginBottom: 16,
    color: '#4a90e2',
  },
  text: {
    fontSize: 16,
    color: '#333',
    marginBottom: 12,
    textAlign: 'center',
  },
}); 