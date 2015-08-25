<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bottom.aspx.cs" Inherits="Cms.Web.Admin.Bottom" %>

<%@ Register src="Controls/CopyRight.ascx" tagname="CopyRight2" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>版权信息</title>
    <link rel="stylesheet" type="text/css" href="Images/AdmStyle.css" />
</head>
<body style="padding:0px;">
    <form id="form1" runat="server" style="padding:0px;">
    <uc1:CopyRight2 ID="CopyRight" runat="server" style="padding:0px;" />
    </form>
</body>
</html>
