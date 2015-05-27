<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Schimba Parola.aspx.cs" Inherits="Schimba_Parola" MasterPageFile="MasterPage.master" %>

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

    <br />

    <asp:Panel ID="Link" runat="server" CssClass="profil-nav">
        <asp:HyperLink ID="HyperLink_profil" runat="server" NavigateUrl="Profil.aspx">Profil</asp:HyperLink>
        <asp:HyperLink ID="HyperLink_cursuri" runat="server" NavigateUrl="Cursuri_profil.aspx">Cursuri</asp:HyperLink>
        <asp:HyperLink ID="HyperLink_facultati" runat="server" NavigateUrl="Facultati_recomandate_profil.aspx">Facultati</asp:HyperLink>
        <asp:HyperLink ID="HyperLink_schimba_parola" runat="server" NavigateUrl="Schimba Parola.aspx">Schimba Parola</asp:HyperLink>
    </asp:Panel>

    <br />

    <asp:Panel ID="continut" runat="server" CssClass="continut">
        <br />
        <asp:Label ID="Msg" ForeColor="maroon" runat="server" />
        <table cellpadding="3" border="0">
            <tr>
                <td>Parola Veche:</td>
                <td>
                    <asp:TextBox ID="OldPasswordTextbox" runat="server" TextMode="Password" /></td>
                <td>
                    <asp:RequiredFieldValidator ID="OldPasswordRequiredValidator" runat="server"
                        ControlToValidate="OldPasswordTextbox" ForeColor="red"
                        Display="Static" ErrorMessage="*" /></td>
            </tr>
            <tr>
                <td>Parola noua:</td>
                <td>
                    <asp:TextBox ID="PasswordTextbox" runat="server" TextMode="Password" /></td>
                <td>
                    <asp:RequiredFieldValidator ID="PasswordRequiredValidator" runat="server"
                        ControlToValidate="PasswordTextbox" ForeColor="red"
                        Display="Static" ErrorMessage="*" /></td>
            </tr>
            <tr>
                <td>Confirma parola:</td>
                <td>
                    <asp:TextBox ID="PasswordConfirmTextbox" runat="server" TextMode="Password" /></td>
                <td>
                    <asp:RequiredFieldValidator ID="PasswordConfirmRequiredValidator" runat="server"
                        ControlToValidate="PasswordConfirmTextbox" ForeColor="red"
                        Display="Static" ErrorMessage="*" />
                    <asp:CompareValidator ID="PasswordConfirmCompareValidator" runat="server"
                        ControlToValidate="PasswordConfirmTextbox" ForeColor="red"
                        Display="Static" ControlToCompare="PasswordTextBox"
                        ErrorMessage="Campurile 'Parola noua' si 'Confirma parola' trebuie sa fie similare." />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="ChangePasswordButton" Text="Change Password"
                        runat="server" OnClick="ChangePasswordButton_Click" /></td>
            </tr>
        </table>
        <br />
    </asp:Panel>
</asp:Content>
