<%@ Page Language='C#' AutoEventWireup='true' CodeFile='Facultatea de Stiinte Socio Umane Oradea.aspx.cs' Inherits='Facultatea_de_Stiinte_Socio_Umane_Oradea' MasterPageFile='~/MasterPage.master'%>
 
<asp:Content runat='server' ID='Content1' ContentPlaceHolderID='head'>
    <link rel='stylesheet' type='text/css' href="/Resources/css/facultati_each.css" />
</asp:Content>
<asp:Content runat='server' ID='content' ContentPlaceHolderID='ContentPlaceHolder1'>
    <asp:Table ID="formularFacultate" runat="server" Width="80%" Style="margin-left: 10%">
        <asp:TableRow Width="100%">
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="20%">
                <asp:Image ID="imagine_facultate" runat="server" Width="100px" Height="100px" ImageUrl="~/Imagini_facultati/Facultatea de Stiinte Socio-umaneOradea.jpg" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="50%">
                <asp:Label ID="nume_facultate" runat="server" Text="Facultatea de Stiinte Socio Umane" CssClass="nume_facultate_formular" Width="50%">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="30%">
                <asp:Label ID="localitatea_facultatii" runat="server" Text="Oradea" Width="30%">
 
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="100%">
                <asp:Label ID="adresa_facultatii" TextMode="MultiLine" Rows="3" Text="Universitatea din Oradea, Str. Universitatii nr.1" runat="server"  Width="100%">
 
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="100%">
                <asp:Label ID="alte_informatii" TextMode="MultiLine" Rows="5" Text="Procesul de pregatire a specialistilor din domeniile specifice facultatii noastre este astfel conceput incat 

sa fie in concordanta cu prevederile Cadrului national al calificarilor din Romania.    
Oricare dintre specializarile existente in facultatea noastra va ofera posibilitatea dezvoltarii propriei 

personalitati, atat in plan profesional, cat si in cel al valorificarii disponibilitatilor individuale, a 

aptitudinilor si capacitatilor de care dispuneti, prin numeroasele si interesantele activitati 

extracurriculare care sunt organizate: cercuri studentesti orientate spre cercetare, grupuri corale si de 

arta plastica, activitati de voluntariat etc. 

http://www.socioumane.ro/" runat="server" Width="100%">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
