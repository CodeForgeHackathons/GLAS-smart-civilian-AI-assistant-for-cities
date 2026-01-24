<script setup lang="ts">
import HeroBanner from '@/components/home/HeroBanner.vue'
import HeroActions from '@/components/home/HeroActions.vue'
</script>

<template>
<main class="hero">
  <div class="hero-card">
  <HeroBanner />
  <HeroActions />
  </div>
</main>
</template>

<style scoped>
.hero{
  display: flex;
  justify-content: center;
  align-items: flex-start;
}

.hero-card{
  width: 100%;
  max-width: 720px;
  background: white;
  border-radius: 24px;
  padding: 48px;
  box-shadow: 0 20px 40px rgba(20, 40, 120, 0.08);
}
</style>
