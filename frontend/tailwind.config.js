/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./app/**/*.{js,jsx,ts,tsx}"],
  presets: [require("nativewind/preset")],
  theme: {
    extend: {
      colors: {
        primary: "#EBE9E9",
        buttonOne: "#549E65",
        buttonTwo: "#258EA6",
      },
    },
  },
  plugins: [],
};
