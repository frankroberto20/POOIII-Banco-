<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="InternetBanking.Register" %>

<!DOCTYPE html>

<!DOCTYPE html style="height:400px; width:400px">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
	<script type="text/javascript" src="/scripts/jquery.min.js"></script>
  <script type="text/javascript" src="/scripts/moment.min.js"></script>
  <script type="text/javascript" src="/scripts/bootstrap.min.js"></script>
  <script type="text/javascript" src="/scripts/bootstrap-datetimepicker.*js"></script>
  <link rel="stylesheet" href="/Content/bootstrap-datetimepicker.css" />

	<link rel="stylesheet" type="text/css" href="Content/register-style.css" />
	<webopt:bundlereference runat="server" path="~/Content/css" />
	<link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
	<link rel="stylesheet" type="text/css" href="Content/bootstrap-default.css"/>
</head>
<body>
	<div>
		<form runat="server" class="loginbox" id="frmCreateUser">
			<fieldset>
							<table style="padding-right:20px; padding-left:20px; width:380px" align="center" >
								<tr>
									<td align="center" style="padding-bottom:40px; padding-top:20px" class="h1">Register New User</td>
								</tr>
								<tr class="form-group">
									<td style="width:100%">
										<asp:Label ID="NombreLabel" runat="server" AssociatedControlID="Nombre">Nombre:</asp:Label>
										<asp:TextBox ID="Nombre" runat="server" CssClass="form-control" style="max-width:100%"></asp:TextBox>
										<asp:RequiredFieldValidator ID="NameRequired" runat="server" ControlToValidate="Nombre" ErrorMessage="Name is required." ToolTip="Name is required." ValidationGroup="frmCreateUser" CssClass="text-danger small">*</asp:RequiredFieldValidator>
									</td>
								</tr>
								<tr class="form-group">
									<td>
										<asp:Label ID="ApellidoLabel" runat="server" AssociatedControlID="Apellido">Apellido:</asp:Label>
										<asp:TextBox ID="Apellido" runat="server" CssClass="form-control" style="max-width:100%"></asp:TextBox>
										<asp:RequiredFieldValidator ID="LastNameRequired" runat="server" ControlToValidate="Apellido" ErrorMessage="Last Name is required." ToolTip="Name is required." ValidationGroup="frmCreateUser" CssClass="text-danger small">*</asp:RequiredFieldValidator>
									</td>
								</tr>
								<tr class="form-group">
									<td>
										<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuario:</asp:Label>
										<asp:TextBox ID="UserName" runat="server" CssClass="form-control" style="max-width:100%"></asp:TextBox>
										<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="frmCreateUser" CssClass="text-danger small">*</asp:RequiredFieldValidator>
									</td>
								</tr>
								<tr class="form-group">
									<td>
										<asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
										<asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control" style="max-width:100%"></asp:TextBox>
										<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="frmCreateUser" CssClass="text-danger small">*</asp:RequiredFieldValidator>
									</td>
								</tr>
								<tr class="form-group">
									<td>
										<asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
										<asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" style="max-width:100%"></asp:TextBox>
										<asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword" ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required." ValidationGroup="frmCreateUser" CssClass="text-danger small">*</asp:RequiredFieldValidator>
									</td>
								</tr>
								<tr class="form-group">
									<td>
										<asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
										<asp:TextBox ID="Email" runat="server" CssClass="form-control" style="max-width:100%"></asp:TextBox>
										<asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" ErrorMessage="E-mail is required." ToolTip="E-mail is required." ValidationGroup="frmCreateUser" CssClass="text-danger small">*</asp:RequiredFieldValidator>
									</td>
								</tr>
								<tr class="form-group">
									<td>
										<asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Security Question:</asp:Label>
										<asp:TextBox ID="Question" runat="server" CssClass="form-control" style="max-width:100%"></asp:TextBox>
										<asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question" ErrorMessage="Security question is required." ToolTip="Security question is required." ValidationGroup="frmCreateUser" CssClass="text-danger small">*</asp:RequiredFieldValidator>
									</td>
								</tr>
								<tr class="form-group">
									<td>
										<asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Security Answer:</asp:Label>
										<asp:TextBox ID="Answer" runat="server" CssClass="form-control" style="max-width:100%"></asp:TextBox>
										<asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer" ErrorMessage="Security answer is required." ToolTip="Security answer is required." ValidationGroup="frmCreateUser" CssClass="text-danger small">*</asp:RequiredFieldValidator>
									</td>
								</tr>
								<tr>
									<td align="center">
										<asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match." ValidationGroup="frmCreateUser"></asp:CompareValidator>
									</td>
								</tr>
								<tr>
									<td align="center" style="color:Red;">
										<asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
									</td>
								</tr>
							</table>
				</fieldset>
			<asp:Button ID="btnSubmit" runat="server" type="submit" CssClass="btn btn-primary" Text="Create User" ValidationGroup="frmCreateUser"/>
		</form>
	</div>
</body>
</html>
