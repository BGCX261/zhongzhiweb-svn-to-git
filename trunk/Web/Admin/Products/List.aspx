﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Cms.Web.Admin.Products.List" %>



<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>产品列表</title>
    <link rel="stylesheet" type="text/css" href="../Images/AdmStyle.css" />
    <script type="text/javascript" src="../Js/function.js"></script>
    <script type="text/javascript" src="../Js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../Js/jquery.pagination.js"></script>
     <script type="text/javascript">
        $(function() {
            $(".listtable tr:nth-child(odd)").addClass("tr_bg"); //隔行变色
            $(".listtable tr").hover(
			    function() {
			        $(this).addClass("tr_hover_col");
			    },
			    function() {
			        $(this).removeClass("tr_hover_col");
			    }
		    );
        });
    </script>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div style="height:20px;width:100%;">
       <img src="../Images/Icons/application_form.png" /><span>产品管理 &gt;&gt; 产品列表</span><span class="navigationAdd"><a href="Add.aspx">添加产品</a></span>
    </div>
    <div class="spAboveTable"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="50" align="center">请选择：</td>
        <td align="left" width="150">
            商品类型
            <asp:DropDownList ID="ddlTypeId" runat="server" CssClass="select" 
                AutoPostBack="True" onselectedindexchanged="ddlTypeId_SelectedIndexChanged"></asp:DropDownList>
        </td>
        <td align="left" width="150">
            商品品牌
            <asp:DropDownList ID="ddlBrandId" runat="server" CssClass="select" 
                AutoPostBack="True" onselectedindexchanged="ddlBrandId_SelectedIndexChanged"></asp:DropDownList>
        </td>
        <td align="left">
            商品名称
            <asp:DropDownList ID="ddlNameId" runat="server" CssClass="select" 
                AutoPostBack="True" onselectedindexchanged="ddlNameId_SelectedIndexChanged"></asp:DropDownList>
        </td>
        <td width="120" align="right">关健字查询：</td>
        <td width="150"><asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword"></asp:TextBox></td>
        <td width="60" align="center"><asp:Button ID="btnSelect" runat="server" Text="查询" CssClass="submit" onclick="btnSelect_Click" /></td>
        </tr>
    </table>
    <div class="spAboveTable"></div>
    <asp:Repeater ID="rptList" runat="server" onitemcommand="rptList_ItemCommand">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listtable">
      <tr>
        <th width="5%" height="22px" valign="middle">选择</th>
        <th width="5%" valign="middle">编号</th>
        <th width="15%" valign="middle">品牌</th>
        <th width="15%" valign="middle">类型</th>
        <th width="15%" valign="middle">商品名称</th>
        <th width="15%" valign="middle">型号</th>
        <th width="15%" valign="middle">发布时间</th>
        <th width="5%" valign="middle">置顶</th>
        <th width="10%" valign="middle">操作</th>
      </tr>
      </HeaderTemplate>
      <ItemTemplate>
      <tr>
        <td align="center"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" /></td>
        <td align="center"><asp:Label ID="lb_id" runat="server" Text='<%#Eval("SpecificationsId")%>'></asp:Label></td>
        <td align="center"><%# new Cms.DAL.Channel().GetProductTypeTitle(Convert.ToInt32(Eval("TypeID")))%></td>
        <td align="center"><%# new Cms.DAL.Channel().GetProductBrandTitle(Convert.ToInt32(Eval("BrandID")))%></td>
        <td align="center"><%# new Cms.DAL.Channel().GetProductNameTitle(Convert.ToInt32(Eval("ComoditiesNameID")))%></td>
        <td align="center"><a href="Show.aspx?specID=<%#Eval("SpecificationsId") %>"><%#Eval("Specifications")%></a></td>
        <td align="center"><%#string.Format("{0:g}", Eval("PubTime"))%></td>
        <td align="center">
            <asp:ImageButton ID="ibtnTop" CommandName="ibtnTop" runat="server" ImageUrl='<%# Convert.ToInt32(Eval("IsTop")) == 1 ? "../Images/ico-1.png" : "../Images/ico-1_.png"%>' ToolTip='<%# Convert.ToInt32(Eval("IsTop")) == 1 ? "取消置顶" : "设置置顶"%>' />
        </td>
        <td align="center"><span><a href="Edit.aspx?specID=<%#Eval("SpecificationsId") %>">修改</a></span> | <span><a href="Show.aspx?specID=<%#Eval("SpecificationsId") %>">详细</a></span></td>
      </tr>
      </ItemTemplate>
      <FooterTemplate>
      </table>
      </FooterTemplate>
      </asp:Repeater>

      <div class="spClear"></div>
        <div style="line-height:30px;height:30px;">
           <div class="right flickr"> 
               <webdiyer:aspnetpager ID="AspNetPager1" runat="server" CssClass="formfield" 
            CustomInfoClass="formbutton" 
            CustomInfoHTML="分页：总数 %RecordCount%条 每页%PageSize%条 页次 &lt;font color='red'&gt;&lt;b&gt;%CurrentPageIndex%&lt;/b&gt;&lt;/font&gt;/%PageCount%&nbsp;" 
            CustomInfoTextAlign="Center" FirstPageText="首页" horizontalalign="Center" 
            InputBoxStyle="width:19px" LastPageText="尾页" meta:resourceKey="AspNetPager1" 
            NextPageText="下一页" PageSize="20"
            PrevPageText="前一页" showcustominfosection="Left" ShowInputBox="Always" 
            ShowNavigationToolTip="True" style="FONT-SIZE: 12px" 
            SubmitButtonStyle="height:20px;position:relative;left:3px;top:1px;" SubmitButtonClass="submit" SubmitButtonText="跳转" width="550px" 
            onpagechanging="AspNetPager1_PageChanging" PageIndexBoxType="TextBox"
            ShowPageIndexBox="Always" AlwaysShow="True">
        </webdiyer:aspnetpager>
             </div>
             <div class="left">
                <span class="btn_all" onclick="checkAll(this);">全选</span>
                <span class="btn_bg">
                  <asp:LinkButton ID="lbtnDel" runat="server" 
                    OnClientClick="return confirm( '确定要删除这些记录吗？ ');" onclick="lbtnDel_Click">删 除</asp:LinkButton>
                </span>
            </div>
	</div>
    </form>
</body>
</html>