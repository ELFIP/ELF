<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Testul 1.aspx.cs" Inherits="Testul_1" MasterPageFile="~/MasterPage.master"%>
 
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <script type="text/javascript">
 
        var secunde = 0;
        var minute = 0;
        var ore = 0;

        window.onload = function () {
            if("<%=testInceput%>" == "True") {
                setInterval(function () { myTimer() }, 1000);
            }
        }
 
        function myTimer() {
            secunde++;
            if (secunde == 60) {
                minute++;
                secunde = 0;
                if (minute == 60) {
                    ore++;
                    minute = 0;
                    if (ore == 24) {
                        ore = 0;
                    }
                }
            }
 
            document.getElementById("demo").innerHTML = ore + " : " + minute + " : " + secunde;
 
            if (minute + "" == "<%=minute_bazaDeDate%>" && ore + "" == "<%=ore_bazaDeDate%>") {
                clearInterval(myVar);
                alert("Timpul testului s-a scurs!");
            }
 
        }
 
    </script>
</asp:Content>
 
<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">
       <p id="demo"></p>
       <asp:Label ID="id_timp_rezolvare" runat="server" Text="Timp rezolvare: "></asp:Label>
       <asp:Table ID="formular" runat="server" Width="80%" style="margin-left: 10%">
            <asp:TableHeaderRow Width="100%">
                <asp:TableHeaderCell HorizontalAlign="Center" style="padding:10px" Width="50%">
                    <asp:Label ID="numeTest" runat="server" Text="Testul 1" Width="50%">
                    </asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell HorizontalAlign="Center" style="padding:10px" Width="50%">
                    <asp:Label ID="numeCurs" runat="server" Text="Understanding the Brain" Width="50%">
                    </asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
           <asp:TableRow>
               <asp:TableCell>
                   <asp:Button ID="buton_start" runat="server" Text="Incepe" OnClick="incepeTest"/>
               </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell ID="celula_test" HorizontalAlign="Center" ColumnSpan="2">
 
               </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell ID="celula_rezultat" HorizontalAlign="Center" ColumnSpan="2">
 
               </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                   <asp:RadioButtonList ID="RadioButtonList1" runat="server" HorizontalAlign="Center" AutoPostBack ="true" OnSelectedIndexChanged="selectare">
                       <asp:ListItem ID="id_nota1" runat="server" Text="1">
 
                       </asp:ListItem>
                       <asp:ListItem ID="id_nota2" runat="server" Text="2">
 
                       </asp:ListItem>
                       <asp:ListItem ID="id_nota3" runat="server" Text="3">
 
                       </asp:ListItem>
                       <asp:ListItem ID="id_nota4" runat="server" Text="4">
 
                       </asp:ListItem>
                       <asp:ListItem ID="id_nota5" runat="server" Text="5">
 
                       </asp:ListItem>
                   </asp:RadioButtonList>
               </asp:TableCell>
           </asp:TableRow>
        </asp:Table>
</asp:Content>
 
