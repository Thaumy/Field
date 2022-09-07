import {ref} from "vue"
import {Post} from "@/scripts/type/post"
import {PostFullData} from "@/components/PostCard/type"
import {Topic} from "@/scripts/type/topic"
import {Comment} from "@/scripts/type/comment"

//TODO view count chip? impl
export const post_items = ref([
    <PostFullData>{
        post: <Post>{
            id: 12343,
            body: "这是一条笔记，适合短文本发布。(摸摸鱼)",
            createTime: new Date('2022-09-01T08:24:00'),
            modifyTime: new Date('2022-09-91T08:34:00')
        },
        coverUrl: null,
        summary: null,
        viewCount: 1,
        comments: [
            <Comment>{
                id: 1000,
                user: '小品',
                body: '这是一条评论！',
                replyTo: 12343,
                siteUrl: 'https://www.thaumy.cn',
                avatarUrl: '/src/assets/comment_user_avatars/kurumi.jpg',
                createTime: new Date('2022-08-11T01:34:00')
            },
        ],//8
        isSchedule: false,
        isArchive: false,
        topics: [{name: '花花'}, {name: '草草'}, {name: '云云'}],
    },
    <PostFullData>{
        post: <Post>{
            id: 12344,
            title: '氛',
            body: '(追番)',
            createTime: new Date('2022-08-12T08:24:00'),
            modifyTime: new Date('2022-08-14T08:24:00')
        },
        coverUrl: null,
        summary: "Make a simple, intuitive UI.",
        viewCount: 10,
        comments: [
            <Comment>{
                id: 1000,
                user: '小品',
                body: '这是一条评论！',
                replyTo: 12344,
                siteUrl: 'https://www.thaumy.cn',
                avatarUrl: '/src/assets/comment_user_avatars/kurumi.jpg',
                createTime: new Date('2022-08-11T01:34:00')
            },
            <Comment>{
                id: 1001,
                user: 'Thaumy',
                body:
                    '贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴' +
                    '贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴',
                replyTo: 1000,
                siteUrl: 'https://www.thaumy.cn',
                avatarUrl: '/src/assets/comment_user_avatars/kurumi.jpg',
                createTime: new Date('2022-08-12T02:12:00')//"22-08-12 | 02:12"
            },
            <Comment>{
                id: 1002,
                user: '小品',
                body: '不许贴贴！',
                replyTo: 1001,
                siteUrl: 'https://www.thaumy.cn',
                avatarUrl: '/src/assets/comment_user_avatars/kurumi.jpg',
                createTime: new Date('2022-08-13T03:51:00')//"22-08-13 | 03:51"
            },
            <Comment>{
                id: 1003,
                user: 'Fubuki',
                body: 'moemoemoemoemoemoemoemoemoemoemoemoe',
                replyTo: 12344,
                siteUrl: null,
                avatarUrl: '/src/assets/comment_user_avatars/kurumi.jpg',
                createTime: new Date('2022-08-13T05:15:00')//"22-08-13 | 05:15"
            }],//8
        topics: <Topic[]>[],
        isSchedule: false,
        isArchive: false,
    },
    <PostFullData>{
        post: <Post>{
            id: 12345,
            title: '氛',
            body: "This is Field V4!Aaz(看书)",
            createTime: new Date('2022-08-21T08:24:00'),
            modifyTime: new Date('2022-09-01T08:34:00')
        },
        coverUrl: null,
        summary: "Make a simple, intuitive UI.",
        viewCount: 0,
        comments: [
            <Comment>{
                id: 1000,
                user: '小品',
                body: '这是一条评论！',
                replyTo: 12345,
                siteUrl: 'https://www.thaumy.cn',
                avatarUrl: '/src/assets/comment_user_avatars/kurumi.jpg',
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
                avatarUrl: '/src/assets/comment_user_avatars/thaumy.png',
                createTime: new Date('2022-08-12T02:12:00')//"22-08-12 | 02:12"
            },
            <Comment>{
                id: 1002,
                user: '小品',
                body: '不许贴贴！',
                replyTo: 1001,
                siteUrl: 'https://www.thaumy.cn',
                avatarUrl: '/src/assets/comment_user_avatars/kurumi.jpg',
                createTime: new Date('2022-08-13T03:51:00')//"22-08-13 | 03:51"
            },
            <Comment>{
                id: 1003,
                user: 'Mai',
                body: 'moemoemoemoemoemoemoemoemoemoemoemoe',
                replyTo: 12345,
                siteUrl: null,
                avatarUrl: '/src/assets/comment_user_avatars/mai.jpg',
                createTime: new Date('2022-08-13T05:15:00')//"22-08-13 | 05:15"
            }],//8
        topics: <Topic[]>[],
        isSchedule: true,
        isArchive: true,
    },
    <PostFullData>{
        post: <Post>{
            id: 12346,
            title: '空の青さを知る人よ(睡大觉)',
            body:
                '<img src="/src/assets/akane.jpg" alt=""/><h1>相生茜 Aioi Akane</h1><h2>简介</h2><blockquote>井底之蛙，不知大海之宽阔，却晓天空之蓝。</blockquote>31岁。相生葵的姐姐。慎之介以前的恋人。<br>通勤时使用自家用车接送葵。工作是市民生活课。<br>被葵称为「あか姉（ねえ）」（姐姐和茜的变体）。<br>从高中时期就一直戴著眼镜。' +
                '<h2>经历</h2>' +
                '<ul><li>高中时代时常看慎之介的乐团练习，做的饭团大多为葵喜欢吃的昆布，而非慎之介喜欢的。</li><li>在父母因车祸双亡后，独自一人撑起家中的生活，照顾著葵，甚至放弃了与慎之介一起前往东京之事。在葵的眼里总是表现得完美无缺。（但也因此让葵觉得自己害了姐姐的梦想没能实现）</li><li>实际上无论是做的料理、还是做的事情都下足了功夫，葵曾于厨房中找到茜的笔记。悲伤之事很少与茜谈到。</li><li>知道一起工作的儿时玩伴中村正道喜欢自己，但由于现实面而没有戳破。</li><li>13年后与回到镇里的慎之介再次相遇，于彩排前曾与慎之介在阶梯处谈心，并要求对方唱慎之介得出道曲《知道天空有多蓝的人啊》，同时指出是葵经常听的歌，在慎之介离开后哭了出来，被一堂偷看的葵表示「从过去到现在，能让她笑得这么开心以及哭得这么难过的，一直都是慎之介」。</li><li>为了找新渡户团吉掉的项链而遇上了地震，前往的地方有些微土石流。</li></ul>' +
                '<ol><li>平安找到项链后，遇到了前来的「慎之」，接受现况后与其谈心，随后被慎之抱出洞口。</li><li>在见到慎之介与葵时，第一个反应是前往拥抱葵。</li><li>后与慎之介以及慎之座车返回，途中表示自己还未放弃梦想，并与慎之介下了约定。「慎之」也在不久后从后座消失。</li><li>多年后与慎之介举行婚礼。</li></ol><br>' +
                '链接测试<a href="https://www.thaumy.cn">这里是THAUMY的博客！</a><br>' +
                '小块代码<code>rm -rf /*</code><br>' +
                '表格渲染<table id="post_comic_list"><thead><th>TODO</th><th>//</th><th>优先级</th></thead><tr><td>思考人生</td><td>去码头整点薯条。</td><td>⭐⭐⭐⭐⭐</td></tr><tr><td>写代码</td><td>pilipala又出bug了！</td><td>⭐⭐⭐⭐</td></tr><tr><td>看番</td><td>😄</td><td>⭐⭐⭐</td></tr><tr><td>睡觉觉</td><td>只有弱者才睡觉！</td><td>⭐⭐</td></tr></table>' +
                '代码高亮<pre><code class="language-fsharp">let HelloField() : unit -> unit =\n  Console.WriteLine "HelloField!"</code></pre>' +
                '键盘字符<br><kbd>ctrl</kbd>+<kbd>f</kbd><br>' +
                'LaTeX single-line<br><span class="math">$Y=λf.((λx.f(x\\ x))\\ (λx.f(x\\ x)))$</span><br>' +
                'LaTeX multi-line<br><span class="math">$$\\begin{eqnarray}\\quad Y\\ g&=&(λx.g(x\\ x))\\ (λx.g(x\\ x))\\\\&=&g((λx.g(x\\ x))\\ (λx.g(x\\ x)))\\\\&=&g(Y\\ g)\\end{eqnarray}$$</span>',
            createTime: new Date('2022-08-20T08:00:00'),
            modifyTime: new Date('2022-08-20T10:00:01'),
        },
        coverUrl: "/src/assets/akane_cover.png",
        summary: "《知晓天空之蓝的人啊》",
        viewCount: 114514,
        comments: [
            <Comment>{
                id: 1000,
                user: '小品',
                body: '这是一条评论！',
                replyTo: 12346,
                siteUrl: 'https://www.thaumy.cn',
                avatarUrl: '/src/assets/comment_user_avatars/kurumi.jpg',
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
                avatarUrl: '/src/assets/comment_user_avatars/thaumy.png',
                createTime: new Date('2022-08-12T02:12:00')//"22-08-12 | 02:12"
            },
            <Comment>{
                id: 1002,
                user: '小品',
                body: '不许贴贴！',
                replyTo: 1001,
                siteUrl: 'https://www.thaumy.cn',
                avatarUrl: '/src/assets/comment_user_avatars/kurumi.jpg',
                createTime: new Date('2022-08-13T03:51:00')//"22-08-13 | 03:51"
            },
            <Comment>{
                id: 1003,
                user: 'Fubuki',
                body: 'moemoemoemoemoemoemoemoemoemoemoemoe',
                replyTo: 12346,
                siteUrl: null,
                avatarUrl: '/src/assets/comment_user_avatars/kurumi.jpg',
                createTime: new Date('2022-08-13T05:15:00')//"22-08-13 | 05:15"
            }],//18
        topics: [{name: '花花'}, {name: '草草'}, {name: '云云'}],
        isSchedule: true,
        isArchive: true,
        prevTitle: "你不知道的114514个单身技巧",
        nextTitle: "构建pilipala应用的最佳实践"
    },
    <PostFullData>{
        post: <Post>{
            id: 12347,
            title: '空の青さを知る人よ',
            body: 'no body!!',
            createTime: new Date('2022-08-20T08:00:00'),
            modifyTime: new Date('2022-08-20T10:00:01'),
        },
        //coverUrl: "/src/assets/akane_cover.png",
        summary: "《知晓天空之蓝的人啊》",
        viewCount: 114514,
        comments: [
            <Comment>{
                id: 1000,
                user: '小品',
                body: '这是一条评论！',
                replyTo: 12347,
                siteUrl: 'https://www.thaumy.cn',
                avatarUrl: '/src/assets/comment_user_avatars/kurumi.jpg',
                createTime: new Date('2022-08-11T01:34:00')
            },
            <Comment>{
                id: 1001,
                user: 'Thaumy',
                body:
                    '贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴' +
                    '贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴',
                replyTo: 1000,
                siteUrl: 'https://www.thaumy.cn',
                avatarUrl: '/src/assets/comment_user_avatars/kurumi.jpg',
                createTime: new Date('2022-08-12T02:12:00')//"22-08-12 | 02:12"
            },
            <Comment>{
                id: 1002,
                user: '小品',
                body: '不许贴贴！',
                replyTo: 1001,
                siteUrl: 'https://www.thaumy.cn',
                avatarUrl: '/src/assets/comment_user_avatars/kurumi.jpg',
                createTime: new Date('2022-08-13T03:51:00')//"22-08-13 | 03:51"
            },
            <Comment>{
                id: 1003,
                user: 'Megumi',
                body: 'moemoemoemoemoemoemoemoemoemoemoemoe',
                replyTo: 12347,
                siteUrl: null,
                avatarUrl: '/src/assets/comment_user_avatars/megumi.jpg',
                createTime: new Date('2022-08-13T05:15:00')//"22-08-13 | 05:15"
            }],//18
        isSchedule: true,
        isArchive: true,
        topics: [{name: '花花'}, {name: '草草'}, {name: '云云'}]
    },
]);
