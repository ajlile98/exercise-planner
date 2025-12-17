/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./Components/**/*.{razor,html,js}",
    "./Pages/**/*.{razor,html,js}",
    "./Layout/**/*.{razor,html,js}",
    "./App.razor",
    "./**/*.razor"
  ],
  theme: {
    extend: {},
  },
  plugins: [require("daisyui")],
  daisyui: {
    themes: ["light", "dark"],
  },
}
