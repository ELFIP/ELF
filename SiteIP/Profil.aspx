<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Profil.aspx.cs" Inherits="Profil" MasterPageFile="~/MasterPage.master"%>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">

</asp:Content>
<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">

    <asp:Panel ID="panou_header" runat="server" CssClass="header_profil" >
        <asp:Panel ID="panou_iconita" runat="server" CssClass="iconita_profil">
            <asp:Image ID="iconita" runat="server" Width="50px" Height="50px" />
        </asp:Panel>
        <asp:Panel ID="panou_nume_utilizator" runat="server" CssClass="nume_utilizator_profil">
            Mihai Alexandru
        </asp:Panel>
        <asp:Panel ID="panou_buton_edit" runat="server" CssClass="buton_edit_profil">
             <asp:Button ID="Button1" runat="server" Text="Edit" Height="40px" Width="40px" />
        </asp:Panel>
    </asp:Panel>

    <br />

    <asp:Panel ID="continut" runat="server">
        <asp:Panel ID="panou_listacursuri" runat="server" CssClass="dropdown_profil">
            <asp:DropDownList ID="listacursuri" runat="server" CssClass="dropdown_profil">

            </asp:DropDownList>
        </asp:Panel>

        <br />

        <asp:Panel ID="panou_listafacultati" runat="server" CssClass="dropdown_profil">
            <asp:DropDownList ID="listafacultati" runat="server" CssClass="dropdown_profil">

            </asp:DropDownList>
        </asp:Panel>

        <asp:Panel ID="panou_ziuainregistrarii" runat="server">

        </asp:Panel>

        <asp:Panel ID="panou_altedetalii" runat="server">

        </asp:Panel>
    </asp:Panel>

</asp:Content>