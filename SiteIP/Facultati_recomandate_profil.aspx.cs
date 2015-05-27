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
    private string localitate_utilizator;
    private double nota_utilizator;
    private string data_nasterii;
    private string data_inregistrarii;

    private List<string> nume_facultati = new List<string>();

    private List<int> referinta_id_facultate = new List<int>();
    private List<string> referinta_nume_facultate = new List<string>();
    private List<string> referinta_localitate_facultate = new List<string>();
    private List<int> referinta_id_curs = new List<int>();

    private List<int> id_facultati_scor = new List<int>();
    private List<double> scor_facultate = new List<double>();

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

    private List<double> nota_teste = new List<double>();

    // Valorile care calculeaza scorurile fiecarei facultati;
    private int date_colectate;
    private int curs;
    private int judet;
    private int note;
    private int videoclipuri;
    private int teste;
    private int nota_data_videoclip;
    private int videoclipuri_vazute;
    private int teste_date;
    private int nota_data_test;
    private int nota_test;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            culegeDate();
            selecteazaIdUtilizator();
            creazaReferinteFacultati();
            calculeazaDistantaMinima();
            calculeazaDistantaMaxima();
            selecteazaValoriRecomandari();
            calculeazaScorFacultati();
            adaugaInBazaDeDate();
          //  selecteazaFacultatileRecomandate();
            actualizeazaCampuri();
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
        comanda.CommandText = "SELECT id_utilizator, domiciliu, media_notelor FROM Utilizator WHERE email = '" + email + "';";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        id_utilizator = int.Parse(sdr.GetValue(0).ToString());
        localitate_utilizator = sdr.GetValue(1).ToString();
        nota_utilizator = double.Parse(sdr.GetValue(2).ToString());
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
        nota_data_videoclip = int.Parse(sdr.GetValue(7).ToString());
        videoclipuri_vazute = int.Parse(sdr.GetValue(8).ToString());
        teste_date = int.Parse(sdr.GetValue(9).ToString());
        nota_data_test = int.Parse(sdr.GetValue(10).ToString());
        nota_test = int.Parse(sdr.GetValue(11).ToString());
        conexiune.Close();
    }

    private void creazaReferinteFacultati()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT f.id_facultate, f.nume, f.localitate, c.id_curs,(SELECT COUNT(*) FROM Videoclip v WHERE v.id_curs = c.id_curs), (SELECT COUNT(*) FROM Test test WHERE test.id_curs = c.id_curs), (SELECT COUNT(*) FROM Utilizator_Videoclip uv, Videoclip v WHERE v.id_curs = c.id_curs AND v.id_videoclip = uv.id_videoclip AND uv.id_utilizator = " + id_utilizator + "), (SELECT COUNT(*) FROM Utilizator_Test ut, Test test WHERE test.id_curs = c.id_curs AND test.id_test = ut.id_test AND ut.id_utilizator = " + id_utilizator + "), (SELECT AVG(nota_data) FROM Utilizator_Videoclip uv, Videoclip v WHERE v.id_curs = c.id_curs AND v.id_videoclip = uv.id_videoclip AND uv.id_utilizator = " + id_utilizator + "), (SELECT AVG(nota_data) FROM Utilizator_Test ut, Test test WHERE test.id_curs = c.id_curs AND test.id_test = ut.id_test AND ut.id_utilizator = " + id_utilizator + "), (SELECT AVG(nota_obtinuta) FROM Utilizator_Test ut, Test test WHERE test.id_curs = c.id_curs AND test.id_test = ut.id_test AND ut.id_utilizator = " + id_utilizator + ")  FROM Facultate f, Tag t, Curs c, Utilizator_Curs uc WHERE t.id_facultate = f.id_facultate AND t.id_curs = c.id_curs AND c.id_curs = uc.id_curs AND uc.id_utilizator = " + id_utilizator + " ORDER BY f.id_facultate;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            referinta_id_facultate.Add(int.Parse(sdr.GetValue(0).ToString()));
            referinta_nume_facultate.Add(sdr.GetValue(1).ToString());
            referinta_localitate_facultate.Add(sdr.GetValue(2).ToString());
            referinta_id_curs.Add(int.Parse(sdr.GetValue(3).ToString()));
            numar_videoclipuri.Add(int.Parse(sdr.GetValue(4).ToString()));
            numar_teste.Add(int.Parse(sdr.GetValue(5).ToString()));
            numar_videoclipuri_vazute.Add(int.Parse(sdr.GetValue(6).ToString()));
            numar_teste_date.Add(int.Parse(sdr.GetValue(7).ToString()));
            string aux1 = sdr.GetValue(8).ToString();
            if (aux1 == "" || aux1 == null)
            {
                media_notelor_date_videoclip.Add(0);
            }
            else
            {
                media_notelor_date_videoclip.Add(double.Parse(aux1));
            }
            string aux2 = sdr.GetValue(9).ToString();
            if (aux2 == "" || aux2 == null)
            {
                media_notelor_date_test.Add(0);
            }
            else
            {
                media_notelor_date_test.Add(double.Parse(aux2));
            }
            string aux3 = sdr.GetValue(10).ToString();
            if (aux3 == "" || aux3 == null)
            {
                nota_teste.Add(0);
            }
            else
            {
                nota_teste.Add(double.Parse(aux3));
            }
        }
        conexiune.Close();
    }

    private void calculeazaScorFacultati()
    {
        for (int i = 0; i < referinta_id_facultate.Count; i++)
        {
            // Aflam ponderea notei de la Bac;
            double scor_note = nota_utilizator / 10.0;

            // Aflam ponderea distantei;
            double scor_judet;
            Distanta d = new Distanta(id_utilizator, localitate_utilizator, referinta_localitate_facultate[i]);
            int distanta = d.stringToInt(d.DistanceMatrixRequest(localitate_utilizator, referinta_localitate_facultate[i]));
            scor_judet = 1 - (double)(distanta) / (double)(distanta_maxima);

            // Aflam ponderea videoclipurilor;
            double scor_nota_data_videoclip = media_notelor_date_videoclip[i] / 5.0;
            double scor_videoclipuri_vazute;
            if (numar_videoclipuri[i] == 0)
            {
                scor_videoclipuri_vazute = 0.0;
            }
            else
            {
                scor_videoclipuri_vazute = (double)numar_videoclipuri_vazute[i] / (double)numar_videoclipuri[i];
            }

            // Aflam ponderea testelor;
            double scor_nota_data_test = media_notelor_date_test[i] / 5.0;
            double scor_teste_date;
            if (numar_teste[i] == 0)
            {
                scor_teste_date = 0.0;
            }
            else
            {
                scor_teste_date = (double)numar_teste_date[i] / (double)numar_teste[i];
            }

            double scor_nota_teste = nota_teste[i];

            id_facultati_scor.Add(referinta_id_facultate[i]);

            while (i + 1 < referinta_id_facultate.Count && referinta_id_facultate[i] == referinta_id_facultate[i + 1])
            {
                // Aflam ponderea distantei;
                distanta = d.stringToInt(d.DistanceMatrixRequest(localitate_utilizator, referinta_localitate_facultate[i + 1]));
                scor_judet = (scor_judet + 1 - (double)(distanta) / (double)(distanta_maxima)) / 2.0;

                // Aflam ponderea videoclipurilor;
                scor_nota_data_videoclip = (scor_nota_data_videoclip + media_notelor_date_videoclip[i + 1] / 5.0) / 2.0;
                if (numar_videoclipuri[i + 1] == 0)
                {
                    scor_videoclipuri_vazute = scor_videoclipuri_vazute / 2.0;
                }
                else
                {
                    scor_videoclipuri_vazute = (scor_videoclipuri_vazute + (double)numar_videoclipuri_vazute[i + 1] / (double)numar_videoclipuri[i + 1]) / 2.0;
                }

                // Aflam ponderea testelor;
                scor_nota_data_test = (scor_nota_data_test + media_notelor_date_test[i + 1] / 5.0) / 2.0;
                if (numar_teste[i + 1] == 0)
                {
                    scor_teste_date = scor_teste_date / 2.0;
                }
                else
                {
                    scor_teste_date = (scor_teste_date + (double)numar_teste_date[i + 1] / (double)numar_teste[i + 1]) / 2.0;
                }

                scor_nota_teste = (scor_nota_teste + nota_teste[i + 1]) / 2.0;

                i++;
            }

            // Aflam ponderea cursului;
            double scor_videoclipuri = scor_nota_data_videoclip * nota_data_videoclip + scor_videoclipuri_vazute * videoclipuri_vazute;
            double scor_teste = scor_nota_data_test * nota_data_test + scor_teste_date * nota_test + scor_nota_teste * nota_test;
            double scor_curs = (scor_videoclipuri * videoclipuri) / 100.0 + (scor_teste * teste) / 100.0;

            // Aflam ponderea datelor colectate;
            double scor_date_colectate = scor_note * note + scor_judet * judet;

            // Aflam ponderea totala;
            double scor = (scor_date_colectate * date_colectate) / 100.0 + (scor_curs * curs) / 100.0;
            scor_facultate.Add(scor);
        }
    }

    private bool existaRecomandarea(int id_facultate)
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT 1 FROM [Utilizator_Facultate] WHERE id_utilizator = " + id_utilizator + " AND id_facultate = " + id_facultate + ";";
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
        for (int i = 0; i < id_facultati_scor.Count; i++)
        {
            if (existaRecomandarea(id_facultati_scor[i]))
            {
                SqlCommand comanda = new SqlCommand();
                SqlConnection conexiune;
                conexiune = new SqlConnection(a.string_bazadedate);
                comanda = new SqlCommand();
                comanda.Connection = conexiune;
                comanda.Connection.Open();
                comanda.CommandText = "UPDATE [Utilizator_Facultate] SET scor = " + (int)scor_facultate[i] + " WHERE id_utilizator = " + id_utilizator + " AND id_facultate = " + id_facultati_scor[i] + ";";
                comanda.ExecuteNonQuery();
                conexiune.Close();
            }
            else
            {
                SqlCommand comanda = new SqlCommand();
                SqlConnection conexiune;
                conexiune = new SqlConnection(a.string_bazadedate);
                comanda = new SqlCommand();
                comanda.Connection = conexiune;
                comanda.Connection.Open();
                comanda.CommandText = "Insert into [Utilizator_Facultate] values (" + id_utilizator + ", " + id_facultati_scor[i] + ",  CONVERT(VARCHAR(10), GETDATE(), 10)," + (int)scor_facultate[i] + ");";
                comanda.ExecuteNonQuery();
                conexiune.Close();
            }
        }
    }

    private void culegeDate()
    {
        email = (string)Session["email"];
        data_nasterii = (string)Session["data_nasterii"];
        data_inregistrarii = (string)Session["data_inregistrarii"];
    }

    private void selecteazaFacultatileRecomandate()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT TOP 10 f.nume FROM Facultate f, Utilizator_facultate uf WHERE uf.id_utilizator = " + id_utilizator + " AND f.id_facultate = uf.id_facultate ORDER BY uf.scor DESC;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            nume_facultati.Add(sdr.GetValue(0).ToString());
        }
        conexiune.Close();
    }

    private void actualizeazaCampuri()
    {
        //lista_facultati.Items.Add(new ListItem("Facultati recomandate"));
        label_email.Text = email;
        label_data_nasterii.Text = "Data nasterii: " + data_nasterii;
        label_data_inregistrarii.Text = "Data inregistrarii: " + data_inregistrarii;
        //foreach (string NumeFacultate in nume_facultati)
        //{
        //lista_facultati.Items.Add(new ListItem(NumeFacultate));
        // }
    }

}
