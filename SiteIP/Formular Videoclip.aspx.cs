using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Formular_Videoclip : System.Web.UI.Page
{
    Auxiliare a = new Auxiliare();
    string nume_curs = null;
    int id_curs;
    string format_videoclip = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        selecteazaNumeCurs();
        selecteazaIdCurs();
    }

    private void selecteazaIdCurs()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT id_curs FROM Curs WHERE nume = '" + nume_curs + "';";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        id_curs = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
    }

    private void selecteazaNumeCurs()
    {
        if (Request.QueryString["nume_curs"] != null)
        {
            nume_curs = Request.QueryString["nume_curs"].ToString();
        }
    }

    protected void buton_upload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            if (FileUpload1.FileBytes.Length > 5242880)
            {
                eroare_marime.Text = "Marimea Videoclipului trebuie sa fie mai mica de 5 GB!";
            }
            else
            {
                format_videoclip = format(FileUpload1.FileName);
                Session["format_videoclip"] = format_videoclip;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Cursuri/") + nume_curs + "/" + numeVideoclip.Text + "." + format_videoclip);
                afiseaza.Src = "/Cursuri/" + nume_curs + "/" + numeVideoclip.Text + "." + format_videoclip;
            }
        }
        else
        {
            eroare_marime.Text = "";
            lbl_debug.Text = "Selecteaza videoclipul pe care vrei sa-l adaugi!";
        }


    }

    private void adaugaInBazaDeDate()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "Insert into [Videoclip] values (" + (maxIdVideoclip() + 1) + ", " + id_curs + ", '" + numeVideoclip.Text + "',  CONVERT(VARCHAR(10), GETDATE(), 10), 0 );";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }

    private int maxIdVideoclip()
    {
        if (numarVideoclipuri() == 0)
        {
            return 0;
        }
        else
        {
            SqlCommand comanda = new SqlCommand();
            SqlConnection conexiune;
            conexiune = new SqlConnection(a.string_bazadedate);
            comanda.Connection = conexiune;
            comanda.Connection.Open();
            SqlDataReader sdr;
            comanda.CommandText = "Select MAX(id_videoclip) from Videoclip;";
            sdr = comanda.ExecuteReader();
            sdr.Read();
            int max = int.Parse(sdr.GetValue(0).ToString());
            conexiune.Close();
            return max;
        }
    }

    private int numarVideoclipuri()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "Select 1 from Videoclip;";
        sdr = comanda.ExecuteReader();
        int i = 0;
        while (sdr.Read())
        {
            i++;
        }
        conexiune.Close();
        return i;
    }

    protected void buton_creeaza_Click(object sender, EventArgs e)
    {
        adaugaInBazaDeDate();
        creazaASPX();
        creazaC();
        Response.Redirect("\\Cursuri\\" + nume_curs + "\\" + numeVideoclip.Text + ".aspx");
    }

    private void creazaASPX()
    {
        String[] aspxLines = {
"<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeFile=\"" + numeVideoclip.Text + ".aspx.cs\" Inherits=\"" + numeVideoclip.Text.Replace(" ", "_") + "\" MasterPageFile=\"~/MasterPage.master\"%>",
" ",
"<asp:Content runat=\"server\" ID=\"Content1\" ContentPlaceHolderID=\"head\">",
"</asp:Content>",
" ",
"<asp:Content runat=\"server\" ID=\"content\" ContentPlaceHolderID=\"ContentPlaceHolder1\">",
"       <asp:Table ID=\"formular\" runat=\"server\" Width=\"80%\" style=\"margin-left: 10%\">",
"            <asp:TableHeaderRow Width=\"100%\">",
"                <asp:TableHeaderCell HorizontalAlign=\"Center\" style=\"padding:10px\" Width=\"50%\">",
"                    <asp:Label ID=\"numeVideoclip\" runat=\"server\" Text=\"" + numeVideoclip.Text + "\" Width=\"50%\">",
"                    </asp:Label>",
"                </asp:TableHeaderCell>",
"                <asp:TableHeaderCell HorizontalAlign=\"Center\" style=\"padding:10px\" Width=\"50%\">",
"                    <asp:Label ID=\"numeCurs\" runat=\"server\" Text=\"" + nume_curs + "\" Width=\"50%\">",
"                    </asp:Label>",
"                </asp:TableHeaderCell>",
"            </asp:TableHeaderRow>",
"           <asp:TableRow>",
"               <asp:TableCell HorizontalAlign=\"Center\" ColumnSpan=\"2\">",
"                   <iframe ID=\"afiseaza\" width=\"560\" height=\"315\" src=\"" + numeVideoclip.Text + "." + (string)Session["format_videoclip"] + "\" frameborder=\"0\" allowfullscreen runat=\"server\"></iframe>",
"               </asp:TableCell>",
"           </asp:TableRow>",
"           <asp:TableRow>",
"               <asp:TableCell HorizontalAlign=\"Center\" ColumnSpan=\"2\">",
"                    <asp:ScriptManager EnablePartialRendering=\"true\" ID=\"ScriptManager1\" runat=\"server\">",
"                    </asp:ScriptManager>",
"                    <asp:UpdatePanel runat=\"server\" ID=\"UpdatePanel\" UpdateMode=\"Conditional\">",
"                    <ContentTemplate>",
"                   <asp:RadioButtonList ID=\"RadioButtonList1\" runat=\"server\" HorizontalAlign=\"Center\" AutoPostBack =\"true\" OnSelectedIndexChanged=\"selectare\">",
"                       <asp:ListItem ID=\"id_nota1\" runat=\"server\" Text=\"1\">",
" ",
"                       </asp:ListItem>",
"                       <asp:ListItem ID=\"id_nota2\" runat=\"server\" Text=\"2\">",
" ",
"                       </asp:ListItem>",
"                       <asp:ListItem ID=\"id_nota3\" runat=\"server\" Text=\"3\">",
" ",
"                       </asp:ListItem>",
"                       <asp:ListItem ID=\"id_nota4\" runat=\"server\" Text=\"4\">",
" ",
"                       </asp:ListItem>",
"                       <asp:ListItem ID=\"id_nota5\" runat=\"server\" Text=\"5\">",
" ",
"                       </asp:ListItem>",
"                   </asp:RadioButtonList>",
"                    </ContentTemplate>",
"                </asp:UpdatePanel>",
"               </asp:TableCell>",
"           </asp:TableRow>",
"        </asp:Table>",
"</asp:Content>",
""
                             };
        System.IO.File.WriteAllLines(Server.MapPath("\\Cursuri\\" + nume_curs + "\\" + numeVideoclip.Text + ".aspx"), aspxLines);
    }

    private void creazaC()
    {

        String[] codeLines = {
"using System;",
"using System.Collections.Generic;",
"using System.Linq;",
"using System.Web;",
"using System.Web.UI;",
"using System.Web.UI.WebControls;",
"using System.Data.SqlClient;",
" ",
"public partial class " + numeVideoclip.Text.Replace(" ", "_") + " : System.Web.UI.Page",
"{",
"    Auxiliare a = new Auxiliare();",
"    int id_videoclip;",
"    int id_utilizator;",
"    int id_curs;",
"    int nota_data;",
"    int numar_note = 0;",
"    double media_notelor_videoclip;",
"    private string email;",
" ",
"    protected void Page_Load(object sender, EventArgs e)",
"    {",
"        culegeDate();",
"        selecteazaIdUtilizator();",
"        selecteazaIdCurs();",
"        selecteazaIdVideoclip();",
"        if (!IsPostBack) {",
"            numarNote();",
"            selecteazaNotaDataVideoclip();",
"            afiseazaNotaData();",
"        }",
"    }",
" ",
"    private void culegeDate()",
"    {",
"        email = (string)Session[\"email\"];",
"    }",
" ",
"    private void afiseazaNotaData()",
"    {",
"        switch(nota_data) {",
"            case 1:",
"                id_nota1.Selected = true;",
"                break;",
"            case 2:",
"                id_nota2.Selected = true;",
"                break;",
"            case 3:",
"                id_nota3.Selected = true;",
"                break;",
"            case 4:",
"                id_nota4.Selected = true;",
"                break;",
"            case 5:",
"                id_nota5.Selected = true;",
"                break;",
"        }",
"    }",
" ",
"    private void numarNote()",
"    {",
"        SqlCommand comanda = new SqlCommand();",
"        SqlConnection conexiune;",
"        conexiune = new SqlConnection(a.string_bazadedate);",
"        comanda.Connection = conexiune;",
"        comanda.Connection.Open();",
"        SqlDataReader sdr;",
"        comanda.CommandText = \"SELECT 1 FROM Utilizator_Videoclip WHERE id_utilizator = \" + id_utilizator + \" AND id_videoclip = \" + id_videoclip + \";\";",
"        sdr = comanda.ExecuteReader();",
"        while(sdr.Read()) {",
"            numar_note++;",
"        }",
"        conexiune.Close();",
"    }",
" ",
"    private void selecteazaNotaDataVideoclip()",
"    {",
"        if (numar_note == 0) {",
"            nota_data = 0;",
"        }",
"        else",
"        {",
"           SqlCommand comanda = new SqlCommand();",
"           SqlConnection conexiune;",
"           conexiune = new SqlConnection(a.string_bazadedate);",
"           comanda.Connection = conexiune;",
"           comanda.Connection.Open();",
"           SqlDataReader sdr;",
"           comanda.CommandText = \"SELECT nota_data FROM Utilizator_Videoclip WHERE id_utilizator = \" + id_utilizator + \" AND id_videoclip = \" + id_videoclip + \";\";",
"           sdr = comanda.ExecuteReader();",
"           sdr.Read();",
"           nota_data = int.Parse(sdr.GetValue(0).ToString());",
"           conexiune.Close();",
"        }",
"    }",
" ",
"    private void selecteazaIdCurs()",
"    {",
"        SqlCommand comanda = new SqlCommand();",
"        SqlConnection conexiune;",
"        conexiune = new SqlConnection(a.string_bazadedate);",
"        comanda.Connection = conexiune;",
"        comanda.Connection.Open();",
"        SqlDataReader sdr;",
"        comanda.CommandText = \"SELECT id_curs FROM Curs WHERE nume = \'\" + numeCurs.Text + \"\';\";",
"        sdr = comanda.ExecuteReader();",
"        sdr.Read();",
"        id_curs = int.Parse(sdr.GetValue(0).ToString());",
"        conexiune.Close();",
"    }",
" ",
"    private void selecteazaIdVideoclip()",
"    {",
"        SqlCommand comanda = new SqlCommand();",
"        SqlConnection conexiune;",
"        conexiune = new SqlConnection(a.string_bazadedate);",
"        comanda.Connection = conexiune;",
"        comanda.Connection.Open();",
"        SqlDataReader sdr;",
"        comanda.CommandText = \"SELECT id_videoclip FROM Videoclip WHERE nume = \'\" + numeVideoclip.Text + \"\' AND id_curs = \" + id_curs + \";\";",
"        sdr = comanda.ExecuteReader();",
"        sdr.Read();",
"        id_videoclip = int.Parse(sdr.GetValue(0).ToString());",
"        conexiune.Close();",
"    }",
" ",
"    private void selecteazaIdUtilizator()",
"    {",
"        SqlCommand comanda = new SqlCommand();",
"        SqlConnection conexiune;",
"        conexiune = new SqlConnection(a.string_bazadedate);",
"        comanda.Connection = conexiune;",
"        comanda.Connection.Open();",
"        SqlDataReader sdr;",
"        comanda.CommandText = \"SELECT id_utilizator FROM Utilizator WHERE email = \'\" + email + \"\';\";",
"        sdr = comanda.ExecuteReader();",
"        sdr.Read();",
"        id_utilizator = int.Parse(sdr.GetValue(0).ToString());",
"        conexiune.Close();",
"    }",
" ",
"    private bool exista()",
"    {",
"        SqlCommand comanda = new SqlCommand();",
"        SqlConnection conexiune;",
"        conexiune = new SqlConnection(a.string_bazadedate);",
"        comanda.Connection = conexiune;",
"        comanda.Connection.Open();",
"        SqlDataReader sdr;",
"        comanda.CommandText = \"Select 1 from Utilizator_Videoclip WHERE id_utilizator = \" + id_utilizator + \" AND id_videoclip = \" + id_videoclip + \";\";",
"        sdr = comanda.ExecuteReader();",
"        int i = 0;",
"        while (sdr.Read())",
"        {",
"            i++;",
"        }",
"        conexiune.Close();",
"        if (i == 0) {",
"            return false;",
"        }",
"        else",
"        {",
"            return true;",
"        }",
"    }",
" ",
"    private void actualizeazaNotaDataVideoclip(int nota)",
"    {",
"        if(exista()) {",
"           SqlCommand comanda = new SqlCommand();",
"           SqlConnection conexiune;",
"           conexiune = new SqlConnection(a.string_bazadedate);",
"           comanda = new SqlCommand();",
"           comanda.Connection = conexiune;",
"           comanda.Connection.Open();",
"           comanda.CommandText = \"UPDATE [Utilizator_Videoclip] SET nota_data = \" + nota + \" WHERE id_utilizator = \" + id_utilizator + \" AND id_videoclip = \" + id_videoclip + \";\";",
"           comanda.ExecuteNonQuery();",
"           conexiune.Close();",
"        }",
"        else",
"        {",
"            SqlCommand comanda = new SqlCommand();",
"            SqlConnection conexiune;",
"            conexiune = new SqlConnection(a.string_bazadedate);",
"            comanda = new SqlCommand();",
"            comanda.Connection = conexiune;",
"            comanda.Connection.Open();",
"            comanda.CommandText = \"Insert into [Utilizator_Videoclip] values (\" + id_utilizator + \", \" + id_videoclip + \",  CONVERT(VARCHAR(10), GETDATE(), 10), \" + nota + \");\";",
"            comanda.ExecuteNonQuery();",
"            conexiune.Close();",
"        }",
"    }",
" ",
"    private void selecteazaMediaNotelorVideoclip()",
"    {",
"        SqlCommand comanda = new SqlCommand();",
"        SqlConnection conexiune;",
"        conexiune = new SqlConnection(a.string_bazadedate);",
"        comanda.Connection = conexiune;",
"        comanda.Connection.Open();",
"        SqlDataReader sdr;",
"        comanda.CommandText = \"SELECT AVG(nota_data) FROM Utilizator_Videoclip WHERE id_videoclip = \" + id_videoclip + \";\";",
"        sdr = comanda.ExecuteReader();",
"        sdr.Read();",
"        media_notelor_videoclip = int.Parse(sdr.GetValue(0).ToString());",
"        conexiune.Close();",
"    }",
" ",
"    private void actualizeazaMediaNotelorVideoclip(int nota)",
"    {",
"        SqlCommand comanda = new SqlCommand();",
"        SqlConnection conexiune;",
"        conexiune = new SqlConnection(a.string_bazadedate);",
"        comanda = new SqlCommand();",
"        comanda.Connection = conexiune;",
"        comanda.Connection.Open();",
"        comanda.CommandText = \"UPDATE [Videoclip] SET media_notelor = \" + media_notelor_videoclip + \" WHERE id_videoclip = \" + id_videoclip + \" AND id_curs = \" + id_curs + \";\";",
"        comanda.ExecuteNonQuery();",
"        conexiune.Close();",
"    }",
" ",
"    protected void selectare(object sender, EventArgs e)",
"    {",
"        if(id_nota1.Selected == true) {",
"            actualizeazaNotaDataVideoclip(1);",
"            selecteazaMediaNotelorVideoclip();",
"            actualizeazaMediaNotelorVideoclip(1);",
"        } else if(id_nota2.Selected == true) {",
"            actualizeazaNotaDataVideoclip(2);",
"            selecteazaMediaNotelorVideoclip();",
"            actualizeazaMediaNotelorVideoclip(2);",
"        } else if(id_nota3.Selected == true) {",
"            actualizeazaNotaDataVideoclip(3);",
"            selecteazaMediaNotelorVideoclip();",
"            actualizeazaMediaNotelorVideoclip(3);",
"        } else if (id_nota4.Selected == true) {",
"            actualizeazaNotaDataVideoclip(4);",
"            selecteazaMediaNotelorVideoclip();",
"            actualizeazaMediaNotelorVideoclip(4);",
"        } else {",
"            actualizeazaNotaDataVideoclip(5);",
"            selecteazaMediaNotelorVideoclip();",
"            actualizeazaMediaNotelorVideoclip(5);",
"        }",
"    }",
" ",
"}",
" "
                             };

        System.IO.File.WriteAllLines(Server.MapPath("\\Cursuri\\" + nume_curs + "\\" + numeVideoclip.Text + ".aspx.cs"), codeLines);
    }

    public string format(string nume)
    {
        string s = "";
        string[] rezultat = nume.Split('.');
        foreach (string word in rezultat)
        {
            s = word;
        }
        return s;
    }

}
