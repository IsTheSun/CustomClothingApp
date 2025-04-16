<template>
  <main>
    <section class="header-content">
      <figure class="header-img">
        <img src="@/assets/banner.jpg" alt="Индивидуальный пошив" />
      </figure>
      <div class="header-description container">
        <p class="header-title">Индивидуальный пошив одежды</p>
        <p>
          Добро пожаловать! Здесь вы можете создать одежду своей мечты.
          Выберите стиль, ткань и параметры, а мы позаботимся об остальном!
        </p>
        <button class="ghost-button" v-if="!isLoggedIn">
          <router-link to="/register">Начать</router-link>
        </button>
        <button class="ghost-button" v-if="isLoggedIn">
          <router-link to="/categories">Выбрать модель</router-link>
        </button>
      </div>
    </section>
  </main>
</template>
<script>
  export default {
    computed: {
      isLoggedIn() {
        return this.$store.getters.isLoggedIn;
      },
    },
  };
</script>
<style scoped>
  .header-content {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-top: 20px;
  }
  .header-img img {
    width: 100%;
    max-width: 500px;
    height: auto;
  }
  .header-description {
    max-width: 600px;
    padding-left: 20px;
  }
  .header-title {
    font-size: 24px;
    font-weight: bold;
    color: black;
  }
  .header-description p {
    color: black;
  }
  .ghost-button {
    border: 2px solid var(--gray-color);
    font-size: 1rem;
    padding: 0.5em 1.5em;
    min-width: 9em;
    color: black;
    background: transparent;
    cursor: pointer;
    transition: all 0.3s ease-in-out;
    text-align: center;
    text-decoration: none;
  }
    .ghost-button:hover {
      background: #f9c8d9;
      color: white;
      border-color: #f9c8d9;
    }
    .ghost-button router-link {
      color: black;
      text-decoration: none;
    }
    .ghost-button:hover router-link {
      color: white;
    }
  .type-button {
    padding: 10px 20px;
    background-color: #5a9;
    color: white;
    border: none;
    cursor: pointer;
    margin-top: 10px;
  }
    .type-button:hover {
      background-color: #4c8;
    }
</style>
