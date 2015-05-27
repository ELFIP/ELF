<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Understanding the Brain_administrator.aspx.cs" Inherits="Understanding_the_Brain_administrator" MasterPageFile="~/MasterPage.master" %>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link rel='stylesheet' type='text/css' href="/Resources/css/cursuri_each.css" />
</asp:Content>
<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">
   <asp:Table ID="forma" runat="server" Width="80%" Style="margin-left: 10%">
       <asp:TableHeaderRow >
           <asp:TableHeaderCell HorizontalAlign="Center" Style="padding: 10px">
               <asp:Image ID="imagine_curs" runat="server" ImageUrl="~/Imagini_cursuri/Understanding the Brain.jpg" Width="100px" Height="100px"/>
               <asp:Label ID="numeCurs" runat="server" Text="Understanding the Brain" Width="50%"></asp:Label>
           </asp:TableHeaderCell>
            <asp:TableHeaderCell HorizontalAlign="Center" Style="padding: 10px">
                <asp:Button ID="buton_inscrie" runat="server" Text="Inscrie-te" OnClick="inscrie_Click"/>
            </asp:TableHeaderCell>
       </asp:TableHeaderRow>
       <asp:TableRow>
           <asp:TableCell HorizontalAlign="Center" Style="padding: 10px">
               <asp:Label ID="despreCurs" TextMode="MultiLine" Rows="10" runat="server" Text="Understanding our brain mysteries ">
               </asp:Label>
           </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
           <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" BorderStyle="Solid" BorderColor="Black" BorderWidth="1px">
               <asp:Table ID="tabel_videoclipuri" runat="server" Width="100%">
                   <asp:TableHeaderRow Width="100%">
                       <asp:TableHeaderCell ID="id_videoclip" Text="Videoclipuri" Style="padding: 10px" Width="50%">
                       </asp:TableHeaderCell>
                       <asp:TableHeaderCell ID="id_media_notelor_videoclip" Text="Media notelor" Style="padding: 10px" Width="50%">
                       </asp:TableHeaderCell>
                       <asp:TableHeaderCell Text="" Style="padding: 10px" Width="20%">
                       </asp:TableHeaderCell>
                   </asp:TableHeaderRow>
                   <asp:TableRow>
                        <asp:TableCell ColumnSpan="3" HorizontalAlign="Center">
                            <asp:Button runat="server" Text="Adauga Videoclip" OnClick="adauga_videoclip_click"/>
                        </asp:TableCell>
                    </asp:TableRow>
               </asp:Table>
           </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
           <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" BorderStyle="Solid" BorderColor="Black" BorderWidth="1px">
               <asp:Table ID="tabel_teste" runat="server" Width="100%">
                   <asp:TableHeaderRow Width="100%">
                       <asp:TableHeaderCell ID="id_test" Text="Test" Style="padding: 10px" Width="50%">
                       </asp:TableHeaderCell>
                       <asp:TableHeaderCell ID="id_media_notelor_test" Text="Media notelor" Style="padding: 10px" Width="50%">
                       </asp:TableHeaderCell>
                       <asp:TableHeaderCell Text="" Style="padding: 10px" Width="20%">
                       </asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="3" HorizontalAlign="Center">
                            <asp:Button runat="server" Text="Adauga Test" OnClick="adauga_test_click"/>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
           </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
           <asp:TableCell HorizontalAlign="Center" Style="padding: 10px">
                <asp:HyperLink ID="hyperlink_adaugaReferinta" NavigateUrl="~/Formular Referinte Curs.aspx?nume_curs=Understanding the Brain" runat="server">Adauga Referinta</asp:HyperLink>
           </asp:TableCell>
       </asp:TableRow>
   </asp:Table>
</asp:Content>
