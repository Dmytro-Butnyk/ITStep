import React, { useState } from 'react';
import { StyleSheet, View, FlatList, SafeAreaView, StatusBar } from 'react-native';
import { dishes } from './data/dishes';
import DishCard from './components/DishCard';
import CartBar from './components/CartBar';
import OrderModal from './components/OrderModal';

export default function App() {
  const [cart, setCart] = useState([]);
  const [modalVisible, setModalVisible] = useState(false);

  const addToCart = (dish) => {
    setCart((prev) => [...prev, dish]);
  };

  const removeFromCart = (id) => {
    setCart((prev) => prev.filter((item, idx) => idx !== prev.findIndex(i => i.id === id)));
  };

  const clearCart = () => setCart([]);

  const total = cart.reduce((sum, item) => sum + item.price, 0);

  return (
    <SafeAreaView style={styles.container}>
      <FlatList
        data={dishes}
        keyExtractor={item => item.id}
        renderItem={({ item }) => (
          <DishCard dish={item} onAdd={() => addToCart(item)} />
        )}
        contentContainerStyle={{ paddingBottom: 90 }}
      />
      <CartBar
        count={cart.length}
        total={total}
        onViewOrder={() => setModalVisible(true)}
      />
      <OrderModal
        visible={modalVisible}
        cart={cart}
        onRemove={id => setCart(cart.filter((item, idx) => idx !== cart.findIndex(i => i.id === id)))}
        onClear={clearCart}
        onClose={() => setModalVisible(false)}
      />
      <StatusBar style="auto" />
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#f5f5f5',
  },
});
