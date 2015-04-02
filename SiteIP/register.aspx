<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inregistrare</title>
    <meta charset="utf-8"/>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="tb_nume" placeholder="Nume" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_nume" ErrorMessage="Numele este obligatoriu !"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="tb_nume" ErrorMessage="Numele nu este valid (trebuie sa contina numai litere) !" ValidationExpression="^[a-zA-Z]+$"></asp:RegularExpressionValidator>
        <br />   

        <asp:TextBox ID="tb_prenume" placeholder="Prenume" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_prenume" ErrorMessage="Prenumele este obligatoriu !"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="tb_prenume" ErrorMessage="Prenumele nu este valid (trebuie sa contina numai litere) !" ValidationExpression="^[a-zA-Z]+$"></asp:RegularExpressionValidator>
        <br />

        <asp:TextBox ID="tb_email" placeholder="Email" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tb_email" ErrorMessage="Emailul este obligatoriu !"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tb_email" ErrorMessage="Emailul nu este valid !" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />

        <asp:TextBox ID="tb_parola" placeholder="Parola" TextMode="password" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tb_parola" ErrorMessage="Parola este obligatorie !"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tb_parola" ErrorMessage="Parola nu este valida (lungime minima de 8 caractere, litere si cifre) !" ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,15})$"></asp:RegularExpressionValidator>
        <br />

        <asp:TextBox ID="tb_mediaNotelor" placeholder="Media notelor" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tb_mediaNotelor" ErrorMessage="Media este obligatorie !"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="tb_mediaNotelor" ErrorMessage="Media notelor nu este valida (lungime minima de 1 caracter, doar cifre !" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
        <br />

        <asp:TextBox ID="tb_adresa" placeholder="Adresa" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tb_adresa" ErrorMessage="Adresa este obligatorie !"></asp:RequiredFieldValidator>
        <br />

        <input type="text" id="datepicker" placeholder="Data nasterii"/>        
        <br /><br />

        <asp:Button ID="btn_trimite" runat="server" Text="Trimite" OnClick="btn_trimite_Click" />
    </form>
    <script>
        $(function () {
            $("#datepicker").datepicker();
        });
    </script>
    </body>
</html>
