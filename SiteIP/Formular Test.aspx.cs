using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Forma_Test : System.Web.UI.Page
{

    Auxiliare a = new Auxiliare();
    List<TextBox> intrebari = new List<TextBox>();
    List<TextBox> numarRaspunsuri = new List<TextBox>();
    List<List<CheckBox>> bifat = new List<List<CheckBox>>();
    List<List<TextBox>> raspunsuri = new List<List<TextBox>>();
    List<List<string>> asd = new List<List<string>> { new List<string> { "1", "2" }, new List<string> {"3 ", "4"} };
    string nume_curs = null;
    int id_curs;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        selecteazaNumeCurs();
        selecteazaIdCurs();
        if (IsPostBack)
        {
            if((bool)Session["intrebari"] == true) {
                intrebari = (List<TextBox>)Session["lista_intrebari"];
                numarRaspunsuri = (List<TextBox>)Session["lista_numarRaspunsuri"];
                readaugaIntrebari();
            }
            if((bool)Session["teste"] == true) {
                bifat = (List<List<CheckBox>>)Session["lista_bifat"];
                raspunsuri = (List<List<TextBox>>)Session["lista_raspunsuri"];
                readaugaRaspunsuri();
            }
        }
        else
        {
            Session["intrebari"] = false;
            Session["teste"] = false;
        }
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

    protected void genereazaIntrebari(object sender, EventArgs e)
    {
        adaugaIntrebari();
    }

    private void readaugaIntrebari()
    {
        Table tabel_intrebari = new Table();
        tabel_intrebari.ID = "tabel_intrebari";

        for (int i = 0; i < int.Parse(numarIntrebari.Text); i++)
        {
            TableRow rand_intrebare = new TableRow();
            TableCell celula_intrebare = new TableCell();
            celula_intrebare.HorizontalAlign = HorizontalAlign.Center;
            celula_intrebare.Attributes.Add("style", "padding: 10px");

            TableRow rand_numar_raspuns = new TableRow();
            TableCell celula_numar_raspuns = new TableCell();
            celula_numar_raspuns.HorizontalAlign = HorizontalAlign.Center;
            celula_numar_raspuns.Attributes.Add("style", "padding: 10px");

            celula_intrebare.Controls.Add(intrebari[i]);
            celula_numar_raspuns.Controls.Add(numarRaspunsuri[i]);

            rand_intrebare.Controls.Add(celula_intrebare);
            rand_numar_raspuns.Controls.Add(celula_numar_raspuns);

            tabel_intrebari.Controls.Add(rand_intrebare);
            tabel_intrebari.Controls.Add(rand_numar_raspuns);
        }

        TableRow rand_tabel = new TableRow();
        TableCell celula_tabel = new TableCell();
        celula_tabel.HorizontalAlign = HorizontalAlign.Center;
        celula_tabel.ColumnSpan = 2;
        celula_tabel.Attributes.Add("style", "padding: 10px");

        celula_tabel.Controls.Add(tabel_intrebari);
        rand_tabel.Controls.Add(celula_tabel);

        TableRow rand_buton_adaugare = new TableRow();
        TableCell celula_buton_creaza = new TableCell();
        celula_buton_creaza.HorizontalAlign = HorizontalAlign.Center;
        celula_buton_creaza.ColumnSpan = 2;
        celula_buton_creaza.Attributes.Add("style", "padding: 10px");

        Button buton_creazaSchelet = new Button();
        buton_creazaSchelet.Text = "Genereaza Raspunsuri";
        buton_creazaSchelet.ID = "buton_raspunsuri";
        buton_creazaSchelet.Click += genereazaRaspunsuri;

        celula_buton_creaza.Controls.Add(buton_creazaSchelet);
        rand_buton_adaugare.Controls.Add(celula_buton_creaza);

        tabel_generare.Controls.Add(rand_tabel);
        tabel_generare.Controls.Add(rand_buton_adaugare);
    }

    private void adaugaIntrebari()
    {
        Session["intrebari"] = true;
        Table tabel_intrebari = new Table();
        tabel_intrebari.ID = "tabel_intrebari";

        // Adaugam fiecare intrebare si numarul raspunsurilor;
        for (int i = 0; i < int.Parse(numarIntrebari.Text); i++)
        {
            TableRow rand_intrebare = new TableRow();
            TableCell celula_intrebare = new TableCell();
            celula_intrebare.HorizontalAlign = HorizontalAlign.Center;
            celula_intrebare.Attributes.Add("style", "padding: 10px");

            TableRow rand_numar_raspuns = new TableRow();
            TableCell celula_numar_raspuns = new TableCell();
            celula_numar_raspuns.HorizontalAlign = HorizontalAlign.Center;
            celula_numar_raspuns.Attributes.Add("style", "padding: 10px");

            TextBox intrebare = new TextBox();
            intrebare.ID = "intrebare" + i;
            intrebare.Attributes.Add("placeholder", "Intrebare");
            intrebare.Width = new Unit("500");
            intrebari.Add(intrebare);

            TextBox numar_raspunsuri = new TextBox();
            numar_raspunsuri.ID = "numar_raspunsuri" + i;
            numar_raspunsuri.Attributes.Add("placeholder", "Numar Raspunsuri");
            numar_raspunsuri.Width = new Unit("250");
            numarRaspunsuri.Add(numar_raspunsuri);

            celula_intrebare.Controls.Add(intrebare);
            celula_numar_raspuns.Controls.Add(numar_raspunsuri);

            rand_intrebare.Controls.Add(celula_intrebare);
            rand_numar_raspuns.Controls.Add(celula_numar_raspuns);

            tabel_intrebari.Controls.Add(rand_intrebare);
            tabel_intrebari.Controls.Add(rand_numar_raspuns);
        }

        TableRow rand_tabel = new TableRow();
        TableCell celula_tabel = new TableCell();
        celula_tabel.HorizontalAlign = HorizontalAlign.Center;
        celula_tabel.ColumnSpan = 2;
        celula_tabel.Attributes.Add("style", "padding: 10px");

        celula_tabel.Controls.Add(tabel_intrebari);
        rand_tabel.Controls.Add(celula_tabel);

        TableRow rand_buton_adaugare = new TableRow();
        TableCell celula_buton_creaza = new TableCell();
        celula_buton_creaza.HorizontalAlign = HorizontalAlign.Center;
        celula_buton_creaza.ColumnSpan = 2;
        celula_buton_creaza.Attributes.Add("style", "padding: 10px");

        Button buton_creazaSchelet = new Button();
        buton_creazaSchelet.Text = "Genereaza Raspunsuri";
        buton_creazaSchelet.ID = "buton_raspunsuri";
        buton_creazaSchelet.Click += genereazaRaspunsuri;

        celula_buton_creaza.Controls.Add(buton_creazaSchelet);
        rand_buton_adaugare.Controls.Add(celula_buton_creaza);

        tabel_generare.Controls.Add(rand_tabel);
        tabel_generare.Controls.Add(rand_buton_adaugare);

        // Cream variabilele de sesiune pentru listele de TextBox-uri
        Session["lista_intrebari"] = intrebari;
        Session["lista_numarRaspunsuri"] = numarRaspunsuri;
    }

    private void readaugaRaspunsuri()
    {
        Table tabel_intrebari = new Table();
        tabel_intrebari.ID = "tabel_intrebari_raspunsuri";

        for (int i = 0; i < int.Parse(numarIntrebari.Text); i++)
        {
            TableRow rand_intrebare = new TableRow();
            TableCell celula_intrebare = new TableCell();
            celula_intrebare.HorizontalAlign = HorizontalAlign.Center;
            celula_intrebare.Attributes.Add("style", "padding: 10px");

            TableRow rand_numar_raspuns = new TableRow();
            TableCell celula_numar_raspuns = new TableCell();
            celula_numar_raspuns.HorizontalAlign = HorizontalAlign.Center;
            celula_numar_raspuns.Attributes.Add("style", "padding: 10px");

            Label intrebare = new Label();
            intrebare.ID = "intrebare" + i + "'";
            intrebare.Attributes.Add("placeholder", "Intrebare");
            intrebare.Width = new Unit("500");
            intrebare.Text = intrebari[i].Text;

            Table tabel_raspunsuri = new Table();
            tabel_raspunsuri.ID = "tabel_raspunsuri" + i;

            for (int j = 0; j < int.Parse(numarRaspunsuri[i].Text); j++)
            {
                TableRow rand_raspuns = new TableRow();
                TableCell celula_raspuns = new TableCell();
                celula_raspuns.HorizontalAlign = HorizontalAlign.Center;
                celula_raspuns.Attributes.Add("style", "padding: 10px");

                celula_raspuns.Controls.Add(bifat[i][j]);
                celula_raspuns.Controls.Add(raspunsuri[i][j]);
                rand_raspuns.Controls.Add(celula_raspuns);
                tabel_raspunsuri.Controls.Add(rand_raspuns);
            }

            celula_intrebare.Controls.Add(intrebare);
            celula_numar_raspuns.Controls.Add(tabel_raspunsuri);

            rand_intrebare.Controls.Add(celula_intrebare);
            rand_numar_raspuns.Controls.Add(celula_numar_raspuns);

            tabel_intrebari.Controls.Add(rand_intrebare);
            tabel_intrebari.Controls.Add(rand_numar_raspuns);
        }

        TableRow rand_tabel = new TableRow();
        TableCell celula_tabel = new TableCell();
        celula_tabel.HorizontalAlign = HorizontalAlign.Center;
        celula_tabel.ColumnSpan = 2;
        celula_tabel.Attributes.Add("style", "padding: 10px");

        celula_tabel.Controls.Add(tabel_intrebari);
        rand_tabel.Controls.Add(celula_tabel);

        TableRow rand_buton_adaugare = new TableRow();
        TableCell celula_buton_creaza = new TableCell();
        celula_buton_creaza.HorizontalAlign = HorizontalAlign.Center;
        celula_buton_creaza.ColumnSpan = 2;
        celula_buton_creaza.Attributes.Add("style", "padding: 10px");

        Button buton_creazaSchelet = new Button();
        buton_creazaSchelet.Text = "Creaza Test";
        buton_creazaSchelet.ID = "buton_creaza";
        buton_creazaSchelet.Click += creazaTest;

        celula_buton_creaza.Controls.Add(buton_creazaSchelet);
        rand_buton_adaugare.Controls.Add(celula_buton_creaza);

        tabel_generare.Controls.Add(rand_tabel);
        tabel_generare.Controls.Add(rand_buton_adaugare);
    }

    private void adaugaRaspunsuri()
    {
        Session["teste"] = true;
        Table tabel_intrebari = new Table();
        tabel_intrebari.ID = "tabel_intrebari_raspunsuri";

        for (int i = 0; i < int.Parse(numarIntrebari.Text); i++)
        {
            TableRow rand_intrebare = new TableRow();
            TableCell celula_intrebare = new TableCell();
            celula_intrebare.HorizontalAlign = HorizontalAlign.Center;
            celula_intrebare.Attributes.Add("style", "padding: 10px");

            TableRow rand_numar_raspuns = new TableRow();
            TableCell celula_numar_raspuns = new TableCell();
            celula_numar_raspuns.HorizontalAlign = HorizontalAlign.Center;
            celula_numar_raspuns.Attributes.Add("style", "padding: 10px");

            Label intrebare = new Label();
            intrebare.ID = "intrebare" + i + "'";
            intrebare.Attributes.Add("placeholder", "Intrebare");
            intrebare.Width = new Unit("500");
            intrebare.Text = intrebari[i].Text;

            Table tabel_raspunsuri = new Table();
            tabel_raspunsuri.ID = "tabel_raspunsuri"+i;

            bifat.Add(new List<CheckBox>());
            raspunsuri.Add(new List<TextBox>());

            for (int j = 0; j < int.Parse(numarRaspunsuri[i].Text); j++)
            {
                TableRow rand_raspuns = new TableRow();
                TableCell celula_raspuns = new TableCell();
                celula_raspuns.HorizontalAlign = HorizontalAlign.Center;
                celula_raspuns.Attributes.Add("style", "padding: 10px");

                CheckBox c = new CheckBox();
                c.ID = "checkbox" + i + "" + j;
                bifat[i].Add(c);

                TextBox raspuns = new TextBox();
                raspuns.ID = "raspuns" + i + "" + j;
                raspuns.Attributes.Add("placeholder", "Raspuns");
                raspuns.Width = new Unit("500");
                raspunsuri[i].Add(raspuns);

                celula_raspuns.Controls.Add(c);
                celula_raspuns.Controls.Add(raspuns);
                rand_raspuns.Controls.Add(celula_raspuns);
                tabel_raspunsuri.Controls.Add(rand_raspuns);
            }

            celula_intrebare.Controls.Add(intrebare);
            celula_numar_raspuns.Controls.Add(tabel_raspunsuri);

            rand_intrebare.Controls.Add(celula_intrebare);
            rand_numar_raspuns.Controls.Add(celula_numar_raspuns);

            tabel_intrebari.Controls.Add(rand_intrebare);
            tabel_intrebari.Controls.Add(rand_numar_raspuns);
        }

        TableRow rand_tabel = new TableRow();
        TableCell celula_tabel = new TableCell();
        celula_tabel.HorizontalAlign = HorizontalAlign.Center;
        celula_tabel.ColumnSpan = 2;
        celula_tabel.Attributes.Add("style", "padding: 10px");

        celula_tabel.Controls.Add(tabel_intrebari);
        rand_tabel.Controls.Add(celula_tabel);

        TableRow rand_buton_adaugare = new TableRow();
        TableCell celula_buton_creaza = new TableCell();
        celula_buton_creaza.HorizontalAlign = HorizontalAlign.Center;
        celula_buton_creaza.ColumnSpan = 2;
        celula_buton_creaza.Attributes.Add("style", "padding: 10px");

        Button buton_creazaSchelet = new Button();
        buton_creazaSchelet.Text = "Creaza Test";
        buton_creazaSchelet.ID = "buton_creaza";
        buton_creazaSchelet.Click += creazaTest;

        celula_buton_creaza.Controls.Add(buton_creazaSchelet);
        rand_buton_adaugare.Controls.Add(celula_buton_creaza);

        tabel_generare.Controls.Add(rand_tabel);
        tabel_generare.Controls.Add(rand_buton_adaugare);

        // Cream variabilele de sesiune pentru listele de TextBox-uri si CheckBox-uri
        Session["lista_bifat"] = bifat;
        Session["lista_raspunsuri"] = raspunsuri;
    }

    protected void genereazaRaspunsuri(object sender, EventArgs e)
    {
        Button buton_adauga = (Button)sender;
        adaugaRaspunsuri();
    }

    private void adaugaInBazaDeDate()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "Insert into [Test] values (" + (maxIdTest() + 1) + ", " + id_curs + ", '" + numeTest.Text + "',  CONVERT(VARCHAR(10), GETDATE(), 10), 0 );";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }

    private int maxIdTest()
    {
        if (numarTeste() == 0)
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
            comanda.CommandText = "Select MAX(id_test) from Test;";
            sdr = comanda.ExecuteReader();
            sdr.Read();
            int max = int.Parse(sdr.GetValue(0).ToString());
            conexiune.Close();
            return max;
        }
    }

    private int numarTeste()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "Select 1 from Test;";
        sdr = comanda.ExecuteReader();
        int i = 0;
        while (sdr.Read())
        {
            i++;
        }
        conexiune.Close();
        return i;
    }

    protected void creazaTest(object sender, EventArgs e)
    {
        // Adauga Testul in baza de date;
        adaugaInBazaDeDate();

        // Creaza pagina pentru Test;
        creazaASPX();
        creazaC();

        // Stergem variabilele de sesiune;
        Session.Remove("intrebari");
        Session.Remove("teste");
        Session.Remove("lista_intrebari");
        Session.Remove("lista_numarRaspunsuri");
        Session.Remove("lista_bifat");
        Session.Remove("lista_raspunsuri");
    }

    private void creazaASPX()
    {
        String[] aspxLines = {
"<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeFile=\"" + numeTest.Text + ".aspx.cs\" Inherits=\"" + numeTest.Text + "\" MasterPageFile=\"~/MasterPage.master\"%>",
" ",
"<asp:Content runat=\"server\" ID=\"Content1\" ContentPlaceHolderID=\"head\">",
"</asp:Content>",
" ",
"<asp:Content runat=\"server\" ID=\"content\" ContentPlaceHolderID=\"ContentPlaceHolder1\">",
"       <asp:Table ID=\"formular\" runat=\"server\" Width=\"80%\" style=\"margin-left: 10%\">",
"            <asp:TableHeaderRow Width=\"100%\">",
"                <asp:TableHeaderCell HorizontalAlign=\"Center\" style=\"padding:10px\" Width=\"50%\">",
"                    <asp:Label ID=\"numeTest\" runat=\"server\" Text=\"" + numeTest.Text + "\" Width=\"50%\">",
"                    </asp:Label>",
"                </asp:TableHeaderCell>",
"                <asp:TableHeaderCell HorizontalAlign=\"Center\" style=\"padding:10px\" Width=\"50%\">",
"                    <asp:Label ID=\"numeCurs\" runat=\"server\" Text=\"" + nume_curs + "\" Width=\"50%\">",
"                    </asp:Label>",
"                </asp:TableHeaderCell>",
"            </asp:TableHeaderRow>",
"           <asp:TableRow>",
"               <asp:TableCell ID=\"celula_test\" HorizontalAlign=\"Center\" ColumnSpan=\"2\">",
" ",                   
"               </asp:TableCell>",
"           </asp:TableRow>",
"           <asp:TableRow>",
"               <asp:TableCell HorizontalAlign=\"Center\" ColumnSpan=\"2\">",
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
"               </asp:TableCell>",
"           </asp:TableRow>",
"        </asp:Table>",
"</asp:Content>",
" "
                             };
        System.IO.File.WriteAllLines(Server.MapPath("\\Cursuri\\" + nume_curs + "\\" + numeTest.Text + ".aspx"), aspxLines);
    }

    private string creazaStringIntrebari()
    {
        string s = " {";
        for (int i = 0; i < intrebari.Count - 1; i ++)
        {
            s += " \"" + intrebari[i].Text + "\",";
        }
        s += " \"" + intrebari[intrebari.Count - 1].Text + "\"";
        s += " }";
        return s;
    }

    private string creazaStringRaspunsuri()
    {
        string s = " {";
        for (int i = 0; i < raspunsuri.Count - 1; i++ )
        {
            s += " new List<string> { ";
            for (int j = 0; j < raspunsuri[i].Count - 1; j ++ )
            {
                s += " \"" + raspunsuri[i][j].Text + "\",";
            }
            s += " \"" + raspunsuri[i][raspunsuri[i].Count - 1].Text + "\"";
            s += " }, ";
        }
        s += " new List<string> { ";
        for (int j = 0; j < raspunsuri[raspunsuri.Count - 1].Count - 1; j++)
        {
            s += " \"" + raspunsuri[raspunsuri.Count - 1][j].Text + "\",";
        }
        s += " \"" + raspunsuri[raspunsuri.Count - 1][raspunsuri[raspunsuri.Count - 1].Count - 1].Text + "\"";
        s += " } ";
        s += " }";
        return s;
    }

    private string toString(CheckBox checkbox)
    {
        if (checkbox.Checked == true)
        {
            return "true";
        }
        else
        {
            return "false";
        }
    }

    private string creazaStringRaspunsuri_corecte()
    {
        string s = " {";
        for (int i = 0; i < bifat.Count - 1; i++)
        {
            s += " new List<bool> { ";
            for (int j = 0; j < bifat[i].Count - 1; j++)
            {
                s += " " + toString(bifat[i][j]) + ",";
            }
            s += " " + toString(bifat[i][bifat[i].Count - 1]) + "";
            s += " }, ";
        }
        s += " new List<bool> { ";
        for (int j = 0; j < bifat[bifat.Count - 1].Count - 1; j++)
        {
            s += " " + toString(bifat[bifat.Count - 1][j]) + ",";
        }
        s += " " + toString(bifat[bifat.Count - 1][bifat[bifat.Count - 1].Count - 1]) + "";
        s += " } ";
        s += " }";
        return s;
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
"public partial class " + numeTest.Text + " : System.Web.UI.Page",
"{",
"    Auxiliare a = new Auxiliare();",
"    int id_test;",
"    int id_utilizator;",
"    int id_curs;",
"    int nota_data;",
"    double media_notelor_test;",
"    private string email;",
"    List<string> intrebari = new List<string> " + creazaStringIntrebari() + ";",
"    List<List<string>> raspunsuri = new List<List<string>> " + creazaStringRaspunsuri() + " ;",
"    List<List<bool>> raspunsuri_corecte = new List<List<bool>> " + creazaStringRaspunsuri_corecte() + " ;",
" ",
"    protected void Page_Load(object sender, EventArgs e)",
"    {",
"        if (!IsPostBack)",
"        {",
"            culegeDate();",
"            selecteazaIdUtilizator();",
"            selecteazaIdTest();",
"            selecteazaIdCurs();",
"            selecteazaNotaDataTest();",
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
"        switch (nota_data)",
"        {",
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
"    private void selecteazaNotaDataTest()",
"    {",
"        SqlCommand comanda = new SqlCommand();",
"        SqlConnection conexiune;",
"        conexiune = new SqlConnection(a.string_bazadedate);",
"        comanda.Connection = conexiune;",
"        comanda.Connection.Open();",
"        SqlDataReader sdr;",
"        comanda.CommandText = \"SELECT nota_data FROM Utilizator_Test WHERE id_utilizator = \" + id_utilizator + \" AND id_test = \" + id_test + \";\";",
"        sdr = comanda.ExecuteReader();",
"        sdr.Read();",
"        nota_data = int.Parse(sdr.GetValue(0).ToString());",
"        conexiune.Close();",
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
"    private void selecteazaIdTest()",
"    {",
"        SqlCommand comanda = new SqlCommand();",
"        SqlConnection conexiune;",
"        conexiune = new SqlConnection(a.string_bazadedate);",
"        comanda.Connection = conexiune;",
"        comanda.Connection.Open();",
"        SqlDataReader sdr;",
"        comanda.CommandText = \"SELECT id_videoclip FROM Videoclip WHERE nume = \'\" + numeTest.Text + \"\';\";",
"        sdr = comanda.ExecuteReader();",
"        sdr.Read();",
"        id_test = int.Parse(sdr.GetValue(0).ToString());",
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
"    private void actualizeazaNotaDataTest(int nota)",
"    {",
"        SqlCommand comanda = new SqlCommand();",
"        SqlConnection conexiune;",
"        conexiune = new SqlConnection(a.string_bazadedate);",
"        comanda = new SqlCommand();",
"        comanda.Connection = conexiune;",
"        comanda.Connection.Open();",
"        comanda.CommandText = \"UPDATE [Utilizator_Test] SET nota_data = \" + nota + \" WHERE id_utilizator = \" + id_utilizator + \" AND id_test = \" + id_test + \";\";",
"        comanda.ExecuteNonQuery();",
"        conexiune.Close();",
"    }",
" ",
"    private void selecteazaMediaNotelorTest()",
"    {",
"        SqlCommand comanda = new SqlCommand();",
"        SqlConnection conexiune;",
"        conexiune = new SqlConnection(a.string_bazadedate);",
"        comanda.Connection = conexiune;",
"        comanda.Connection.Open();",
"        SqlDataReader sdr;",
"        comanda.CommandText = \"SELECT AVG(nota_data) FROM Utilizator_Test WHERE id_test = \" + id_test + \";\";",
"        sdr = comanda.ExecuteReader();",
"        sdr.Read();",
"        media_notelor_test = int.Parse(sdr.GetValue(0).ToString());",
"        conexiune.Close();",
"    }",
" ",
"    private void actualizeazaMediaNotelorTest(int nota)",
"    {",
"        SqlCommand comanda = new SqlCommand();",
"        SqlConnection conexiune;",
"        conexiune = new SqlConnection(a.string_bazadedate);",
"        comanda = new SqlCommand();",
"        comanda.Connection = conexiune;",
"        comanda.Connection.Open();",
"        comanda.CommandText = \"UPDATE [Test] SET media_notelor = \" + media_notelor_test + \" WHERE id_test = \" + id_test + \" AND id_curs = \" + id_curs + \";\";",
"        comanda.ExecuteNonQuery();",
"        conexiune.Close();",
"    }",
" ",
"    protected void selectare(object sender, EventArgs e)",
"    {",
"        if (id_nota1.Selected == true)",
"        {",
"            actualizeazaNotaDataTest(1);",
"            selecteazaMediaNotelorTest();",
"            actualizeazaMediaNotelorTest(1);",
"        }",
"        else if (id_nota2.Selected == true)",
"        {",
"            actualizeazaNotaDataTest(2);",
"            selecteazaMediaNotelorTest();",
"            actualizeazaMediaNotelorTest(2);",
"        }",
"        else if (id_nota3.Selected == true)",
"        {",
"            actualizeazaNotaDataTest(3);",
"            selecteazaMediaNotelorTest();",
"            actualizeazaMediaNotelorTest(3);",
"        }",
"        else if (id_nota4.Selected == true)",
"        {",
"            actualizeazaNotaDataTest(4);",
"            selecteazaMediaNotelorTest();",
"            actualizeazaMediaNotelorTest(4);",
"        }",
"        else",
"        {",
"            actualizeazaNotaDataTest(5);",
"            selecteazaMediaNotelorTest();",
"            actualizeazaMediaNotelorTest(5);",
"        }",
"    }",
" ",
"}",
" "
                             };

        System.IO.File.WriteAllLines(Server.MapPath("\\Cursuri\\" + nume_curs + "\\" + numeTest.Text + ".aspx.cs"), codeLines);
    }

}
