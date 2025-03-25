import { Animated, Text, View, TouchableOpacity, Image } from "react-native";
import { SafeAreaView } from "react-native-safe-area-context";
import { useRouter } from "expo-router";
import { useEffect, useRef } from "react";

export default function Index() {
  const router = useRouter();

  const slideAnim = useRef(new Animated.Value(-100)).current; //slide ref
  const fadeAnim = useRef(new Animated.Value(0)).current; //fade-in ref

  // animacje na wejscie
  useEffect(() => {
    Animated.parallel([
      //slide
      Animated.timing(slideAnim, {
        toValue: 0,
        duration: 800,
        useNativeDriver: true,
      }),
      //fade-in
      Animated.timing(fadeAnim, {
        toValue: 1,
        duration: 1000,
        useNativeDriver: true,
      }),
    ]).start();
  }, []);

  return (
    //caly ekran
    <SafeAreaView className="flex-1 bg-white">
      {/* Main view */}
      <View className="items-center justify-center flex-1">
        <Animated.View
          /* slide w Y            fade-in (opacity) */
          style={{ transform: [{ translateY: slideAnim }], opacity: fadeAnim }}
        >
          {/* Text jako logo ;D */}
          <Text className="text-4xl font-bold text-secondary drop-shadow-2xl">
            Management Control
          </Text>
        </Animated.View>
        {/* View dla buttonow */}
        <View className="flex flex-row gap-6 pt-8">
          {/* Login btn */}
          <TouchableOpacity
            onPress={() => {
              router.push("/(auth)/login");
            }}
            className="px-6 py-3 mt-4 bg-buttonOne rounded-xl"
          >
            <Text className="text-lg font-semibold text-white">Login</Text>
          </TouchableOpacity>
          {/* Register btn */}
          <TouchableOpacity
            onPress={() => {
              router.push("/(auth)/register");
            }}
            className="px-6 py-3 mt-4 bg-buttonTwo rounded-xl"
          >
            <Text className="text-lg font-semibold text-white">Register</Text>
          </TouchableOpacity>
        </View>
      </View>
      {/* Obrazek jakis spoko ;D */}
      <Image
        source={require("..//assets/images/workTogether.png")}
        className="absolute bottom-0 self-center w-64 h-64"
        resizeMode="contain"
      />
    </SafeAreaView>
  );
}
