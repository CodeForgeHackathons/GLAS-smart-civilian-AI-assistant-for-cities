<script setup lang="ts">
import PublicLayout from '@/components/layout/PublicLayout.vue'
</script>

<template>
  <PublicLayout>
    <div class="report-card">
      <h1 class="page-title">Сообщить о проблеме</h1>
      <div class="steps">
        <span class="step active">1</span>
        <span class="step-line"></span>
        <span class="step">2</span>
        <span class="step-line"></span>
        <span class="step">3</span>
        <span class="step-line"></span>
        <span class="step">4</span>
      </div>
      <div class="step-label">Что случилось?</div>
      <div class="step-placeholder">
        Сетка категорий (иконки) + микрофон
      </div>
      <div class="report-actions">
        <button type="button" class="btn btn-secondary">Назад</button>
        <button type="button" class="btn btn-primary">Далее</button>
      </div>
    </div>
  </PublicLayout>
</template>

<style scoped>
.report-card {
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

.steps {
  display: flex;
  align-items: center;
  gap: 8px;
  margin-bottom: 32px;
}

.step {
  width: 36px;
  height: 36px;
  border-radius: 50%;
  background: #e5e7eb;
  color: #6b7280;
  display: flex;
  align-items: center;
  justify-content: center;
  font-weight: 600;
  font-size: 14px;
}

.step.active {
  background: #2563eb;
  color: white;
}

.step-line {
  flex: 1;
  max-width: 60px;
  height: 2px;
  background: #e5e7eb;
}

.step-label {
  font-size: 16px;
  font-weight: 500;
  color: #1e2a4a;
  margin-bottom: 16px;
}

.step-placeholder {
  min-height: 200px;
  background: #f9fafb;
  border: 2px dashed #d1d5db;
  border-radius: 16px;
  display: flex;
  align-items: center;
  justify-content: center;
  color: #9ca3af;
  font-size: 14px;
  margin-bottom: 24px;
}

.report-actions {
  display: flex;
  gap: 16px;
  justify-content: flex-end;
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

.btn-secondary {
  background: #f3f4f6;
  color: #4b5563;
}
</style>
