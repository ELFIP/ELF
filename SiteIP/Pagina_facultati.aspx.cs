using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Pagina_facultati : System.Web.UI.Page
{
    Auxiliare a = new Auxiliare();
    List<Panel> panou_facultati = new List<Panel>();

    protected void Page_Load(object sender, EventArgs e)
    {
        selecteazaFacultati();
        afiseazaFacultati();
    }

    protected void selecteazaFacultati()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT nume, localitate FROM Facultate;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            // Extragem numele si localitatea facultatilor;
            String nume = sdr.GetValue(0).ToString();
            String localitate = sdr.GetValue(1).ToString();

            // Panou pentru fiecare facultate;
            Panel facultate = new Panel();

            // Cream hyperlink-uri catre pagina facultatii;
            HyperLink hnf = new HyperLink();
            hnf.NavigateUrl = "Facultati/" + nume + " " + localitate + "/" + nume + " " + localitate + ".aspx";
            hnf.Text = nume;

            Label label_localitate = new Label();
            label_localitate.Width = new Unit("50%");
            label_localitate.Height = new Unit("100%");
            label_localitate.Text = localitate;

            facultate.Controls.Add(hnf);
            facultate.Controls.Add(label_localitate);

            // Adaugam panoul facultatii in lista;
            panou_facultati.Add(facultate);
        }
        conexiune.Close();
    }

    protected void afiseazaFacultati()
    {
        for (int i = 0; i < panou_facultati.Count; i++)
        {
            // Adaugam Label-urile;
            TableRow rand_facultate = new TableRow();
            TableCell celula_facultate = new TableCell();
            celula_facultate.HorizontalAlign = HorizontalAlign.Center;
            celula_facultate.Attributes.Add("style", "padding: 10px");
            celula_facultate.Width = new Unit("50%");

            celula_facultate.Controls.Add(panou_facultati[i]);

            rand_facultate.Controls.Add(celula_facultate);

            tabel_link_facultati.Controls.Add(rand_facultate);
        }
    }

    protected void adauga_facultate_Click(object sender, EventArgs e)
    {
        Response.Redirect("Formular Facultate.aspx");
    }

}