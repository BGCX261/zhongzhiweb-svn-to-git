<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Cms.Web.Admin.News.Show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新闻详细</title>
    <link rel="stylesheet" type="text/css" href="../Images/AdmStyle.css" />
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div style="height:20px;width:100%;">
       <img src="../Images/Icons/application_form.png" /><span>新闻管理 &gt;&gt; 新闻内容</span><span class="navigationBack"><a href="List.aspx">[返回列表]</a></span>
    </div>
    <div class="spAboveTable"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" style="text-align:center;">新闻详细</th>
        </tr>
	<tr>
	<td class="tdLeft" height="25" width="100" align="right">
		Id
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td class="tdLeft" height="25" width="100" align="right">
		新闻标题
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTitle" runat="server"></asp:Label>
	</td></tr>
    <tr>
	<td class="tdLeft" height="25" width="100" align="right">
		所属栏目
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblClassId" runat="server"></asp:Label>
	</td></tr>		
	<tr>
	<td class="tdLeft" height="25" width="100" align="right">
		新闻内容
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblContent" runat="server"></asp:Label>
	</td></tr>
    <tr>
	<td class="tdLeft" height="25" width="100" align="right">
		发布人
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAuthor" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td class="tdLeft" height="25" width="100" align="right">
		点击次数
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblClick" runat="server"></asp:Label>
	</td></tr>
    <tr>
	<td class="tdLeft" height="25" width="100" align="right">
		是否隐藏
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblIsLock" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td class="tdLeft" height="25" width="100" align="right">
		是否置顶
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblIsTop" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td class="tdLeft" height="25" width="100" align="right">
		发布时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPubTime" runat="server"></asp:Label>
	</td></tr>
</table>
 <div style="margin-top:10px;text-align:center;">
     <asp:LinkButton ID="lbtnback" runat="server" CssClass="submit" 
         PostBackUrl="List.aspx" Width="120px">返回列表</asp:LinkButton>
   </div>
</form>
</body>
</html>
