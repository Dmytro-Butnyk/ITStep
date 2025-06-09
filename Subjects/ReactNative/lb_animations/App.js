import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View } from 'react-native';
import {Example_1} from "./components/Example_1";
import {Example_2} from "./components/Example_2";
import {Example_3} from "./components/Example_3";
import {Example_4} from "./components/Example_4";

export default function App() {
  return (
    <View style={styles.container}>
      <Example_4/>

      <StatusBar style="auto" />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#fff',
  },
});
