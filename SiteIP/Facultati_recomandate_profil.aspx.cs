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
    private List<int> id_facultati = new List<int>();
    private List<string> nume_facultati = new List<string>();
    private List<string> localitate_facultati = new List<string>();
    private List<int> id_cursuri = new List<int>();
    private List<int> numar_videoclipuri = new List<int>();
    private List<int> numar_teste = new List<int>();
    private List<int> numar_videoclipuri_vazute = new List<int>();
    private List<int> numar_teste_date = new List<int>();
    private List<double> media_notelor_date_videoclip = new List<double>();
    private List<double> media_notelor_date_test = new List<double>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            culegeDate();
            actualizeazaCampuri();
        }
    }

    private void selecteazaNumarulVideoclipurilor()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        for (int i = 0; i < id_cursuri.Count; i++)
        {
            comanda.CommandText = "SELECT COUNT(*) FROM [Videoclip] WHERE id_curs = " + id_cursuri[i] + ";";
            sdr = comanda.ExecuteReader();
            sdr.Read();
            numar_videoclipuri.Add(int.Parse(sdr.GetValue(0).ToString()));
        }
        conexiune.Close();
    }

    private void selecteazaMediaNotelorDateVideoclip()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        for (int i = 0; i < id_cursuri.Count; i++)
        {
            comanda.CommandText = "SELECT AVG(nota_data) FROM Utilizator_Videoclip uv, Videoclip v WHERE v.id_curs = " + id_cursuri[i] + " AND v.id_videoclip = uv.id_videoclip AND uv.id_utilizator = " + id_utilizator + ";";
            sdr = comanda.ExecuteReader();
            sdr.Read();
            media_notelor_date_videoclip.Add(double.Parse(sdr.GetValue(0).ToString()));
        }
        conexiune.Close();
    }

    private void selecteazaNumarulVideoclipurilorVazute()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        for (int i = 0; i < id_cursuri.Count; i++)
        {
            comanda.CommandText = "SELECT COUNT(*) FROM Utilizator_Videoclip uv, Videoclip v WHERE v.id_curs = " + id_cursuri[i] + " AND v.id_videoclip = uv.id_videoclip AND uv.id_utilizator = " + id_utilizator + ";";
            sdr = comanda.ExecuteReader();
            sdr.Read();
            numar_videoclipuri_vazute.Add(int.Parse(sdr.GetValue(0).ToString()));
        }
        conexiune.Close();
    }

    private void selecteazaMediaNotelorDateTest()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        for (int i = 0; i < id_cursuri.Count; i++)
        {
            comanda.CommandText = "SELECT AVG(nota_data) FROM Utilizator_Test ut, Test t WHERE t.id_curs = " + id_cursuri[i] + " AND t.id_tes = ut.id_test AND ut.id_utilizator = " + id_utilizator + ";";
            sdr = comanda.ExecuteReader();
            sdr.Read();
            media_notelor_date_test.Add(double.Parse(sdr.GetValue(0).ToString()));
        }
        conexiune.Close();
    }

    private void selecteazaNumarulTestelor()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        for (int i = 0; i < id_cursuri.Count; i++)
        {
            comanda.CommandText = "SELECT COUNT(*) FROM [Test] WHERE id_curs = " + id_cursuri[i] + ";";
            sdr = comanda.ExecuteReader();
            sdr.Read();
            numar_teste.Add(int.Parse(sdr.GetValue(0).ToString()));
        }
        conexiune.Close();
    }

    private void selecteazaNumarulTestelorDate()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        for (int i = 0; i < id_cursuri.Count; i++)
        {
            comanda.CommandText = "SELECT COUNT(*) FROM Utilizator_Test ut, Test t WHERE t.id_curs = " + id_cursuri[i] + " AND t.id_videoclip = ut.id_videoclip AND ut.id_utilizator = " + id_utilizator + ";";
            sdr = comanda.ExecuteReader();
            sdr.Read();
            numar_teste_date.Add(int.Parse(sdr.GetValue(0).ToString()));
        }
        conexiune.Close();
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
        comanda.CommandText = "SELECT MIN(distanta) FROM [Distanta] WHERE id_utilizator = " + id_utilizator +";";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        distanta_minima = int.Parse(sdr.GetValue(0).ToString());
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
        distanta_maxima = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
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
        foreach (String NumeFacultate in NumeFacultatiRecomandate)
        {
            lista_facultati.Items.Add(new ListItem(NumeFacultate));
        }
    }

}
