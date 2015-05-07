<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Formular Videoclip.aspx.cs" Inherits="Formular_Videoclip" MasterPageFile="~/MasterPage.master"%>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
</asp:Content>

<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">
       <asp:Table ID="formular" runat="server" Width="80%" style="margin-left: 10%">
            <asp:TableHeaderRow Width="100%" >
                <asp:TableHeaderCell HorizontalAlign="Center" style="padding:10px">
                    <asp:TextBox ID="numeVideoclip" runat="server" placeholder="Nume videoclip" Width="50%">
                    </asp:TextBox>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
           <asp:TableRow>
               <asp:TableCell HorizontalAlign="Center">
                   <asp:FileUpload ID="FileUpload1" runat="server" />
                   <asp:Button ID="buton_upload" runat="server" Text="Upload" OnClick="buton_upload_Click" />
                   <asp:Label ID="lbl_debug" runat="server" Text=""></asp:Label>
               </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell HorizontalAlign="Center">
                   <iframe width="560" ID="afiseaza" height="315" src="" frameborder="0" allowfullscreen runat="server"></iframe>
               </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell HorizontalAlign="Center">
                   <asp:Button ID="creaza_pagina_video" runat="server" Text="Creeaza Pagina" OnClick="buton_creeaza_Click"/>
               </asp:TableCell>
           </asp:TableRow>
        </asp:Table>
</asp:Content>

