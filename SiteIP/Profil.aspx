<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Profil.aspx.cs" Inherits="Profil" MasterPageFile="~/MasterPage.master"%>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link rel='stylesheet' type='text/css' href="/Resources/css/PaginaDeProfil.css"/>
</asp:Content>
<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">

    <asp:Panel ID="panou_header" runat="server" CssClass="header_profil" >
        <asp:Panel ID="panou_iconita" runat="server" CssClass="iconita_profil">
            <asp:Image ID="iconita" runat="server" Width="50px" Height="50px" />
        </asp:Panel>
        <asp:Panel ID="panou_utilizator" runat="server" CssClass="utilizator_profil">
            <asp:Label ID="label_email" runat="server" Text="" CssClass="camp_profil" >

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

    <asp:Panel ID="continut" runat="server">
        <asp:Panel ID="panou_nume" runat="server" CssClass="item_profil">
            <asp:Label ID="label_nume" runat="server" Text="Nume" CssClass="item_profil">

            </asp:Label>
            <br />
            <asp:Textbox ID="textbox_nume" runat="server" Text="" CssClass="item_profil">

            </asp:Textbox>

        </asp:Panel>
        
        <asp:Panel ID="panou_prenume" runat="server" CssClass="item_profil">
            <asp:Label ID="label_prenume" runat="server" Text="Prenume" CssClass="item_profil">

            </asp:Label>
            <br />
            <asp:Textbox ID="textbox_prenume" runat="server" Text="" CssClass="item_profil">

            </asp:Textbox>

        </asp:Panel>

        <asp:Panel ID="panou_domiciliu" runat="server" CssClass="item_profil">
            <asp:Label ID="label_domiciliu" runat="server" Text="Domiciliu" CssClass="item_profil">

            </asp:Label>
            <br />
            <asp:Textbox ID="textbox_domiciliu" runat="server" Text="" CssClass="item_profil">

            </asp:Textbox>

        </asp:Panel>

        <br />

        <asp:Panel ID="panou_listacursuri" runat="server" CssClass="item_profil">
            <asp:DropDownList ID="lista_cursuri" runat="server" CssClass="item_profil">

            </asp:DropDownList>
        </asp:Panel>

        <br />

        <asp:Panel ID="panou_listafacultati" runat="server" CssClass="item_profil">
            <asp:DropDownList ID="lista_facultati" runat="server" CssClass="item_profil">

            </asp:DropDownList>
        </asp:Panel>

        <br />

        <asp:Panel ID="panou_altedetalii" runat="server" CssClass="item_profil">

            <br />
            
            <asp:Panel ID="panou_este_administrator" runat="server" CssClass="item_profil">
                <asp:Label ID="label_este_administrator_text" runat="server" Text="Este administrator ?">

                </asp:Label>

                <br />

                <asp:label ID="label_este_administrator" runat="server" Text="">

                </asp:label>
            </asp:Panel>

            <br />
            
            <asp:Button ID="actualizare_profil" runat="server" Text="Actualizeaza Profil" CssClass="item_profil" OnClick="actualizare_profil_Click"/>
        </asp:Panel>


    </asp:Panel>

</asp:Content>