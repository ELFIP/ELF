using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    private int id_utilizator;
    private String email;
    private String parola;
    private String nume;
    private String prenume;
    private String data_nasterii;
    private String data_inregistrarii;
    private float media_notelor;
    private String domiciliu;
    private bool este_administrator;
    private ArrayList Cursuri = new ArrayList();
    private ArrayList NumeCursuri = new ArrayList();
    private ArrayList VideoclipuriVazute = new ArrayList();
    private ArrayList TesteDate = new ArrayList();
    private ArrayList FacultatiRecomandate = new ArrayList();
    private ArrayList NumeFacultatiRecomandate = new ArrayList();
    Auxiliare a = new Auxiliare();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_login_Click(object sender, EventArgs e)
    {
        if (email_valid(tb_email.Text))
        {
            email = tb_email.Text;
            if (tb_parola.Text.Equals(verificare_parola()))
            {
                lbl_alertDateLogin.Text = "";
                aflaDateUtilizator();
                creazaVariabileleDeSesiune();
                Response.Redirect("Profil.aspx");
            }
            else
            {
                lbl_alertDateLogin.Text = "Date incorecte !";
            }
        }
        else
        {
            lbl_alertDateLogin.Text = "Date incorecte !";
        }

    }

    private bool email_valid(string email)
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT email FROM [Utilizator] where email = '" + email + "';";
        sdr = comanda.ExecuteReader();
        int i = 0;
        while (sdr.Read())
        {
            i++;
        }
        conexiune.Close();
        if (i == 0)
        {
            return false; // email-ul nu exista
        }
        else
        {
            return true; // emailul exista, verificam parola
        }
    }

    private string verificare_parola()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT parola FROM [Utilizator] where email = '" + email + "' ;";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        string password = sdr.GetValue(0).ToString();
        conexiune.Close();
        return password;
    }

    private void aflaDateUtilizator()
    {
        datePersonale();
        aflaCursuri();
        aflaVideoclipuriVazute();
        aflaTesteDate();
        aflaFacultatiRecomandate();
    }

    private void creazaVariabileleDeSesiune()
    {
        Session["id_utilizator"] = id_utilizator;
        Session["email"] = email;
        Session["parola"] = parola;
        Session["nume"] = nume;
        Session["prenume"] = prenume;
        Session["data_nasterii"] = data_nasterii;
        Session["data_inregistrarii"] = data_inregistrarii;
        Session["media_notelor"] = media_notelor;
        Session["domiciliu"] = domiciliu;
        Session["este_administrator"] = este_administrator;
        Session["Cursuri"] = Cursuri;
        Session["NumeCursuri"] = NumeCursuri;
        Session["VideoclipuriVazute"] = VideoclipuriVazute;
        Session["TesteDate"] = TesteDate;
        Session["FacultatiRecomandate"] = FacultatiRecomandate;
        Session["NumeFacultatiRecomandate"] = NumeFacultatiRecomandate;
    }

    private void datePersonale()
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

    private void aflaCursuri()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT uc.id_curs, c.nume FROM [Utilizator_Curs] uc, [Curs] c WHERE uc.id_utilizator = " + id_utilizator + " AND uc.id_curs = c.id_curs;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            Cursuri.Add(sdr.GetValue(0));
            NumeCursuri.Add(sdr.GetValue(1));
        }
        conexiune.Close();
    }

    private void aflaVideoclipuriVazute()
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

    private void aflaTesteDate()
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

    private void aflaFacultatiRecomandate()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT uf.id_facultate, f.nume FROM [Utilizator_Facultate] uf, [Facultate] f WHERE uf.id_utilizator = " + id_utilizator + " AND uf.id_facultate = f.id_facultate;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            FacultatiRecomandate.Add(sdr.GetValue(0));
            NumeFacultatiRecomandate.Add(sdr.GetValue(1));
        }
        conexiune.Close();
    }

}