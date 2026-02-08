<script setup lang="ts">
import { RouterLink } from 'vue-router'
</script>

<template>
  <header class="admin-header">
    <div class="header-left">
      <RouterLink to="/" class="back-home" aria-label="На главную">
        <svg width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
          <path d="M12 4L6 10L12 16" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
        </svg>
        <span class="back-home-text">Главная</span>
      </RouterLink>
      <svg class="play-icon" width="16" height="16" viewBox="0 0 16 16" fill="none" xmlns="http://www.w3.org/2000/svg">
        <path d="M4 3L12 8L4 13V3Z" fill="currentColor"/>
      </svg>
      <h1 class="header-title">Дашборд администратора</h1>
    </div>
    <div class="header-tabs">
      <span class="tab tab-new">
        <span class="tab-badge">1</span>
        Новые
      </span>
      <span class="tab tab-progress">
        <span class="tab-badge">1</span>
        В работе
      </span>
      <span class="tab tab-urgent">
        <span class="tab-badge">5</span>
        Срочные
      </span>
      <span class="tab tab-attention">
        <span class="tab-badge">1</span>
        Требуют внимания
      </span>
      <span class="tab tab-mine">
        <span class="tab-badge">0</span>
        Назначенные мне
      </span>
    </div>
    <div class="header-right">
      <button class="icon-btn dark"></button>
      <button class="icon-btn light"></button>
      <button class="icon-btn profile"></button>
    </div>
  </header>
</template>

<style scoped>
.admin-header {
  display: flex;
  align-items: center;
  justify-content: space-between;
  gap: 24px;
  padding: 12px 24px;
  background: #2563eb;
  color: white;
  flex-shrink: 0;
}

.header-left {
  display: flex;
  align-items: center;
  gap: 10px;
}

.back-home {
  display: flex;
  align-items: center;
  gap: 6px;
  color: white;
  text-decoration: none;
  font-size: 14px;
  opacity: 0.9;
  padding: 6px 10px;
  border-radius: 8px;
  margin-right: 4px;
}

.back-home:hover {
  background: rgba(255, 255, 255, 0.15);
  opacity: 1;
}

.back-home-text {
  display: none;
}

@media (min-width: 600px) {
  .back-home-text {
    display: inline;
  }
}

.play-icon {
  width: 16px;
  height: 16px;
  opacity: 0.9;
}

.header-title {
  margin: 0;
  font-size: 18px;
  font-weight: 600;
}

.header-tabs {
  display: flex;
  align-items: center;
  gap: 8px;
}

.tab {
  display: inline-flex;
  align-items: center;
  gap: 6px;
  padding: 6px 12px;
  border-radius: 20px;
  font-size: 13px;
  font-weight: 500;
}

.tab-badge {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  min-width: 20px;
  height: 20px;
  padding: 0 5px;
  border-radius: 50%;
  background: rgba(255, 255, 255, 0.3);
  font-size: 12px;
}

.tab-new {
  background: rgba(255, 255, 255, 0.2);
}

.tab-progress {
  background: #16a34a;
}

.tab-urgent {
  background: #dc2626;
}

.tab-attention {
  background: #0ea5e9;
}

.tab-mine {
  background: #8b5cf6;
}

.header-right {
  display: flex;
  align-items: center;
  gap: 8px;
}

.icon-btn {
  width: 32px;
  height: 32px;
  border-radius: 50%;
  border: none;
  cursor: pointer;
}

.icon-btn.dark {
  background: #1e3a8a;
}

.icon-btn.light {
  background: #93c5fd;
}

.icon-btn.profile {
  background: rgba(255, 255, 255, 0.3);
}
</style>
