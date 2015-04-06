using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Facultati_recomandate_profil : System.Web.UI.Page
{
    private string email;
    private string data_nasterii;
    private string data_inregistrarii;
    private ArrayList FacultatiRecomandate = new ArrayList();
    private ArrayList NumeFacultatiRecomandate = new ArrayList();

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
        email = (string)Session["email"];
        data_nasterii = (string)Session["data_nasterii"];
        data_inregistrarii = (string)Session["data_inregistrarii"];
        FacultatiRecomandate = (ArrayList)Session["FacultatiRecomandate"];
        NumeFacultatiRecomandate = (ArrayList)Session["NumeFacultatiRecomandate"];
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