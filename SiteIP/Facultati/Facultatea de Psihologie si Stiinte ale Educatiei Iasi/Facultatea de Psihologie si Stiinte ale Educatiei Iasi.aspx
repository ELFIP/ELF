<%@ Page Language='C#' AutoEventWireup='true' CodeFile='Facultatea de Psihologie si Stiinte ale Educatiei Iasi.aspx.cs' Inherits='Facultatea_de_Psihologie_si_Stiinte_ale_Educatiei_Iasi' MasterPageFile='~/MasterPage.master'%>
 
<asp:Content runat='server' ID='Content1' ContentPlaceHolderID='head'>
</asp:Content>
<asp:Content runat='server' ID='content' ContentPlaceHolderID='ContentPlaceHolder1'>
    <asp:Table ID="formularFacultate" runat="server" Width="80%" Style="margin-left: 10%">
        <asp:TableRow Width="100%">
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="20%">
                <asp:Image ID="imagine_facultate" runat="server" Width="100px" Height="100px" ImageUrl="~/Imagini_facultati/Facultatea de Psihologie si Stiinte ale EducatieiIasi.JPG" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="50%">
                <asp:Label ID="nume_facultate" runat="server" Text="Facultatea de Psihologie si Stiinte ale Educatiei" CssClass="nume_facultate_formular" Width="50%">
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
                <asp:Label ID="adresa_facultatii" TextMode="MultiLine" Rows="3" Text="Universitatea Alexandru Ioan Cuza, Strada Toma Cozma 3
" runat="server"  Width="100%">
 
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="100%">
                <asp:Label ID="alte_informatii" TextMode="MultiLine" Rows="5" Text="In anul 1997 Facultatea de Psihologie si Stiinte ale Educatiei s-a infiintat ca facultate de sine 

statatoare, prin separarea de Facultatea de Filosofie. Aceasta separare a fost un proces reparator, pentru 

compensarea absentei acestei specializari din perioada 1978-1989, cand facultatile de profil din toata tara 

au fost desfiintate. A fost si un act necesar, atat epistemologic cat si administrativ. Anual, cel putin 

1500 de tineri bat la portile facultatii noastre.

Misiunea facultatii noastre este de a pregati specialisti de performanta in domeniile Psihologiei si 

Stiintelor educatiei, care sa contribuie la dezvoltarea societatii romanesti, in contextul integrarii tarii 

noastre in Comunitatea Europeana. Oferta academica este orientata catre invatamantul de excelenta, prin 

stabilirea unor standarde didactice si de cercetare la nivelul celor mai prestigioase facultati de profil 

din tara si strainatate.

http://www.psih.uaic.ro/" runat="server" Width="100%">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
