<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pagina_facultati_administrator.aspx.cs" Inherits="Pagina_facultati_administrator" MasterPageFile="MasterPage.master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Table ID="tabel_facultati" runat="server" Width="80%" Style="margin-left: 10%">
        <asp:TableHeaderRow Width="100%">
            <asp:TableHeaderCell HorizontalAlign="Center" Style="padding: 10px" Width="50%" ColumnSpan="2">
                <asp:Label ID="numeFacultati" runat="server" Text="Facultati" Width="50%">
                </asp:Label>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="50%">
                <asp:Table ID="tabel_link_facultati" runat="server">
                </asp:Table>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="50%">
                <asp:Table ID="tabel_butoane_stergere" runat="server">
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="50%" ColumnSpan="2">
                <asp:Button ID="adauga_facultate" runat="server" Text="Adauga Facultate" CssClass="buton_adaugare" OnClick="adauga_facultate_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
