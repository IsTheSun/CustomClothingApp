<template>
  <div class="designer-page">
    <h2>Конструктор модели</h2>
    <div class="designer-container">
      <div class="designer-left">
        <div class="designer-left-column">
          <div class="designer-section">
            <label for="model-select">Выберите модель:</label>
            <select id="model-select" v-model="selectedModel">
              <option v-for="model in models" :key="model.id" :value="model.name">
                {{ model.name }}
              </option>
            </select>
          </div>
          <div class="designer-section">
            <label for="color-select">Выберите цвет:</label>
            <input type="color" id="color-select" v-model="selectedColor" />
          </div>
          <div class="designer-section">
            <label for="extra">Дополнительные параметры:</label>
            <textarea id="extra" v-model="extraParams" placeholder="Например: длина рукава, тип ткани"></textarea>
          </div>
        </div>
        <div class="designer-right-column">
          <div class="measurements-table">
            <div class="measurements-single-column">
              <div class="designer-section">
                <label for="height">Рост:</label>
                <input type="number" id="height" v-model="measurements.height" placeholder="Ваш рост" />
              </div>
              <div class="designer-section">
                <label for="chest">Грудь:</label>
                <input type="number" id="chest" v-model="measurements.chest" placeholder="Обхват груди" />
              </div>
              <div class="designer-section">
                <label for="waist">Талия:</label>
                <input type="number" id="waist" v-model="measurements.waist" placeholder="Обхват талии" />
              </div>
              <div class="designer-section">
                <label for="hip">Бедра:</label>
                <input type="number" id="hip" v-model="measurements.hip" placeholder="Обхват бедер" />
              </div>
              <div class="designer-section">
                <label for="other">Другие параметры:</label>
                <textarea id="other" v-model="measurements.other" placeholder="Прочие параметры"></textarea>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="designer-right">
        <h3>Предпросмотр:</h3>
        <div class="preview">
          <div class="preview-model">
            <div class="image-container">
              <img :src="getPreviewImage" alt="Предпросмотр модели" />
            </div>
          </div>
          <p>Модель: {{ selectedModel }}</p>
          <p>Цвет: <span :style="{ backgroundColor: selectedColor }" class="color-box"></span></p>
          <p>Дополнительно: {{ extraParams || 'Не указано' }}</p>
          <p>
            Мерки:
            Рост: {{ measurements.height || 'Не указано' }},
            Грудь: {{ measurements.chest || 'Не указано' }},
            Талия: {{ measurements.waist || 'Не указано' }},
            Бедра: {{ measurements.hip || 'Не указано' }},
            Прочие: {{ measurements.other || 'Не указано' }}
          </p>
        </div>
      </div>
    </div>
    <button class="submit-button" @click="addToCart">Добавить в корзину</button>
  </div>
</template>
<script>
  export default {
    data() {
      return {
        models: [
          { id: 1, name: "Платье", preview: "./assets/dress.jpg" },
          { id: 2, name: "Куртка", preview: "./assets/jacket.jpg" },
          { id: 3, name: "Рубашка", preview: "./assets/shirt.jpg" },
        ],
        selectedModel: "Платье",
        selectedColor: "#ff0000", // По умолчанию красный цвет
        extraParams: "",
        measurements: {
          height: null,
          chest: null,
          waist: null,
          hip: null,
          other: "",
        },
      };
    },
    computed: {
      getPreviewImage() {
        const model = this.models.find((m) => m.name === this.selectedModel);
        return model ? model.preview : "";
      },
    },
    methods: {
      saveMeasurements() {
        const userId = this.$store.getters.getId;
        if (!userId) {
          alert("Необходимо войти в систему, чтобы сохранить мерки.");
          return;
        }
        const data = {
          userId: userId,
          height: this.measurements.height,
          chest: this.measurements.chest,
          waist: this.measurements.waist,
          hip: this.measurements.hip,
          othermeasurements: this.measurements.other,
        };
        this.$axios.post("/Measurements/Save", data)
          .then(() => {
            alert("Мерки успешно сохранены!");
          })
          .catch((error) => {
            console.error("Ошибка при сохранении мерок:", error);
          });
      },
      addToCart() {
        alert(
          `Модель "${this.selectedModel}" добавлена в корзину!\nЦвет: ${this.selectedColor}\nДополнительно: ${this.extraParams || "Не указано"
          }\nМерки: ${this.measurements.height ? `Рост: ${this.measurements.height}, Грудь: ${this.measurements.chest}` : "Не выбраны"}`
        );
      },
    },
  };
</script>
<style scoped>
  .designer-page {
    padding: 20px;
    max-width: 1000px;
    margin: 0 auto;
    display: flex;
    flex-direction: column;
    gap: 30px;
  }
  h2 {
    text-align: center;
    margin-bottom: 20px;
  }
  .designer-container {
    display: flex;
    justify-content: space-between;
    flex-wrap: wrap;
  }
  .designer-left,
  .designer-right {
    width: 48%;
  }
  .designer-left {
    display: flex;
    gap: 20px;
  }
  .designer-left-column,
  .designer-right-column {
    width: 50%;
  }
  .designer-section {
    margin-bottom: 8px;
  }
  label {
    display: block;
    margin-bottom: 2px;
    font-weight: bold;
  }
  select,
  textarea,
  input[type="color"],
  input[type="number"] {
    width: 100%;
    padding: 8px;
    border: 1px solid #ddd;
    border-radius: 5px;
    margin-bottom: 8px;
  }
  textarea {
    resize: none;
  }
  .measurements-table {
    display: block;
  }
  .measurements-single-column {
    display: flex;
    flex-direction: column;
    gap: 15px;
  }
  .preview-section {
    margin-top: 20px;
    border-top: 1px solid #ddd;
    padding-top: 20px;
  }
  .preview {
    text-align: center;
  }
    .preview img {
      max-width: 100%;
      height: auto;
      margin: 0 auto 10px;
    }
  .image-container {
    width: 200px;
    height: 250px;
    border: 5px solid black;
    padding: 10px;
    display: inline-block;
    overflow: hidden;
  }
  .color-box {
    display: inline-block;
    width: 20px;
    height: 20px;
    border: 1px solid #ddd;
    vertical-align: middle;
  }
  .submit-button {
    display: block;
    width: 100%;
    padding: 10px;
    background-color: #e91e63;
    color: white;
    font-size: 1rem;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    transition: background-color 0.3s;
  }
    .submit-button:hover {
      background-color: #c2185b;
    }
</style>
