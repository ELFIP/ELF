using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

public partial class Formular_Curs : System.Web.UI.Page
{
    Auxiliare a = new Auxiliare();
    String format_imagine = "";
    String nume_curs = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack){
            Session["format_videoclip"] = "";
            Session["nume_curs"] = "";
        }
        else
        {
            format_imagine = (String)Session["format_videoclip"];
            nume_curs = (String)Session["nume_curs"];
        }
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

    protected void Upload(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            if(numeCurs.Text == "") {
                alerta_nume.Text = "Trebuie sa alegi un nume pentru curs!";
            }
            else
            {
                alerta_nume.Text = "";
                lbl_debug.Text = "";
                format_imagine = format(FileUpload1.FileName);
                Session["format_videoclip"] = format_imagine;
                Session["nume_curs"] = numeCurs.Text;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Imagini_cursuri/") + numeCurs.Text + "." + format_imagine);
                imagine_curs.ImageUrl = "/Imagini_cursuri/" + numeCurs.Text + "." + format_imagine;
            }
        }
        else
        {
            lbl_debug.Text = "Selecteaza imaginea pe care vrei sa o adaugi!";
        }
    }

    protected void adauga_curs_Click(object sender, EventArgs e)
    {
        if (exista())
        {
            alerta_nume.Text = "Nume deja folosit";
        }
        else
        {
            alerta_nume.Text = "";
            adaugaInBazaDeDate();
            creazaPaginaNoua();
            Response.Redirect("\\Cursuri\\" + numeCurs.Text + "\\" + numeCurs.Text + ".aspx");
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
        comanda.CommandText = "SELECT 1 FROM Curs WHERE nume = '" + numeCurs.Text + "';";
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

    // Inseram un nou curs in baza de date;
    private void insereazaCurs()
    {
        SqlCommand dbcommand = new SqlCommand();
        SqlConnection dbconnection;
        dbconnection = new SqlConnection(a.string_bazadedate);
        dbcommand = new SqlCommand();
        dbcommand.Connection = dbconnection;
        dbcommand.Connection.Open();
        dbcommand.CommandText = "Insert into [Curs] values (" + (maxIdCurs() + 1) + ", '" + numeCurs.Text + "', 0, '" + nume_curs + "." + format_imagine + "');";
        dbcommand.ExecuteNonQuery();
        dbconnection.Close();
    }

    // Numaram numarul cursurilor din baza de date;
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

    // Cursul nou creat va avea id = id_max + 1;
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

    // Cream pagina pentru cursul respectiv;
    protected void creazaPaginaNoua()
    {
        creazaFolder();

        // ASPX si C pentru utilizatorul care nu este administrator;
        creazaASPX();
        creazaC();

        // ASPX si C pentru administrator;
        creazaASPX_administrator();
        creazaC_administrator();
    }

    // Folderul in care va fi memorat cursul;
    private void creazaFolder()
    {
        var folder = Server.MapPath("~/Cursuri/" + numeCurs.Text);
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }
    }

    private void creazaASPX()
    {

        String[] aspxLines = {
"<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeFile=\"" + numeCurs.Text + ".aspx.cs\" Inherits=\"" + numeCurs.Text + "\" MasterPageFile=\"~/MasterPage.master\" %>",

"<asp:Content runat=\"server\" ID=\"Content1\" ContentPlaceHolderID=\"head\">",
"</asp:Content>",
"<asp:Content runat=\"server\" ID=\"content\" ContentPlaceHolderID=\"ContentPlaceHolder1\">",
" ",
"   <asp:Table ID=\"forma\" runat=\"server\" Width=\"80%\" Style=\"margin-left: 10%\">",
"       <asp:TableHeaderRow Width=\"100%\">",
"           <asp:TableHeaderCell HorizontalAlign=\"Center\" Style=\"padding: 10px\">",
"               <asp:Image ID=\"imagine_curs\" runat=\"server\" ImageUrl=\"~/Imagini_cursuri/" + nume_curs + "." + format_imagine + "\" Width=\"100px\" Height=\"100px\"/>",
"               <asp:Label ID=\"numeCurs\" runat=\"server\" Text=\"" + numeCurs.Text +"\" Width=\"50%\"></asp:Label>",
"           </asp:TableHeaderCell>",
"            <asp:TableHeaderCell HorizontalAlign=\"Center\" Style=\"padding: 10px\">",
"                <asp:Button ID=\"buton_inscrie\" runat=\"server\" Text=\"Inscrie-te\" OnClick=\"inscrie_Click\"/>",
"            </asp:TableHeaderCell>",
"       </asp:TableHeaderRow>",
"       <asp:TableRow Width=\"100%\">",
"           <asp:TableCell HorizontalAlign=\"Center\" Style=\"padding: 10px\">",
"               <asp:Label ID=\"despreCurs\" TextMode=\"MultiLine\" Rows=\"10\" runat=\"server\" Text=\"" + despreCurs.Text + "\">",
"               </asp:Label>",
"           </asp:TableCell>",
"       </asp:TableRow>",
"       <asp:TableRow Width=\"100%\">",
"           <asp:TableCell HorizontalAlign=\"Center\" Style=\"padding: 10px\" BorderStyle=\"Solid\" BorderColor=\"Black\" BorderWidth=\"1px\">",
"               <asp:Table ID=\"tabel_videoclipuri\" runat=\"server\" Width=\"100%\">",
"                   <asp:TableHeaderRow Width=\"100%\">",
"                       <asp:TableHeaderCell ID=\"id_videoclip\" Text=\"Videoclipuri\" Style=\"padding: 10px\" Width=\"50%\">",
"                       </asp:TableHeaderCell>",
"                       <asp:TableHeaderCell ID=\"id_media_notelor_videoclip\" Text=\"Media notelor\" Style=\"padding: 10px\" Width=\"50%\">",
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
"                       <asp:TableHeaderCell ID=\"id_test\" Text=\"Test\" Style=\"padding: 10px\" Width=\"50%\">",
"                       </asp:TableHeaderCell>",
"                       <asp:TableHeaderCell ID=\"id_media_notelor_test\" Text=\"Media notelor\" Style=\"padding: 10px\" Width=\"50%\">",
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
        System.IO.File.WriteAllLines(Server.MapPath("\\Cursuri\\" + numeCurs.Text + "\\" + numeCurs.Text + ".aspx"), aspxLines);
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
"    private int id_utilizator;",
"    private int id_curs;",
"    private List<string> numeVideoclip = new List<string>();",
"    private List<string> numeTest = new List<string>();",
"    private List<double> mediaNotelorVideoclip = new List<double>();",
"    private List<double> mediaNotelorTest = new List<double>();",
" ",
"    protected void Page_Load(object sender, EventArgs e)",
"    {",
"        if ((bool)Session[\"este_administrator\"])",
"        {",
"             Response.Redirect(\"" + numeCurs.Text + "_administrator.aspx" + "\");",
"        }",
"        culegeDate();",
"        selecteazaIdCurs();",
"        selecteazaIdUtilizator();",
"        if (este_inscris())",
"        {",
"             buton_inscrie.Text = \"Inscris\";",
"             buton_inscrie.Enabled = false;",
"             selecteazaVideoclipurile();",
"             selecteazaTestele();",
"             afiseazaVideoclipurile();",
"             afiseazaTestele();",
"        }",
"    }",
" ",
"    private bool este_inscris()",
"    {",
"        SqlCommand comanda = new SqlCommand();",
"        SqlConnection conexiune;",
"        conexiune = new SqlConnection(a.string_bazadedate);",
"        comanda.Connection = conexiune;",
"        comanda.Connection.Open();",
"        SqlDataReader sdr;",
"        comanda.CommandText = \"SELECT 1 FROM Utilizator_Curs WHERE id_utilizator = \" + id_utilizator + \" AND id_curs = \" + id_curs + \";\";",
"        sdr = comanda.ExecuteReader();",
"        int nr = 0;",
"        while (sdr.Read())",
"        {",
"            nr++;",
"        }",
"        conexiune.Close();",
"        if (nr == 0)",
"        {",
"            return false;",
"        }",
"        else",
"        {",
"            return true;",
"        }",
"    }",
" ",
"    private void culegeDate()",
"    {",
"        email = (string)Session[\"email\"];",
"        nume_curs = numeCurs.Text;",
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
"        comanda.CommandText = \"SELECT id_curs FROM Curs WHERE nume = \'\" + nume_curs + \"\';\";",
"        sdr = comanda.ExecuteReader();",
"        sdr.Read();",
"        int nr = int.Parse(sdr.GetValue(0).ToString());",
"        id_curs = nr;",
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
"        int nr = int.Parse(sdr.GetValue(0).ToString());",
"        id_utilizator = nr;",
"        conexiune.Close();",
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
"        comanda.CommandText = \"SELECT nume, media_notelor FROM Videoclip WHERE id_curs = \" + id_curs + \" ;\";",
"        sdr = comanda.ExecuteReader();",
"        while (sdr.Read())",
"        {",
"            numeVideoclip.Add(sdr.GetValue(0).ToString());",
"            mediaNotelorVideoclip.Add(double.Parse(sdr.GetValue(1).ToString()));",
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
"        comanda.CommandText = \"SELECT nume, media_notelor FROM Test WHERE id_curs = \" + id_curs + \";\";",
"        sdr = comanda.ExecuteReader();",
"        while (sdr.Read())",
"        {",
"            numeTest.Add(sdr.GetValue(0).ToString());",
"            mediaNotelorTest.Add(double.Parse(sdr.GetValue(1).ToString()));",
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
"            celula1.HorizontalAlign = HorizontalAlign.Center;",
"            celula1.Attributes.Add(\"style\", \"padding: 10px\");",
" ",
"            TableCell celula2 = new TableCell();",
"            celula2.Text = mediaNotelorVideoclip[i].ToString();",
"            celula2.HorizontalAlign = HorizontalAlign.Center;",
"            celula2.Attributes.Add(\"style\", \"padding: 10px\");",
" ",
"            TableRow rand = new TableRow();",
"            rand.Controls.Add(celula1);",
"            rand.Controls.Add(celula2);",
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
"            celula1.HorizontalAlign = HorizontalAlign.Center;",
"            celula1.Attributes.Add(\"style\", \"padding: 10px\");",
" ",
"            TableCell celula2 = new TableCell();",
"            celula2.Text = mediaNotelorTest[i].ToString();",
"            celula2.HorizontalAlign = HorizontalAlign.Center;",
"            celula2.Attributes.Add(\"style\", \"padding: 10px\");",
" ",
"            TableRow rand = new TableRow();",
"            rand.Controls.Add(celula1);",
"            rand.Controls.Add(celula2);",
" ",
"            tabel_teste.Controls.Add(rand);",
"        }",
"    }",
" ",
"    protected void inscrie_Click(object sender, EventArgs e)",
"    {",
"        // Blocam butonul si schimbam textul;",
"        buton_inscrie.Text = \"Inscris\";",
"        buton_inscrie.Enabled = false;",
" ",
"        // Adaugam perechea utilizator - curs in baza de date;",
"        adaugaInBazaDeDate();",
"        selecteazaVideoclipurile();",
"        selecteazaTestele();",
"        afiseazaVideoclipurile();",
"        afiseazaTestele();",
"    }",
" ",
"    private void adaugaInBazaDeDate()",
"    {",
"        SqlCommand dbcommand = new SqlCommand();",
"        SqlConnection dbconnection;",
"        dbconnection = new SqlConnection(a.string_bazadedate);",
"        dbcommand = new SqlCommand();",
"        dbcommand.Connection = dbconnection;",
"        dbcommand.Connection.Open();",
"        dbcommand.CommandText = \"Insert into [Utilizator_Curs] values (\" + id_utilizator + \", \" + id_curs + \",  CONVERT(VARCHAR(10), GETDATE(), 10), null);\";",
"        dbcommand.ExecuteNonQuery();",
"        dbconnection.Close();",
"    }",
" ",
"}"
                             };

        System.IO.File.WriteAllLines(Server.MapPath("\\Cursuri\\" + numeCurs.Text + "\\" + numeCurs.Text + ".aspx.cs"), codeLines);
    }

    private void creazaASPX_administrator()
    {

        String[] aspxLines = {
"<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeFile=\"" + numeCurs.Text + "_administrator.aspx.cs\" Inherits=\"" + numeCurs.Text + "_administrator\" MasterPageFile=\"~/MasterPage.master\" %>",

"<asp:Content runat=\"server\" ID=\"Content1\" ContentPlaceHolderID=\"head\">",
"</asp:Content>",
"<asp:Content runat=\"server\" ID=\"content\" ContentPlaceHolderID=\"ContentPlaceHolder1\">",

"   <asp:Table ID=\"forma\" runat=\"server\" Width=\"80%\" Style=\"margin-left: 10%\">",
"       <asp:TableHeaderRow >",
"           <asp:TableHeaderCell HorizontalAlign=\"Center\" Style=\"padding: 10px\">",
"               <asp:Image ID=\"imagine_curs\" runat=\"server\" ImageUrl=\"~/Imagini_cursuri/" + nume_curs + "." + format_imagine + "\" Width=\"100px\" Height=\"100px\"/>",
"               <asp:Label ID=\"numeCurs\" runat=\"server\" Text=\"" + numeCurs.Text +"\" Width=\"50%\"></asp:Label>",
"           </asp:TableHeaderCell>",
"            <asp:TableHeaderCell HorizontalAlign=\"Center\" Style=\"padding: 10px\">",
"                <asp:Button ID=\"buton_inscrie\" runat=\"server\" Text=\"Inscrie-te\" OnClick=\"inscrie_Click\"/>",
"            </asp:TableHeaderCell>",
"       </asp:TableHeaderRow>",
"       <asp:TableRow>",
"           <asp:TableCell HorizontalAlign=\"Center\" Style=\"padding: 10px\">",
"               <asp:Label ID=\"despreCurs\" TextMode=\"MultiLine\" Rows=\"10\" runat=\"server\" Text=\"" + despreCurs.Text + "\">",
"               </asp:Label>",
"           </asp:TableCell>",
"       </asp:TableRow>",
"       <asp:TableRow>",
"           <asp:TableCell HorizontalAlign=\"Center\" Style=\"padding: 10px\" BorderStyle=\"Solid\" BorderColor=\"Black\" BorderWidth=\"1px\">",
"               <asp:Table ID=\"tabel_videoclipuri\" runat=\"server\" Width=\"100%\">",
"                   <asp:TableHeaderRow Width=\"100%\">",
"                       <asp:TableHeaderCell ID=\"id_videoclip\" Text=\"Videoclipuri\" Style=\"padding: 10px\" Width=\"50%\">",
"                       </asp:TableHeaderCell>",
"                       <asp:TableHeaderCell ID=\"id_media_notelor_videoclip\" Text=\"Media notelor\" Style=\"padding: 10px\" Width=\"50%\">",
"                       </asp:TableHeaderCell>",
"                       <asp:TableHeaderCell Text=\"\" Style=\"padding: 10px\" Width=\"20%\">",
"                       </asp:TableHeaderCell>",
"                   </asp:TableHeaderRow>",
"                   <asp:TableRow>",
"                        <asp:TableCell ColumnSpan=\"3\" HorizontalAlign=\"Center\">",
"                            <asp:Button runat=\"server\" Text=\"Adauga Videoclip\" OnClick=\"adauga_videoclip_click\"/>",
"                        </asp:TableCell>",
"                    </asp:TableRow>",
"               </asp:Table>",
"           </asp:TableCell>",
"       </asp:TableRow>",
"       <asp:TableRow>",
"           <asp:TableCell HorizontalAlign=\"Center\" Style=\"padding: 10px\" BorderStyle=\"Solid\" BorderColor=\"Black\" BorderWidth=\"1px\">",
"               <asp:Table ID=\"tabel_teste\" runat=\"server\" Width=\"100%\">",
"                   <asp:TableHeaderRow Width=\"100%\">",
"                       <asp:TableHeaderCell ID=\"id_test\" Text=\"Test\" Style=\"padding: 10px\" Width=\"50%\">",
"                       </asp:TableHeaderCell>",
"                       <asp:TableHeaderCell ID=\"id_media_notelor_test\" Text=\"Media notelor\" Style=\"padding: 10px\" Width=\"50%\">",
"                       </asp:TableHeaderCell>",
"                       <asp:TableHeaderCell Text=\"\" Style=\"padding: 10px\" Width=\"20%\">",
"                       </asp:TableHeaderCell>",
"                    </asp:TableHeaderRow>",
"                    <asp:TableRow>",
"                        <asp:TableCell ColumnSpan=\"3\" HorizontalAlign=\"Center\">",
"                            <asp:Button runat=\"server\" Text=\"Adauga Test\" OnClick=\"adauga_test_click\"/>",
"                        </asp:TableCell>",
"                    </asp:TableRow>",
"                </asp:Table>",
"           </asp:TableCell>",
"       </asp:TableRow>",
"       <asp:TableRow>",
"           <asp:TableCell HorizontalAlign=\"Center\" Style=\"padding: 10px\">",
"                <asp:HyperLink ID=\"hyperlink_adaugaReferinta\" NavigateUrl=\"~/Formular Referinte Curs.aspx?nume_curs=" + numeCurs.Text + "\" runat=\"server\">Adauga Referinta</asp:HyperLink>",
"           </asp:TableCell>",
"       </asp:TableRow>",
"   </asp:Table>",
"</asp:Content>"
                             };
        System.IO.File.WriteAllLines(Server.MapPath("\\Cursuri\\" + numeCurs.Text + "\\" + numeCurs.Text + "_administrator.aspx"), aspxLines);
    }

    private void creazaC_administrator()
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
"public partial class " + numeCurs.Text + "_administrator : System.Web.UI.Page",
"{",
"    Auxiliare a = new Auxiliare();",
"    private string nume_curs;",
"    private string email;",
"    private int id_utilizator;",
"    private int id_curs;",
"    private List<string> numeVideoclip = new List<string>();",
"    private List<string> numeTest = new List<string>();",
"    private List<double> mediaNotelorVideoclip = new List<double>();",
"    private List<double> mediaNotelorTest = new List<double>();",
"    private List<Button> sterge_videoclip = new List<Button>();",
"    private List<Button> sterge_test = new List<Button>();",
" ",
"    protected void Page_Load(object sender, EventArgs e)",
"    {",
"        if (!(bool)Session[\"este_administrator\"])",
"        {",
"             Response.Redirect(\"" + numeCurs.Text + ".aspx" + "\");",
"        }",
"        culegeDate();",
"        selecteazaIdCurs();",
"        selecteazaIdUtilizator();",
"        if (este_inscris())",
"        {",
"             buton_inscrie.Text = \"Inscris\";",
"             buton_inscrie.Enabled = false;",
"             selecteazaVideoclipurile();",
"             selecteazaTestele();",
"             afiseazaVideoclipurile();",
"             afiseazaTestele();",
"        }",
"    }",
" ",
"    private bool este_inscris()",
"    {",
"        SqlCommand comanda = new SqlCommand();",
"        SqlConnection conexiune;",
"        conexiune = new SqlConnection(a.string_bazadedate);",
"        comanda.Connection = conexiune;",
"        comanda.Connection.Open();",
"        SqlDataReader sdr;",
"        comanda.CommandText = \"SELECT 1 FROM Utilizator_Curs WHERE id_utilizator = \" + id_utilizator + \" AND id_curs = \" + id_curs + \";\";",
"        sdr = comanda.ExecuteReader();",
"        int nr = 0;",
"        while (sdr.Read())",
"        {",
"            nr++;",
"        }",
"        conexiune.Close();",
"        if (nr == 0)",
"        {",
"            return false;",
"        }",
"        else",
"        {",
"            return true;",
"        }",
"    }",
" ",
"    private void culegeDate()",
"    {",
"        email = (string)Session[\"email\"];",
"        nume_curs = numeCurs.Text;",
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
"        comanda.CommandText = \"SELECT id_curs FROM Curs WHERE nume = \'\" + nume_curs + \"\';\";",
"        sdr = comanda.ExecuteReader();",
"        sdr.Read();",
"        int nr = int.Parse(sdr.GetValue(0).ToString());",
"        id_curs = nr;",
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
"        int nr = int.Parse(sdr.GetValue(0).ToString());",
"        id_utilizator = nr;",
"        conexiune.Close();",
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
"        comanda.CommandText = \"SELECT id_videoclip, nume, media_notelor FROM Videoclip WHERE id_curs = \" + id_curs + \";\";",
"        sdr = comanda.ExecuteReader();",
"        while (sdr.Read())",
"        {",
"            int id = int.Parse(sdr.GetValue(0).ToString());",
"            numeVideoclip.Add(sdr.GetValue(1).ToString());",
"            mediaNotelorVideoclip.Add(double.Parse(sdr.GetValue(2).ToString()));",
" ",
"            // Cream buton de stergere a videoclipului;",
"            Button buton = new Button();",
"            buton.Text = \"Sterge\";",
"            buton.ID = \"videoclip\" + id;",
"            buton.Click += stergeVideoclip;",
"            sterge_videoclip.Add(buton);",
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
"        comanda.CommandText = \"SELECT id_test, nume, media_notelor FROM Test WHERE id_curs = \" + id_curs + \";\";",
"        sdr = comanda.ExecuteReader();",
"        while (sdr.Read())",
"        {",
"            int id = int.Parse(sdr.GetValue(0).ToString());",
"            numeTest.Add(sdr.GetValue(1).ToString());",
"            mediaNotelorTest.Add(double.Parse(sdr.GetValue(2).ToString()));",
" ",
"            // Cream buton de stergere a videoclipului;",
"            Button buton = new Button();",
"            buton.Text = \"Sterge\";",
"            buton.ID = \"test\" + id;",
"            buton.Click += stergeTest;",
"            sterge_test.Add(buton);",
"        }",
"        conexiune.Close();",
"    }",
" ",
"    private int getID(String s)",
"    {",
"        int n = 0;",
"        for (int i = 0; i < s.Length; i++)",
"        {",
"            if (s[i] >= '0' && s[i] <= '9')",
"            {",
"                n = n * 10 + (s[i] - '0');",
"            }",
"        }",
"        return n;",
"    }",
" ",
"    private void stergeVideoclip(int id)",
"    {",
"        SqlCommand comanda = new SqlCommand();",
"        SqlConnection conexiune;",
"        conexiune = new SqlConnection(a.string_bazadedate);",
"        comanda = new SqlCommand();",
"        comanda.Connection = conexiune;",
"        comanda.Connection.Open();",
"        comanda.CommandText = \"DELETE FROM Videoclip WHERE id_curs = \" + id_curs + \" AND id_videoclip = \" + id + \";\";",
"        comanda.ExecuteNonQuery();",
"        conexiune.Close();",
"    }",
" ",
"    protected void stergeVideoclip(object sender, EventArgs e)",
"    {",
"        int id_buton = getID(((Button)sender).ID);",
"        stergeVideoclip(id_buton);",
"        Response.Redirect(\"" + nume_curs + "_administrator.aspx\");",
"    }",
" ",
"    private void stergeTest(int id)",
"    {",
"        SqlCommand comanda = new SqlCommand();",
"        SqlConnection conexiune;",
"        conexiune = new SqlConnection(a.string_bazadedate);",
"        comanda = new SqlCommand();",
"        comanda.Connection = conexiune;",
"        comanda.Connection.Open();",
"        comanda.CommandText = \"DELETE FROM Test WHERE id_curs = \" + id_curs + \" AND id_test = \" + id + \";\";",
"        comanda.ExecuteNonQuery();",
"        conexiune.Close();",
"    }",
" ",
"    protected void stergeTest(object sender, EventArgs e)",
"    {",
"        int id_buton = getID(((Button)sender).ID);",
"        stergeTest(id_buton);",
"        Response.Redirect(\"" + nume_curs + "_administrator.aspx\");",
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
"            celula1.HorizontalAlign = HorizontalAlign.Center;",
"            celula1.Attributes.Add(\"style\", \"padding: 10px\");",
" ",
"            TableCell celula2 = new TableCell();",
"            celula2.Text = mediaNotelorVideoclip[i].ToString();",
"            celula2.HorizontalAlign = HorizontalAlign.Center;",
"            celula2.Attributes.Add(\"style\", \"padding: 10px\");",
" ",
"            TableCell celula3 = new TableCell();",
"            celula3.HorizontalAlign = HorizontalAlign.Center;",
"            celula3.Attributes.Add(\"style\", \"padding: 10px\");",
"            celula3.Controls.Add(sterge_videoclip[i]);",
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
"            celula1.HorizontalAlign = HorizontalAlign.Center;",
"            celula1.Attributes.Add(\"style\", \"padding: 10px\");",
" ",
"            TableCell celula2 = new TableCell();",
"            celula2.Text = mediaNotelorTest[i].ToString();",
"            celula2.HorizontalAlign = HorizontalAlign.Center;",
"            celula2.Attributes.Add(\"style\", \"padding: 10px\");",
" ",
"            TableCell celula3 = new TableCell();",
"            celula3.HorizontalAlign = HorizontalAlign.Center;",
"            celula3.Attributes.Add(\"style\", \"padding: 10px\");",
"            celula3.Controls.Add(sterge_test[i]);",
" ",
"            TableRow rand = new TableRow();",
"            rand.Controls.Add(celula1);",
"            rand.Controls.Add(celula2);",
"            rand.Controls.Add(celula3);",
" ",
"            tabel_teste.Controls.Add(rand);",
"        }",
"    }",
" ",
"    protected void inscrie_Click(object sender, EventArgs e)",
"    {",
"        // Blocam butonul si schimbam textul;",
"        buton_inscrie.Text = \"Inscris\";",
"        buton_inscrie.Enabled = false;",
" ",
"        // Adaugam perechea utilizator - curs in baza de date;",
"        adaugaInBazaDeDate();",
"        selecteazaVideoclipurile();",
"        selecteazaTestele();",
"        afiseazaVideoclipurile();",
"        afiseazaTestele();",
"    }",
" ",
"    private void adaugaInBazaDeDate()",
"    {",
"        SqlCommand dbcommand = new SqlCommand();",
"        SqlConnection dbconnection;",
"        dbconnection = new SqlConnection(a.string_bazadedate);",
"        dbcommand = new SqlCommand();",
"        dbcommand.Connection = dbconnection;",
"        dbcommand.Connection.Open();",
"        dbcommand.CommandText = \"Insert into [Utilizator_Curs] values (\" + id_utilizator + \", \" + id_curs + \",  CONVERT(VARCHAR(10), GETDATE(), 10), null);\";",
"        dbcommand.ExecuteNonQuery();",
"        dbconnection.Close();",
"    }",
" ",
"    protected void adauga_test_click(object sender, EventArgs e)",
"    {",
"           Response.Redirect(\"..\\\\..\\\\Formular Test.aspx?nume_curs=\" + numeCurs.Text );",

"    }",
" ",
"    protected void adauga_videoclip_click(object sender, EventArgs e)",
"    {",
"           Response.Redirect(\"..\\\\..\\\\Formular Videoclip.aspx?nume_curs=\" + numeCurs.Text );",
"    }",
"}",
                             };

        System.IO.File.WriteAllLines(Server.MapPath("\\Cursuri\\" + numeCurs.Text + "\\" + numeCurs.Text + "_administrator.aspx.cs"), codeLines);
    }

}
