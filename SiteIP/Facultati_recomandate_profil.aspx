<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Facultati_recomandate_profil.aspx.cs" Inherits="Facultati_recomandate_profil" MasterPageFile="MasterPage.master"%>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link rel='stylesheet' type='text/css' href="/Resources/css/PaginaDeProfil.css" />
    <link rel='stylesheet' type='text/css' href="/Resources/Master_layout_style.css" />
    <link href="http://fonts.googleapis.com/css?family=Open+Sans" rel="stylesheet" type="text/css">

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
    
    <asp:Panel ID="Link" runat="server" CssClass="profil-nav">
        <asp:HyperLink ID="HyperLink_profil" runat="server" NavigateUrl="Profil.aspx">Profil</asp:HyperLink>
        <asp:HyperLink ID="HyperLink_cursuri" runat="server" NavigateUrl="Cursuri_profil.aspx">Cursuri</asp:HyperLink>
        <asp:HyperLink ID="HyperLink_facultati" runat="server" NavigateUrl="Facultati_recomandate_profil.aspx">Facultati</asp:HyperLink>
        <asp:HyperLink ID="HyperLink_schimba_parola" runat="server" NavigateUrl="Schimba Parola.aspx">Schimba Parola</asp:HyperLink>
    </asp:Panel>
    
    <br />
    
    <asp:Table ID="tabel_facultati_recomandate" runat="server" Width="80%" style="margin-left: 10%">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell Text="Facultati Recomandate" HorizontalAlign="Center">

            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>

    <asp:Panel ID="continut" runat="server">

        <div class="aux">
            <dropdown>
                <input id="toggle2" type="checkbox">
                    <label for="toggle2" class="animate">Facultati</label>
                    <asp:BulletedList ID="BulletedList1" runat="server" DataTextField="nume" DataValueField="nume" DataSourceID="SqlDataSource1" CssClass="animate">
                    </asp:BulletedList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT nume FROM Facultate AS f WHERE (id_facultate = (SELECT id_facultate FROM Utilizator_Facultate AS uf WHERE (id_facultate = f.id_facultate) AND (uf.id_utilizator = (SELECT id_utilizator FROM Utilizator WHERE (email = @uem)))))">
                        <SelectParameters>
                            <asp:SessionParameter Name="uem" SessionField="email" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </input>
            </dropdown> 
        </div>

    </asp:Panel>
</asp:Content>
