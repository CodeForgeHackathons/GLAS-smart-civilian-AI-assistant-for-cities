<script setup lang="ts">
import PublicLayout from '@/components/layout/PublicLayout.vue'
</script>

<template>
  <PublicLayout>
    <div class="track-card">
      <h1 class="page-title">Проверить статус</h1>
      <div class="track-input-block">
        <label class="input-label">Номер обращения или ссылка</label>
        <input type="text" class="track-input" placeholder="Введите номер или вставьте ссылку" readonly />
        <button type="button" class="btn btn-primary">Проверить</button>
      </div>
      <div class="status-block">
        <div class="status-title">Получено</div>
        <div class="status-steps">
          <div class="status-item done">
            <span class="status-dot"></span>
            <span>Получено</span>
          </div>
          <div class="status-item active">
            <span class="status-dot"></span>
            <span>В работе</span>
          </div>
          <div class="status-item">
            <span class="status-dot"></span>
            <span>Рассматривается</span>
          </div>
          <div class="status-item">
            <span class="status-dot"></span>
            <span>Решено</span>
          </div>
        </div>
        <button type="button" class="btn btn-green">Сообщить еще</button>
      </div>
    </div>
  </PublicLayout>
</template>

<style scoped>
.track-card {
  background: white;
  border-radius: 24px;
  padding: 32px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.06);
}

.page-title {
  margin: 0 0 24px;
  font-size: 22px;
  font-weight: 600;
  color: #1e2a4a;
}

.track-input-block {
  margin-bottom: 32px;
}

.input-label {
  display: block;
  font-size: 14px;
  font-weight: 500;
  color: #4b5563;
  margin-bottom: 8px;
}

.track-input {
  width: 100%;
  max-width: 400px;
  min-height: 48px;
  padding: 0 16px;
  border: 1px solid #d1d5db;
  border-radius: 12px;
  font-size: 16px;
  margin-bottom: 12px;
}

.status-block {
  padding-top: 24px;
  border-top: 1px solid #e5e7eb;
}

.status-title {
  font-size: 18px;
  font-weight: 600;
  color: #1e2a4a;
  margin-bottom: 20px;
}

.status-steps {
  display: flex;
  flex-direction: column;
  gap: 16px;
  margin-bottom: 24px;
}

.status-item {
  display: flex;
  align-items: center;
  gap: 12px;
  font-size: 15px;
  color: #9ca3af;
}

.status-item.active {
  color: #16a34a;
  font-weight: 600;
}

.status-item.done {
  color: #6b7280;
}

.status-dot {
  width: 24px;
  height: 24px;
  border-radius: 50%;
  background: #e5e7eb;
}

.status-item.active .status-dot {
  background: #16a34a;
}

.status-item.done .status-dot {
  background: #9ca3af;
}

.btn {
  min-height: 48px;
  padding: 0 24px;
  border-radius: 14px;
  font-size: 16px;
  font-weight: 500;
  cursor: pointer;
  border: none;
}

.btn-primary {
  background: #2563eb;
  color: white;
}

.btn-green {
  background: #16a34a;
  color: white;
  width: 100%;
  max-width: 280px;
}
</style>
