<script setup lang="ts">
import HeroBanner from '@/components/home/HeroBanner.vue'
import HeroActions from '@/components/home/HeroActions.vue'
</script>

<template>
<main class="hero">
  <HeroBanner />
  <HeroActions />
</main>
</template>

<style scoped>
.hero{
  padding: 40px;
  background: #eef3ff;
}
</style>
