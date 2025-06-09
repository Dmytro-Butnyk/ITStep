import { StatusBar } from 'expo-status-bar';
import {SafeAreaView, StyleSheet} from 'react-native';
import List from "./components/List";

export default function App() {
  return (
    <SafeAreaView style={styles.container}>
      <List/>
      <StatusBar style='dark' backgroundColor='rgba(139, 0, 0, 0.5)'/>
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: 'yellow',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
