import React, { useContext } from "react";
import { View, Text, StyleSheet, TouchableOpacity } from "react-native";
import { Ionicons } from "@expo/vector-icons";
import { TasksContext } from "../context/TasksContext";

export default function TaskItem({ task }) {
  const { updateTask } = useContext(TasksContext);

  const toggleCompleted = () => {
    updateTask(task.id, { completed: !task.completed });
  };

  return (
    <View style={styles.item}>
      <TouchableOpacity onPress={toggleCompleted} style={styles.checkBox}>
        {task.completed ? (
          <Ionicons name="checkmark-circle" size={24} color="green" />
        ) : (
          <Ionicons name="ellipse-outline" size={24} color="#bbb" />
        )}
      </TouchableOpacity>
      <Text style={[styles.title, task.completed && styles.completed]}>{task.title}</Text>
    </View>
  );
}

const styles = StyleSheet.create({
  item: {
    flexDirection: 'row',
    alignItems: 'center',
    padding: 10,
    borderBottomWidth: 1,
    borderBottomColor: '#eee',
  },
  checkBox: {
    marginRight: 10,
  },
  title: {
    fontSize: 16,
    flex: 1,
  },
  completed: {
    textDecorationLine: 'line-through',
    color: '#888',
  },
}); 