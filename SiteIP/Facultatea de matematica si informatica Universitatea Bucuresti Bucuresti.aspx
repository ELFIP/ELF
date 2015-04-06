<%@ Page Language='C#' AutoEventWireup='true' CodeFile='Facultatea de matematica si informatica Universitatea Bucuresti Bucuresti.aspx.cs' Inherits='Facultatea_de_matematica_si_informatica_Universitatea_Bucuresti_Bucuresti' MasterPageFile='~/MasterPage.master'%>
 
<asp:Content runat='server' ID='Content1' ContentPlaceHolderID='head'>
</asp:Content>
<asp:Content runat='server' ID='content' ContentPlaceHolderID='ContentPlaceHolder1'>
    <asp:Panel ID="formular" runat="server" CssClass="formular_facultate">
        <asp:TextBox ID="nume_facultate" runat="server" Enabled="false" CssClass="nume_facultate_formular" Text="Facultatea de matematica si informatica Universitatea Bucuresti">
 
        </asp:TextBox>
        <asp:TextBox ID="localitatea_facultatii" runat="server" Enabled="false" CssClass="localitate_facultate_formular" Text="Bucuresti">
 
        </asp:TextBox>
        <asp:TextBox ID="adresa_facultatii" TextMode="multiline" Enabled="false" Columns="50" Rows="5" runat="server" CssClass="adresa_facultate_formular" Text="asdasd">
 
        </asp:TextBox>
        <asp:TextBox ID="alte_informatii" TextMode="multiline" Enabled="false" Columns="50" Rows="5" runat="server" CssClass="alte_informatii_formular" Text="asdas"> 
 
       </asp:TextBox>
 
    </asp:Panel>
</asp:Content>
