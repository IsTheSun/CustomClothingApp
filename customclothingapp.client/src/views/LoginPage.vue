<template>
  <div class="login-page">
    <h2>Вход</h2>
    <br>
    <form @submit.prevent="login">
      <div class="form-group">
        <label for="email">Email:</label>
        <input type="email" id="email" v-model="email" required>
      </div>
      <div class="form-group">
        <label for="password">Пароль:</label>
        <input type="password" id="password" v-model="password" required>
      </div>
      <div class="center">
        <button class="login-button" type="submit">Войти</button>
      </div>
    </form>
    <br><br>
    <div class="center">
      <p>Еще не зарегистрированы?</p>
      <button class="type-button">
        <router-link to="/register">Регистрация</router-link>
      </button>
    </div>
  </div>
</template>
<script>
  export default {
    data() {
      return {
        email: '',
        password: ''
      };
    },
    methods: {
      async login() {
        try {
          const response = await this.$axios.post('/api/auth/login', {
            email: this.email,
            password: this.password
          });
          this.$store.dispatch('login', {
            token: response.data.token,
            id: response.data.userId,
            role: response.data.role
          });
          this.$router.push('/');
        } catch (error) {
          console.error('Ошибка при входе:', error.response?.data?.message || error.message);
          alert('Не удалось войти. Проверьте данные или попробуйте позже.');
        }
      }
    }
  };
</script>
<style scoped>
  .login-page {
    max-width: 400px;
    margin: 0 auto;
    padding: 20px;
    background-color: #f9f9f9;
    border-radius: 8px;
    box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
  }
  .form-group {
    margin-bottom: 15px;
  }
  label {
    display: block;
    font-weight: bold;
    margin-bottom: 5px;
  }
  input[type="email"],
  input[type="password"] {
    width: 100%;
    padding: 8px;
    font-size: 16px;
    border: 1px solid #ccc;
    border-radius: 4px;
  }
  .login-button {
    padding: 10px 20px;
    background-color: #ffc0cb;
    color: #000;
    border: none;
    border-radius: 4px;
    cursor: pointer;
    transition: background-color 0.3s ease, color 0.3s ease;
  }
    .login-button:hover {
      background-color: #d85a7b;
      color: #fff;
    }
  .type-button {
    padding: 8px 16px;
    background-color: transparent;
    color: #000;
    border: 2px solid #000;
    border-radius: 4px;
    cursor: pointer;
    transition: background-color 0.3s ease, color 0.3s ease;
  }
    .type-button:hover {
      background-color: #d85a7b;
      color: #fff;
    }
    .type-button a {
      text-decoration: none;
      color: inherit;
    }
  .center {
    text-align: center;
  }
</style>

