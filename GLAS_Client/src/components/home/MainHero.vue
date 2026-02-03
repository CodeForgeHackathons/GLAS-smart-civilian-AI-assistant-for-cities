<script setup lang="ts">
import HeroBanner from '@/components/home/HeroBanner.vue'
import HeroActions from '@/components/home/HeroActions.vue'
</script>

<template>
<main class="hero">
  <div class="hero-header">
    <h2>Экран пользователя</h2>
  </div>
  <div class="hero-content">
    <div class="hero-illustration">
      <div class="illustration-placeholder">
        <svg width="100%" height="100%" viewBox="0 0 600 400" fill="none" xmlns="http://www.w3.org/2000/svg">
          <rect width="600" height="400" fill="#E3F2FD"/>
          <rect y="250" width="600" height="150" fill="#4CAF50"/>
          <circle cx="100" cy="200" r="40" fill="#2E7D32"/>
          <rect x="95" y="200" width="10" height="50" fill="#5D4037"/>
          <circle cx="200" cy="180" r="35" fill="#2E7D32"/>
          <rect x="197" y="180" width="8" height="70" fill="#5D4037"/>
          <circle cx="450" cy="190" r="45" fill="#2E7D32"/>
          <rect x="447" y="190" width="8" height="60" fill="#5D4037"/>
          <rect y="280" width="600" height="80" fill="#757575"/>
          <rect y="315" width="600" height="4" fill="#FFC107"/>
          <rect x="300" y="100" width="80" height="150" fill="#90CAF9"/>
          <rect x="320" y="120" width="20" height="20" fill="#FFC107"/>
          <rect x="360" y="140" width="20" height="20" fill="#FFC107"/>
          <rect x="500" y="80" width="70" height="170" fill="#BBDEFB"/>
          <rect x="520" y="100" width="15" height="15" fill="#FFC107"/>
          <rect x="550" y="130" width="15" height="15" fill="#FFC107"/>
          <circle cx="250" cy="240" r="8" fill="#FFB74D"/>
          <rect x="245" y="248" width="10" height="20" fill="#2196F3"/>
          <circle cx="280" cy="240" r="8" fill="#FFB74D"/>
          <rect x="275" y="248" width="10" height="20" fill="#E91E63"/>
          <rect x="320" y="260" width="60" height="8" fill="#8D6E63"/>
          <rect x="325" y="268" width="8" height="15" fill="#6D4C41"/>
          <rect x="347" y="268" width="8" height="15" fill="#6D4C41"/>
        </svg>
      </div>
    </div>
    <HeroBanner />
    <HeroActions />
    <div class="pagination-dots">
      <span class="dot active"></span>
      <span class="dot"></span>
      <span class="dot"></span>
      <span class="dot"></span>
      <span class="dot"></span>
    </div>
  </div>
</main>
</template>

<style scoped>
.hero {
  display: flex;
  flex-direction: column;
  width: 100%;
}

.hero-header {
  background: linear-gradient(180deg, #E3F2FD, #BBDEFB);
  padding: 16px 24px;
  border-radius: 16px 16px 0 0;
  margin-bottom: 0;
}

.hero-header h2 {
  font-size: 18px;
  font-weight: 600;
  color: #1e2a4a;
  margin: 0;
}

.hero-content {
  background: white;
  border-radius: 0 0 24px 24px;
  padding: 32px 48px 24px;
  box-shadow: 0 20px 40px rgba(20, 40, 120, 0.08);
  display: flex;
  flex-direction: column;
}

.hero-illustration {
  width: 100%;
  height: 320px;
  margin-bottom: 32px;
  border-radius: 16px;
  overflow: hidden;
  background: linear-gradient(135deg, #E3F2FD 0%, #BBDEFB 100%);
}

.illustration-placeholder {
  width: 100%;
  height: 100%;
}

.pagination-dots {
  display: flex;
  justify-content: center;
  gap: 8px;
  margin-top: 24px;
  padding-top: 24px;
}

.dot {
  width: 8px;
  height: 8px;
  border-radius: 50%;
  background: #E0E0E0;
  cursor: pointer;
  transition: all 0.2s;
}

.dot.active {
  background: #1e2a4a;
  width: 24px;
  border-radius: 4px;
}
</style>
