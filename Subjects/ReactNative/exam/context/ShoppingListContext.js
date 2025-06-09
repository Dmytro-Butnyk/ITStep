import React, { createContext, useContext, useEffect, useState } from 'react';
import AsyncStorage from '@react-native-async-storage/async-storage';

const ShoppingListContext = createContext();

export const ShoppingListProvider = ({ children }) => {
  const [lists, setLists] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    loadLists();
  }, []);

  useEffect(() => {
    if (!loading) saveLists();
  }, [lists]);

  const loadLists = async () => {
    try {
      const data = await AsyncStorage.getItem('SHOPPING_LISTS');
      if (data) setLists(JSON.parse(data));
    } catch (e) {
      console.log('Помилка завантаження списків', e);
    } finally {
      setLoading(false);
    }
  };

  const saveLists = async () => {
    try {
      await AsyncStorage.setItem('SHOPPING_LISTS', JSON.stringify(lists));
    } catch (e) {
      console.log('Помилка збереження списків', e);
    }
  };

  const addList = (title) => {
    setLists(prev => [
      ...prev,
      { id: Date.now().toString(), title, products: [] }
    ]);
  };

  const editList = (id, newTitle) => {
    setLists(prev => prev.map(list => list.id === id ? { ...list, title: newTitle } : list));
  };

  const deleteList = (id) => {
    setLists(prev => prev.filter(list => list.id !== id));
  };

  const addProduct = (listId, product) => {
    setLists(prev => prev.map(list =>
      list.id === listId
        ? { ...list, products: [...list.products, { ...product, id: Date.now().toString(), bought: false }] }
        : list
    ));
  };

  const editProduct = (listId, productId, newProduct) => {
    setLists(prev => prev.map(list =>
      list.id === listId
        ? {
            ...list,
            products: list.products.map(p => p.id === productId ? { ...p, ...newProduct } : p)
          }
        : list
    ));
  };

  const deleteProduct = (listId, productId) => {
    setLists(prev => prev.map(list =>
      list.id === listId
        ? { ...list, products: list.products.filter(p => p.id !== productId) }
        : list
    ));
  };

  const toggleProductStatus = (listId, productId) => {
    setLists(prev => prev.map(list =>
      list.id === listId
        ? {
            ...list,
            products: list.products.map(p => p.id === productId ? { ...p, bought: !p.bought } : p)
          }
        : list
    ));
  };

  return (
    <ShoppingListContext.Provider
      value={{ lists, addList, editList, deleteList, addProduct, editProduct, deleteProduct, toggleProductStatus, loading }}
    >
      {children}
    </ShoppingListContext.Provider>
  );
};

export const useShoppingList = () => useContext(ShoppingListContext); 