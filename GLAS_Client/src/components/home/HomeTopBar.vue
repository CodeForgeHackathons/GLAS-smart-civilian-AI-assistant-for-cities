<script setup lang="ts"></script>

<template>
  <header class="top-bar">
    <div class="top-bar-inner">
      <span class="top-bar-logo">ГЛАС</span>
      <div class="lang-switcher">
        <button type="button" class="lang-btn active" aria-label="Русский">RU</button>
        <button type="button" class="lang-btn" aria-label="English">EN</button>
      </div>
    </div>
  </header>
</template>

<style scoped>
.top-bar {
  background: white;
  border-bottom: 1px solid #e5e7eb;
  padding: 12px 24px;
}

.top-bar-inner {
  max-width: 1600px;
  margin: 0 auto;
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.top-bar-logo {
  font-size: 18px;
  font-weight: 700;
  color: #1e2a4a;
}

.lang-switcher {
  display: flex;
  gap: 4px;
}

.lang-btn {
  min-width: 40px;
  height: 36px;
  padding: 0 12px;
  border: 1px solid #d1d5db;
  border-radius: 8px;
  background: white;
  font-size: 14px;
  font-weight: 500;
  color: #4b5563;
  cursor: pointer;
}

.lang-btn:hover {
  background: #f9fafb;
  border-color: #2563eb;
  color: #2563eb;
}

.lang-btn.active {
  background: #2563eb;
  border-color: #2563eb;
  color: white;
}
</style>
