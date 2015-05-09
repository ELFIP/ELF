<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forma Test.aspx.cs" Inherits="Forma_Test" MasterPageFile="~/MasterPage.master"%>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
</asp:Content>

<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">
       <asp:Table ID="formular" runat="server" Width="80%" style="margin-left: 10%">
            <asp:TableHeaderRow Width="100%" >
                <asp:TableHeaderCell HorizontalAlign="Center" style="padding:10px" Width="50%">
                    <asp:Label ID="numeTest" runat="server" Text="" Width="50%">
                    </asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell HorizontalAlign="Center" style="padding:10px" Width="50%">
                    <asp:Label ID="numeCurs" runat="server" Text="" Width="50%">
                    </asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
           <asp:TableRow>
               <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                   
               </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                   <asp:RadioButtonList ID="RadioButtonList1" runat="server" HorizontalAlign="Center" AutoPostBack ="true" OnSelectedIndexChanged="selectare">
                       <asp:ListItem ID="id_nota1" runat="server" Text="1">

                       </asp:ListItem>
                       <asp:ListItem ID="id_nota2" runat="server" Text="2">

                       </asp:ListItem>
                       <asp:ListItem ID="id_nota3" runat="server" Text="3">

                       </asp:ListItem>
                       <asp:ListItem ID="id_nota4" runat="server" Text="4">

                       </asp:ListItem>
                       <asp:ListItem ID="id_nota5" runat="server" Text="5">

                       </asp:ListItem>
                   </asp:RadioButtonList>
               </asp:TableCell>
           </asp:TableRow>
        </asp:Table>
</asp:Content>
