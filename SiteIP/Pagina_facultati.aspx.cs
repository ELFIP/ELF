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
    List<String> nume_facultati = new List<String>();
    List<String> localitate_facultati = new List<String>();

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
            nume_facultati.Add(sdr.GetValue(0).ToString());
            localitate_facultati.Add(sdr.GetValue(1).ToString());
        }
        conexiune.Close();
    }

    protected void afiseazaFacultati()
    {

        for (int i = 0; i < nume_facultati.Count; i ++ )
        {
            Panel facultate = new Panel();
            facultate.CssClass = "facultate";

            Panel nume_facultate = new Panel();
            nume_facultate.Width = new Unit("50%");
            nume_facultate.Height = new Unit("100%");

            HyperLink hnf = new HyperLink();
            hnf.NavigateUrl = "Facultati/" + nume_facultati[i] + " " + localitate_facultati[i] + "/" + nume_facultati[i] + " " + localitate_facultati[i] + ".aspx";
            hnf.Text = nume_facultati[i] + " " + localitate_facultati[i];

            nume_facultate.Controls.Add(hnf);

            Label localitate_facultate = new Label();
            localitate_facultate.Width = new Unit("50%");
            localitate_facultate.Height = new Unit("100%");
            localitate_facultate.Text = localitate_facultati[i];

            facultate.Controls.Add(nume_facultate);
            facultate.Controls.Add(localitate_facultate);

            panou_facultati.Controls.Add(facultate);
            panou_facultati.Controls.Add(new LiteralControl("<br />"));
        }
    }

}