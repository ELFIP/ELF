<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Formular Curs.aspx.cs" Inherits="Formular_Curs" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
</asp:Content>

<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Table ID="formular" runat="server" Width="80%" Style="margin-left: 10%">
        <asp:TableHeaderRow Width="100%">
            <asp:TableHeaderCell HorizontalAlign="Center" Style="padding: 10px" Width="20%">
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <br />
                <asp:Label ID="lbl_debug" runat="server" Text="" ForeColor="Red"></asp:Label>
                <hr />
                <asp:Image ID="imagine_curs" runat="server" Width="100px" Height="100px"/>
                <hr />
                <asp:Button ID="btnUpload" runat="server"  Text="Upload" OnClick="Upload" />
            </asp:TableHeaderCell>
            <asp:TableHeaderCell HorizontalAlign="Center" Style="padding: 10px">
                <asp:TextBox ID="numeCurs" runat="server" placeholder="Nume curs" Width="50%">
                </asp:TextBox>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell ID="alerta_nume" runat="server" Text="" ForeColor="Red" HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2">
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Width="100%">
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2">
                <asp:TextBox ID="despreCurs" TextMode="MultiLine" Rows="10" placeholder="Despre" runat="server" Width="100%">
                </asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Width="100%">
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2">
                <asp:Button ID="AdaugaCurs" runat="server" Text="Adauga Curs" HorizontalAlign="Center" OnClick="adauga_curs_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
