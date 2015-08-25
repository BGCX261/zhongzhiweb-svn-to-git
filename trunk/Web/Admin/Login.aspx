<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Cms.Web.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统登录</title>
    <link rel="stylesheet" type="text/css" href="Images/AdmStyle.css" />
    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="js/function.js"></script>

     <style type="text/css">
        body,td,th {
	font-size: 12px;
	}
    body {
	    margin-left: 0px;
	    margin-top: 0px;
	    margin-right: 0px;
	    margin-bottom: 0px;
	    background-color:#FFFFFF;
	    padding:0px;
	    }
	#Form1 {
	    position:absolute;
	    top:0px;
	    left:0px;
	    width:100%;
	    height:100%;
	    z-index:0;
    }
    #LoginInput {
	    position:absolute;
	    top:45%;
	    left:45%;
	    width:250px;
	    height:100px;
	    background-image:url('images/login/login_input_bg.gif');
	    z-index:1;
    }
    #LoginSubmit {
	    position:absolute;
	    top:45%;
	    left:45%;
	    margin-left:249px;
	    margin-top:-3px;
	    width:90px;
	    height:95px;
	    background-image:url('images/login/login_submit_bg.gif');
	    z-index:1;
    }
    </style>

    <script language="javascript" type="text/javascript">
        function ChangeCode() {

            var date = new Date();
            var myImg = document.getElementById("ImageCheck");
            var GUID = document.getElementById("lblGUID");

            if (GUID != null) {
                if (GUID.innerHTML != "" && GUID.innerHTML != null) {
                    myImg.src = "ValidateCode.aspx?GUID=" + GUID.innerHTML + "&flag=" + date.getMilliseconds()
                }
            }
            return false;
        }     
    </script>

</head>
<body>
<form id="Form1" name="form1"  runat="server">
    <asp:Label ID="lblGUID" runat="server" Style="display: none"></asp:Label>
    <div id="LoginInput">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" style=" position:relative; top:5px;left:15px;">
        <tr>
            <td width="60" height="26">
                <div align="center" style="color:rgb(136,206,245);">
                    用户名:</div>
            </td>
            <td style="text-align: left">
                    &nbsp;<asp:TextBox ID="txtName" runat="server" Width="140px" CssClass="login_input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="26">
                <div align="center" style="color:rgb(136,206,245);">
                    密&nbsp;&nbsp;码:</div>
            </td>
            <td style="text-align: left">
                &nbsp;<asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Width="140px" CssClass="login_input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="26">
                <div align="center" style="color:rgb(136,206,245);">
                    验证码:</div>
            </td>
            <td style="text-align: left">
                &nbsp;<asp:TextBox ID="txtCode" runat="server" Width="80px" CssClass="login_input"></asp:TextBox>
                <a id="A2" href="" onclick="ChangeCode();return false;">
                    <asp:Image ID="ImageCheck" runat="server" ImageUrl="ValidateCode.aspx?GUID=GUID"
                        ImageAlign="AbsMiddle" ToolTip="看不清，换一个"></asp:Image>
                </a>
            </td>
        </tr>
    </table>
    </div>

    <div id="LoginSubmit">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" style="position:relative;top:16px;left:-1px;">
            <tr>
                <td align="center" height="28px">
                    <asp:ImageButton ID="logindl" runat="server" ImageUrl="images/login/dl.gif" onclick="logindl_Click" />
                </td>
            </tr>
            <tr>
                <td  align="center" height="28px">
                    <asp:ImageButton ID="logincancel" runat="server" ImageUrl="images/login/cz.gif" onclick="logincancel_Click" />
                </td>
            </tr>
        </table>
    </div>

    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="100%" height="45%" colspan="5">
                <img src="images/login/login_BG_up.gif" width="100%" alt="" height="100%"/>
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="5" valign="top" height="15%">
                <img src="images/login/login_BG_Mid.gif" width="100%" height="100%" alt=""/>
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="5" valign="top" height="30%">
                <img src="images/login/login_BG_Down_1.gif" width="100%" height="100%" alt=""/>
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="5" valign="top" style=" background-image:url('images/login/login_BG_Down_2.gif'); background-repeat:repeat;">
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="5" valign="top" height="5%">
                <img src="images/login/login_BG_Down_3.gif" width="100%" height="100%" alt=""/>
            </td>
        </tr>
    </table>
</form>

</body>
</html>