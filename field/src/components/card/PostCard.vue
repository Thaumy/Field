<template>

  <div class="Card M bE-black bRds">
    <div class="contain bRds">

      <div class="Title">{{ title }}</div>
      <div class="Summary">{{ summary }}</div>

      <ScheduleTip/>
      <ArchiveTip/>
      <ReadTimeTip/>

      <div class="Content markdown-body" v-html="body"></div>
      <SwitchBtn prev="你不知道的114514个单身技巧" next="构建pilipala应用的最佳实践"/>

    </div>
  </div>

</template>

<script>
import '@/styles/card/common.css'
import ScheduleTip from "@/components/tip/ScheduleTip.vue";
import ReadTimeTip from "@/components/tip/ReadTimeTip.vue";
import ArchiveTip from "@/components/tip/ArchiveTip.vue";
import SwitchBtn from "@/components/btn/SwitchBtn.vue";

export default {
  name: "PostBox",
  props: ['title', 'summary', 'body'],
  components: {
    SwitchBtn,
    ScheduleTip,
    ArchiveTip,
    ReadTimeTip
  },

}
</script>

<style scoped>

</style>