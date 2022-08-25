<template>
  <div>

    <div class="comment-list">

      <div v-for="(item,index) in comments" ref="comment-list">
        <div class="comment-divider" v-if="index!==0"/>
        <CommentCard
            :comment='item'
            :enable-reply='replyTo!==item.id'
            @do-reply="
                    replyTo=item.id;
                    $refs['reply-target-slider'].expand($refs['comment-list'][index].children[1].offsetHeight)"
        >

          <template #user-name-right-slot>

            <transition name="reply-btn" v-if="enableReply">
              <v-icon class="reply-btn"
                      color="orange"
                      icon="mdi-reply"
                      size="1.1em"
                      @click="$emit('replyClick',item)"
              />
            </transition>

          </template>

        </CommentCard>
      </div>

    </div>

  </div>
</template>

<script setup lang="ts">
import CommentCard from './CommentCard.vue'
import {Comment} from "@/scripts/comment";
import {PropType, Ref, ref} from "vue";

defineEmits<{ (e: 'replyClick', comment: Comment): void }>()

defineProps({
  comments: Object as PropType<Comment[]>
})
const replyTo = ref(12384)
</script>

<style lang="stylus" scoped>

.comment-divider
  border-top 1px solid rgb(50 50 50)
  margin-left 44px
  margin-right 8px

</style>