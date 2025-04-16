<template>
  <div class="product-card">
    <router-link :to="{ name: 'ClothingDetails', params: { id: product.productId } }">
      <h3>{{ product.title }}</h3>
    </router-link>
    <p>Размеры: {{ product.sizes.join(', ') }}</p>
    <p>{{ product.price }} руб.</p>
    <span v-if="isLoggedIn">
      <span v-if="!cartItem">
        <button @click="addToCart(product.productId)">Добавить в корзину</button>
      </span>
      <span v-if="cartItem" class="horizontal-controls">
        <button @click="incrementQuantity(product.productId)">+</button>
        <p>{{ cartItem.quantity }}</p>
        <button @click="decrementQuantity(product.productId)">-</button>
      </span>
    </span>
  </div>
</template>
<script setup>
import { ref, computed, onMounted } from 'vue';
import { useStore } from 'vuex';
import { useAxios } from '../composables/axios';
const store = useStore();
const axios = useAxios();
const cartItem = ref(null);
const isLoggedIn = computed(() => store.getters.isLoggedIn);
function fetchCartItems(productId) {
    axios
        .get('/CartItem/GetCartItemByProductIdAndCartId', {
            params: { productId, cartId: store.getters.getId },
        })
        .then((response) => {
            cartItem.value = response.data;
        })
        .catch((error) => console.error('Ошибка при загрузке товара:', error));
}
function addToCart(productId) {
    axios
        .post('/CartItem', {
            productId,
            cartId: store.getters.getId,
            price: product.price,
            quantity: 1,
        })
        .then(() => fetchCartItems(productId))
        .catch((error) => console.error('Ошибка при добавлении товара:', error));
}
function incrementQuantity(productId) {
    if (cartItem.value.quantity < product.quantity) {
        updateCartItemQuantity(productId, cartItem.value.quantity + 1);
    }
}
function decrementQuantity(productId) {
    if (cartItem.value.quantity > 1) {
        updateCartItemQuantity(productId, cartItem.value.quantity - 1);
    }
}
function updateCartItemQuantity(productId, quantity) {
    axios
        .put('/CartItem', {
            productId,
            cartId: store.getters.getId,
            price: product.price,
            quantity,
        })
        .then(() => fetchCartItems(productId))
        .catch((error) => console.error('Ошибка при обновлении количества:', error));
}
onMounted(() => fetchCartItems(product.productId));
</script>
<style scoped>
  .product-card {
    border: 1px solid #ccc;
    padding: 10px;
    margin: 10px;
    width: 20em;
    text-align: center;
  }
  button {
    padding: 8px 16px;
    background-color: #007bff;
    color: #fff;
    border: none;
    cursor: pointer;
  }
  .horizontal-controls {
    display: flex;
    justify-content: center;
    align-items: center;
  }
    .horizontal-controls button {
      margin: 0 10px;
    }
</style>
