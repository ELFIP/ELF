<%@ Page Language='C#' AutoEventWireup='true' CodeFile='Facultatea de Stiinte Economice Sibiu.aspx.cs' Inherits='Facultatea_de_Stiinte_Economice_Sibiu' MasterPageFile='~/MasterPage.master'%>
 
<asp:Content runat='server' ID='Content1' ContentPlaceHolderID='head'>
</asp:Content>
<asp:Content runat='server' ID='content' ContentPlaceHolderID='ContentPlaceHolder1'>
    <asp:Table ID="formularFacultate" runat="server" Width="80%" Style="margin-left: 10%">
        <asp:TableRow Width="100%">
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="20%">
                <asp:Image ID="imagine_facultate" runat="server" Width="100px" Height="100px" ImageUrl="~/Imagini_facultati/Facultatea de Stiinte EconomiceSibiu.jpg" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="50%">
                <asp:Label ID="nume_facultate" runat="server" Text="Facultatea de Stiinte Economice" CssClass="nume_facultate_formular" Width="50%">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="30%">
                <asp:Label ID="localitatea_facultatii" runat="server" Text="Sibiu" Width="30%">
 
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="100%">
                <asp:Label ID="adresa_facultatii" TextMode="MultiLine" Rows="3" Text="Universitatea Lucian Blaga, Calea Dumbravii nr.17" runat="server"  Width="100%">
 
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="100%">
                <asp:Label ID="alte_informatii" TextMode="MultiLine" Rows="5" Text="Facultatea de Stiinte Economice pregateste specialisti in toate ramurile profilului economic, absolventii 

nostri fiind apreciati in tara si strainatate. Plecand de la premisa ca cunoasterea, cultura, 

spiritualitatea etc. sunt elemente-cheie ale dezvoltarii umane, facultatea noastra are ca obiectiv strategic 

formarea studentilor in spiritul independentei in gandire, cultivarii valorilor autentice si nu in ultimul 

rand, interpretarii critice a lumii si societatii.  Totodata, manifestand permanenta preocupare pentru 

consolidarea prestigiului academic al institutiei, cadrele didactice ale facultatii participa la proiecte de 

cercetare in colaborare cu companii si institutii locale (inclusiv cu Biblioteca Centrala Universitara din 

Sibiu), implicandu-se activ in procesul integrarii europene a Romaniei in general, a dezvoltarii economice 

regionale in particular. 

http://economice.ulbsibiu.ro/index.php/ro/" runat="server" Width="100%">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
