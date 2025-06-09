import { StatusBar } from 'expo-status-bar';
import { StyleSheet, View } from 'react-native';
import Test_2 from "./test_2";


export default function App() {
  return (
    <View style={styles.container}>
      <StatusBar />
      <Test_2 />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});