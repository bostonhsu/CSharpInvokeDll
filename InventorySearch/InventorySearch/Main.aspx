<%@ Page Title="工位用料查询" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="InventorySearch.Main" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
      <div class="row-fluid">
        <div class="span3">
          <div class="well sidebar-nav">
            <ul class="nav nav-list">
              <li class="nav-header">工位用料查询</li>
              <li class="active">日期</li>
              <li>###</li>
              <li>车间</li>
              <li>###</li>
			  		 <li>班次</li>
			      <li>###</li>
              <li class="nav-header">查询按钮</li>              
            </ul>
          </div><!--/.well -->
        </div><!--/span-->
        <div class="span9">
          
          <div class="row-fluid">
            <div class="span6">
              <h2>总汇</h2>
              <p>这里显示材料汇总List。 </p>
              
            </div><!--/span-->
            <div class="span6">
              <h2>工位明细</h2>
              <p>这里显示材料汇总List。 </p>
            </div><!--/span-->
          </div><!--/row-->

        </div><!--/.fluid-container-->
    </div>
</div>
</asp:Content>