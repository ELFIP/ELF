using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Administrare_utilizator : System.Web.UI.Page
{
    public String[] email = new String[20];
    public String[] nume = new String[20];
    public String[] prenume = new String[20];
    public String[] parola = new String[20];
    Auxiliare a = new Auxiliare();

    int numar_utilizatori = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        numar_utilizatori = 0;
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT email, nume, prenume, parola FROM Utilizator WHERE email LIKE '%" + cauta_utilizator.Text + "%' ORDER BY data_inregistrarii;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            email[numar_utilizatori] = sdr.GetValue(0).ToString();
            nume[numar_utilizatori] = sdr.GetValue(1).ToString();
            prenume[numar_utilizatori] = sdr.GetValue(2).ToString();
            parola[numar_utilizatori] = sdr.GetValue(3).ToString();
            numar_utilizatori++;
        }
        conexiune.Close();
        afiseazaUtilizatori();
    }

    public void schimbaTabelul(object sender, EventArgs e)
    {
        numar_utilizatori = 0;
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT email, nume, prenume, parola FROM Utilizator WHERE email LIKE '%" + cauta_utilizator.Text + "%' ORDER BY data_inregistrarii;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            email[numar_utilizatori] = sdr.GetValue(0).ToString();
            nume[numar_utilizatori] = sdr.GetValue(1).ToString();
            prenume[numar_utilizatori] = sdr.GetValue(2).ToString();
            parola[numar_utilizatori] = sdr.GetValue(3).ToString();
            numar_utilizatori++;
        }
        conexiune.Close();
        afiseazaUtilizatori();
    }

    public void afiseazaUtilizatori()
    {
        tabel_utilizatori.Rows.Clear();
       
        TableHeaderRow header = new TableHeaderRow();
        header.Width = new Unit("75%");
        TableHeaderCell header_celula1 = new TableHeaderCell();
        header_celula1.Text = "Email";
        header_celula1.Width = new Unit("30%");
        TableHeaderCell header_celula2 = new TableHeaderCell();
        header_celula2.Text = "Nume";
        header_celula2.Width = new Unit("30%");
        TableHeaderCell header_celula3 = new TableHeaderCell();
        header_celula3.Text = "Prenume";
        header_celula3.Width = new Unit("30%");

        header.Controls.Add(header_celula1);
        header.Controls.Add(header_celula2);
        header.Controls.Add(header_celula3);

        tabel_utilizatori.Controls.Add(header);

        for (int i = 0; i < numar_utilizatori; i ++ )
        {
            TableCell celula1 = new TableCell();
            celula1.Text = email[i];
            TableCell celula2 = new TableCell();
            celula2.Text = nume[i];
            TableCell celula3 = new TableCell();
            celula3.Text = prenume[i];
            TableRow rand = new TableRow();
            rand.Controls.Add(celula1);
            rand.Controls.Add(celula2);
            rand.Controls.Add(celula3);
            tabel_utilizatori.Controls.Add(rand);
        }
    }

}