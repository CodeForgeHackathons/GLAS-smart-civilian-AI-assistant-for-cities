<script setup lang="ts">
import { RouterLink } from 'vue-router'
</script>

<template>
<div class="actions">
  <RouterLink to="/report" class="btn primary">
    <svg class="button-icon" width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
      <path d="M6 4L14 10L6 16V4Z" fill="currentColor"/>
    </svg>
    <span>Сообщить о проблеме</span>
  </RouterLink>
  <RouterLink to="/track" class="btn secondary">
    <svg class="button-icon" width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
      <path d="M5 7L10 12L15 7" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
    </svg>
    <span>Проверить статус</span>
  </RouterLink>
</div>
</template>

<style scoped>
.actions {
  display: flex;
  gap: 16px;
}
.btn {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 8px;
  min-height: 48px;
  padding: 16px 28px;
  border-radius: 14px;
  font-size: 16px;
  font-weight: 500;
  cursor: pointer;
  transition: all 0.2s;
  border: none;
  text-decoration: none;
}

@media (max-width: 768px) {
  .btn {
    min-height: 56px;
  }
}

.primary {
  background: #2f6bff;
  color: white;
  box-shadow: 0 10px 20px rgba(47, 107, 255, 0.3);
}

.primary:hover {
  background: #2563eb;
  box-shadow: 0 12px 24px rgba(47, 107, 255, 0.4);
}

.secondary {
  background: #ff6b35;
  color: white;
  box-shadow: 0 10px 20px rgba(255, 107, 53, 0.3);
}

.secondary:hover {
  background: #ff5722;
  box-shadow: 0 12px 24px rgba(255, 107, 53, 0.4);
}

.button-icon {
  width: 20px;
  height: 20px;
  flex-shrink: 0;
}
</style>
