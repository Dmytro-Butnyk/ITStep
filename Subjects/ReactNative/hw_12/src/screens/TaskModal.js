import React, { useState, useContext } from "react";
import { View, TextInput, Button, Switch, StyleSheet, Text } from "react-native";
import { TasksContext } from "../context/TasksContext";

export default function TaskModal({ navigation }) {
  const { addTask } = useContext(TasksContext);
  const [title, setTitle] = useState("");
  const [desc, setDesc] = useState("");
  const [completed, setCompleted] = useState(false);

  const handleSave = () => {
    if (!title.trim()) return;
    addTask({ id: Date.now().toString(), title, desc, completed });
    navigation.goBack();
  };

  return (
    <View style={styles.container}>
      <Text style={styles.label}>Назва завдання</Text>
      <TextInput
        style={styles.input}
        placeholder="Назва завдання"
        value={title}
        onChangeText={setTitle}
      />
      <Text style={styles.label}>Опис</Text>
      <TextInput
        style={styles.input}
        placeholder="Опис"
        value={desc}
        onChangeText={setDesc}
      />
      <View style={styles.switchRow}>
        <Text>Виконано</Text>
        <Switch value={completed} onValueChange={setCompleted} />
      </View>
      <Button title="Зберегти" onPress={handleSave} />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: "center",
    padding: 20,
    backgroundColor: '#fff',
  },
  label: {
    marginTop: 10,
    marginBottom: 4,
    fontWeight: 'bold',
  },
  input: {
    borderWidth: 1,
    borderColor: '#ccc',
    borderRadius: 5,
    padding: 8,
    marginBottom: 10,
  },
  switchRow: {
    flexDirection: 'row',
    alignItems: 'center',
    marginBottom: 20,
    justifyContent: 'space-between',
  },
}); 