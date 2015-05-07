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
               <asp:TableCell>
                   <asp:FileUpload ID="FileUpload1" runat="server" />
                   <asp:Button ID="buton_upload" runat="server" Text="Upload" OnClick="buton_upload_Click" />
                   <asp:Label ID="lbl_debug" runat="server" Text=""></asp:Label>
               </asp:TableCell>
           </asp:TableRow>
        </asp:Table>
</asp:Content>

