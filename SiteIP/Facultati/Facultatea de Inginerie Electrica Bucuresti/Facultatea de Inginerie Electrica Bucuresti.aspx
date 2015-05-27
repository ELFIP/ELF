<%@ Page Language='C#' AutoEventWireup='true' CodeFile='Facultatea de Inginerie Electrica Bucuresti.aspx.cs' Inherits='Facultatea_de_Inginerie_Electrica_Bucuresti' MasterPageFile='~/MasterPage.master'%>
 
<asp:Content runat='server' ID='Content1' ContentPlaceHolderID='head'>
    <link rel='stylesheet' type='text/css' href="/Resources/css/facultati_each.css" />
</asp:Content>
<asp:Content runat='server' ID='content' ContentPlaceHolderID='ContentPlaceHolder1'>
    <asp:Table ID="formularFacultate" runat="server" Width="80%" Style="margin-left: 10%">
        <asp:TableRow Width="100%">
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="20%">
                <asp:Image ID="imagine_facultate" runat="server" Width="100px" Height="100px" ImageUrl="~/Imagini_facultati/Facultatea de Inginerie ElectricaBucuresti.jpg" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="50%">
                <asp:Label ID="nume_facultate" runat="server" Text="Facultatea de Inginerie Electrica" CssClass="nume_facultate_formular" Width="50%">
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
                <asp:Label ID="adresa_facultatii" TextMode="MultiLine" Rows="3" Text="Campusul Politehnicii, Sector 6" runat="server"  Width="100%">
 
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="100%">
                <asp:Label ID="alte_informatii" TextMode="MultiLine" Rows="5" Text="Facultatea de Inginerie Electrica, prin programele sale de studiu, raspunde necesitatilor pietei muncii de la noi din tara si evolutiei generale a acestei piete, punctele forte ale facultatii fiind: conceptia diversificata a ofertei curriculare la nivelul studiilor de licenta, programe de master cu caracter de aprofundare, corp profesoral caracterizat prin competenta ridicata, cercetare stiintifica fundamentala si aplicativa de nivel inalt, baza materiala in continua modernizare, integrarea in aria europeana a educatiei si cercetarii.

Facultatea are o baza materiala importanta, realizata in principal prin programe europene, programe si granturi de cercetare nationale si prin fonduri de investitii de la bugetul de stat, dispunand de laboratoare performante in care se desfasoara activitatile didactice pentru cele 44 discipline prevazute cu laborator, dar si activitati de cercetare.

O realizare notabila o constituie Centrala fotovoltaica de 30 KWp, cea mai mare din sud-estul Europei.

In cadrul celor trei catedre se desfasoara activitati didactice in laboratoare dotate cu tehnica de calcul, aparatura electrica, electronica si de achizitii de date, studentii obtinand cunostinte moderne si actuale, laboratoare reprezentative pentru facultate fiind: Electrotehnica, Metode numerice, Masurari electrice, Materiale electrotehnice, Convertoare statice de putere, Masini electrice, Actionari electrice, Inginerie Electrica pentru Medicina, Informatica aplicata, Compatibilitate electromagnetica, Aparate si echipamente electrice.

http://www.upb.ro/electrica.html" runat="server" Width="100%">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
