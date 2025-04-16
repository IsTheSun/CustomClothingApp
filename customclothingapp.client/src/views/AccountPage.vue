<template>
  <div class="account-page">
    <h2>Личный кабинет</h2>
    <div v-if="user">
      <p><strong>Имя:</strong> {{ user.name }}</p>
      <p><strong>Email:</strong> {{ user.email }}</p>
      <p><strong>Адрес доставки:</strong> {{ user.address }}</p>
    </div>
    <h3>История заказов</h3>
    <div v-if="orders.length === 0">
      <p>У вас пока нет заказов.</p>
    </div>
    <div v-else>
      <div v-for="order in orders" :key="order.id" class="order-item">
        <p><strong>Номер заказа:</strong> {{ order.id }}</p>
        <p><strong>Сумма:</strong> {{ order.total }} руб.</p>
        <p><strong>Статус:</strong> {{ order.status }}</p>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      user: null,
      orders: [],
    };
  },
  async created() {
    try {
      const userId = this.$store.getters.getId;
      const userResponse = await this.$axios.get(`/Customer/${userId}`);
      this.user = userResponse.data;

      const ordersResponse = await this.$axios.get(`/Orders/${userId}`);
      this.orders = ordersResponse.data;
    } catch (error) {
      console.error("Ошибка загрузки данных:", error);
    }
  },
};
</script>
<style scoped>
  .account-page {
    max-width: 600px;
    margin: 0 auto;
  }
  .order-item {
    border-bottom: 1px solid #ccc;
    padding: 10px 0;
  }
</style>
