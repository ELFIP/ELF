using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Formular_Curs : System.Web.UI.Page
{
    Auxiliare a = new Auxiliare();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void adauga_curs_Click(object sender, EventArgs e)
    {
        if (exista())
        {
            alerta_nume.Text = "Nume deja folosit";
        }
        else
        {
            adaugaInBazaDeDate();
            creazaPaginaNoua();
        }
    }

    private bool exista()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT 1 FROM Curs WHERE nume LIKE '" + numeCurs.Text + "';";
        sdr = comanda.ExecuteReader();
        int i = 0;
        while (sdr.Read())
        {
            i++;
        }
        conexiune.Close();
        if (i == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void adaugaInBazaDeDate()
    {
        insereazaCurs();
    }

    private void insereazaCurs()
    {
        SqlCommand dbcommand = new SqlCommand();
        SqlConnection dbconnection;
        dbconnection = new SqlConnection(a.string_bazadedate);
        dbcommand = new SqlCommand();
        dbcommand.Connection = dbconnection;
        dbcommand.Connection.Open();
        dbcommand.CommandText = "Insert into [Curs] values (" + (maxIdCurs() + 1) + ", '" + numeCurs.Text + "', null);";
        dbcommand.ExecuteNonQuery();
        dbconnection.Close();
    }

    private int numarCursuri()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "Select 1 from Curs;";
        sdr = comanda.ExecuteReader();
        int i = 0;
        while (sdr.Read())
        {
            i++;
        }
        conexiune.Close();
        return i;
    }

    private int maxIdCurs()
    {
        if (numarCursuri() == 0)
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
            comanda.CommandText = "Select MAX(id_curs) from Curs;";
            sdr = comanda.ExecuteReader();
            sdr.Read();
            int max = int.Parse(sdr.GetValue(0).ToString());
            conexiune.Close();
            return max;
        }
    }

    protected void creazaPaginaNoua()
    {
        creazaASPX();
        creazaC();
        //Response.Redirect(numeCurs.Text + ".aspx");
    }

    private void creazaASPX()
    {

        String[] aspxLines = {
"<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeFile=\"" + numeCurs.Text + ".aspx.cs\" Inherits=\"" + numeCurs.Text + "\" MasterPageFile=\"~/MasterPage.master\" %>",

"<asp:Content runat=\"server\" ID=\"Content1\" ContentPlaceHolderID=\"head\">",
"</asp:Content>",
"<asp:Content runat=\"server\" ID=\"content\" ContentPlaceHolderID=\"ContentPlaceHolder1\">",

"   <asp:Table ID=\"forma\" runat=\"server\" Width=\"80%\" Style=\"margin-left: 10%\">",
"       <asp:TableHeaderRow Width=\"100%\">",
"           <asp:TableHeaderCell HorizontalAlign=\"Center\" Style=\"padding: 10px\">",
"               <asp:Label ID=\"numeCurs\" runat=\"server\" Text=\"" + numeCurs.Text +"\" Width=\"50%\"></asp:Label>",
"           </asp:TableHeaderCell>",
"       </asp:TableHeaderRow>",
"       <asp:TableRow Width=\"100%\">",
"           <asp:TableCell HorizontalAlign=\"Center\" Style=\"padding: 10px\">",
"               <asp:Label ID=\"despreCurs\" TextMode=\"MultiLine\" Rows=\"10\" runat=\"server\" Text=\"\">",
"               </asp:Label>",
"           </asp:TableCell>",
"       </asp:TableRow>",
"       <asp:TableRow Width=\"100%\">",
"           <asp:TableCell HorizontalAlign=\"Center\" Style=\"padding: 10px\" BorderStyle=\"Solid\" BorderColor=\"Black\" BorderWidth=\"1px\">",
"               <asp:Table ID=\"tabel_videoclipuri\" runat=\"server\" Width=\"100%\">",
"                   <asp:TableHeaderRow Width=\"100%\">",
"                       <asp:TableHeaderCell ID=\"id_videoclip\" Text=\"Videoclipuri\" Style=\"padding: 10px\" Width=\"60%\">",
"                       </asp:TableHeaderCell>",
"                       <asp:TableHeaderCell ID=\"id_nota_data_videoclip\" Text=\"Nota data\" Style=\"padding: 10px\" Width=\"20%\">",
"                       </asp:TableHeaderCell>",
"                       <asp:TableHeaderCell ID=\"id_media_notelor_videoclip\" Text=\"Media notelor\" Style=\"padding: 10px\" Width=\"20%\">",
"                       </asp:TableHeaderCell>",
"                   </asp:TableHeaderRow>",
"                   <asp:TableRow>",
"                       <asp:TableCell ID=\"videoclipuri\">",
"                       </asp:TableCell>",
"                   </asp:TableRow>",
"               </asp:Table>",
"           </asp:TableCell>",
"       </asp:TableRow>",
"       <asp:TableRow Width=\"100%\" >",
"           <asp:TableCell HorizontalAlign=\"Center\" Style=\"padding: 10px\" BorderStyle=\"Solid\" BorderColor=\"Black\" BorderWidth=\"1px\">",
"               <asp:Table ID=\"tabel_teste\" runat=\"server\" Width=\"100%\">",
"                   <asp:TableHeaderRow Width=\"100%\">",
"                       <asp:TableHeaderCell ID=\"id_test\" Text=\"Test\" Style=\"padding: 10px\" Width=\"60%\">",
"                       </asp:TableHeaderCell>",
"                       <asp:TableHeaderCell ID=\"id_nota_data_test\" Text=\"Nota data\" Style=\"padding: 10px\" Width=\"20%\">",
"                       </asp:TableHeaderCell>",
"                       <asp:TableHeaderCell ID=\"id_media_notelor_test\" Text=\"Media notelor\" Style=\"padding: 10px\" Width=\"20%\">",
"                       </asp:TableHeaderCell>",
"                       </asp:TableHeaderRow>",
"                       <asp:TableRow>",
"                           <asp:TableCell ID=\"Teste\">",
"                           </asp:TableCell>",
"                       </asp:TableRow>",
"                   </asp:Table>",
"           </asp:TableCell>",
"       </asp:TableRow>",
"   </asp:Table>",
"</asp:Content>"
                             };
        System.IO.File.WriteAllLines(Server.MapPath("\\Cursuri\\" + numeCurs.Text + ".aspx"), aspxLines);
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
"public partial class " + numeCurs.Text + " : System.Web.UI.Page",
"{",
"    Auxiliare a = new Auxiliare();",
"    private string nume_curs;",
"    private string email;",
"    private List<string> numeVideoclip = new List<string>();",
"    private List<string> numeTest = new List<string>();",
"    private List<int> notaDataVideoclip = new List<int>();",
"    private List<double> mediaNotelorVideoclip = new List<double>();",
"    private List<int> notaDataTest = new List<int>();",
"    private List<double> mediaNotelorTest = new List<double>();",
" ",
"    protected void Page_Load(object sender, EventArgs e)",
"    {",
"        culegeDate();",
"        selecteazaVideoclipurile();",
"        selecteazaTestele();",
"        afiseazaVideoclipurile();",
"        afiseazaTestele();",
"    }",
" ",
"    private void culegeDate()",
"    {",
"        email = (string)Session[\"email\"];",
"        nume_curs = numeCurs.Text;",
"    }",
" ",
"    private int selecteazaIdCurs()",
"    {",
"        SqlCommand comanda = new SqlCommand();",
"        SqlConnection conexiune;",
"        conexiune = new SqlConnection(a.string_bazadedate);",
"        comanda.Connection = conexiune;",
"        comanda.Connection.Open();",
"        SqlDataReader sdr;",
"        comanda.CommandText = \"SELECT id_curs FROM Curs WHERE nume = \'\" + nume_curs + \"\';\";",
"        sdr = comanda.ExecuteReader();",
"        sdr.Read();",
"        int nr = int.Parse(sdr.GetValue(0).ToString());",
"        conexiune.Close();",
"        return nr;",
"    }",
" ",
"    private int selecteazaIdUtilizator()",
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
"        int nr = int.Parse(sdr.GetValue(0).ToString());",
"        conexiune.Close();",
"        return nr;",
"    }",
" ",
"    private void selecteazaVideoclipurile()",
"    {",
"        SqlCommand comanda = new SqlCommand();",
"        SqlConnection conexiune;",
"        conexiune = new SqlConnection(a.string_bazadedate);",
"        comanda.Connection = conexiune;",
"        comanda.Connection.Open();",
"        SqlDataReader sdr;",
"        comanda.CommandText = \"SELECT v.nume, v.media_notelor, uv.nota_data FROM Videoclip v, Utilizator_Videoclip uv WHERE uv.id_videoclip = v.id_videoclip AND v.id_curs = \" + selecteazaIdCurs() + \" AND uv.id_utilizator = \" + selecteazaIdUtilizator() +\";\";",
"        sdr = comanda.ExecuteReader();",
"        while (sdr.Read())",
"        {",
"            numeVideoclip.Add(sdr.GetValue(0).ToString());",
"            mediaNotelorVideoclip.Add(double.Parse(sdr.GetValue(1).ToString()));",
"            notaDataVideoclip.Add(int.Parse(sdr.GetValue(2).ToString()));",
"        }",
"        conexiune.Close();",
"    }",
" ",
"    private void selecteazaTestele()",
"    {",
"        SqlCommand comanda = new SqlCommand();",
"        SqlConnection conexiune;",
"        conexiune = new SqlConnection(a.string_bazadedate);",
"        comanda.Connection = conexiune;",
"        comanda.Connection.Open();",
"        SqlDataReader sdr;",
"        comanda.CommandText = \"SELECT t.nume, t.media_notelor, ut.nota_data FROM Test t, Utilizator_Test ut WHERE ut.id_test = t.id_test AND t.id_curs = \" + selecteazaIdCurs() + \" AND ut.id_utilizator = \" + selecteazaIdUtilizator() + \";\";",
"        sdr = comanda.ExecuteReader();",
"        while (sdr.Read())",
"        {",
"            numeTest.Add(sdr.GetValue(0).ToString());",
"            mediaNotelorTest.Add(double.Parse(sdr.GetValue(1).ToString()));",
"            notaDataTest.Add(int.Parse(sdr.GetValue(2).ToString()));",
"        }",
"        conexiune.Close();",
"    }",
" ",
"    private void afiseazaVideoclipurile()",
"    {",
"        for (int i = 0; i < numeVideoclip.Count; i++)",
"        {",
"            HyperLink hnf = new HyperLink();",
"            hnf.NavigateUrl = numeVideoclip[i] + \".aspx\";",
"            hnf.Text = numeVideoclip[i];",
" ",
"            TableCell celula1 = new TableCell();",
"            celula1.Controls.Add(hnf);",
" ",
"            TableCell celula2 = new TableCell();",
"            celula2.Text = notaDataVideoclip[i].ToString();",
" ",
"            TableCell celula3 = new TableCell();",
"            celula3.Text = mediaNotelorVideoclip[i].ToString();",
" ",
"            TableRow rand = new TableRow();",
"            rand.Controls.Add(celula1);",
"            rand.Controls.Add(celula2);",
"            rand.Controls.Add(celula3);",
" ",
"            tabel_videoclipuri.Controls.Add(rand);",
"        }",
"    }",
" ",
"    private void afiseazaTestele()",
"    {",
"        for (int i = 0; i < numeTest.Count; i++)",
"        {",
"            HyperLink hnf = new HyperLink();",
"            hnf.NavigateUrl = numeTest[i] + \".aspx\";",
"            hnf.Text = numeTest[i];",
" ",
"            TableCell celula1 = new TableCell();",
"            celula1.Controls.Add(hnf);",
" ",
"            TableCell celula2 = new TableCell();",
"            celula2.Text = notaDataTest[i].ToString();",
" ",
"            TableCell celula3 = new TableCell();",
"            celula3.Text = mediaNotelorTest[i].ToString();",
" ",
"            TableRow rand = new TableRow();",
"            rand.Controls.Add(celula1);",
"            rand.Controls.Add(celula2);",
"            rand.Controls.Add(celula3);",
" ",
"            tabel_videoclipuri.Controls.Add(rand);",
"        }",
"    }",
" ",
"}",
                             };

        System.IO.File.WriteAllLines(Server.MapPath("\\Cursuri\\" + numeCurs.Text + ".aspx.cs"), codeLines);
    }

}
