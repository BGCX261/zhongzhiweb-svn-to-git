<%@ Page Title="" Language="C#" MasterPageFile="Manager.Master" AutoEventWireup="true" CodeBehind="SiteMap.aspx.cs" Inherits="Cms.Web.SiteMap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="background-color:White;">
<!-- main star -->
<div class="main">
    <div class="prplace">
        <a class="navLink" href="Default.aspx">主页</a> > <a class="navLink" href="About.aspx">
            公司概况</a> >站点地图
    </div>
<!--left.start-->
  <div class="pleft">
      <div>
          <dl class="kuang02" style="position: relative; left: 2px; background-color: #F8F8F8;
              border-radius: 3px;">
              <dt style="height: 30px; background-image:url('Images/Title3_BG.gif');">
                  <span class="productText01" style="position: relative; left: 10px; top: 8px;">公司概况</span>
              </dt>
              <dd>
                  <%=Cms.Web.UI.Channel.aboutList()%>
              </dd>
          </dl>
      </div>
  </div>
  <!--left.end-->
   <!--right.start-->
    <div class="pright">
        <div class="kuang02" style="position: relative;width:800px;height:400px;left:10px;border-radius:3px;">
            <div style="position: relative;width:200px;height:70px;left:20px;top:20px;">
                <span style="font-size:26px;font-weight:700; font-family:simHei;color:rgb(10,10,10)">站点地图</span>
            </div>
            <!-- zhu start -->
                    <div class="zhulx">
                        <p><span class="siteMapText01">站点导航</span><br />
                             <a class="siteLink" href="Default.aspx">首页</a>&nbsp;&nbsp;
                             <a class="siteLink" href="ProductList.aspx">产品天地</a>&nbsp;&nbsp;
                             <a class="siteLink" href="Solution.aspx">解决方案</a>&nbsp;&nbsp;
                             <a class="siteLink" href="News.aspx">活动分享</a>&nbsp;&nbsp;
                             <a class="siteLink" href="ContactInfo.aspx">联系我们</a></p>
                        <p><span class="siteMapText01">产品导航</span><br />
                             <%= outputProductSites()%>
                        <p><span class="siteMapText01">活动导航</span><br />
                            <%= outputNewsSites()%>
                        <p><span class="siteMapText01">众智概况</span><br />
                            <a class="siteLink" href="Contact.aspx">众智简介</a>&nbsp;&nbsp;
                            <a class="siteLink" href="RecuitmentNews.aspx">联系我们</a>&nbsp;&nbsp;
                            <a class="siteLink" href="SiteMap.aspx">站点地图</a>&nbsp;&nbsp;
                            <a class="siteLink" href="ContactInfo.aspx">联系我们</a></p>
                    </div>
            </div>
         <!-- zhu end -->
    </div>
    <!--right.end-->
</div>
<!--main.end-->
</div>
</asp:Content>
