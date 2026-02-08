<script setup lang="ts">
import AdminHeader from '@/components/admin/AdminHeader.vue'
import AdminTaskList from '@/components/admin/AdminTaskList.vue'
import AdminMapPanel from '@/components/admin/AdminMapPanel.vue'
import AdminRequestCard from '@/components/admin/AdminRequestCard.vue'
</script>

<template>
  <div class="admin-dashboard">
    <AdminHeader />
    <div class="admin-body">
      <AdminTaskList />
      <AdminMapPanel />
      <AdminRequestCard />
    </div>
  </div>
</template>

<style scoped>
.admin-dashboard {
  display: flex;
  flex-direction: column;
  height: 100vh;
  width: 100%;
  background: #f4f7fb;
  overflow: hidden;
}

.admin-body {
  display: grid;
  grid-template-columns: 320px 1fr 360px;
  gap: 24px;
  flex: 1;
  min-height: 0;
  padding: 24px;
  overflow: hidden;
}
</style>
