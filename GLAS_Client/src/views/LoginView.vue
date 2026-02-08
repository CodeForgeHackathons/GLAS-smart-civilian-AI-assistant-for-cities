<script setup lang="ts">
import HomeTopBar from '@/components/home/HomeTopBar.vue'
</script>

<template>
  <div class="login-page">
    <HomeTopBar />
    <div class="login-wrap">
      <div class="login-card">
        <h1 class="login-title">Вход</h1>
        <div class="login-field">
          <label class="input-label">Телефон или email</label>
          <input type="text" class="input" placeholder="+7 (___) ___-__-__" readonly />
        </div>
        <button type="button" class="btn btn-primary">Получить код</button>
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
  padding: 32px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.06);
}

.login-title {
  margin: 0 0 24px;
  font-size: 22px;
  font-weight: 600;
  color: #1e2a4a;
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

.login-footer {
  font-size: 14px;
  color: #6b7280;
}

.login-footer a {
  color: #2563eb;
  margin-left: 4px;
}
</style>
