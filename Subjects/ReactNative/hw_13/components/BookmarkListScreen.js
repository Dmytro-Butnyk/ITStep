import React, { useEffect, useState } from 'react';
import { View, Text, FlatList, TouchableOpacity, StyleSheet, Alert } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { useNavigation, useIsFocused } from '@react-navigation/native';
import * as Linking from 'expo-linking';

export default function BookmarkListScreen() {
  const [bookmarks, setBookmarks] = useState([]);
  const navigation = useNavigation();
  const isFocused = useIsFocused();

  useEffect(() => {
    loadBookmarks();
  }, [isFocused]);

  const loadBookmarks = async () => {
    try {
      const data = await AsyncStorage.getItem('bookmarks');
      if (data) setBookmarks(JSON.parse(data));
      else setBookmarks([]);
    } catch (e) {
      Alert.alert('Error', 'Failed to load bookmarks');
    }
  };

  const deleteBookmark = async (id) => {
    const filtered = bookmarks.filter(b => b.id !== id);
    setBookmarks(filtered);
    await AsyncStorage.setItem('bookmarks', JSON.stringify(filtered));
  };

  const openUrl = async (url) => {
    let finalUrl = url;
    if (!/^https?:\/\//i.test(finalUrl)) {
      finalUrl = 'https://' + finalUrl;
    }
    try {
      const supported = await Linking.canOpenURL(finalUrl);
      if (supported) {
        await Linking.openURL(finalUrl);
      } else {
        Alert.alert('Error', 'Cannot open this URL: ' + finalUrl);
      }
    } catch (e) {
      Alert.alert('Error', 'Failed to open URL: ' + finalUrl);
    }
  };

  const renderItem = ({ item }) => (
    <View style={styles.item}>
      <TouchableOpacity onPress={() => openUrl(item.url)} style={{ flex: 1 }}>
        <Text style={styles.title}>{item.title}</Text>
        <Text style={styles.url}>{item.url}</Text>
        <Text style={styles.desc}>{item.description}</Text>
      </TouchableOpacity>
      <View style={styles.actions}>
        <TouchableOpacity onPress={() => navigation.navigate('BookmarkForm', { bookmark: item })} style={styles.actionBtn}>
          <Text>✏️</Text>
        </TouchableOpacity>
        <TouchableOpacity onPress={() => deleteBookmark(item.id)} style={styles.actionBtn}>
          <Text>🗑️</Text>
        </TouchableOpacity>
      </View>
    </View>
  );

  return (
    <View style={styles.container}>
      <FlatList
        data={bookmarks}
        keyExtractor={item => item.id}
        renderItem={renderItem}
        ListEmptyComponent={<Text style={{ textAlign: 'center', marginTop: 20 }}>No bookmarks yet</Text>}
      />
      <TouchableOpacity style={styles.addBtn} onPress={() => navigation.navigate('BookmarkForm')}>
        <Text style={styles.addBtnText}>+ Add Bookmark</Text>
      </TouchableOpacity>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: '#fff' },
  item: { flexDirection: 'row', alignItems: 'center', padding: 12, borderBottomWidth: 1, borderColor: '#eee' },
  title: { fontWeight: 'bold', fontSize: 16 },
  url: { color: 'blue', textDecorationLine: 'underline' },
  desc: { color: '#555' },
  actions: { flexDirection: 'row', marginLeft: 8 },
  actionBtn: { marginHorizontal: 4, padding: 4 },
  addBtn: { backgroundColor: '#007bff', padding: 16, alignItems: 'center', margin: 16, borderRadius: 8 },
  addBtnText: { color: '#fff', fontWeight: 'bold', fontSize: 16 },
}); 