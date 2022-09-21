<template>
  <div>

    <div v-if="post_ids.length>1">
      <f-lazy
          v-for="post_id in post_ids"
          v-slot="data"
          :initializer="async ()=>{
            await preparePost(post_id)
            return getPost(post_id)
          }"
      >
        <PostCard
            hide-body
            :post="data.post"
            :cover-url="data.additional.coverUrl"
            :summary="data.additional.summary"
            :is-generated-summary="data.additional.isGeneratedSummary"
            :view-count="data.additional.viewCount"
            :comment-count="data.comments.length"
            :is-archived="data.additional.isArchived"
            :is-scheduled="data.additional.isScheduled"
            :topics="data.additional.topics"
            class="cursor-pointer"
            @click="$router.push('/'+data.post.id)"
        />
      </f-lazy>
    </div>

    <div v-else-if="post_ids.length===1">
      <f-lazy
          v-slot="data"
          :initializer="async ()=>getPost(post_ids[0])"
      >
        <PostCard
            :post="data.post"
            :cover-url="data.additional.coverUrl"
            :summary="data.additional.summary"
            :is-generated-summary="data.additional.isGeneratedSummary"
            :view-count="data.additional.viewCount"
            :comment-count="data.comments.length"
            :is-archived="data.additional.isArchived"
            :is-scheduled="data.additional.isScheduled"
            :topics="data.additional.topics"
        />
        <transition-group>
          <CommentZone
              key=""
              class="margin-bottom"
              :post-id="data.post.id"
              :comments="data.comments"
              :disable-comment="data.additional.disableComment"
          />
          <SwitchZone
              key=""
              class="margin-bottom"
              :post-id="data.post.id"
          />
        </transition-group>
      </f-lazy>
    </div>

  </div>
</template>

<script lang="ts" setup>

import {defineAsyncComponent, inject} from "vue"
import {CachedMixin} from "@/scripts/type/mixin"
import {useRouter} from "vue-router"
import PostCard from "@/components/PostCard/PostCard.vue"
import {onBeforeRouteUpdate} from "vue-router"
import {getPost, prepareNextPost, preparePrevPost} from "@/scripts/data/post"
import {preparePost} from "@/scripts/data/post"
import FLazy from "@/components/field/f-lazy.vue"

/*
onBeforeRouteUpdate(async (to, from, next) => {
  const post_id = Number(to.params.post_id)

  //如果数据不存在，从服务器获取
//TODO title
  if (!isCached(post_id))
    await getPost(post_id)

  next()
})
*/

const CommentZone = defineAsyncComponent(
    () => import("@/components/CommentZone/CommentZone.vue"))
const SwitchZone = defineAsyncComponent(
    async () => {
      console.log('done1')
      if (props.post_ids.length === 1) {
        await prepareNextPost(props.post_ids[0])
        await preparePrevPost(props.post_ids[0])
        console.log('done')
      }
      return import("@/components/btn/SwitchZone.vue")
    })

const props =
    defineProps<{
      post_ids: number[]
    }>()

const showGlobalSnackbar: any = inject('showGlobalSnackbar')

if (props.post_ids.length === 0) {
  showGlobalSnackbar('mdi-alert-rhombus', '404 NOT FOUND / 已重定向至首页', 'red', 5000)
  useRouter().push('/')
}

</script>

<style lang="stylus" scoped>

.v-enter-active
  transition all 0.2s ease

.v-enter-from
  transform translateY(20px)
  opacity 0

.initialized-enter-active
  transition all 0.4s ease

.initialized-enter-from
  transform translateX(50px) rotate(0.5deg)
  opacity 0

</style>