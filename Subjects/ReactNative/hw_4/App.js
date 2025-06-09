import React, { useState } from 'react';
import { StyleSheet, View, Text, ScrollView, TouchableOpacity, Image, SafeAreaView } from 'react-native';
import { StatusBar } from 'expo-status-bar';
import HabitItem from './components/HabitItem';

// Import images
const images = {
  book: require('./assets/book.png'),
  water: require('./assets/water.png'),
  abc: require('./assets/abc.png'),
  dumbbell: require('./assets/dumbbell.png'),
  alarm: require('./assets/alarm.png'),
  broccoli: require('./assets/broccoli.png'),
};

export default function App() {
  const [habits, setHabits] = useState([
    {
      id: 1,
      title: 'Read 30 minutes a day',
      isCompleted: true,
      icon: require('./assets/book.png'),
    },
    {
      id: 2,
      title: 'Drink 1.5 liters of water a day',
      isCompleted: true,
      icon: require('./assets/water.png'),
    },
    {
      id: 3,
      title: 'Take one English lesson a day',
      isCompleted: false,
      icon: require('./assets/abc.png'),
    },
    {
      id: 4,
      title: 'Training in the hall three times\na week',
      isCompleted: true,
      icon: require('./assets/dumbbell.png'),
    },
    {
      id: 5,
      title: 'Wake up at 7:00',
      isCompleted: true,
      icon: require('./assets/alarm.png'),
    },
    {
      id: 6,
      title: 'Eat right',
      isCompleted: false,
      icon: require('./assets/broccoli.png'),
    },
  ]);

  const toggleHabit = (id) => {
    setHabits(habits.map(habit =>
      habit.id === id ? { ...habit, isCompleted: !habit.isCompleted } : habit
    ));
  };

  return (
    <SafeAreaView style={styles.container}>
      <StatusBar style="dark" />
      <View style={styles.header}>
        <TouchableOpacity style={styles.backButton}>
          <Text style={styles.backArrow}>←</Text>
        </TouchableOpacity>
        <View style={styles.headerTitleContainer}>
          <Text style={styles.headerTitle}>New habit</Text>
        </View>
      </View>
      
      <ScrollView 
        style={styles.habitsList} 
        showsVerticalScrollIndicator={false}
        contentContainerStyle={styles.habitsListContent}
      >
        {habits.map(habit => (
          <HabitItem
            key={habit.id}
            title={habit.title}
            isCompleted={habit.isCompleted}
            icon={habit.icon}
            onToggle={() => toggleHabit(habit.id)}
          />
        ))}
      </ScrollView>

      <View style={styles.bottomContainer}>
        <View style={styles.buttonWrapper}>
          <TouchableOpacity style={styles.createButton}>
            <Text style={styles.createButtonText}>+ Create a habit</Text>
          </TouchableOpacity>
          <TouchableOpacity style={styles.arrowButton}>
            <Text style={styles.arrowText}>→</Text>
          </TouchableOpacity>
        </View>
      </View>
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#FFF6E9',
  },
  header: {
    paddingTop: 8,
    paddingBottom: 12,
    paddingHorizontal: 20,
    flexDirection: 'row',
    alignItems: 'center',
    position: 'relative',
  },
  backButton: {
    position: 'absolute',
    left: 20,
    zIndex: 1,
  },
  backArrow: {
    fontSize: 28,
    color: '#000080',
    fontWeight: '300',
  },
  headerTitleContainer: {
    flex: 1,
    alignItems: 'center',
  },
  headerTitle: {
    fontSize: 24,
    fontWeight: '600',
    color: '#000080',
  },
  habitsList: {
    flex: 1,
  },
  habitsListContent: {
    paddingHorizontal: 20,
    paddingTop: 4,
    paddingBottom: 20,
  },
  bottomContainer: {
    paddingHorizontal: 20,
    paddingBottom: 30,
  },
  buttonWrapper: {
    position: 'relative',
    flexDirection: 'row',
    alignItems: 'center',
  },
  createButton: {
    backgroundColor: '#000080',
    height: 56,
    borderRadius: 28,
    alignItems: 'center',
    justifyContent: 'center',
    flex: 1,
    marginRight: 44,
  },
  createButtonText: {
    color: 'white',
    fontSize: 17,
    fontWeight: '500',
  },
  arrowButton: {
    width: 32,
    height: 32,
    borderRadius: 16,
    backgroundColor: '#000080',
    alignItems: 'center',
    justifyContent: 'center',
    position: 'absolute',
    right: 0,
    elevation: 2,
    shadowColor: '#000',
    shadowOffset: {
      width: 0,
      height: 2,
    },
    shadowOpacity: 0.25,
    shadowRadius: 3.84,
  },
  arrowText: {
    color: 'white',
    fontSize: 20,
    marginTop: -2,
  },
});
