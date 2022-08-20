<template>
  <div>

    <div class="card border-shadow"
    >
      <v-avatar
          class="user-avatar"
          rounded="true"
          size="32"
          icon="mdi-account-circle"
      />
      <div class="user-name">
        <transition name="reply-btn-rotate">
          <v-text-field
              label="昵称"
              variant="solo"
          ></v-text-field>
        </transition>
      </div>
      <div class="create-time"></div>
      <v-textarea class="body"></v-textarea>
    </div>

  </div>
</template>

<script setup lang="ts">

</script>

<style scoped>

.card {
  display: grid;
  grid-template-columns: 40px auto;
  grid-template-rows: 40px auto 80px;

  padding: 4px;

  border-radius: 2px;
  margin: 4px;
}

.reply-btn-rotate-enter-active,
.reply-btn-rotate-leave-active {
  transition: all 0.2s ease;
}

.reply-btn-rotate-leave-to {
  opacity: 0;
}

.reply-btn-rotate-enter-from {
  opacity: 0;
  transform-origin: left bottom;
  transform: rotate(90deg);
}

.user-avatar {
  margin: 4px;
  grid-row-start: 1;
  grid-row-end: 3;
}

.user-name {
  font-size: 0.8rem;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
  grid-column-start: 2;
}

.create-time {
  align-self: center;
  grid-row-start: 2;
  grid-column-start: 4;

  font-size: 0.6rem;
  color: rgba(170, 170, 170, 1);
}

.body {
  grid-column-start: 1;
  grid-column-end: 5;

  font-size: 0.9rem;
  text-align: left;

  padding-top: 4px;
  padding-left: 8px;
  padding-bottom: 2px;
}
</style>
<style scoped>
.card {
  /* 颜色模式 */
  background: var(--b30);
}

.user-name {
  /* 颜色模式 */
  color: var(--w220);
}

.body {
  /* 颜色模式 */
  color: var(--w200);
}

.create-time {
  /* 颜色模式 */
  color: rgba(170, 170, 170, 1);
}
</style>