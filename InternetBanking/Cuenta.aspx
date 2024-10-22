﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cuenta.aspx.cs" Inherits="InternetBanking.Cuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<header>
		<webopt:bundlereference runat="server" path="~/Content/css" />
		<link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
		<link rel="stylesheet" type="text/css" href="Content/bootstrap-default.css"/>
		<link rel="stylesheet" type="text/css" href="Content/gridview-style.css"/>
	</header>
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
</asp:Content>
