<%@ Page Language='C#' AutoEventWireup='true' CodeFile='Facultatea de Muzica Brasov.aspx.cs' Inherits='Facultatea_de_Muzica_Brasov' MasterPageFile='~/MasterPage.master'%>
 
<asp:Content runat='server' ID='Content1' ContentPlaceHolderID='head'>
    <link rel='stylesheet' type='text/css' href="/Resources/css/facultati_each.css" />
</asp:Content>
<asp:Content runat='server' ID='content' ContentPlaceHolderID='ContentPlaceHolder1'>
    <asp:Table ID="formularFacultate" runat="server" Width="80%" Style="margin-left: 10%">
        <asp:TableRow Width="100%">
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="20%">
                <asp:Image ID="imagine_facultate" runat="server" Width="100px" Height="100px" ImageUrl="~/Imagini_facultati/Facultatea de MuzicaBrasov.JPG" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="50%">
                <asp:Label ID="nume_facultate" runat="server" Text="Facultatea de Muzica" CssClass="nume_facultate_formular" Width="50%">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="30%">
                <asp:Label ID="localitatea_facultatii" runat="server" Text="Brasov" Width="30%">
 
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="100%">
                <asp:Label ID="adresa_facultatii" TextMode="MultiLine" Rows="3" Text="Universitatea Transilvania, Corpul Z, Sirul Mitropolit Andrei Saguna 2" runat="server"  Width="100%">
 
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="100%">
                <asp:Label ID="alte_informatii" TextMode="MultiLine" Rows="5" Text="Facultatea de Muzica promoveaza cadre didactice tinere, valori?cand excelenta cadrelor didactice cu 

experienta, admite doar promovarea pe criterii de performanta, sustine mobilitatea cadrelor didactice si a 

studentilor, sprijinind programele de schimb interuniversitare, perfectionarea personalului tehnic si 

administrativ.
Initierea unor noi programe de studiu, planificarea, monitorizarea si evaluarea periodica a calitatii lor se 

realizeaza in mod sistematic, iar stabilirea programelor de studiu se realizeaza in functie de valorile 

universale ale pregatirii muzicale, precum si in functie de necesitatile actuale locale.

http://www.unitbv.ro/Default.aspx?alias=www.unitbv.ro/muzica&" runat="server" Width="100%">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
