<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Formular Test.aspx.cs" Inherits="Forma_Test" MasterPageFile="~/MasterPage.master"%>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
</asp:Content>

<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">
       <asp:Table ID="tabel_generare" runat="server" Width="80%" style="margin-left: 10%">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell HorizontalAlign="Center" style="padding:10px" Width="50%">
                    <asp:TextBox ID="numeTest" runat="server" placeholder="Nume test" Width="50%">
                    </asp:TextBox>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell HorizontalAlign="Center" style="padding:10px" Width="50%">
                    <asp:TextBox ID="timpTest" runat="server" placeholder="Timp(minute)" Width="50%">
                    </asp:TextBox>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
           <asp:TableHeaderRow>
               <asp:TableHeaderCell>

               </asp:TableHeaderCell>
               <asp:TableHeaderCell>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="Durata testului trebuie specificata!" ControlToValidate="timpTest"></asp:RequiredFieldValidator>
                   <br />
                   <asp:RangeValidator ID="RangeValidator" runat="server" ErrorMessage="Durata testului trebuie sa fie intre 1 si 180 minute!" ControlToValidate="timpTest" minimumvalue="1" maximumvalue="180"></asp:RangeValidator>
               </asp:TableHeaderCell>
           </asp:TableHeaderRow>
           <asp:TableRow>
               <asp:TableCell HorizontalAlign="Center" style="padding:10px" Width="50%">
                   <asp:TextBox ID="numarIntrebari" runat="server" placeholder="Numar Intrebari" Width="50%">
                   </asp:TextBox>
                   <br />
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator_numarIntrebari" runat="server" ErrorMessage="Numarul intrebarilor trebuie specificat!" ControlToValidate="numarIntrebari" ></asp:RequiredFieldValidator>
                   <br />
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ErrorMessage="Numarul intrebarilor este incorect!" ValidationExpression="[1-9][0-9]*" ControlToValidate="numarIntrebari"></asp:RegularExpressionValidator>
               </asp:TableCell>
               <asp:TableCell HorizontalAlign="Center" style="padding:10px" Width="50%">
                   <asp:Button ID="buton_genereazaIntrebari" runat="server" Text="Genereaza Intrebari" OnClick="genereazaIntrebari" Width="50%"/>
               </asp:TableCell>
           </asp:TableRow>
        </asp:Table>
</asp:Content>
