<template>
  <div id="CommentBox" class="CommentBox M border-radius-all bE-white">
    <div class="Content">
      <div class="Logo"></div>
      <div class="ReplyLogo" v-show="HEAD"></div>
      <transition name="fade">
        <div class="ReplyFloor cursor-pointer" v-show="HEAD" v-on:click="closeReply" onmouseover="CommentBox_ReplyBtn_Over()"
             onmouseleave="CommentBox_ReplyBtn_Leave()">{{ FloorText }}
        </div>
      </transition>
      <textarea v-model="Content" placeholder="评论内容(必填)"></textarea>
    </div>
    <div class="Name">
      <div class="Logo"></div>
      <input v-model="Name" placeholder="昵称(必填)"/>
    </div>
    <div class="Email">
      <div class="Logo"></div>
      <input v-model="Email" placeholder="邮箱(必填)"/>
    </div>
    <div class="WebSite">
      <div class="Logo"></div>
      <input v-model="WebSite" placeholder="网站(可选)"/>
    </div>

    <div class="Captcha">
      <v-btn color="primary" block height="34" class="CaptchaLine">提交</v-btn>
    </div>

  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";
export default defineComponent({
  name: "CommentBox",
  data() {
    return {
      FloorText: '0F',

      HEAD: 0,
      Content: '',
      Name: '',
      Email: '',
      WebSite: ''
    }
  },

  methods: {

    /*评论检查*/
    ContentCheck(value) {
      if (value == "") {
        return false;
      } else {
        if (value.length > 320) {
          return false;
        } else {
          return true;
        }
      }
    },
    NameCheck(value) {
      if (value == "") {
        return false;
      } else {
        if (value.length > 12) {
          return false;
        } else {
          return true;
        }
      }
    },
    EmailCheck(value) {
      if (value == "") {
        return false;
      } else {
        //const reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
        const reg = /^([A-Za-z0-9_\-.])+@([A-Za-z0-9_\-.])+\.([A-Za-z]{2,4})$/;
        if (!reg.test(value)) {
          return false;
        }
      }
    },
    WebSiteCheck(value) {
      if (value == "") {
        return true;
      } else {
        //const reg0 = /^(http|https|ftp)\:\/\/([a-zA-Z0-9]([a-zA-Z0-9\-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,6}(\/)?$/;
        const reg0 = /^(http|https|ftp):\/\/([a-zA-Z0-9]([a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,6}(\/)?$/;
        if (!reg0.test(value)) {
          return false;
        } else {
          return true;
        }
      }
    },
    check: function () {

      if (this.ContentCheck(this.Content) &
          this.NameCheck(this.Name) &
          this.EmailCheck(this.Email) &
          this.WebSiteCheck(this.WebSite)) {
        //TODO
        return true;
      } else {
        //TODO
        //__nc.reload();????
        window.alert("请检查填写是否有误");
        return false;
      }
    },
    doReply: function (el) {
      this.FloorText = el.dataset.f + "F";
      this.HEAD = el.dataset.id;
    },
    closeReply: function () {
      /* HEAD为0时，回复不会显示 */
      this.HEAD = 0;
    }
  }
})
</script>

<style scoped>

.CommentBox {
  display: grid;
  grid-template-columns: 35% 20% 35% 10%;
  grid-template-rows: auto 38px 38px;

  padding: 2px;
}

/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px) {
  .CommentBox {
    margin: auto;
    width: 70%;
    min-width: 600px;
    max-width: 700px;
  }
}

/* 屏幕宽度 [ 491 , 1000 ] */
@media (min-width: 491px) and (max-width: 1000px) {
  .CommentBox {
    margin: auto;
    width: 86%;
    min-width: 482px;
    max-width: 700px;
  }
}

/* 屏幕宽度 ( - , 490 ] */
@media (max-width: 490px) {
  .CommentBox {
    width: 100%;
    box-sizing: border-box;
  }
}

.CommentBox > div {
  display: flex;
  padding: 2px;
}

.CommentBox > div > input,
.CommentBox > div > textarea {
  font-size: 16px;
  min-width: 0;
  flex: 1;
  border-radius: 0;
  border-top-right-radius: 2px;
  border-bottom-right-radius: 2px;
}

.CommentBox input {
  color: rgba(80, 80, 80, 1);

  padding-left: 8px;
  border: 0;

  transition: all 0.2s ease;
}

.CommentBox > .Name {
  grid-column-start: 1;
  grid-column-end: 2;
}

.CommentBox > .Email {
  grid-column-start: 2;
  grid-column-end: 5;
}

.CommentBox > .WebSite {
  grid-column-start: 1;
  grid-column-end: 3;
}

.CommentBox > .Captcha {
  grid-column-start: 3;
  grid-column-end: 5;
}

.CommentBox > .Content {
  grid-column-start: 1;
  grid-column-end: 5;

  grid-template-columns: 34px auto;
  grid-template-rows: 30px 24px auto;

  display: grid;
}

.CommentBox > .Content > textarea {
  grid-row-start: 1;
  grid-row-end: 4;

  grid-column-start: 2;
  grid-column-end: 3;

  font-family: 'Noto Sans SC', sans-serif;
  text-align: left;

  min-height: 74px;
  padding-top: 4px;
  padding-left: 8px;

  border: 0;

  border-top-right-radius: 2px;
  border-bottom-right-radius: 2px;
  border-bottom-left-radius: 2px;

  resize: none;
}

.CommentBox > .Content > .Logo {
  padding-left: 10px;
  line-height: 33px;
}

.CommentBox > div > .Logo {
  border-top-left-radius: 2px;
  border-bottom-left-radius: 2px;
  line-height: 2.2em;
  padding-left: 8px;
  padding-right: 8px;
  color: rgba(130, 130, 130, 1);
}

.CommentBox > div > .Logo::before {
  font-family: 'field-icon';
  line-height: 1.2em;
}

.CommentBox > .Name > .Logo::before {
  content: "\e3008";
}

.CommentBox > .Email > .Logo::before {
  content: "\e3021";
}

.CommentBox > .WebSite > .Logo::before {
  content: "\e3022";
}

.CommentBox > .Captcha > .Logo::before {
  content: "\e3015";
}

.CommentBox > .Content > .Logo::before {
  content: "\e3010";
}

.CommentBox > .Content > .ReplyLogo {
  margin: auto;
  padding-top: 1px;
  grid-row-start: 2;
  transform: rotate(90deg);
}

.CommentBox > .Content > .ReplyLogo::before {
  content: "\e3020";
  font-family: 'field-icon';
  color: rgb(255 159 0);
}

.CommentBox > .Content > .ReplyFloor {
  grid-row-start: 3;

  color: white;
  font-size: 12px;
  font-weight: 600;
  line-height: 18px;

  padding-bottom: 1px;

  padding-left: 3px;
  padding-right: 3px;
  margin: auto;

  background: rgb(0, 180, 255, 1);
  border-radius: 4px;
  box-shadow: 0px 0px 3px 0.2px rgba(0, 0, 0, 0.4);

  transition: all 0.2s ease;
}

</style>