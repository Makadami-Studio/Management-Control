import axios from "axios";
/* import { EXPO_PUBLIC_API_URL } from "@env";
 */

interface LoginResponse {
  token: string;
}

const API = axios.create({
  baseURL: "http://10.0.2.2:3000/api/v1", //url dla androida
});

console.log(API);

export const registerUser = (name: string, email: string, password: string) => {
  return API.post(
    "/auth/register",
    { name, email, password },
    {
      headers: {
        "Content-Type": "application/json",
      },
    }
  );
};

export const loginUser = (email: string, password: string) => {
  return API.post<LoginResponse>("/auth/login", { email, password });
};
