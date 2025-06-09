import React from 'react';
import { View, Text, FlatList, TouchableOpacity, Image, StyleSheet, Button } from 'react-native';

const PRODUCTS = [
  {
    id: '1',
    title: 'Смартфон X100',
    price: 9999,
    description: 'Потужний смартфон з AMOLED-дисплеєм.',
    image: require('../assets/icon.png'),
    badge: 'new',
  },
  {
    id: '2',
    title: 'Навушники ProSound',
    price: 2999,
    description: 'Безпровідні навушники з шумозаглушенням.',
    image: require('../assets/adaptive-icon.png'),
    badge: 'sale',
  },
  {
    id: '3',
    title: 'Ноутбук UltraBook',
    price: 24999,
    description: 'Легкий ноутбук для роботи та навчання.',
    image: require('../assets/splash-icon.png'),
    badge: '',
  },
  {
    id: '4',
    title: 'Смарт-годинник FitTime',
    price: 4999,
    description: 'Годинник для спорту та здоровʼя.',
    image: require('../assets/favicon.png'),
    badge: 'new',
  },
  {
    id: '5',
    title: 'Планшет TabX',
    price: 13999,
    description: 'Планшет для розваг та роботи.',
    image: require('../assets/icon.png'),
    badge: 'sale',
  },
];

export default function ProductListScreen({ navigation }) {
  React.useLayoutEffect(() => {
    navigation.setOptions({
      headerRight: () => (
        <TouchableOpacity
          onPress={() => navigation.navigate('About')}
          style={styles.headerButton}
        >
          <Text style={styles.headerButtonText}>Про застосунок</Text>
        </TouchableOpacity>
      ),
    });
  }, [navigation]);

  const renderItem = ({ item }) => (
    <TouchableOpacity
      style={styles.item}
      onPress={() => navigation.navigate('ProductDetails', { product: item })}
    >
      <Image source={item.image} style={styles.image} />
      <View style={{ flex: 1 }}>
        <Text style={styles.title}>{item.title}</Text>
        <Text style={styles.price}>{item.price} грн</Text>
        {item.badge === 'new' && <Text style={styles.badgeNew}>Новинка</Text>}
        {item.badge === 'sale' && <Text style={styles.badgeSale}>Зі знижкою</Text>}
      </View>
    </TouchableOpacity>
  );

  return (
    <View style={styles.container}>
      <FlatList
        data={PRODUCTS}
        renderItem={renderItem}
        keyExtractor={item => item.id}
      />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#f5f5f5',
    padding: 10,
  },
  item: {
    flexDirection: 'row',
    backgroundColor: '#fff',
    marginBottom: 12,
    borderRadius: 8,
    padding: 10,
    alignItems: 'center',
    elevation: 2,
  },
  image: {
    width: 60,
    height: 60,
    marginRight: 12,
    borderRadius: 8,
  },
  title: {
    fontSize: 18,
    fontWeight: 'bold',
  },
  price: {
    fontSize: 16,
    color: '#4a90e2',
    marginVertical: 2,
  },
  badgeNew: {
    backgroundColor: '#4a90e2',
    color: '#fff',
    borderRadius: 6,
    paddingHorizontal: 6,
    paddingVertical: 2,
    alignSelf: 'flex-start',
    marginTop: 4,
    fontSize: 12,
  },
  badgeSale: {
    backgroundColor: '#e94e77',
    color: '#fff',
    borderRadius: 6,
    paddingHorizontal: 6,
    paddingVertical: 2,
    alignSelf: 'flex-start',
    marginTop: 4,
    fontSize: 12,
  },
  headerButton: {
    backgroundColor: 'transparent',
    paddingHorizontal: 12,
    paddingVertical: 6,
    marginRight: 8,
  },
  headerButtonText: {
    color: '#000',
    fontSize: 16,
  },
}); 