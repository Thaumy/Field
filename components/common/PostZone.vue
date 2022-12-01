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

//onBeforeRouteUpdate(())


</script>
