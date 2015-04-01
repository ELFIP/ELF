<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Administrare_utilizator.aspx.cs" Inherits="Administrare_utilizator" MasterPageFile="~/MasterPage.master"%>


<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">
    <div style="margin-left: auto; margin-right: auto; text-align: center;">
        <asp:Label ID="label_cauta_utilizator" runat="server" Text="Cauta utilizator"></asp:Label>
        <br />
        <asp:TextBox ID="cauta_utilizator" runat="server" Style="margin:5px; padding: 5px;" Width="30%" OnTextChanged="Page_Load"></asp:TextBox>
    </div>
    <hr />
    <div style="margin-left: auto; margin-right: auto; text-align: center;">
        <asp:Table ID="tabel_utilizatori" runat="server" Width="75%" HorizontalAlign="Center">
            <asp:TableHeaderRow runat="server">

            </asp:TableHeaderRow>
        </asp:Table>

    </div>
</asp:Content>
