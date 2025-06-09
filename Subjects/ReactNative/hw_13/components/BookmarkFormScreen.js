import React, { useState, useEffect } from 'react';
import { View, Text, TextInput, TouchableOpacity, StyleSheet, Alert } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { useNavigation, useRoute } from '@react-navigation/native';

function generateId() {
  return Math.random().toString(36).substr(2, 9);
}

export default function BookmarkFormScreen() {
  const navigation = useNavigation();
  const route = useRoute();
  const editingBookmark = route.params?.bookmark;

  const [title, setTitle] = useState(editingBookmark ? editingBookmark.title : '');
  const [url, setUrl] = useState(editingBookmark ? editingBookmark.url : '');
  const [description, setDescription] = useState(editingBookmark ? editingBookmark.description : '');

  useEffect(() => {
    if (editingBookmark) {
      setTitle(editingBookmark.title);
      setUrl(editingBookmark.url);
      setDescription(editingBookmark.description);
    }
  }, [editingBookmark]);

  const saveBookmark = async () => {
    if (!title || !url) {
      Alert.alert('Validation', 'Title and URL are required');
      return;
    }
    try {
      const data = await AsyncStorage.getItem('bookmarks');
      let bookmarks = data ? JSON.parse(data) : [];
      if (editingBookmark) {
        bookmarks = bookmarks.map(b => b.id === editingBookmark.id ? { ...b, title, url, description } : b);
      } else {
        bookmarks.push({ id: generateId(), title, url, description });
      }
      await AsyncStorage.setItem('bookmarks', JSON.stringify(bookmarks));
      navigation.goBack();
    } catch (e) {
      Alert.alert('Error', 'Failed to save bookmark');
    }
  };

  return (
    <View style={styles.container}>
      <Text style={styles.label}>Title</Text>
      <TextInput style={styles.input} value={title} onChangeText={setTitle} placeholder="Enter title" />
      <Text style={styles.label}>URL</Text>
      <TextInput style={styles.input} value={url} onChangeText={setUrl} placeholder="Enter URL" autoCapitalize="none" />
      <Text style={styles.label}>Description</Text>
      <TextInput style={styles.input} value={description} onChangeText={setDescription} placeholder="Enter description" />
      <TouchableOpacity style={styles.saveBtn} onPress={saveBookmark}>
        <Text style={styles.saveBtnText}>Save</Text>
      </TouchableOpacity>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, padding: 20, backgroundColor: '#fff' },
  label: { fontWeight: 'bold', marginTop: 12 },
  input: { borderWidth: 1, borderColor: '#ccc', borderRadius: 6, padding: 10, marginTop: 4 },
  saveBtn: { backgroundColor: '#28a745', padding: 16, alignItems: 'center', marginTop: 24, borderRadius: 8 },
  saveBtnText: { color: '#fff', fontWeight: 'bold', fontSize: 16 },
}); 