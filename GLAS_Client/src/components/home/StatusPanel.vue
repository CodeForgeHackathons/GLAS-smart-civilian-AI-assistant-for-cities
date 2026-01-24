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
  padding: 24px;
  border-left: 1px solid #e5e9f2;
}
h3{
  margin: 20px;
}
ul{
  list-style: none;
  padding: 0;
}
li{
  padding: 10px 0;
  opacity: 0.6;
}
li.active{
  color: green;
  font-weight: 600;
  opacity: 1;
}

.more{
  margin-top: 30px;
  width: 100%;
  padding: 12px;
  border-radius: 10px;
  background: #1f9d55;
  color: white;
  border: none;
}
</style>
