<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Formular Facultate.aspx.cs" Inherits="Formular_Facultate" MasterPageFile="~/MasterPage.master" %>


<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link rel="stylesheet" runat="server" media="screen" href="/Resources/css/formFacultateStyles.css" />
    <link href='http://fonts.googleapis.com/css?family=Roboto:500' rel='stylesheet' type='text/css'>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/normalize/3.0.3/normalize.css" rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Droid+Sans' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic' rel='stylesheet' type='text/css'>
</asp:Content>


<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="main_container">
        <asp:Panel ID="formular" runat="server" CssClass="formular_facultate">

            <h4>Formular Facultate </h4>

            <div class="input_form_container">
                <div class="inputBoxContainers">
                    <asp:Label AssociatedControlID="nume_facultate" runat="server" CssClass="form_labels" Text="Nume" ></asp:Label>
                    <asp:TextBox ID="nume_facultate" runat="server" placeholder="Matematica-Informatica.." CssClass="nume_facultate_formular"></asp:TextBox>
                </div>
                <div class="inputBoxContainers">
                    <asp:Label AssociatedControlID="localitatea_facultatii" runat="server" CssClass="form_labels" Text="Localitate" ></asp:Label>
                    <asp:TextBox ID="localitatea_facultatii" runat="server" placeholder="Bucuresti.." CssClass="localitate_facultate_formular"></asp:TextBox>
                </div>

                <div class="inputBoxContainers">
                    <asp:Label AssociatedControlID="adresa_facultatii" runat="server" CssClass="form_labels" Text="Adresa" ></asp:Label>
                    <asp:TextBox ID="adresa_facultatii" TextMode="MultiLine" Rows="3"  placeholder="Ion Calin, nr 9.." runat="server" CssClass="adresa_facultate_formular"></asp:TextBox>
                     </div>
            
                <div class="inputBoxContainers">
                    <asp:Label AssociatedControlID="alte_informatii" runat="server" CssClass="form_labels" Text="Alte Info." ></asp:Label>
                    <asp:TextBox ID="alte_informatii"  TextMode="MultiLine" Rows="5" placeholder="banane..." runat="server" CssClass="alte_informatii_formular">
                    </asp:TextBox>
                     </div>
                <div class="inputBoxContainers">
                    <asp:Button ID="adauga_facultate" runat="server" Text="Creaza" CssClass="buton_adaugare" OnClick="adauga_facultate_Click" />
                </div>
                <div class="space_holder"></div>
                </div>
        </asp:Panel>
    </div>

</asp:Content>
