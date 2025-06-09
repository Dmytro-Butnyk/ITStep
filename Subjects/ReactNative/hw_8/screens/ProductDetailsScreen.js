import React from 'react';
import { View, Text, Image, StyleSheet, Button } from 'react-native';

export default function ProductDetailsScreen({ route, navigation }) {
  const { product } = route.params;

  React.useLayoutEffect(() => {
    navigation.setOptions({
      title: product.title,
    });
  }, [navigation, product]);

  return (
    <View style={styles.container}>
      <Image source={product.image} style={styles.image} />
      <Text style={styles.title}>{product.title}</Text>
      <Text style={styles.price}>{product.price} грн</Text>
      {product.badge === 'new' && <Text style={styles.badgeNew}>Новинка</Text>}
      {product.badge === 'sale' && <Text style={styles.badgeSale}>Зі знижкою</Text>}
      <Text style={styles.description}>{product.description}</Text>
      <Button title="Додати в кошик" onPress={() => {}} color="#4a90e2" />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    padding: 20,
  },
  image: {
    width: 160,
    height: 160,
    borderRadius: 12,
    marginBottom: 16,
  },
  title: {
    fontSize: 24,
    fontWeight: 'bold',
    marginBottom: 8,
    textAlign: 'center',
  },
  price: {
    fontSize: 20,
    color: '#4a90e2',
    marginBottom: 8,
  },
  badgeNew: {
    backgroundColor: '#4a90e2',
    color: '#fff',
    borderRadius: 6,
    paddingHorizontal: 8,
    paddingVertical: 3,
    alignSelf: 'center',
    marginBottom: 8,
    fontSize: 14,
  },
  badgeSale: {
    backgroundColor: '#e94e77',
    color: '#fff',
    borderRadius: 6,
    paddingHorizontal: 8,
    paddingVertical: 3,
    alignSelf: 'center',
    marginBottom: 8,
    fontSize: 14,
  },
  description: {
    fontSize: 16,
    color: '#333',
    marginBottom: 24,
    textAlign: 'center',
  },
}); 