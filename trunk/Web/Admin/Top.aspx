<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="Cms.Web.Admin.Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Top</title>
    <link rel="stylesheet" type="text/css" href="Images/AdmStyle.css" />
</head>
<body style="padding:0px;">
<form id="Form1" method="post" runat="server">
<table width="100%" height="102" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td background="Images/top-bj.gif">
			<table width="801" height="102" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td colspan="3">
					<img src="Images/Logo.jpg" width="800" height="71" alt="管理系统" /></td>
					</tr>
				<tr>
					<td width="240" style="background-image:url('Images/top-2.gif')">
						<table width="100%" height="31" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td height="3" colspan="2"></td>
							</tr>
							<tr>
								<td width="30"><div align="center"><img src="Images/bar_00.gif" width="16" height="16" alt="" /></div>
								</td>
								<td>
                                <span style="color: #000000;">
								『当前用户：<font color="#FF0000">
								<asp:Label id="lblSignIn" runat="server"></asp:Label></font>』</span></td>												
							</tr>
						</table>
					</td>
					<td width="546" background="Images/top-3.gif"  height="31" style="color: #000000;">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
						<tr>
							<td width="15">&nbsp;</td>
							<td height="31">
								<table border="0" cellpadding="0" cellspacing="0">
									<tr>
										<td rowspan="2"><img src="Images/top-4.gif" width="39" height="31" alt="" /></td>
										<td height="8"><font face="宋体"></font></td>
									</tr>
									<tr>
										<td><a href="Frame.aspx" target="_top">首页</a></td>
									</tr>
								</table>
							</td>
							<td height="31">
								<table border="0" cellpadding="0" cellspacing="0">
									<tr>
										<td rowspan="2"><img src="Images/top-4.gif" width="39" height="31" alt="" /></td>
										<td height="8"></td>
									</tr>
									<tr>
										<td><a href="javascript:history.go(-1)">后退</a></td>
									</tr>
								</table>
							</td>
							<td height="31">
								<table border="0" cellpadding="0" cellspacing="0">
									<tr>
										<td rowspan="2"><img src="images/top-4.gif" width="39" height="31" alt="" /></td>
										<td height="8"></td>
									</tr>
									<tr>
										<td><a href="javascript:history.go(1)">前进</a></td>
									</tr>
								</table>
							</td>
							<td>
								<table height="31" border="0" cellpadding="0" cellspacing="0">
									<tr>
										<td rowspan="2"><img src="Images/top-4.gif" width="39" height="31" /></td>
										<td height="8"></td>
									</tr>
									<tr>
										<td><a href="javascript:window.parent.mainFrame.location.reload();">刷新</a></td>
									</tr>
								</table>
							</td>
							<td>
								<table height="31" border="0" cellpadding="0" cellspacing="0">
									<tr>
										<td rowspan="2"><img src="Images/top-4.gif" width="39" height="31" alt="" /></td>
										<td height="8"></td>
									</tr>
									<tr>
										<td><a href="Relogin.aspx" target="_top" onClick="if (!window.confirm('您确认要注消当前登录用户吗？')){return false;}">注销</a></td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
					</td>
					<td width="75"><img src="Images/top-5.gif" width="75" height="31" alt="" /></td>
				</tr>
			</table>
		</td>
	</tr>
</table>
</form>
</body>
</html>
