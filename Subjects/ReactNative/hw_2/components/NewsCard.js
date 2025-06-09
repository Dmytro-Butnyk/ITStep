import React from 'react';
import { View, Text, Image, TouchableOpacity } from 'react-native';

const NewsCard = ({ title, description, imageUrl }) => {
  return (
    <View className="bg-white rounded-lg shadow-md m-2 overflow-hidden">
      <Image
        source={{ uri: imageUrl }}
        className="w-full h-48"
        resizeMode="cover"
      />
      <View className="p-4">
        <Text className="text-xl font-bold mb-2 text-gray-800">{title}</Text>
        <Text className="text-gray-600 mb-4">{description}</Text>
        <TouchableOpacity className="bg-blue-500 py-2 px-4 rounded-lg">
          <Text className="text-white text-center font-semibold">Read More</Text>
        </TouchableOpacity>
      </View>
    </View>
  );
};

export default NewsCard; 