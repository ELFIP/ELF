using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Cursuri : System.Web.UI.Page
{
    public String[] nume = new String[20];
    public float nota;
    Auxiliare a = new Auxiliare();

    int numar_cursuri = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        numar_cursuri = 0;
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT nume, nota, FROM Curs WHERE nume LIKE '%" + cauta_curs.Text + "%' ;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            nume[numar_cursuri] = sdr.GetValue(0).ToString();
            nota = int.Parse(sdr.GetValue(1).ToString());
            numar_cursuri++;
        }
        conexiune.Close();
        afiseazaCursuri();
    }
    

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    public void afiseazaCursuri()
    {
        
        numar_cursuri = 0;
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT nume,nota FROM Curs ;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            Panel cursuri = new Panel();
            nume[numar_cursuri] = sdr.GetValue(0).ToString();
            nota = int.Parse(sdr.GetValue(1).ToString());
            cursuri.Controls.Add(nume);
            numar_cursuri++;
        }
        conexiune.Close();
    }
}