<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Administrare_utilizator.aspx.cs" Inherits="Administrare_utilizator" MasterPageFile="MasterPage.master"%>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">
    <div style="margin-left: auto; margin-right: auto; text-align: center;">
        <asp:Table ID="tabel_utilizatori" runat="server" Width="90%" HorizontalAlign="Center">
            <asp:TableHeaderRow runat="server">

            </asp:TableHeaderRow>
        </asp:Table>
    </div>
    <asp:Panel ID="form2" runat="server"></asp:Panel>
</asp:Content>
