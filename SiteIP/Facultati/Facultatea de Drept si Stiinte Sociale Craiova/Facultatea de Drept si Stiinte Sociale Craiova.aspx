<%@ Page Language='C#' AutoEventWireup='true' CodeFile='Facultatea de Drept si Stiinte Sociale Craiova.aspx.cs' Inherits='Facultatea_de_Drept_si_Stiinte_Sociale_Craiova' MasterPageFile='~/MasterPage.master'%>
 
<asp:Content runat='server' ID='Content1' ContentPlaceHolderID='head'>
    <link rel='stylesheet' type='text/css' href="/Resources/css/facultati_each.css" />
</asp:Content>
<asp:Content runat='server' ID='content' ContentPlaceHolderID='ContentPlaceHolder1'>
    <asp:Table ID="formularFacultate" runat="server" Width="80%" Style="margin-left: 10%">
        <asp:TableRow Width="100%">
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="20%">
                <asp:Image ID="imagine_facultate" runat="server" Width="100px" Height="100px" ImageUrl="~/Imagini_facultati/Facultatea de Drept si Stiinte SocialeCraiova.JPG" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="50%">
                <asp:Label ID="nume_facultate" runat="server" Text="Facultatea de Drept si Stiinte Sociale" CssClass="nume_facultate_formular" Width="50%">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="30%">
                <asp:Label ID="localitatea_facultatii" runat="server" Text="Craiova" Width="30%">
 
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="100%">
                <asp:Label ID="adresa_facultatii" TextMode="MultiLine" Rows="3" Text="Str. Calea Bucuresti nr.107D" runat="server"  Width="100%">
 
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="100%">
                <asp:Label ID="alte_informatii" TextMode="MultiLine" Rows="5" Text="Infiintarea unei facultati de drept la Craiova, in inima Olteniei, a fost un vis vechi al locuitorilor 
acestor meleaguri din randul carora s-au ridicat personalitati ilustre ale dreptului romanesc, precum 
logofatul Nestor Craiovescu - primul profesor roman de drept si principal autor al Legiuirii Caragea, 
Nicolae Titulescu - academician, profesor universitar, cel mai mare diplomat roman, Valentin Al. Georgescu - 
academician, profesor universitar, cel mai valoros romanist si istoric al dreptului romanesc, Ion P. 
Filipescu - academician, profesor universitar, reputat specialist in dreptul familiei si dreptul 
international privat, Nicolae Mateescu Matte - academician, profesor universitar, pionier al dreptului
international aerian si parinte al dreptului spatial.

drept.ucv.ro/" runat="server" Width="100%">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
