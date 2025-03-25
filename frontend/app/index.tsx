import { Text, View, TouchableOpacity, Image } from "react-native";
import { SafeAreaView } from "react-native-safe-area-context";
import { useRouter } from "expo-router";

export default function Index() {
  const router = useRouter();
  return (
    <SafeAreaView className="flex-1 bg-white">
      <View className="items-center justify-center flex-1">
        <Text className="text-4xl font-bold text-gray-800 drop-shadow-2xl">
          Management Control
        </Text>
        <View className="flex flex-row gap-6 pt-8">
          <TouchableOpacity
            onPress={() => {
              router.push("/(auth)/login");
            }}
            className="px-6 py-3 mt-4 bg-buttonOne rounded-xl"
          >
            <Text className="text-lg font-semibold text-white">Login</Text>
          </TouchableOpacity>
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
      <Image
        source={require("@/assets/images/workTogether.png")}
        className="absolute bottom-0 self-center w-64 h-64"
        resizeMode="contain"
      />
    </SafeAreaView>
  );
}
