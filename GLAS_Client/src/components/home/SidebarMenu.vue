<script setup lang="ts"></script>

<template>
  <aside class="sidebar">
    <div class="logo">ГЛАС</div>

    <nav>
      <a class="active">Главная</a>
      <a>Сообщить о проблеме</a>
      <a>Мои обращения</a>
      <a>Администрирование</a>
      <div class="spacer"></div>
      <a>Ещё</a>
    </nav>
  </aside>
</template>

<style scoped>
.sidebar {
  background: linear-gradient(180deg, #2f6bff, #4f8cff);
  border-radius: 20px;
  color: white;
  padding: 20px;
  display: flex;
  flex-direction: column;
}
.logo {
  font-size: 18px;
  font-weight: 700;
  margin-bottom: 32px;
}
nav {
  display: flex;
  flex-direction: column;
  gap: 6px;
}
nav a {
  display: flex;
  align-items: center;
  height: 44px;
  padding: 0 16px;
  border-radius: 12px;
  font-size: 15px;
  opacity: 0.85;
  cursor: pointer;
}
nav.a.active {
  background: rgba(255, 255, 255, 0.25);
  font-weight: 600;
}
nav.a.hover {
  background: rgba(255, 255, 255, 0.25);
  font-weight: 600;
}
.spacer {
  flex: 1;
}
</style>
