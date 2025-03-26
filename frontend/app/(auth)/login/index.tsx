import { StyleSheet, View, Text, TextInput, TouchableOpacity } from "react-native";
import { SafeAreaView } from "react-native-safe-area-context";
import {useRouter} from "expo-router";
import {useState} from "react";
import {registerUser} from "@/API/authAPI";

const Index = () => {
  const router = useRouter();

  const [emailorname, setEmailorName] = useState("");
  const [password, setPassword] = useState("");
    return (
        <SafeAreaView className="flex-1 px-6 pt-10 bg-white">
            <View className="items-center justify-center flex-1 gap-6">
                <Text className="text-3xl font-bold text-center text-gray-800">
                    Login In
                </Text>

                <View className="w-2/3 gap-4">
                    <TextInput
                        value={emailorname}
                        onChangeText={setEmailorName}
                        placeholder="Username or Email"
                        keyboardType={emailorname.includes("@") ? "email-address" : "default"}
                        autoCapitalize="none"
                        className="px-4 py-3 text-base border border-gray-300 rounded-lg"
                    />
                    <TextInput
                        value={password}
                        onChangeText={setPassword}
                        placeholder="Password"
                        secureTextEntry
                        className="px-4 py-3 text-base border border-gray-300 rounded-lg"
                        autoCapitalize="none"
                    />
                </View>
                <TouchableOpacity
                    className="w-2/3 py-4 bg-buttonOne rounded-xl"
                    onPress={async () => {
                            router.push("/(auth)/main");// logujesz się ale narazie bez sprawdzenia co i jak bo nwm jak to zrobić mati ratuj
                        }}
                    >
                    <Text className="text-lg font-semibold text-center text-white">
                        Login now!
                    </Text>
                </TouchableOpacity>
                <TouchableOpacity
                    onPress={() => {
                        router.push("/(auth)/register");
                    }}
                >
                    <Text className="text-center text-gray-500">
                        Don't have an accound??{" "}
                        <Text className="text-buttonTwo">Register in!</Text>
                    </Text>
                </TouchableOpacity>
            </View>
    </SafeAreaView>
  );
};

const styles = StyleSheet.create({});

export default Index;
