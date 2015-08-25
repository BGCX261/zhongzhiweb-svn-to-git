<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Cms.Web.Admin.Contents.HomePage" %>



<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公司首页</title>
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
                <th colspan="2" style="text-align:center;">公司首页设置</th>
              </tr>
               <tr class="upordown">
                   <td class="tdLeft" width="100" rowspan="2" align="right" valign="top">
                       公司LOGO：
                   </td>
                   <td align="left">
                         <img id="companyLogo" src="<%=getLogoImage()%>" alt="<%=getLogoImage()%>" border="1"
                           width="750" height="45" />
                    </td>
               </tr>
               <tr>
                    <td valign="bottom">
                        <asp:TextBox ID="logoImgUrl" runat="server" CssClass="input w380 left" Width="700px"></asp:TextBox>
                        <span style="position:relative; top:3px;vertical-align:bottom;">(最大上传大小：100K)</span>
                        <a href="javascript:void(0);" class="files">
                            <input type="file" id="FileUploadLogo" name="FileUploadLogo" onchange="SingleUpload('companyLogo', 'logoImgUrl','FileUploadLogo',200)" /></a>
                        <span class="uploading">正在上传，请稍候...</span>
                    </td>
               </tr>
               <tr class="upordown">
                   <td class="tdLeft" rowspan="2" align="right" valign="top">
                       公司首页图片：
                   </td>
                   <td>
                       <img id="startPage" src="<%=getStartPage()%>" alt="<%=getStartPage()%>" border="1"
                           width="750" height="180" />
                   </td>
               </tr>
               <tr>
                   <td valign="bottom">
                       <asp:TextBox ID="startImgUrl" runat="server" CssClass="input w380 left" Width="700px"></asp:TextBox>
                       <span style="position:relative; top:3px;vertical-align:bottom;">(最大上传大小：500K)</span>
                       <a href="javascript:void(0);" class="files">
                           <input type="file" id="FileUploadStart" name="FileUploadStart" onchange="SingleUpload('startPage', 'startImgUrl','FileUploadStart',800)" /></a>
                       <span class="uploading">正在上传，请稍候...</span>
                   </td>
               </tr>
               <tr>
                   <td class="tdLeft" align="right" valign="top">
                       左侧边栏：
                   </td>
                    <td>
                        <asp:TextBox ID="leftSummary" runat="server" CssClass="input required" 
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
