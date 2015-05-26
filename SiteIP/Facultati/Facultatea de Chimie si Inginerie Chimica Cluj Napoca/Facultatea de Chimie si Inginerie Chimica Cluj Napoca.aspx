<%@ Page Language='C#' AutoEventWireup='true' CodeFile='Facultatea de Chimie si Inginerie Chimica Cluj Napoca.aspx.cs' Inherits='Facultatea_de_Chimie_si_Inginerie_Chimica_Cluj_Napoca' MasterPageFile='~/MasterPage.master'%>
 
<asp:Content runat='server' ID='Content1' ContentPlaceHolderID='head'>
</asp:Content>
<asp:Content runat='server' ID='content' ContentPlaceHolderID='ContentPlaceHolder1'>
    <asp:Table ID="formularFacultate" runat="server" Width="80%" Style="margin-left: 10%">
        <asp:TableRow Width="100%">
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="20%">
                <asp:Image ID="imagine_facultate" runat="server" Width="100px" Height="100px" ImageUrl="~/Imagini_facultati/Facultatea de Chimie si Inginerie ChimicaCluj Napoca.jpg" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="50%">
                <asp:Label ID="nume_facultate" runat="server" Text="Facultatea de Chimie si Inginerie Chimica" CssClass="nume_facultate_formular" Width="50%">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="30%">
                <asp:Label ID="localitatea_facultatii" runat="server" Text="Cluj Napoca" Width="30%">
 
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="100%">
                <asp:Label ID="adresa_facultatii" TextMode="MultiLine" Rows="3" Text="Universitatea Babes-Bolyai, Strada Arany Janos 11" runat="server"  Width="100%">
 
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="100%">
                <asp:Label ID="alte_informatii" TextMode="MultiLine" Rows="5" Text="Absolventii ingineri chimisti se pot valida profesional la toate nivelele unei societati comerciale de tip 

Industrial sau Intreprindere Mica si Mijlocie: furnizarea si pregatirea materiilor prime, fazele de 

productie, analiza si asigurarea calitatii produselor, ambalarea, vanzarea, cercetare-dezvoltare, protectia 

mediului si managementul societatii. Angajatori din industriile chimica, petrochimica, a materialelor de 

constructii, alimentara, de produse cosmetice, auto, dar si din productia de materiale speciale, 

bioinginerie, biomedicina si ingineria genetica sunt interesati sa utilizeze competentele dobandite de 

inginerii chimisti ai Facultatii noastre. 

http://chem.ubbcluj.ro/" runat="server" Width="100%">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
