<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Cms.Web.Admin.Solution.List" %>



<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>案例列表</title>
    <link rel="stylesheet" type="text/css" href="../Images/AdmStyle.css" />
    <script type="text/javascript" src="../Js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../Js/jquery.pagination.js"></script>
    <script type="text/javascript" src="../Js/function.js"></script>
    <script type="text/javascript">
        //隔行变色
        $(function () {
            $(".listtable tr:nth-child(odd)").addClass("tr_bg");
            $(".listtable tr").hover(
			    function () {
			        $(this).addClass("tr_hover_col");
			    },
			    function () {
			        $(this).removeClass("tr_hover_col");
			    }
		    );
        });
    </script>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div style="height:20px;width:100%;">
       <img src="../Images/Icons/application_form.png" /><span>解决方案 &gt;&gt; 案例管理</span><span class="navigationAdd"><a href="Add.aspx">添加案例</a></span>
    </div>
    <div class="spAboveTable"></div>
    <asp:Repeater ID="rptList" runat="server" onitemcommand="rptList_ItemCommand">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listtable">
      <tr>
        <th width="10%" height="22px" valign="middle">选择</th>
        <th width="70%" valign="middle">解决方案</th>
        <th width="10%" valign="middle">状态</th>
        <th width="10%" valign="middle">操作</th>
      </tr>
      </HeaderTemplate>
      <ItemTemplate>
      <tr>
        <td align="center">
        <asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" />
        <asp:Label ID="lb_id" runat="server" Text='<%#Eval("SolutionID")%>' Visible="false"></asp:Label>
        </td>
        <td align="center"><%#Eval("CaseTitle") %></td>
        <td align="center">
            <asp:ImageButton ID="ibtnLock" CommandName="ibtnLock" runat="server" ImageUrl='<%# Convert.ToInt32(Eval("IsLock")) == 0 ? "../Images/correct.gif" : "../Images/disable.gif"%>' ToolTip='<%# Convert.ToInt32(Eval("IsLock")) == 1 ? "取消隐藏" : "设置隐藏"%>' />
        </td>
        </td>
        <td align="center"><span><a href="Edit.aspx?SolutionID=<%#Eval("SolutionID") %>">修改</a></span></td>
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
