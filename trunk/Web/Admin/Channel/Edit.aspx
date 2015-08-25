<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Cms.Web.Admin.Channel.Edit" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加栏目</title>
    <link rel="stylesheet" type="text/css" href="../Images/AdmStyle.css" />
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
       <span class="navigationBack"><a href="List.aspx">[返回列表]</a></span><img src="../Images/Icons/application_form_edit.png" /><span>新闻管理 &gt;&gt; 编辑栏目</span>
    </div>
    <div class="spAboveTable"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th colspan="2" style="text-align:center;">修改类别信息</th>
      </tr>
      <tr>
        <td class="tdLeft" width="100" align="right">栏目名称：</td>
        <td>
          <asp:TextBox ID="txtTitle" runat="server" CssClass="input required" size="30" 
            maxlength="50" ></asp:TextBox>
        </td>
       </tr>
       <tr>
         <td class="tdLeft" width="100" align="right">优先级别：</td>
         <td>
            <asp:TextBox ID="txtSortId" CssClass="input required number" size="10" runat="server" maxlength="9" ></asp:TextBox>
         </td>
       </tr>
     </table>
     <div style="margin-top:10px; text-align:center;">
            <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
                onclick="btnSave_Click" />
&nbsp;&nbsp; 
            <input type="reset" name="button" id="btnReset" value="重 置" class="submit" />
     </div>
     <div>
     
     </div>
    </form>
</body>
</html>
