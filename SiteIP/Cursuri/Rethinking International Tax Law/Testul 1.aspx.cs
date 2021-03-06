using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
 
public partial class Testul_1 : System.Web.UI.Page
{
    Auxiliare a = new Auxiliare();
    int id_test;
    int id_utilizator;
    int id_curs;
    int nota_data;
    int numar_note = 0;
    int numar_raspunsuri = 0;
    int numar_raspunsuri_corecte = 0;
    double nota_obtinuta;
    double media_notelor_test;
    private string email;
    List<List<CheckBox>> bifat = new List<List<CheckBox>>();
    List<string> intrebari = new List<string>  { "In video-ul 1 din aceast curs, am vazut presedintele Comitetului Conturi Publice, Margaret Hodge, si vicepresedintele Google din Marea Britanie, Matt Brittin, schimb opinii. Care dintre urmatoarele afirmatii, cu privire la discutia lor este adevarata?", "Planificarea fiscala internationala este:", "De cand a fost acolo un potential de planificare fiscala in temeiul dreptului fiscal international?", "De ce criza financiara a dus la opinia publica cerand multinationalelor sa contribue partea lor echitabila a taxei in jurisdictiile afacerile lor aflate in plina desfasurare?", "Ce inseamna OCDE ?", "Care fost organizatia care a finalizat primul tratat de impozit model?" };
    List<List<string>> raspunsuri = new List<List<string>>  { new List<string> {  " Margaret Hodge acuza Google  de frauda fiscala internationala in Marea Britanie", " Margaret Hodge acuza Google de impozitare a clientilor din Marea Britanie, la o rata mai mare decat a celor din Bermuda", " Margaret Hodge a luat la intrebari strategiile internationale fiscale ale Google ", " Margaret Hodge a luat la intrebari angajamentul Google de a evita dubla impozitare internationala" },  new List<string> {  "Interzisa", " Nu impotriva legii", "Ilicita", "Ilegala" },  new List<string> {  " De la sfarsitul anilor 80", " De la sfarsitul anilor 90", " De cand au fost stabilite bazele dreptului fiscal international", " De cand cu concluziile al doilea razboi mondial" },  new List<string> {  " Cresterea in activitati a multinationalelor in mod viabil in tarile afectate financiar", " Masurile de austeritate care au dus in puterea de cheltuieli inferioare a publicului", " Cresterea numarului de consilieri fiscali", " Mai mult timp rezulta examinarea si detaliarea activitatilor multinationale" },  new List<string> {  " Organizatia pentru Dezvoltare Economica si Coerenta", " Organizatia pentru Cooperare si Dezvoltare Economica", " Organizatia pentru Evaluarea Colectiilor si distributiilor", " Organizarea Economica pentru tarile dezvoltare" },  new List<string> {  " Liga Natiunilor", "OECD", "IRS", " Natiunile Unite" }  } ;
    List<List<bool>> raspunsuri_corecte = new List<List<bool>>  { new List<bool> {  false, false, true, false },  new List<bool> {  false, true, false, false },  new List<bool> {  false, true, false, false },  new List<bool> {  false, true, false, false },  new List<bool> {  false, false, false, false },  new List<bool> {  true, false, false, false }  } ;
    Table tabel_intrebari_raspunsuri = new Table();
    Button buton_evalueaza = new Button();
    public bool testInceput = false;
 
    // Timp de rezolvare;
    int timp_rezolvare;
 
    // Cate minute dureaza testul;
    public int minute_bazaDeDate = 0;
 
    // Cate ore dureaza testul;
    public int ore_bazaDeDate = 0;
 
    DateTime Start;
    DateTime End;

    protected void Page_Load(object sender, EventArgs e)
    {
        afiseazaIntrebarileSiRaspunsurile();
        culegeDate();
        selecteazaIdUtilizator();
        selecteazaIdCurs();
        selecteazaIdTest();
        selecteazaTimpTest();
        timpTest();
        afiseazaTimpRezolvare();
        if (!IsPostBack)
        {
            numarNote();
            if (numar_note == 0)
            {
                adaugaInBazaDeDate();
            }
            selecteazaNotaDataTest();
            afiseazaNotaData();
            Session["Test_inceput"] = false;
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
        comanda.CommandText = "Insert into [Utilizator_Test] values (" + id_utilizator + ", " + id_test + ",  CONVERT(VARCHAR(10), GETDATE(), 10), " + 0 + ", " + 0 + ");";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }

    private void numarNote()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT 1 FROM Utilizator_Test WHERE id_utilizator = " + id_utilizator + " AND id_test = " + id_test + ";";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            numar_note++;
        }
        conexiune.Close();
    }

    private void afiseazaIntrebarileSiRaspunsurile()
    {
        //Table tabel_intrebari_raspunsuri = new Table();
        tabel_intrebari_raspunsuri.ID = "tabel_intrebari_raspunsuri";
        tabel_intrebari_raspunsuri.Style.Add("display", "none");

        for (int i = 0; i < intrebari.Count; i++)
        {
            TableRow rand_intrebare = new TableRow();
            TableCell celula_intrebare = new TableCell();
            celula_intrebare.HorizontalAlign = HorizontalAlign.Center;
            celula_intrebare.Attributes.Add("style", "padding: 10px");

            TableRow rand_raspuns = new TableRow();
            TableCell celula_raspuns = new TableCell();
            celula_raspuns.HorizontalAlign = HorizontalAlign.Center;
            celula_raspuns.Attributes.Add("style", "padding: 10px");

            Label intrebare = new Label();
            intrebare.ID = "intrebare" + i;
            intrebare.Width = new Unit("500");
            intrebare.Text = intrebari[i];

            Table tabel_raspunsuri = new Table();
            tabel_raspunsuri.ID = "tabel_raspunsuri" + i;

            bifat.Add(new List<CheckBox>());

            for (int j = 0; j < raspunsuri[i].Count; j++)
            {
                TableRow rand_raspuns_i = new TableRow();
                TableCell celula_raspuns_i = new TableCell();
                celula_raspuns_i.HorizontalAlign = HorizontalAlign.Center;
                celula_raspuns_i.Attributes.Add("style", "padding: 10px");

                CheckBox c = new CheckBox();
                c.ID = "checkbox" + i + "" + j;
                bifat[i].Add(c);

                Label raspuns = new Label();
                raspuns.ID = "raspuns" + i + "" + j;
                raspuns.Width = new Unit("500");
                raspuns.Text = raspunsuri[i][j];

                celula_raspuns_i.Controls.Add(c);
                celula_raspuns_i.Controls.Add(raspuns);
                rand_raspuns_i.Controls.Add(celula_raspuns_i);
                tabel_raspunsuri.Controls.Add(rand_raspuns_i);
            }

            celula_intrebare.Controls.Add(intrebare);
            celula_raspuns.Controls.Add(tabel_raspunsuri);

            rand_intrebare.Controls.Add(celula_intrebare);
            rand_raspuns.Controls.Add(celula_raspuns);

            tabel_intrebari_raspunsuri.Controls.Add(rand_intrebare);
            tabel_intrebari_raspunsuri.Controls.Add(rand_raspuns);
        }

        TableRow rand_tabel = new TableRow();
        TableCell celula_tabel = new TableCell();
        celula_tabel.HorizontalAlign = HorizontalAlign.Center;
        celula_tabel.ColumnSpan = 2;
        celula_tabel.Attributes.Add("style", "padding: 10px");

        celula_tabel.Controls.Add(tabel_intrebari_raspunsuri);
        rand_tabel.Controls.Add(celula_tabel);

        TableRow rand_buton_evaluare = new TableRow();
        TableCell celula_buton_evaluare = new TableCell();
        celula_buton_evaluare.HorizontalAlign = HorizontalAlign.Center;
        celula_buton_evaluare.ColumnSpan = 2;
        celula_buton_evaluare.Attributes.Add("style", "padding: 10px");

        //Button buton_evalueaza = new Button();
        buton_evalueaza.Text = "Evalueaza";
        buton_evalueaza.ID = "buton_evalueaza";
        buton_evalueaza.Click += evalueazaTest;

        celula_buton_evaluare.Controls.Add(buton_evalueaza);
        rand_buton_evaluare.Controls.Add(celula_buton_evaluare);

        celula_test.Controls.Add(rand_tabel);
        celula_test.Controls.Add(rand_buton_evaluare);
    }

    private void obtineRezultat()
    {
        for (int i = 0; i < bifat.Count; i++)
        {
            for (int j = 0; j < bifat[i].Count; j++)
            {
                numar_raspunsuri++;
                if (bifat[i][j].Checked == raspunsuri_corecte[i][j])
                {
                    numar_raspunsuri_corecte++;
                }
            }
        }
        nota_obtinuta = (double)numar_raspunsuri_corecte / (double)numar_raspunsuri;
    }

    private void actualizeazaLabel()
    {
        celula_rezultat.Text = " Rezultat: " + nota_obtinuta;
    }

    private void insereazaRezultatInBazaDeDate()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "UPDATE [Utilizator_Test] SET nota_obtinuta = " + nota_obtinuta + " WHERE id_utilizator = " + id_utilizator + " AND id_test = " + id_test + ";";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }

    protected void evalueazaTest(object sender, EventArgs e)
    {
        // Testul s-a terminat;
        testInceput = false;

        obtineRezultat();
        actualizeazaLabel();
        insereazaRezultatInBazaDeDate();

        // Stergem variabilele de sesiune;
        Session.Remove("Test_inceput");
    }

    private void culegeDate()
    {
        email = (string)Session["email"];
    }

    private void afiseazaNotaData()
    {
        switch (nota_data)
        {
            case 1:
                id_nota1.Selected = true;
                break;
            case 2:
                id_nota2.Selected = true;
                break;
            case 3:
                id_nota3.Selected = true;
                break;
            case 4:
                id_nota4.Selected = true;
                break;
            case 5:
                id_nota5.Selected = true;
                break;
        }
    }

    private void selecteazaNotaDataTest()
    {
        if (numar_note == 0)
        {
            nota_data = 0;
        }
        else
        {
            SqlCommand comanda = new SqlCommand();
            SqlConnection conexiune;
            conexiune = new SqlConnection(a.string_bazadedate);
            comanda.Connection = conexiune;
            comanda.Connection.Open();
            SqlDataReader sdr;
            comanda.CommandText = "SELECT nota_data FROM Utilizator_Test WHERE id_utilizator = " + id_utilizator + " AND id_test = " + id_test + ";";
            sdr = comanda.ExecuteReader();
            sdr.Read();
            nota_data = int.Parse(sdr.GetValue(0).ToString());
            conexiune.Close();
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
        comanda.CommandText = "SELECT id_curs FROM Curs WHERE nume = '" + numeCurs.Text + "';";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        id_curs = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
    }

    private void selecteazaIdTest()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT id_test FROM Test WHERE nume = '" + numeTest.Text + "' AND id_curs = " + id_curs + ";";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        id_test = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
    }

    private void timpTest()
    {
        minute_bazaDeDate = timp_rezolvare % 60;
        ore_bazaDeDate = timp_rezolvare / 60;
    }

    private void afiseazaTimpRezolvare()
    {
        id_timp_rezolvare.Text = "Timp rezolvare: " + ore_bazaDeDate + " ore " + minute_bazaDeDate + " minute ";
    }

    private void selecteazaTimpTest()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT timp_rezolvare FROM Test WHERE id_test = " + id_test + ";";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        timp_rezolvare = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
    }

    private void selecteazaIdUtilizator()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT id_utilizator FROM Utilizator WHERE email = '" + email + "';";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        id_utilizator = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
    }

    private void actualizeazaNotaDataTest(int nota)
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "UPDATE [Utilizator_Test] SET nota_data = " + nota + " WHERE id_utilizator = " + id_utilizator + " AND id_test = " + id_test + ";";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }

    private void selecteazaMediaNotelorTest()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT AVG(nota_data) FROM Utilizator_Test WHERE id_test = " + id_test + ";";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        media_notelor_test = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
    }

    private void actualizeazaMediaNotelorTest(int nota)
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "UPDATE [Test] SET media_notelor = " + media_notelor_test + " WHERE id_test = " + id_test + " AND id_curs = " + id_curs + ";";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }

    protected void selectare(object sender, EventArgs e)
    {
        if (id_nota1.Selected == true)
        {
            actualizeazaNotaDataTest(1);
            selecteazaMediaNotelorTest();
            actualizeazaMediaNotelorTest(1);
        }
        else if (id_nota2.Selected == true)
        {
            actualizeazaNotaDataTest(2);
            selecteazaMediaNotelorTest();
            actualizeazaMediaNotelorTest(2);
        }
        else if (id_nota3.Selected == true)
        {
            actualizeazaNotaDataTest(3);
            selecteazaMediaNotelorTest();
            actualizeazaMediaNotelorTest(3);
        }
        else if (id_nota4.Selected == true)
        {
            actualizeazaNotaDataTest(4);
            selecteazaMediaNotelorTest();
            actualizeazaMediaNotelorTest(4);
        }
        else
        {
            actualizeazaNotaDataTest(5);
            selecteazaMediaNotelorTest();
            actualizeazaMediaNotelorTest(5);
        }
    }

    protected void incepeTest(object sender, EventArgs e)
    {
        buton_start.Enabled = false;
        tabel_intrebari_raspunsuri.Style.Add("display", "inline-table");
        buton_evalueaza.Style.Add("display", "inline-table");
        Session["Test_inceput"] = true;
        testInceput = (bool)Session["Test_inceput"];
    }
}
 
