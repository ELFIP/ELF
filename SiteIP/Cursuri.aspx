<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cursuri.aspx.cs" Inherits="Cursuri" MasterPageFile="MasterPage.master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">
        <asp:Table ID="tabel_continut" runat="server" Width="80%" style="margin-left: 10%">
            <asp:TableHeaderRow Width="100%" >
                <asp:TableHeaderCell style="padding:5px">

                </asp:TableHeaderCell>
                <asp:TableHeaderCell style="padding:5px">
                    <asp:TextBox ID="cauta_curs" runat="server" placeholder="Cauta curs" Width="30%" AutoPostBack="false">

                    </asp:TextBox>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow Width="100%">
                <asp:TableCell Width="20%">
                    <asp:Table ID="tabel_checkbox" runat="server" HorizontalAlign="Center" style="padding:5px">

                    </asp:Table>
                </asp:TableCell>

                <asp:TableCell Width="80%">
                    <asp:Table ID="tabel_cursuri" runat="server" HorizontalAlign="Center" style="padding:5px">

                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                    <asp:HyperLink ID="hyperlink_adaugaCurs" NavigateUrl="Formular Curs.aspx" runat="server">Adauga Curs</asp:HyperLink>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
</asp:Content>
