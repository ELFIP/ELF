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
    List<Button> sterge_facultati = new List<Button>();
    List<Panel> panou_facultati = new List<Panel>();

    protected void Page_Load(object sender, EventArgs e)
    {
        selecteazaFacultati();
        afiseazaFacultati();
    }

    private int getID(String s)
    {
        int n = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] >= '0' && s[i] <= '9')
            {
                n = n * 10 + (s[i] - '0');
            }
        }
        return n;
    }

    private void stergeFacultatea(int id)
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "DELETE FROM Facultate WHERE id_facultate = " + id + ";";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }

    protected void stergeFacultatea(object sender, EventArgs e)
    {
        int id_buton = getID(((Button)sender).ID);
        stergeFacultatea(id_buton);
        Response.Redirect("Pagina_facultati_administrator.aspx?");
    }

    protected void selecteazaFacultati()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT id_facultate, nume, localitate FROM Facultate;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            // Inseram id-ul;
            int id = int.Parse(sdr.GetValue(0).ToString());

            // Extragem numele si localitatea facultatilor;
            String nume = sdr.GetValue(1).ToString();
            String localitate = sdr.GetValue(2).ToString();

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

            // Buton de stergere;
            Button sterge = new Button();
            sterge.Text = "Sterge";
            sterge.ID = "buton" + id;
            sterge.Click += stergeFacultatea;

            // Adaugam butonul de stergere in lista;
            sterge_facultati.Add(sterge);
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

            // Adaugam butoanele de stergere;
            TableRow rand_buton_facultate = new TableRow();
            TableCell celula_stergere = new TableCell();
            celula_stergere.HorizontalAlign = HorizontalAlign.Center;
            celula_stergere.Attributes.Add("style", "padding: 10px");
            celula_stergere.Width = new Unit("50%");

            celula_stergere.Controls.Add(sterge_facultati[i]);

            rand_buton_facultate.Controls.Add(celula_stergere);

            tabel_butoane_stergere.Controls.Add(rand_buton_facultate);
        }
    }

    protected void adauga_facultate_Click(object sender, EventArgs e)
    {
        Response.Redirect("Formular Facultate.aspx");
    }

}
