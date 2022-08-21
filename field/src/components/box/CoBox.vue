<template>

  <div class="CoBox margin-bottom border-line">

    <span class="text_auth float-left">由{{ userName }}最后编辑于{{ modifyTime }}</span>
    <span title="MD5签名 : @MD5" class="text_mId float-right">{{ hashSign }}</span>

    <AtBox create-date="19-07-12"
           view-count="12345"
           comment-count="12345"
           star-count="12345"
           create-time="周四 07:12"
           archive="氛归档"
           label="氛标签"/>
  </div>

</template>

<script lang="ts">
import {defineComponent} from 'vue'
import AtBox from "@/components/box/AtBox.vue";

export default defineComponent({
  name: "CoBox",
  props:
      ['userName',
        'modifyTime',
        'hashSign',
        'create',
        'createDate',
        'viewCount',
        'commentCount',
        'starCount',
        'createTime',
        'archive',
        'label',],
  components: {AtBox}
})
</script>

<style scoped>

.CoBox {
  width: 100%;
  overflow: hidden;
  font-size: 16px;
  color: rgba(250, 250, 250, 1.00);

  border-radius: 4px;
}

#FootCoBox {
  color: white;
  text-align: center;
  letter-spacing: 1px;
  height: 100px;
}


.CoBox > .text_auth {
  margin-top: 6px;
  margin-left: 10px;

  letter-spacing: 1px;
  margin-right: 0;
}

.CoBox > .text_mId {
  font-family: 'Roboto Mono', monospace;
  letter-spacing: 2px;
  font-size: 14px;
  line-height: 14px;
  margin: 6px;

  border-radius: 4px;
}

.CoBox > .text_mId::before {
  font-family: 'field-icon';
  content: "\e3015";

  display: table-cell;
}

</style>