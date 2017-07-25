<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InventorySearch._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1><asp:Localize Text="<%$ Resources: Resources, applicationName %>" runat="server"></asp:Localize></h1>
        <p class="lead"><asp:Localize Text="<%$ Resources: Resources, applicationName %>" runat="server"></asp:Localize>是为了满足荣亨集团工位排产，而开发出的仓库配套管理系统。</p>
        <p><a href="main.aspx" class="btn btn-primary btn-lg">进入系统 &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2><asp:Localize meta:resourcekey="startString" runat="server">Getting started</asp:Localize></h2>
            <p>
                如果您对如何使用该系统存在疑问，请单击下面的<asp:Localize meta:resourcekey="LearnButtonString" runat="server">Learn more</asp:Localize>按钮进行学习。
            </p>
            <p>
                <a class="btn btn-default" href="learn.aspx"><asp:Localize meta:resourcekey="LearnButtonString" runat="server">Learn more</asp:Localize> &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
