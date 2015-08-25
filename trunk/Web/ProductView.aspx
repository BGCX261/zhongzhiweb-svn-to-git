<%@ Page Title="" Language="C#" MasterPageFile="Manager.Master" AutoEventWireup="true" CodeBehind="ProductView.aspx.cs" Inherits="Cms.Web.ProductView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color: White;">
        <div class="main">
            <div class="prplace">
                <a class="navLink" href="Default.aspx">主页</a> > <a class="navLink" href="ProductList.aspx">产品天地</a> >
                <%=Cms.Web.UI.Channel.ViewProductListTitle(this.model.TypeId, this.model.BrandId, this.model.NameId)%>
                &gt;
            </div>
            <!--left.start-->
            <div class="pleft" style=" padding-bottom:10px;">
                <dl class="kuang01" style="position: relative; left: 2px; background-color: #F8F8F8;
                    border-radius: 3px;">
                    <dt style="height: 27px;background-image:url('Images/Title1_BG.gif');background-repeat:no-repeat;">
                        <span class="productText01" style="position: relative; left: 10px; top: 6px;">产品类别</span>
                    </dt>
                    <dd>
                        <%=Cms.Web.UI.Channel.productClassList()%>
                    </dd>
                </dl>
            </div>
            <!--left.end-->
  
            <!--right.start-->
            <div class="pright">
                <div id="productInfo" style="width:810px;position:relative;left:10px;">
                    <div style="float: left;width:10px;">
                        <img src="Images/vdivider.gif" width="10px" height="350"/>
                    </div>
                    <div style="float: right; width:800px;">
                        <div class="productInfoDIV">
                            <div class="pictureDIV">
                                <div style="height: 310px; text-align: center;">
                                    <span class="jqzoom">
                                        <img src="Tools/Http_ImgLoad.ashx?w=300&h=300&gurl=<%=model.ImgUrl%>" alt="" width="300" height="300"/></span>
                                </div>
                            </div>
                            <div class="infoDIV">
                                <div class="infoTitle">
                                    <%=GetProductTitle()%></div>
                                <div class="productItem">
                                    <ul>
                                        <li>所属类别：<%=GetTypeTitle(model.TypeId) %></li>
                                        <li>产品品牌：<%=GetBrandTitle(model.BrandId)%></li>
                                        <li>产品名称：<%=GetNameTitle(model.NameId)%></li>
                                        <li>产品型号：<%=model.Specifications %></li>
                                        <li>浏览次数：<%=model.Click.ToString()%></li>
                                        <li>发布时间：<%=model.PubTime.ToString("yyyy/MM/dd") %></li>
                                        <li></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="productIntroduction">
                        <img src="Images/hdivider1.gif" width="800px" height="10px" />
                        <div style="margin-left: 6px; color: Black; font-size:18px; font-weight:bold; position:relative; top:5px;">
                            产品介绍</div>
                        <div id="productDetails" style=" position:relative; left:10px; top:10px; padding-bottom:10px;">
                            <%=Cms.Common.Utils.ToTxt(model.Description) %>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
