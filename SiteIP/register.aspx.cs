using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
{
    Auxiliare a = new Auxiliare();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_trimite_Click(object sender, EventArgs e)
    {
<<<<<<< HEAD
        int id_max = maxId() + 1;
        SqlCommand dbcommand = new SqlCommand();
        SqlConnection dbconnection;
        dbconnection = new SqlConnection(a.string_bazadedate);
        dbcommand = new SqlCommand();
        dbcommand.Connection = dbconnection;
        dbcommand.Connection.Open();
        dbcommand.CommandText = "Insert into [Utilizator] values (" + id_max + ", '" + tb_email.Text + "', '" + tb_parola.Text + "',  '" + tb_nume.Text + "', '" + tb_prenume.Text + "', '01/01/2000', '" + DateTime.Now + "', " + int.Parse(tb_mediaNotelor.Text) + ", '" + tb_adresa.Text + "', " + 1 + " );";
        dbcommand.ExecuteNonQuery();
        dbconnection.Close();

        Distanta d = new Distanta(id_max, tb_adresa.Text, "");
        d.insereazaDistante();
    }

    private int maxId()
=======
        if (email_valid(tb_email.Text))
        {
            SqlCommand dbcommand = new SqlCommand();
            SqlConnection dbconnection;
            dbconnection = new SqlConnection(a.string_bazadedate);
            dbcommand = new SqlCommand();
            dbcommand.Connection = dbconnection;
            dbcommand.Connection.Open();
            dbcommand.CommandText = "Insert into [Utilizator] values (" + (maxId() + 1) + ", '" + tb_email.Text + "', '" + tb_parola.Text + "',  '" + tb_nume.Text + "', '" + tb_prenume.Text + "', '01/01/2000', '" + DateTime.Now + "', " + int.Parse(tb_mediaNotelor.Text) + ", '" + tb_adresa.Text + "', " + 1 + " );";
            dbcommand.ExecuteNonQuery();
            dbconnection.Close();
            lbl_debug.Text = "Inregistrare terminata cu succes !";
        }
        else
        {
            lbl_debug.Text = "Emailul introdus exista deja in baza de date. Daca ti-ai uitat parola, o poti recupera AICI(link catre pagina de recuperat parola).";
        }
    }
    private int maxId()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "Select MAX(id_utilizator) from [Utilizator]";
        sdr = comanda.ExecuteReader();
        int i = 0;
        sdr.Read();
        i = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
        return i;
    }
    private bool email_valid(string email)
>>>>>>> origin/master
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
<<<<<<< HEAD
        comanda.CommandText = "Select MAX(id_utilizator) from [Utilizator]";
=======
        comanda.CommandText = "SELECT email FROM [Utilizator] where email = '" + email + "';";
>>>>>>> origin/master
        sdr = comanda.ExecuteReader();
        sdr.Read();
        int max = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
<<<<<<< HEAD
        return max;
=======
        if (i == 0)
        {
            return true; // email-ul nu exista, daca datele trec de validatoare facem insert si redirectionam catre login 
        }
        else
        {
            return false; // emailul exista deci nu se poate inregistra cu acest email, nu facem insert 
        }
    }
    protected void SendMail()
    {
        var fromAddress = "elfteamip@gmail.com";
        var toAddress = tb_email.Text;
        const string fromPassword = "elfteamip1";
        string subject = "Bun venit !";
        string body = "Bun venit in comunitatea ELF... bla bla";
        var smtp = new System.Net.Mail.SmtpClient();
        {
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            smtp.Timeout = 20000;
        }
        smtp.Send(fromAddress, toAddress, subject, body);
>>>>>>> origin/master
    }
}