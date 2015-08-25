<%@ Page Title="" Language="C#" MasterPageFile="Manager.Master" AutoEventWireup="true" CodeBehind="Solution.aspx.cs" Inherits="Cms.Web.Solution" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="background-color:White;">
    <div class="main">
        <div class="text06" style="color: #606060; position: relative; top: 10px; padding-bottom:15px;text-indent:2em;">
            <%=getSolutionSummary()%></div>
        <div style="position:relative; left:10px; width: 980px; height: 30px; position: relative; background-image:url('Images/Title4_BG.gif');">
            <span  class="titleText01" style="position: relative;left: 10px; top: 8px;">解决案例</span></div>
           <%=Cms.Web.UI.Solutions.solutionList()%>
    </div>
</div>
</asp:Content>
