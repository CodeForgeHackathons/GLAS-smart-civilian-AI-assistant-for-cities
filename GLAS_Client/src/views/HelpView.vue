<script setup lang="ts">
import PublicLayout from '@/components/layout/PublicLayout.vue'
</script>

<template>
  <PublicLayout>
    <div class="help-card">
      <h1 class="page-title">Справка и помощь</h1>
      <div class="help-placeholder">
        Видеоинструкции и ссылки на помощь
      </div>
    </div>
  </PublicLayout>
</template>

<style scoped>
.help-card {
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

.help-placeholder {
  min-height: 300px;
  background: #f9fafb;
  border: 2px dashed #d1d5db;
  border-radius: 16px;
  display: flex;
  align-items: center;
  justify-content: center;
  color: #9ca3af;
  font-size: 14px;
}
</style>
