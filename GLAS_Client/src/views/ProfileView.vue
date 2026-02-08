<script setup lang="ts">
import PublicLayout from '@/components/layout/PublicLayout.vue'
</script>

<template>
  <PublicLayout>
    <div class="profile-card">
      <h1 class="page-title">Личный кабинет</h1>
      <div class="profile-section">
        <div class="section-title">Мои обращения</div>
        <div class="section-placeholder">Список обращений со статусами</div>
      </div>
      <div class="profile-section">
        <div class="section-title">Настройки уведомлений</div>
        <div class="section-placeholder">SMS, Email, Push — переключатели</div>
      </div>
      <div class="profile-section">
        <div class="section-title">Язык интерфейса</div>
        <div class="section-placeholder">Выбор языка</div>
      </div>
      <div class="profile-section">
        <div class="section-title">Справка и помощь</div>
        <div class="section-placeholder">Ссылки на инструкции</div>
      </div>
    </div>
  </PublicLayout>
</template>

<style scoped>
.profile-card {
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

.profile-section {
  margin-bottom: 24px;
}

.profile-section:last-child {
  margin-bottom: 0;
}

.section-title {
  font-size: 16px;
  font-weight: 600;
  color: #1e2a4a;
  margin-bottom: 8px;
}

.section-placeholder {
  min-height: 60px;
  background: #f9fafb;
  border: 2px dashed #d1d5db;
  border-radius: 12px;
  display: flex;
  align-items: center;
  padding: 0 16px;
  color: #9ca3af;
  font-size: 14px;
}
</style>
