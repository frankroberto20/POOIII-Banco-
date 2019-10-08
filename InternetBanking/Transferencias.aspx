<%@ Page Title="Transferencias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transferencias.aspx.cs" Inherits="InternetBanking.Transferencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<header>
		<webopt:bundlereference runat="server" path="~/Content/css" />
		<link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
		<link rel="stylesheet" type="text/css" href="Content/bootstrap-default.css"/>
        <link rel="stylesheet" type="text/css" href="Content/Transferencia-style.css" />
	</header>
	<header style="padding-top:40px">
		<h1>Tranferencia</h1>
	</header>
	<div id="formTransfer" style="padding-top:40px">
		<div runat="server" style="display:table; width:100%">
			<fieldset>
 <script type="text/javascript">

                function dontshow() {
                    document.getElementById('div1').style.display = 'none';
                }
                function showdiv1() {
                    document.getElementById('div1').style.display = 'block';
                    document.getElementById('div2').style.display = 'none';
                    document.getElementById('div3').style.display = 'none';
                }

                function showdiv2() {
                    document.getElementById('div2').style.display = 'block';
                    document.getElementById('div1').style.display = 'none';
                    document.getElementById('div3').style.display = 'none';

                }

                function showdiv3() {
                    document.getElementById('div3').style.display = 'block';
                    document.getElementById('div1').style.display = 'none';
                    document.getElementById('div2').style.display = 'none';
                }
            </script>


                <!--  ============================================================ -->

                <h5>Cuenta a Transferir: </h5>
                    <input type="radio" name="tab" value="igotnone" onclick="showdiv1();" />
                    Cuenta Propia

                    <input type="radio" name="tab" value="igottwo" onclick="showdiv2();" />
                    Otra Cuenta

                    <input type="radio" name="tab" value="igottwo" onclick="showdiv3();" />
                    Cuenta de Otro Banco


                        <div id="div1" class="hide">
				
				            <div id="group_sltCuentaOrigen" class="form-group" style="display: table-row; padding-bottom:40px; width:100%;">
                                <div style="display: table-cell; padding-left:500px; width:40%">
						            <label for="balanceCuentaOrigen">Balance</label>
						            <asp:Label runat="server" ID="Label1" CssClass="form-control">RD$800.00</asp:Label>
					            </div>
                            </div>

					        <div style="display: table-cell; width:60%">
						            <br />
						            <label for="sltCuentaOrigen">Desde Cuenta:</label>
						            <select runat="server" class="form-control" id="Select7">
							            <option>Ahorro / 8123495</option>
							            <option>Corriente / 5341892</option>
						            </select>
                            </div>

                            <div id="group_sltCuentaDestino" class="form-group" style="display: table-row; padding-bottom:40px; width:100%;">
					            <div style="display: table-cell; width:60%">
						            <br />
						            <label for="sltCuentaDestino">Hasta Cuenta:</label>
						            <select runat="server" class="form-control" id="Select2">
							            <option>Ahorro / 8123495</option>
							            <option>Corriente / 5341892</option>
						            </select>
					            </div>
                            </div>

                        </div>

                        <div id="div2" class="hide">
                                <div id="group_sltCuentaOrigen2" class="form-group" style="display: table-row; padding-bottom:40px; width:100%;">
                                    <div style="display: table-cell; padding-left:500px; width:40%">
						                <label for="balanceCuentaOrigen">Balance</label>
						                <asp:Label runat="server" ID="Label2" CssClass="form-control">RD$800.00</asp:Label>
					                </div>
                                </div>

					            <div style="display: table-cell; width:60%">
						                <br />
						                <label for="sltCuentaOrigen">Desde Cuenta:</label>
						                <select runat="server" class="form-control" id="Select3">
							                <option>Ahorro / 8123495</option>
							                <option>Corriente / 5341892</option>
						                </select>

                                <div id="group_sltCuentaDestino2" class="form-group" style="display: table-row; width:100%">
					                    <div style="display:table-cell; padding-top:40px; width:60%">
						                    <label for="txtCuentaDestino2">Hasta Cuenta:</label>
						                    <asp:TextBox id="txtCuentaDestino" runat="server" class="form-control" placeholder="Numero de cuenta"/>
					                        <br />
					                    </div>
                                </div>

                                <div style="display: table-cell; width:60%">
						                    <label for="lblFavorite">Cuenta Favorita:</label>
						                    <select runat="server" class="form-control" id="Select4">
							                    <option>Ahorro / 8123495</option>
							                    <option>Corriente / 5341892</option>
						                    </select>
                                </div>
                            </div>
                        </div>



                        <div id="div3" class="hide">
                            <div id="group_sltCuentaOrigen3" class="form-group" style="display: table-row; padding-bottom:40px; width:100%;">
                                <div style="display: table-cell; padding-left:500px; width:40%">
						            <label for="balanceCuentaOrigen">Balance</label>
						            <asp:Label runat="server" ID="Label3" CssClass="form-control">RD$800.00</asp:Label>
					            </div>
                            </div>

					        <div style="display: table-cell; width:60%">
						            <br />
						            <label for="sltCuentaOrigen">Desde Cuenta:</label>
						            <select runat="server" class="form-control" id="Select5">
							            <option>Ahorro / 8123495</option>
							            <option>Corriente / 5341892</option>
						            </select>
                            </div>

                            <div style="display: table-cell; width:60%" >
						        <label for="lblFavorite">Banco: </label>
						            <select runat="server" class="form-control" id="Select6">
							            <option>Banco 1</option>
							            <option>Banco 2</option>
						            </select>
                            </div>

                            <div id="group_sltCuentaDestino3" class="form-group" style="display: table-row; width:100%">
					                <div style="display:table-cell; padding-top:40px; width:60%">
						                <label for="txtCuentaDestino2">Hasta Cuenta:</label>
						                <asp:TextBox id="TextBox1" runat="server" class="form-control" placeholder="Numero de cuenta"/>
					                    <br />
					                </div>
                            </div>
                        </div>

                        


				<!--<div id="group_sltCuentaOrigen" class="form-group" style="display: table-row; padding-bottom:40px; width:100%;">
					<div style="display: table-cell; width:60%">
						<br />
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
				</div>-->

				<!-- <div id="group_sltCuentaDestino" class="form-group" style="display: table-row; width:100%">
					<div style="display:table-cell; padding-top:40px; width:60%">
						<label for="txtCuentaDestinokd">Hasta Cuenta:</label>
						<asp:TextBox id="txtCuentaDestino123" runat="server" class="form-control" placeholder="Numero de cuenta"/>
					    <br />
					</div>

                    <div style="display: table-cell; width:60%">
						<label for="lblFavorite">Cuenta Favorita:</label>
						<select runat="server" class="form-control" id="Select1">
							<option>Ahorro / 8123495</option>
							<option>Corriente / 5341892</option>
						</select>
					</div> -->


				<div class="border-bottom border-primary" style="padding-top:40px"></div>
				<div id="group_sltMonto" class="form-group" style="display: table-row; padding-top:60px; width:100%">
					<div style="display:table-cell; padding-top:40px; width:60%">
						<label for="txtMonto">Monto:</label>
						<asp:TextBox id="txtMonto" runat="server" class="form-control" placeholder="Monto en pesos dominicanos"/>
					</div>
				</div>
				<asp:Button id="btnTransferencia" runat="server" CssClass="btn btn-primary" type="submit" Text="Submit"/>
			</fieldset>
		</div>
	</div>
</asp:Content>
