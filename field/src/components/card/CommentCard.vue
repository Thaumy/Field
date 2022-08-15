<template>

  <div class="Box border-shadow" @mouseover="over" @mouseleave="leave()">
    <div class="Name">{{ userName }}
      <span v-if="replyFloor&&replyUserName">
        <span class="ReplyLogo"></span>
        <span class="ReplyFloor">{{ replyFloor }}F</span>
        {{ replyUserName }}
      </span>
    </div>
    <div class="Floor cursor-pointer border-shadow"
         :style="floorStyle"
         onclick="CommentBox.doReply(this)">{{ floorText }}
    </div>
    <div class="Email">{{ email }}</div>
    <div class="Time">{{ createTime }}</div>
    <div class="Content">{{ body }}</div>
  </div>

</template>

<script lang="ts">
import {defineComponent} from "vue";

export default defineComponent({
  name: "CommentCard",
  props: {
    userName: String,
    floor: String,
    email: String,
    createTime: String,
    body: String,
    replyFloor: String,
    replyUserName: String
  },
  data() {
    return {
      floorText: this.floor,
      floorStyle: {},
      overStyle: {
        "height": "22px",
        "width": "32px",

        "font-size": "0.8em",
        "font-weight": "500",
        "font-family": "Source Sans Pro",
        "color": "rgb(255, 255, 255)",
        "line-height": "22px",

        "background": "rgb(0, 180, 255)"
      }
    }
  },
  methods: {
    over() {
      this.floorText = "回复"
      this.floorStyle = this.overStyle
    },
    leave() {
      this.floorText = this.floor
      this.floorStyle = {}
    },
  }
})
</script>

<style scoped>

.Box {
  display: grid;
  grid-template-columns: 50% 46% 4%;
  grid-template-rows: 24px 20px auto;

  padding: 4px;

  border-radius: 2px;
  margin: 4px;
}

.Box > .Name {
  justify-self: start;
  grid-column-start: 1;
  grid-column-end: 3;

  max-width: 93.4%;
  padding-left: 3px;

  font-size: 1.1em;
  font-weight: 400;
  line-height: 1.2em;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}

.ReplyFloor {
  float: right;

  color: white;
  font-size: 12px;
  font-weight: 600;
  line-height: 18px;
  margin-top: 2px;
  padding-bottom: 1px;

  padding-left: 3px;
  padding-right: 3px;
  margin-left: 4px;
  margin-right: 4px;

  background: rgb(0, 180, 255);
  border-radius: 4px;
  box-shadow: 0px 0px 3px 0.2px rgba(0, 0, 0, 0.4);
}

.ReplyLogo {
  display: inline;

  margin-left: 4px;
  margin-right: 4px;
}

.ReplyLogo::before {
  font-family: 'field-icon';
  font-size: 0.88em;
  color: rgb(255, 159, 0);
  content: "\e3020";
}

.Box > .Time {
  justify-self: right;
  grid-column-start: 2;
  grid-column-end: 4;

  font-size: 0.7em;
  color: rgba(170, 170, 170, 1);
}

.Box > .Email {
  justify-self: start;
  padding-left: 3px;

  font-size: 0.7em;
  text-align: right;
  color: rgba(170, 170, 170, 1);
}

.Box > .Floor {
  justify-self: end;
  grid-column-start: 3;

  height: 14px;
  width: 14px;

  font-size: 0.6em;
  font-family: 'Roboto Mono', monospace;
  overflow: hidden;
  text-align: center;
  line-height: 13px;

  border-radius: 2px;

  transition: all 0.2s ease;
}

.Box > .Content {
  grid-column-start: 1;
  grid-column-end: 4;

  font-size: 0.9em;
  text-align: left;

  padding-top: 4px;
  padding-left: 8px;
  padding-bottom: 2px;
}

</style>