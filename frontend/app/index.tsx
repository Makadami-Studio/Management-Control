import { Animated, Text, View, TouchableOpacity, Image } from "react-native";
import { SafeAreaView } from "react-native-safe-area-context";
import { useRouter } from "expo-router";
import { useEffect, useRef } from "react";

export default function Index() {
  const router = useRouter();

  const upslideAnim = useRef(new Animated.Value(-100)).current; //up slide ref
  const downslideAnim = useRef(new Animated.Value(100)).current; //down slide ref
  const fadeAnim = useRef(new Animated.Value(0)).current; //fade-in ref

  // animacje na wejscie
  useEffect(() => {
    Animated.parallel([
      //upslide
      Animated.timing(upslideAnim, {
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
      //Downslide
      Animated.timing(downslideAnim, {
        toValue: 0,
        duration: 800,
        useNativeDriver: true,
      }),
    ]).start();
  }, []);

  return (
    //caly ekran
    <SafeAreaView className="flex-auto bg-white">
      {/* Main view */}

      <View className="items-center justify-start flex-1 mt-10">
        <Animated.View
          /* slide w Y            fade-in (opacity) */
          style={{
            transform: [{ translateY: downslideAnim }],
            opacity: fadeAnim,
          }}
        >
          <Text className="text-4xl font-bold text-third drop-shadow-2xl ite">
            Welcome To the
          </Text>
        </Animated.View>
        <Animated.View
          /* slide w Y            fade-in (opacity) */
          style={{
            transform: [{ translateY: upslideAnim }],
            opacity: fadeAnim,
          }}
        >
          {/* Text jako logo ;D */}
          <Text className="text-4xl font-bold text-secondary drop-shadow-2xl">
            Management Control
          </Text>
        </Animated.View>
      </View>
      <View className="items-center justify-start flex-1 gap-5 ">
        <TouchableOpacity
          className="flex-row items-center justify-center w-80 h-14"
          onPress={() => {
            router.push("/(auth)/main"); //narazie przerzuca testowo do maina pozdro #do zmiany :3
          }}
        >
          <View className="flex-row items-center justify-center flex-shrink gap-1 py-4 text-base border w-80 border-third rounded-3xl">
            <Image
              source={require("..//assets/images/google.png")}
              className="w-8 h-8 mr-2"
              resizeMode="contain"
            />
            <Text className="text-base whitespace-nowrap">
              Sign in with Google
            </Text>
          </View>
        </TouchableOpacity>
        <TouchableOpacity
          className="flex-row items-center justify-center w-80 h-14 "
          onPress={() => {
            router.push("/(dashboard)/main"); //narazie przerzuca testowo do maina pozdro #do zmiany :3
          }}
        >
          <View className="flex-row items-center justify-center gap-1 py-4 text-base border w-80 border-third rounded-3xl ">
            <Image
              source={require("..//assets/images/facebook.png")}
              className="w-8 h-8 mr-2"
              resizeMode="contain"
            />
            <Text className="text-base whitespace-nowrap">
              Sign in with Facebook
            </Text>
          </View>
        </TouchableOpacity>
        {/* View dla buttonow */}
        <View className="items-center justify-start flex-1 ">
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
