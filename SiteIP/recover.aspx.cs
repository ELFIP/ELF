using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recover : System.Web.UI.Page
{
    Auxiliare a = new Auxiliare(); 
    private string parolaTrimisa;
    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_debug.Text = "";
        tb_email.Visible = true;
        btn_trimite.Visible = true;
    }
    protected void btn_trimite_Click(object sender, EventArgs e)
    {
        if (email_valid(tb_email.Text))
        {
            SendMail();
            update_parola();
            lbl_debug.Text = "Un email cu noile date de accesare a contului au fost trimise catre: " + tb_email.Text;
            tb_email.Visible = false;
            btn_trimite.Visible = false;
        }
        else
        {
            lbl_debug.Text = "Emailul introdus nu a fost gasit in baza noastra de date !";
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

    protected void SendMail()
    {
        parolaTrimisa = parola_random();
        var fromAddress = "elfteamip@gmail.com";
        var toAddress = tb_email.Text;
        const string fromPassword = "elfteamip1";
        string subject = "ELF-Recuperare parola";
        string body = "Buna ziua, pentru a folosi contul de ELF, folositi urmatoarele date:\n";
        body += "Email: " + tb_email.Text + "\n";
        body += "Parola: " + parolaTrimisa;
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
    }

    protected string parola_random()
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        var result = new string(
            Enumerable.Repeat(chars, 8)
                      .Select(s => s[random.Next(s.Length)])
                      .ToArray());
        return result;
    }

    private void update_parola()
    {
        SqlCommand dbcommand = new SqlCommand();
        SqlConnection dbconnection;
        dbconnection = new SqlConnection(a.string_bazadedate);
        dbcommand = new SqlCommand();
        dbcommand.Connection = dbconnection;
        dbcommand.Connection.Open();
        dbcommand.CommandText = "UPDATE [Utilizator] SET parola = '" + parolaTrimisa + "' WHERE email = '" + tb_email.Text + "';";
        dbcommand.ExecuteNonQuery();
        dbconnection.Close();
    }
}