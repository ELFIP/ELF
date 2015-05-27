<%@ Page Language='C#' AutoEventWireup='true' CodeFile='UNATC I L Caragiale Bucuresti.aspx.cs' Inherits='UNATC_I_L_Caragiale_Bucuresti' MasterPageFile='~/MasterPage.master'%>
 
<asp:Content runat='server' ID='Content1' ContentPlaceHolderID='head'>
    <link rel='stylesheet' type='text/css' href="/Resources/css/facultati_each.css" />
</asp:Content>
<asp:Content runat='server' ID='content' ContentPlaceHolderID='ContentPlaceHolder1'>
    <asp:Table ID="formularFacultate" runat="server" Width="80%" Style="margin-left: 10%">
        <asp:TableRow Width="100%">
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="20%">
                <asp:Image ID="imagine_facultate" runat="server" Width="100px" Height="100px" ImageUrl="~/Imagini_facultati/UNATC I L CaragialeBucuresti.jpg" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="50%">
                <asp:Label ID="nume_facultate" runat="server" Text="UNATC I L Caragiale" CssClass="nume_facultate_formular" Width="50%">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="30%">
                <asp:Label ID="localitatea_facultatii" runat="server" Text="Bucuresti" Width="30%">
 
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="100%">
                <asp:Label ID="adresa_facultatii" TextMode="MultiLine" Rows="3" Text="Strada Matei Voievod 75-77" runat="server"  Width="100%">
 
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="100%">
                <asp:Label ID="alte_informatii" TextMode="MultiLine" Rows="5" Text="Credem in cinema ca arta care poate sintetiza timpurile noastre mai bine decat oricare alta, in puterea sa de a reconfigura comunicarea asa cum o stim, de a re-forma cultura globala si trairile individuale.Conceptul definitoriu al Facultatii de Film este lucrul in echipa. Filmul este vazut ca produsul rezultat din unirea creativa a energiilor diverselor compartimente.UNATC, prin Facultatea de Film este membru titular al CILECT si GEECT.

Aproape toate numele importante ale cinematografiei romanesti au trecut prin aceasta institutie care combina traditia cu inovatia, experimentul cu cercetarea.

http://unatc.ro/film/index.php" runat="server" Width="100%">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
