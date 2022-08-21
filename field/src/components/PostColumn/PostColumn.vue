<template>
  <div>

    <div class="CardCol float-right">
      <DetailCard
          comment-count="8"
          body="这是一条笔记，适合短文本发布。"
          :create-time="new Date('2022-08-19T08:24:00')"
          :modify-time="new Date('2022-08-19T08:24:00')"
      />

      <DetailCard
          title="氛"
          summary="Make a simple, intuitive UI"
          comment-count="8"
          :create-time="new Date('2022-08-12T08:24:00')"
          :modify-time="new Date('2022-08-14T08:24:00')"
      />

      <DetailCard
          title="氛"
          summary="Make a simple, intuitive UI"
          comment-count="8"
          is-schedule="true"
          is-archive="true"
          body="This is Field V4!"
          :create-time="new Date('2022-08-16T08:24:00')"
          :modify-time="new Date('2022-08-18T08:24:00')"
          :topics="['花花','草草','云云']"
      />

      <DetailCard
          coverUrl='/src/assets/akane_cover.png'
          title="空の青さを知る人よ"
          summary="《知晓天空之蓝的人啊》"
          comment-count="18"
          :topics="['花花','草草','云云']"
          :create-time="new Date('2022-08-20T08:00:00')"
          :modify-time="new Date('2022-08-20T10:00:01')"
      />

      <DetailCard
          coverUrl='/src/assets/akane_cover.png'
          title="空の青さを知る人よ"
          summary="《知晓天空之蓝的人啊》"
          :create-time="new Date('2022-08-20T08:00:00')"
          :modify-time="new Date('2022-08-20T10:00:01')"
          is-schedule="true"
          is-archive="true"
          :topics="['花花','草草','云云']"
          body=
              '<img src="./src/assets/akane.jpg"/>
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

          prev-title="你不知道的114514个单身技巧" next-title="构建pilipala应用的最佳实践"
      />

      <!--
      <CoBox user-name="Thaumy" modify-time="19.04.05" hash-sign="004C01E"
             create-date="19-07-12"
             view-count="12345"
             comment-count="12345"
             star-count="12345"
             create-time="周四 07:12"
             archive="氛归档"
             label="氛标签"
      />

      <div id="column_bottom"></div>

      <NoCommentTip/>
      <WarningTip/>
      <LockingTip/>
-->
      <CommentColumn/>

    </div>
  </div>
</template>

<script lang="ts">
import {defineComponent} from 'vue'

import CoBox from "@/components/box/CoBox.vue";
import WarningTip from "@/components/tip/WarningTip.vue";
import LockingTip from "@/components/tip/LockingTip.vue";
import NoCommentTip from "@/components/tip/NoCommentTip.vue";
import CommentColumn from "@/components/CommentColumn/CommentColumn.vue";
import DetailCard from "./DetailCard.vue";
import NoteCard from "./NoteCard.vue";
import PreviewCard from "./PreviewCard.vue";

export default defineComponent({
  name: "PostColumn",
  components: {
    CommentColumn,
    CoBox,
    NoCommentTip,
    WarningTip,
    LockingTip,
    NoteCard,
    DetailCard,
    PreviewCard,
  }
})
</script>

<style scoped>
</style>

<style scoped>
/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px) {
  .CardCol {
    width: 76%;
    max-width: 1100px;
  }
}

/* 屏幕宽度 ( - , 1000 ] */
@media (max-width: 1000px) {
  .CardCol {
    width: 100%;
  }
}
</style>