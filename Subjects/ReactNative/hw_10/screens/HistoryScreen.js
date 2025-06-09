import React, { useState } from 'react';
import { View, Text, FlatList, StyleSheet } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { useFocusEffect } from '@react-navigation/native';

export default function HistoryScreen() {
  const [history, setHistory] = useState([]);

  useFocusEffect(
    React.useCallback(() => {
      const fetchHistory = async () => {
        const data = await AsyncStorage.getItem('moodHistory');
        setHistory(data ? JSON.parse(data) : []);
      };
      fetchHistory();
    }, [])
  );

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Історія</Text>
      <FlatList
        data={history}
        keyExtractor={(_, i) => i.toString()}
        renderItem={({ item }) => (
          <Text style={styles.item}>
            {item.date} - {item.time} - {item.mood}
          </Text>
        )}
      />
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, padding: 24, backgroundColor: '#fff' },
  title: { fontSize: 18, fontWeight: 'bold', marginBottom: 16 },
  item: { fontSize: 16, marginBottom: 8 },
}); 