<script setup lang="ts"></script>

<template>
  <aside class="sidebar">
    <div class="header">
      <div class="header-title">
        <svg class="header-icon" width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
          <path d="M2 10L6 6L9 9L13 5L18 10M18 10V16H2V10H18Z" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"/>
        </svg>
        <span>ГЛАС</span>
      </div>
    </div>

    <nav>
      <a class="active">
        <svg class="nav-icon" width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
          <path d="M3 10L10 3L17 10M10 17V7" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"/>
        </svg>
        <span>Главная</span>
      </a>
      <a>
        <svg class="nav-icon" width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
          <path d="M3 17L17 3M17 3H9M17 3V11" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"/>
        </svg>
        <span>Сообщить о проблеме</span>
      </a>
      <a>
        <svg class="nav-icon" width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
          <path d="M3 5H17M3 5L3 15C3 16.1046 3.89543 17 5 17H15C16.1046 17 17 16.1046 17 15V5M3 5L10 10L17 5" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"/>
        </svg>
        <span>Мои обращения</span>
      </a>
      <a>
        <svg class="nav-icon" width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
          <path d="M10 10C12.7614 10 15 7.76142 15 5C15 2.23858 12.7614 0 10 0C7.23858 0 5 2.23858 5 5C5 7.76142 7.23858 10 10 10Z" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"/>
          <path d="M2.5 20C2.5 15.5817 6.08172 12 10.5 12C14.9183 12 18.5 15.5817 18.5 20" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"/>
        </svg>
        <span>Администрировать</span>
      </a>
      <div class="spacer"></div>
      <a>
        <svg class="nav-icon" width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
          <path d="M7.5 10L12.5 15L17.5 10" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"/>
        </svg>
        <span>Ещё</span>
      </a>
    </nav>

    <div class="city-silhouette">
      <svg width="100%" height="80" viewBox="0 0 200 80" fill="none" xmlns="http://www.w3.org/2000/svg" preserveAspectRatio="none">
        <rect x="20" y="50" width="15" height="30" fill="rgba(255,255,255,0.3)"/>
        <rect x="40" y="40" width="15" height="40" fill="rgba(255,255,255,0.3)"/>
        <rect x="60" y="45" width="15" height="35" fill="rgba(255,255,255,0.3)"/>
        <rect x="80" y="35" width="15" height="45" fill="rgba(255,255,255,0.3)"/>
        <rect x="100" y="50" width="15" height="30" fill="rgba(255,255,255,0.3)"/>
        <rect x="120" y="42" width="15" height="38" fill="rgba(255,255,255,0.3)"/>
        <rect x="140" y="38" width="15" height="42" fill="rgba(255,255,255,0.3)"/>
        <rect x="160" y="48" width="15" height="32" fill="rgba(255,255,255,0.3)"/>
      </svg>
    </div>
  </aside>
</template>

<style scoped>
.sidebar {
  background: linear-gradient(180deg, #1e3a8a, #2563eb);
  border-radius: 20px;
  color: white;
  padding: 24px;
  display: flex;
  flex-direction: column;
  min-height: 100%;
}

.header {
  margin-bottom: 32px;
}

.header-title {
  display: flex;
  align-items: center;
  gap: 10px;
  font-size: 16px;
  font-weight: 600;
}

.header-icon {
  width: 20px;
  height: 20px;
  opacity: 0.9;
}

.logo {
  font-size: 18px;
  font-weight: 700;
  margin-bottom: 32px;
}

nav {
  display: flex;
  flex-direction: column;
  gap: 4px;
  flex: 1;
}

nav a {
  display: flex;
  align-items: center;
  gap: 12px;
  height: 44px;
  padding: 0 16px;
  border-radius: 12px;
  font-size: 15px;
  opacity: 0.85;
  cursor: pointer;
  transition: all 0.2s;
}

nav a:hover {
  background: rgba(255, 255, 255, 0.15);
  opacity: 1;
}

nav a.active {
  background: rgba(255, 255, 255, 0.25);
  font-weight: 600;
  opacity: 1;
}

.nav-icon {
  width: 20px;
  height: 20px;
  flex-shrink: 0;
}

.spacer {
  flex: 1;
}

.city-silhouette {
  margin-top: auto;
  padding-top: 20px;
  opacity: 0.4;
}
</style>
