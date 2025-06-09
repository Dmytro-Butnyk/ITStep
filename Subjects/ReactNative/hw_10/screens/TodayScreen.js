import React, { useState } from 'react';
import { View, Text, Button, Modal, StyleSheet } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

const moods = [
  { label: 'Гарний', value: 'good' },
  { label: 'Нейтральний', value: 'neutral' },
  { label: 'Поганий', value: 'bad' },
];

export default function TodayScreen() {
  const [modalVisible, setModalVisible] = useState(false);
  const [selectedMood, setSelectedMood] = useState(null);

  const saveMood = async (mood) => {
    const now = new Date();
    const entry = {
      date: now.toLocaleDateString(),
      time: now.toLocaleTimeString(),
      mood,
    };
    const history = JSON.parse(await AsyncStorage.getItem('moodHistory')) || [];
    history.unshift(entry);
    await AsyncStorage.setItem('moodHistory', JSON.stringify(history));
  };

  const handleMood = async (mood) => {
    setSelectedMood(mood);
    await saveMood(mood);
    setModalVisible(true);
  };

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Який у вас сьогодні настрій?</Text>
      {moods.map((m) => (
        <View key={m.value} style={styles.buttonContainer}>
          <Button
            title={m.label}
            onPress={() => handleMood(m.label)}
            color="#1976d2"
          />
        </View>
      ))}
      <Modal
        visible={modalVisible}
        transparent
        animationType="fade"
        onRequestClose={() => setModalVisible(false)}
      >
        <View style={styles.modalBg}>
          <View style={styles.modalContent}>
            <Text>Збережено!</Text>
            <Text>Ваш настрій: {selectedMood}</Text>
            <Button title="OK" onPress={() => setModalVisible(false)} />
          </View>
        </View>
      </Modal>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, padding: 24, backgroundColor: '#fff' },
  title: { fontSize: 18, fontWeight: 'bold', marginBottom: 24 },
  buttonContainer: { marginVertical: 8 },
  modalBg: {
    flex: 1, justifyContent: 'center', alignItems: 'center', backgroundColor: 'rgba(0,0,0,0.4)'
  },
  modalContent: {
    backgroundColor: '#fff', padding: 24, borderRadius: 8, alignItems: 'center'
  },
}); 