import './assets/headerStyle.css';
import { createApp } from 'vue';
import App from './App.vue';
import axios from 'axios';
import router from './router';
import { createStore } from 'vuex';

// Настройка базового URL для axios
axios.defaults.baseURL = 'https://localhost:7166/api';

// Создание Vuex-хранилища
export const store = createStore({
  state: {
    isAuthenticated: false, // Статус авторизации
    token: null, // Токен пользователя
    id: null, // ID пользователя
  },
  mutations: {
    // Устанавливаем состояние авторизации
    setAuthentication(state, payload) {
      state.isAuthenticated = payload.isAuthenticated;
      state.token = payload.token;
      state.id = payload.id;
    },
  },
  actions: {
    // Авторизация: сохраняем токен в хранилище и localStorage
    login({ commit }, { token, id }) {
      localStorage.setItem('token', token); // Сохраняем токен
      commit('setAuthentication', { isAuthenticated: true, token, id });
    },
    // Выход: очищаем токен из хранилища и localStorage
    logout({ commit }) {
      localStorage.removeItem('token'); // Удаляем токен
      commit('setAuthentication', { isAuthenticated: false, token: null, id: null });
    },
  },
  getters: {
    isLoggedIn: (state) => !!state.token, // Проверка авторизации
    authStatus: (state) => state.isAuthenticated, // Статус авторизации
    getId: (state) => state.id, // Получение ID пользователя
    isAdmin: (state) => state.id === 'CM000000', // Проверка прав администратора
  },
});

// Инициализация приложения
const app = createApp(App);

// Автоматическая проверка токена при загрузке
const token = localStorage.getItem('token');
if (token) {
  store.commit('setAuthentication', { isAuthenticated: true, token, id: null }); // Добавьте здесь реальный ID, если нужно
}

// Добавление axios в глобальные свойства
app.config.globalProperties.$https = axios;
app.config.globalProperties.$axios = axios;

// Подключение Vuex и роутера
app.use(store);
app.use(router);

// Монтирование приложения
app.mount('#app');
