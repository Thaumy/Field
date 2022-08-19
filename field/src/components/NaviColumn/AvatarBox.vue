<template>

  <div class="box border-shadow border-radius-top">
    <div class="AvaBox">
      <div class="outline" :style="outlineStyle" @click="showOutline()">
        <img class="Avatar border-shadow cursor-pointer" :src="avatar" alt="avatar">
      </div>
    </div>

    <div class="Name">{{ title }}</div>
    <div class="Note"><span id="note"></span></div>
  </div>

</template>

<script lang="ts">
import {defineComponent} from "vue";

import Typed from "typed.js";

export default defineComponent({
  name: "AvatarBox",
  props: {
    avatar: String,
    title: String,
  },
  data() {
    return {
      outlineStyle: {
        'border-color': 'transparent'
      },
    }
  },
  methods: {
    showOutline() {
      this.outlineStyle = {
        'border-color': 'rgba(1, 153, 255, 1)'
      }
      setTimeout(() => this.outlineStyle = {'border-color': 'transparent'}, 200)
    }
  },
  mounted() {
    new Typed('#note', {
      strings: ['你好！~~^400', '这里是THAUMY的博客！^300', '又一个码农的家', '又一个码农的家.', '又一个码农的家..', '又一个码农的家...'],
      typeSpeed: 100,
      backSpeed: 0,
      smartBackspace: true,
      loop: false
    });
  },
})
</script>

<style scoped>

.AvaBox {
  display: flex;

  height: 21vh;
  max-height: 160px;
  min-height: 150px;
}

.outline {
  margin: auto;
  display: flex;

  width: 11vw;
  height: 11vw;
  max-width: 108px;
  max-height: 108px;

  border-width: 2.6px;
  border-style: solid;
  border-radius: 100px;

  transition: all 0.2s ease;
}

.Avatar {
  align-self: center;

  width: 10vw;
  height: 10vw;
  max-width: 100px;
  max-height: 100px;

  margin: auto;

  border-radius: 100px;
}

.Name {
  font-size: 21px;
  font-weight: 400;
  letter-spacing: 2px;

  text-align: center;
}

.Note {
  height: 6vh;
  max-height: 50px;
  min-height: 30px;
  width: 98%;

  font-size: 15px;

  text-align: center;
  font-size: 15px;

  margin: auto;
}

.Note::before {
  align-self: center;

  margin-right: 6px;
  font-family: "field-icon";
  content: '\e3010';
  font-size: 12px;
}

.Note::after {
  align-self: center;

  margin-left: 6px;
  font-family: "field-icon";
  content: '\e3003';
  font-size: 12px;
}
</style>