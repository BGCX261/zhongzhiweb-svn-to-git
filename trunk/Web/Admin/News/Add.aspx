<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs"  ValidateRequest="false" Inherits="Cms.Web.Admin.News.Add" %>



<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发布新闻</title>
    <link rel="stylesheet" type="text/css" href="../Images/AdmStyle.css" />
    <script type="text/javascript" src="../Js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../Js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../Js/messages_cn.js"></script>
    <script type="text/javascript" src="../Js/jquery.form.js"></script>
    <script type="text/javascript" src="../Js/function.js"></script>
        <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
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
       $(function () {
           $("#cbIsImage").bind("click", function () {
               if ($(this).attr("checked") == true) {
                   $(".upordown").show();
               } else {
                   $(".upordown").hide();
               }
           });
       });
   </script>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div style="height:20px;width:100%;">
       <img src="../Images/Icons/application_form_add.png" /><span>新闻管理 &gt;&gt; 发布新闻</span><span class="navigationBack"><a href="List.aspx">[返回列表]</a>
    </div>
    <div class="spAboveTable"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" style="text-align:center;">发布新闻</th>
        </tr>
        <tr>
            <td class="tdLeft" width="100" align="right">新闻标题：</td>
            <td >
            <asp:TextBox ID="txtTitle" runat="server" CssClass="input w380 required" 
            maxlength="250" minlength="3" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft" align="right">发布人：</td>
            <td>
            <asp:TextBox ID="txtAuthor" runat="server" CssClass="input w250 required" 
            maxlength="50" ></asp:TextBox>
            </td>
        </tr>      
        <tr>
            <td class="tdLeft" align="right">所属栏目：</td>
            <td><asp:DropDownList id="ddlClassId" CssClass=" required" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td class="tdLeft" align="right" valign="top">新闻内容：</td>
            <td>
                <CKEditor:CKEditorControl ID="NewsContent" runat="server" BasePath="~/CKEditor/" Height="400px" ToolbarSet="ROY" Width="99%" Value="">
                </CKEditor:CKEditorControl>
            </td>
        </tr>
        <tr>
            <td class="tdLeft" align="right">发布时间：</td>
            <td>
                <asp:TextBox ID="txtPubTime" runat="server" CssClass="input " size="20" onfocus="WdatePicker(({dateFmt:'yyyy-MM-dd HH:mm:ss'}))" maxlength="20" ></asp:TextBox>
            </td>
        </tr>
       <tr>
            <td class="tdLeft" align="right">新闻属性：</td>
            <td>
                <asp:CheckBoxList ID="cblItem" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="0">置顶</asp:ListItem>
                    <asp:ListItem Value="0">隐藏</asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td class="tdLeft" align="right">浏览次数：</td>
            <td>
                <asp:TextBox ID="txtClick" runat="server" CssClass="input required number" size="10" maxlength="10" >0</asp:TextBox>
            </td>
        </tr>
    </table>
    <div style="margin-top:10px;text-align:center;">
  <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="submit" 
            Width="50px" onclick="btnSave_Click" />
  &nbsp;&nbsp;&nbsp;&nbsp;
   <asp:Button ID="btnReset" runat="server" Text="重置" CssClass="submit" 
            Width="50px" onclick="btnReset_Click" />
   </div>
</form>
</body>
</html>