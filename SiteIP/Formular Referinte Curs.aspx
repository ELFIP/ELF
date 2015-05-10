<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Formular Referinte Curs.aspx.cs" Inherits="Formular_Referinte_Curs" MasterPageFile="~/MasterPage.master"%>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
</asp:Content>

<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">
       <asp:Table ID="formular" runat="server" Width="80%" style="margin-left: 10%">
            <asp:TableHeaderRow Width="100%" >
                <asp:TableHeaderCell HorizontalAlign="Center" style="padding:10px">
                    <asp:Label ID="numeFacultate" runat="server" Text="Facultate" Width="50%">
                    </asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell HorizontalAlign="Center" style="padding:10px">
                    <asp:Label ID="numeTaguri" runat="server" Text="Tag" Width="50%">
                    </asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
           <asp:TableRow>
               <asp:TableCell ID="tabel_facultati_taguri" runat="server" HorizontalAlign="Center" style="padding:10px" ColumnSpan="2">
               </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow Width="100%">
               <asp:TableCell HorizontalAlign="Center" style="padding:10px" ColumnSpan="2">
                   <asp:Button ID="AdaugaReferinte" runat="server" Text="Adauga Referinte" HorizontalAlign="Center" OnClick="adauga_referinte_Click"/>
               </asp:TableCell>
           </asp:TableRow>
        </asp:Table>
</asp:Content>
