<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cursuri.aspx.cs" Inherits="Cursuri" MasterPageFile="~/MasterPage.master" %>


<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">
  <div style="margin-left: auto; margin-right: auto; text-align: center;">
        <asp:Label ID="label_cauta_utilizator" runat="server" Text="Cauta cursuri"></asp:Label>
      <br />
        <asp:TextBox ID="cauta_curs" runat="server" OnTextChanged="TextBox1_TextChanged" style="margin-bottom: 0px"></asp:TextBox>
  </div>
        <asp:Panel ID="panou_cursuri" runat="server">

        </asp:Panel>
        <asp:Panel ID="panou_checkbox" runat="server">

        </asp:Panel>
</asp:Content>

