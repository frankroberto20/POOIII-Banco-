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

    
    <asp:GridView ID="grdCuentas" runat="server" CssClass="table table-hover" GridLines="None" OnRowDataBound="grdCuentas_RowDataBound" OnSelectedIndexChanged="grdCuentas_SelectedIndexChanged">
		<HeaderStyle CssClass="table-primary" />
		<SelectedRowStyle CssClass="table-active" />
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
			<HeaderStyle CssClass="table-primary"/>
		</asp:GridView>
	</div>
	</div>
</asp:Content>
