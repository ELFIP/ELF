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
        culegeDate();
        actualizeazaCampuri();
    }

    private void culegeDate()
    {
        id_utilizator = (int)Session["id_utilizator"];
        email = (String)Session["email"];
        parola = (String)Session["parola"];
        nume = (String)Session["nume"];
        prenume = (String)Session["prenume"];
        data_nasterii = (String)Session["data_nasterii"];
        data_inregistrarii = (String)Session["data_inregistrarii"];
        //media_notelor = (float)Session["data_nasterii"];
        domiciliu = (String)Session["domiciliu"];
        este_administrator = (bool)Session["este_administrator"];
        Cursuri = (ArrayList)Session["Cursuri"];
        NumeCursuri = (ArrayList)Session["NumeCursuri"];
        VideoclipuriVazute = (ArrayList)Session["VideoclipuriVazute"];
        TesteDate = (ArrayList)Session["TesteDate"];
        FacultatiRecomandate = (ArrayList)Session["FacultatiRecomandate"];
        NumeFacultatiRecomandate = (ArrayList)Session["NumeFacultatiRecomandate"];
    }

    private void actualizeazaCampuri()
    {
        lista_cursuri.Items.Add(new ListItem("Cursuri"));
        lista_facultati.Items.Add(new ListItem("Facultati recomandate"));
        label_email.Text = email;
        label_data_nasterii.Text = "Data nasterii: " + data_nasterii;
        label_data_inregistrarii.Text = "Data inregistrarii: " + data_inregistrarii;
        textbox_nume.Text = nume;
        textbox_prenume.Text = prenume;
        textbox_domiciliu.Text = domiciliu;
        foreach(String Curs in NumeCursuri) {
            lista_cursuri.Items.Add(new ListItem(Curs));
        }
        foreach(String NumeFacultate in NumeFacultatiRecomandate) {
            lista_facultati.Items.Add(new ListItem(NumeFacultate));
        }
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
        Response.Redirect("login.aspx?" + textbox_nume.Text);
        modificaDateleDeSesiune();
        actualizeazaBazaDeDate();

    }

    private void modificaDateleDeSesiune()
    {
        Session["nume"] = textbox_nume.Text;
        Session["prenume"] = textbox_prenume.Text;
        Session["domiciliu"] = textbox_domiciliu.Text;
    }

    private void actualizeazaBazaDeDate()
    {
        Response.Redirect("login.aspx?" + textbox_nume.Text);
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "UPDATE Utilizator SET nume = '" + textbox_nume.Text + "', prenume = '" + textbox_prenume.Text + "', domiciliu = '" + textbox_domiciliu.Text + "' WHERE id_utilizator = " + id_utilizator + ";";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }
}