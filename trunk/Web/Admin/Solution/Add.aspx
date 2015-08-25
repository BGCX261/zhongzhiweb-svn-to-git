<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Cms.Web.Admin.Solution.Add" %>



<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加解决方案</title>
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
    </script>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div style="height:20px;width:100%;">
       <img src="../Images/Icons/application_form_add.png" /><span>解决方案 &gt;&gt; 增加案例</span><span class="navigationBack"><a href="List.aspx">[返回列表]</a>
    </div>
    <div class="spAboveTable"></div>
           <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
              <tr>
                <th colspan="3" style="text-align: center;">增加解决方案</th>
              </tr>
              <tr>
                <td class="tdLeft" width="100" align="right">案例名称：</td>
                <td colspan="2">
                <asp:TextBox ID="caseTitle" runat="server" CssClass="input required" size="30" maxlength="50" minlength="3" Width="300px"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <td class="tdLeft" align="right" valign="top">案例描述：</td>
                    <td colspan="2">
                        <asp:TextBox ID="description" runat="server" CssClass="input required" 
                            size="25" style= "TEXT-ALIGN:left" Height="150px" TextMode="MultiLine" 
                            Width="99%"></asp:TextBox>
                    </td>
              </tr>
              <tr>
                <td class="tdLeft" align="right" valign="top">解决方案：</td>
                    <td colspan="2">
                        <asp:TextBox ID="solution" runat="server" CssClass="input required" 
                            size="25" style= "TEXT-ALIGN:left" Height="150px" TextMode="MultiLine" 
                            Width="99%"></asp:TextBox>
                    </td>
              </tr>
               <tr class="upordown">
                   <td  class="tdLeft" align="right" valign="top">
                       案例图片：
                   </td>
                   <td width="100">
                       <img id="solutionImg" alt="" border="1" width="100" height="100" />
                   </td>
                   <td valign="bottom">
                       <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input w380 left"></asp:TextBox>
                       <span style="position:relative; top:3px;vertical-align:bottom;">(最大上传大小：100K)</span>
                       <a href="javascript:void(0);" class="files">
                           <input type="file" id="FileUpload" name="FileUpload" onchange="SingleUpload('solutionImg', 'txtImgUrl','FileUpload',100,100,100)" /></a>
                       <span class="uploading">正在上传，请稍候...</span>
                   </td>
               </tr>
            <tr>
                <td class="tdLeft" align="right" valign="top">成功案例：</td>
                    <td colspan="2">
                        <asp:TextBox ID="SucCases" runat="server" CssClass="input required" 
                            size="25" style= "TEXT-ALIGN:left" maxlength="50" Height="147px" TextMode="MultiLine" 
                            Width="99%"></asp:TextBox>
                    </td>
              </tr>
              <tr>
                <td class="tdLeft" align="right">显示顺序：</td>
                <td colspan="2">
                <asp:TextBox ID="sortOrder" runat="server" CssClass="input number" size="25" maxlength="50"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <td class="tdLeft" align="right">是否隐藏：</td>
                <td colspan="2">
                <asp:RadioButtonList ID="isLock" runat="server" RepeatDirection="Horizontal" 
                        RepeatLayout="Flow">
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
