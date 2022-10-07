<template>
  <!--
    <div>

      <f-data :provider="async ()=> data" v-slot="its">
        <div v-if="its.length>1">
        </div>
      </f-data>
    </div>
  -->
</template>

<script lang="ts" setup>

import {ref, inject, onMounted, onBeforeMount} from "vue"
import {useRouter} from "#app"
import PostCard from "@/components/PostCard/PostCard.vue"
import CommentZone from "@/components/CommentZone/CommentZone.vue"
import SwitchZone from "@/components/common/SwitchZone.vue"
import FLazy from "@/components/field/f-lazy.vue"
import FData from "@/components/field/f-data.vue"
import {CachedMixin} from "~/scripts/type/mixin"

//onBeforeRouteUpdate(())

const props =
    defineProps<{
      data: CachedMixin[]
    }>()

const showGlobalSnackbar: any = inject('showGlobalSnackbar')

const router = useRouter()

onBeforeMount(() => {
  if (props.data.length === 0) {
    showGlobalSnackbar('mdi-alert-rhombus', '404 NOT FOUND / 已重定向至首页', 'red', 5000)
    router.push('/')
  }
})

</script>
