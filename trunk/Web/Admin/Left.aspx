<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="Cms.Web.Admin.Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>左侧菜单</title>
<style type="text/css">
body  { background:#799AE1; font:Verdana 12px; 
SCROLLBAR-FACE-COLOR: #799AE1; SCROLLBAR-HIGHLIGHT-COLOR: #799AE1; 
SCROLLBAR-SHADOW-COLOR: #799AE1; SCROLLBAR-DARKSHADOW-COLOR: #799AE1; 
SCROLLBAR-3DLIGHT-COLOR: #799AE1; SCROLLBAR-ARROW-COLOR: #FFFFFF;
SCROLLBAR-TRACK-COLOR: #AABFEC;
}
table  { border:0px; }
td  { font:normal 12px 宋体;}
img  { vertical-align:bottom; border:0px; }
a  { font:normal 12px 宋体; color:#000000; text-decoration:none; }
a:hover  { color:#428EFF;text-decoration:underline; }
.sec_menu  { border-left:1px solid white; border-right:1px solid white; border-bottom:1px solid white; overflow:hidden; background:#D6DFF7; }
.menu_title  { }
.menu_title span  { position:relative; top:0px; left:8px; color:#000000; font-weight:bold; }
.menu_title2  { }
.menu_title2 span  { position:relative; top:0px; left:8px; color:#999999; font-weight:bold; }
</style>

    <script type="text/javascript">
<!--
        var bV = parseInt(navigator.appVersion);
        var NS4 = (document.layers) ? true : false;
        var IE4 = ((document.all) && (bV >= 4)) ? true : false;
        var ver4 = (NS4 || IE4) ? true : false;

        function expandIt() { return }
        function expandAll() { return }
        function nomsg() { self.status = ""; }

        if (ver4) {
            document.write("<SCR" + "IPT LANGUAGE=\"JavaScript\" SRC=\"./Js/rsmenu.js\"></SCR" + "IPT>");
        }
//-->
    </script>
</head>
<body>
     <form id="form1" runat="server">

<div id="elOneParent" class="parent" style=" position:relative;top:0px;">
    <table cellpadding="0" cellspacing="0" width="158">
        <tr>
            <td height="25" onmouseover='this.className="menu_title2"' onmouseout='this.className="menu_title"'
                background="Images/title_bg_quit.gif" class="menu_title" onclick="expandIt('elOne'); return false">
                <span>基本设置</span>
            </td>
        </tr>
    </table>
 </div>
 
<div id="elOneChild" class="child">
    <table cellpadding="0" cellspacing="0" width="158" class="sec_menu">
        <tr>
            <td height="10">
            </td>
        </tr>
        <tr>
            <td height="20">
                &nbsp;<a href="Contents/HomePage.aspx" target="mainFrame">&nbsp;公司首页</a>
            </td>
        </tr>
        <tr>
            <td height="20">
                &nbsp;<a href="Contents/AboutCompany.aspx" target="mainFrame">&nbsp;公司简介</a>
            </td>
        </tr>
        <tr>
            <td height="20">
                &nbsp;<a href="Contents/ContactUS.aspx" target="mainFrame">&nbsp;联系我们</a>
            </td>
        </tr>
    </table>
</div>
<!--中间分隔-->
     <table>
         <tr>
             <td>
             </td>
         </tr>
     </table>

<%--产品展示--%>
<div id="el2Parent" class="parent">
 <table cellpadding="0" cellspacing="0" width="158">
  <tr>            
  <td height=25 onmouseover="this.className='menu_title2'" onmouseout="this.className='menu_title'"  background="Images/title_bg_quit.gif" class="menu_title" onclick="expandIt('el2'); return false"><span>产品展示</span></td>
  </tr>
    </table>
 </div>
 
<div id="el2Child" class="child" >

<table cellpadding="0" cellspacing="0" width="158" class="sec_menu">
            <tr>
              <td height="10"></td>
            </tr>
<tr>
<td height="20">&nbsp;<a href="Products/List.aspx" target="mainFrame">&nbsp;产品列表</a></td>
</tr>
<tr>
<td height="20">&nbsp;<a href="Products/Add.aspx" target="mainFrame">&nbsp;添加产品</a></td>
</tr>
<tr>
<td height="20">&nbsp;<a href="Products/Import.aspx" target="mainFrame">&nbsp;导入数据</a></td>
</tr>
</table>
</div>
<!--中间分隔-->
<table>
<tr>
<td></td>
</tr>
</table>

<%--新闻管理--%>
<div id="el3Parent" class="parent">
 <table cellpadding="0" cellspacing="0" width="158">
  <tr>            
  <td height="25" onmouseover="this.className='menu_title2'" onmouseout="this.className='menu_title'" background="Images/title_bg_quit.gif" class="menu_title" onclick="expandIt('el3'); return false"><span>新闻管理</span></td>
  </tr>
    </table>
 </div>
 
<div id="el3Child" class="child" >

<table cellpadding="0" cellspacing="0" width="158" class="sec_menu">
            <tr>
              <td height="10"></td>
            </tr>
<tr>
<td height="20">&nbsp;<a href="News/List.aspx" target="mainFrame">&nbsp;新闻管理</a></td>
</tr>
<tr>
<td height="20">&nbsp;<a href="News/Add.aspx" target="mainFrame">&nbsp;增加新闻</a></td>
</tr>
<tr>
<td height="20">&nbsp;<a href="Channel/List.aspx?kindId=0" target="mainFrame">&nbsp;类别管理</a></td>
</tr>
<tr>
<td height="20">&nbsp;<a href="Channel/Add.aspx?kindId=0" target="mainFrame">&nbsp;增加类别</a></td>
</tr>
</table>
</div>
<!--中间分隔-->
<table>
<tr>
<td></td>
</tr>
</table>

<%--解决方案--%>
<div id="Div1" class="parent">
 <table cellpadding="0" cellspacing="0" width="158">
  <tr>            
  <td height="25" onmouseover="this.className='menu_title2'" onmouseout="this.className='menu_title'" background="Images/title_bg_quit.gif" class="menu_title" onclick="expandIt('el4'); return false"><span>解决方案</span></td>
  </tr>
    </table>
 </div>
 
<div id="el4Child" class="child">

<table cellpadding="0" cellspacing="0" width="158" class="sec_menu">
            <tr>
              <td height="10"></td>
            </tr>
<tr>
<td height="20">&nbsp;<a href="Solution/Summary.aspx" target="mainFrame">&nbsp;方案概述</a></td>
</tr>
<tr>
<td height="20">&nbsp;<a href="Solution/List.aspx" target="mainFrame">&nbsp;案例管理</a></td>
</tr>
<tr>
<td height="20">&nbsp;<a href="Solution/Add.aspx" target="mainFrame">&nbsp;增加案例</a></td>
</tr>
</table>
</div>
<!--中间分隔-->
<table>
<tr>
<td></td>
</tr>
</table>

<%--招聘管理--%>
<div id="el7Parent" class="parent">
 <table cellpadding="0" cellspacing="0" width="158">
  <tr>            
  <td height="25" onmouseover="this.className='menu_title2'" onmouseout="this.className='menu_title'" background="Images/title_bg_quit.gif" class="menu_title" onclick="expandIt('el7'); return false"><span>招聘管理</span></td>
  </tr>
    </table>
 </div>
 
<div id="el7Child" class="child">

<table cellpadding="0" cellspacing="0" width="158" class="sec_menu">
            <tr>
              <td height="10"></td>
            </tr>
<tr>
<td height="20">&nbsp;<a href="Job/List.aspx" target="mainFrame">&nbsp;招聘管理</a></td>
</tr>
<tr>
<td height="20">&nbsp;<a href="Job/Add.aspx" target="mainFrame">&nbsp;增加招聘</a></td>
</tr>
</table>
</div>
<!--中间分隔-->
<table>
<tr>
<td></td>
</tr>
</table>

<%--用户管理--%>
<div id="el8Parent" class="parent">
 <table cellpadding="0" cellspacing="0" width="158">
  <tr>            
  <td height="25" onmouseover="this.className='menu_title2'" onmouseout="this.className='menu_title'" background="Images/title_bg_quit.gif" class="menu_title" onclick="expandIt('el8'); return false"><span>用户管理</span></td>
  </tr>
    </table>
 </div>
 
<div id="el8Child" class="child">

<table cellpadding="0" cellspacing="0" width="158" class="sec_menu">
            <tr>
              <td height="10"></td>
            </tr>
<tr>
<td height="20">&nbsp;<a href="Admin/List.aspx" target="mainFrame">&nbsp;用户列表</a></td>
</tr>
<tr>
<td height="20">&nbsp;<a href="Admin/Add.aspx" target="mainFrame">&nbsp;添加用户</a></td>
</tr>
</table>
</div>

</form>
</body>
</html>