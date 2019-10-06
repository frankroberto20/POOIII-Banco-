<%@ Page Title="Crear Cuenta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearCuenta.aspx.cs" Inherits="InternetBanking.CrearCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<header>
		<webopt:bundlereference runat="server" path="~/Content/css" />
		<link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
		<link rel="stylesheet" type="text/css" href="Content/bootstrap-default.css"/>
	</header>
	<header style="padding-top:40px">
		<h1>Nueva Cuenta</h1>
	</header>
	<div id="formTransfer" runat="server" style="padding-top:40px">
		<div runat="server" style="display:table; width:100%">
			<fieldset>
				<div class="form-group">
					<label for="sltTipoCuenta">Tipo de Cuenta</label>
					<select runat="server" class="form-control" id="sltTipoCuenta">
						<option value="1">Ahorro</option>
						<option value="2">Corriente</option>
					</select>
				</div>
				<asp:Button id="btnSolicitarCuenta" runat="server" CssClass="btn btn-primary" type="submit" Text="Solicitar Cuenta"/>
			</fieldset>
		</div>
	</div>
	
</asp:Content>
