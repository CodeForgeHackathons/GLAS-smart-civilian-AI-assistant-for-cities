<script setup lang="ts">
import { computed } from 'vue'
import { useRouter } from 'vue-router'
import PublicLayout from '@/components/layout/PublicLayout.vue'
import { useAuthStore } from '@/stores/auth'

const auth = useAuthStore()
const router = useRouter()

const userName = computed(() => {
  if (!auth.user) return ''
  return `${auth.user.firstName} ${auth.user.lastName}`.trim()
})

async function handleLogout() {
  auth.logout()
  router.push('/')
}
</script>

<template>
  <PublicLayout>
    <div class="profile-card">
      <h1 class="page-title">Личный кабинет</h1>

      <div class="profile-section">
        <div class="section-title">Профиль</div>
        <div class="section-placeholder">
          <div class="profile-row">
            <span class="profile-label">Имя:</span>
            <span class="profile-value">
              {{ userName || 'Гость' }}
            </span>
          </div>
          <div class="profile-row">
            <span class="profile-label">Телефон:</span>
            <span class="profile-value">
              {{ auth.user?.phoneNumber || '—' }}
            </span>
          </div>
        </div>
      </div>

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

      <button type="button" class="logout-btn" @click="handleLogout">
        Выйти из аккаунта
      </button>
    </div>
  </PublicLayout>
</template>

<style scoped>
.profile-card {
  background: white;
  border-radius: 24px;
  padding: 32px 32px 28px;
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

.profile-row {
  display: flex;
  gap: 8px;
  font-size: 14px;
  color: #4b5563;
}

.profile-label {
  font-weight: 500;
}

.profile-value {
  word-break: break-all;
}

.logout-btn {
  margin-top: 16px;
  width: 100%;
  min-height: 44px;
  border-radius: 12px;
  border: none;
  background: #ef4444;
  color: white;
  font-size: 14px;
  font-weight: 500;
  cursor: pointer;
}

.logout-btn:hover {
  background: #dc2626;
}
</style>
