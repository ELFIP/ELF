<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Astronomical Discovery.aspx.cs" Inherits="Astronomical_Discovery" MasterPageFile="~/MasterPage.master" %>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link rel='stylesheet' type='text/css' href="/Resources/css/cursuri_each.css" />
</asp:Content>
<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">
 
   <asp:Table ID="forma" runat="server" Width="80%" Style="margin-left: 10%">
       <asp:TableHeaderRow Width="100%">
           <asp:TableHeaderCell HorizontalAlign="Center" Style="padding: 10px">
               <asp:Image ID="imagine_curs" runat="server" ImageUrl="~/Imagini_cursuri/Astronomical Discovery.jpg" Width="100px" Height="100px"/>
               <asp:Label ID="numeCurs" runat="server" Text="Astronomical Discovery" Width="50%"></asp:Label>
           </asp:TableHeaderCell>
            <asp:TableHeaderCell HorizontalAlign="Center" Style="padding: 10px">
                <asp:Button ID="buton_inscrie" runat="server" Text="Inscrie-te" OnClick="inscrie_Click"/>
            </asp:TableHeaderCell>
       </asp:TableHeaderRow>
       <asp:TableRow Width="100%">
           <asp:TableCell HorizontalAlign="Center" Style="padding: 10px">
               <asp:Label ID="despreCurs" TextMode="MultiLine" Rows="10" runat="server" Text="The Science and Technology behind Astronomical Discovery">
               </asp:Label>
           </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow Width="100%">
           <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" BorderStyle="Solid" BorderColor="Black" BorderWidth="1px">
               <asp:Table ID="tabel_videoclipuri" runat="server" Width="100%">
                   <asp:TableHeaderRow Width="100%">
                       <asp:TableHeaderCell ID="id_videoclip" Text="Videoclipuri" Style="padding: 10px" Width="50%">
                       </asp:TableHeaderCell>
                       <asp:TableHeaderCell ID="id_media_notelor_videoclip" Text="Media notelor" Style="padding: 10px" Width="50%">
                       </asp:TableHeaderCell>
                   </asp:TableHeaderRow>
                   <asp:TableRow>
                       <asp:TableCell ID="videoclipuri">
                       </asp:TableCell>
                   </asp:TableRow>
               </asp:Table>
           </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow Width="100%" >
           <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" BorderStyle="Solid" BorderColor="Black" BorderWidth="1px">
               <asp:Table ID="tabel_teste" runat="server" Width="100%">
                   <asp:TableHeaderRow Width="100%">
                       <asp:TableHeaderCell ID="id_test" Text="Test" Style="padding: 10px" Width="50%">
                       </asp:TableHeaderCell>
                       <asp:TableHeaderCell ID="id_media_notelor_test" Text="Media notelor" Style="padding: 10px" Width="50%">
                       </asp:TableHeaderCell>
                       </asp:TableHeaderRow>
                       <asp:TableRow>
                           <asp:TableCell ID="Teste">
                           </asp:TableCell>
                       </asp:TableRow>
                   </asp:Table>
           </asp:TableCell>
       </asp:TableRow>
   </asp:Table>
</asp:Content>
