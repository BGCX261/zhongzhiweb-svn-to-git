<%@ Page Title="" Language="C#" AutoEventWireup="true"
    CodeBehind="Frame.aspx.cs" Inherits="Cms.Web.Frame" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>系统管理</title>
</head>

<frameset rows="101,*,30"  framespacing="0" frameborder="no" border="0" name="topset">
  <frame src="Top.aspx" name="topFrame" scrolling="No" noresize="noresize" id="topFrame" title="topFrame" />
  <frameset rows="*" cols="176,*" framespacing="0" frameborder="no" border="0" name="middleset">
    <frame src="Left.aspx" name="leftFrame" scrolling="yes" noresize="noresize" id="leftFrame" title="leftFrame" />
    <frameset rows="*" cols="5,*" framespacing="0" frameborder="no" border="0">
		<frame src="Spliter.aspx" name="spliterFrame" scrolling="no" noresize="noresize" >
		<frame src="Main.aspx" name="mainFrame" />
	</frameset>
  </frameset>
  <frame src="Bottom.aspx" name="bottomFrame" scrolling="No" noresize="noresize" id="bottomFrame" title="bottomFrame"/>
</frameset>
<noframes>
<body bgcolor="#FFFFFF" text="#000000">
</body>
</noframes>
</html>

