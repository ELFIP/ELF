<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Formular Facultate.aspx.cs" Inherits="Formular_Facultate" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/normalize/3.0.3/normalize.css" rel='stylesheet' type='text/css' />
    <link href="Resources/css/globalStyle.css" rel="stylesheet" type="text/css" />
    <link href="Resources/css/formFacultateStyles.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Roboto:500' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Droid+Sans' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic' rel='stylesheet' type='text/css' />
</asp:Content>

<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">

    <asp:Table ID="formularFacultate" runat="server" Width="80%" Style="margin-left: 10%">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell HorizontalAlign="Center" Style="padding: 10px" Text="Formular Facultate" ColumnSpan="2">
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow Width="100%">
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="20%">
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <br />
                <asp:Label ID="lbl_debug" runat="server" Text="" ForeColor="Red"></asp:Label>
                <hr />
                <asp:Image ID="imagine_facultate" runat="server" Width="100px" Height="100px" />
                <hr />
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="50%">
                <asp:TextBox ID="nume_facultate" runat="server" placeholder="Nume Facultate" CssClass="nume_facultate_formular" Width="50%">
                </asp:TextBox>
                <br />
                <asp:Label ID="alerta_nume" runat="server" Text="" ForeColor="Red" HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="30%">
                <asp:TextBox ID="localitatea_facultatii" runat="server" placeholder="Localitate" Width="30%">

                </asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="100%">
                <asp:TextBox ID="adresa_facultatii" TextMode="MultiLine" Rows="3" placeholder="Adresa" runat="server"  Width="100%">

                </asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="100%">
                <asp:TextBox ID="alte_informatii" TextMode="MultiLine" Rows="5" placeholder="Alte informatii" runat="server" Width="100%">
                </asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Width="100%">
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2">
                <asp:Button ID="adauga_facultate" runat="server" Text="Creaza" CssClass="buaton" OnClick="adauga_facultate_Click" Width="20%"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

</asp:Content>
