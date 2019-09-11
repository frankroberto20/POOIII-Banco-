<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InternetBanking.Login" %>

<!DOCTYPE html>
<webopt:bundlereference runat="server" path="~/Content/css" />
<link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
	<link rel="stylesheet" type="text/css" href="Content/login-style.css"
</head>

<div class="loginbox">
<form runat="server" id="login">
	<h1 align="center">Login</h1>
  <fieldset runat="server">
    <div class="form-group" runat="server">
      <label for="inputUserName">User Name</label>
      <asp:TextBox runat="server" type="text" class="form-control" id="inputUserName" aria-describedby="emailHelp" placeholder="Enter User Name" />
		<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="inputUserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="login">*</asp:RequiredFieldValidator>
		<small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
    </div>
    <div class="form-group" runat="server">
      <label for="inputPassword">Password</label>
      <asp:TextBox runat="server" type="password" class="form-control" id="inputPassword" placeholder="Password"/>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="inputPassword" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="login">*</asp:RequiredFieldValidator>
		</div>
	  <asp:Button ID="btnSubmit" runat="server" CommandName="Login" Text="Log In" ValidationGroup="login" />
	  </fieldset>
    </form>
	</div>

	<div>
		<asp:Login runat="server" id="Login1">
			<LayoutTemplate>
				<form runat="server" id="Form1">
	<h1 align="center">Login</h1>
  <fieldset runat="server">
    <div class="form-group" runat="server">
      <label for="inputUserName">User Name</label>
      <asp:TextBox runat="server" type="text" class="form-control" id="TextBox1" aria-describedby="emailHelp" placeholder="Enter User Name" />
		<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="inputUserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="login">*</asp:RequiredFieldValidator>
		<small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
    </div>
    <div class="form-group" runat="server">
      <label for="inputPassword">Password</label>
      <asp:TextBox runat="server" type="password" class="form-control" id="TextBox2" placeholder="Password"/>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="inputPassword" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="login">*</asp:RequiredFieldValidator>
		</div>
	  <asp:Button ID="Button1" runat="server" CommandName="Login" Text="Log In" ValidationGroup="login" />
	  </fieldset>
    </form>
			</LayoutTemplate>
		</asp:Login>
	</div>

</body>
</html>
