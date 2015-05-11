using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Facultati_recomandate_profil : System.Web.UI.Page
{
    Auxiliare a = new Auxiliare();
    private int id_utilizator;
    private int distanta_minima;
    private int distanta_maxima;
    private string email;
    private string data_nasterii;
    private string data_inregistrarii;

    // In cazul in care nu este inscris la niciun curs ne vom folosi doar de partea de date declarate de acesta;
    private List<int> id_facultati = new List<int>();
    private List<string> nume_facultati = new List<string>();
    private List<string> localitate_facultati = new List<string>();

    // Pentru fiecare curs la care utilizatorul este inscris vom crea o lista de referinte;
    private List<List<int>> id_referinta_facultate = new List<List<int>>();
    private List<List<string>> nume_referinta_facultate = new List<List<string>>();
    private List<List<string>> localitate_referinta_facultate = new List<List<string>>();

    // Id-urile cursurilor la care este inscris;
    private List<int> id_cursuri = new List<int>();

    // Cate videoclipuri au cursurile respective;
    private List<int> numar_videoclipuri = new List<int>();

    // Cate teste au cursurile respective;
    private List<int> numar_teste = new List<int>();

    // Care videoclipuri a vazut;
    private List<int> numar_videoclipuri_vazute = new List<int>();

    // Cate teste a dat;
    private List<int> numar_teste_date = new List<int>();

    // Media notelor date videoclipurilor;
    private List<double> media_notelor_date_videoclip = new List<double>();

    // Media notelor date testelor;
    private List<double> media_notelor_date_test = new List<double>();

    // Valorile care calculeaza scorurile fiecarei facultati;
    private int date_colectate;
    private int curs;
    private int judet;
    private int note;
    private int videoclipuri;
    private int teste;
    private int nota_curs;
    private int nota_data_videoclip;
    private int videoclipuri_vazute;
    private int nota_data_test;
    private int nota_test;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            culegeDate();
            selecteazaIdUtilizator();
            selecteazaCursurile();
            selecteazaNumarulVideoclipurilor();
            selecteazaNumarulTestelor();
            selecteazaNumarulVideoclipurilorVazute();
            selecteazaNumarulTestelorDate();
            selecteazaMediaNotelorDateVideoclip();
            selecteazaMediaNotelorDateTest();
            calculeazaDistantaMinima();
            calculeazaDistantaMaxima();
            selecteazaReferinteCurs();
            selecteazaValoriRecomandari();
            Response.Redirect("login.aspx?n=" + numar_videoclipuri_vazute[2]);
        }
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

    private void selecteazaNumarulVideoclipurilor()
    {
        for (int i = 0; i < id_cursuri.Count; i++)
        {
            SqlCommand comanda = new SqlCommand();
            SqlConnection conexiune;
            conexiune = new SqlConnection(a.string_bazadedate);
            comanda.Connection = conexiune;
            comanda.Connection.Open();
            SqlDataReader sdr;
            comanda.CommandText = "SELECT COUNT(*) FROM [Videoclip] WHERE id_curs = " + id_cursuri[i] + ";";
            sdr = comanda.ExecuteReader();
            sdr.Read();
            numar_videoclipuri.Add(int.Parse(sdr.GetValue(0).ToString()));
            conexiune.Close();
        }
    }

    private void selecteazaMediaNotelorDateVideoclip()
    {
        for (int i = 0; i < id_cursuri.Count; i++)
        {
            SqlCommand comanda = new SqlCommand();
            SqlConnection conexiune;
            conexiune = new SqlConnection(a.string_bazadedate);
            comanda.Connection = conexiune;
            comanda.Connection.Open();
            SqlDataReader sdr;
            comanda.CommandText = "SELECT AVG(nota_data) FROM Utilizator_Videoclip uv, Videoclip v WHERE v.id_curs = " + id_cursuri[i] + " AND v.id_videoclip = uv.id_videoclip AND uv.id_utilizator = " + id_utilizator + ";";
            sdr = comanda.ExecuteReader();
            sdr.Read();
            string aux = sdr.GetValue(0).ToString();
            if (aux == "" || aux == null)
            {
                media_notelor_date_test.Add(0);
            }
            else
            {
                media_notelor_date_videoclip.Add(double.Parse(aux));
            }
            conexiune.Close();
        }
    }

    private void selecteazaNumarulVideoclipurilorVazute()
    {
        for (int i = 0; i < id_cursuri.Count; i++)
        {
            SqlCommand comanda = new SqlCommand();
            SqlConnection conexiune;
            conexiune = new SqlConnection(a.string_bazadedate);
            comanda.Connection = conexiune;
            comanda.Connection.Open();
            SqlDataReader sdr;
            comanda.CommandText = "SELECT COUNT(*) FROM Utilizator_Videoclip uv, Videoclip v WHERE v.id_curs = " + id_cursuri[i] + " AND v.id_videoclip = uv.id_videoclip AND uv.id_utilizator = " + id_utilizator + ";";
            sdr = comanda.ExecuteReader();
            sdr.Read();
            numar_videoclipuri_vazute.Add(int.Parse(sdr.GetValue(0).ToString()));
            conexiune.Close();
        }
    }

    private void selecteazaMediaNotelorDateTest()
    {
        for (int i = 0; i < id_cursuri.Count; i++)
        {
            SqlCommand comanda = new SqlCommand();
            SqlConnection conexiune;
            conexiune = new SqlConnection(a.string_bazadedate);
            comanda.Connection = conexiune;
            comanda.Connection.Open();
            SqlDataReader sdr;
            comanda.CommandText = "SELECT AVG(nota_data) FROM Utilizator_Test ut, Test t WHERE t.id_curs = " + id_cursuri[i] + " AND t.id_test = ut.id_test AND ut.id_utilizator = " + id_utilizator + ";";
            sdr = comanda.ExecuteReader();
            sdr.Read();
            string aux = sdr.GetValue(0).ToString();
            if (aux == "" || aux == null)
            {
                media_notelor_date_test.Add(0);
            }
            else
            {
                media_notelor_date_test.Add(double.Parse(aux));
            }
            conexiune.Close();
        }
    }

    private void selecteazaNumarulTestelor()
    {
        for (int i = 0; i < id_cursuri.Count; i++)
        {
            SqlCommand comanda = new SqlCommand();
            SqlConnection conexiune;
            conexiune = new SqlConnection(a.string_bazadedate);
            comanda.Connection = conexiune;
            comanda.Connection.Open();
            SqlDataReader sdr;
            comanda.CommandText = "SELECT COUNT(*) FROM [Test] WHERE id_curs = " + id_cursuri[i] + ";";
            sdr = comanda.ExecuteReader();
            sdr.Read();
            numar_teste.Add(int.Parse(sdr.GetValue(0).ToString()));
            conexiune.Close();
        }
    }

    private void selecteazaNumarulTestelorDate()
    {
        for (int i = 0; i < id_cursuri.Count; i++)
        {
            SqlCommand comanda = new SqlCommand();
            SqlConnection conexiune;
            conexiune = new SqlConnection(a.string_bazadedate);
            comanda.Connection = conexiune;
            comanda.Connection.Open();
            SqlDataReader sdr;
            comanda.CommandText = "SELECT COUNT(*) FROM Utilizator_Test ut, Test t WHERE t.id_curs = " + id_cursuri[i] + " AND t.id_test = ut.id_test AND ut.id_utilizator = " + id_utilizator + ";";
            sdr = comanda.ExecuteReader();
            sdr.Read();
            numar_teste_date.Add(int.Parse(sdr.GetValue(0).ToString()));
            conexiune.Close();
        }
    }

    private void selecteazaCursurile()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT id_curs FROM [Utilizator_Curs] WHERE id_utilizator = " + id_utilizator + ";";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            id_cursuri.Add(int.Parse(sdr.GetValue(0).ToString()));
        }
        conexiune.Close();
    }

    private void selecteazaFacultatile()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT id_facultate, nume, localitate FROM [Facultate]";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            id_facultati.Add(int.Parse(sdr.GetValue(0).ToString()));
            nume_facultati.Add(sdr.GetValue(1).ToString());
            localitate_facultati.Add(sdr.GetValue(2).ToString());
        }
        conexiune.Close();
    }

    private void calculeazaDistantaMinima()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT MIN(distanta) FROM [Distanta] WHERE id_utilizator = " + id_utilizator + ";";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        string aux = sdr.GetValue(0).ToString();
        if (aux == "" || aux == null)
        {
            distanta_minima = 0;
        }
        else
        {
            distanta_minima = int.Parse(aux);
        }
        conexiune.Close();
    }

    private void calculeazaDistantaMaxima()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT MAX(distanta) FROM [Distanta] WHERE id_utilizator = " + id_utilizator + ";";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        string aux = sdr.GetValue(0).ToString();
        if (aux == "" || aux == null)
        {
            distanta_minima = 1000;
        }
        else
        {
            distanta_maxima = int.Parse(aux);
        }
        conexiune.Close();
    }

    private void selecteazaValoriRecomandari()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT * FROM [recomandari] WHERE id_recomandare = 1;";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        date_colectate = int.Parse(sdr.GetValue(1).ToString());
        curs = int.Parse(sdr.GetValue(2).ToString());
        judet = int.Parse(sdr.GetValue(3).ToString());
        note = int.Parse(sdr.GetValue(4).ToString());
        videoclipuri = int.Parse(sdr.GetValue(5).ToString());
        teste = int.Parse(sdr.GetValue(6).ToString());
        nota_curs = int.Parse(sdr.GetValue(7).ToString());
        nota_data_videoclip = int.Parse(sdr.GetValue(8).ToString());
        videoclipuri_vazute = int.Parse(sdr.GetValue(9).ToString());
        nota_data_test = int.Parse(sdr.GetValue(10).ToString());
        nota_test = int.Parse(sdr.GetValue(11).ToString());
        conexiune.Close();
    }

    private void selecteazaReferinteCurs()
    {
        for (int i = 0; i < id_cursuri.Count; i++)
        {
            SqlCommand comanda = new SqlCommand();
            SqlConnection conexiune;
            conexiune = new SqlConnection(a.string_bazadedate);
            comanda.Connection = conexiune;
            comanda.Connection.Open();
            SqlDataReader sdr;
            id_referinta_facultate.Add(new List<int>());
            nume_referinta_facultate.Add(new List<string>());
            localitate_referinta_facultate.Add(new List<string>());
            comanda.CommandText = "SELECT t.id_facultate, f.nume, f.localitate FROM Tag t, Facultate f WHERE t.id_curs = " + id_cursuri[i] + " AND t.id_facultate = f.id_facultate;";
            sdr = comanda.ExecuteReader();
            while (sdr.Read())
            {
                id_referinta_facultate[i].Add(int.Parse(sdr.GetValue(0).ToString()));
                nume_referinta_facultate[i].Add(sdr.GetValue(1).ToString());
                localitate_referinta_facultate[i].Add(sdr.GetValue(2).ToString());
            }
            conexiune.Close();
        }
    }

    private void calculeazaScorFacultati()
    {

    }

    private void culegeDate()
    {
        email = (string)Session["email"];
        data_nasterii = (string)Session["data_nasterii"];
        data_inregistrarii = (string)Session["data_inregistrarii"];
    }

    private void actualizeazaCampuri()
    {
        lista_facultati.Items.Add(new ListItem("Facultati recomandate"));
        label_email.Text = email;
        label_data_nasterii.Text = "Data nasterii: " + data_nasterii;
        label_data_inregistrarii.Text = "Data inregistrarii: " + data_inregistrarii;
        // foreach (String NumeFacultate in NumeFacultatiRecomandate)
        //   {
        //     lista_facultati.Items.Add(new ListItem(NumeFacultate));
        // }
    }

}
