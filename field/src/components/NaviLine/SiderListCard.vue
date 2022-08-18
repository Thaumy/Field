<template>
  <div>

    <div class="card cursor-pointer border-radius-all">
      <div class="card-title">{{ title }}</div>
    </div>

  </div>
</template>

<script>
export default {
  name: "SiderListCard",
  props: {
    title: String
  }
}
</script>

<style scoped>

.card {
  width: 94%;
  height: 5vh;
  display: flex;

  margin: auto;
  margin-top: 2px;
  margin-bottom: 2px;

  color: rgba(250, 250, 250, 1);
  font-size: 17px;
  letter-spacing: 1px;
}

.card-title {
  margin: auto;
  align-self: center;
}

</style>