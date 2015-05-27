<%@ Page Language='C#' AutoEventWireup='true' CodeFile='Facultatea de Fizica Bucuresti.aspx.cs' Inherits='Facultatea_de_Fizica_Bucuresti' MasterPageFile='~/MasterPage.master'%>
 
<asp:Content runat='server' ID='Content1' ContentPlaceHolderID='head'>
    <link rel='stylesheet' type='text/css' href="/Resources/css/facultati_each.css" />
</asp:Content>
<asp:Content runat='server' ID='content' ContentPlaceHolderID='ContentPlaceHolder1'>
    <asp:Table ID="formularFacultate" runat="server" Width="80%" Style="margin-left: 10%">
        <asp:TableRow Width="100%">
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="20%">
                <asp:Image ID="imagine_facultate" runat="server" Width="100px" Height="100px" ImageUrl="~/Imagini_facultati/Facultatea de FizicaBucuresti.jpg" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="50%">
                <asp:Label ID="nume_facultate" runat="server" Text="Facultatea de Fizica" CssClass="nume_facultate_formular" Width="50%">
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
                <asp:Label ID="adresa_facultatii" TextMode="MultiLine" Rows="3" Text="Universitatea Din Bucuresti, Strada Atomistilor 405, Magurele" runat="server"  Width="100%">
 
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="100%">
                <asp:Label ID="alte_informatii" TextMode="MultiLine" Rows="5" Text="Facultatea de Fizica dispune in acest moment de infrastructura necesara desfasurarii in bune conditii a activitatii de invatamant si cercetare. De asemenea exista o preocupare continua pentru dezvoltarea acestei infrastructuri.

Intreaga activitate didactica de formare-specializare si de cercetare stiintifica se desfasoara in cadrul celor 3 departamente ale facultatii.
Biblioteca Facultatii de Fizica ocupa un spatiu larg in cladire, cu sala mare de lectura, sala de imprumut, de documentare si depozite.
Este dotata cu carti, manuale (peste 105.000 volume) si un bogat depozit de reviste stiintifice.
Biblioteca asigura documentarea stiintifica pentru studenti si cadre didactice. Din anul 2000 biblioteca dispune de o sectie de imprumut informatizata, si in prezent se fac eforturi pentru informatizarea completa. 

http://www.fizica.unibuc.ro/Fizica/Main.php" runat="server" Width="100%">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
