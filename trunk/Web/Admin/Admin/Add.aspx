<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Cms.Web.Admin.Manage.Add" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加管理员</title>
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
       <img src="../Images/Icons/application_form_add.png" /><span>用户管理 &gt;&gt; 增加用户</span><span class="navigationBack"><a href="List.aspx">[返回列表]</a>
    </div>
    <div class="spAboveTable"></div>
           <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
              <tr>
                <th colspan="2" style="text-align: center;">基本信息设置</th>
              </tr>
              <tr>
                <td class="tdLeft" width="100" align="right">登录帐号：</td>
                <td>
                <asp:TextBox ID="txtUserName" runat="server" CssClass="input required" size="25" 
            maxlength="50" minlength="3"></asp:TextBox>                    
                </td>
              </tr>
              <tr>
                <td class="tdLeft" align="right">登录密码：</td>
                <td>
                <asp:TextBox ID="txtUserPwd" runat="server" CssClass="input required" size="25" maxlength="50" TextMode="Password"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <td class="tdLeft" align="right">确认密码：</td>
                <td>
                <asp:TextBox ID="txtUserPwd1" runat="server" CssClass="input required" size="25" maxlength="50" equalTo="#txtUserPwd" TextMode="Password"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <td class="tdLeft" align="right">真实姓名：</td>
                <td>
                <asp:TextBox ID="txtRealName" runat="server" CssClass="input required" Width="160px"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <td class="tdLeft" align="right">联系电话：</td>
                <td>
                <asp:TextBox ID="txtTelephone" runat="server" CssClass="input" Width="160px"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <td class="tdLeft" align="right">联系地址：</td>
                <td>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="input" Width="160px"></asp:TextBox>
                </td>
              </tr>
            </table>

          <div style="margin-top:10px; text-align:center;">
            <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
                  onclick="btnSave_Click" />&nbsp;&nbsp; 
              <asp:Button ID="Button1" runat="server" Text="重置" CssClass="submit" 
                  Width="80px" onclick="Button1_Click" />
          </div>
    </form>
</body>
</html>
