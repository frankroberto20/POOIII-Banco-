<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="InternetBanking._Default" EnableEventValidation="false" %>

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

    
    <asp:GridView ID="grdCuentas" runat="server" CssClass="table table-hover" GridLines="None" OnRowDataBound="grdCuentas_RowDataBound" OnSelectedIndexChanged="grdCuentas_SelectedIndexChanged" CellPadding="4" ForeColor="#333333">
		<AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
		<SelectedRowStyle CssClass="table-active" BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>

	<div id="CuentaInfo" runat="server">
	<div id="CuentaCards" style="padding-top:60px; display:table; width:100%">
		<div style="display:table-row">
			<div style="display:table-cell; width:50%; padding-left:10px; padding-right:10px">
				<div class="card card border-primary mb-3" style="max-width: 30rem;">
					<div class="card-header">Balance</div>
					<div class="card-body">
						<asp:Label runat="server" ID="lblBalance"  CssClass="card-title"></asp:Label>
					</div>
				</div>
			</div>
			<div style="display:table-cell; width:50%; padding-left:10px; padding-right:10px">
				<div class="card card border-primary mb-3" style="max-width: 30rem;">
					<div class="card-header">Ultima Transaccion</div>
					<div class="card-body">
						<asp:Label runat="server" ID="lblUltimaTransaccion"  CssClass="card-title"></asp:Label>
					</div>
				</div>
			</div>
		</div>
	</div>
	<div id="Movimientos" style="padding-top:40px">
		<asp:GridView ID="grdMovimientos" runat="server" AutoGenerateColumns="true" CssClass="table" GridLines="None">
			<AlternatingRowStyle BackColor="White" />
			<EditRowStyle BackColor="#2461BF" />
			<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
			<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
			<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
			<RowStyle BackColor="#EFF3FB" />
			<SelectedRowStyle CssClass="table-active" BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
			<SortedAscendingCellStyle BackColor="#F5F7FB" />
			<SortedAscendingHeaderStyle BackColor="#6D95E1" />
			<SortedDescendingCellStyle BackColor="#E9EBEF" />
			<SortedDescendingHeaderStyle BackColor="#4870BE" />
		</asp:GridView>
	</div>
	</div>
</asp:Content>
