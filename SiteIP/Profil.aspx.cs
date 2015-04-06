using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;

public partial class Profil : System.Web.UI.Page
{
    private string email;
    private string nume;
    private string prenume;
    private string data_nasterii;
    private string data_inregistrarii;
    private String domiciliu;
    private bool este_administrator;
    Auxiliare a = new Auxiliare();

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            culegeDate();
            actualizeazaCampuri();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    private void culegeDate()
    {
        email = (string)Session["email"];
        nume = (string)Session["nume"];
        prenume = (string)Session["prenume"];
        data_nasterii = (string)Session["data_nasterii"];
        data_inregistrarii = (string)Session["data_inregistrarii"];
        //media_notelor = (float)Session["data_nasterii"];
        domiciliu = (String)Session["domiciliu"];
        este_administrator = (bool)Session["este_administrator"];
    }
    
    private void actualizeazaCampuri()
    {
        label_email.Text = email;
        label_data_nasterii.Text = "Data nasterii: " + data_nasterii;
        label_data_inregistrarii.Text = "Data inregistrarii: " + data_inregistrarii;
        textbox_nume.Text = nume;
        textbox_prenume.Text = prenume;
        textbox_domiciliu.Text = domiciliu;
        if (este_administrator)
        {
            label_este_administrator.Text = "Este administrator.";
        }
        else
        {
            label_este_administrator.Text = "Nu este administrator.";
        }
    }

    protected void actualizare_profil_Click(object sender, EventArgs e)
    {
        modificaDateleDeSesiune();
        actualizeazaBazaDeDate();
        Distanta d = new Distanta((int)Session["id_utilizator"], textbox_domiciliu.Text, "");
        d.actualizeazaDistante();
    }

    private void modificaDateleDeSesiune()
    {
        Session["nume"] = textbox_nume.Text;
        Session["prenume"] = textbox_prenume.Text;
        Session["domiciliu"] = textbox_domiciliu.Text;
        nume = (String)Session["nume"];
        prenume = (String)Session["prenume"];
        domiciliu = (String)Session["domiciliu"];
    }

    private void actualizeazaBazaDeDate()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "UPDATE [Utilizator] SET nume = '" + nume + "', prenume = '" + prenume + "', domiciliu = '" + domiciliu + "' WHERE email = '" + label_email.Text + "';";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }

}