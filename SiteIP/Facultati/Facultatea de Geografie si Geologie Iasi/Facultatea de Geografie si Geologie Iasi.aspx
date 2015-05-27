<%@ Page Language='C#' AutoEventWireup='true' CodeFile='Facultatea de Geografie si Geologie Iasi.aspx.cs' Inherits='Facultatea_de_Geografie_si_Geologie_Iasi' MasterPageFile='~/MasterPage.master'%>
 
<asp:Content runat='server' ID='Content1' ContentPlaceHolderID='head'>
    <link rel='stylesheet' type='text/css' href="/Resources/css/facultati_each.css" />
</asp:Content>
<asp:Content runat='server' ID='content' ContentPlaceHolderID='ContentPlaceHolder1'>
    <asp:Table ID="formularFacultate" runat="server" Width="80%" Style="margin-left: 10%">
        <asp:TableRow Width="100%">
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="20%">
                <asp:Image ID="imagine_facultate" runat="server" Width="100px" Height="100px" ImageUrl="~/Imagini_facultati/Facultatea de Geografie si GeologieIasi.jpg" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="50%">
                <asp:Label ID="nume_facultate" runat="server" Text="Facultatea de Geografie si Geologie" CssClass="nume_facultate_formular" Width="50%">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="30%">
                <asp:Label ID="localitatea_facultatii" runat="server" Text="Iasi" Width="30%">
 
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="100%">
                <asp:Label ID="adresa_facultatii" TextMode="MultiLine" Rows="3" Text="Universitatea Alexandru Ioan Cuza, Corpul B, Bulevardul Carol I 20A" runat="server"  Width="100%">
 
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="100%">
                <asp:Label ID="alte_informatii" TextMode="MultiLine" Rows="5" Text="Misiunea facultatii implica doua componente de baza: una didactica si una stiintifica, fiind diferentiata in functie de specializarea urmata de student. In ansamblu, Facultatea de Geografie si Geologie isi propune:

    Sa pregateasca specialisti in domeniul geologie (licentiati in geologie) si in domeniul inginerie geologica (ingineri geologi) prin programe de invatamant adaptate necesitatilor domeniilor de interes national si international, in concordanta cu normele de integrare europeana.
    Sa promoveze un invatamant geologic si geochimic de inalta calitate, prin adaptarea continua a strategiei pe termen scurt, a programelor analitice ale disciplinelor, a tematicii de cercetare, a criteriilor de evaluare a cadrelor didactice, pentru a fi in concordanta cu standardele de calitate impuse de organismele nationale sau internationale.
	
	http://www.geo.uaic.ro/ro/" runat="server" Width="100%">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
