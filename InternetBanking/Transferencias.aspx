<%@ Page Title="Transferencias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transferencias.aspx.cs" Inherits="InternetBanking.Transferencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<header>
		<webopt:bundlereference runat="server" path="~/Content/css" />
		<link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
		<link rel="stylesheet" type="text/css" href="Content/bootstrap-default.css"/>
	</header>
	<header style="padding-top:40px">
		<h1>Tranferencia</h1>
	</header>
	<div id="formTransfer" style="padding-top:40px">
		<div runat="server" style="display:table; width:100%">
			<fieldset>
				<div id="group_sltCuentaOrigen" class="form-group" style="display: table-row; padding-bottom:40px; width:100%;">
					<div style="display: table-cell; width:60%">
						<label for="sltCuentaOrigen">Desde Cuenta:</label>
						<select runat="server" class="form-control" id="sltCuentaOrigen">
							<option>Ahorro / 8123495</option>
							<option>Corriente / 5341892</option>
						</select>
					</div>
					<div style="display: table-cell; padding-left:200px; width:40%">
						<label for="balanceCuentaOrigen">Balance</label>
						<asp:Label runat="server" ID="balanceCuentaOrigen" CssClass="form-control">RD$800.00</asp:Label>
					</div>
				</div>
				<div id="group_sltCuentaDestino" class="form-group" style="display: table-row; width:100%">
					<div style="display:table-cell; padding-top:40px; width:60%">
						<label for="txtCuentaDestino">Hasta Cuenta:</label>
						<asp:TextBox id="txtCuentaDestino" runat="server" class="form-control" placeholder="Numero de cuenta"/>
					</div>
				</div>
				<div class="border-bottom border-primary" style="padding-top:40px"></div>
				<div id="group_sltMonto" class="form-group" style="display: table-row; padding-top:60px; width:100%">
					<div style="display:table-cell; padding-top:40px; width:60%">
						<label for="txtMonto">Monto:</label>
						<asp:TextBox id="txtMonto" runat="server" class="form-control" placeholder="Monto en pesos dominicanos"/>
					</div>
				</div>
			</fieldset>
		</div>
	</div>
</asp:Content>
