<script setup lang="ts">

</script>

<template>
<aside class="status">
  <h3>Получено</h3>
  <ul>
    <li class="active">В работе</li>
    <li>Рассматривается</li>
    <li>Решено</li>
  </ul>
  <button class="more">Сообщить ещё</button>
</aside>
</template>

<style scoped>
.status {
  background: white;
  border-radius: 24px;
  padding: 32px;
  box-shadow: 0 20px 40px rgba(20, 40, 120, 0.08);
}
h3{
  margin-bottom: 24px;
  color: #1e2a4a;
}
ul li{
  color: #9aa4bf;
  padding: 10px 0;
}

ul li.active{
  color: #1f9d55;
  font-weight: 600;
}

.more{
  margin-top: 32px;
  width: 100%;
  padding: 14px;
  border-radius: 14px;
  background: #1f9d55;
  color: white;
  border: none;
  font-size: 15px;
}
</style>
