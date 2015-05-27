<%@ Page Language='C#' AutoEventWireup='true' CodeFile='Universitatea de Arhitectura Ion Mincu Bucuresti.aspx.cs' Inherits='Universitatea_de_Arhitectura_Ion_Mincu_Bucuresti' MasterPageFile='~/MasterPage.master'%>
 
<asp:Content runat='server' ID='Content1' ContentPlaceHolderID='head'>
    <link rel='stylesheet' type='text/css' href="/Resources/css/facultati_each.css" />
</asp:Content>
<asp:Content runat='server' ID='content' ContentPlaceHolderID='ContentPlaceHolder1'>
    <asp:Table ID="formularFacultate" runat="server" Width="80%" Style="margin-left: 10%">
        <asp:TableRow Width="100%">
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="20%">
                <asp:Image ID="imagine_facultate" runat="server" Width="100px" Height="100px" ImageUrl="~/Imagini_facultati/Universitatea de Arhitectura Ion MincuBucuresti.jpg" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" Width="50%">
                <asp:Label ID="nume_facultate" runat="server" Text="Universitatea de Arhitectura Ion Mincu" CssClass="nume_facultate_formular" Width="50%">
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
                <asp:Label ID="adresa_facultatii" TextMode="MultiLine" Rows="3" Text="Strada Academiei 18-20" runat="server"  Width="100%">
 
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" Style="padding: 10px" ColumnSpan="2" Width="100%">
                <asp:Label ID="alte_informatii" TextMode="MultiLine" Rows="5" Text="Prestigiul academic, stiintific si profesional al Universitatii de Arhitectura si Urbanism Ion Mincu este emblematic pentru invatamantul superior de arhitectura din Romania. Se regaseste in profesionalismul de exceptie al corpului didactic, in calitatea profesionala a multor serii de absolventi; in recunoasterea Scolii noastre ca fiind inscrisa in esalonul de elita al invatamantului academic international.

Premierea cu Ordine si Medalii, conferinte la cel mai inalt nivel; recunoasterea publica si oficiala a prestigiului profesional al celor mai buni profesori; importanta si prestigiul UAUIM reflectate in Titluri academice conferite unor mari personalitati din domeniul arhitecturii la nivel mondial, reflecta pe deplin prestigiul Scolii noastre.

https://www.uauim.ro/" runat="server" Width="100%">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
