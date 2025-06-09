import React, { createContext, useState } from "react";

export const TasksContext = createContext();

export const TasksProvider = ({ children }) => {
  const [tasks, setTasks] = useState([]);

  const addTask = (task) => setTasks([...tasks, task]);
  const updateTask = (id, updatedTask) =>
    setTasks(tasks.map(t => t.id === id ? { ...t, ...updatedTask } : t));

  return (
    <TasksContext.Provider value={{ tasks, addTask, updateTask }}>
      {children}
    </TasksContext.Provider>
  );
}; 