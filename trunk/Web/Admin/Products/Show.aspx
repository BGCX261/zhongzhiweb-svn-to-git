<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Cms.Web.Admin.Products.Show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新闻详细</title>
    <link rel="stylesheet" type="text/css" href="../Images/AdmStyle.css" />
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div style="height:20px;width:100%;">
       <img src="../Images/Icons/application_form.png" /><span>产品管理 &gt;&gt; 型号信息</span><span class="navigationBack"><a href="List.aspx">[返回列表]</a></span>
    </div>
    <div class="spAboveTable"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" style="text-align:center;">产品型号信息</th>
        </tr>
	<tr>
	<td class="tdLeft" height="25" width="100" align="right">
		型号Id
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblId" runat="server"></asp:Label>
	</td></tr>
    <tr>
    <td class="tdLeft" height="25" width="100" align="right">
		产品类型
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblType" runat="server"></asp:Label>
	</td></tr>
    <tr>
	<td class="tdLeft" height="25" width="100" align="right">
		产品品牌
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBrand" runat="server"></asp:Label>
	</td></tr>
    <tr>
	<td class="tdLeft" height="25" width="100" align="right">
		产品名称
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td class="tdLeft" height="25" width="100" align="right">
		产品型号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSpec" runat="server"></asp:Label>
	</td></tr>
    <tr>
	<td class="tdLeft" height="25" width="100" align="right">
		产品图片
	：</td>
	<td height="25" width="*" align="left">
		<img id="ProductImg" src="../Tools/Http_ImgLoad.ashx?w=200&h=200&gurl=<%=getImgUrl()%>" alt="<%=getImgUrl()%>" border="1"
             width="200" height="200" />
	</td></tr>
	<tr>
	<td class="tdLeft" height="25" width="100" align="right">
		产品介绍
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblContent" runat="server"></asp:Label>
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
