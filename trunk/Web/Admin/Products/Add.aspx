<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Cms.Web.Admin.Products.Add" %>



<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加产品型号信息</title>
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
    <style type="text/css">
        #datePicker
        {
            display:none;
            position:absolute;
	        margin-top:-250px;
            border:solid 2px black;
            background-color:white;
         }
    </style>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div style="height:20px;">
       <img src="../Images/Icons/application_form_add.png" /><span>产品管理 &gt;&gt; 添加产品</span><span class="navigationBack"><a href="List.aspx">[返回列表]</a>
    </div>
    <div class="spAboveTable"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="4" style="text-align:center;">添加产品型号信息</th>
        </tr>
        <tr>
            <td class="tdLeft" width="100" align="right">产品型号：</td>
            <td colspan="2">
                <asp:TextBox ID="txtSpec" runat="server" CssClass="input " size="20" maxlength="50" ></asp:TextBox>
            </td>
        </tr>
        <tr class="upordown">
            <td class="tdLeft" align="right" valign="top">产品图片：</td>
            <td width="200">
                <asp:Image ID="ProductImg" runat="server" BorderColor="0xbbbbbb" BorderWidth="1" Width="200" Height="200"></asp:Image>
            </td>
            <td valign="bottom">
                <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input w380 left"></asp:TextBox>
                <span style="position:relative; top:3px;vertical-align:bottom;">(最大上传大小：300K)</span>
                <a href="javascript:void(0);" class="files">
                    <input type="file" id="FileUpload" name="FileUpload" onchange="SingleUpload('ProductImg', 'txtImgUrl','FileUpload',300,200,200)" /></a>
                <span class="uploading">正在上传，请稍候...</span>
            </td>
        </tr>
         <tr>
            <td class="tdLeft" width="100" align="right">商品类型：</td>
            <td colspan="2">
                <asp:DropDownList ID="ddlTypeId" runat="server" CssClass="select" 
                AutoPostBack="true" onselectedindexchanged="ddlTypeId_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tdLeft" width="100" align="right">商品品牌：</td>
            <td colspan="2">
                <asp:DropDownList ID="ddlBrandId" runat="server" CssClass="select" 
                AutoPostBack="true" onselectedindexchanged="ddlBrandId_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tdLeft" width="100" align="right">商品名称：</td>
            <td colspan="2">
                <asp:DropDownList ID="ddlNameId" runat="server" CssClass="select" 
                AutoPostBack="true"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tdLeft" align="right" valign="top">产品详细：</td>
            <td colspan="2">
                <CKEditor:CKEditorControl ID="ProductDetail" runat="server" BasePath="~/CKEditor/" Height="400px" ToolbarSet="Default" Width="98%" Value="" CssClass="ckEditor">
                </CKEditor:CKEditorControl>
            </td>
        </tr>
        <tr>
            <td class="tdLeft" align="right">发布时间：</td>
            <td colspan="2">
                <asp:TextBox ID="txtPubTime" runat="server" CssClass="input " size="20" onfocus="WdatePicker(({dateFmt:'yyyy-MM-dd HH:mm:ss'}))" maxlength="20" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft" align="right">产品属性：</td>
            <td colspan="2">
                <asp:CheckBoxList ID="cblItem" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">置顶</asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td class="tdLeft" align="right">浏览次数：</td>
            <td colspan="2">
            <asp:TextBox ID="txtClick" runat="server" CssClass="input required number" size="10" 
            maxlength="10">0</asp:TextBox>
            </td>
        </tr>
    </table>
    <div style="margin-top:10px;text-align:center;">
      <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" onclick="btnSave_Click" /> &nbsp; &nbsp; &nbsp; 
      <asp:Button ID="btnreset" runat="server" Text="重置" CssClass="submit" onclick="btnreset_Click" Width="80px" />
    </div>
    </form>
</body>
</html>