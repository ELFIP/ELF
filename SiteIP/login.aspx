<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/normalize/3.0.3/normalize.css" rel='stylesheet' type='text/css' />
    <link href="Resources/css/globalStyle.css" rel="stylesheet" />
    <link href="Resources/css/loginPageStyle.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Roboto:500' rel='stylesheet' type='text/css' />
</head>
<body>
   <!-- <header>
        <nav>
            <a href="#"> Home </a>
            <a href="#"> Bananas </a>
            <a href="#"> Papoi </a>
        </nav>
    </header>-->
    <div class="centering_container">
        <form id="form1" runat="server">    
            <asp:TextBox ID="tb_email" runat="server" CssClass="inputs" placeholder="Email"></asp:TextBox>
            <br /><br />
            <asp:TextBox ID="tb_parola" runat="server" CssClass="inputs" placeholder="Parola" TextMode="password"></asp:TextBox>
            <br /><br />
            <asp:Button ID="btn_login" runat="server" CssClass="buton" Text="Login" OnClick="btn_login_Click" />
            <asp:Label ID="lbl_alertDateLogin" CssClass="eroareLogin" runat="server" Text=""></asp:Label>
        </form>
    </div>
    <footer>
        <nav>
            <a href="#"> About </a>
            <a href="#"> Termeni si Factori </a>
            <p> &copy; 2015 </p>
        </nav>
    </footer>
</body>
</html>
