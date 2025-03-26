/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./app/**/*.{js,jsx,ts,tsx}"],
  presets: [require("nativewind/preset")],
  theme: {
    extend: {
      colors: {
        primary: "#EBE9E9",
        secondary: "#925E78",
        third: "#A11E1E",
        buttonOne: "#549E65",
        buttonTwo: "#258EA6",
      },
    },
  },
  plugins: [],
};
