import React, { useContext } from "react";
import { View, StyleSheet } from "react-native";
import { TasksContext } from "../context/TasksContext";
import TaskList from "../components/TaskList";

export default function CompletedScreen() {
  const { tasks } = useContext(TasksContext);

  return (
    <View style={styles.container}>
      <TaskList tasks={tasks.filter(t => t.completed)} />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
  },
}); 