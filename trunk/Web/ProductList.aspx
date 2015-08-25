<%@ Page Title="" Language="C#" MasterPageFile="Manager.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Cms.Web.ProductList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="background-color:White;">
<div class="main">
  <div class="prplace">
            <a class="navLink" href="Default.aspx">主页</a> > <a class="navLink" href="ProductList.aspx">产品天地</a> >
            <%=Cms.Web.UI.Channel.ViewProductListTitle(this.typeID, this.brandID, this.nameID)%>
  </div>
  <!--left.start-->
  <div class="pleft" style=" padding-bottom:10px;">
      <dl class="kuang01" style="position: relative;left: 2px; background-color: #F8F8F8;border-radius: 3px;">
          <dt style="height: 27px; background-image:url('Images/Title1_BG.gif');background-repeat:no-repeat;">
              <span class="productText01" style="position: relative; left: 10px; top: 6px;">产品类别</span>
          </dt>
          <dd>
              <%=Cms.Web.UI.Channel.productClassList()%>
          </dd>
      </dl>
      <dl class="kuang01" style="position: relative; top: 10px; left: 2px; background-color: #F8F8F8;border-radius: 3px;">
          <dt style="height: 27px; background-image:url('Images/Title1_BG.gif');background-repeat:no-repeat;">
              <span class="productText01" style="position: relative; top: 6px;">推荐产品</span>
              <dd>
                  <%=Cms.Web.UI.Products.adviseProductList()%>
              </dd>
          </dt>
      </dl>
  </div>
  <!--left.end-->
  
    <!--right.start-->
    <div class="pright">
        <div  class="kuang01" style="position: relative;width:800px;left:10px;border-radius:3px;">
            <div style="width: 800px; height: 40px; position: relative; background-color:rgb(241,241,241);border-bottom: 1px solid #999999;">
                <span style="color:rgb(52,54,64); font-size: 18px; font-weight: bold; position:relative;left:10px;top:15px;">
                    产品列表</span></div>
            <div class="plist"style="position:relative;top:25px;left:30px;">
                <ul>
                    <!--Product.Start-->
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <li><a href="ProductView.aspx?specId=<%#Eval("SpecificationsID")%>">
                                <img src="Tools/Http_ImgLoad.ashx?w=114&h=114&gurl=<%#Eval("SmallImgUrl")%>" alt="<%#Eval("Specifications")%>"
                                    border="1" width="114" height="114"/></a> <span><a href="ProductView.aspx?specId=<%#Eval("SpecificationsID")%>">
                                        <%#Eval("Specifications")%></a></span> </li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <!--Product.End-->
                </ul>
            </div>
            <div class="spClear">
                <asp:Label ID="lbmsg" runat="server"></asp:Label>
            </div>
            <div style="height:30px;">
              <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="formfield" CustomInfoClass="formbutton"
                  CustomInfoHTML="" FirstPageText="首页" HorizontalAlign="Right" InputBoxStyle="width:19px"
                  LastPageText="尾页" meta:resourceKey="AspNetPager1" NextPageText="下一页" PageSize="15"
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
