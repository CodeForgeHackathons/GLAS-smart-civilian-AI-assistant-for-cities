<script setup lang="ts"></script>

<template>
  <aside class="request-card">
    <div class="card-header">
      <button class="back-btn">
        <svg width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
          <path d="M12 4L6 10L12 16" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
        </svg>
      </button>
      <h2 class="card-title">Карточка обращения</h2>
    </div>
    <div class="card-body">
      <h3 class="issue-title">Свалка мусора</h3>
      <div class="card-row">
        <span class="card-label">Дата:</span>
        <span class="card-value">12 апреля 2022</span>
      </div>
      <div class="card-row">
        <span class="card-label">Адрес:</span>
        <span class="card-value">ул. Несская, 15</span>
      </div>
      <p class="card-description">
        Свалка мусора. Проблема зафиксирована, принята в работу. Просим указать новую дату вывоза.
      </p>
      <div class="card-image-placeholder">
        <span class="image-placeholder-text">Фото</span>
      </div>
      <div class="card-actions">
        <button type="button" class="action-btn">Назначить</button>
        <button type="button" class="action-btn">Изменить статус</button>
        <button type="button" class="action-btn">Запросить информацию</button>
      </div>
      <div class="dialogue-block">
        <div class="dialogue-title">История диалога</div>
        <div class="dialogue-placeholder">Сообщения с гражданином (если не аноним)</div>
      </div>
      <button type="button" class="close-btn">Закрыть</button>
    </div>
  </aside>
</template>

<style scoped>
.request-card {
  background: white;
  border-radius: 16px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.06);
  display: flex;
  flex-direction: column;
  overflow: hidden;
}

.card-header {
  display: flex;
  align-items: center;
  gap: 12px;
  padding: 16px 20px;
  border-bottom: 1px solid #e5e7eb;
}

.back-btn {
  width: 36px;
  height: 36px;
  border: none;
  background: #f3f4f6;
  border-radius: 10px;
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
  color: #4b5563;
}

.back-btn:hover {
  background: #e5e7eb;
}

.card-title {
  margin: 0;
  font-size: 16px;
  font-weight: 600;
  color: #1e2a4a;
}

.card-body {
  padding: 20px;
  flex: 1;
  overflow-y: auto;
}

.issue-title {
  margin: 0 0 16px;
  font-size: 18px;
  font-weight: 600;
  color: #1e2a4a;
}

.card-row {
  margin-bottom: 12px;
  font-size: 14px;
}

.card-label {
  color: #6b7280;
  margin-right: 6px;
}

.card-value {
  color: #1e2a4a;
}

.card-description {
  margin: 16px 0;
  font-size: 14px;
  color: #4b5563;
  line-height: 1.5;
}

.card-image-placeholder {
  width: 100%;
  height: 180px;
  background: #f3f4f6;
  border-radius: 12px;
  display: flex;
  align-items: center;
  justify-content: center;
  margin-bottom: 20px;
}

.image-placeholder-text {
  font-size: 14px;
  color: #9ca3af;
}

.card-actions {
  display: flex;
  flex-direction: column;
  gap: 8px;
  margin-bottom: 20px;
}

.action-btn {
  width: 100%;
  padding: 12px 16px;
  background: #f3f4f6;
  border: 1px solid #e5e7eb;
  border-radius: 10px;
  font-size: 14px;
  font-weight: 500;
  color: #1e2a4a;
  cursor: pointer;
}

.action-btn:hover {
  background: #e5e7eb;
}

.dialogue-block {
  margin-bottom: 20px;
  padding: 16px;
  background: #f9fafb;
  border-radius: 12px;
  border: 1px solid #e5e7eb;
}

.dialogue-title {
  font-size: 14px;
  font-weight: 600;
  color: #1e2a4a;
  margin-bottom: 8px;
}

.dialogue-placeholder {
  font-size: 13px;
  color: #9ca3af;
}

.close-btn {
  width: 100%;
  padding: 14px;
  background: #2563eb;
  color: white;
  border: none;
  border-radius: 12px;
  font-size: 15px;
  font-weight: 500;
  cursor: pointer;
}

.close-btn:hover {
  background: #1d4ed8;
}
</style>
