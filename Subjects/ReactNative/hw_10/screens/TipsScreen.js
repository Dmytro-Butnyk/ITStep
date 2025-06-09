import React from 'react';
import { View, Text, StyleSheet } from 'react-native';

const tips = [
  'Відчуйте свої емоції — поділіться ними з іншими.',
  'Знайдіть натхнення — зробіть щось приємне для себе.',
  'Розслабтеся — поспілкуйтеся з друзями або порухайтеся.',
];

export default function TipsScreen() {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>Поради на день</Text>
      {tips.map((tip, i) => (
        <Text key={i} style={styles.tip}>💡 {tip}</Text>
      ))}
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, padding: 24, backgroundColor: '#fff' },
  title: { fontSize: 18, fontWeight: 'bold', marginBottom: 16 },
  tip: { fontSize: 16, marginBottom: 8 },
}); 