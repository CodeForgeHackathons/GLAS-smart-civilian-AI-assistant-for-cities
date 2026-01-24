<script setup lang="ts">
import SidebarMenu from '@/components/home/SidebarMenu.vue'
import MainHero from '@/components/home/MainHero.vue'
import StatusPanel from '@/components/home/StatusPanel.vue'
</script>

<template>
  <div class="city-layout">
    <SidebarMenu />
    <MainHero />
    <StatusPanel />
  </div>
</template>

<style scoped>
.city-layout {
  display:grid;
  grid-template-columns:260px 1fr 360px;
  gap: 24px;
  height: 100vh;
  padding: 24px;
  background: #f4f7fb;
}
</style>
