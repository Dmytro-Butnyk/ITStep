import React from 'react';
import { View, Text, StyleSheet, Image, Button } from 'react-native';

export default function ProfileScreen() {
  return (
    <View style={styles.container}>
      <Image
        source={{ uri: 'https://randomuser.me/api/portraits/men/1.jpg' }}
        style={styles.avatar}
      />
      <Text style={styles.name}>Ім'я: Іван Студент</Text>
      <Text style={styles.email}>Email: student@example.com</Text>
      <View style={styles.button}>
        <Button title="ВИЙТИ" color="#1976d2" onPress={() => {}} />
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: '#bdbdbd', alignItems: 'center', justifyContent: 'center' },
  avatar: { width: 100, height: 100, borderRadius: 50, marginBottom: 20 },
  name: { fontSize: 18, fontWeight: 'bold', marginBottom: 5 },
  email: { fontSize: 16, color: '#333', marginBottom: 20 },
  button: { width: 100 },
}); 