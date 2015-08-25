<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Cms.Web.Admin.Manage.List" %>



<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员管理</title>
    <link rel="stylesheet" type="text/css" href="../Images/AdmStyle.css" />
    <script type="text/javascript" src="../Js/function.js"></script>
    <script type="text/javascript" src="../Js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../Js/jquery.pagination.js"></script>
     <script type="text/javascript">
        //隔行变色
        $(function() {
            $(".listtable tr:nth-child(odd)").addClass("tr_bg");
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
       <img src="../Images/Icons/application_form.png" /><span>用户管理 &gt;&gt; 用户列表</span><span class="navigationAdd"><a href="Add.aspx">添加用户</a></span>
        </div>
        <div class="spAboveTable"></div>
        <div>
            <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listtable">
              <tr>
                <th style="width:10%;" height="22px">选择</th>
                <th width="10%" valign="middle">编号</th>
                <th width="15%" valign="middle">用户名</th>
                <th width="15%" valign="middle">真实姓名</th>
                <th width="20%" valign="middle">联系电话</th>
                <th width="20%" valign="middle">通信地址</th>
                <th style="width:10%;">操作</th>
              </tr>
            </HeaderTemplate>
            <ItemTemplate>
              <tr>
                <td align="center">
                    <asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" />
                    <asp:Label ID="lb_id" runat="server" Text='<%#Eval("userid")%>' Visible="False"></asp:Label>
                </td>
                <td align="center"><%#Eval("userid")%></td>
                <td align="center"><%#Eval("username")%></td>
                <td align="center"><%#Eval("realname2")%></td>
                <td align="center"><%#Eval("StaffTel")%></td>
                <td align="center"><%#Eval("StaffAddres")%></td>
                <td align="center"><%# getOperation(Convert.ToString(Eval("userid")))%></td>
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
            CustomInfoHTML="第&lt;font color='red'&gt;&lt;b&gt;%CurrentPageIndex%&lt;/b&gt;&lt;/font&gt;页 共%PageCount%&nbsp;页 %StartRecordIndex%-%EndRecordIndex%" 
            CustomInfoTextAlign="Center" FirstPageText="首页" horizontalalign="Center" 
            InputBoxStyle="width:19px" LastPageText="尾页" meta:resourceKey="AspNetPager1" 
            NextPageText="下一页" PageSize="9" 
            PrevPageText="前一页" showcustominfosection="Left" ShowInputBox="Always" 
            ShowNavigationToolTip="True" style="FONT-SIZE: 12px" 
            SubmitButtonClass="formfield" SubmitButtonText="GO" width="506px" 
            onpagechanging="AspNetPager1_PageChanging" PageIndexBoxType="TextBox" 
                    ShowPageIndexBox="Never" AlwaysShow="True">
        </webdiyer:aspnetpager>
             </div>
              <div class="left">
                <span class="btn_all" onclick="checkAll(this);">全选</span>
                <span class="btn_bg">
                  <asp:LinkButton ID="lbtnDel" runat="server" onclick="lbtnDel_Click" OnClientClick="return confirm( '确定要删除这些记录吗？ ');">批量删除</asp:LinkButton>
                  </span>
            </div>
	  </div>
    </div>
    </form>
</body>
</html>
