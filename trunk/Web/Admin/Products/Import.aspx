<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Import.aspx.cs" Inherits="Cms.Web.Admin.Products.Import" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>导入数据</title>
    <link rel="stylesheet" type="text/css" href="../Images/AdmStyle.css" />
    <script type="text/javascript" src="../Js/calendar.js"></script>
    <script type="text/javascript" src="../Js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../Js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../Js/messages_cn.js"></script>
    <script type="text/javascript" src="../Js/function.js"></script>
    <script type="text/javascript" src="../Js/jquery.form.js"></script>
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
   </script>
</head>

<body style="padding:10px;">
    <form id="form1" runat="server">
    <div style="height:20px;">
       <img src="../Images/Icons/application_form_edit.png" /><span>基本设置 &gt;&gt; 公司首页</span>
    </div>
    <div class="spAboveTable"></div>
           <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
              <tr>
                <th colspan="2" style="text-align:center;">导入数据</th>
              </tr>
               <tr class="upordown">
                   <td class="tdLeft" width="100" rowspan="2" align="right" valign="top">
                       数据文件：
                   </td>
                   <td valign="bottom">
                        <asp:TextBox ID="importFilePath" runat="server" CssClass="input w380 left" Width="300px"></asp:TextBox>
                        <span style="position:relative; top:3px;vertical-align:bottom;"></span>
                        <a href="javascript:void(0);" class="files" style=" background-image:url('../Images/upfilebg2.gif')">
                            <input type="file" id="importFile" name="importFile"
                             onchange="SingleUpload('', 'importFilePath','importFile',20000)" /></a>
                        <span class="uploading">正在上传，请稍候...</span>
                    </td>
               </tr>
            </table>

          <div style="margin-top:10px; text-align:center;">
          <asp:Button ID="lbtnImport" runat="server" CssClass="submit"
                    OnClientClick="return confirm( '确定要导入这些记录吗？ ');" onclick="lbtnImport_Click" Text="导 入"></asp:Button>&nbsp;&nbsp; 
              <asp:Button ID="btnretset" runat="server" Text="重置" CssClass="submit" 
                  Width="80px" onclick="btnretset_Click" />
          </div>
    </form>
</body>
</html>
