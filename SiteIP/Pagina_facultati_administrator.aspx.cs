using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Pagina_facultati_administrator : System.Web.UI.Page
{
    Auxiliare a = new Auxiliare();
    // DateUtilizator dU = new DateUtilizator();
    int numar_facultati = 0;
    String[] nume_facultati = new String[20];
    String[] localitate_facultati = new String[20];

    protected void Page_Load(object sender, EventArgs e)
    {
        selecteazaFacultati();
        afiseazaFacultati();
    }

    protected void selecteazaFacultati()
    {
        numar_facultati = 0;
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
            nume_facultati[numar_facultati] = sdr.GetValue(0).ToString();
            localitate_facultati[numar_facultati] = sdr.GetValue(1).ToString();
            numar_facultati++;
        }
        conexiune.Close();
    }

    protected void afiseazaFacultati()
    {
        for (int i = 0; i < numar_facultati; i++)
        {
            Panel facultate = new Panel();
            facultate.CssClass = "facultate";

            Label nume_facultate = new Label();
            nume_facultate.Width = new Unit("50%");
            nume_facultate.Height = new Unit("100%");
            nume_facultate.CssClass = "label_numefacultate";
            nume_facultate.Text = nume_facultati[i];

            Label localitate_facultate = new Label();
            localitate_facultate.Width = new Unit("50%");
            localitate_facultate.Height = new Unit("100%");
            localitate_facultate.CssClass = "label_localitatefacultate";
            localitate_facultate.Text = localitate_facultati[i];

            facultate.Controls.Add(nume_facultate);
            facultate.Controls.Add(localitate_facultate);

            panou_facultati.Controls.Add(facultate);
            panou_facultati.Controls.Add(new LiteralControl("<br />"));
        }
    }

}