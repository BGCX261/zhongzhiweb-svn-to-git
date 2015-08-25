<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Cms.Web.Admin.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>管理中心首页</title>
    <link rel="stylesheet" type="text/css" href="Images/AdmStyle.css" />
    <script type="text/javascript" src="../js/jquery-1.3.2.min.js"></script>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div style="height:20px;width:100%;">
       <img src="Images/Icons/application_form.png" /><span>服务器信息</span>
    </div>
    <div class="spAboveTable"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">    
      <tr>
        <th colspan="2" align="center">服务器信息</th>
      </tr>
      <tr>
        <td class="tdLeft" align="right" width="100">服务器名称：</td>
        <td>
          <%=Server.MachineName%>
        </td>
      </tr>
      <tr>
        <td class="tdLeft" align="right">服务器IP：</td>
        <td>
          <%=Request.ServerVariables["LOCAL_ADDR"] %>
        </td>
      </tr>
      <tr>
        <td class="tdLeft" align="right">NET框架版本：</td>
        <td>
          <%=Environment.Version.ToString()%>
        </td>
      </tr>
      <tr>
        <td class="tdLeft" align="right">服务器操作系统：</td>
        <td>
          <%=Environment.OSVersion.ToString()%>
        </td>
      </tr>
      <tr>
        <td class="tdLeft" align="right">IIS环境：</td>
        <td>
          <%=Request.ServerVariables["SERVER_SOFTWARE"]%>
        </td>
      </tr>
      <tr>
        <td class="tdLeft" align="right">服务器端口：</td>
        <td>
          <%=Request.ServerVariables["SERVER_PORT"]%>
        </td>
      </tr>
      <tr>
        <td class="tdLeft" align="right">虚拟目录绝对路径：</td>
        <td>
          <%=Request.ServerVariables["APPL_PHYSICAL_PATH"]%>
        </td>
      </tr>
      <tr>
        <td class="tdLeft" align="right">脚本超时时间：</td>
        <td>
           <%=Server.ScriptTimeout%> 秒</td>
      </tr>
      <tr>
        <td class="tdLeft" align="right">服务器CPU数量：</td>
        <td>
        <%=Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS")%>个
        </td>
      </tr>
      <tr>
        <td class="tdLeft" align="right">CPU类型</td>
        <td>
           <%=Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER")%></td>
      </tr>
      <tr>
        <td class="tdLeft" align="right">HTTPS支持：</td>
        <td>
          <%=Request.ServerVariables["HTTPS"]%>
        </td>
      </tr>
      <tr>
        <td class="tdLeft" align="right">seesion总数：</td>
        <td>
          <%=Session.Keys.Count.ToString()%>
        </td>
      </tr>
    </table>    
    </form>
</body>
</html>