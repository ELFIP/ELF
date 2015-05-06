<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Formular Curs.aspx.cs" Inherits="Formular_Curs" MasterPageFile="~/MasterPage.master"%>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
</asp:Content>

<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">

       <asp:Table ID="formular" runat="server" Width="80%" style="margin-left: 10%">
            <asp:TableHeaderRow Width="100%" >
                <asp:TableHeaderCell HorizontalAlign="Center" style="padding:10px">
                    <asp:TextBox ID="numeCurs" runat="server" placeholder="Nume curs" Width="50%">

                    </asp:TextBox>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow Width="100%">
                <asp:TableCell HorizontalAlign="Center" style="padding:10px">
                    <asp:TextBox ID="despreCurs" TextMode="MultiLine" Rows="10" placeholder="Despre" runat="server" Width="80%">
                    </asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow Width="100%">
               <asp:TableCell HorizontalAlign="Center" style="padding:10px">
                   <asp:Button ID="AdaugaCurs" runat="server" Text="Adauga Curs" HorizontalAlign="Center" OnClick="adauga_curs_Click"/>
               </asp:TableCell>
           </asp:TableRow>
        </asp:Table>

</asp:Content>
