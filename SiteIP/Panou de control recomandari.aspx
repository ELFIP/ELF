<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Panou de control recomandari.aspx.cs" Inherits="Panou_de_control_recomandari" MasterPageFile="~/MasterPage.master"%>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link href="Resources/css/PanouDeControlRecomandari.css" rel="stylesheet" />
    <script src="Resources/js/SliderPanouDeControlRecomandari.js"></script>
    <script src="Resources/js/jQuery/jQueryLib.js"></script>
    <script src="Resources/js/validariPanouDeControlRecomandari.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/normalize/3.0.3/normalize.css" rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css'>
</asp:Content>
<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">
    
    <div class="tree">
	    <ul>
            <li>
                <a href="#" class="rad">Recomandare</a>
                <ul>
                    <li>
                        <asp:TextBox ID="date_colectate" runat="server" placeholder="Date colectate" CssClass="procentaje rec_grp"></asp:TextBox>
					    <ul>
						    <li>
							    <asp:TextBox ID="judet" runat="server" placeholder="Judet" CssClass="procentaje date_colectate_grp"></asp:TextBox>
						    </li>
                            <li>
							    <asp:TextBox ID="note" runat="server" placeholder="Note" CssClass="procentaje date_colectate_grp"></asp:TextBox>
						    </li>
					    </ul>
				    </li>
				    <li>
					    <asp:TextBox ID="curs" runat="server" placeholder="Curs" CssClass="procentaje rec_grp"></asp:TextBox>
                        <ul>
                            <li>
                                <asp:TextBox ID="videoclipuri" runat="server" placeholder="Videoclipuri" CssClass="procentaje curs_grp"></asp:TextBox>
                                <ul>
                                    <li>
                                        <asp:TextBox ID="nota_data_videoclipuri" runat="server" placeholder="Nota Videoclip" CssClass="procentaje video_grp"></asp:TextBox>
                                    </li>
                                    <li>
                                        <asp:TextBox ID="numar_videoclipuri_vazute" runat="server" placeholder="Videoclip vazut" CssClass="procentaje video_grp"></asp:TextBox>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <asp:TextBox ID="teste" runat="server" placeholder="Teste" CssClass="procentaje curs_grp"></asp:TextBox>
                                <ul>
                                    <li>
                                        <asp:TextBox ID="nota_data_teste" runat="server" placeholder="Nota Data" CssClass="procentaje note_grp"></asp:TextBox>
                                    </li>
                                    <li>
                                        <asp:TextBox ID="nota_test" runat="server" placeholder="Nota Teste" CssClass="procentaje note_grp"></asp:TextBox>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <asp:TextBox ID="nota_obtinuta_curs" runat="server" placeholder="Nota Curs" CssClass="procentaje curs_grp"></asp:TextBox>
                            </li>
                        </ul>
				    </li>
			    </ul>
		    </li>
	    </ul>
    </div>
    <br style="clear:both" />
    <br />
    <asp:Button ID="actualizeaza_recomandarile" runat="server" Text="Actualizeaza Recomandarile" UseSubmitBehavior="false"  
                OnClientClick="if(!validate()) return false" OnClick="actualizeaza_recomandarile_Click" CssClass="buaton" />

</asp:Content>
