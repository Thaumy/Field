<template>
  <div id="CardCol" class="R">
    <div class="Col">
      <!--<NoteCard/>-->
      <PostCard/>
      <CoBox/>
      <CommentList/>
      <NoCommentTip/>
      <WarningTip/>
      <LockingTip/>
      <div id="column_bottom"></div>
      <CommentBox/>
    </div>
  </div>
</template>

<script>
//import NoteCard from "@/components/NoteCard";
import NoCommentTip from "@/components/tip/NoCommentTip";
import WarningTip from "@/components/tip/WarningTip";
import LockingTip from "@/components/tip/LockingTip";
import PostCard from "@/components/box/PostCard";
import CoBox from "@/components/box/CoBox";
import CommentList from "@/components/CommentList";
import CommentBox from "@/components/box/CommentBox";

export default {
  name: "CardCol",
  components: {
    CommentBox,
    CommentList,
    CoBox,
    NoCommentTip,
    WarningTip,
    LockingTip,
    //NoteCard,
    PostCard,
  }
}
</script>

<style scoped>

/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px) {
  #CardCol {
    width: 76%;
    max-width: 1100px;
  }

  #CardCol .Card > .contain > .Title {
    padding-top: 12px;
  }
}

/* 屏幕宽度 ( - , 1000 ] */
@media (max-width: 1000px) {
  #CardCol {
    width: 100%;
  }
}

#CardCol {
  padding-bottom: 100vh;
}

#CardCol > .Col {
  width: 100%;
  transition: all 1s ease;
}


</style>