<script setup lang="ts">
import HomeTopBar from '@/components/home/HomeTopBar.vue'
import SidebarMenu from '@/components/home/SidebarMenu.vue'
import BottomNav from '@/components/home/BottomNav.vue'
</script>

<template>
  <div class="public-layout">
    <HomeTopBar />
    <div class="public-body">
      <SidebarMenu />
      <main class="public-main">
        <slot />
      </main>
    </div>
    <BottomNav />
  </div>
</template>

<style scoped>
.public-layout {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
  width: 100%;
  background: #f4f7fb;
}

.public-body {
  display: grid;
  grid-template-columns: 280px 1fr;
  gap: 24px;
  flex: 1;
  min-height: 0;
  padding: 24px;
  overflow-y: auto;
}

.public-main {
  min-height: 0;
}

@media (max-width: 768px) {
  .public-body {
    padding-bottom: 72px;
  }
}
</style>
