<%@ Page Title="Cuenta Favorita" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CuentasFavoritasConfiguration.aspx.cs" Inherits="InternetBanking.CuentasFavoritasConfiguration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<webopt:bundlereference runat="server" path="~/Content/css" />
<link rel="stylesheet" type="text/css" href="Content/Transferencia-style.css" />

<div runat="server" style="display:table; width:100%">
    <!-- ========================================================================= -->
    <div style="margin-left: auto; margin-right: auto; text-align: center;">
        <br />
        <br />
        <h3>Configuracion de Cuentas Favoritas</h3>
    </div>

    <script type="text/javascript">

        function showAgregarCuenta() {
            document.getElementById('divCuentaFavorita1').style.display = 'block';
        }

    </script>

        <div id="group_sltCuenta" class="form-group" style="display: table-row; padding-bottom:40px; width:100%;">
			<div style="display: table-cell; width:60%">
				<br />
				<label for="sltCuenta">Hasta Cuenta:</label>
				<select runat="server" class="form-control" id="Select1">
					<option>Ahorro / 8123495</option>
					<option>Corriente / 5341892</option>
				</select>
			</div>
        </div>

        <div>
            <br />
            <asp:GridView ID="grdCuentasFavoritas" runat="server" CssClass="table table-hover" GridLines="Horizontal" OnRowDataBound="grdCuentasFavoritas_RowDataBound" CellPadding="3" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
		        <AlternatingRowStyle BackColor="#F7F7F7" />
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
            </asp:GridView>
            <br />
            <br />
        </div>

    <asp:Button Id="btnAddCuentafavorita1" Text="Agregar Cuenta" runat="server" OnClick="btnAddCuentafavorita1_Click" />
    &nbsp
    <asp:Button Id="btnDeleteCuentaFavorita" Text="Eliminar Cuenta" runat="server" OnClick="btnDeleteCuentaFavorita_Click" />

    <div class="border-bottom border-primary" style="padding-top:40px"></div> <!-- this is a line -->

    <div id="divAddCuentaFavorita" >
        <div id="group_sltCuentaDestino2" class="form-group" style="display: table-row; width:100%; padding-top:40px" >
			<div style="display:table-cell; padding-top:40px; width:60%">
				 <asp:Label id="lblAddCuentaFavorita" runat="server" Text="Numero de Cuenta:"/>
                <br />
				<asp:TextBox id="txtAddCuentaFavorita" runat="server" class="form-control" placeholder="Numero de cuenta"/>
                <br />
                <asp:Button Id="SubmitCuentaFavorita" Text="Submit" runat="server"/>
			</div>
        </div>
    </div>

    <div id="divDeleteCuentaFavorita">
		<div style="display:table-cell; padding-top:40px; width:60%">
			<asp:Label id="lblDeleteCuentaFavorita" runat="server" Text="Numero de Cuenta:"/>
            <br />
			<asp:TextBox id="txtDeleteCuentaFavorita" runat="server" class="form-control" placeholder="Numero de cuenta"/>
            <br />
            <asp:Button Id="SubmitCuentaDelete" Text="Submit" runat="server" OnClick="Button1_Click" />
		</div>        
    </div>

</div>



</asp:Content>

