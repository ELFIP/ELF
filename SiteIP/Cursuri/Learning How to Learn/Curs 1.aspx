<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Curs 1.aspx.cs" Inherits="Curs_1" MasterPageFile="~/MasterPage.master"%>
 
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
</asp:Content>
 
<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">
       <asp:Table ID="formular" runat="server" Width="80%" style="margin-left: 10%">
            <asp:TableHeaderRow Width="100%">
                <asp:TableHeaderCell HorizontalAlign="Center" style="padding:10px" Width="50%">
                    <asp:Label ID="numeVideoclip" runat="server" Text="Curs 1" Width="50%">
                    </asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell HorizontalAlign="Center" style="padding:10px" Width="50%">
                    <asp:Label ID="numeCurs" runat="server" Text="Learning How to Learn" Width="50%">
                    </asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
           <asp:TableRow>
               <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                   <iframe ID="afiseaza" width="560" height="315" src="Curs 1.mp4" frameborder="0" allowfullscreen runat="server"></iframe>
               </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
                    <ContentTemplate>
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
                    </ContentTemplate>
                </asp:UpdatePanel>
               </asp:TableCell>
           </asp:TableRow>
        </asp:Table>
</asp:Content>

