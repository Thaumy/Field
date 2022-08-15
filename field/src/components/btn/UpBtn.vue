<template>
  <div>
    <transition name="fade">
      <div
          v-show="isShow"
          class="upBtn bE-black border-radius-all"
          @click="goUp()"></div>
    </transition>
  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";
import {makeThrottle} from "@/scripts/throttle";

export default defineComponent({
  name: "UpBtn",
  mounted() {
    /* 返顶按钮淡入淡出 */
    window.addEventListener('scroll', makeThrottle(() => {
      this.isShow = window.scrollY >= 1000
    }, 300))
  },
  data() {
    return {isShow: false}
  },
  methods: {
    goUp: () => window.scrollTo({top: 0, behavior: 'smooth'})
  }
})
</script>

<style scoped>

.fade-enter-from, .fade-leave-to {
  opacity: 0;
}

.fade-enter-active, .fade-leave-active {
  transition: all 0.35s;
}

.upBtn {
  transition: all 0.35s;
  text-align: center;
  line-height: 28px;

  position: fixed;
  z-index: 1;
  bottom: 10%;

  cursor: pointer;
  background: rgba(0, 0, 0, 0.8);
  backdrop-filter: blur(20px) invert(80%);
}

.upBtn::before {
  font-family: 'field-icon';
  color: #FFFFFF;
  content: "\e3005";
}

/* 屏幕宽度 [ 1491 , + ) */
@media (min-width: 1491px) {
  .upBtn {
    font-size: 22px;

    width: 50px;
    padding-top: 7px;
    padding-bottom: 9px;

    right: 6%;
  }

  .upBtn::before {
    font-size: 16px;
  }
}

/* 屏幕宽度 [ 1001 , 1490 ] */
@media (min-width: 1001px) and (max-width: 1490px) {
  .upBtn {
    font-size: 22px;

    width: 36px;
    padding-top: 2px;
    padding-bottom: 7px;

    right: 2%;
  }

  .upBtn::before {
    font-size: 14px;
  }
}

/* 屏幕宽度 ( - , 1000 ] */
@media (max-width: 1000px) {
  .upBtn {
    font-size: 18px;

    width: 36px;
    padding-top: 4px;
    padding-bottom: 7px;

    left: 2%;
  }

  .upBtn::before {
    font-size: 12px;
  }
}

</style>