﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">    
        <asp:TextBox ID="tb_email" runat="server" placeholder="Email"></asp:TextBox>
        <br /><br />
        <asp:TextBox ID="tb_parola" runat="server" placeholder="Parola" TextMode="password"></asp:TextBox>
        <br /><br />
        <asp:Button ID="btn_login" runat="server" Text="Login" OnClick="btn_login_Click" />
        <asp:Label ID="lbl_alertDateLogin" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
