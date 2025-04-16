<template>
  <header>
    <nav class="header-nav container flex-container">
      <h1 class="logo">
        <router-link class="logo-link" to="/home">CustomClothing</router-link>
      </h1>
      <ul class="header-menu flex-container">
        <li><router-link class="header-menu-link" to="/catalog">Каталог</router-link></li>
        <li><router-link class="header-menu-link" to="/designer">Конструктор</router-link></li>
      </ul>
      <router-link to="/cart">
        <button class="ghost-button">Корзина</button>
      </router-link>
      <router-link v-if="!isLoggedIn" class="header-menu-link" to="/login">Вход</router-link>
      <span v-if="isLoggedIn">
        | <a @click="logout">Выход</a>
      </span>
      <span v-if="isAdmin">
        <router-link class="header-menu-link" to="/admin">Админ</router-link>
      </span>
    </nav>
  </header>
</template>
<script setup>
  import { computed } from 'vue';
  import { useStore } from 'vuex';
  import { useRouter } from 'vue-router';
  const store = useStore();
  const router = useRouter();
  const isLoggedIn = computed(() => store.getters.isLoggedIn);
  const isAdmin = computed(() => store.getters.isAdmin);
  function logout() {
    store.dispatch('logout').then(() => {
      router.push('/login');
    });
  }
</script>
<style scoped>
  @import '../assets/headerStyle.css';
</style>
