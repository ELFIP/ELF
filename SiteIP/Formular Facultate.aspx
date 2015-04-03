<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Formular Facultate.aspx.cs" Inherits="Formular_Facultate" MasterPageFile="~/MasterPage.master"%>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <script type="text/javascript">
        function OpenFiledialog() {
            document.getElementById('incarca_imagine').focus() / click();
        }
    </script>
</asp:Content>
<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">

    <asp:Panel ID="formular" runat="server" CssClass="formular_facultate">
        <asp:ImageButton ID="imagine_facultate" runat="server" CssClass="imagine_facultate"/>
        <asp:FileUpload ID="incarca_imagine" runat="server" style="display:none"/>
        <asp:TextBox ID="nume_facultate" runat="server" placeholder="Nume" CssClass="nume_facultate_formular" >

        </asp:TextBox>
        <asp:TextBox ID="localitatea_facultatii" runat="server" placeholder="Localitate" CssClass="localitate_facultate_formular">

        </asp:TextBox>
        <asp:TextBox ID="adresa_facultatii" placeholder="Adresa" TextMode="multiline" Columns="50" Rows="5" runat="server" CssClass="adresa_facultate_formular">

        </asp:TextBox>
        
        <asp:TextBox ID="alte_informatii" placeholder="Alte Informatii" TextMode="multiline" Columns="50" Rows="5" runat="server" CssClass="alte_informatii_formular">

        </asp:TextBox>

        <asp:Button ID="adauga_facultate" runat="server" Text="Adauga" CssClass="buton_adaugare"/>
    </asp:Panel>
</asp:Content>
