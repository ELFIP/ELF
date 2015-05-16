<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Formular Test.aspx.cs" Inherits="Forma_Test" MasterPageFile="~/MasterPage.master"%>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
</asp:Content>

<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">
       <asp:Table ID="tabel_generare" runat="server" Width="80%" style="margin-left: 10%">
            <asp:TableHeaderRow Width="100%" >
                <asp:TableHeaderCell HorizontalAlign="Center" style="padding:10px" Width="50%">
                    <asp:TextBox ID="numeTest" runat="server" placeholder="Nume test" Width="50%">
                    </asp:TextBox>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell HorizontalAlign="Center" style="padding:10px" Width="50%">
                    <asp:TextBox ID="timpTest" runat="server" placeholder="Timp(minute)" Width="50%">
                    </asp:TextBox>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
           <asp:TableRow>
               <asp:TableCell HorizontalAlign="Center" style="padding:10px" Width="50%">
                   <asp:TextBox ID="numarIntrebari" runat="server" placeholder="Numar Intrebari" Width="50%">
                   </asp:TextBox>
               </asp:TableCell>
               <asp:TableCell HorizontalAlign="Center" style="padding:10px" Width="50%">
                   <asp:Button ID="buton_genereazaIntrebari" runat="server" Text="Genereaza Intrebari" OnClick="genereazaIntrebari" Width="50%"/>
               </asp:TableCell>
           </asp:TableRow>
        </asp:Table>
</asp:Content>
