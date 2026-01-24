<script setup lang="ts">
</script>

<template>
  <aside class="sidebar">
    <div class="logo">ГЛАС</div>

    <nav>
      <a class="active">Главная</a>
      <a>Сообщить о проблеме</a>
      <a>Мои обращения</a>
      <a>Администрирование</a>
      <a>Ещё</a>
    </nav>
  </aside>
</template>

<style scoped>
.sidebar{
  background: linear-gradient(180deg, #2f6bff, #4fa3ff);
  color:white;
  padding: 20px;
}
.logo{
  font-weight: 700;
  margin-bottom: 30px;
}
nav a{
  display: block;
  padding: 12px 0;
  opacity: 0.85;
  cursor: pointer;
}
nav.a.active{
  font-weight: 600;
  opacity: 1;
}
</style>
