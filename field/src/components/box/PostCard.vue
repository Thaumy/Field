<template>
  <div class="Card M bE-black bRds">
    <div onclick="up()" class="contain cur bRds">
      <div class="NoteContent bRds">
        这是一条笔记，适合短文本发布。
      </div>
    </div>
  </div>

  <div class="Card M bE-black bRds">

    <div onclick="up()" class="contain cur">
      <img class="pXL" src="http://thblog-img.test.upcdn.net/md-img/氛V2/field2cg.jpg"/>
      <div class="Title">氛</div>
      <div class="Summary">Make a simple, intuitive UI</div>
    </div>

    <AtBox createTime="19-07-12" viewCount="12345" commentCount="12345" starCount="12345"/>
  </div>

  <div class="Card M bE-black bRds">

    <div onclick="up()" class="contain cur">

      <img class="pXL" id="welcom_pic"/>
      <component :is="'script'">
        let images = ['http://thblog-img.test.upcdn.net/ui-background/bg_1.jpg',
        'http://thblog-img.test.upcdn.net/ui-background/bg_2.jpg',
        'http://thblog-img.test.upcdn.net/ui-background/bg_3.jpg',
        'http://thblog-img.test.upcdn.net/ui-background/bg_4.jpg'
        ];
        document.getElementById("welcom_pic").src = images[Math.floor(Math.random() * images.length)];
      </component>
      <div class="Title">PILIPALA BETA8</div>
      <div class="Summary">信的开头</div>
    </div>

    <AtBox createTime="19-07-12" viewCount="12345" commentCount="12345" starCount="12345"/>
  </div>

  <div class="Card M bE-black bRds">
    <div class="contain bRds">
      <div class="Title">四宫辉夜</div>
      <div class="Summary">Shinomiya Kaguya</div>
      <ScheduleTip/>
      <ArchiveTip/>
      <ReadTimeTip/>
      <div class="Content markdown-body">

        <img class="pM" src="http://thblog-img.test.upcdn.net/md-img/Kaguya_winter.jpg"/>

        <h1>四宮輝夜 Shinomiya Kaguya</h1>
        <h2>简介</h2>
        <blockquote>
          四宫辉夜是秀知院学园高中部2年A班学生，学生会副会长。是总资产200兆万亿日元、旗下子公司破千、被视为四大财阀之一的四宫集团的大小姐，有三个哥哥。AAA
        </blockquote>
        学业优秀，是一个在茶道、花道、舞蹈、古筝、合气道、薙刀、弓道等方面皆有出色成绩的全能型天才，其中弓道在二年级就升到了四段，初中便拿到全国大赛一等奖，曾在决胜阶段连续射中十次,但升入高中后因比赛与圣诞节冲突便再也没有参加。<br>
        住在四宫家位于东京的别墅，出门有专车接送、便当是专属厨师制作，是个“盒中的女孩（箱入り娘）”，过着与世俗无缘的生活的同时很向往庶民的生活，是个IT白痴性知识也极度缺乏。<br>
        以大约一月一个的速度被人告白。<br>
        非常适合猫耳。
        <h2>性格</h2>
        在四宫家的教育下，是一个利己主义者，同时对自己立下的规矩绝不违背。总是不自觉的露出看低别人的表情。<br>
        因性格冰冷而被当成难以靠近的冰山美人、深闺公主，在加入学生会后渐渐变得温柔和沙雕，少女心的一面渐渐多了起来。<br>
        自尊心极高，喜欢白银御行和他凶狠的眼神熬夜的黑眼圈，一直不愿承认。“但喜欢的话一定是真爱。”<br>
        经常主动采取措施逼迫白银御行告白，但常常被藤原千花干扰。到后来甚至会太喜欢白银御行得上“恋心病”。<br>
        嫉妒心极强，非常担忧白银御行的女性朋友增多。<br>
        生病时会变得很爱撒娇，但是痊愈后会将这个事情完全忘记。如白银去探病时，直接被辉夜逆推，但辉夜病好之后发现白银在她的床上时，是立刻恢复元气，将白银踹离她的闺房。不过其实这期间白银根本没有做出逾矩的事情，很单纯的只是因睡眠不足而睡着而已。
        <br><br>
        <a href="www.baidu.com">baidu链接测试</a>
        <code>rm -rf /*</code>
        表格测试

        <table id="post_comic_list">

          <thead>
          <th>番名</th>
          <th>列</th>
          <th>评级</th>
          </thead>
          <tr>
            <td>辉夜大小姐想让我告白</td>
            <td>列</td>
            <td>⭐⭐⭐⭐⭐</td>
          </tr>
          <tr>
            <td>ALDNOAH.ZERO</td>
            <td>列</td>
            <td>⭐⭐⭐⭐</td>
          </tr>
          <tr>
            <td>埃罗芒阿老师</td>
            <td>列</td>
            <td>⭐⭐⭐</td>
          </tr>
          <tr>
            <td>轻音少女</td>
            <td>列</td>
            <td>⭐⭐</td>
          </tr>
          <tr>
            <td>头文字D</td>
            <td>列</td>
            <td>⭐</td>
          </tr>
        </table>

        高亮测试

        <pre v-hljs><code class="cs">public void HelloField()
{
    Console.WriteLine("HelloField!");
}</code></pre>

        <span class="mk-dt">20.08.30<span class="mk-ui"></span></span>引入了Gitalk作为评论模块（测试版本）
        <br><span class="mk-dt">20.08.02<span class="mk-ui"></span></span>进一步优化了分辨率兼容性
        <br><span class="mk-dt">20.07.30<span class="mk-ui"></span></span>微调了ui部分栏目的间隔
        <br><span class="mk-dt">20.05.09<span class="mk-updt"></span></span>CNZZ记录服务已恢复
        <br><span class="mk-dt">20.05.09<span class="mk-ui"></span></span>修复了因githack错误而导致的mrks和wrds标记样式丢失的问题
        <br><span class="mk-dt">20.04.30<span class="mk-updt"></span></span>氛：文章计划标签现可用
        <br><span class="mk-dt">20.04.30<span class="mk-updt"></span></span>多文章状态属性现可用（例如归档、计划、隐藏、禁用等等）
        测试结束
      </div>
      <div>
        <SwitchBtn/>
      </div>

    </div>
    <component :is="'script'">
      this.hljs.highlightAll();
    </component>
  </div>
</template>

<script>
import AtBox from "@/components/box/AtBox";
import ScheduleTip from "@/components/tip/ScheduleTip";
import ReadTimeTip from "@/components/tip/ReadTimeTip";
import ArchiveTip from "@/components/tip/ArchiveTip";
import SwitchBtn from "@/components/btn/SwitchBtn";

export default {
  name: "PostCard",
  components: {
    SwitchBtn,
    ScheduleTip,
    ArchiveTip,
    ReadTimeTip,
    AtBox
  }
}
</script>

<style scoped>

/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px) {
  .Card > .contain > .Title {
    padding-top: 12px;
  }
}

/* 屏幕宽度 ( - , 1000 ] */
@media (max-width: 1000px) {
  .Card > .contain > .Title {
    padding-top: 10px;
  }
}

.Card {
  /* 颜色模式 */
  background: rgba(40, 40, 40, 1.00);
}

.Card > .contain {
  /* 颜色模式 */
  background: rgba(30, 30, 30, 1.00);
}

.Card > .contain > .Title {
  /* 颜色模式 */
  color: rgba(240, 240, 240, 1.00);
}

.Card > .contain > .Summary {
  /* 颜色模式 */
  color: rgba(210, 210, 210, 1.00);
}

.Card > .contain > .Content {
  /* 颜色模式 */
  color: rgba(240, 240, 240, 1.00);
  background: rgba(30, 30, 30, 1.00);
}

.Card > .contain > .NoteContent {
  /* 颜色模式 */
  color: rgba(170, 170, 170, 1.00);
  background: rgba(30, 30, 30, 1.00);
}


.Card {
  width: 100%;

  overflow: hidden;
  /* 颜色模式 */
  background: rgba(40, 40, 40, 1.00);
}

.Card > .contain {
  overflow: hidden;
  width: 100%;
  border-top-left-radius: 4px;
  border-top-right-radius: 4px;
}

.Card > .contain > .Title {
  font-size: 24px;
  line-height: 24px;

  padding-left: 12px;
  padding-bottom: 8px;
}

.Card > .contain > img {
  border-top-left-radius: 3px;
  border-top-right-radius: 3px;
  margin-bottom: -5px;
}

.Card > .contain > .Summary {
  font-size: 15px;
  line-height: 20px;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;

  padding-left: 18px;
  padding-right: 18px;

  margin-bottom: 8px;
}

.Card > .contain > .Content {
  padding: 4px;
  padding-left: 8px;
  padding-right: 8px;

  font-size: 15px;
  line-height: 22px;
  letter-spacing: 1px;
  word-break: break-word;
}

.Card > .contain > .NoteContent {
  padding-top: 8px;
  padding-bottom: 10px;
  padding-left: 16px;
  padding-right: 16px;

  font-size: 16px;
  font-weight: 500;
  line-height: 28px;
  word-break: break-word;
}
</style>