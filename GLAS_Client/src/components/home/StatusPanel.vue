<script setup lang="ts">

</script>

<template>
<aside class="status">
  <div class="status-header">
    <h3>Получено</h3>
  </div>
  <div class="status-content">
    <div class="status-tracker">
      <div class="status-item active">
        <div class="status-circle">
          <svg width="16" height="16" viewBox="0 0 16 16" fill="none" xmlns="http://www.w3.org/2000/svg">
            <path d="M13 4L6 11L3 8" stroke="white" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
          </svg>
        </div>
        <div class="status-info">
          <div class="status-name">В работе</div>
          <div class="status-time">Вчера, 12:20</div>
          <div class="status-tag">13:22</div>
        </div>
      </div>
      <div class="status-item">
        <div class="status-circle empty"></div>
        <div class="status-info">
          <div class="status-name">Рассматривается</div>
        </div>
      </div>
      <div class="status-item">
        <div class="status-circle empty"></div>
        <div class="status-info">
          <div class="status-name">Решено</div>
        </div>
      </div>
    </div>

    <div class="performer-section">
      <div class="performer-label">Исполнитель:</div>
      <div class="performer-info">
        <div class="performer-icon"></div>
        <span class="performer-name">ООО "Чистый город"</span>
      </div>
      <div class="performer-description">
        Паспортизация и уборка территории, очистка от снега и наледи
      </div>
    </div>

    <button class="more-btn">
      <span>Сообщите еще</span>
      <svg width="16" height="16" viewBox="0 0 16 16" fill="none" xmlns="http://www.w3.org/2000/svg">
        <path d="M6 4L10 8L6 12" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
      </svg>
    </button>
  </div>
</aside>
</template>

<style scoped>
.status {
  background: white;
  border-radius: 24px;
  overflow: hidden;
  box-shadow: 0 20px 40px rgba(20, 40, 120, 0.08);
  display: flex;
  flex-direction: column;
  min-height: 100%;
}

.status-header {
  background: #1e2a4a;
  padding: 20px 24px;
}

.status-header h3 {
  margin: 0;
  color: white;
  font-size: 18px;
  font-weight: 600;
}

.status-content {
  padding: 24px;
  display: flex;
  flex-direction: column;
  flex: 1;
}

.status-tracker {
  display: flex;
  flex-direction: column;
  gap: 20px;
  margin-bottom: 32px;
}

.status-item {
  display: flex;
  align-items: flex-start;
  gap: 12px;
}

.status-circle {
  width: 24px;
  height: 24px;
  border-radius: 50%;
  background: #1f9d55;
  display: flex;
  align-items: center;
  justify-content: center;
  flex-shrink: 0;
  margin-top: 2px;
}

.status-circle.empty {
  background: transparent;
  border: 2px solid #E0E0E0;
}

.status-info {
  flex: 1;
}

.status-name {
  font-size: 15px;
  font-weight: 500;
  color: #1e2a4a;
  margin-bottom: 4px;
}

.status-item.active .status-name {
  color: #1f9d55;
  font-weight: 600;
}

.status-time {
  font-size: 13px;
  color: #9aa4bf;
  margin-bottom: 6px;
}

.status-tag {
  display: inline-block;
  background: #ff6b35;
  color: white;
  padding: 4px 8px;
  border-radius: 4px;
  font-size: 12px;
  font-weight: 500;
}

.performer-section {
  margin-bottom: 24px;
  padding-top: 24px;
  border-top: 1px solid #E0E0E0;
}

.performer-label {
  font-size: 13px;
  color: #9aa4bf;
  margin-bottom: 8px;
}

.performer-info {
  display: flex;
  align-items: center;
  gap: 8px;
  margin-bottom: 12px;
}

.performer-icon {
  width: 20px;
  height: 20px;
  border-radius: 50%;
  background: #1f9d55;
  flex-shrink: 0;
}

.performer-name {
  font-size: 15px;
  font-weight: 500;
  color: #1f9d55;
}

.performer-description {
  font-size: 13px;
  color: #5b6b8c;
  line-height: 1.5;
}

.more-btn {
  margin-top: auto;
  width: 100%;
  padding: 14px;
  border-radius: 14px;
  background: #1f9d55;
  color: white;
  border: none;
  font-size: 15px;
  font-weight: 500;
  cursor: pointer;
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 8px;
  transition: all 0.2s;
}

.more-btn:hover {
  background: #1a8a4a;
  box-shadow: 0 4px 12px rgba(31, 157, 85, 0.3);
}
</style>
