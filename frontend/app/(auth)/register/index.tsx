import { useState } from "react";
import { View, Text, TextInput, TouchableOpacity } from "react-native";
import { SafeAreaView } from "react-native-safe-area-context";
import { useRouter } from "expo-router";
import { registerUser } from "@/API/authAPI";

const Register = () => {
  const router = useRouter();

  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  return (
    <SafeAreaView className="flex-1 px-6 pt-10 bg-white">
      <View className="items-center justify-center flex-1 gap-6">
        <Text className="text-3xl font-bold text-center text-gray-800">
          Create an account
        </Text>

        <View className="w-2/3 gap-4">
          <TextInput
            value={name}
            onChangeText={setName}
            placeholder="Name"
            className="px-4 py-3 text-base border border-gray-300 rounded-lg"
          />
          <TextInput
            value={email}
            onChangeText={setEmail}
            placeholder="Email"
            keyboardType="email-address"
            autoCapitalize="none"
            className="px-4 py-3 text-base border border-gray-300 rounded-lg"
          />
          <TextInput
            value={password}
            onChangeText={setPassword}
            placeholder="Password"
            secureTextEntry
            className="px-4 py-3 text-base border border-gray-300 rounded-lg"
          />
        </View>

        <TouchableOpacity
          className="w-2/3 py-4 bg-buttonTwo rounded-xl"
          onPress={async () => {
            try {
              const res = await registerUser(name, email, password);
              console.log("Zarejestrowano:", res.data);
              // Możesz od razu przenieść użytkownika dalej:
              router.push("/(auth)/login");
            } catch (err) {
              console.error("Błąd rejestracji:", err);
            }
          }}
        >
          <Text className="text-lg font-semibold text-center text-white">
            Register now!
          </Text>
        </TouchableOpacity>

        <TouchableOpacity
          onPress={() => {
            router.push("/(auth)/login");
          }}
        >
          <Text className="text-center text-gray-500">
            Already have an account?{" "}
            <Text className="text-buttonTwo">Log in!</Text>
          </Text>
        </TouchableOpacity>
      </View>
    </SafeAreaView>
  );
};

export default Register;
