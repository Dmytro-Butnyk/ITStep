import React from 'react';
import { View, Text, TouchableOpacity, StyleSheet, Image } from 'react-native';

const HabitItem = ({ title, isCompleted, icon, onToggle }) => {
  return (
    <TouchableOpacity style={styles.habitContainer} onPress={onToggle}>
      <View style={styles.habitContent}>
        <View style={styles.iconContainer}>
          <Image source={icon} style={styles.icon} />
        </View>
        <Text style={styles.title}>{title}</Text>
      </View>
      <View style={[styles.checkbox, isCompleted && styles.checkboxChecked]}>
        {isCompleted && (
          <Text style={styles.checkmark}>✓</Text>
        )}
      </View>
    </TouchableOpacity>
  );
};

const styles = StyleSheet.create({
  habitContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
    backgroundColor: 'rgba(190, 220, 255, 0.65)',
    paddingVertical: 16,
    paddingHorizontal: 16,
    borderRadius: 20,
    marginVertical: 6,
  },
  habitContent: {
    flexDirection: 'row',
    alignItems: 'center',
    flex: 1,
    marginRight: 12,
  },
  iconContainer: {
    width: 50,
    height: 50,
    marginRight: 16,
    justifyContent: 'center',
    alignItems: 'center',
  },
  icon: {
    width: 84,
    height: 84,
    resizeMode: 'contain',
    position: 'absolute',
  },
  title: {
    fontSize: 16,
    color: '#000080',
    flex: 1,
    lineHeight: 20,
  },
  checkbox: {
    width: 24,
    height: 24,
    borderRadius: 12,
    borderWidth: 2,
    borderColor: '#000080',
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor: 'transparent',
  },
  checkboxChecked: {
    backgroundColor: '#000080',
  },
  checkmark: {
    color: 'white',
    fontSize: 16,
    fontWeight: '600',
    marginTop: -2,
  },
});

export default HabitItem; 