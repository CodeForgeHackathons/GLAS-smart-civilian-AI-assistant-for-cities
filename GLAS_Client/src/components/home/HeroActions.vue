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
  gap: 16px;
  margin-top: 20px;
}
button{
  padding: 14px 24px;
  border-radius: 12px;
  font-size: 16px;
  border: none;
  cursor: pointer;
}

.primary{
  background: #2f6bff;
  color: white;
}
.secondary{
  background: white;
  color: #2f6bff;
  border: 2px solid #2f6bff;
}
</style>
