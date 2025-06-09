import React, { useState, useRef, useEffect } from 'react';
import {
  View,
  Text,
  StyleSheet,
  FlatList,
  Dimensions,
  TouchableOpacity,
  Animated,
} from 'react-native';
import Frame1 from '../../assets/Frame 1.svg';
import Frame2 from '../../assets/Frame 2.svg';
import Frame3 from '../../assets/Frame 3.svg';

const { width, height } = Dimensions.get('window');

const slides = [
  {
    id: '1',
    title: 'Quick & Easy Booking',
    description: 'Book your taxi with just a few taps. Fast, reliable, and convenient service at your fingertips.',
    SvgImage: Frame1,
  },
  {
    id: '2',
    title: 'Track Your Ride',
    description: 'Follow your driver in real-time and share your trip details with loved ones for added safety.',
    SvgImage: Frame2,
  },
  {
    id: '3',
    title: 'Safe & Comfortable',
    description: 'All our drivers are verified and vehicles regularly maintained for your comfort and safety.',
    SvgImage: Frame3,
  },
];

const OnboardingScreen = ({ navigation }) => {
  const [currentIndex, setCurrentIndex] = useState(0);
  const flatListRef = useRef(null);
  const scrollX = useRef(new Animated.Value(0)).current;

  useEffect(() => {
    const timer = setInterval(() => {
      if (currentIndex < slides.length - 1) {
        flatListRef.current?.scrollToIndex({
          index: currentIndex + 1,
          animated: true,
        });
      } else {
        flatListRef.current?.scrollToIndex({
          index: 0,
          animated: true,
        });
      }
    }, 3000);

    return () => clearInterval(timer);
  }, [currentIndex]);

  const renderItem = ({ item }) => {
    const SvgImage = item.SvgImage;
    return (
      <View style={styles.slide}>
        <View style={styles.imageContainer}>
          <SvgImage style={styles.image} />
        </View>
        <View style={styles.textContainer}>
          <Text style={styles.title}>{item.title}</Text>
          <Text style={styles.description}>{item.description}</Text>
        </View>
      </View>
    );
  };

  const renderDots = () => {
    return slides.map((_, index) => {
      const dotWidth = scrollX.interpolate({
        inputRange: [(index - 1) * width, index * width, (index + 1) * width],
        outputRange: [8, 16, 8],
        extrapolate: 'clamp',
      });

      const dotOpacity = scrollX.interpolate({
        inputRange: [(index - 1) * width, index * width, (index + 1) * width],
        outputRange: [0.4, 1, 0.4],
        extrapolate: 'clamp',
      });

      return (
        <Animated.View
          key={index.toString()}
          style={[
            styles.dot,
            {
              width: dotWidth,
              opacity: dotOpacity,
            },
          ]}
        />
      );
    });
  };

  const onViewableItemsChanged = useRef(({ viewableItems }) => {
    if (viewableItems[0]) {
      setCurrentIndex(viewableItems[0].index);
    }
  }).current;

  return (
    <View style={styles.container}>
      <FlatList
        ref={flatListRef}
        data={slides}
        renderItem={renderItem}
        horizontal
        pagingEnabled
        showsHorizontalScrollIndicator={false}
        onScroll={Animated.event(
          [{ nativeEvent: { contentOffset: { x: scrollX } } }],
          { useNativeDriver: false }
        )}
        onViewableItemsChanged={onViewableItemsChanged}
        viewabilityConfig={{ itemVisiblePercentThreshold: 50 }}
        keyExtractor={(item) => item.id}
      />
      <View style={styles.dotsContainer}>{renderDots()}</View>
      <TouchableOpacity
        style={styles.skipButton}
        onPress={() => {
          // Navigate to main app
          console.log('Skip pressed');
        }}
      >
        <Text style={styles.skipText}>Skip</Text>
      </TouchableOpacity>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
  },
  slide: {
    width,
    height,
    alignItems: 'center',
    justifyContent: 'center',
    padding: 20,
  },
  imageContainer: {
    flex: 0.6,
    justifyContent: 'center',
    alignItems: 'center',
    width: width * 0.8,
  },
  image: {
    width: '100%',
    height: '100%',
  },
  textContainer: {
    flex: 0.4,
    alignItems: 'center',
  },
  title: {
    fontSize: 24,
    fontWeight: 'bold',
    color: '#333',
    marginBottom: 10,
    textAlign: 'center',
  },
  description: {
    fontSize: 16,
    color: '#666',
    textAlign: 'center',
    paddingHorizontal: 20,
  },
  dotsContainer: {
    flexDirection: 'row',
    position: 'absolute',
    bottom: 100,
    alignSelf: 'center',
  },
  dot: {
    height: 8,
    borderRadius: 4,
    backgroundColor: '#FFD700',
    marginHorizontal: 4,
  },
  skipButton: {
    position: 'absolute',
    bottom: 50,
    right: 20,
    padding: 10,
  },
  skipText: {
    fontSize: 16,
    color: '#333',
    fontWeight: '600',
  },
});

export default OnboardingScreen; 