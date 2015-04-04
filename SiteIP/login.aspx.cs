using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    Auxiliare a = new Auxiliare();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_login_Click(object sender, EventArgs e)
    {
        if (email_valid(tb_email.Text))
        {
            if (tb_parola.Text.Equals(verificare_parola(tb_email.Text)))
            {
                DateUtilizator.email = tb_email.Text;
                lbl_alertDateLogin.Text = "";
                Response.Redirect("index.aspx");
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
    private string verificare_parola(string email)
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
    private string date_utlizator(string email)
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT nume,prenume FROM [Utilizator] where email = '" + email + "' ;";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        string date = sdr.GetValue(0).ToString();
        conexiune.Close();
        return date;
    }
}