<template>
  <div class="catalog-page">
    <h2>Каталог</h2>
    <div class="category-section">
      <h3>Женская одежда</h3>
      <div class="models-wrapper">
        <button class="arrow left" @click="scrollLeft('women')">←</button>
        <div class="models-container" ref="women">
          <div class="models">
            <div class="model">
              <img src="@/assets/dress.jpg" alt="Платье" />
              <p>Платье</p>
            </div>
            <div class="model">
              <img src="@/assets/skirt.jpg" alt="Юбка" />
              <p>Юбка</p>
            </div>
            <div class="model">
              <img src="@/assets/blouse.jpg" alt="Блузка" />
              <p>Блузка</p>
            </div>
            <div class="model">
              <img src="@/assets/jacket.jpg" alt="Куртка" />
              <p>Куртка</p>
            </div>
          </div>
        </div>
        <button class="arrow right" @click="scrollRight('women')">→</button>
      </div>
    </div>
    <div class="category-section">
      <h3>Мужская одежда</h3>
      <div class="models-wrapper">
        <button class="arrow left" @click="scrollLeft('men')">←</button>
        <div class="models-container" ref="men">
          <div class="models">
            <div class="model">
              <img src="@/assets/shirt.jpg" alt="Рубашка" />
              <p>Рубашка</p>
            </div>
            <div class="model">
              <img src="@/assets/jeans.jpg" alt="Джинсы" />
              <p>Джинсы</p>
            </div>
            <div class="model">
              <img src="@/assets/jacket.jpg" alt="Куртка" />
              <p>Куртка</p>
            </div>
            <div class="model">
              <img src="@/assets/coat.jpg" alt="Пальто" />
              <p>Пальто</p>
            </div>
          </div>
        </div>
        <button class="arrow right" @click="scrollRight('men')">→</button>
      </div>
    </div>
  </div>
</template>
<script>
  export default {
    methods: {
      scrollLeft(categoryRef) {
        const container = this.$refs[categoryRef];
        if (container) container.scrollBy({ left: -container.offsetWidth, behavior: "smooth" });
      },
      scrollRight(categoryRef) {
        const container = this.$refs[categoryRef];
        if (container) container.scrollBy({ left: container.offsetWidth, behavior: "smooth" });
      },
    },
  };
</script>
<style scoped>
  .catalog-page {
    padding: 20px;
  }
  h2 {
    text-align: center;
    font-size: 2rem;
    margin-bottom: 30px;
  }
  .category-section {
    margin-bottom: 40px;
  }
    .category-section h3 {
      font-size: 1.5rem;
      margin-bottom: 10px;
      text-align: center;
    }
  .models-wrapper {
    display: flex;
    align-items: center;
    position: relative;
  }
  .arrow {
    background-color: #f8d7da;
    color: white;
    border: none;
    font-size: 1.5rem;
    cursor: pointer;
    padding: 10px 15px;
    border-radius: 50%;
    transition: background-color 0.3s, transform 0.2s;
  }
    .arrow:hover {
      background-color: #e91e63;
      transform: scale(1.1);
    }
  .models-container {
    overflow: hidden;
    flex: 1;
    display: flex;
    justify-content: center;
  }
  .models {
    display: flex;
    gap: 20px;
    transition: transform 0.3s ease;
  }
  .model {
    flex: 0 0 calc(33.33% - 20px);
    max-width: calc(33.33% - 20px);
    text-align: center;
  }
    .model img {
      width: 100%;
      height: 250px;
      object-fit: contain;
      border-radius: 8px;
    }
    .model p {
      margin-top: 10px;
      font-size: 1rem;
      color: black;
    }
</style>
