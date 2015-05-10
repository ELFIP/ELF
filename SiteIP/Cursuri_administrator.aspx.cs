using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Cursuri_administrator : System.Web.UI.Page
{
    String[] nume_cursuri = new String[200];
    String[] nume_taguri = new String[100];
    Auxiliare a = new Auxiliare();
    int numar_cursuri = 0;
    int numar_taguri = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(bool)Session["este_administrator"])
        {
            Response.Redirect("Cursuri.aspx");
        }
        selecteazaCursuri();
        afiseazaCursuri();
        selecteazaTaguri();
        afiseazaTaguri();
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        schimbaText();
    }

    protected void schimbaText()
    {
        numar_cursuri = 0;
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT nume FROM Curs WHERE nume LIKE '%" + cauta_curs.Text + "%' ;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            nume_cursuri[numar_cursuri] = sdr.GetValue(0).ToString();
            numar_cursuri++;
        }
        conexiune.Close();
        tabel_cursuri.Controls.Clear();
        for (int i = 0; i < numar_cursuri; i++)
        {
            Panel curs = new Panel();
            curs.CssClass = "curs";

            Panel nume_curs = new Panel();
            nume_curs.Width = new Unit("50%");
            nume_curs.Height = new Unit("100%");

            HyperLink hnf = new HyperLink();
            hnf.NavigateUrl = nume_cursuri[i];
            hnf.Text = nume_cursuri[i];

            nume_curs.Controls.Add(hnf);

            curs.Controls.Add(nume_curs);
            tabel_cursuri.Controls.Add(curs);
            tabel_cursuri.Controls.Add(new LiteralControl("<br />"));
        }
    }

    protected void selecteazaCursuri()
    {
        numar_cursuri = 0;
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT nume FROM Curs;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            nume_cursuri[numar_cursuri] = sdr.GetValue(0).ToString();
            numar_cursuri++;
        }
        conexiune.Close();
    }

    public void afiseazaCursuri()
    {
        for (int i = 0; i < numar_cursuri; i++)
        {
            HyperLink hnf = new HyperLink();
            hnf.NavigateUrl = "Cursuri/" + nume_cursuri[i] + "/" + nume_cursuri[i] + ".aspx";
            hnf.Text = nume_cursuri[i];

            TableCell celula = new TableCell();
            celula.Controls.Add(hnf);

            TableRow rand = new TableRow();
            rand.Controls.Add(celula);

            tabel_cursuri.Controls.Add(rand);
        }
    }

    protected void selecteazaTaguri()
    {
        numar_taguri = 0;
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT DISTINCT nume FROM Tag;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            nume_taguri[numar_taguri] = sdr.GetValue(0).ToString();
            numar_taguri++;
        }
        conexiune.Close();
    }

    public void afiseazaTaguri()
    {
        for (int i = 0; i < numar_taguri; i++)
        {
            CheckBox cbox = new CheckBox();
            cbox.CssClass = "checkbox";
            cbox.Text = nume_taguri[i];
            cbox.ID = nume_taguri[i];

            TableCell celula1 = new TableCell();
            celula1.Controls.Add(cbox);

            TableRow rand = new TableRow();
            rand.Controls.Add(celula1);

            tabel_checkbox.Controls.Add(rand);
        }
    }
}