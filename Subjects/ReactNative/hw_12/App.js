import React from "react";
import { NavigationContainer } from "@react-navigation/native";
import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import TasksScreen from "./src/screens/TasksScreen";
import CompletedScreen from "./src/screens/CompletedScreen";
import TaskModal from "./src/screens/TaskModal";
import { TasksProvider } from "./src/context/TasksContext";
import { Ionicons } from "@expo/vector-icons";

const Tab = createBottomTabNavigator();
const Stack = createNativeStackNavigator();

function MainTabs() {
  return (
    <Tab.Navigator
      screenOptions={({ route }) => ({
        tabBarIcon: ({ color, size }) => {
          if (route.name === "Завдання") {
            return <Ionicons name="list-outline" size={size} color={color} />;
          } else if (route.name === "Виконані") {
            return <Ionicons name="checkmark-done-outline" size={size} color={color} />;
          }
        },
        tabBarActiveTintColor: '#b84cff',
        tabBarInactiveTintColor: 'gray',
      })}
    >
      <Tab.Screen name="Завдання" component={TasksScreen} />
      <Tab.Screen name="Виконані" component={CompletedScreen} />
    </Tab.Navigator>
  );
}

export default function App() {
  return (
    <TasksProvider>
      <NavigationContainer>
        <Stack.Navigator>
          <Stack.Screen
            name="Main"
            component={MainTabs}
            options={{ headerShown: false }}
          />
          <Stack.Screen
            name="TaskModal"
            component={TaskModal}
            options={{ presentation: "modal", title: "Завдання" }}
          />
        </Stack.Navigator>
      </NavigationContainer>
    </TasksProvider>
  );
}
