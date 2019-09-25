<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="InternetBanking._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

 <div class="jumbotron">
        <h1>Kelvin Lee Hsu(Nombre completo Cliente)</h1>
    </div>


      <!-- 
    <div class="row">
        <div class="col-4">
        <div class="card" style="width: 25rem;">
            <div class="card-header">
                    <p>Tipo de Cuenta</p>
            </div>
        </div>
        </div>
        <div class="col-4">
            <div class="card" style="width: 25rem;">
                <div class="card-header">
                    <p>ID</p>
                </div>
            </div>
        </div>
        <div class="col-4">
            <div class="card" style="width: 25rem;">
                <div class="card-header">
                    <p>Fecha de Apertura</p>
                </div>
            </div>
        </div>
    </div>
      -->



    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbCuentasConnectionString %>" SelectCommand="SELECT * FROM [tblCuentaInfo]"></asp:SqlDataSource>
    
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="1150px" Height="175px" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None">

    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
    <FooterStyle Width="10%" BackColor="#507CD1" />

    <HeaderStyle Width="10%" BackColor="#507CD1"/>
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" 
        Height="12px" VerticalAlign="Bottom" Width="12px" Wrap="False" />
    <RowStyle Width="10%" BackColor="#EFF3FB" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F5F7FB" />
    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
    <SortedDescendingCellStyle BackColor="#E9EBEF" />
    <SortedDescendingHeaderStyle BackColor="#4870BE" />

    </asp:GridView>


    <!-- <div class="card" style="width: 73.8rem;">
        <table class="card-table talbe">
          <thead>
            <tr>
                <th scope="col" style="width:25rem;">First</th>
                <th scope="col" style="width:25rem;">Second</th>
                <th scope="col" style="width:25rem;">Third</th>
            </tr>
          </thead>
            <tbody>
                <tr>
                    <td><asp:Label runat="server" ID="lblTipoCuenta"  CssClass="card-title"></asp:Label></td>
                    <td><asp:Label runat="server" ID="lblID"  CssClass="card-title"></asp:Label></td>
                    <td><asp:Label runat="server" ID="lblFechaApertura"  CssClass="card-title"></asp:Label></td>
                </tr>
            </tbody>
        </table>
    </div>
        -->

</asp:Content>
