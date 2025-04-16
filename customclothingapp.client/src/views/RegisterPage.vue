<template>
  <div class="register-page">
    <h2>Регистрация</h2>
    <br>
    <form @submit.prevent="register">
      <div class="form-group">
        <label for="username">Имя пользователя:</label>
        <input type="text" id="username" v-model="username" required />
      </div>
      <div class="form-group">
        <label for="email">Email:</label>
        <input type="email" id="email" v-model="email" required />
      </div>
      <div class="form-group">
        <label for="phone">Телефон:</label>
        <input type="tel" id="phone" v-model="phone" required />
      </div>
      <div class="form-group">
        <label for="password">Пароль:</label>
        <input type="password" id="password" v-model="password" required />
      </div>
      <div class="center">
        <button class="register-button" type="submit">Зарегистрироваться</button>
      </div>
    </form>
    <br><br>
    <div class="center">
      <p>Уже есть аккаунт?</p>
      <button class="type-button">
        <router-link to="/login">Войти</router-link>
      </button>
    </div>
  </div>
</template>
<script>
  export default {
    data() {
      return {
        username: "",
        email: "",
        phone: "",
        password: "",
      };
    },
    methods: {
      async register() {
        try {
          await this.$axios.post("/api/Users", {
            username: this.username,
            email: this.email,
            phone: this.phone,
            passwordHash: this.password,
            userrole: "Customer",
          });
          this.$router.push("/login");
        } catch (error) {
          console.error("Ошибка при регистрации:", error.response?.data?.message || error.message);
          alert("Не удалось зарегистрироваться. Проверьте данные или попробуйте позже.");
        }
      },
    },
  };
</script>
<style scoped>
  .register-page {
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
  input[type="text"],
  input[type="email"],
  input[type="tel"],
  input[type="password"] {
    width: 100%;
    padding: 8px;
    font-size: 16px;
    border: 1px solid #ccc;
    border-radius: 4px;
  }
  .register-button {
    padding: 10px 20px;
    background-color: #ffc0cb;
    color: #000;
    border: none;
    border-radius: 4px;
    cursor: pointer;
    transition: background-color 0.3s ease, color 0.3s ease;
  }
    .register-button:hover {
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

