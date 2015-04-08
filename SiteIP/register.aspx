<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inregistrare</title>
    <meta charset="utf-8"/>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/normalize/3.0.3/normalize.css" rel='stylesheet' type='text/css' />
    <link href="Resources/css/globalStyle.css" rel="stylesheet" />
    <link href="Resources/css/registerPageStyle.css" rel="stylesheet" />
    <link href="Resources/css/loginPageStyle.css" rel="stylesheet" />
   <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Roboto:500' rel='stylesheet' type='text/css'>
</head>
<body>
    <!--<header>
        <nav>
            <a href="#"> Home </a>
            <a href="#"> Bananas </a>
            <a href="#"> Papoi </a>
        </nav>
    </header>-->
    <div class="centering_container">
        <form id="form1" runat="server">

            <div class="field_container">
                
                <asp:TextBox ID="tb_nume" CssClass="inputs" placeholder="Nume" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="err_msg" ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_nume" ErrorMessage="Numele este obligatoriu !"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator CssClass="err_msg" ID="RegularExpressionValidator3" runat="server" ControlToValidate="tb_nume" ErrorMessage="Numele nu este valid (trebuie sa contina numai litere) !" ValidationExpression="^[a-zA-Z]+$"></asp:RegularExpressionValidator>
            </div>

            <div class="field_container">
                <asp:TextBox ID="tb_prenume" CssClass="inputs" placeholder="Prenume" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator  CssClass="err_msg" ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_prenume" ErrorMessage="Prenumele este obligatoriu !"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator  CssClass="err_msg" ID="RegularExpressionValidator4" runat="server" ControlToValidate="tb_prenume" ErrorMessage="Prenumele nu este valid (trebuie sa contina numai litere) !" ValidationExpression="^[a-zA-Z]+$"></asp:RegularExpressionValidator>
            </div>

            <div class="field_container">
                <asp:TextBox ID="tb_email" CssClass="inputs" placeholder="Email" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator  CssClass="err_msg" ID="RequiredFieldValidator3" runat="server" ControlToValidate="tb_email" ErrorMessage="Emailul este obligatoriu !"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator   CssClass="err_msg" ID="RegularExpressionValidator1" runat="server" ControlToValidate="tb_email" ErrorMessage="Emailul nu este valid !" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>

            <div class="field_container">
                <asp:TextBox ID="tb_parola" CssClass="inputs" placeholder="Parola" TextMode="password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator  CssClass="err_msg" ID="RequiredFieldValidator4" runat="server" ControlToValidate="tb_parola" ErrorMessage="Parola este obligatorie !"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator  CssClass="err_msg" ID="RegularExpressionValidator2" runat="server" ControlToValidate="tb_parola" ErrorMessage="Parola nu este valida (lungime minima de 8 caractere, litere si cifre) !" ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,15})$"></asp:RegularExpressionValidator>
            </div>

            <div class="field_container">
                <asp:TextBox ID="tb_mediaNotelor" CssClass="inputs" placeholder="Media notelor" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator  CssClass="err_msg" ID="RequiredFieldValidator5" runat="server" ControlToValidate="tb_mediaNotelor" ErrorMessage="Media este obligatorie !"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator  CssClass="err_msg" ID="RegularExpressionValidator5" runat="server" ControlToValidate="tb_mediaNotelor" ErrorMessage="Media notelor nu este valida (lungime minima de 1 caracter, doar cifre !" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
            </div>

            <div class="field_container">
                <asp:TextBox ID="tb_adresa" CssClass="inputs" placeholder="Adresa" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator  CssClass="err_msg" ID="RequiredFieldValidator6" runat="server" ControlToValidate="tb_adresa" ErrorMessage="Adresa este obligatorie !"></asp:RequiredFieldValidator>
            </div>

            <div class="field_container">
                <input type="text" id="datepicker" class="inputs" placeholder="Data nasterii"/> 
                <span class="space_holder"> </span
                <span class="space_holder"> </span>
            </div>

            <asp:Button ID="btn_trimite" CssClass="buton" runat="server" Text="Trimite" OnClick="btn_trimite_Click" />
            <asp:Label ID="lbl_debug" runat="server" Text=""></asp:Label>
        </form>
    </div>
    <footer>
        <nav>
            <a href="#"> About </a>
            <a href="#"> Termeni si Factori </a>
            <p> &copy; 2015 </p>
        </nav>

    </footer>
    <script>
        $(function () {
            $("#datepicker").datepicker();
        });
    </script>
    </body>
</html>
