<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Cms.Web.Admin.Channel.List" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>类别管理</title>
    <link rel="stylesheet" type="text/css" href="../Images/AdmStyle.css" />
    <script type="text/javascript" src="../Js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".listtable tr:nth-child(odd)").addClass("tr_bg"); //隔行变色
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
       <img src="../Images/Icons/application_form.png" /><span>新闻管理 &gt;&gt; 栏目列表</span><span class="navigationAdd"><a href="Add.aspx">添加栏目</a></span>
    </div>
    <div class="spAboveTable"></div>
        <asp:Repeater ID="rptClassList" runat="server" 
            onitemcommand="rptClassList_ItemCommand" 
            onitemdatabound="rptClassList_ItemDataBound">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listtable">
                    <tr>
                        <th width="10%" height="22px" valign="middle">编号</th>
                        <th align="60%" valign="middle">栏目名称</th>
                        <th width="10%" valign="middle">优先级别</th>
                        <th width="20%" valign="middle">管理操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td align="center">
                          <asp:HiddenField ID="txtClassId" runat="server" Value='<%#Eval("ClassId") %>' />
                          <%# Eval("ClassId")%>
                        </td>
                        <td align="left">
                          <asp:Literal ID="LitFirst" runat="server"></asp:Literal>
                          <%# Eval("Title")  %>
                        </td>
                        <td align="center">
                            <asp:ImageButton ID="ibtnUp" CommandName="ibtnUp" runat="server" ImageUrl='../Images/ico-up.png' ToolTip='上移'/>
                            <asp:ImageButton ID="ibtnDown" CommandName="ibtnDown" runat="server" ImageUrl='../Images/ico-down.png' ToolTip='下移' />
                        </td>
                        <td align="center">
                            <span><a href="Edit.aspx?classId=<%# Eval("ClassID") %>">修改</a></span>
                            <span><asp:LinkButton ID="lbDel" CommandName="btndel" runat="server" OnClientClick="return confirm( '该操作会删除本栏目，确定要删除吗？ ');">删除</asp:LinkButton></span>
                        </td>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
     </form>
</body>
</html>
