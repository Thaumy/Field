<template>
  <div v-for="a in List" v-bind:item="a" v-bind:key="a.index">
    <div ref="foo" class="Card cur bRds" v-on:click="pc_nav_card_click" :key="a.index">
      <div class="contain">{{ a.Title }}</div>
    </div>
  </div>
</template>

<script>
export default {
  name: "PcNavCard",
  methods: {
    pc_nav_card_click: function () {
      //up();
      this.barSeen = true

      this.style = {
        top: this.item.index * 6 + 'vh',
      }

      /*
      AvaOutline.style = {
        'border-color': 'rgba(0,0,0,0)'
      }
      CoOutline.style = {
        'border-color': 'rgba(0,0,0,0)'
      }*/
    }
  },
  data() {
    return {
      barSeen: true,
      style: {
        top: '0vh'
      },
      List: [{
        index: 0,
        ID: 12345,
        Title: '首页'
      },
        {
          index: 1,
          ID: 12346,
          Title: '四宫辉夜'
        },
        {
          index: 2,
          ID: 12349,
          Title: '石上优'
        },
        {
          index: 3,
          ID: 12349,
          Title: '白银御行'
        },
        {
          index: 4,
          ID: 12349,
          Title: '藤原千花'
        },
        {
          index: 5,
          ID: 12349,
          Title: '早坂爱'
        },
        {
          index: 6,
          ID: 12349,
          Title: '伊井野弥子'
        }
      ]
    }
  },
}
</script>

<style scoped>

.Card {
  display: flex;
  width: 94%;
  height: 6vh;
  max-height: 50px;
  min-height: 28px;

  margin-left: 2.4%;

  font-size: 17px;
  letter-spacing: 1px;
  color: rgba(230, 230, 230, 1.00);

  transition: all 0.2s ease;
}

.Card::after {
  align-self: center;

  margin-right: 3px;
  float: right;

  font-family: 'field-icon';
  content: "\e3013";
}

.Card > .contain {
  margin-right: auto;
  align-self: center;
  margin-left: 10px;
}
</style>