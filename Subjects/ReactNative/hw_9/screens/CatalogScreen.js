import React from 'react';
import { View, Text, StyleSheet, FlatList } from 'react-native';

const DATA = [
  { id: '1', title: 'Книга: React для початківців', desc: 'Основи React', color: '#e1bee7' },
  { id: '2', title: 'Курс: Основи JavaScript', desc: 'Вивчення JS', color: '#b2ebf2' },
  { id: '3', title: 'Фільм: Social Network', desc: 'Історія Facebook', color: '#ffcdd2' },
  { id: '4', title: 'Книга: Design Patterns', desc: 'Патерни проектування', color: '#c8e6c9' },
  { id: '5', title: 'Курс: HTML + CSS', desc: 'Верстка сайтів', color: '#e1bee7' },
];

export default function CatalogScreen() {
  return (
    <View style={styles.container}>
      <FlatList
        data={DATA}
        keyExtractor={item => item.id}
        renderItem={({ item }) => (
          <View style={[styles.item, { backgroundColor: item.color }]}> 
            <Text style={styles.title}>{item.title}</Text>
            <Text style={styles.desc}>{item.desc}</Text>
          </View>
        )}
        contentContainerStyle={{ paddingVertical: 20 }}
      />
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: '#bdbdbd' },
  item: { margin: 10, borderRadius: 10, padding: 15, elevation: 2 },
  title: { fontWeight: 'bold', fontSize: 16 },
  desc: { fontSize: 14, color: '#555' },
}); 