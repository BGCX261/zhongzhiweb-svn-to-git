<%@ Page Title="" Language="C#" MasterPageFile="Manager.Master" AutoEventWireup="true" CodeBehind="ContactInfo.aspx.cs" Inherits="Cms.Web.ContactInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="background-color:White;">
<!-- main star -->
<div class="main">
    <div class="prplace">
        <a class="navLink" href="Default.aspx">主页</a> > <a class="navLink" href="About.aspx">
            公司概况</a> >联系我们
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
                <span style="font-size:26px;font-weight:700; font-family:simHei;color:rgb(10,10,10)">联系我们</span>
            </div>
            <!-- zhu start -->
                    <div class="zhulx">
                        <div class=" address">
                            <div class="addresscontent"><div class="contactText01">地址：<span class="contactText02"><%= getCompanyAddress()%></span></div>
                                                     <div class="contactText01">网址：<span class="contactText02"><%= getCompanyWebSite()%></span></div>
                                                      <div class="contactText01"">电话：<span class="contactText02"><%= getTelephone()%></span></div>
                                                      <div class="contactText01"">传真：<span class="contactText02"><%= getFax()%></span></div>
                                                      <div class="contactText01"">邮编：<span class="contactText02"><%= getPostNumber()%></span></div>
                          </div>
                        </div>
                    </div>
            </div>
         <!-- zhu end -->
    </div>
    <!--right.end-->
</div>
<!--main.end-->
</div>
</asp:Content>
