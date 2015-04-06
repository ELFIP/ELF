using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;

public partial class Schimba_Parola : System.Web.UI.Page
{
    private String email;
    private String parola;
    private String data_nasterii;
    private String data_inregistrarii;
    Auxiliare a = new Auxiliare();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            culegeDate();
            actualizeazaCampuri();
        }
    }

    private void culegeDate()
    {
        email = (String)Session["email"];
        parola = (String)Session["parola"];
        data_nasterii = (String)Session["data_nasterii"];
        data_inregistrarii = (String)Session["data_inregistrarii"];
    }

    private void actualizeazaCampuri()
    {
        label_email.Text = email;
        label_data_nasterii.Text = "Data nasterii: " + data_nasterii;
        label_data_inregistrarii.Text = "Data inregistrarii: " + data_inregistrarii;
    }

    protected void ChangePasswordButton_Click(object sender, EventArgs e)
    {
        if (OldPasswordTextbox.Text == PasswordTextbox.Text)
        {
            Msg.Text = "Parola veche si cea noua trebuie sa fie diferite.";
        }
        else
        {
            if (OldPasswordTextbox.Text == (String)Session["parola"])
            {
                Msg.Text = "Parola a fost schimbata";
                actualizeazaParola();
            }
            else
            {
                Msg.Text = "Parola veche incorecta.";
            }
        }
    }

    private void actualizeazaParola()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "UPDATE [Utilizator] SET parola = '" + PasswordTextbox.Text + "' WHERE email = '" + label_email.Text + "';";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }
}