import React, { useContext } from "react";
import { View, StyleSheet, TouchableOpacity, Text } from "react-native";
import { TasksContext } from "../context/TasksContext";
import TaskList from "../components/TaskList";
import { Ionicons } from "@expo/vector-icons";

export default function TasksScreen({ navigation }) {
  const { tasks } = useContext(TasksContext);

  return (
    <View style={styles.container}>
      <TaskList tasks={tasks.filter(t => !t.completed)} />
      <View style={styles.buttonContainer}>
        <TouchableOpacity
          style={styles.addButton}
          onPress={() => navigation.navigate("TaskModal")}
        >
          <Ionicons name="add-circle" size={24} color="#fff" />
          <Text style={styles.addButtonText}>ДОДАТИ ЗАВДАННЯ</Text>
        </TouchableOpacity>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
  },
  buttonContainer: {
    padding: 10,
  },
  addButton: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor: '#2196f3',
    padding: 12,
    borderRadius: 5,
  },
  addButtonText: {
    color: '#fff',
    fontWeight: 'bold',
    marginLeft: 8,
  },
}); 