<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InternetBanking.Login" %>

<!DOCTYPE html style="height:400px; width:400px">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
	<link rel="stylesheet" type="text/css" href="Content/login-style.css" />
	<webopt:bundlereference runat="server" path="~/Content/css" />
	<link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
	<link rel="stylesheet" type="text/css" href="Content/bootstrap-default.css"/>
</head>
<body>
	<div>
		<form id="formLogin" runat="server">
	<asp:Login ID="Login1" runat="server">
	<LayoutTemplate>
	<div class="loginbox">
		<h1 align="center" style="padding-bottom:10px;">Log In</h1>
    <div class="form-group">
      <label for="UserName">User Name</label>
      <asp:TextBox id="UserName" runat="server" type="username" class="form-control" placeholder="Enter User Name" />
		<asp:RequiredFieldValidator ID="usernameValidator" runat="server" CssClass="text-danger small" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*Username Required</asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
      <label for="Password">Password</label>
      <asp:TextBox id="Password" runat="server" type="password" class="form-control" placeholder="Password"/>
		<asp:RequiredFieldValidator ID="passwordValidator" runat="server" CssClass="text-danger small" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*Password Required</asp:RequiredFieldValidator>
		</div>
	  <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" CommandName="Login" Text="Log In" ValidationGroup="Login1" OnClick="btnSubmit_Click"/>
	</div>
		</LayoutTemplate>
		</asp:Login>
			</form>
	</div>
</body>
</html>
