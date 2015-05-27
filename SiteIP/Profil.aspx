<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Profil.aspx.cs" Inherits="Profil" MasterPageFile="MasterPage.master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link rel='stylesheet' type='text/css' href="/Resources/css/PaginaDeProfil.css" />
    <link rel='stylesheet' type='text/css' href="/Resources/Master_layout_style.css" />
    <link href="http://fonts.googleapis.com/css?family=Open+Sans" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">

    <asp:Panel ID="panou_header" runat="server" CssClass="header_profil">
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

    <!-- random comment -->

    <asp:Panel ID="Link" runat="server" CssClass="profil-nav">
        <asp:HyperLink ID="HyperLink_profil" runat="server" NavigateUrl="Profil.aspx">Profil</asp:HyperLink>
        <asp:HyperLink ID="HyperLink_cursuri" runat="server" NavigateUrl="Cursuri_profil.aspx">Cursuri</asp:HyperLink>
        <asp:HyperLink ID="HyperLink_facultati" runat="server" NavigateUrl="Facultati_recomandate_profil.aspx">Facultati</asp:HyperLink>
        <asp:HyperLink ID="HyperLink_schimba_parola" runat="server" NavigateUrl="Schimba Parola.aspx">Schimba Parola</asp:HyperLink>
    </asp:Panel>


    <asp:Panel ID="continut" runat="server" CssClass="continut">
        <asp:Panel ID="panou_nume" runat="server" CssClass="item_profil">
            <asp:Label ID="label_nume" runat="server" Text="Nume" CssClass="eti">
            </asp:Label>
            <br />
            <asp:TextBox ID="textbox_nume" runat="server" CssClass="item_profil">
            </asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="panou_prenume" runat="server" CssClass="item_profil">
            <asp:Label ID="label_prenume" runat="server" Text="Prenume" CssClass="eti">
            </asp:Label>
            <br />
            <asp:TextBox ID="textbox_prenume" runat="server" CssClass="item_profil">
            </asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="panou_domiciliu" runat="server" CssClass="item_profil">
            <asp:Label ID="label_domiciliu" runat="server" Text="Domiciliu" CssClass="eti">
            </asp:Label>
            <br />
            <asp:TextBox ID="textbox_domiciliu" runat="server" CssClass="item_profil">
            </asp:TextBox>
        </asp:Panel>
        <br />
        <asp:Panel ID="panou_altedetalii" runat="server" CssClass="item_profil">
            <br />
            <asp:Panel ID="panou_este_administrator" runat="server" CssClass="item_profil">
                <asp:Label ID="label_este_administrator_text" runat="server" Text="Este administrator ?">
                </asp:Label>
                <br />
                <asp:Label ID="label_este_administrator" runat="server" Text="">
                </asp:Label>
            </asp:Panel>
            <br />
            <asp:Button ID="actualizare_profil" runat="server" Text="Actualizeaza Profil" OnClick="actualizare_profil_Click" CssClass="buton" />
        </asp:Panel>
        <br />
    </asp:Panel>
</asp:Content>
