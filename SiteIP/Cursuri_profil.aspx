<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cursuri_profil.aspx.cs" Inherits="Cursuri_profil" MasterPageFile="MasterPage.master"%>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link rel='stylesheet' type='text/css' href="/Resources/css/PaginaDeProfil.css" />
</asp:Content>
<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">

    <asp:Panel ID="panou_header" runat="server" CssClass="header_profil">
        <asp:Panel ID="panou_iconita" runat="server" CssClass="iconita_profil">
            <asp:Image ID="iconita" runat="server" Width="50px" Height="50px" />
        </asp:Panel>
        <asp:Panel ID="panou_utilizator" runat="server" CssClass="utilizator_profil">
            <asp:Label ID="label_email" runat="server" Text="" CssClass="camp_profil">
            </asp:Label>
            <br />
            <asp:Label ID="label_data_nasterii" runat="server" Text="" CssClass="camp_profil">
            </asp:Label>
            <br />
            <asp:Label ID="label_data_inregistrarii" runat="server" Text="" CssClass="camp_profil">
            </asp:Label>
        </asp:Panel>
    </asp:Panel>

    <br />
    
    <asp:Panel ID="Link" runat="server">
        <asp:HyperLink ID="HyperLink_profil" runat="server" NavigateUrl="Profil.aspx">Profil</asp:HyperLink>
        <asp:HyperLink ID="HyperLink_cursuri" runat="server" NavigateUrl="Cursuri_profil.aspx">Cursuri</asp:HyperLink>
        <asp:HyperLink ID="HyperLink_facultati" runat="server" NavigateUrl="Facultati_recomandate_profil.aspx">Facultati</asp:HyperLink>
        <asp:HyperLink ID="HyperLink_schimba_parola" runat="server" NavigateUrl="Schimba Parola.aspx">Schimba Parola</asp:HyperLink>
    </asp:Panel>
    
    <br />

    <asp:Panel ID="continut" runat="server">
        <br />

        <asp:Panel ID="panou_listacursuri" runat="server" CssClass="item_profil">
            <asp:DropDownList ID="lista_cursuri" runat="server" CssClass="item_profil">
            </asp:DropDownList>
        </asp:Panel>
        <br />

    </asp:Panel>
</asp:Content>
