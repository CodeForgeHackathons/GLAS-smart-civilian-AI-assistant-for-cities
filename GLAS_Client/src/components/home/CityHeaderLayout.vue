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
  grid-template-columns:240px 1fr 320px;
  height: 100vh;
  background: #f4f7fb;
}
</style>
