<script setup lang="ts">
import { RouterLink } from 'vue-router'
</script>

<template>
  <nav class="bottom-nav" aria-label="Основная навигация">
    <RouterLink to="/" class="nav-item" active-class="active">
      <svg class="nav-item-icon" width="24" height="24" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
        <path d="M3 10L10 3L17 10M10 17V7" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"/>
      </svg>
      <span class="nav-item-label">Главная</span>
    </RouterLink>
    <a href="#" class="nav-item">
      <svg class="nav-item-icon" width="24" height="24" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
        <path d="M3 17L17 3M17 3H9M17 3V11" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"/>
      </svg>
      <span class="nav-item-label">Сообщить</span>
    </a>
    <a href="#" class="nav-item">
      <svg class="nav-item-icon" width="24" height="24" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
        <path d="M3 5H17M3 5L3 15C3 16.1046 3.89543 17 5 17H15C16.1046 17 17 16.1046 17 15V5M3 5L10 10L17 5" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"/>
      </svg>
      <span class="nav-item-label">Мои обращения</span>
    </a>
    <a href="#" class="nav-item">
      <svg class="nav-item-icon" width="24" height="24" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
        <path d="M7.5 10L12.5 15L17.5 10" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"/>
      </svg>
      <span class="nav-item-label">Ещё</span>
    </a>
  </nav>
</template>

<style scoped>
.bottom-nav {
  display: none;
}

@media (max-width: 768px) {
  .bottom-nav {
    display: flex;
    align-items: center;
    justify-content: space-around;
    position: fixed;
    bottom: 0;
    left: 0;
    right: 0;
    height: 56px;
    background: white;
    border-top: 1px solid #e5e7eb;
    padding: 0 8px;
    z-index: 100;
  }

  .nav-item {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    gap: 2px;
    flex: 1;
    min-width: 0;
    padding: 6px 4px;
    color: #6b7280;
    text-decoration: none;
    font-size: 11px;
    font-weight: 500;
  }

  .nav-item:hover {
    color: #2563eb;
  }

  .nav-item.active {
    color: #2563eb;
  }

  .nav-item-icon {
    width: 24px;
    height: 24px;
    flex-shrink: 0;
  }

  .nav-item-label {
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
    max-width: 100%;
  }
}
</style>
