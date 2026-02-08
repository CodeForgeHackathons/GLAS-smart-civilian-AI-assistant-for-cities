<script setup lang="ts"></script>

<template>
  <main class="map-panel">
    <div class="map-area">
      <div class="map-placeholder">
        <svg width="100%" height="100%" viewBox="0 0 400 280" fill="none" xmlns="http://www.w3.org/2000/svg">
          <rect width="400" height="280" fill="#f0f9ff"/>
          <path d="M50 80 L120 80 L120 160 L50 160 Z" stroke="#cbd5e1" stroke-width="1" fill="none"/>
          <path d="M130 60 L200 60 L200 140 L130 140 Z" stroke="#cbd5e1" stroke-width="1" fill="none"/>
          <path d="M210 100 L280 100 L280 200 L210 200 Z" stroke="#cbd5e1" stroke-width="1" fill="none"/>
          <path d="M290 70 L360 70 L360 170 L290 170 Z" stroke="#cbd5e1" stroke-width="1" fill="none"/>
          <circle cx="85" cy="120" r="8" fill="#2563eb"/>
          <circle cx="165" cy="100" r="8" fill="#16a34a"/>
          <circle cx="245" cy="150" r="8" fill="#dc2626"/>
          <circle cx="325" cy="120" r="8" fill="#eab308"/>
        </svg>
      </div>
    </div>
    <div class="summary-area">
      <div class="summary-row">
        <span class="summary-label">1 Новые</span>
        <span class="summary-value">2 зарегистрировано</span>
      </div>
      <div class="summary-row">
        <span class="summary-label">2 В работе</span>
        <span class="summary-value">1 зарегистрировано</span>
      </div>
      <div class="summary-row">
        <span class="summary-label">5 Срочные</span>
        <span class="summary-value">5 зарегистрировано</span>
      </div>
      <div class="summary-row">
        <span class="summary-label">1 Требуют внимания</span>
        <span class="summary-value">11 зарегистрировано</span>
      </div>
      <button class="more-tasks-btn">
        <svg class="mic-icon" width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
          <path d="M10 12C11.6569 12 13 10.6569 13 9V4C13 2.34315 11.6569 1 10 1C8.34315 1 7 2.34315 7 4V9C7 10.6569 8.34315 12 10 12Z" stroke="currentColor" stroke-width="1.5"/>
          <path d="M4 9V10C4 13.3137 6.68629 16 10 16C13.3137 16 16 13.3137 16 10V9" stroke="currentColor" stroke-width="1.5" stroke-linecap="round"/>
          <path d="M10 16V19M10 19H7M10 19H13" stroke="currentColor" stroke-width="1.5" stroke-linecap="round"/>
        </svg>
        <span>← Ещё задания ...</span>
        <span class="more-count">11</span>
      </button>
    </div>
  </main>
</template>

<style scoped>
.map-panel {
  display: flex;
  flex-direction: column;
  flex: 1;
  min-height: 0;
  background: white;
  border-radius: 16px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.06);
  overflow: hidden;
}

.map-area {
  flex: 1;
  min-height: 240px;
}

.map-placeholder {
  width: 100%;
  height: 100%;
  min-height: 240px;
}

.summary-area {
  padding: 20px 24px;
  border-top: 1px solid #e5e7eb;
}

.summary-row {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 8px 0;
  font-size: 14px;
}

.summary-label {
  color: #4b5563;
  font-weight: 500;
}

.summary-value {
  color: #6b7280;
}

.more-tasks-btn {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 10px;
  width: 100%;
  margin-top: 16px;
  padding: 14px 20px;
  background: #2563eb;
  color: white;
  border: none;
  border-radius: 12px;
  font-size: 15px;
  font-weight: 500;
  cursor: pointer;
}

.more-tasks-btn:hover {
  background: #1d4ed8;
}

.mic-icon {
  width: 20px;
  height: 20px;
  flex-shrink: 0;
}

.more-count {
  margin-left: 4px;
  opacity: 0.9;
}
</style>
