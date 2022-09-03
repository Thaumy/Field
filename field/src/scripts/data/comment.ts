import {Comment} from "@/scripts/type/comment";

export function getCommentById(id: Number) {
    return comments.filter(x => x.id === id)[0]
}

export function getCommentByIdIn(id: Number, comments: Comment[]) {
    return comments.filter(x => x.id === id)[0]
}

export const comments = [
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
        replyTo: 12347,
        siteUrl: null,
        avatarUrl: '/src/assets/comment_user_avatars/kurumi.jpg',
        createTime: new Date('2022-08-13T05:15:00')//"22-08-13 | 05:15"
    }]

