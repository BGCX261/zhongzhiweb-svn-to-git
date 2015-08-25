<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AboutCompany.aspx.cs" Inherits="Cms.Web.Admin.Contents.AboutCompany" %>



<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公司简介</title>
    <link rel="stylesheet" type="text/css" href="../Images/AdmStyle.css" />
    <script type="text/javascript" src="../Js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../Js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../Js/messages_cn.js"></script>
    <script type="text/javascript" src="../Js/jquery.form.js"></script>
    <script type="text/javascript" src="../Js/function.js"></script>
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
    <div style="height:20px;">
       <img src="../Images/Icons/application_form_edit.png" /><span>基本设置 &gt;&gt; 公司简介</span>
    </div>
    <div class="spAboveTable"></div>
           <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
              <tr>
                <th colspan="2" style="text-align:center;">公司简介设置</th>
              </tr>
              <tr>
                   <td class="tdLeft" width="100" align="right" valign="top">
                       公司名称：
                   </td>
                    <td>
                        <asp:TextBox ID="companyName" runat="server" CssClass="input required" size="25" maxlength="50" minlength="3" Width="500px"></asp:TextBox>
                    </td>
               </tr>
               <tr>
                   <td class="tdLeft" width="100" align="right" valign="top">
                       公司简介：
                   </td>
                    <td>
                        <CKEditor:CKEditorControl ID="content" runat="server" BasePath="~/CKEditor/" Height="400px" ToolbarSet="Default" Width="98%" Value="" CssClass="ckEditor">
                        </CKEditor:CKEditorControl>
                    </td>
               </tr>
               <tr>
                   <td class="tdLeft" width="100" align="right" valign="top">
                       版权信息：
                   </td>
                    <td>
                        <asp:TextBox ID="copyright" runat="server" CssClass="input required" size="25" maxlength="50" minlength="3" Width="500px"></asp:TextBox>
                    </td>
               </tr>
            </table>

          <div style="margin-top:10px; text-align:center;">
            <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
                  Width="80px" onclick="btnSave_Click" />&nbsp;&nbsp; 
              <asp:Button ID="btnretset" runat="server" Text="重置" CssClass="submit" 
                  Width="80px" onclick="btnretset_Click" />
          </div>
    </form>
</body>
</html>
