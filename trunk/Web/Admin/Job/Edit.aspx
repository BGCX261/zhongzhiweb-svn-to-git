<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Cms.Web.Admin.Job.Edit" %>



<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>编辑招聘</title>
    <link rel="stylesheet" type="text/css" href="../Images/AdmStyle.css" />
    <script type="text/javascript" src="../Js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../Js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../Js/messages_cn.js"></script>
    <script type="text/javascript" src="../Js/function.js"></script>
    <script src="../Js/calendar.js" type="text/javascript"></script>
   <script type="text/javascript">
       $(function () {
           //表单验证JS
           $("#form1").validate({
               //出错时添加的标签
               errorElement: "span",
               success: function (label) {
                   //正确时的样式
                   label.text(" ").addClass("success");
               }
           });
       });
   </script>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div style="height:20px;width:100%;">
       <span class="navigationBack"><a href="List.aspx">[返回列表]</a></span><img src="../Images/Icons/application_form_edit.png" /><span>招聘管理 &gt;&gt; 编辑招聘</span>
    </div>
    <div class="spAboveTable"></div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
            <tr>
                <th colspan="2" style="text-align: center;">
                    修改招聘信息
                </th>
            </tr>
            <tr>
                <td class="tdLeft" width="100" align="right">
                    岗位职称：
                </td>
                <td>
                    <asp:TextBox ID="position" runat="server" CssClass="input required" size="25" MaxLength="50"
                        minlength="3" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdLeft" align="right" valign="top">
                    岗位职责：
                </td>
                <td>
                    <asp:TextBox ID="responsibility" runat="server" CssClass="input required" size="25"
                        Style="text-align: left" MaxLength="50" Height="150px" TextMode="MultiLine" Width="99%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdLeft" align="right" valign="top">
                    招聘要求：
                </td>
                <td>
                    <asp:TextBox ID="requirement" runat="server" CssClass="input required" size="25"
                        Style="text-align: left" MaxLength="50" Height="150px" TextMode="MultiLine" Width="99%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdLeft" align="right">
                    招聘人数：
                </td>
                <td>
                    <asp:TextBox ID="headCount" runat="server" CssClass="input required number" size="30"
                        MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdLeft" align="right">
                    显示顺序：
                </td>
                <td>
                    <asp:TextBox ID="jobOrder" runat="server" CssClass="input number" size="30" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdLeft" align="right">
                    是否隐藏：
                </td>
                <td>
                    <asp:RadioButtonList ID="jobIsLock" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Selected="True" Value="0">正常</asp:ListItem>
                        <asp:ListItem Value="1">隐藏</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>

          <div style="margin-top:10px; text-align:center;">
            <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
                  Width="80px" onclick="btnSave_Click" />&nbsp;&nbsp; 
              <asp:Button ID="btnreset" runat="server" Text="重置" CssClass="submit" 
                  Width="80px" onclick="btnreset_Click"  />
          </div>
    </form>
</body>
</html>
