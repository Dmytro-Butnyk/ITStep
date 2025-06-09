import React from 'react';
import { View, Text, StyleSheet } from 'react-native';

export default function HomeScreen() {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>Вітаємо в застосунку!</Text>
      <Text style={styles.quote}>"Знання — це сила."</Text>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: '#bdbdbd', justifyContent: 'center', alignItems: 'center' },
  title: { fontSize: 20, fontWeight: 'bold', marginBottom: 10 },
  quote: { fontSize: 16, fontStyle: 'italic', color: '#333' },
}); 