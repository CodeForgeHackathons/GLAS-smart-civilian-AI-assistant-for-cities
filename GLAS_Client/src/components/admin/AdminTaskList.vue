<script setup lang="ts"></script>

<template>
  <aside class="task-list">
    <div class="list-header">
      <span class="list-title">1 Новые</span>
      <div class="pagination">
        <span class="page-info">2 1</span>
        <button class="nav-arrow">‹</button>
        <button class="nav-arrow">›</button>
      </div>
    </div>
    <div class="list-items">
      <div class="task-item">
        <span class="task-icon task-icon-mic"></span>
        <div class="task-content">
          <div class="task-title">Дым на дороге</div>
          <div class="task-address">ул. Майская, 17</div>
        </div>
        <span class="task-tag new">Новые</span>
      </div>
      <div class="task-item">
        <span class="task-icon task-icon-search"></span>
        <div class="task-content">
          <div class="task-title">Треснула мусорка во дворе</div>
          <div class="task-address">ул. Тверская, 20</div>
        </div>
        <button class="task-close">×</button>
      </div>
      <div class="task-item">
        <span class="task-icon task-icon-dot"></span>
        <div class="task-content">
          <div class="task-title">Треснула крышка люка</div>
          <div class="task-address">ул. Мира, д. 20</div>
        </div>
      </div>
      <div class="task-item">
        <span class="task-icon task-icon-dot"></span>
        <div class="task-content">
          <div class="task-title">Треснула крышка люка</div>
          <div class="task-address">ул. Мира, д. 20</div>
        </div>
        <button class="task-close">×</button>
      </div>
    </div>
  </aside>
</template>

<style scoped>
.task-list {
  background: white;
  border-radius: 16px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.06);
  display: flex;
  flex-direction: column;
  overflow: hidden;
}

.list-header {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 16px 20px;
  border-bottom: 1px solid #e5e7eb;
}

.list-title {
  font-size: 16px;
  font-weight: 600;
  color: #1e2a4a;
}

.pagination {
  display: flex;
  align-items: center;
  gap: 8px;
}

.page-info {
  font-size: 13px;
  color: #6b7280;
  margin-right: 4px;
}

.nav-arrow {
  width: 28px;
  height: 28px;
  border: 1px solid #d1d5db;
  border-radius: 6px;
  background: white;
  font-size: 16px;
  cursor: pointer;
  color: #4b5563;
}

.list-items {
  flex: 1;
  overflow-y: auto;
  padding: 8px;
}

.task-item {
  display: flex;
  align-items: flex-start;
  gap: 12px;
  padding: 12px 14px;
  border-radius: 12px;
  margin-bottom: 6px;
  transition: background 0.2s;
}

.task-item:hover {
  background: #f9fafb;
}

.task-icon {
  width: 36px;
  height: 36px;
  border-radius: 10px;
  flex-shrink: 0;
}

.task-icon-mic {
  background: #fed7aa;
}

.task-icon-search {
  background: #bbf7d0;
}

.task-icon-dot {
  background: #fecaca;
  position: relative;
}

.task-icon-dot::after {
  content: '';
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  width: 8px;
  height: 8px;
  border-radius: 50%;
  background: #dc2626;
}

.task-content {
  flex: 1;
  min-width: 0;
}

.task-title {
  font-size: 14px;
  font-weight: 500;
  color: #1e2a4a;
  margin-bottom: 4px;
}

.task-address {
  font-size: 12px;
  color: #6b7280;
}

.task-tag {
  font-size: 11px;
  font-weight: 500;
  padding: 4px 8px;
  border-radius: 6px;
  flex-shrink: 0;
}

.task-tag.new {
  background: #fef3c7;
  color: #b45309;
}

.task-close {
  width: 24px;
  height: 24px;
  border: none;
  background: transparent;
  font-size: 18px;
  color: #9ca3af;
  cursor: pointer;
  flex-shrink: 0;
}
</style>
