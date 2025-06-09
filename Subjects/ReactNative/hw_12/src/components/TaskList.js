import React from "react";
import { FlatList } from "react-native";
import TaskItem from "./TaskItem";

export default function TaskList({ tasks }) {
  return (
    <FlatList
      data={tasks}
      keyExtractor={item => item.id}
      renderItem={({ item }) => <TaskItem task={item} />}
    />
  );
} 