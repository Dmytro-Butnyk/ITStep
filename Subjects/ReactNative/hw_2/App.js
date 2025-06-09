import { StatusBar } from 'expo-status-bar';
import { ScrollView, View } from 'react-native';
import NewsCard from './components/NewsCard';

// Sample news data
const newsData = [
  {
    id: 1,
    title: "New Technology Breakthrough",
    description: "Scientists have made a remarkable discovery in quantum computing that could revolutionize the field.",
    imageUrl: "https://picsum.photos/800/600?random=1"
  },
  {
    id: 2,
    title: "Space Exploration Update",
    description: "NASA announces plans for the next mission to Mars, scheduled for early next year.",
    imageUrl: "https://picsum.photos/800/600?random=2"
  },
  {
    id: 3,
    title: "Environmental Innovation",
    description: "A new sustainable energy solution has been developed that could help combat climate change.",
    imageUrl: "https://picsum.photos/800/600?random=3"
  },
  {
    id: 4,
    title: "Medical Research Progress",
    description: "Researchers have made significant progress in developing new treatments for chronic diseases.",
    imageUrl: "https://picsum.photos/800/600?random=4"
  }
];

export default function App() {
  return (
    <View className="flex-1 bg-gray-100 pt-12">
      <StatusBar style="auto" />
      <ScrollView className="flex-1">
        {newsData.map(news => (
          <NewsCard
            key={news.id}
            title={news.title}
            description={news.description}
            imageUrl={news.imageUrl}
          />
        ))}
      </ScrollView>
    </View>
  );
}
