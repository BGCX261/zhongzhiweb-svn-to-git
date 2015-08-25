<%@ Page Title="" Language="C#" MasterPageFile="Manager.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Cms.Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color: White;">
        <!--content.Start-->
        <div class="main">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td width="230">
                        <table cellpadding="0" cellspacing="0" border="0" style="background-color:rgb(50,50,50);position:relative;top:-3px;">
                        <tr>
                            <td>
                                <table width="230" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="15">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text05" height="228" style=" padding-right:5px;" valign="top">
                                            <span style="position: relative; left: 5px;text-indent:2em;color:rgb(255,255,255);">
                                               <%=getCompanyDescription()%></p></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" height="25" valign="center">
                                            <a href="http://www.baidu.com" style="color:White">查看百度推广演示视频>></a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="40" style="background-image:url(Images/sitemapBG.gif);" cellpadding="0" cellspacing="0">
                            <table width="100%">
                                <tr>
                                    <td align="center" height="40" valign="middle">
                                        <a style="position:relative;color:#fff; font-size:16px; font-weight:bold; font-family:Microsoft YaHei;" href="SiteMap.aspx">站点地图</a>
                                    </td>
                                </tr>
                            </table>
                            </td>
                        </tr>
                        </table>
                    </td>
                    <td width="770">
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td width="770" height="220" bgcolor="#F0EFF5" valign="top">
                                    <div >
                                        <table width="620" cellpadding="2" cellspacing="2" style="position: relative; top: 20px; left: 30px;">
                                            <%=Cms.Web.UI.Products.hotProdcutList()%>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr height="90">
                                <td style="background-color:rgb(245,245,245);">
                                    <div style="position: relative; top: 5px; left: 30px;">
                                        <table>
                                            <tr>
                                                <td width="350">
                                                    <a href="http://www.baidu.com">>> 您的推广只出现在相关的网页上</a>
                                                </td>
                                                <td>
                                                    <a href="http://www.baidu.com">>> 您的推广只出现在相关的网页上</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <a href="http://www.baidu.com">>> 您只需为点击付费，有道搜索推广保证点击质量</a>
                                                </td>
                                                <td>
                                                    <a href="http://www.baidu.com">>> 您只需为点击付费，有道搜索推广保证点击质量</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <a href="http://www.baidu.com">>> 高质量投放渠道，"门户+搜索"面面俱到</a>
                                                </td>
                                                <td>
                                                    <a href="http://www.baidu.com">>> 高质量投放渠道，"门户+搜索"面面俱到</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <a href="http://www.baidu.com">>> 针对中国用户设计的系统，简单易用，功能强大</a>
                                                </td>
                                                <td>
                                                    <a href="http://www.baidu.com">>> 针对中国用户设计的系统，简单易用，功能强大</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <a href="http://www.baidu.com">>> 关键词价格低至1毛起</a>
                                                </td>
                                                <td>
                                                    <a href="http://www.baidu.com">>> 关键词价格低至1毛起</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <!--content.End-->
    </div>
</asp:Content>
