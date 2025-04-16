<template>
  <div class="cart-page">
    <h2>Корзина</h2>
    <br>
    <div v-if="cartItems.length === 0" class="empty-cart">
      <p>Ваша корзина пуста.</p>
    </div>
    <div v-else>
      <div v-for="item in cartItems" :key="item.productId" class="cart-item">
        <div class="item-details">
          <p class="item-title">{{ item.product.title }}</p>
          <p class="item-price">{{ item.price }} руб.</p>
          <p class="item-quantity">Количество: {{ item.quantity }}</p>
        </div>
        <div class="item-actions">
          <button class="quantity-button" @click="incrementQuantity(item)">+</button>
          <button class="quantity-button" @click="decrementQuantity(item)">-</button>
          <button class="remove-button" @click="removeItem(item.productId)">Удалить</button>
        </div>
      </div>
      <div class="cart-summary">
        <p>Общая стоимость: <span class="total-price">{{ total }} руб.</span></p>
        <div class="center">
          <button class="primary-button" @click="buy">Оформить заказ</button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
  export default {
    data() {
      return {
        cartItems: []
      };
    },
    created() {
      this.fetchCartItems();
    },
    computed: {
      total() {
        return this.cartItems.reduce((acc, item) => acc + item.price * item.quantity, 0);
      }
    },
    methods: {
      async fetchCartItems() {
        try {
          const id = this.$store.getters.getId;
          const response = await this.$axios.get('/CartItem/GetCartItemsByCartId', {
            params: { cartId: id }
          });
          this.cartItems = response.data;
        } catch (error) {
          console.error('Ошибка при загрузке товаров в корзине:', error);
        }
      },
      async removeItem(itemId) {
        try {
          const id = this.$store.getters.getId;
          await this.$axios.delete('/CartItem', {
            params: { productId: itemId, cartId: id }
          });
          this.fetchCartItems();
        } catch (error) {
          console.error('Ошибка при удалении товара из корзины:', error);
        }
      },
      async buy() {
        try {
          this.$router.push('/orders');
        } catch (error) {
          console.error('Ошибка при оформлении заказа:', error);
        }
      },
      incrementQuantity(item) {
        if (item.quantity < item.product.quantity) {
          this.updateCartItemQuantity(item, item.quantity + 1);
        }
      },
      decrementQuantity(item) {
        if (item.quantity > 1) {
          this.updateCartItemQuantity(item, item.quantity - 1);
        }
      },
      async updateCartItemQuantity(item, quantity) {
        try {
          await this.$axios.put('/CartItem', {
            productId: item.productId,
            cartId: this.$store.getters.getId,
            price: item.product.price,
            quantity: quantity
          });
          this.fetchCartItems();
        } catch (error) {
          console.error('Ошибка при обновлении количества товара:', error);
        }
      }
    }
  };
</script>
<style scoped>
  .cart-page {
    max-width: 800px;
    margin: 0 auto;
    padding: 20px;
    background-color: #f9f9f9;
    border-radius: 8px;
    box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
  }
  .cart-item {
    display: flex;
    justify-content: space-between;
    align-items: center;
    border-bottom: 1px solid #ccc;
    padding: 10px 0;
  }
  .item-details {
    flex: 1;
  }
  .item-title {
    font-size: 16px;
    font-weight: bold;
  }
  .item-price,
  .item-quantity {
    font-size: 14px;
    margin: 5px 0;
  }
  .item-actions {
    display: flex;
    gap: 10px;
  }
  .quantity-button,
  .remove-button,
  .primary-button {
    padding: 8px 16px;
    border: none;
    border-radius: 4px;
    cursor: pointer;
    transition: background-color 0.3s ease, color 0.3s ease;
  }
  .quantity-button {
    background-color: transparent;
    color: #000;
    border: 2px solid #000;
  }
    .quantity-button:hover {
      background-color: #d85a7b;
      color: #fff;
    }
  .remove-button {
    background-color: #ffc0cb;
    color: #000;
  }
    .remove-button:hover {
      background-color: #d85a7b;
      color: #fff;
    }
  .primary-button {
    background-color: #ffc0cb;
    color: #000;
  }
    .primary-button:hover {
      background-color: #d85a7b;
      color: #fff;
    }
  .total-price {
    font-weight: bold;
  }
  .center {
    text-align: center;
  }
</style>
