<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pagina_facultati.aspx.cs" Inherits="Pagina_facultati" MasterPageFile="MasterPage.master"%>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link rel='stylesheet' type='text/css' href="/Resources/css/facultati_list.css" />
    
    <link href="http://fonts.googleapis.com/css?family=Open+Sans" rel="stylesheet" type="text/css">

</asp:Content>
<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Table ID="tabel_facultati" runat="server" Width="80%" Style="margin-left: 10%">
        <asp:TableHeaderRow Width="100%">
            <asp:TableHeaderCell HorizontalAlign="Center" Style="padding: 10px" Width="50%">
                <asp:Label ID="numeFacultati" runat="server" Text="Facultati" Width="50%">
                </asp:Label>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow CssClass="fac">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="50%">
                <asp:Table ID="tabel_link_facultati" runat="server">
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
