<%@ Page Title="" Language="C#" MasterPageFile="Manager.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Cms.Web.News" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="background-color:White;">
<div class="main">
    <div class="prplace">
        <a class="navLink" href="Default.aspx">主页</a> > <a class="navLink" href="News.aspx">
            活动分享</a> >
        <%=Cms.Web.UI.Channel.ViewNewsListTitle(this.classId)%>
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
      <div style="position: relative; top: 10px; left: 2px;">
          <dl class="kuang02" style="background-color: #FFFFFF;
              border-radius: 3px;">
              <dt style="height: 30px; background-color: rgb(241,241,241);"><span class="channelText01"
                  style="position: relative; left: 10px; top: 8px;">最新活动</span> </dt>
              <dd>
                <%=Cms.Web.UI.News.latestNewsList()%>
              </dd>
          </dl>
      </div>
  </div>
  <!--left.end-->
  
  <!--right.start-->
  <div class="pright">
      <div style="position: relative; width: 800px; left: 10px;">
          <div style="width: 800px; height: 30px; position: relative; background-image:url('Images/Title5_BG.gif');">
              <span class="titleText01" style="position: relative;left: 10px; top: 8px;">活动列表</span></div>
          <dl class="p2">
              <dt><strong class="fc_f60">
                  <%=Cms.Web.UI.Channel.ViewNewsListTitle(this.classId)%></strong></dt>
              <dd>
                  <ul class="b3">
                      <asp:Repeater ID="rptList" runat="server">
                          <ItemTemplate>
                              <li><a href="NewsView.aspx?newsID=<%#Eval("NewsID").ToString()%>">
                                  <%#Eval("Title").ToString()%></a><small>(<%#Convert.ToDateTime(Eval("PubTime")).ToString("yyyy-MM-dd")%>)</small></li>
                          </ItemTemplate>
                      </asp:Repeater>
                  </ul>
              </dd>
          </dl>
          <div class="spClear">
              <asp:Label ID="lbmsg" runat="server" Visible="False"></asp:Label>
          </div>
          <div style="height:30px;">
              <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="formfield" CustomInfoClass="formbutton"
                  CustomInfoHTML="" FirstPageText="首页" HorizontalAlign="Right" InputBoxStyle="width:19px"
                  LastPageText="尾页" meta:resourceKey="AspNetPager1" NextPageText="下一页" PageSize="10"
                  PrevPageText="前一页" ShowCustomInfoSection="Never" ShowInputBox="Always" ShowNavigationToolTip="True"
                  Style="font-size: 12px; text-align: right; padding-right:10px;" SubmitButtonClass="formfield" SubmitButtonText="GO"
                  OnPageChanging="AspNetPager1_PageChanging" PageIndexBoxType="TextBox" ShowPageIndexBox="Never"
                  AlwaysShow="True">
              </webdiyer:AspNetPager>
          </div>
      </div>
    </div>
  <!--right.end-->
</div>
</div>
</asp:Content>
