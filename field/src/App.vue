<template>
  <v-app class="main">
    <v-main>

      <MenuBar :posts="menu_posts" :style="commonOpacityStyle"/>

      <div class="content">
        <div class="left-part">
          <Menu :posts="menu_posts" :style="commonOpacityStyle"/>
        </div>

        <div class="right-part float-right">
          <PostZone :comments="comments" :data-collection="post_data" :style="commonOpacityStyle"/>

          <CommentZone :comments="comments" :post-id="12384"/>

          <f-card style="width: fit-content;margin: auto">
            <SwitchBtn prev="你不知道的114514个单身技巧" next="构建pilipala应用的最佳实践"/>
          </f-card>
        </div>
      </div>

      <GoUpBtn :style="commonOpacityStyle"/>

    </v-main>

    <PageFoot
        id="page-foot"
        body="基于pilipala构建 - Field Theme Designed By Thaumy<br>
              Thaumy'Blog 2016-2023<br>
              <a href='http://beian.miit.gov.cn/'
                 target='_blank'
                 style='color: rgba(255,255,255,0.6);
                        font-size: 0.7rem;
                        text-decoration: none;'
              >鲁ICP备2021005067</a>"
        style="margin: 20px;margin-top: 80px"
        :style="pageFootOpacityStyle"
    />
  </v-app>
</template>

<script lang="ts" setup>
import {onMounted, ref} from 'vue'
import GoUpBtn from "@/components/btn/GoUpBtn.vue";
import PageFoot from "@/components/common/PageFoot.vue";
import {Post} from "@/scripts/type/post";
import PostZone from "@/components/PostZone/PostZone.vue";
import Menu from "@/components/Menu/Menu.vue";
import MenuBar from "@/components/MenuBar/MenuBar.vue";
import {Comment} from "@/scripts/type/comment";
import {PostCardData} from "@/components/PostZone/type";
import {Topic} from "@/scripts/type/topic";
import CommentZone from "@/components/CommentZone/CommentZone.vue";
import FCard from "@/components/field/f-card.vue";
import SwitchBtn from "@/components/btn/SwitchBtn.vue";

const commonOpacityStyle = ref({
  opacity: 1,
  'pointer-events': 'unset',
  transition: 'all 0.2s ease'
})

const pageFootOpacityStyle = ref({
  opacity: 1,
  'pointer-events': 'none',
  transition: 'all 0.2s ease'
})

const comments = [
  <Comment>{
    id: 1000,
    user: '小品',
    body: '这是一条评论！',
    replyTo: null,
    siteUrl: 'https://www.thaumy.cn',
    avatarUrl: null,
    createTime: new Date('2022-08-11T01:34:00')
  },
  <Comment>{
    id: 1001,
    user: 'Thaumy',
    body:
        '贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴' +
        '贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴' +
        '贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴',
    replyTo: 1000,
    siteUrl: 'https://www.thaumy.cn',
    avatarUrl: null,
    createTime: new Date('2022-08-12T02:12:00')//"22-08-12 | 02:12"
  },
  <Comment>{
    id: 1002,
    user: '小品',
    body: '不许贴贴！',
    replyTo: 1000,
    siteUrl: 'https://www.thaumy.cn',
    avatarUrl: null,
    createTime: new Date('2022-08-13T03:51:00')//"22-08-13 | 03:51"
  },
  <Comment>{
    id: 1003,
    user: 'Fubuki',
    body: 'moemoemoemoemoemoemoemoemoemoemoemoe',
    replyTo: null,
    siteUrl: null,
    avatarUrl: null,
    createTime: new Date('2022-08-13T05:15:00')//"22-08-13 | 05:15"
  }]

const menu_posts = ref([
  <Post>{id: 12345, title: '首页'},
  <Post>{id: 12346, title: '摸摸鱼'},
  <Post>{id: 12347, title: '追番'},
  <Post>{id: 12348, title: '看书'},
  <Post>{id: 12349, title: '写代码'},
  <Post>{id: 12350, title: '睡大觉'}
])
/*
              '<img src="1/src/assets/akane.jpg"/>
              <h1>相生茜 Aioi Akane</h1>
              <h2>简介</h2>
              <blockquote>
                井底之蛙，不知大海之宽阔，却晓天空之蓝。
              </blockquote>
              31岁。相生葵的姐姐。慎之介以前的恋人。<br>
              通勤时使用自家用车接送葵。工作是市民生活课。<br>
              被葵称为「あか姉（ねえ）」（姐姐和茜的变体）。<br>
              从高中时期就一直戴著眼镜。
              <h2>经历</h2>
              <li>高中时代时常看慎之介的乐团练习，做的饭团大多为葵喜欢吃的昆布，而非慎之介喜欢的。</li>
              <li>在父母因车祸双亡后，独自一人撑起家中的生活，照顾著葵，甚至放弃了与慎之介一起前往东京之事。在葵的眼里总是表现得完美无缺。（但也因此让葵觉得自己害了姐姐的梦想没能实现）</li>
              <li>实际上无论是做的料理、还是做的事情都下足了功夫，葵曾于厨房中找到茜的笔记。悲伤之事很少与茜谈到。</li>
              <li>知道一起工作的儿时玩伴中村正道喜欢自己，但由于现实面而没有戳破。</li>
              <li>
                13年后与回到镇里的慎之介再次相遇，于彩排前曾与慎之介在阶梯处谈心，并要求对方唱慎之介得出道曲《知道天空有多蓝的人啊》，同时指出是葵经常听的歌，在慎之介离开后哭了出来，被一堂偷看的葵表示「从过去到现在，能让她笑得这么开心以及哭得这么难过的，一直都是慎之介」。
              </li>
              <li>为了找新渡户团吉掉的项链而遇上了地震，前往的地方有些微土石流。</li>
              <li>平安找到项链后，遇到了前来的「慎之」，接受现况后与其谈心，随后被慎之抱出洞口。</li>
              <li>在见到慎之介与葵时，第一个反应是前往拥抱葵。</li>
              <li>后与慎之介以及慎之座车返回，途中表示自己还未放弃梦想，并与慎之介下了约定。「慎之」也在不久后从后座消失。</li>
              <li>多年后与慎之介举行婚礼。</li>

              <br>链接测试
              <a href="https://www.thaumy.cn">这里是THAUMY的博客！</a>
              <br>小块代码<code>rm -rf /*</code>
              <br>表格渲染
              <table id="post_comic_list">
                <thead>
                <th>TODO</th>
                <th>//</th>
                <th>优先级</th>
                </thead>
                <tr>
                  <td>思考人生</td>
                  <td>去码头整点薯条。</td>
                  <td>⭐⭐⭐⭐⭐</td>
                </tr>
                <tr>
                  <td>写代码</td>
                  <td>pilipala又出bug了！</td>
                  <td>⭐⭐⭐⭐</td>
                </tr>
                <tr>
                  <td>看番</td>
                  <td>😄</td>
                  <td>⭐⭐⭐</td>
                </tr>
                <tr>
                  <td>睡觉觉</td>
                  <td>只有弱者才睡觉！</td>
                  <td>⭐⭐</td>
                </tr>
              </table>

              代码高亮
              <pre><code class="language-fsharp">let HelloField() : unit -> unit =
  Console.WriteLine "HelloField!"</code></pre>'
*/

//TODO view count chip? impl
const post_data = ref([
  <PostCardData>{
    post: <Post>{
      id: 12345,
      body: "这是一条笔记，适合短文本发布。",
      createTime: new Date('2022-08-19T08:24:00'),
      modifyTime: new Date('2022-08-19T08:24:00')
    },
    coverUrl: null,
    summary: null,
    viewCount: 0,
    commentCount: 8,
    topics: [{name: '花花'}, {name: '草草'}, {name: '云云'}],
    isSchedule: false,
    isArchive: false,
  },
  <PostCardData>{
    post: <Post>{
      id: 12346,
      title: '氛',
      createTime: new Date('2022-08-12T08:24:00'),
      modifyTime: new Date('2022-08-14T08:24:00')
    },
    coverUrl: null,
    summary: "Make a simple, intuitive UI@@@@@@@@@@@@@@@@@@",
    viewCount: 0,
    commentCount: 8,
    topics: <Topic[]>[],
    isSchedule: false,
    isArchive: false,
  },
  <PostCardData>{
    post: <Post>{
      id: 12347,
      title: '氛',
      body: "This is Field V4!",
      createTime: new Date('2022-08-16T08:24:00'),
      modifyTime: new Date('2022-08-18T08:24:00'),
    },
    coverUrl: null,
    summary: "Make a simple, intuitive UI@@@@@@@@@@@@@@@@@@",
    commentCount: 8,
    topics: <Topic[]>[],
    isSchedule: true,
    isArchive: true,
  },
  <PostCardData>{
    post: <Post>{
      id: 12347,
      title: '空の青さを知る人よ@@@@@@@@@@@@@@@@@@',
      createTime: new Date('2022-08-20T08:00:00'),
      modifyTime: new Date('2022-08-20T10:00:01'),
    },
    coverUrl: "1/src/assets/akane_cover.png",
    summary: "《知晓天空之蓝的人啊》",
    commentCount: 18,
    isSchedule: true,
    isArchive: true,
    topics: [{name: '花花'}, {name: '草草'}, {name: '云云'}]
  },
  <PostCardData>{
    post: <Post>{
      id: 12347,
      title: '空の青さを知る人よ@@@@@@@@@@@@@@@@@@',
      body: '<img src="1/src/assets/akane.jpg" alt=""/>\n              <h1>相生茜 Aioi Akane</h1>\n              <h2>简介</h2>\n              <blockquote>\n                井底之蛙，不知大海之宽阔，却晓天空之蓝。\n              </blockquote>\n              31岁。相生葵的姐姐。慎之介以前的恋人。<br>\n              通勤时使用自家用车接送葵。工作是市民生活课。<br>\n              被葵称为「あか姉（ねえ）」（姐姐和茜的变体）。<br>\n              从高中时期就一直戴著眼镜。\n              <h2>经历</h2>\n              <li>高中时代时常看慎之介的乐团练习，做的饭团大多为葵喜欢吃的昆布，而非慎之介喜欢的。</li>\n              <li>在父母因车祸双亡后，独自一人撑起家中的生活，照顾著葵，甚至放弃了与慎之介一起前往东京之事。在葵的眼里总是表现得完美无缺。（但也因此让葵觉得自己害了姐姐的梦想没能实现）</li>\n              <li>实际上无论是做的料理、还是做的事情都下足了功夫，葵曾于厨房中找到茜的笔记。悲伤之事很少与茜谈到。</li>\n              <li>知道一起工作的儿时玩伴中村正道喜欢自己，但由于现实面而没有戳破。</li>\n              <li>\n                13年后与回到镇里的慎之介再次相遇，于彩排前曾与慎之介在阶梯处谈心，并要求对方唱慎之介得出道曲《知道天空有多蓝的人啊》，同时指出是葵经常听的歌，在慎之介离开后哭了出来，被一堂偷看的葵表示「从过去到现在，能让她笑得这么开心以及哭得这么难过的，一直都是慎之介」。\n              </li>\n              <li>为了找新渡户团吉掉的项链而遇上了地震，前往的地方有些微土石流。</li>\n              <li>平安找到项链后，遇到了前来的「慎之」，接受现况后与其谈心，随后被慎之抱出洞口。</li>\n              <li>在见到慎之介与葵时，第一个反应是前往拥抱葵。</li>\n              <li>后与慎之介以及慎之座车返回，途中表示自己还未放弃梦想，并与慎之介下了约定。「慎之」也在不久后从后座消失。</li>\n              <li>多年后与慎之介举行婚礼。</li>\n\n              <br>链接测试\n              <a href="https://www.thaumy.cn">这里是THAUMY的博客！</a>\n              <br>小块代码<code>rm -rf /*</code>\n              <br>表格渲染\n              <table id="post_comic_list">\n                <thead>\n                <th>TODO</th>\n                <th>//</th>\n                <th>优先级</th>\n                </thead>\n                <tr>\n                  <td>思考人生</td>\n                  <td>去码头整点薯条。</td>\n                  <td>⭐⭐⭐⭐⭐</td>\n                </tr>\n                <tr>\n                  <td>写代码</td>\n                  <td>pilipala又出bug了！</td>\n                  <td>⭐⭐⭐⭐</td>\n                </tr>\n                <tr>\n                  <td>看番</td>\n                  <td>😄</td>\n                  <td>⭐⭐⭐</td>\n                </tr>\n                <tr>\n                  <td>睡觉觉</td>\n                  <td>只有弱者才睡觉！</td>\n                  <td>⭐⭐</td>\n                </tr>\n              </table>\n\n              代码高亮\n              <pre><code class="language-fsharp">let HelloField() : unit -> unit =\n  Console.WriteLine "HelloField!"</code></pre>',
      createTime: new Date('2022-08-20T08:00:00'),
      modifyTime: new Date('2022-08-20T10:00:01'),
    },
    coverUrl: "1/src/assets/akane_cover.png",
    summary: "《知晓天空之蓝的人啊》",
    commentCount: 18,
    topics: [{name: '花花'}, {name: '草草'}, {name: '云云'}],
    isSchedule: true,
    isArchive: true,
  },
]);

/* 滑到底部查看壁纸 */
/*
onMounted(() => {
  const handler = (entries: IntersectionObserverEntry[]) => {
    entries.forEach(entry => {
      if (entry.intersectionRatio > 0.9) {
        commonOpacityStyle.value.opacity = 0
        commonOpacityStyle.value["pointer-events"] = 'none'
        pageFootOpacityStyle.value.opacity = 1
        pageFootOpacityStyle.value["pointer-events"] = 'unset'
      } else if (entry.intersectionRatio < 0.1) {
        commonOpacityStyle.value.opacity = 1
        commonOpacityStyle.value["pointer-events"] = 'unset'
        pageFootOpacityStyle.value.opacity = 0
        pageFootOpacityStyle.value["pointer-events"] = 'none'
      }
    })
  }

  let target =
      document.querySelector('#page-foot')
  if (target)
    new IntersectionObserver(handler, {
      root: null,
      rootMargin: '0px',
      threshold: [0, 1]
    }).observe(target)
})*/
</script>

<style lang="stylus" scoped>
.main
  background url("@/assets/pc.jpg")
  background-size cover
  background-position center
  background-attachment fixed

.content
  margin auto
  max-width 1160px

/* 屏幕宽度 [ 1001  + ) */
@media (min-width 1001px)
  .content
    padding-top 8px
    width 99%

/* 屏幕宽度 [ 601  1000 ] */
@media (min-width 601px) and (max-width 1000px)
  .content
    padding 7px
    padding-top 57px

/* 屏幕宽度 ( -  600 ] */
@media screen and (max-width 600px)
  .content
    padding-top 57px

/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px)
  .right-part
    width 76%
    max-width 1100px

/* 屏幕宽度 ( - , 1000 ] */
@media (max-width: 1000px)
  .right-part
    width 100%

/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px)
  .left-part
    width 23%
    min-width 230px
    max-width 270px
    position fixed

/* 屏幕宽度 ( - , 1000 ] */
@media screen and (max-width: 1000px)
  .left-part
    display none
</style>
