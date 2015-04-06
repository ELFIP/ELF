<%@ Page Language="C#" AutoEventWireup="true" CodeFile="recover.aspx.cs" Inherits="recover" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="tb_email" runat="server" placeholder="Email"></asp:TextBox>
        <br />
        <asp:Button ID="btn_trimite" runat="server" Text="Trimite" OnClick="btn_trimite_Click" />
        <br />
        <asp:Label ID="lbl_debug" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
