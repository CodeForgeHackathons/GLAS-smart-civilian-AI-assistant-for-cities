<script setup lang="ts">
</script>

<template>
<div class="actions">
  <button class="primary">Сообщить о проблеме</button>
  <button class="secondary">Проверить статус</button>
</div>
</template>

<style scoped>
.actions {
  display: flex;
  gap: 20px;
}
button{
  padding: 16px 28px;
  border-radius: 14px;
  font-size: 16px;
  font-weight: 500;
  cursor: pointer;
}

.primary{
  background: #2f6bff;
  color: white;
  border: none;
  box-shadow: 0 10px 20px rgba(47, 107, 255, 0.3);
}
.secondary{
  background: white;
  color: #2f6bff;
  border: 2px solid #2f6bff;
}
</style>
