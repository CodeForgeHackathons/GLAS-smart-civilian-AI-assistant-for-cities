<script setup lang="ts">
import HomeTopBar from '@/components/home/HomeTopBar.vue'
import SidebarMenu from '@/components/home/SidebarMenu.vue'
import MainHero from '@/components/home/MainHero.vue'
import StatusPanel from '@/components/home/StatusPanel.vue'
import BottomNav from '@/components/home/BottomNav.vue'
</script>

<template>
  <div class="home-wrapper">
    <HomeTopBar />
    <div class="city-layout">
      <SidebarMenu />
      <MainHero />
      <StatusPanel />
    </div>
    <BottomNav />
  </div>
</template>

<style scoped>
.home-wrapper {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
  width: 100%;
  background: #f4f7fb;
}

.city-layout {
  display: grid;
  grid-template-columns: 280px 1fr 380px;
  gap: 24px;
  flex: 1;
  min-height: 0;
  padding: 24px;
  width: 100%;
  box-sizing: border-box;
  overflow-y: auto;
}

@media (max-width: 768px) {
  .city-layout {
    padding-bottom: 72px;
  }
}
</style>
