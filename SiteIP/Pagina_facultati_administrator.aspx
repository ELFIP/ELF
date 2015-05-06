<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pagina_facultati_administrator.aspx.cs" Inherits="Pagina_facultati_administrator" MasterPageFile="MasterPage.master"%>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="panou_facultati" runat="server">

    </asp:Panel>
    <br />
    <asp:Button ID="adauga_facultate" runat="server" Text="+" CssClass ="buton_adaugare" OnClick="adauga_facultate_Click" />
</asp:Content>
