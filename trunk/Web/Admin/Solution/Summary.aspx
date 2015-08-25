<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="Cms.Web.Admin.Contents.Summary" %>



<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>方案概述</title>
    <link rel="stylesheet" type="text/css" href="../Images/AdmStyle.css" />
    <script type="text/javascript" src="../Js/calendar.js"></script>
    <script type="text/javascript" src="../Js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../Js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../Js/messages_cn.js"></script>
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
    <div style="height:20px;width:100%;">
       <img src="../Images/Icons/application_form_edit.png" /><span>解决方案 &gt;&gt; 方案概述</span><span class="navigationBack"><a href="List.aspx">查看列表</a></span>
    </div>
    <div class="spAboveTable"></div>
           <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
              <tr>
                <th colspan="2"  style="text-align: center;">解决方案概述设置</th>
              </tr>
               <tr>
                   <td class="tdLeft" align="right" valign="top" width="100">
                       详细内容：
                   </td>
                    <td>
                        <asp:TextBox ID="content" runat="server" CssClass="input required" 
                            size="25" style= "TEXT-ALIGN:left" maxlength="50" Height="147px" TextMode="MultiLine" 
                            Width="99%"></asp:TextBox>
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
