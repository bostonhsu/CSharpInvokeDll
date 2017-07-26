<%@ Page Title="工位用料查询" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="InventorySearch.Main" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row">
        <div class="col-md-4">
            <h2>工位用料查询</h2>
            <ul>
              <li>查询条件：<asp:TextBox ID="txtSearchCondition" runat="server" Enabled="False" Width="164px"></asp:TextBox>
                </li>
              <li>日期<br />
                  <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
              </li>
              <li>车间<br />
                  <asp:ListBox ID="lstWorkshop" runat="server" Height="90px" Width="244px">
                      <asp:ListItem>1 - 制膏组</asp:ListItem>
                      <asp:ListItem>2 - 压蜡车间</asp:ListItem>
                      <asp:ListItem>3 - 修模车间</asp:ListItem>
                      <asp:ListItem>4 - 蜡检组</asp:ListItem>
                  </asp:ListBox>
              </li>
			  <li>班次<br />
                  <asp:ListBox ID="lstBanci" runat="server" Height="57px" Width="244px">
                      <asp:ListItem>1 - 白班</asp:ListItem>
                      <asp:ListItem>2 - 夜班</asp:ListItem>
                      <asp:ListItem>3 - 早班</asp:ListItem>
                  </asp:ListBox>
			  </li>
              <li>
                  <asp:Button ID="Button1" runat="server" Font-Size="Larger" Height="40px" Text="  查询  " Width="150px" />
                </li>              
            </ul>
        </div>
        <div class="col-md-4">
            <h2>总汇</h2>
            <p>
                
                <asp:ListBox ID="lstAll" runat="server" Height="450px" Width="300px">
                    <asp:ListItem>料1  3.50  斤</asp:ListItem>
                    <asp:ListItem>料2  19.5  个</asp:ListItem>
                    <asp:ListItem>料3  7.89 米</asp:ListItem>
                </asp:ListBox>
                
            </p>
            
        </div>
        <div class="col-md-4">
            <h2>工位明细</h2>
            <p>
                <asp:ListBox ID="lstAll0" runat="server" Height="450px" Width="300px">
                    <asp:ListItem>工位001：</asp:ListItem>
                    <asp:ListItem>料1 1.50 斤</asp:ListItem>
                    <asp:ListItem>料2 10.00 个</asp:ListItem>
                    <asp:ListItem>工位002：</asp:ListItem>
                    <asp:ListItem>料1 2.00 斤</asp:ListItem>
                    <asp:ListItem>料2 9.50 个</asp:ListItem>
                    <asp:ListItem>料3 7.00 米</asp:ListItem>
                    <asp:ListItem>工位003：</asp:ListItem>
                    <asp:ListItem>料3 0.89 米</asp:ListItem>
                    <asp:ListItem>工位004：</asp:ListItem>
                    <asp:ListItem>... ...</asp:ListItem>
                </asp:ListBox>
            </p>
            
        </div>
    </div>
</asp:Content>