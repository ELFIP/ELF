using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;

public class DateUtilizator
{
    public static int id_utilizator;
    public static String email;
    public static String parola;
    public static String nume;
    public static String prenume;
    public static String data_nasterii;
    public static String data_inregistrarii;
    public static float media_notelor;
    public static String domiciliu;
    public static bool este_administrator;
    public static ArrayList Cursuri = new ArrayList();
    public static ArrayList VideoclipuriVazute = new ArrayList();
    public static ArrayList TesteDate = new ArrayList();
    public static ArrayList FacultatiRecomandate = new ArrayList();
    Auxiliare a = new Auxiliare();

	public DateUtilizator(String email)
	{
        datePersonale();
        aflaCursuri();
        aflaVideoclipuriVazute();
        aflaTesteDate();
	}

    public void datePersonale()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT * FROM [Utilizator] WHERE email = '" + email + "' ;";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        id_utilizator = int.Parse(sdr.GetValue(0).ToString());
        email = sdr.GetValue(1).ToString();
        parola = sdr.GetValue(2).ToString();
        nume = sdr.GetValue(3).ToString();
        prenume = sdr.GetValue(4).ToString();
        data_nasterii = sdr.GetValue(5).ToString();
        data_inregistrarii = sdr.GetValue(6).ToString();
        media_notelor = float.Parse(sdr.GetValue(7).ToString());
        domiciliu = sdr.GetValue(8).ToString();
        int b = int.Parse(sdr.GetValue(9).ToString());
        if (b == 1)
        {
            este_administrator = true;
        }
        else
        {
            este_administrator = false;
        }
        conexiune.Close();
    }

    public void aflaCursuri()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT id_curs FROM [Utilizator_Curs] WHERE id_utilizator = " + id_utilizator + " ;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            Cursuri.Add(sdr.GetValue(0));
        }
        conexiune.Close();
    }

    public void aflaVideoclipuriVazute()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT id_videoclip FROM [Utilizator_Videoclip] WHERE id_utilizator = " + id_utilizator + " ;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            VideoclipuriVazute.Add(sdr.GetValue(0));
        }
        conexiune.Close();
    }

    public void aflaTesteDate()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT id_test FROM [Utilizator_Test] WHERE id_utilizator = " + id_utilizator + " ;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            TesteDate.Add(sdr.GetValue(0));
        }
        conexiune.Close();
    }

    public void aflaFacultatiRecomandate()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT id_facultate FROM [Utilizator_Facultate] WHERE id_utilizator = " + id_utilizator + " ;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            FacultatiRecomandate.Add(sdr.GetValue(0));
        }
        conexiune.Close();
    }

    public int getId_utilizator()
    {
        return id_utilizator;
    }

    public String getEmail()
    {
        return email;
    }

    public String getParola()
    {
        return parola;
    }

    public String getNume()
    {
        return nume;
    }

    public String getPrenume()
    {
        return prenume;
    }

    public String getData_nasterii()
    {
        return data_nasterii;
    }

    public String getData_inregistrarii()
    {
        return data_inregistrarii;
    }

    public float getMedia_notelor()
    {
        return media_notelor;
    }

    public String getDomiciliu()
    {
        return domiciliu;
    }

    public bool getEste_administrator()
    {
        return este_administrator;
    }

    public ArrayList getCursuri()
    {
        return Cursuri;
    }

    public ArrayList getVideoclipuriVazute()
    {
        return VideoclipuriVazute;
    }

    public ArrayList getTesteDate()
    {
        return TesteDate;
    }

    public ArrayList getFacultatiRecomandate()
    {
        return FacultatiRecomandate;

    }

}
