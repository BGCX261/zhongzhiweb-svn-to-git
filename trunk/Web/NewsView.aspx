<%@ Page Title="" Language="C#" MasterPageFile="Manager.Master" AutoEventWireup="true" CodeBehind="NewsView.aspx.cs" Inherits="Cms.Web.NewsView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="background-color:White;">
<div class="main">
    <div class="prplace">
        <a class="navLink" href="Default.aspx">主页</a> &gt; <a class="navLink" href="News.aspx">活动分享</a> &gt;
        <%=Cms.Web.UI.Channel.ViewNewsListTitle(model.ClassId)%>
        &gt;
    </div>
  <!--left.start-->
  <div class="pleft" style=" padding-bottom:10px;">
    <div>
          <dl class="kuang02" style="position: relative; left: 2px; background-color: #F8F8F8;
              border-radius: 3px;">
              <dt style="height: 30px; background-image:url('Images/Title3_BG.gif');">
                  <span class="productText01" style="position: relative; left: 10px; top: 8px;">栏目导航</span>
              </dt>
              <dd>
                  <%=Cms.Web.UI.Channel.newsClassList()%>
              </dd>
          </dl>
      </div>
  </div>
  <!--left.end-->
  
  <!--right.start-->
  <div class="pright">
    <div class="pageInfo">
      <h1><%=model.Title %></h1>
      <div class="note">作者：<%=model.Author %> 浏览数：<%=model.Click %> 发布时间：<%=model.PubTime.ToString()%></div>
      <div > <%= Cms.Common.Utils.ToTxt(model.Content) %></div>
    </div>
  </div>
  <!--right.end-->
  
</div>
</div>
</asp:Content>
