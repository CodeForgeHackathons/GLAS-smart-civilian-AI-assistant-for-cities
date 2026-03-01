<script setup lang="ts">
import { ref } from 'vue'
import { useRouter, useRoute } from 'vue-router'
import HomeTopBar from '@/components/home/HomeTopBar.vue'
import { useAuthStore } from '@/stores/auth'
import { logger } from '@/utils/logger'

const phoneNumber = ref('')
const password = ref('')
const isSubmitting = ref(false)
const error = ref('')

const router = useRouter()
const route = useRoute()
const auth = useAuthStore()

async function handleSubmit() {
  if (isSubmitting.value) return

  error.value = ''
  isSubmitting.value = true

  try {
    logger.log('login:submit', { phoneNumber: phoneNumber.value })
    await auth.login(phoneNumber.value.trim(), password.value)

    const redirect = (route.query.redirect as string) || '/profile'
    logger.log('login:redirect', { redirect })
    router.push(redirect)
  } catch (err) {
    const message = err instanceof Error ? err.message : 'Не удалось войти'
    logger.error('login:error', { phoneNumber: phoneNumber.value, message })
    error.value = message
  } finally {
    isSubmitting.value = false
  }
}
</script>

<template>
  <div class="login-page">
    <HomeTopBar />
    <div class="login-wrap">
      <div class="login-card">
        <h1 class="login-title">Вход</h1>
        <form class="login-form" @submit.prevent="handleSubmit">
          <div class="login-field">
            <label class="input-label">Телефон</label>
            <input
              v-model="phoneNumber"
              type="tel"
              class="input"
              placeholder="+7 900 000 00 00"
              autocomplete="tel"
            />
          </div>
          <div class="login-field">
            <label class="input-label">Пароль</label>
            <input
              v-model="password"
              type="password"
              class="input"
              placeholder="Введите пароль"
              autocomplete="current-password"
            />
          </div>

          <p v-if="error" class="error-text">
            {{ error }}
          </p>

          <button type="submit" class="btn btn-primary" :disabled="isSubmitting">
            {{ isSubmitting ? 'Входим...' : 'Войти' }}
          </button>
        </form>

        <div class="login-footer">
          <span>Нет аккаунта?</span>
          <a href="#">Зарегистрироваться</a>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.login-page {
  min-height: 100vh;
  background: #f4f7fb;
  display: flex;
  flex-direction: column;
}

.login-wrap {
  flex: 1;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 24px;
}

.login-card {
  width: 100%;
  max-width: 400px;
  background: white;
  border-radius: 24px;
  padding: 32px 32px 28px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.06);
}

.login-title {
  margin: 0 0 24px;
  font-size: 22px;
  font-weight: 600;
  color: #1e2a4a;
}

.login-form {
  display: flex;
  flex-direction: column;
}

.login-field {
  margin-bottom: 20px;
}

.input-label {
  display: block;
  font-size: 14px;
  font-weight: 500;
  color: #4b5563;
  margin-bottom: 8px;
}

.input {
  width: 100%;
  min-height: 48px;
  padding: 0 16px;
  border: 1px solid #d1d5db;
  border-radius: 12px;
  font-size: 16px;
  box-sizing: border-box;
}

.btn {
  width: 100%;
  min-height: 48px;
  border-radius: 14px;
  font-size: 16px;
  font-weight: 500;
  cursor: pointer;
  border: none;
  margin-bottom: 16px;
}

.btn-primary {
  background: #2563eb;
  color: white;
}

.btn-primary:disabled {
  opacity: 0.7;
  cursor: default;
}

.error-text {
  margin: 0 0 12px;
  font-size: 14px;
  color: #dc2626;
}

.login-footer {
  font-size: 14px;
  color: #6b7280;
}

.login-footer a {
  color: #2563eb;
  margin-left: 4px;
}
</style>
