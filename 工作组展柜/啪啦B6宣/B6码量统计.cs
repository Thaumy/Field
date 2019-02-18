SELECT
	`pala_text_index`.`text_id` AS `text_id`,
	`pala_text_index`.`text_mode` AS `text_mode`,
	`pala_text_index`.`text_type` AS `text_type` 
FROM
	`pala_text_index` 
WHERE
	( ( `pala_text_index`.`text_type` LIKE 'page' ) AND ( `pala_text_index`.`text_mode` = 'onshow' ) ) 
ORDER BY
	`pala_text_index`.`text_id` DESC
    SELECT
	`pala_text_index`.`text_id` AS `text_id`,
	`pala_text_index`.`text_mode` AS `text_mode`,
	`pala_text_index`.`text_type` AS `text_type` 
FROM
	`pala_text_index` 
WHERE
	( ( `pala_text_index`.`text_type` LIKE 'post' ) AND ( `pala_text_index`.`text_mode` = 'onshow' ) ) 
ORDER BY
	`pala_text_index`.`text_id` DESC
    SELECT
	`pala_text_main`.`text_id` AS `text_id`,
	`pala_text_main`.`text_title` AS `text_title`,
	`pala_text_main`.`text_summary` AS `text_summary`,
	`pala_text_main`.`text_content` AS `text_content` 
FROM
	`pala_text_main` 
ORDER BY
	`pala_text_main`.`text_id` DESC
    SELECT
	`pala_text_sub`.`text_id` AS `text_id`,
	`pala_text_sub`.`text_class` AS `text_class`,
	`pala_text_sub`.`text_editor` AS `text_editor`,
	`pala_text_sub`.`date_created` AS `date_created`,
	`pala_text_sub`.`date_changed` AS `date_changed`,
	`pala_text_sub`.`count_pv` AS `count_pv`,
	`pala_text_sub`.`count_comment` AS `count_comment`,
	`pala_text_sub`.`count_like` AS `count_like`,
	`pala_text_sub`.`tags` AS `tags`,
	`pala_text_sub`.`cover_url` AS `cover_url`,
	`pala_text_sub`.`strip_color` AS `strip_color` 
FROM
	`pala_text_sub` 
ORDER BY
	`pala_text_sub`.`text_id` DESC
    CREATE DEFINER=`pala_database_user`@`localhost` PROCEDURE `get_root`(IN `root_id` int)
BEGIN
	#Routine body goes here...
	
	SELECT
*
FROM
	`pala_root` 
WHERE
	( `pala_root`.`root_id` = root_id) ;
END
CREATE DEFINER=`pala_database_user`@`localhost` PROCEDURE `get_text>main`(IN `text_id` int)
BEGIN
	#Routine body goes here...
	
	SELECT
*
FROM
	`view_text>main` 
WHERE
	( `view_text>main`.`text_id` = text_id) ;
END
CREATE DEFINER=`pala_database_user`@`localhost` PROCEDURE `get_text>sub`(IN `text_id` int)
BEGIN
	#Routine body goes here...
	
	SELECT
*
FROM
	`view_text>sub` 
WHERE
	( `view_text>sub`.`text_id` = text_id) ;
END
CREATE DEFINER=`pala_database_user`@`localhost` FUNCTION `random$number`( start_num INTEGER, end_num INTEGER ) RETURNS int(11)
BEGIN

/* 在指定范围内抓取一个整数随机数并返回 */

RETURN FLOOR( start_num + RAND( ) * ( end_num - start_num + 1 ) );

END
CREATE DEFINER=`pala_database_user`@`localhost` PROCEDURE `random_text>index.page`(excluded_text_id INTEGER)
BEGIN

SELECT
*
FROM
    `pala_text_index`
WHERE
    ((`pala_text_index`.`text_id` >= ((((SELECT 
            MAX(`pala_text_index`.`text_id`)
        FROM
            `pala_text_index`) - (SELECT 
            MIN(`pala_text_index`.`text_id`)
        FROM
            `pala_text_index`)) * RAND()) + (SELECT 
            MIN(`pala_text_index`.`text_id`)
        FROM
            `pala_text_index`)))
						/* 展示可用 */
        AND (`pala_text_index`.`text_mode` = 'onshow')
				
				/* 排除不参与随机取样的文章 */
        AND (`pala_text_index`.`text_id` <> excluded_text_id)
				
				AND (`pala_text_index`.`text_type` = 'page'))
				/* 从第一位置取一条记录 */
LIMIT 0 , 1;

END
CREATE DEFINER=`pala_database_user`@`localhost` PROCEDURE `random_text>index.post`(excluded_text_id INTEGER)
BEGIN

SELECT
*
FROM
    `pala_text_index`
WHERE
    ((`pala_text_index`.`text_id` >= ((((SELECT 
            MAX(`pala_text_index`.`text_id`)
        FROM
            `pala_text_index`) - (SELECT 
            MIN(`pala_text_index`.`text_id`)
        FROM
            `pala_text_index`)) * RAND()) + (SELECT 
            MIN(`pala_text_index`.`text_id`)
        FROM
            `pala_text_index`)))
						/* 展示可用 */
        AND (`pala_text_index`.`text_mode` = 'onshow')
				
				/* 排除不参与随机取样的文章 */
        AND (`pala_text_index`.`text_id` <> excluded_text_id)
				
				AND (`pala_text_index`.`text_type` = 'post'))
				/* 从第一位置取一条记录 */
LIMIT 0 , 1;

END
begin

INSERT INTO `pala_database`.`pala_text_main` (`text_id`) VALUES (new.text_id);
INSERT INTO `pala_database`.`pala_text_sub` (`text_id`) VALUES (new.text_id);

end
begin

INSERT INTO `pala_database`.`pala_text_main` (`text_id`) VALUES (new.text_id);
INSERT INTO `pala_database`.`pala_text_sub` (`text_id`) VALUES (new.text_id);

end
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PILIPALA.Default" %>

<%Response.Redirect("~/pala_content/themes/fen/index.aspx?guide=1&text=1&row=0"); %>
<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="index.aspx.cs"
    Inherits="PILIPALA.pala_content.themes.fen.index"
    Debug="true"
    MasterPageFile="~/pala_content/index.master" %>

<%@ Import Namespace="PILIPALA.pala_services" %>
<%@ Import Namespace="PILIPALA.pala_content.themes.fen.services" %>

<asp:Content ID="head" ContentPlaceHolderID="indexHead" runat="Server">
    <meta http-equiv="Content-type" content="text/html;charset=UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=0.5, maximum-scale=2.0, user-scalable=yes" />
    <base target="_blank">
    <link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon">
    <style type="text/css">
        @import url("css/global.css");
        @import url("css/pic.css");
        @import url("css/basic.css");
        @import url("css/font.css");
        @import url("css/Box/Box.css");
        @import url("css/Btn/Btn.css");
    </style>
    <script src="js/jquery-1.12.4.min.js"></script>
    <script src="js/jquery.cookie.js"></script>
    <script src="js/index.js"></script>
</asp:Content>

<asp:Content ID="body" ContentPlaceHolderID="indexBody" runat="Server">
    <!-- ScriptManager -->
    <asp:ScriptManager ID="indexScriptManager" runat="server">
        <Services>
            <asp:ServiceReference Path="~/pala_services/SLS.asmx" />
        </Services>
    </asp:ScriptManager>
    <!-- ScriptManager -->

    <div class="siteBg"></div>

    <div class="main">

        <%if (Request.QueryString["guide"] == "1") {%>
        <div class="GuideCol">
            <div class="GuideBox">
                <div class="GuideHead fltL RdiuT">
                    <a onclick="goHome()">
                        <div class="UserIMG UserIMG_pic"></div>
                    </a>
                    <div class="SiteSummary">THAUMY的博客</div>
                    <div class="UserMotto fltL">签名</div>
                </div>
                <div class="GuideCardBox fltL RdiuB MagnB">
                    <%foreach (LibStructs.PaText PaText in List_text_index_page)
                {
                    LibStructs.PaText PaTextMain = SLS.getTextMain(PaText.text_id);
                    %>
                    <a onclick="showTxt(<%Response.Write(PaTextMain.text_id); %>)" class="GuideCard RdiuB RdiuT flx Tran">
                        <div class="GuideCardTitle flx_center"><%Response.Write(PaTextMain.text_title); %></div>
                    </a>
                    <%} %>
                    <div class="CopyrightMark">
                        <p>Thaumy的博客©2016-2019保留所有权利</p>
                        <p>基于pilipala开发</p>
                        <p>based on pilipala</p>
                        站点背景图来自
                    </div>
                </div>
            </div>
        </div>
        <%} %>

        <a href="#top" target="_self" class="GoUpBtn RdiuT RdiuB Tran fltL">
            <div class="arrow_up GoUpBtn_pic"></div>
        </a>

        <%if (Request.QueryString["text"] == "1") { %>
        <div class="TxtCol">
            <div>
                <%if (List_text_index_post != null)
                    {
                        foreach (LibStructs.PaText idxPaText in List_text_index_post)
                        {%>
                <%
                    LibStructs.PaText PaText = new LibStructs.PaText();
                    PaText = SLS.fill(SLS.getTextMain(idxPaText.text_id), SLS.getTextSub(idxPaText.text_id));
                %>
                <div class="TxtBox fltL RdiuB RdiuT Shadow MagnB">
                    <%if (PaText.cover_url != "")
                        {  %>
                    <a onclick="showTxt(<%Response.Write(PaText.text_id); %>)">
                        <img alt="" class="RdiuT TxtImg" src="<%Response.Write(PaText.cover_url); %>" />
                    </a>
                    <%} %>
                    <div class="BoxStrip <%Response.Write(indexServ.stripStyle(PaText.strip_color)); %>"></div>
                    <div class="TxtContent">
                        <a onclick="showTxt(<%Response.Write(PaText.text_id); %>)">
                            <div class="TxtBoxTitle"><%Response.Write(PaText.text_title); %></div>
                            <div class="TxtBoxSummary"><%Response.Write(PaText.text_summary); %></div>
                        </a>
                    </div>
                    <div class="fltL LabelBox LabelTxt LabelBg RdiuB">
                        <div class="LabelContent LabelTxt">
                            <div class="LBL_time"><%Response.Write(indexServ.extime(PaText.date_created)); %></div>
                            <div class="LBL_class"><%Response.Write(PaText.text_class); %></div>
                            <div class="LBL_comment RdiuB RdiuT">评论<%Response.Write(PaText.count_comment); %></div>
                            <div class="LBL_like RdiuB RdiuT"><%Response.Write(PaText.count_like);%></div>
                            <div class="LBL_pv">阅读<%Response.Write(PaText.count_pv); %></div>
                            <%foreach (string tag in indexServ.extags(PaText.tags))
                                { %>
                            <div class="LBL_tag"><%Response.Write(tag); %></div>
                            <%} %>
                        </div>
                    </div>
                </div>
                <%} %>
                <a class="LoadPostBtn  fltL Tran RdiuB RdiuT" onclick="loadTxt()">
                    <div class="arrow_down LoadPostBtn_pic"></div>
                </a>
                <%} %>
            </div>
            <div>
                <%if (List_text_index_post == null)
                    {%>
                <div class="TxtBox fltL RdiuB RdiuT Shadow MagnB">
                    <%if (PaText.cover_url != "")
                        {%>
                    <img alt="" class="RdiuT TxtImg" src="<%Response.Write(PaText.cover_url); %>" />
                    <%} %>
                    <div class="BoxStrip <%Response.Write(indexServ.stripStyle(PaText.strip_color)); %>"></div>
                    <div class="TxtContent">
                        <div class="TxtBoxTitle"><%Response.Write(PaText.text_title); %></div>
                        <div class="TxtBoxSummary"><%Response.Write(PaText.text_summary); %></div>
                        <div class="TxtBoxContent linked"><%Response.Write(PaText.text_content); %></div>
                    </div>
                    <div class="TxtCoMark fltL RdiuB RdiuT">
                        <div class="TxtCoMarkTime">此文本由 <%Response.Write(PaText.text_editor); %> 最后维护于 <%Response.Write(indexServ.extime(PaText.date_changed)); %></div>
                        <div class="TxtCoMarkId">文本序列号：<%Response.Write(PaText.text_id); %></div>
                        <div class="LabelBox fltL LabelTxt LabelBg RdiuB">
                            <div class="LabelContent LabelTxt">
                                <div class="LBL_time"><%Response.Write(indexServ.extime(PaText.date_created)); %></div>
                                <div class="LBL_class"><%Response.Write(PaText.text_class); %></div>
                                <a class="Btn_comment RdiuB RdiuT">评论<%Response.Write(PaText.count_comment); %></a>
                                <a onclick="refre_count_like(<%Response.Write(PaText.text_id); %>)" class="Btn_like RdiuB RdiuT"><%Response.Write(PaText.count_like); %></a>
                                <div class="LBL_pv">阅读<%Response.Write(PaText.count_pv); %></div>
                                <%foreach (string tag in indexServ.extags(PaText.tags))
                                    {  %>
                                <div class="LBL_tag"><%Response.Write(tag); %></div>
                                <%} %>
                            </div>
                        </div>
                    </div>
                </div>
                <div>
                    <!-- 随机文本按钮 -->
                    <%LibStructs.PaText rdmPaText = SLS.getTextMain(SLS.rdmTextIndex(rqst_text_id, "post").text_id);%>
                    <a onclick="showTxt(<%Response.Write(rdmPaText.text_id); %>)" class="RandomBtn Tran RdiuB RdiuT MagnB">
                        <%Response.Write(rdmPaText.text_title); %>
                    </a>
                    <!-- 评论区 -->
                    <div class="CommentBox fltL RdiuB RdiuT Shadow LabelBg MagnB">评论功能将于BETA测试结束后开放</div>
                </div>
                <%}%>
            </div>
        </div>
        <%} %>
    </div>

    <footer>
        <div style="color: aliceblue">本博客目前处于第六开发板（pilipalalaBETA6），所有内容均为测试文本，可能不具备参考价值</div>
    </footer>

    <script>
        $('body').mousemove(function (e) {
            if (document.body.clientWidth >= 1024) {
                var x = (e.originalEvent.x * -1 / 30), y = (e.originalEvent.y * -1 / 30);
                $('.siteBg').css('background-position', x + 'px ' + y + 'px');
            }
        });
    </script>
</asp:Content>
/* ajax查看文本的函数 */
function showTxt(text_id) {
    $.ajax({
        type: "post",
        url: "index.aspx?guide=0&text=1&text_id=" + text_id,
        data: "",
        dataType: "html",/* html返回类型 */
        success: function (result) {
            $(".TxtCol").html($(result).find(".TxtCol").html());

            refre_count_pv(text_id);/* 刷新count_pv计数 */

            if ($.cookie('isLike' + text_id) == 'true') {/* 如果cookie显示目前文本已点赞 */
                $(".Btn_like").text("✓" + $(result).find(".Btn_like").text());
            } else {
                $(".Btn_like").text("点赞" + $(result).find(".Btn_like").text());
            }
        }
    });
};

/* ajax返回首页的函数 */
function goHome() {
    $.ajax({
        type: "post",
        url: "index.aspx?guide=0&text=1&row=0",
        data: "",
        dataType: "html",/* html返回类型 */
        success: function (result) {
            $(".TxtCol").html($(result).find(".TxtCol").html());/* 以ajax异步请求到的页面.TxtCol替换原有.TxtCol */
        }
    });
};

/* ajax刷新count_like计数的函数 */
function refre_count_like(text_id) {
    if ($.cookie('isLike' + text_id) == 'true') {/* 如果cookie显示目前文本已经点赞 */
        $.cookie('isLike' + text_id, 'false', { expires: 1 });/* 设置为取消点赞，并设置cookie时效（天） */
        $.ajax({
            type: "post",
            contentType: "application/json",
            url: "./services/indexServ.asmx/less_count_like",
            data: "{text_id:" + text_id + "}",
            dataType: "json",/* json返回类型 */
            success: function (result) {
                $(".Btn_like").text("点赞" + result.d);
            }
        });
    } else {
        $.cookie('isLike' + text_id, 'true', { expires: 1 });
        $.ajax({
            type: "post",
            contentType: "application/json",
            url: "./services/indexServ.asmx/incre_count_like",
            data: "{text_id:" + text_id + "}",
            dataType: "json",/* json返回类型 */
            success: function (result) {
                $(".Btn_like").text("✓" + result.d);
            }
        });
    }
};
/* ajax刷新count_pv计数的函数 */
function refre_count_pv(text_id) {
    if ($.cookie('isLook' + text_id) == 'true') {/* 如果cookie显示目前文本已经浏览不做处理 */ }
    else {/* 未被浏览 */
        $.cookie('isLook' + text_id, 'true', { expires: 1 });
        $.ajax({
            type: "post",
            contentType: "application/json",
            url: "./services/indexServ.asmx/incre_count_pv",
            data: "{text_id:" + text_id + "}",
            dataType: "json",/* json返回类型 */
            success: function (result) {
                $(".LBL_pv").text("阅读" + result.d);
            }
        });
    }
};

/* ajax推进式文本列表加载的函数 */
function loadTxt() {
    $.ajax({
        type: "post",
        url: "index.aspx?guide=0&text=1&row=" + $(".TxtBox").length,
        data: "",
        dataType: "html",/* html返回类型 */
        success: function (result) {
            $("a").remove(".LoadPostBtn");
            $(".TxtCol").html($(".TxtCol").html() + $(result).find(".TxtCol").html());
        }
    });
}
<!DOCTYPE html>
<html lang="zh-CN">
<head>
<meta http-equiv="Content-type" content="text/html;charset=UTF-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=0.5, maximum-scale=2.0, user-scalable=yes"/>
<base target="_blank">
<link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon">
<title>Thaumy的博客|又一个码农的家</title>
<style type="text/css">
@import url("css/global.css");
 @import url("css/pic.css");
 @import url("css/basic.css");
 @import url("css/font.css");
 @import url("css/Box/Box.css");
 @import url("css/Btn/Btn.css");
</style>
<script src="js/jquery-1.12.4.min.js"></script>
</head>
<body>
<div class="siteBg"></div>
<div class="main">
  <div class="GuideCol">
    <div class="GuideBox">
      <div class="GuideHead fltL RdiuT"> <a href="233">
        <div class="UserIMG UserIMG_pic"></div>
        </a>
        <div class="SiteSummary">THAUMY的博客</div>
        <div class="UserMotto fltL">签名</div>
      </div>
      <div class="GuideCardBox fltL RdiuB MagnB"> <a href="233" class="GuideCard RdiuB RdiuT flx Tran">
        <div class="GuideCardTitle flx_center">页面标题</div>
        </a>
        <div class="CopyrightMark">
          <p>Thaumy的博客©2016-2019保留所有权利</p>
          <p>基于pilipala开发</p>
          <p>based on pilipala</p>
          站点背景图来自</div>
      </div>
    </div>
  </div>
  <a href="#top" target="_self" class="GoUpBtn RdiuT RdiuB Tran fltL">
  <div class="arrow_up GoUpBtn_pic"></div>
  </a>
  <div class="TxtCol">
    <div class="TxtBox fltL RdiuB RdiuT Shadow MagnB">
      <div class="BoxStrip OrgStrip"></div>
      <div class="TxtContent"> <a href="233">
        <div class="TxtBoxTitle">标准标题</div>
        <div class="TxtBoxSummary">文本概要，简短的描述。</div>
        </a> </div>
      <div class="fltL LabelBox LabelTxt LabelBg RdiuB">
        <div class="LabelContent LabelTxt">
          <div class="LBL_time">19/2/33 17:00</div>
          <div class="LBL_class">归档名</div>
          <div class="LBL_comment RdiuB RdiuT">评论99999</div>
          <div class="LBL_like RdiuB RdiuT">点赞99999</div>
          <div class="LBL_pv">阅读99999</div>
          <div class="LBL_tag">特征</div>
        </div>
      </div>
    </div>
    <a class="LoadPostBtn  fltL Tran RdiuB RdiuT">
    <div class="arrow_down LoadPostBtn_pic"></div>
    </a>
    <div class="TxtBox fltL RdiuB RdiuT Shadow MagnB"> <img alt="" class="RdiuT TxtImg" src="img/txtbg2.svg"/>
      <div class="BoxStrip OrgStrip"></div>
      <div class="TxtContent">
        <div class="TxtBoxTitle">标准标题</div>
        <div class="TxtBoxSummary">文本概要，简短的描述。</div>
        <div class="TxtBoxContent linked">文本内容，复杂的描述复杂的描述杂的述复杂的描述复杂的描述复杂的描述复杂的描述复杂的描述<span class="hidden">你知道的太多了</span>描述复杂的复杂的描述<a href="233">超链接样式展示233</a>复杂的描述复杂的描述复杂的描述复杂的描述复杂的描述的描述复杂的描述复杂述复杂的描述</div>
      </div>
      <div class="TxtCoMark fltL RdiuB RdiuT">
        <div class="TxtCoMarkTime">此文本由ThaumyCheng最后维护于9999/99/99</div>
        <div class="TxtCoMarkId">文本序列号：99999</div>
        <div class="LabelBox fltL LabelTxt LabelBg RdiuB">
          <div class="LabelContent LabelTxt">
            <div class="LBL_time">19/2/33 17:00</div>
            <div class="LBL_class">归档名</div>
            <a class="Btn_comment RdiuB RdiuT">评论99999</a> <a class="Btn_like RdiuB RdiuT">点赞99999</a>
            <div class="LBL_pv">阅读99999</div>
            <div class="LBL_tag">标签</div>
          </div>
        </div>
      </div>
    </div>
    <div> <a class="RandomBtn Tran RdiuB RdiuT MagnB">随机文本标题</a>
      <div class="CommentBox fltL RdiuB RdiuT Shadow LabelBg MagnB">评论功能将于BETA测试结束后开放</div>
    </div>
  </div>
</div>
<footer>
  <div style="color: aliceblue">本博客目前处于第六开发板（pilipalalaBETA6），所有内容均为测试文本，可能不具备参考价值</div>
</footer>
<script >
        $('body').mousemove(function (e) {
            if (document.body.clientWidth >= 1024) {
                var x = (e.originalEvent.x * -1 / 30), y = (e.originalEvent.y * -1 / 30);
                $('.siteBg').css('background-position', x + 'px ' + y + 'px');
            }
        });
    </script>
</body>
</html>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using LibStructs;
using sukiUnit;
using jarwUnit.pilipala;
using jarwUnit.pilipala.UI;

namespace PILIPALA.pala_services
{
    /// <summary>
    /// SLS 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SLS : System.Web.Services.WebService
    {
        private PalaRoot PalaRoot;
        private ConnSign cS;
        private PalaDB PalaDB;

        private TextListH TextListH;
        private TextH TextH;


        public SLS()
        {
            PalaDB.MySqlConnH = new MySqlConnH();

            
            cS.user = "thaumy0tdymy";
            cS.password = "177BDE5";
            cS.dataSource = "localhost";
            cS.port = "3306";
            PalaDB.MySqlConnH.start(cS);
            PalaDB.dataBase = "thaumy0tdymy";

            /*
            cS.user = "pala_database_user";
            cS.password = "pala_database_user_password";
            cS.dataSource = "localhost";
            cS.port = "3306";
            PalaDB.MySqlConnH.start(cS);
            PalaDB.dataBase = "pala_database";
            */

            PalaDB.Tables = PalaRoot.defaultTables();/* 以默认值确定表名 */
            PalaDB.Views = PalaRoot.defaultViews();/* 以默认值确定视图名 */

            PalaRoot = new PalaRoot(2, PalaDB);
            TextListH = new TextListH(PalaDB);
            TextH = new TextH(PalaDB);

            //如果使用设计的组件，请取消注释以下行 
            //InitializeComponent(); 
        }

        /// <summary>
        /// 获得权限数据
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public PaRoot getRoot()
        {
            return PalaRoot.getRoot();
        }

        #region 文本数据操作

        [WebMethod]
        public List<PaText> getTextList()
        {
            return TextListH.getTextList();
        }
        [WebMethod]
        public List<PaText> getTextList(string text_type)
        {
            return TextListH.getTextList(text_type);
        }


        [WebMethod]
        public List<PaText> stepTextList(int row, int rowLength)
        {
            return TextListH.stepTextList(row, rowLength);
        }
        [WebMethod]
        public List<PaText> stepTextList(int row, int rowLength, string text_type)
        {
            return TextListH.stepTextList(row, rowLength, text_type);
        }


        [WebMethod]
        public PaText getTextMain(int text_id)
        {
            return TextH.getTextMain(text_id);
        }
        [WebMethod]
        public PaText getTextSub(int text_id)
        {
            return TextH.getTextSub(text_id);
        }
        [WebMethod]
        public PaText rdmTextIndex(int excluded_text_id, string text_type)
        {
            return TextH.rdmTextIndex(excluded_text_id, text_type);
        }
        [WebMethod]
        public bool update_count_pv(int text_id, int value)
        {
            return TextH.update_count_pv(text_id, value);
        }
        [WebMethod]
        public bool update_count_like(int text_id, int value)
        {
            return TextH.update_count_like(text_id, value);
        }
        [WebMethod]
        public static PaText fill(PaText TextMain, PaText TextSub)
        {
            return TextH.fill(TextMain, TextSub);
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using LibStructs;
using sukiUnit;
using jarwUnit.pilipala;
using PILIPALA.pala_services;

namespace PILIPALA.pala_content.themes.fen.services
{
    /// <summary>
    /// index 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    [System.Web.Script.Services.ScriptService]
    public class indexServ : System.Web.Services.WebService
    {
        public indexServ()
        {
            //如果使用设计的组件，请取消注释以下行 
            //InitializeComponent(); 
        }


        /// <summary>
        /// count_like计数减一
        /// </summary>
        /// <param name="text_id"></param>
        /// <returns></returns>
        [WebMethod]
        public int less_count_like(int text_id)
        {
            SLS SLS = new SLS();
            int count_like = SLS.getTextSub(text_id).count_like;

                SLS.update_count_like(text_id, count_like - 1);
                return count_like - 1;
                
        }
        /// <summary>
        /// count_like计数加一
        /// </summary>
        /// <param name="text_id"></param>
        /// <returns></returns>
        [WebMethod]
        public int incre_count_like(int text_id)
        {
            SLS SLS = new SLS();
            int count_like = SLS.getTextSub(text_id).count_like;

            SLS.update_count_like(text_id, count_like + 1);
            return count_like + 1;
        }
        /// <summary>
        /// count_pv计数加一
        /// </summary>
        /// <param name="text_id"></param>
        /// <returns></returns>
        [WebMethod]
        public int incre_count_pv(int text_id)
        {
            SLS SLS = new SLS();
            int count_pv = SLS.getTextSub(text_id).count_pv;

            SLS.update_count_pv(text_id, count_pv + 1);
            return count_pv + 1;
        }

        /// <summary>
        /// 文件转字符串
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string exstring(string url)
        {
            FileHandler FH = new FileHandler();
            return FH.fileToStr(Server.MapPath("") + url);
        }
        /// <summary>
        /// 时间转换
        /// </summary>
        /// <param name="DateTime">时间对象</param>
        /// <returns></returns>
        [WebMethod]
        public static string extime(DateTime DateTime)
        {
            //年份只取后二位：2099=>99
            return Convert.ToString(DateTime.Year).Substring(2, 2) + "/" + DateTime.Month + "/" + DateTime.Day + " " + DateTime.Hour + ":" + DateTime.Minute;
        }
        /// <summary>
        /// 条带颜色样式
        /// </summary>
        /// <param name="color">颜色代码</param>
        /// <returns></returns>
        [WebMethod]
        public static string stripStyle(string strip_color)
        {
            switch (strip_color)
            {
                case "org": return "OrgStrip";
                case "blu": return "BluStrip";
                case "prp": return "PrpStrip";
                default: return null;
            }
        }
        /// <summary>
        /// 标签文本转标签集合
        /// </summary>
        /// <param name="tags">标签文本</param>
        /// <returns></returns>
        [WebMethod]
        public static List<string> extags(string tags)
        {
            List<string> list_tags = new List<string>();
            foreach (string tag in tags.Split('$'))
            {
                list_tags.Add(tag);
            }
            return list_tags;
        }
    }
}
<%@ Master Language="C#" AutoEventWireup="true" CodeBehind="index.master.cs" Inherits="PILIPALA.index" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Thaumy的博客|又一个码农的家</title>
    <!-- 文档头 -->
    <asp:ContentPlaceHolder ID="indexHead" runat="server"></asp:ContentPlaceHolder>
</head>
<body>
    <form runat="server">
        <!-- 文档内容 -->
        <asp:ContentPlaceHolder ID="indexBody" runat="server"></asp:ContentPlaceHolder>
    </form>
</body>
</html>
<?xml version="1.0" encoding="utf-8"?>

<!--
  有关如何配置 ASP.NET 应用程序的详细信息，请访问
  https://go.microsoft.com/fwlink/?LinkId=169433
-->
<configuration>
  <system.web>
    <compilation debug="true" targetFramework="4.5.2"/>
    <customErrors mode="Off"/>
    <httpRuntime targetFramework="4.5.2"/>
  </system.web>
  <!--
  <system.codedom>
    <compilers>
      <compiler language="c#;cs;csharp" extension=".cs"
        type="Microsoft.CodeDom.Providers.DotNetCompilerPlatform.CSharpCodeProvider, Microsoft.CodeDom.Providers.DotNetCompilerPlatform, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
        warningLevel="4" compilerOptions="/langversion:6 /nowarn:1659;1699;1701"/>
      <compiler language="vb;vbs;visualbasic;vbscript" extension=".vb"
        type="Microsoft.CodeDom.Providers.DotNetCompilerPlatform.VBCodeProvider, Microsoft.CodeDom.Providers.DotNetCompilerPlatform, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
        warningLevel="4" compilerOptions="/langversion:14 /nowarn:41008 /define:_MYTYPE=\&quot;Web\&quot; /optionInfer+"/>
    </compilers>
  </system.codedom>
  -->
</configuration>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;/* MySqlDB */
using System.Data;/* ADO.NET */
using System.Web.UI;
using System.Web;

using sukiUnit;
using LibStructs;

namespace jarwUnit
{
    namespace pilipala
    {
        interface IPalaRoot
        {
            /// <summary>
            /// Pala数据表所在数据库
            /// </summary>
            string dataBase { get; }
            /// <summary>
            /// 文本表
            /// </summary>
            PalaRoot.Tables Tables { get; }
            /// <summary>
            /// 文本视图
            /// </summary>
            PalaRoot.Views Views { get; }
            /// <summary>
            /// 数据库管理器实例
            /// </summary>
            MySqlConnH MySqlConnH { get; set; }
        }

        /// <summary>
        /// 啪啦权限控制器
        /// </summary>
        public class PalaRoot
        {
            public string dataBase { get; }
            public Tables objTables { get; }
            public Views objViews { get; }
            public MySqlConnH MySqlConnH { get; set; }
            int root_id;/* 权限ID */

            /// <summary>
            /// 初始化PalaRoot
            /// </summary>
            /// <param name="root_id">权限ID</param>
            /// <param name="PalaDB">啪啦数据库信息</param>
            public PalaRoot(int root_id, PalaDB PalaDB)
            {
                this.root_id = root_id;
                objTables = PalaDB.Tables;
                objViews = PalaDB.Views;
                dataBase = PalaDB.dataBase;
                MySqlConnH = PalaDB.MySqlConnH;
            }

            /// <summary>
            /// 获得权限数据
            /// </summary>
            /// <returns></returns>
            public PaRoot getRoot()
            {
                try
                {
                    PaRoot PaRoot = new PaRoot();/* 定义权限数据 */

                    string SQL = "call " + dataBase + ".`get_root`( ?root_id )";
                    List<Para> List_Para = new List<Para>/* 为参数化查询添加元素 */
                    {
                        new Para() { paraName = "?root_id", paraValue = root_id }
                    };

                    using (MySqlCommand MySqlCommand = MySqlConnH.paraQueryCmd(SQL, List_Para))/* 参数化查询 */
                    {
                        DataTable pala_root = MySqlConnH.getTable(MySqlCommand);

                        foreach (DataRow Row in pala_root.Rows)/* 遍历数据库表以取得唯一的数据行 */
                        {
                            PaRoot.root_id = Convert.ToInt32(Row["root_id"]);
                            PaRoot.root_definer = Convert.ToString(Row["root_definer"]);
                            PaRoot.site_debug = Convert.ToBoolean(Row["site_debug"]);
                            PaRoot.site_access = Convert.ToBoolean(Row["site_access"]);
                            PaRoot.site_url = Convert.ToString(Row["site_url"]);
                            PaRoot.site_title = Convert.ToString(Row["site_title"]);
                            PaRoot.site_summary = Convert.ToString(Row["site_summary"]);
                        }
                        return PaRoot;
                    }
                }
                finally
                {
                    MySqlConnH.closeHConnection();
                    MySqlConnH.nullHCommand();
                    MySqlConnH.disposeHCommand();
                }
            }

            /// <summary>
            /// 默认pala数据表
            /// </summary>
            private struct dftTables
            {
                public static string root = "pala_root";
                public static string text_index = "pala_text_index";
                public static string text_main = "pala_text_main";
                public static string text_sub = "pala_text_sub";
            }
            /// <summary>
            /// 默认pala数据视图
            /// </summary>
            private struct dftViews
            {
                public static string text_index_page = "view_text>index.page";
                public static string text_index_post = "view_text>index.post";
                public static string text_main = "view_text>main";
                public static string text_sub = "view_text>sub";
            }

            /// <summary>
            /// 自定义pala数据表
            /// </summary>
            public struct Tables
            {
                /// <summary>
                /// 初始化表名结构
                /// </summary>
                /// <param name="root"></param>
                /// <param name="text_index"></param>
                /// <param name="text_main"></param>
                /// <param name="text_sub"></param>
                public Tables(string root, string text_index, string text_main, string text_sub) : this()
                {
                    this.root = root;
                    this.text_index = text_index;
                    this.text_main = text_main;
                    this.text_sub = text_sub;
                }

                public string root { get; set; }
                public string text_index { get; set; }
                public string text_main { get; set; }
                public string text_sub { get; set; }
            }
            /// <summary>
            /// 自定义pala数据视图
            /// </summary>
            public struct Views
            {
                /// <summary>
                /// 初始化视图名结构
                /// </summary>
                /// <param name="text_main"></param>
                /// <param name="text_sub"></param>
                /// <param name="text_index_post"></param>
                /// <param name="text_index_page"></param>
                public Views(string text_main, string text_sub, string text_index_post, string text_index_page) : this()
                {
                    this.text_index_page = text_index_page;
                    this.text_index_post = text_index_post;
                    this.text_main = text_main;
                    this.text_sub = text_sub;
                }
                public string text_index_page { get; set; }
                public string text_index_post { get; set; }
                public string text_main { get; set; }
                public string text_sub { get; set; }
            }

            /// <summary>
            /// 以默认值定义表名（重载一::直接更改Tables）
            /// </summary>
            public static void defaultTables(ref Tables Tables)
            {
                Tables.root = dftTables.root;
                Tables.text_index = dftTables.text_index;
                Tables.text_main = dftTables.text_main;
                Tables.text_sub = dftTables.text_sub;
            }
            /// <summary>
            /// 以默认值定义视图名（重载一::直接更改Views）
            /// </summary>
            public static void defaultViews(ref Views Views)
            {
                Views.text_main = dftViews.text_main;
                Views.text_sub = dftViews.text_sub;
                Views.text_index_post = dftViews.text_index_post;
                Views.text_index_page = dftViews.text_index_page;
            }

            /// <summary>
            /// 以默认值定义表名（重载二::返回默认Tables）
            /// </summary>
            /// <returns></returns>
            public static Tables defaultTables()
            { return new Tables(dftTables.root, dftTables.text_index, dftTables.text_main, dftTables.text_sub); }
            /// <summary>
            /// 以默认值定义视图名（重载二::返回默认Views）
            /// </summary>
            /// <returns></returns>
            public static Views defaultViews()
            { return new Views(dftViews.text_main, dftViews.text_sub, dftViews.text_index_post, dftViews.text_index_page); }
        }

        namespace UI
        {
            /// <summary>
            /// 文本列表控制接口
            /// </summary>
            interface ITextListH : IPalaRoot
            {
                /// <summary>
                /// 获得文本索引表（重载一::得到全文本列表）
                /// </summary>
                /// <returns></returns>
                List<PaText> getTextList();
                /// <summary>
                /// 获得文本索引表（重载二::得到指定类型的文本列表）
                /// </summary>
                /// <param name="text_type">自定义文本类型</param>
                /// <returns></returns>
                List<PaText> getTextList(string text_type);

                /// <summary>
                /// 步进式获得文本索引表（重载一::得到全文本列表）
                /// </summary>
                /// <param name="row">步进起始行（包含该行）</param>
                /// <param name="rowLength">加载行数</param>
                /// <returns></returns>
                List<PaText> stepTextList(int row, int rowLength);
                /// <summary>
                /// 步进式获得文本索引表（重载一::得到指定类型的文本列表）
                /// </summary>
                /// <param name="row">步进起始行（包含该行）</param>
                /// <param name="rowLength">加载行数</param>
                /// <param name="text_type">自定义文本类型</param>
                /// <returns></returns>
                List<PaText> stepTextList(int row, int rowLength, string text_type);

            }
            /// <summary>
            /// 文本控制接口
            /// </summary>
            interface ITextH : IPalaRoot
            {
                /// <summary>
                /// 获得指定ID的文本主表行
                /// </summary>
                /// <param name="text_id">文本ID</param>
                /// <returns></returns>
                PaText getTextMain(int text_id);
                /// <summary>
                /// 获得指定ID的文本副表行
                /// </summary>
                /// <param name="text_id">文本ID</param>
                /// <returns></returns>
                PaText getTextSub(int text_id);

                /// <summary>
                /// 随机获得文本索引表行
                /// </summary>
                /// <param name="excluded_text_id">不参与随机操作的文本ID</param>
                /// <param name="text_type">自定义文本类型</param>
                /// <returns></returns>
                PaText rdmTextIndex(int excluded_text_id, string text_type);

            }

            /// <summary>
            /// 文本列表控制器
            /// </summary>
            public class TextListH : ITextListH
            {
                public string dataBase { get; }
                public PalaRoot.Tables Tables { get; }
                public PalaRoot.Views Views { get; }
                public MySqlConnH MySqlConnH { get; set; }

                /// <summary>
                /// 初始化TextListH
                /// </summary>
                /// <param name="PalaDB">啪啦数据库信息</param>
                public TextListH(PalaDB PalaDB)
                {
                    dataBase = PalaDB.dataBase;
                    Tables = PalaDB.Tables;
                    Views = PalaDB.Views;
                    MySqlConnH = PalaDB.MySqlConnH;
                }

                public List<PaText> getTextList()
                {
                    try
                    {
                        List<PaText> List_PaText = new List<PaText>();/* 定义文本列表 */

                        using (DataTable pala_text_index = MySqlConnH.getTable("select * from " + dataBase + "." + "`" + Tables.text_index + "`"))
                        {
                            foreach (DataRow Row in pala_text_index.Rows)/* 遍历数据库表行，逐行取得数据 */
                            {
                                PaText PaText = new PaText
                                {
                                    text_id = Convert.ToInt32(Row["text_id"]),
                                    text_mode = Convert.ToString(Row["text_mode"]),
                                    text_type = Convert.ToString(Row["text_type"])
                                };
                                List_PaText.Add(PaText);/* 每次循环完成，将获取到的文本数据添加至文本列表 */
                            }
                        }
                        return List_PaText;
                    }
                    finally
                    {
                        MySqlConnH.nullHCommand();
                        MySqlConnH.disposeHCommand();
                    }
                }
                public List<PaText> getTextList(string text_type)
                {
                    try
                    {
                        List<PaText> List_PaText = new List<PaText>();/* 定义文本列表 */

                        DataTable pala_text_index;
                        if (text_type == "page")/* 对文本类型判断以选择查询目标 */
                        { pala_text_index = MySqlConnH.getTable("select * from " + dataBase + "." + "`" + Views.text_index_page + "`"); }
                        else if (text_type == "post")
                        { pala_text_index = MySqlConnH.getTable("select * from " + dataBase + "." + "`" + Views.text_index_post + "`"); }
                        else { return null; }

                        using (pala_text_index)
                        {
                            foreach (DataRow Row in pala_text_index.Rows)/* 遍历数据库表行，逐行取得数据 */
                            {
                                PaText PaText = new PaText
                                {
                                    text_id = Convert.ToInt32(Row["text_id"]),
                                    text_mode = Convert.ToString(Row["text_mode"]),
                                    text_type = Convert.ToString(Row["text_type"])
                                };
                                List_PaText.Add(PaText);/* 每次循环完成，将获取到的文本数据添加至文本列表 */
                            }
                        }
                        return List_PaText;
                    }
                    finally
                    {
                        MySqlConnH.nullHCommand();
                        MySqlConnH.disposeHCommand();
                    }
                }

                public List<PaText> stepTextList(int row, int rowLength)
                {
                    try
                    {
                        List<PaText> List_PaText = new List<PaText>();/* 定义文本列表 */

                        string SQL = "select * from " + dataBase + "." + "`" + Tables.text_index + "`" + " LIMIT ?row , ?rowLength";
                        List<Para> List_Para = new List<Para>/* 为参数化查询添加元素 */
                        {
                            new Para() { paraName = "?row", paraValue = row },
                            new Para() { paraName = "?rowLength", paraValue = rowLength }
                        };

                        using (MySqlCommand MySqlCommand = MySqlConnH.paraQueryCmd(SQL, List_Para))/* 参数化查询 */
                        {
                            DataTable pala_text_index = MySqlConnH.getTable(MySqlCommand);

                            foreach (DataRow Row in pala_text_index.Rows)/* 遍历数据库表行，逐行取得数据 */
                            {
                                PaText PaText = new PaText
                                {
                                    text_id = Convert.ToInt32(Row["text_id"]),
                                    text_mode = Convert.ToString(Row["text_mode"]),
                                    text_type = Convert.ToString(Row["text_type"])
                                };

                                List_PaText.Add(PaText);/* 每次循环完成，将获取到的文本数据添加至文本列表 */
                            }
                        }
                        return List_PaText;
                    }
                    finally
                    {
                        MySqlConnH.nullHCommand();
                        MySqlConnH.disposeHCommand();
                    }
                }
                public List<PaText> stepTextList(int row, int rowLength, string text_type)
                {
                    try
                    {
                        string SQL;
                        if (text_type == "page")/* 对文本类型判断以选择查询目标 */
                        { SQL = "select * from " + dataBase + "." + "`" + Tables.text_index + "`" + " LIMIT ?row , ?rowLength"; }
                        else if (text_type == "post")
                        { SQL = "select * from " + dataBase + "." + "`" + Tables.text_index + "`" + " LIMIT ?row , ?rowLength"; }
                        else { return null; }

                        List<PaText> List_PaText = new List<PaText>();/* 定义文本列表 */

                        List<Para> List_Para = new List<Para>/* 为参数化查询添加元素 */
                        {
                            new Para() { paraName = "?row", paraValue = row },
                            new Para() { paraName = "?rowLength", paraValue = rowLength }
                        };

                        using (MySqlCommand MySqlCommand = MySqlConnH.paraQueryCmd(SQL, List_Para))/* 参数化查询 */
                        {
                            DataTable pala_text_index = MySqlConnH.getTable(MySqlCommand);

                            foreach (DataRow Row in pala_text_index.Rows)/* 遍历数据库表行，逐行取得数据 */
                            {
                                PaText PaText = new PaText
                                {
                                    text_id = Convert.ToInt32(Row["text_id"]),
                                    text_mode = Convert.ToString(Row["text_mode"]),
                                    text_type = Convert.ToString(Row["text_type"])
                                };

                                List_PaText.Add(PaText);/* 每次循环完成，将获取到的文本数据添加至文本列表 */
                            }
                        }
                        return List_PaText;
                    }
                    finally
                    {
                        MySqlConnH.nullHCommand();
                        MySqlConnH.disposeHCommand();
                    }
                }
            }
            /// <summary>
            /// 文本控制器
            /// </summary>
            public class TextH : ITextH
            {
                public string dataBase { get; }
                public PalaRoot.Tables Tables { get; }
                public PalaRoot.Views Views { get; }
                public MySqlConnH MySqlConnH { get; set; }

                /// <summary>
                /// 初始化TextH
                /// </summary>
                /// <param name="PalaDB">啪啦数据库信息</param>
                public TextH(PalaDB PalaDB)
                {
                    dataBase = PalaDB.dataBase;
                    Tables = PalaDB.Tables;
                    Views = PalaDB.Views;
                    MySqlConnH = PalaDB.MySqlConnH;
                }

                public PaText getTextMain(int text_id)
                {
                    PaText PaText = new PaText();/* 定义文本列表 */

                    string SQL = "call " + dataBase + ".`get_text>main`( ?text_id )";
                    List<Para> List_Para = new List<Para>/* 为参数化查询添加元素 */
                        {
                            new Para() { paraName = "?text_id", paraValue = text_id }
                        };

                    using (MySqlCommand MySqlCommand = MySqlConnH.paraQueryCmd(SQL, List_Para))/* 参数化查询 */
                    {
                        DataTable pala_text_main = MySqlConnH.getTable(MySqlCommand);

                        foreach (DataRow Row in pala_text_main.Rows)/* 遍历数据库表以取得唯一的数据行 */
                        {
                            PaText.text_id = Convert.ToInt32(Row["text_id"]);
                            PaText.text_title = Convert.ToString(Row["text_title"]);
                            PaText.text_summary = Convert.ToString(Row["text_summary"]);
                            PaText.text_content = Convert.ToString(Row["text_content"]);
                        }
                        return PaText;
                    }

                }
                public PaText getTextSub(int text_id)
                {
                    try
                    {
                        PaText PaText = new PaText();/* 定义文本列表 */

                        string SQL = "call " + dataBase + ".`get_text>sub`( ?text_id )";
                        List<Para> List_Para = new List<Para>/* 为参数化查询添加元素 */
                        {
                            new Para() { paraName = "?text_id", paraValue = text_id }
                        };

                        using (MySqlCommand MySqlCommand = MySqlConnH.paraQueryCmd(SQL, List_Para))/* 参数化查询 */
                        {
                            DataTable pala_text_main = MySqlConnH.getTable(MySqlCommand);

                            foreach (DataRow Row in pala_text_main.Rows)/* 遍历数据库表行，逐行取得数据 */
                            {
                                PaText.text_id = Convert.ToInt32(Row["text_id"]);
                                PaText.text_class = Convert.ToString(Row["text_class"]);
                                PaText.text_editor = Convert.ToString(Row["text_editor"]);

                                PaText.date_created = Convert.ToDateTime(Row["date_created"]);
                                PaText.date_changed = Convert.ToDateTime(Row["date_changed"]);

                                PaText.count_pv = Convert.ToInt32(Row["count_pv"]);
                                PaText.count_comment = Convert.ToInt32(Row["count_comment"]);
                                PaText.count_like = Convert.ToInt32(Row["count_like"]);

                                PaText.tags = Convert.ToString(Row["tags"]);
                                PaText.cover_url = Convert.ToString(Row["cover_url"]);
                                PaText.strip_color = Convert.ToString(Row["strip_color"]);
                            }
                            return PaText;
                        }
                    }
                    finally
                    {
                        MySqlConnH.closeHConnection();
                        MySqlConnH.nullHCommand();
                        MySqlConnH.disposeHCommand();
                    }
                }

                public PaText rdmTextIndex(int excluded_text_id, string text_type)
                {
                    try
                    {
                        string SQL;
                        if (text_type == "page")/* 对文本类型判断以选择查询目标 */
                        { SQL = "call " + dataBase + ".`random_text>index.page`( ?excluded_text_id )"; }
                        else if (text_type == "post")
                        { SQL = "call " + dataBase + ".`random_text>index.post`( ?excluded_text_id )"; }
                        else { return new PaText(); }/* 类型识别失败返回空结构 */

                        PaText PaText = new PaText();/* 定义文本列表 */

                        List<Para> List_Para = new List<Para>/* 为参数化查询添加元素 */
                        {
                            new Para() { paraName = "?excluded_text_id", paraValue = excluded_text_id }
                        };

                        using (MySqlCommand MySqlCommand = MySqlConnH.paraQueryCmd(SQL, List_Para))/* 参数化查询 */
                        {
                            DataTable pala_text_main = MySqlConnH.getTable(MySqlCommand);

                            foreach (DataRow Row in pala_text_main.Rows)/* 遍历数据库表以取得唯一的数据行 */
                            {
                                PaText.text_id = Convert.ToInt32(Row["text_id"]);
                                PaText.text_mode = Convert.ToString(Row["text_mode"]);
                                PaText.text_type = Convert.ToString(Row["text_type"]);
                            }
                            return PaText;
                        }
                    }
                    finally
                    {
                        MySqlConnH.closeHConnection();
                        MySqlConnH.nullHCommand();
                        MySqlConnH.disposeHCommand();
                    }
                }

                /// <summary>
                /// 合并主副表PaText数据
                /// </summary>
                /// <param name="TextMain">主表PaText</param>
                /// <param name="TextSub">副表PaText</param>
                /// <returns></returns>
                public static PaText fill(PaText TextMain, PaText TextSub)
                {
                    return new PaText
                    {
                        /* 主表数据填充 */
                        text_id = TextMain.text_id,
                        text_title = TextMain.text_title,
                        text_summary = TextMain.text_summary,
                        text_content = TextMain.text_content,

                        /* 副表数据填充 */
                        text_class = TextSub.text_class,
                        text_editor = TextSub.text_editor,
                        date_created = TextSub.date_created,
                        date_changed = TextSub.date_changed,
                        count_pv = TextSub.count_pv,
                        count_comment = TextSub.count_comment,
                        count_like = TextSub.count_like,
                        tags = TextSub.tags,
                        cover_url = TextSub.cover_url,
                        strip_color = TextSub.strip_color
                    };
                }

                /// <summary>
                /// 设置count_pv
                /// </summary>
                /// <param name="text_id">文本ID</param>
                /// <param name="value">值</param>
                /// <returns></returns>
                public bool update_count_pv(int text_id, int value)
                {
                    try
                    {
                        //初始化目标行定位数据
                        Posi Posi = new Posi
                        {
                            dataBase = dataBase,
                            table = Tables.text_sub,
                            whereColumn = "text_id",
                            targetColumn = "count_pv"
                        };
                        return MySqlConnH.setColumnValue(Posi, text_id.ToString(), value.ToString());
                    }
                    finally
                    {
                        MySqlConnH.closeHConnection();
                        MySqlConnH.nullHCommand();
                        MySqlConnH.disposeHCommand();
                    }
                }
                /// <summary>
                /// 设置count_like
                /// </summary>
                /// <param name="text_id">文本ID</param>
                /// <param name="value">值</param>
                /// <returns></returns>
                public bool update_count_like(int text_id, int value)
                {
                    try
                    {
                        Posi Posi = new Posi
                        {
                            dataBase = dataBase,
                            table = Tables.text_sub,
                            whereColumn = "text_id",
                            targetColumn = "count_like"
                        };
                        return MySqlConnH.setColumnValue(Posi, text_id.ToString(), value.ToString());
                    }
                    finally
                    {
                        MySqlConnH.closeHConnection();
                        MySqlConnH.nullHCommand();
                        MySqlConnH.disposeHCommand();
                    }
                }
            }
        }

        /// <summary>
        /// Cookie控制器
        /// </summary>
        public class CookieHandler : Page
        {
            /// <summary>
            /// 判断Cookie对象是否存在
            /// </summary>
            /// <param name="CookieName">被判断Cookie对象的名称</param>
            /// <returns>存在返回true，反之false</returns>
            public bool isCookiesExist(string CookieName)
            {
                if (HttpContext.Current.Request.Cookies[CookieName] == null)//如果Cookie对象为null（不存在）
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            /// <summary>
            /// 判断Cookie对象是否存在（重载二：判断索引是否存在）
            /// </summary>
            /// <param name="CookieName">被判断Cookie对象的名称</param>
            /// <param name="keyName">索引名，属于被判断的Cookie</param>
            /// <returns>存在返回true，反之false</returns>
            public bool isCookiesExist(string CookieName, string keyName)
            {
                if (isCookiesExist(CookieName) == true)//如果Cookie对象存在
                {
                    if (HttpContext.Current.Request.Cookies[CookieName][keyName].ToString() != "")//如果Cookie中的keyName索引键值为空字符串
                    {
                        return false;//不存在
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }

            }

            /// <summary>
            /// 读取Cookie对象到指定类型
            /// </summary>
            /// <typeparam name="T">指定泛型</typeparam>
            /// <param name="CookieName">被读取Cookie对象名</param>
            /// <returns>返回泛型值，读取失败则返回泛型默认值</returns>
            public T cookie<T>(string CookieName)
            {
                if (isCookiesExist(CookieName) == true)//如果Cookie对象存在
                {
                    if (HttpContext.Current.Request.Cookies[CookieName].Value == "")
                    {
                        return default(T);//如果Cookie对象值为空字符串（null），返回泛型默认值
                    }
                    else
                    {
                        if (HttpContext.Current.Request.Cookies[CookieName].Value == null)
                        {
                            return default(T);
                        }
                        else
                        {
                            //如果Cookie对象的索引值不为null，转换为泛型返回
                            return (T)Convert.ChangeType(HttpContext.Current.Request.Cookies[CookieName].Value, typeof(T));
                        }
                    }
                }
                else
                {
                    return default(T);
                }

            }
            /// <summary>
            /// 读取Cookie对象的指定索引值到指定类型
            /// </summary>
            /// <typeparam name="T">指定泛型</typeparam>
            /// <param name="CookieName">被读取Cookie对象名</param>
            /// <param name="keyName">索引名，属于当前Cookie对象</param>
            /// <returns>返回泛型值，读取失败则返回泛型默认值</returns>
            public T cookie<T>(string CookieName, string keyName)
            {
                if (isCookiesExist(CookieName, keyName) == true)
                {
                    //如果索引键值不为空字符串，转换为泛型返回
                    return (T)Convert.ChangeType(HttpContext.Current.Request.Cookies[CookieName][keyName].ToString(), typeof(T));
                }
                else
                {
                    return default(T);
                }

            }

            /// <summary>
            /// 设置Cookie值
            /// </summary>
            /// <param name="CookieName">Cookie名，承担该操作</param>
            /// <param name="value">设置值</param>
            /// <returns>设置成功返回true，反之false</returns>
            public bool setCookie(string CookieName, object value)
            {
                HttpContext.Current.Response.Cookies[CookieName].Value = value.ToString();
                return true;
            }
            /// <summary>
            /// 设置Cookie值（重载二：索引设置）
            /// </summary>
            /// <param name="CookieName">Cookie名，承担该操作</param>
            /// <param name="keyName">索引名，属于承担该操作的Cookie</param>
            /// <param name="value">设置值</param>
            /// <returns>设置成功返回true，反之false</returns>
            public bool setCookie(string CookieName, string keyName, object value)
            {
                HttpContext.Current.Response.Cookies[CookieName][keyName] = value.ToString();
                return true;
            }
        }

        /// <summary>
        /// Session控制器
        /// </summary>
        public class SessionHandler : Page
        {
            /// <summary>
            /// 读取Session对象到指定类型
            /// </summary>
            /// <typeparam name="T">指定泛型</typeparam>
            /// <param name="varName">变量名，属于Session对象，承担该操作</param>
            /// <returns>返回泛型值，读取失败则返回泛型默认值</returns>
            public T session<T>(string varName)
            {
                //测试表明，Session对象始终存在，并且不为null，所以可以不加判断直接转换
                return (T)Convert.ChangeType(HttpContext.Current.Session[varName], typeof(T));//转换为自定义类型
            }

            /// <summary>
            /// 设置Session对象的变量值
            /// </summary>
            /// <param name="varName">变量名，属于Session对象，承担该操作</param>
            /// <param name="value">设置值</param>
            /// <returns>设置成功返回true，反之false</returns>
            public bool setSession(string varName, object value)
            {
                HttpContext.Current.Session[varName] = value;
                return true;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;/* IO */
using System.Net;/* 网页操作 */
using System.Drawing;/* GDI+ */
using System.Web.Script.Serialization;/* json解析 */

using LibStructs;


/// <summary>
/// SL框架控制
/// </summary>
namespace LibFrame
{
    /// <summary>
    /// 版本控制限定
    /// </summary>
    public interface IStdLibFrame
    {
        /// <summary>
        /// 版本
        /// </summary>
        int projectVer
        {
            get;
        }
        /// <summary>
        /// 版本名字对象
        /// </summary>
        string projectMoniker
        {
            get;
        }
        /// <summary>
        /// 版本类型
        /// </summary>
        string editionType
        {
            get;
        }
        /// <summary>
        /// 步进
        /// </summary>
        string stepping
        {
            get;
        }
        /// <summary>
        /// 目标框架
        /// </summary>
        string targetFramework
        {
            get;
        }
        /// <summary>
        /// 目标框架名字对象
        /// </summary>
        string targetFrameworkMoniker
        {
            get;
        }
        /// <summary>
        /// 对最近一次pub版本的全局兼容性
        /// </summary>
        bool compat
        {
            get;
        }
        /// <summary>
        /// 适用平台
        /// </summary>
        string platform
        {
            get;
        }
    }

    /// <summary>
    /// 用于获取类库信息的类
    /// </summary>
    public sealed class LibInformation : IStdLibFrame
    {
        #region

        private static string SubHlinfURL;/* 子URL，HlinfURL失效时用于替补 */

        /// <summary>
        /// 版本
        /// </summary>
        public int projectVer { get; } = 113;
        /// <summary>
        /// 版本名字对象
        /// </summary>
        public string projectMoniker { get; } = "st114";
        /// <summary>
        /// 版本类型
        /// </summary>
        public string editionType { get; } = "public";
        /// <summary>
        /// 步进
        /// </summary>
        public string stepping { get; } = "a0";
        /// <summary>
        /// 类库的目标框架
        /// </summary>
        public string targetFramework { get; } = ".NET Framework";
        /// <summary>
        /// 类库的目标框架名字对象
        /// </summary>
        public string targetFrameworkMoniker { get; } = "net452";
        /// <summary>
        /// 类库的目标C#版本
        /// </summary>
        public string targetCSharpLang { get; } = "7.2";
        /// <summary>
        /// 针对最近一次发行版的全局兼容性
        /// </summary>
        public bool compat { get; } = false;
        /// <summary>
        /// 适用平台
        /// </summary>
        public string platform { get; } = "x86";
        /// <summary>
        /// 是否为最新pub版本
        /// </summary>
        public string isNewVer { get; }
        /// <summary>
        /// 最新pub版本下载URL
        /// </summary>
        public string newVerDownloadURL { get; }
        /// <summary>
        /// 当前版本下载URL
        /// </summary>
        public string thisVerDownloadURL { get; }
        /// <summary>
        /// 内置于当前版本的Hlinf信息获取URL
        /// </summary>
        public string HlinfURL { get; } = "https://thaumy.github.io/StdLib1x/xplore/st114_Hlinf.html";
        /// <summary>
        /// 获取到像素化的StdLib_logo
        /// </summary>
        public Bitmap logo => StudioLibrary.LibReso.logo;

        #endregion



        /// <summary>
        /// 初始化LibInformation
        /// </summary>
        /// <param name="spareInfUrl">必须的值：用于内置联网信息获取Url失效时进行替补的Url</param>
        public LibInformation(string spareInfUrl)
        {
            LibInformation.SubHlinfURL = spareInfUrl;

            isNewVer = pvtGetHtmlLibInformation()[0];//得到是否为最新pub版本
            newVerDownloadURL = pvtGetHtmlLibInformation()[1];//得到最新版本下载URL

            thisVerDownloadURL = pvtGetHtmlLibInformation()[2];//得到当前版本下载URL
        }

        /// <summary>
        /// 被重写的WebClient
        /// </summary>
        public class OWebClient : WebClient
        {
            /// <summary>
            /// WebRequest请求访问的超时时间
            /// </summary>
            public int timeOut { get; set; }

            /// <summary>
            /// 得到WebRwquest请求实例并附加超时时间的方法
            /// </summary>
            /// <param name="uri">统一资源标识符对象</param>
            /// <returns>返回WebRequests实例(注意！该部分代码尚不安全，因为它没有建立报错处理机制)</returns>
            protected override WebRequest GetWebRequest(Uri uri)
            {
                WebRequest request = base.GetWebRequest(uri);
                request.Timeout = timeOut;//设置超时时间

                return request;
            }
        }

        /// <summary>
        /// 获取url指定的OWebClient所赋值的StreamReader对象（重载一）（UTF8编码模式）
        /// </summary>
        /// <param name="url">被OWebClient指定的url</param>
        /// <returns>返回StreamReader，报错返回null</returns>
        public static StreamReader getStreamReader(string url)
        {
            try
            {
                //安全套接字协议
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                using (OWebClient Client = new OWebClient())//调用完成释放资源
                {
                    Client.timeOut = 5000;
                    return new StreamReader(Client.OpenRead(url), Encoding.UTF8);//使用UTF8编码模式解码，然后返回流对象
                }
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// 获取url指定的OWebClient所赋值的StreamReader对象（重载二）
        /// </summary>
        /// <param name="url">被OWebClient指定的url</param>
        /// <param name="encodingType">使用的编码模式</param>
        /// <returns>返回StreamReader，报错返回null</returns>
        public static StreamReader getStreamReader(string url, string encodingType)
        {
            try
            {
                //安全套接字协议
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                using (OWebClient Client = new OWebClient())//调用完成释放资源
                {
                    Client.timeOut = 5000;
                    return new StreamReader(Client.OpenRead(url), Encoding.GetEncoding(encodingType));//使用UTF8编码模式解码，然后返回流对象
                }
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// 获取联网信息
        /// （注意：一旦取到空值，该方法将自动返回自定义URL所取得的信息（重载二被执行））
        /// </summary>
        /// <returns>返回获得的信息，报错返回null</returns>
        private static string[] pvtGetHtmlLibInformation()
        {
            try
            {
                LibInformation LIF = new LibInformation(null);
                string[] result = getStreamReader(LIF.HlinfURL).ReadToEnd().Split('$');

                if (result == null || result[0] == null || result[1] == null || result[2] == null)//如果获取到空值
                {
                    return pvtGetHtmlLibInformation(SubHlinfURL);//返回重载二
                }
                else { return result; }//返回查询结果
            }
            catch
            {
                return pvtGetHtmlLibInformation(SubHlinfURL);//返回重载二
            }

        }

        /// <summary>
        /// 获取联网信息（重载二）
        /// </summary>
        /// <param name="url">信息所在的URL地址</param>
        /// <returns>返回获得的信息，报错返回“string[] { "null", "null" }”数组</returns>
        private static string[] pvtGetHtmlLibInformation(string url)
        {
            try
            {
                return getStreamReader(url).ReadToEnd().Split('$'); ;
            }
            catch
            {
                return new string[] { "null", "null" };
            }
        }

        /// <summary>
        /// 通过json文件获得类库信息（重载一）
        /// </summary>
        ///<param name="url">json文件所在url</param>
        /// <returns>返回存有类库信息的JlinfObject，错误则返回null</returns>
        public JlinfObject getJsonLibInformation(string url)
        {
            try
            {
                //序列化/反序列化对象JavaScriptSerializer
                //转换json为JlinfObject对象并返回
                return new JavaScriptSerializer().Deserialize<JlinfObject>(getStreamReader(url).ReadToEnd());
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 通过json文件获得类库信息（重载二）
        /// </summary>
        /// <param name="filePath">json文件所在的本地物理路径</param>
        /// <param name="bufferSize">文件流缓冲区大小，默认值可填4096</param>
        /// <param name="useAsync">使用异步初始化文件流，缺乏设计的异步调用会慢于串行调用</param>
        /// <returns>返回存有类库信息的JlinfObject，错误则返回null</returns>
        public JlinfObject getJsonLibInformation(string filePath, int bufferSize, bool useAsync)
        {
            try
            {
                using (
                    StreamReader StreamReader = new StreamReader//流读取对象
                    (new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Write, bufferSize, useAsync)//文件流对象
                    , Encoding.GetEncoding("unicode"))//指定编码模式，为保证兼容，这里使用unicode
                        )
                {
                    //序列化/反序列化对象JavaScriptSerializer
                    //转换json为JlinfObject对象并返回
                    return new JavaScriptSerializer().Deserialize<JlinfObject>(StreamReader.ReadToEnd().ToString());
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibFrame;
using sukiUnit;
using jarwUnit.pilipala;

namespace LibStructs
{
    /// <summary>
    /// 连接签名（用于描述数据库连接的基本信息）
    /// </summary>
    public struct ConnSign
    {
        /// <summary>
        /// 数据源
        /// </summary>
        public string dataSource { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public string port { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string user { get; set; }
        /// <summary>
        /// 用户名对应的密码
        /// </summary>
        public string password { get; set; }
    }

    /// <summary>
    /// XML描述结构
    /// </summary>
    public struct XmlSign
    {
        /// <summary>
        /// 节点地址，如父节点、实节点、子节点的地址，用于XmlCreater类中除reStream、CreateXml方法外的所有方法
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// 被创建的Xml文档的文件地址，用于XmlCreater类的CreateXml方法
        /// </summary>
        public string fileName { get; set; }
        /// <summary>
        /// 被创建的Xml文档的文件名，用于XmlCreater类的CreateXml方法
        /// </summary>
        public string xmlName { get; set; }
        /// <summary>
        /// 被创建的Xml文档的根元素名，用于XmlCreater类的CreateXml方法
        /// </summary>
        public string rootName { get; set; }
        /// <summary>
        /// 节点名，可表示子节点、父节点、新建空\实节点名，用于XmlCreater类的AddRealNode、AddEmptyNode、RemoveNode方法
        /// </summary>
        public string nodeName { get; set; }
        /// <summary>
        /// 节点的属性名，用于XmlCreater类的AddRealNode、ReadAtt方法
        /// </summary>
        public string attName { get; set; }
        /// <summary>
        /// 节点的属性值，用于XmlCreater类的AddRealNode方法
        /// </summary>
        public string attValue { get; set; }
        /// <summary>
        /// 节点的子文本，用于XmlCreater类的AddRealNode方法
        /// </summary>
        public string innerText { get; set; }
        /// <summary>
        /// 读取类型，可选值有"_name"、"_value"，用于XmlCreater类的ReadNode方法
        /// </summary>
        public string type { get; set; }
    }

    /// <summary>
    /// Json本库信息
    /// </summary>
    public class JlinfObject : IStdLibFrame
    {
        //主要信息
        /// <summary>
        /// 版本号
        /// </summary>
        public int projectVer
        {
            get; set;
        }
        /// <summary>
        /// 版本名字对象
        /// </summary>
        public string projectMoniker
        {
            get; set;
        }
        /// <summary>
        /// 版本类型
        /// </summary>
        public string editionType
        {
            get; set;
        }
        /// <summary>
        /// 步进
        /// </summary>
        public string stepping
        {
            get; set;
        }
        /// <summary>
        /// 类库的目标框架
        /// </summary>
        public string targetFramework
        {
            get; set;
        }
        /// <summary>
        /// 类库的目标框架名字对象
        /// </summary>
        public string targetFrameworkMoniker
        {
            get; set;
        }
        /// <summary>
        /// 针对最近一次发行版的全局兼容性
        /// </summary>
        public bool compat
        {
            get; set;
        }
        /// <summary>
        /// 适用平台
        /// </summary>
        public string platform
        {
            get; set;
        }

        //次要信息
        /// <summary>
        /// 架构名
        /// </summary>
        public string architecture
        {
            get; set;
        }
        /// <summary>
        /// 开发代号
        /// </summary>
        public string developmentCode
        {
            get; set;
        }
        /// <summary>
        /// 版本概要
        /// </summary>
        public string summary
        {
            get; set;
        }
        /// <summary>
        /// 是否为最新pub版本
        /// </summary>
        public bool isNewVer
        {
            get; set;
        }
        /// <summary>
        /// 最新pub版本下载URL
        /// </summary>
        public string newVerURL
        {
            get; set;
        }
    }

    /// <summary>
    /// 查询位置
    /// </summary>
    public struct Posi
    {
        /// <summary>
        /// 被操作表所在数据库名
        /// </summary>
        public string dataBase { get; set; }
        /// <summary>
        /// 被操作表名
        /// </summary>
        public string table { get; set; }
        /// <summary>
        /// 定位列的列名
        /// </summary>
        public string whereColumn { get; set; }
        /// <summary>
        /// 目标列的列名，目标列承担读取/更改操作
        /// </summary>
        public string targetColumn { get; set; }
    }
    /// <summary>
    /// 参数单元（用于参数化查询添加参数）
    /// </summary>
    public struct Para
    {
        /// <summary>
        /// 参数名
        /// </summary>
        public string paraName { get; set; }
        /// <summary>
        /// 参数值
        /// </summary>
        public object paraValue { get; set; }
    }

    /// <summary>
    /// 索引表数据接口
    /// </summary>
    public interface IPaTextIndex
    {
        /// <summary>
        /// 文本索引
        /// </summary>
        int text_id { get; set; }
        /// <summary>
        /// 文本模式
        /// </summary>
        string text_mode { get; set; }
        /// <summary>
        /// 文本类型
        /// </summary>
        string text_type { get; set; }
    }
    /// <summary>
    /// 主表数据接口
    /// </summary>
    public interface IPaTextMain
    {
        /// <summary>
        /// 文本标题
        /// </summary>
        string text_title { get; set; }
        /// <summary>
        /// 文本概要
        /// </summary>
        string text_summary { get; set; }
        /// <summary>
        /// 文本正文
        /// </summary>
        string text_content { get; set; }
    }
    /// <summary>
    /// 副表数据接口
    /// </summary>
    public interface IPaTextSub
    {
        /// <summary>
        /// 文本归类
        /// </summary>
        string text_class { get; set; }
        /// <summary>
        /// 文本作者
        /// </summary>
        string text_editor { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        DateTime date_created { get; set; }
        /// <summary>
        /// 变更日期
        /// </summary>
        DateTime date_changed { get; set; }
        /// <summary>
        /// 浏览计数
        /// </summary>
        int count_pv { get; set; }
        /// <summary>
        /// 评论计数
        /// </summary>
        int count_comment { get; set; }
        /// <summary>
        /// 点赞计数
        /// </summary>
        int count_like { get; set; }
        /// <summary>
        /// 标签集合
        /// </summary>
        string tags { get; set; }
        /// <summary>
        /// 封面链接
        /// </summary>
        string cover_url { get; set; }
        /// <summary>
        /// 条带颜色
        /// </summary>
        string strip_color { get; set; }
    }
    /// <summary>
    /// 啪啦文本数据
    /// </summary>
    public struct PaText : IPaTextIndex, IPaTextMain, IPaTextSub
    {
        /* 索引表数据 */
        public int text_id { get; set; }
        public string text_mode { get; set; }
        public string text_type { get; set; }

        /* 主表数据 */
        public string text_title { get; set; }
        public string text_summary { get; set; }
        public string text_content { get; set; }

        /* 副表数据 */
        public string text_class { get; set; }
        public string text_editor { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_changed { get; set; }
        public int count_pv { get; set; }
        public int count_comment { get; set; }
        public int count_like { get; set; }
        public string tags { get; set; }
        public string cover_url { get; set; }
        public string strip_color { get; set; }
    }

    /// <summary>
    /// 权限数据接口
    /// </summary>
    public interface IPaRoot
    {
        /// <summary>
        /// 权限ID
        /// </summary>
        int root_id { get; set; }
        /// <summary>
        /// 权限定义者
        /// </summary>
        string root_definer { get; set; }
        /// <summary>
        /// 站点开发者模式状态
        /// </summary>
        bool site_debug { get; set; }
        /// <summary>
        /// 站点可用（该值用于关闭站点）
        /// </summary>
        bool site_access { get; set; }
        /// <summary>
        /// 站点URL
        /// </summary>
        string site_url { get; set; }
        /// <summary>
        /// 站点标题
        /// </summary>
        string site_title { get; set; }
        /// <summary>
        /// 站点概要
        /// </summary>
        string site_summary { get; set; }
    }
    /// <summary>
    /// 权限数据
    /// </summary>
    public struct PaRoot : IPaRoot
    {
        public int root_id { get; set; }
        public string root_definer { get; set; }
        public bool site_debug { get; set; }
        public bool site_access { get; set; }
        public string site_url { get; set; }
        public string site_title { get; set; }
        public string site_summary { get; set; }
    }

    /// <summary>
    /// 啪啦数据库信息
    /// </summary>
    public struct PalaDB : IPalaRoot
    {
        /// <summary>
        /// Pala数据表所在数据库
        /// </summary>
        public string dataBase { get; set; }
        /// <summary>
        /// 文本表
        /// </summary>
        public PalaRoot.Tables Tables { get; set; }
        /// <summary>
        /// 文本视图
        /// </summary>
        public PalaRoot.Views Views { get; set; }
        /// <summary>
        /// 数据库管理器实例
        /// </summary>
        public MySqlConnH MySqlConnH { get; set; }
    }
}
namespace StudioLibrary
{
    /// <summary>
    /// SL根级控制器
    /// </summary>
    namespace Root
    {
        /// <summary>
        /// SL结构体控制
        /// </summary>
        namespace LibStructs { }
        /// <summary>
        /// SL架构控制
        /// </summary>
        namespace LibFrame { }
    }
    /// <summary>
    /// 算术单元
    /// </summary>
    namespace sansuUnit { }
    /// <summary>
    /// 数据单元
    /// </summary>
    namespace sukiUnit { }
    /// <summary>
    /// 业务单元
    /// </summary>
    namespace jarwUnit
    {
        namespace pilipala
        {
            namespace UI { }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;/* hash&md5 */
using System.Drawing;/* GDI+ */


namespace sansuUnit
{
    /// <summary>
    /// 加密算法
    /// </summary>
    public class Encryptor
    {
        private delegate string MD5Handler(string Str);//声明用于toMD5的委托
                                                       /// <summary>
                                                       /// MD5方法
                                                       /// </summary>
                                                       /// <param name="str">被加密的字符串</param>
                                                       /// <returns>通常返回MD5加密结果，报错则返回错误信息</returns>
        public virtual string md5(string str)
        {
            MD5Handler Mh = new MD5Handler(pvtToMD5);
            IAsyncResult result = Mh.BeginInvoke(str, null, null);

            return Mh.EndInvoke(result);
        }//实际用于调用的方法

        private string pvtToMD5(string input_str)
        {
            try
            {
                var buffer = Encoding.Default.GetBytes(input_str);
                var data = MD5.Create().ComputeHash(buffer);

                var md5 = new StringBuilder();
                foreach (var temp in data)
                {
                    md5.Append(temp.ToString("X2"));
                }

                return md5.ToString();//返回
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        private delegate string HashHandler(string Str);//声明用于toHash的委托
                                                        /// <summary>
                                                        /// 散列方法
                                                        /// </summary>
                                                        /// <param name="str">被加密的字符串</param>
                                                        /// <returns>通常返回散列加密结果，报错则返回错误信息</returns>
        public virtual string hash(string str)
        {
            HashHandler Hh = new HashHandler(pvtToHash);
            IAsyncResult result = Hh.BeginInvoke(str, null, null);

            return Hh.EndInvoke(result);
        }//实际用于调用的方法
        private string pvtToHash(string input_str)
        {
            try
            {
                var buffer = Encoding.UTF8.GetBytes(input_str);//将输入字符串转换成字节数组
                var data = SHA1.Create().ComputeHash(buffer);//创建SHA1对象进行散列计算

                var sha = new StringBuilder();//创建一个新的Stringbuilder收集字节
                foreach (var temp in data)//遍历每个字节的散列数据 
                {
                    sha.Append(temp.ToString("X2"));//格式每一个十六进制字符串
                }

                return sha.ToString();//返回
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }

    /// <summary>
    /// 排序算法
    /// </summary>
    public class Sorter
    {
        /// <summary>
        /// 交换值的方法，引用类型
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        static private void pvtExch(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }
        /// <summary>
        /// 比较大小的方法
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        static private bool pvtLess(int i, int j)
        {
            return i.CompareTo(j) < 0;
        }

        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="array">被排序的数组</param>
        /// <returns>通常返回有序数组(由小到大)，报错则返回null</returns>
        public virtual T[] easySort<T>(T[] array) where T : IComparable
        {
            try
            {
                for (int path = 0; path < array.Length; path++)//正被有序的起始位
                {
                    for (int i = 0; i < array.Length; i++)//临近元素排序
                    {
                        if (i + 1 < array.Length)//元素交换
                        {
                            T tmp; ;
                            if (array[i].CompareTo(array[i + 1]) > 0)
                            {
                                tmp = array[i];
                                array[i] = array[i + 1];
                                array[i + 1] = tmp;
                            }
                        }

                    }
                }
                return array;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 希尔排序
        /// </summary>
        /// <param name="array">待排序的整数组</param>
        /// <returns>返回排序完成的数组</returns>
        public virtual int[] shellSort(int[] array)
        {
            int N = array.Length;
            int h = 1;

            while (h < N / 3)
                h = 3 * h + 1;
            while (h >= 1)
            {
                for (int i = h; i < N; i++)
                {
                    for (int j = i; j >= h && pvtLess(array[j], array[j - h]); j -= h)
                        pvtExch(ref array[j], ref array[j - h]);
                }
                h = h / 3;
            }

            return array;
        }
    }

    /// <summary>
    /// 检索类算法
    /// </summary>
    public class Searcher
    {
        /// <summary>
        /// 二分法检索(重载一),适用于整型检索
        /// </summary>
        /// <param name="value">被检索值</param>
        /// <param name="array">数组,顺序由小到大</param>
        /// <returns>若数组存在被检索值,则返回值在数组中的位置,若不存在则返回-1,报错则返回-2</returns>
        public virtual int binarySearch(int value, int[] array)
        {
            try//二分法主体
            {
                int low = 0;
                int high = array.Length - 1;
                while (low <= high)
                {
                    int mid = (low + high) / 2;

                    if (value == array[mid])
                    {
                        return mid;
                    }
                    if (value > array[mid])
                    {
                        low = mid + 1;
                    }
                    if (value < array[mid])
                    {
                        high = mid - 1;
                    }
                }
                return -1;
            }
            catch
            {
                return -2;
            }
        }

        /// <summary>
        /// 二分法检索(重载二),适用于双精度浮点检索
        /// </summary>
        /// <param name="value">被检索值</param>
        /// <param name="array">数组，顺序由小到大</param>
        /// <returns>若数组存在被检索值,则返回值在数组中的位置,若不存在则返回-1,报错则返回-2</returns>
        public virtual double binarySearch(double value, double[] array)
        {
            try//二分法主体
            {
                double low = 0;
                double high = array.Length - 1;
                while (low <= high)
                {
                    int mid = (int)(low + high) / 2;

                    if (value == array[mid])
                    {
                        return mid;
                    }
                    if (value > array[mid])
                    {
                        low = mid + 1;
                    }
                    if (value < array[mid])
                    {
                        high = mid - 1;
                    }
                }
                return -1;
            }
            catch
            {
                return -2;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;/* IO */
using System.Xml;/* XML */
using MySql.Data.MySqlClient;/* MySqlDB */
using System.Data;/* ADO.NET */

using LibStructs;

namespace sukiUnit
{
    /// <summary>
    /// 文件控制器
    /// </summary>
    public class FileHandler
    {
        /// <summary>
        /// 以字符串形式输出文件（重载一）（UTF8编码模式）
        /// </summary>
        /// <param name="url">文件所在的本地网络路径</param>
        /// <returns>返回字符串</returns>
        public string fileToStr(string url)
        {
            //读取url文件到文件尾，然后返回
            return LibFrame.LibInformation.getStreamReader(url).ReadToEnd();
        }

        /// <summary>
        /// 以字符串形式输出文件（重载二）
        /// </summary>
        /// <param name="url">文件所在的本地网络路径</param>
        /// /// <param name="encodingType">解析文件所用的编码模式</param>
        /// <returns>返回字符串</returns>
        public string fileToStr(string url, string encodingType)
        {
            //读取url文件到文件尾，然后返回
            return LibFrame.LibInformation.getStreamReader(url, encodingType).ReadToEnd();
        }

        /// <summary>
        /// 以字符串形式输出文件（重载三）（UTF8编码模式）
        /// </summary>
        /// <param name="filePath">文件所在的本地物理路径</param>
        /// <param name="bufferSize">文件流缓冲区大小，默认值可填4096</param>
        /// <param name="useAsync">使用异步初始化文件流，缺乏设计的异步调用会慢于串行调用</param>
        /// <returns>返回字符串</returns>
        public string fileToStr(string filePath, int bufferSize, bool useAsync)
        {

            using (
                StreamReader StreamReader = new StreamReader//流读取对象
                (new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Write, bufferSize, useAsync)//文件流对象
                , Encoding.GetEncoding("UTF8"))//指定编码模式
                    )
            {
                //以字符串形式输出文件
                return StreamReader.ReadToEnd().ToString();
            }
        }

        /// <summary>
        /// 以字符串形式输出文件（重载四）
        /// </summary>
        /// <param name="filePath">文件所在的本地物理路径</param>
        /// <param name="bufferSize">文件流缓冲区大小，默认值可填4096</param>
        /// <param name="useAsync">使用异步初始化文件流，缺乏设计的异步调用会慢于串行调用</param>
        /// <param name="encodingType">解析文件所用的编码模式</param>
        /// <returns>返回字符串</returns>
        public string fileToStr(string filePath, int bufferSize, bool useAsync, string encodingType)
        {

            using (
                StreamReader StreamReader = new StreamReader//流读取对象
                (new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Write, bufferSize, useAsync)//文件流对象
                , Encoding.GetEncoding(encodingType))//指定编码模式
                    )
            {
                //以字符串形式输出文件
                return StreamReader.ReadToEnd().ToString();
            }

        }
    }

    /// <summary>
    /// XML文件读写类
    /// </summary>
    public class XmlHandler
    {
        //xml文档地址，默认为运行目录的"StdLibx.xml"
        private string xpath = Directory.GetCurrentDirectory() + @"\StdLibx.xml";
        static XmlDocument xDoc = new XmlDocument();

        /// <summary>
        /// 指定流的方法
        /// </summary>
        /// <param name="xStream">文件流地址</param>
        /// <returns>通常返回true，报错则返回false</returns>
        public bool reStream(string xStream)
        {
            try
            {
                xpath = xStream;
                xDoc.Load(xpath);
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 创建Xml文档的方法（重载一）
        /// </summary>
        /// <param name="fileName">Xml文档被创建的目录</param>
        /// <param name="xmlName">Xml文档名</param>
        /// <param name="rootName">根节点名</param>
        /// <returns>通常返回true，报错则返回false</returns>
        public bool createXml(string fileName, string xmlName, string rootName)
        {
            try
            {
                XmlDocument newDoc = new XmlDocument();//doc模式读写
                XmlNode node_xml = newDoc.CreateXmlDeclaration("1.0", "utf-8", "");
                newDoc.AppendChild(node_xml);
                XmlNode root = newDoc.CreateElement(rootName);//创建根节点
                newDoc.AppendChild(root);//添加根节点

                newDoc.Save(fileName + @"\" + xmlName + ".xml");
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 创建Xml文档的方法（重载二）
        /// </summary>
        /// <param name="XmlSign">Xml文档信息通用结构体</param>
        /// <returns>通常返回true，报错则返回false</returns>
        public bool createXml(XmlSign XmlSign)
        {
            try
            {
                XmlDocument newDoc = new XmlDocument();//doc模式读写
                XmlNode node_xml = newDoc.CreateXmlDeclaration("1.0", "utf-8", "");
                newDoc.AppendChild(node_xml);
                XmlNode root = newDoc.CreateElement(XmlSign.rootName);//创建根节点
                newDoc.AppendChild(root);//添加根节点

                newDoc.Save(XmlSign.fileName + @"\" + XmlSign.xmlName + ".xml");
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 添加实节点的方法（重载一）
        /// </summary>
        /// <param name="path">被指定的父节点</param>
        /// <param name="nodeName">新建的节点名</param>
        /// <param name="attName">节点的属性</param>
        /// <param name="attValue">节点的属性值</param>
        /// <param name="innerText">节点的子文本</param>
        /// <returns>通常返回true，报错则返回false</returns>
        public bool addRealNode(string path, string nodeName, string attName, string attValue, string innerText)
        {
            try
            {
                XmlNode parentNode = xDoc.SelectSingleNode(path);//父节点指定
                XmlNode newNode = xDoc.CreateElement(nodeName);//创建新的子节点
                XmlAttribute newAtt = xDoc.CreateAttribute(attName);//创建用于新的子节点的一个属性

                newAtt.Value = attValue;//属性的值指定
                newNode.Attributes.Append(newAtt);//添加属性到节点

                newNode.InnerText = innerText;

                parentNode.AppendChild(newNode);//在父节点上添加该节点
                xDoc.Save(xpath);//保存到xpath
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 添加实节点的方法（重载二）
        /// </summary>
        /// <param name="XmlSign">Xml文档信息通用结构体</param>
        /// <returns>通常返回true，报错则返回false</returns>
        public bool addRealNode(XmlSign XmlSign)
        {
            try
            {
                XmlNode parentNode = xDoc.SelectSingleNode(XmlSign.path);//父节点指定
                XmlNode newNode = xDoc.CreateElement(XmlSign.nodeName);//创建新的子节点
                XmlAttribute newAtt = xDoc.CreateAttribute(XmlSign.attName);//创建用于新的子节点的一个属性

                newAtt.Value = XmlSign.attValue;//属性的值指定
                newNode.Attributes.Append(newAtt);//添加属性到节点

                newNode.InnerText = XmlSign.innerText;

                parentNode.AppendChild(newNode);//在父节点上添加该节点
                xDoc.Save(xpath);//保存到xpath
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 添加空节点的方法（重载一）
        /// </summary>
        /// <param name="path">被指定的父节点</param>
        /// <param name="nodeName">新建的空节点名</param>
        /// <returns>通常返回true，报错则返回false</returns>
        public bool addEmptyNode(string path, string nodeName)
        {
            try
            {
                XmlNode pxn = xDoc.SelectSingleNode(path);
                XmlNode nxn = xDoc.CreateElement(nodeName);
                pxn.AppendChild(nxn);
                xDoc.Save(xpath);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 添加空节点的方法（重载二）
        /// </summary>
        /// <param name="XmlSign">Xml文档信息通用结构体</param>
        /// <returns>通常返回true，报错则返回false</returns>
        public bool addEmptyNode(XmlSign XmlSign)
        {
            try
            {
                XmlNode Pxn = xDoc.SelectSingleNode(XmlSign.path);
                XmlNode Cxn = xDoc.CreateElement(XmlSign.nodeName);
                Pxn.AppendChild(Cxn);
                xDoc.Save(xpath);
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 删除被指定的父节点下子节点的方法（重载一）
        /// </summary>
        /// <param name="path">被指定的父节点</param>
        /// <param name="nodeName">被删的子节点名</param>
        /// <returns>通常返回true，报错则返回false</returns>
        public bool removeNode(string path, string nodeName)
        {
            try
            {
                XmlNode baseNode = xDoc.SelectSingleNode(path);//指定父节点
                XmlNodeList xnList = baseNode.ChildNodes;//初始化父节点的子节点列
                foreach (XmlNode n in xnList)//遍历每一个节点
                {
                    if (n.Name == nodeName)//判断节点名
                    {
                        baseNode.RemoveChild(n);

                        xDoc.Save(xpath);
                        break;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 删除被指定的父节点下子节点的方法（重载二）
        /// </summary>
        /// <param name="XmlSign">Xml文档信息通用结构体</param>
        /// <returns>通常返回true，报错则返回false</returns>
        public bool removeNode(XmlSign XmlSign)
        {
            try
            {
                XmlNode baseNode = xDoc.SelectSingleNode(XmlSign.path);//指定父节点
                XmlNodeList xnList = baseNode.ChildNodes;//初始化父节点的子节点列
                foreach (XmlNode n in xnList)//遍历每一个节点
                {
                    if (n.Name == XmlSign.nodeName)//判断节点名
                    {
                        baseNode.RemoveChild(n);

                        xDoc.Save(xpath);
                        break;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 读取被指定的实节点的信息的方法（重载一）
        /// </summary>
        /// <param name="path">被指定的实节点</param>
        /// <param name="type">被读取的信息类型</param>
        /// <returns>通常返回被读取的信息，传递未知的type返回"UnknownReadingType"，报错则返回null</returns>
        public string readInformation(string path, string type)
        {
            try
            {
                XmlNode xn = xDoc.SelectSingleNode(path);
                switch (type)
                {
                    case "_name":
                        return xn.Name;
                    case "_value":
                        return xn.InnerText;
                    default:
                        return "UnknownReadingType";
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 读取被指定的实节点的信息的方法（重载二）
        /// </summary>
        /// <param name="XmlSign">Xml文档信息通用结构体</param>
        /// <returns>通常返回被读取的信息，传递未知的type返回"UnknownReadingType"，报错则返回null</returns>
        public string readInformation(XmlSign XmlSign)
        {
            try
            {
                XmlNode xn = xDoc.SelectSingleNode(XmlSign.path);
                switch (XmlSign.type)
                {
                    case "_name":
                        return xn.Name;
                    case "_value":
                        return xn.InnerText;
                    default:
                        return "UnknownReadingType";
                }
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// 读取被指定的实节点的属性值的方法（重载一）
        /// </summary>
        /// <param name="path">被指定的实节点</param>
        /// <param name="attName">被读值的属性名</param>
        /// <returns>通常返回被读取属性的值，报错则返回null</returns>
        public string readAttribute(string path, string attName)
        {
            try
            {
                XmlNode xn = xDoc.SelectSingleNode(path);
                return xn.Attributes[attName].Value;
            }
            catch
            {
                return null;//方法中发生致命性错误，可能是由无法查找到节点属性导致
            }
        }
        /// <summary>
        /// 读取被指定的实节点的属性值的方法（重载二）
        /// </summary>
        /// <param name="XmlSign">Xml文档信息通用结构体</param>
        /// <returns>通常返回被读取属性的值，报错则返回null</returns>
        public string readAttribute(XmlSign XmlSign)
        {
            try
            {
                XmlNode xn = xDoc.SelectSingleNode(XmlSign.path);
                return xn.Attributes[XmlSign.attName].Value;
            }
            catch
            {
                return null;//方法中发生致命性错误，可能是由无法查找到节点属性导致
            }
        }

    }

    /// <summary>
    /// MySql数据库管理器
    /// </summary>
    public class MySqlConnH
    {
        /* 
         * 内置查询方法不会关闭(销毁)任何一个数据库连接
         * 若存在安全性需要，HCommand会被设置为null，但不会关闭(销毁)
         * 只有调用相关方法时才会执行该方面的操作
         */

        private MySqlConnection HConnection;
        private MySqlCommand HCommand;

        /// <summary>
        /// close主连接
        /// </summary>
        /// <returns>成功返回ture，反之或报错返回false</returns>
        public bool closeHConnection()
        {
            try
            {
                switch (HConnection.State)
                {
                    case ConnectionState.Open:
                        HConnection.Close();
                        if (HConnection.State == ConnectionState.Closed)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case ConnectionState.Closed:
                        return true;

                    default:
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// dispose主连接
        /// </summary>
        /// <returns>成功返回ture，反之或报错返回false</returns>
        public bool disposeHConnection()
        {
            try
            {
                switch (HConnection.State)
                {
                    case ConnectionState.Open:
                        HConnection.Dispose();
                        if (HConnection.State == ConnectionState.Closed)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case ConnectionState.Closed:
                        return true;

                    default:
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 将主连接设置为null值
        /// </summary>
        /// <returns>成功返回ture，反之或报错返回false</returns>
        public bool nullHConnection()
        {
            try
            {
                HConnection = null;
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 重启主连接（须以主连接定义完成为前提）
        /// </summary>
        /// <returns>成功返回ture，反之或报错返回false</returns>
        public bool restartHConnection()
        {
            try
            {
                switch (HConnection.State)
                {
                    case ConnectionState.Closed:
                        HConnection.Open();
                        if (HConnection.State == ConnectionState.Open)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case ConnectionState.Open:
                        return true;//注意，在连接打开时调用该方法再次打开也会返回true，这可能会带来安全性问题

                    default:
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// dispose主命令行
        /// </summary>
        /// <returns>成功返回ture，反之或报错返回false</returns>
        public bool disposeHCommand()
        {
            try
            {
                HCommand.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 将主命令行设置为null值
        /// </summary>
        /// <returns>成功返回ture，反之或报错返回false</returns>
        public bool nullHCommand()
        {
            try
            {
                HCommand = null;
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 设置主命令行的sql语句（重载一）（注意：此方法可能会引起未知的ACID问题，建议仅供调试使用）
        /// </summary>
        /// <param name="MySqlConnection">要求主命令行执行的MySqlConnection连接实例</param>
        /// <param name="sql">被设置的sql语句</param>
        /// <returns>成功返回ture，反之或报错返回false</returns>
        public bool setHCommand(MySqlConnection MySqlConnection, string sql)
        {
            try
            {
                HCommand = new MySqlCommand(sql, MySqlConnection);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 设置主命令行的sql语句（重载二：HConnection介入）（注意：此方法可能会引起未知的ACID问题，建议仅供调试使用）
        /// </summary>
        /// <param name="sql">被设置的sql语句</param>
        /// <returns>成功返回ture，反之或报错返回false</returns>
        public bool setHCommand(string sql)
        {
            try
            {
                HCommand = new MySqlCommand(sql, HConnection);
                return true;
            }
            catch
            {
                return false;
            }
        }



        /// <summary>
        /// 启动连接（重载一：HConnection介入）
        /// </summary>
        /// <param name="dataSource">数据源</param>
        /// <param name="port">端口</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>返回true，错误则返回null</returns>
        public bool start(string dataSource, string port, string userName, string password)
        {
            //组建连接信息并创建连接
            HConnection = new MySqlConnection
                (
                "Data source=" + dataSource + ";port="
                + port + ";User Id=" + userName + ";password=" + password + ";"
                );
            return start(HConnection);
        }
        /// <summary>
        /// 启动连接（重载二：HConnection介入）
        /// </summary>
        /// <param name="ConnSign">连接签名</param>
        /// <returns>返回true，错误则返回false</returns>
        public bool start(ConnSign ConnSign)
        {
            //组建连接信息并创建连接
            HConnection = new MySqlConnection
                (
                "Data source=" + ConnSign.dataSource + ";port=" +
                ConnSign.port + ";User Id=" + ConnSign.user + ";password=" + ConnSign.password + ";"
                );
            return start(HConnection);
        }
        /// <summary>
        /// 启动连接（重载三）
        /// </summary>
        /// <param name="MySqlConnection">MySqlConnection连接实例</param>
        /// <returns>返回true，错误则返回false</returns>
        public bool start(MySqlConnection MySqlConnection)
        {
            switch (MySqlConnection.State)
            {
                case ConnectionState.Closed:
                    MySqlConnection.Open();
                    if (MySqlConnection.State == ConnectionState.Open)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case ConnectionState.Open:
                    return true;//注意，在连接打开时调用该方法再次打开也会返回true，这可能会带来安全性问题

                default:
                    return false;
            }
        }



        /// <summary>
        /// 获得数据行（重载一）
        /// </summary>
        /// <param name="MySqlConnection">MySqlConnection连接实例</param>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回查询结果</returns>
        public DataRow getRow(MySqlConnection MySqlConnection, string sql)
        {
            try
            {
                if (MySqlConnection.State == ConnectionState.Closed)//判断连接是否被关闭
                {
                    MySqlConnection.Open();//连接关闭则打开
                }
                using (MySqlDataAdapter myDA = new MySqlDataAdapter(sql, MySqlConnection))
                {
                    DataTable DataTable = new DataTable();
                    myDA.Fill(DataTable);

                    return DataTable.Rows[0];
                }
            }
            finally//释放资源
            {
                HCommand = null;
            }
        }
        /// <summary>
        /// 获得数据行（重载二）（适用于参数化查询）
        /// </summary>
        /// <param name="MySqlConnection">MySqlConnection连接实例</param>
        /// <param name="MySqlCommand">MySqlCommand对象，用于进行查询</param>
        /// <returns>返回查询结果</returns>
        public DataRow getRow(MySqlConnection MySqlConnection, MySqlCommand MySqlCommand)
        {
            try
            {
                if (MySqlConnection.State == ConnectionState.Closed)//判断连接是否被关闭
                {
                    MySqlConnection.Open();//连接关闭则打开
                }
                //将外来cmd设置为基于MySqlConnection执行
                MySqlCommand.Connection = MySqlConnection;
                using (MySqlDataAdapter myDA = new MySqlDataAdapter(MySqlCommand))
                {
                    DataTable DataTable = new DataTable();
                    myDA.Fill(DataTable);

                    return DataTable.Rows[0];
                }
            }
            finally//释放资源
            {
                HCommand = null;
            }
        }
        /// <summary>
        /// 获得数据行（重载三：HConnection介入）
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回查询结果</returns>
        public DataRow getRow(string sql)
        {
            try
            {
                if (HConnection.State == ConnectionState.Closed)//判断连接是否被关闭
                {
                    HConnection.Open();//连接关闭则打开
                }
                using (MySqlDataAdapter myDA = new MySqlDataAdapter(sql, HConnection))
                {
                    DataTable DataTable = new DataTable();
                    myDA.Fill(DataTable);

                    return DataTable.Rows[0];
                }
            }
            finally//释放资源
            {
                HCommand = null;
            }
        }
        /// <summary>
        /// 获得数据行（重载四：HConnection介入）（适用于参数化查询）
        /// </summary>
        /// <param name="MySqlCommand">MySqlCommand对象，用于进行查询</param>
        /// <returns>返回查询结果</returns>
        /// 
        public DataRow getRow(MySqlCommand MySqlCommand)
        {
            try
            {
                if (HConnection.State == ConnectionState.Closed)//判断连接是否被关闭
                {
                    HConnection.Open();//连接关闭则打开
                }
                //将外来cmd设置为基于HConnection执行
                MySqlCommand.Connection = HConnection;
                using (MySqlDataAdapter myDA = new MySqlDataAdapter(MySqlCommand))
                {
                    DataTable DataTable = new DataTable();
                    myDA.Fill(DataTable);

                    return DataTable.Rows[0];
                }
            }
            finally//释放资源
            {
                HCommand = null;
            }
        }
        /// <summary>
        /// 获得数据行（重载五：通过键值匹配，从数据表中获取数据行）
        /// </summary>
        /// <param name="DataTable">数据表实例</param>
        /// <param name="keyName">键名</param>
        /// <param name="keyValue">键值</param>
        /// <returns>返回获得的DataRow数据行实例，未检索到返回null</returns>
        public DataRow getRow(DataTable DataTable, string keyName, object keyValue)
        {
            foreach (DataRow DataRow in DataTable.Rows)
            {
                if (//全部转为string来判断是否相等，因为object箱结构不一样
                    DataRow[keyName].ToString() == keyValue.ToString()
                    )
                {
                    return DataRow;//返回符合被检索主键的行
                }
            }
            return null;//没找到返回bull
        }

        /// <summary>
        /// 抛出一个MySql连接（重载一）
        /// </summary>
        /// <param name="dataSource">数据源</param>
        /// <param name="port">端口</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>返回一个MySqlConnection对象，错误则返回null</returns>
        public MySqlConnection getConnection(string dataSource, string port, string userName, string password)
        {
            try
            {
                //返回创建的连接
                return new MySqlConnection
                    (//组建连接信息
                    "Data source=" + dataSource + ";port="
                    + port + ";User Id=" + userName + ";password=" + password + ";"
                    );
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 抛出一个MySql连接（重载二）
        /// </summary>
        /// <param name="ConnSign">连接签名</param>
        /// <returns>返回一个MySqlConnection对象，错误则返回null</returns>
        public MySqlConnection getConnection(ConnSign ConnSign)
        {
            try
            {
                //返回创建的连接
                return new MySqlConnection
                    (//组建连接信息
                    "Data source=" + ConnSign.dataSource + ";port=" +
                    ConnSign.port + ";User Id=" + ConnSign.user + ";password=" + ConnSign.password + ";"
                    );
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取一张数据表（重载一）
        /// </summary>
        /// <param name="MySqlConnection">MySqlConnection连接实例</param>
        /// <param name="sql">用于查询数据表的SQL语句</param>
        /// <returns>返回一个DataTable对象，错误则返回null</returns>
        public DataTable getTable(MySqlConnection MySqlConnection, string sql)
        {
                //新建数据适配器
                MySqlDataAdapter myDA = new MySqlDataAdapter(sql, MySqlConnection);
                if (MySqlConnection.State == ConnectionState.Closed)//检测是否开启
                {
                    MySqlConnection.Open();
                }

                //新建数据表
                DataTable table = new DataTable();
                myDA.Fill(table);//填充数据到table

                return table;
        }
        /// <summary>
        /// 获取一张数据表（重载二）（适用于参数化查询）
        /// </summary>
        /// <param name="MySqlConnection">MySqlConnection连接实例</param>
        /// <param name="MySqlCommand">MySqlCommand对象，用于进行查询</param>
        /// <returns>返回一个DataTable对象，错误则返回null</returns>
        public DataTable getTable(MySqlConnection MySqlConnection, MySqlCommand MySqlCommand)
        {
                //将外来cmd设置为基于MySqlConnection执行
                MySqlCommand.Connection = MySqlConnection;
                //新建数据适配器，以外来cmd初始化
                MySqlDataAdapter myDA = new MySqlDataAdapter(MySqlCommand);
                if (MySqlConnection.State == ConnectionState.Closed)//检测是否开启
                {
                    MySqlConnection.Open();
                }

                //新建数据表
                DataTable table = new DataTable();
                myDA.Fill(table);//填充数据到table

                return table;
        }
        /// <summary>
        /// 获取一张数据表（重载三：HConnection介入）
        /// </summary>
        /// <param name="sql">SQL语句，用于查询数据表</param>
        /// <returns>返回一个DataTable对象，错误则返回null</returns>
        public DataTable getTable(string sql)
        {
                //新建数据适配器
                MySqlDataAdapter myDA = new MySqlDataAdapter(sql, HConnection);
                if (HConnection.State == ConnectionState.Closed)
                {
                    HConnection.Open();
                }

                //新建数据表
                DataTable table = new DataTable();
                myDA.Fill(table);//填充数据到DataTable

                return table;
        }
        /// <summary>
        /// 获取一张数据表（重载四：HConnection介入）（适用于参数化查询）
        /// </summary>
        /// <param name="MySqlCommand">MySqlCommand对象，用于进行查询</param>
        /// <returns>返回一个DataTable对象，错误则返回null</returns>
        public DataTable getTable(MySqlCommand MySqlCommand)
        {
                //将外来cmd设置为基于HConnection执行
                MySqlCommand.Connection = HConnection;
                //新建数据适配器，以外来cmd初始化
                MySqlDataAdapter myDA = new MySqlDataAdapter(MySqlCommand);
                if (HConnection.State == ConnectionState.Closed)
                {
                    HConnection.Open();
                }

                //新建数据表
                DataTable table = new DataTable();
                myDA.Fill(table);//填充数据到DataTable

                return table;
        }

        /// <summary>
        /// 从数据表中提取取数据列
        /// </summary>
        /// <param name="DataTable">数据表实例</param>
        /// <param name="columnName">列名</param>
        /// <returns>返回非泛型List{object}实例，错误则返回null</returns>
        public List<object> getColumn(DataTable DataTable, string columnName)
        {
            try
            {
                List<object> list = new List<object>();
                foreach (DataRow DataRow in DataTable.Rows)
                {
                    list.Add(DataRow[columnName]);//将数据表中columnName列的所有行数据依次添加到list中
                }
                return list;//返回列
            }
            catch
            {
                return null;
            }
        }



        /// <summary>
        /// 设置(替换)一个行的列值（字符串匹配）
        /// </summary>
        /// <param name="MySqlConnection">数据库连接实例，用于承担该操作</param>
        /// <param name="locateStr">用于定位行和列的结构体</param>
        /// <param name="whereColumnValue">定位列的列值</param>
        /// <param name="targetColumnValue">被改列的改值</param>
        /// <returns>操作成功返回true</returns>
        public bool setColumnValue(MySqlConnection MySqlConnection, Posi locateStr, string whereColumnValue, string targetColumnValue)
        {
            #region SQL字符串处理
            string sql = "UPDATE `" + locateStr.dataBase + "`.`" + locateStr.table
                       + "` SET `" + locateStr.targetColumn + "`= '" + targetColumnValue
                       + "' WHERE `" + locateStr.whereColumn + "`= '" + whereColumnValue + "';";
            #endregion
            HCommand = new MySqlCommand(sql, MySqlConnection);
            try
            {
                if (HCommand.Connection.State == ConnectionState.Closed)//查询连接状况
                {
                    HCommand.Connection.Open();//若连接被关闭则打开连接
                }

                if (HCommand.ExecuteNonQuery() > 0)
                { return true; }//查询成功返回true
                else
                { return false; }//查询失败返回false
            }
            finally//释放内存
            {
                HCommand = null;
            }
        }
        /// <summary>
        /// 设置(替换)一个行的列值（重载二：HConnection介入）（字符串匹配）
        /// </summary>
        /// <param name="locateStr">用于定位行和列的结构体</param>
        /// <param name="whereColumnValue">定位列的列值</param>
        /// <param name="targetColumnValue">被改列的改值</param>
        /// <returns>操作成功返回true</returns>
        public bool setColumnValue(Posi locateStr, string whereColumnValue, string targetColumnValue)
        {
            #region SQL字符串处理
            string sql = "UPDATE `" + locateStr.dataBase + "`.`" + locateStr.table
                       + "` SET `" + locateStr.targetColumn + "`= '" + targetColumnValue
                       + "' WHERE `" + locateStr.whereColumn + "`= '" + whereColumnValue + "';";
            #endregion
            HCommand = new MySqlCommand(sql, HConnection);
            try
            {
                if (HCommand.Connection.State == ConnectionState.Closed)//查询连接状况
                {
                    HCommand.Connection.Open();//若连接被关闭则打开连接
                }

                if (HCommand.ExecuteNonQuery() > 0)
                { return true; }//查询成功返回true
                else
                { return false; }//查询失败返回false
            }
            finally//释放内存
            {
                HCommand = null;
            }
        }

        /// <summary>
        /// 获得一个行的列值（字符串匹配）（重载一）,如果查询到多个行，则只返回第一行的数据
        /// </summary>
        /// <param name="MySqlConnection">数据库连接实例，用于承担该操作</param>
        /// <param name="locateStr">用于定位行和列的结构体</param>
        /// <param name="whereColumnValue">定位列的列值</param>
        /// <returns>操作成功返回true</returns>
        public object getColumnValue(MySqlConnection MySqlConnection, Posi locateStr, string whereColumnValue)
        {
            #region SQL字符串处理
            string sql = "select " + locateStr.targetColumn
                       + " from " + locateStr.dataBase + "." + locateStr.table
                       + " where " + locateStr.whereColumn + " = " + whereColumnValue;
            #endregion
            HCommand = new MySqlCommand(sql, MySqlConnection);
            try
            {
                if (HCommand.Connection.State == ConnectionState.Closed)//查询连接状况
                {
                    HCommand.Connection.Open();//若连接被关闭则打开连接
                }
                return HCommand.ExecuteScalar();
            }
            finally//释放内存
            {
                HCommand = null;
            }
        }
        /// <summary>
        /// 获得一个行的列值（字符串匹配）（重载二：HConnection介入）,如果查询到多个行，则只返回第一行的数据
        /// </summary>
        /// <param name="locateStr">用于定位行和列的结构体</param>
        /// <param name="whereColumnValue">定位列的列值</param>
        /// <returns>操作成功返回true</returns>
        public object getColumnValue(Posi locateStr, string whereColumnValue)
        {
            #region SQL字符串处理
            string sql = "select " + locateStr.targetColumn
                       + " from " + locateStr.dataBase + "." + locateStr.table
                       + " where " + locateStr.whereColumn + " = " + whereColumnValue;
            #endregion
            HCommand = new MySqlCommand(sql, HConnection);
            try
            {
                if (HCommand.Connection.State == ConnectionState.Closed)//查询连接状况
                {
                    HCommand.Connection.Open();//若连接被关闭则打开连接
                }
                return HCommand.ExecuteScalar();
            }
            finally//释放内存
            {
                HCommand = null;
            }
        }

        /// <summary>
        /// 建立参数化查询cmd对象
        /// </summary>
        /// <param name="sql">携带查询参数的SQL语句</param>
        /// <param name="paraList">查询参数列表</param>
        /// <returns>返回建立的参数化查询cmd对象</returns>
        public MySqlCommand paraQueryCmd(string sql, List<Para> paraList)
        {
            //建立cmd对象，用于执行参数化查询
            using (MySqlCommand MySqlCommand = new MySqlCommand(sql))
            {
                foreach (Para para in paraList)
                {
                    MySqlCommand.Parameters.AddWithValue(para.paraName, para.paraValue);//添加参数
                }
                return MySqlCommand;
            }
        }
    }
}
@media only screen and (min-width: 1025px) {
.main {
    margin-left: auto;
    padding-top: 30px;
    padding-right: 0%;
    padding-left: 0%;
    padding-bottom: 33%;
    margin-right: auto;
    width: 1024px;
}
}

@media only screen and (max-width: 1024px) {
.main {
    margin-left: auto;
    padding-top: 1%;
    padding-right: 0%;
    padding-left: 0%;
    padding-bottom: 0%;
    margin-right: auto;
    width: 98%;
}
}
body {
    margin: 0px;
    font-family: sans-serif;
    font-weight: 300;
}
img {
    width: 100%;
    height: auto;
}
footer {
    position: fixed;
    bottom: 0;
    width: 100%;
    padding-top: 3px;
    padding-right: 0%;
    padding-left: 0%;
    padding-bottom: 3px;
    background-color: #980000;
    text-align: center;
}
pre {
word-break: break-all;
white-space: pre-wrap;
}
@media only screen and (min-width: 1025px) {
.siteBg {
    width: 100%;
    height: 100%;
    position: fixed;
    background-image: url("../img/siteBg1.jpg");
    background-size: inherit;
}
}

@media only screen and (max-width: 1024px) {
.siteBg {
    width: 100%;
    height: 100%;
    position: fixed;
    background-image: url("../img/siteBg1.jpg");
    background-size: inherit;
    background-position: center;
}
}
.arrow_up {
    background: transparent url("../img/arrow/arrow_up.svg");
    background-position: center;
    background-repeat: no-repeat;
}
.arrow_down {
    background: transparent url("../img/arrow/arrow_down.svg");
    background-position: center;
    background-repeat: no-repeat;
}
.LabelBg {
    background-image: url("../img/statuBg.jpg");
    background-repeat: repeat;
}
.BoxStrip {
    width: 22px;
    height: 34px;
    position: relative;
    float: right;
    background-position: top;
    background-size: contain;
    margin-right: 4%;
    margin-top: 0px;
}
.OrgStrip {
    background-image: url("../img/strip/strip_org.svg");
    background-repeat: no-repeat;
}
.BluStrip {
    background-image: url("../img/strip/strip_blu.svg");
    background-repeat: no-repeat;
}
.PrpStrip {
    background-image: url("../img/strip/strip_prp.svg");
    background-repeat: no-repeat;
}
.UserIMG_pic {
    background: transparent url("../img/p128.jpg");
    background-repeat: no-repeat;
    background-position: center;
    background-size: contain;
}
.Tran {
    transition-duration: 0.2s;
    transition-timing-function: ease;
}
.MagnT {
    margin-top: 2%;
}
.MagnB {
    margin-bottom: 2%;
}
.Shadow {
    box-shadow: 0px 0px 5px rgba(0, 0, 0, 0.07), 0px 0px 5px rgba(0, 0, 0, 0.07);
}
.RdiuT {
    border-top-left-radius: 10px;
    border-top-right-radius: 10px;
}
.RdiuB {
    border-bottom-left-radius: 10px;
    border-bottom-right-radius: 10px;
}
.fltL {
    float: left;
}
.fltN {
    float: none;
}
.flx {
    display: flex;
}
.flx_center {
    align-self: center;
}
a {
    color: inherit;
    text-decoration: inherit;
}
a:hover {
    color: inherit;
}
a:active {
    style: none;
}
a:visited {
    style: none;
}
.linked>a {
    color: #FFFFFF;
}
.linked>a:link {
    background: rgba(99,208,11,1.00);
    padding-left: 1%;
    padding-right: 1%;
    border-radius: 4px;
    text-decoration: inherit;
}
.linked>a:hover {
    color: #2200FF;
    background: rgba(99,208,11,0.40);
    text-decoration: inherit;
}
.hidden {
    padding-left: 1%;
    padding-right: 1%;
    border-radius: 4px;
    color: rgba(73,73,73,1.00);
    background: rgba(73,73,73,1.00);
}
.hidden:hover {
    color: #FFFFFF;
}
@font-face {
    font-family: 'LabelBoxFont';
    src: url('../FONT/LabelBox/LabelBoxFont.eot'), url('../FONT/LabelBox/LabelBoxFont.woff'), url('../FONT/LabelBox/LabelBoxFont.svg');
}
 @import "GuideHeadBox.css";
 @import "GuideCardBox.css";
 @import "TxtBox.css";
 @import "LabelBox.css";
 @import "CommentBox.css";

@media only screen and (min-width: 1025px) {
.GuideCol {
    width: 302px;
    position: fixed;
}
.GuideHead {
    width: 100%;
    padding-top: 14%;
    padding-right: inherit;
    padding-bottom: 0%;
    position: relative;
    background: linear-gradient(to top, rgba(73,73,73,0.90), rgba(73,73,73,0.8) 50%);
}
.SiteSummary {
    background-color: transparent;
    line-height: 24px;
    font-size: 20px;
    text-align: center;
    color: #FFFFFF;
    width: 88%;
    margin-top: 14%;
    margin-left: auto;
    margin-bottom: 0%;
    position: relative;
    margin-right: auto;
}
.UserMotto {
    background-color: rgba(127,127,127,0.86);
    width: 100%;
    padding-bottom: 7%;
    line-height: 18px;
    font-size: 16px;
    text-align: center;
    color: #FFFFFF;
    font-weight: 300;
    position: relative;
    margin-top: 12%;
    padding-top: 7%;
}
}

@media only screen and (max-width: 1024px) {
.GuideBoxCol {
    width: 100%;
}
.GuideHead {
    width: 100%;
    padding-top: 6%;
    padding-right: inherit;
    padding-bottom: 0%;
    position: relative;
    background: linear-gradient(to top, rgba(73,73,73,0.90), rgba(73,73,73,0.8) 50%);
}
.SiteSummary {
    background-color: transparent;
    line-height: 24px;
    font-size: 20px;
    text-align: center;
    color: #FFFFFF;
    width: 88%;
    margin-top: 5%;
    margin-left: auto;
    margin-bottom: 0%;
    position: relative;
    margin-right: auto;
}
.UserMotto {
    background-color: rgba(127,127,127,0.86);
    width: 100%;
    padding-bottom: 4%;
    line-height: 18px;
    font-size: 16px;
    text-align: center;
    color: #FFFFFF;
    font-weight: 300;
    position: relative;
    margin-top: 5%;
    padding-top: 4%;
}
}
.UserIMG {
    border-radius: 64px;
    width: 128px;
    height: 128px;
    margin-right: auto;
    margin-left: auto;
    transition-duration: 0.2s;
    transition-timing-function: ease;
}
.UserIMG:hover {
    box-shadow: 0px 0px 100px rgba(255, 255, 255, 0.3), 0px 0px 0px rgba(255, 255, 255, 0.3);
    transition-duration: 0.1s;
    transition-timing-function: ease;
}
@media only screen and (min-width: 1025px) {
.GuideCardBox {
    background: linear-gradient(to bottom, rgba(73,73,73,0.90), rgba(73,73,73,0.8) 50%);
    width: 100%;
    padding-bottom: 6%;
    position: relative;
    padding-top: 6%;
}
.CopyrightMark {
    width: 88%;
    position: relative;
    line-height: 12px;
    font-size: 12px;
    text-align: center;
    color: #FFFFFF;
    margin-top: 8%;
    margin-right: auto;
    margin-left: auto;
    margin-bottom: 0%;}
.GuideCard {
    width: 90%;
    position: relative;
    background-color: rgba(52,52,52,0.90);
    padding-top: 0%;
    padding-right: 0%;
    padding-left: 0%;
    padding-bottom: 0%;
    margin-top: 0%;
    margin-bottom: 1%;
    height: 54px;
    margin-left: auto;
    margin-right: auto;
}
}

@media only screen and (max-width: 1024px) {
.GuideCardBox {
    background: linear-gradient(to bottom, rgba(73,73,73,0.90), rgba(73,73,73,0.8) 50%);
    width: 100%;
	margin-bottom: 2%;
    padding-bottom: 4%;
    position: relative;
    padding-top: 4%;
}

.GuideCard {
	width: 90%;
    position: relative;
    background-color: rgba(52,52,52,0.90);
    padding-top: 0%;
    padding-right: 0%;
    padding-left: 0%;
    padding-bottom: 0%;
    margin-top: 0%;
    margin-bottom: 1%;
    height: 54px;
    margin-left: auto;
    margin-right: auto;
}
}
.GuideCard:hover {
    background-color: #9B8484;
}
.GuideCardTitle {
    line-height: 18px;
    font-size: 16px;
    text-align: left;
    color: #FFFFFF;
    float: left;
    margin-right: auto;
    margin-left: 5%;
}
.CopyrightMark {
    width: 88%;
    position: relative;
    line-height: 12px;
    font-size: 12px;
    text-align: center;
    color: #FFFFFF;
    margin-top: 5%;
    margin-right: auto;
    margin-left: auto;
    margin-bottom: 0%;
}
@media only screen and (min-width: 1025px) {
.TxtCol {
    margin-right: 0%;
    float: right;
    width: 708px;
}
}

@media only screen and (max-width: 1024px) {
.TxtCol {
    margin-right: 0%;
    width: 100%;
}
}
.TxtBox {
    width: 100%;
    position: relative;
    background: rgba(255,255,255,0.88);
}
.TxtBoxTitle {
    line-height: 30px;
    font-size: 24px;
    position: relative;
}
.TxtBoxSummary {
    width: 100%;
    font-size: 14px;
    position: relative;
    margin-top: 1%;
    color: #707070;
}
.TxtContent {
    width: 94%;
    position: relative;
    margin-top: 2%;
    margin-left: 3%;
    margin-right: 3%;
    margin-bottom: 2%;
}
.TxtCoMark {
    width: 100%;
    background-color: rgba(132,132,132,1);
    padding-top: 1%;
    padding-bottom: 0%;
    position: relative;
}
.TxtCoMarkTime {
    width: 70%;
    background-color: transparent;
    line-height: 19px;
    font-size: 16px;
    text-align: left;
    color: #FAFAFA;
    font-weight: 300;
    margin-top: 0%;
    margin-right: 0%;
    margin-left: 1%;
    margin-bottom: 0%;
    position: relative;
    float: left;
}
.TxtCoMarkId {
    width: 25%;
    background-color: transparent;
    line-height: 19px;
    font-size: 16px;
    text-align: right;
    color: #FAFAFA;
    font-weight: 300;
    margin-top: 0%;
    margin-right: 1%;
    margin-left: 0%;
    margin-bottom: 0%;
    position: relative;
    float: right;
}
.TxtBoxContent {
    font-weight: 300;
    margin-top: 1%;
    margin-right: 0%;
    margin-left: 0%;
    margin-bottom: 0%;
    font-size: 18px;
}
.TxtImg {
    width: 100%;
    display: block;
}.LabelTxt {
    color: #999999;
    font-family: 'LabelBoxFont';
    font-size: 12px;
    font-weight: 400;
}
.LabelBox {
    width: 100%;
    position: relative;
    padding-bottom: 1%;
    margin-top: 1%;
}
.LabelContent {
    width: 90%;
    margin: auto;
    position: relative;
}
.LBL_class, .LBL_time, .LBL_pv, .LBL_tag, .LBL_comment, .LBL_like {
    width: 20%;
    float: left;
    margin-top: 6px;
    margin-bottom: 2px;
    margin-left: 5%;
    transition-duration: 0.2s;
    transition-timing-function: ease;
    text-align: center;
}
.LBL_class:hover, .LBL_time:hover, .LBL_pv:hover, .LBL_tag:hover, .LBL_comment:hover, .LBL_like:hover {
    color: rgba(100,100,100,1.00);
    transition-duration: 0.2s;
    transition-timing-function: ease;
}
.LBL_class:before {
    padding-right: 4%;
    content: '\e3001';
}
.LBL_comment:before {
    padding-right: 4%;
    content: '\e3003';
}
.LBL_like:before {
    padding-right: 4%;
    content: '\e3002';
}
.LBL_time:before {
    padding-right: 4%;
    content: '\e3007';
}
.LBL_pv:before {
    padding-right: 4%;
    content: '\e3008';
}
.LBL_tag:before {
    padding-right: 4%;
    content: '\e3006';
}
.CommentBox {
    text-align: center;
    font-size: 22px;
    width: 100%;
    padding-top: 2%;
    padding-bottom: 2%;
    margin-bottom: 20%;
    position: relative;
}
 @import "GoUpBtn.css";
 @import "LoadBtn.css";
 @import "RandomBtn.css";
 @import "LabelBoxBtn.css";

@media only screen and (min-width: 1025px) {
.GoUpBtn {
    width: 100px;
    background-color: rgba(127,127,127,0.86);
    margin-right: auto;
    margin-left: auto;
    margin-bottom: 0%;
    padding-top: 10px;
    padding-right: 0%;
    padding-left: 0%;
    padding-bottom: 10px;
    position: fixed;
	right: 4%;
    bottom: 10%;
    z-index: 9999;
}
}

@media only screen and (max-width: 1024px) {
.GoUpBtn {
    width: 100px;
    background-color: rgba(127,127,127,0.86);
    margin-right: 0%;
    margin-left: 0%;
    margin-bottom: 0%;
    padding-top: 10px;
    padding-right: 0%;
    padding-left: 0%;
    padding-bottom: 10px;
    position: fixed;
    left: 2%;
    bottom: 10%;
    z-index: 9999;
}
}
.GoUpBtn:hover {
    background-color: #9B8484;
}
.GoUpBtn_pic {
    width: 26px;
    height: 26px;
    margin: auto;
}
.LoadPostBtn {
    width: 100%;
    background-color: rgba(127,127,127,0.86);
    padding-bottom: 1%;
    margin-top: 6%;
	margin-bottom: 20%;
    position: relative;
    padding-top: 1%;
}
.LoadPostBtn:hover {
    background-color: #9B8484;
}
.LoadPostBtn_pic {
    width: 26px;
    height: 26px;
    position: relative;
    margin: auto;
}
.RandomBtn {
    text-align: center;
    font-size: 26px;
    color: #FFFFFF;
    background-color: rgba(127,127,127,0.86);
    padding-top: 3%;
    padding-bottom: 3%;
    position: relative;
    float: left;
    width: 100%;
}
.RandomBtn:hover {
    color: #FFFFFF;
    background-color: #9B8484;
}
.Btn_like:before {
    padding-right: 4%;
    content: '\e3002';
}
.Btn_like {
    padding-top: 1px;
    padding-bottom: 1px;
    width: 20%;
    float: left;
    margin-top: 6px;
    margin-bottom: 2px;
    margin-left: 5%;
    transition-duration: 0.2s;
    transition-timing-function: ease;
    text-align: center;
    color: #FFFFFF;
    background: rgba(255,185,58,1.00);
}
.Btn_like:hover {
    color: #6E6E6E;
    background: rgba(255,185,58,0.40);
}
.Btn_comment:before {
    padding-right: 4%;
    content: '\e3003';
}
.Btn_comment {
    padding-top: 1px;
    padding-bottom: 1px;
    width: 20%;
    float: left;
    margin-top: 6px;
    margin-bottom: 2px;
    margin-left: 5%;
    transition-duration: 0.2s;
    transition-timing-function: ease;
    text-align: center;
    color: #FFFFFF;
    background: rgba(40, 200, 225,1.00);
}
.Btn_comment:hover {
    color: #6E6E6E;
    background: rgba(40, 200, 225,0.40);
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LibStructs;
using PILIPALA.pala_services;
using PILIPALA.pala_content.themes.fen.services;

namespace PILIPALA.pala_content.themes.fen
{
    public partial class index : System.Web.UI.Page
    {
        protected SLS SLS { get; set; }

        public List<PaText> List_text_index_page;/* 页面索引列 */
        public List<PaText> List_text_index_post;/* 文章索引列 */

        public int rqst_text_id;/* 请求的文章ID */
        public PaText PaText;/* 文章数据 */

        public void Page_Load(object sender, EventArgs e)
        {
            SLS = new SLS();

            if (Request.QueryString["guide"] == "1")/* 如果导航加载 */
            {
                List_text_index_page = SLS.getTextList("page");/* 导航列不加载 */
            }


            if (Request.QueryString["text_id"] == null)/* 如果没有文本ID参数 */
            {
                if (Request.QueryString["row"] != null)/* 如果推进加载行参数不为空 */
                {/* 以推进式加载数据赋值索引列 */
                    int row = Convert.ToInt32(Request.QueryString["row"]);
                    List_text_index_post = SLS.stepTextList(row, 6, "post");
                }
                else
                {/* 以全部数据赋值索引列 */
                    List_text_index_post = SLS.getTextList("post");
                }

            }
            else if (Request.QueryString["text_id"] != null)
            {/* 加载到文本详情 */
                rqst_text_id = Convert.ToInt32(Request.Params["text_id"]);
                PaText = SLS.fill(SLS.getTextMain(rqst_text_id), SLS.getTextSub(rqst_text_id));
            }
        }
    }
}using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PILIPALA
{
    public partial class index : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PILIPALA
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}