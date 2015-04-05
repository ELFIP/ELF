﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Panou de control recomandari.aspx.cs" Inherits="Panou_de_control_recomandari" MasterPageFile="~/MasterPage.master"%>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link href="Resources/css/PanouDeControlRecomandari.css" rel="stylesheet" />
    <script src="Resources/js/SliderPanouDeControlRecomandari.js"></script>
</asp:Content>
<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">
    
    <div class="tree">
	<ul>
        <li>
            <a href="#">Recomandare</a>
            <ul>
                <li>
                    <asp:TextBox ID="date_colectate" runat="server" placeholder="Date colectate" CssClass="procentaje"></asp:TextBox>
					<ul>
						<li>
							<asp:TextBox ID="judet" runat="server" placeholder="Judet" CssClass="procentaje"></asp:TextBox>
						</li>
                        <li>
							<asp:TextBox ID="note" runat="server" placeholder="Note" CssClass="procentaje"></asp:TextBox>
						</li>
					</ul>
				</li>
				<li>
					<asp:TextBox ID="curs" runat="server" placeholder="Curs" CssClass="procentaje"></asp:TextBox>
                    <ul>
                        <li>
                            <asp:TextBox ID="videoclipuri" runat="server" placeholder="Videoclipuri" CssClass="procentaje"></asp:TextBox>
                            <ul>
                                <li>
                                    <asp:TextBox ID="nota_data_videoclipuri" runat="server" placeholder="Nota Videoclip" CssClass="procentaje"></asp:TextBox>
                                </li>
                                <li>
                                    <asp:TextBox ID="numar_videoclipuri_vazute" runat="server" placeholder="Videoclip vazut" CssClass="procentaje"></asp:TextBox>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:TextBox ID="teste" runat="server" placeholder="Teste" CssClass="procentaje"></asp:TextBox>
                            <ul>
                                <li>
                                    <asp:TextBox ID="nota_data_teste" runat="server" placeholder="Nota Data" CssClass="procentaje"></asp:TextBox>
                                </li>
                                <li>
                                    <asp:TextBox ID="nota_test" runat="server" placeholder="Nota Teste" CssClass="procentaje"></asp:TextBox>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:TextBox ID="nota_obtinuta_curs" runat="server" placeholder="Nota Curs" CssClass="procentaje"></asp:TextBox>
                        </li>
                    </ul>
				</li>
			</ul>
		</li>
	</ul>
    </div>
    <br style="clear:both" />
    <br />
    <asp:Button ID="actualizeaza_recomandarile" runat="server" Text="Actualizeaza Recomandarile" OnClick="actualizeaza_recomandarile_Click" />

</asp:Content>