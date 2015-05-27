using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
 
public partial class Curs2 : System.Web.UI.Page
{
    Auxiliare a = new Auxiliare();
    private string nume_curs;
    private string email;
    private int id_utilizator;
    private int id_curs;
    private List<string> numeVideoclip = new List<string>();
    private List<string> numeTest = new List<string>();
    private List<double> mediaNotelorVideoclip = new List<double>();
    private List<double> mediaNotelorTest = new List<double>();
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["este_administrator"])
        {
             Response.Redirect("Curs2_administrator.aspx");
        }
        culegeDate();
        selecteazaIdCurs();
        selecteazaIdUtilizator();
        if (este_inscris())
        {
             buton_inscrie.Text = "Inscris";
             buton_inscrie.Enabled = false;
             selecteazaVideoclipurile();
             selecteazaTestele();
             afiseazaVideoclipurile();
             afiseazaTestele();
        }
    }
 
    private bool este_inscris()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT 1 FROM Utilizator_Curs WHERE id_utilizator = " + id_utilizator + " AND id_curs = " + id_curs + ";";
        sdr = comanda.ExecuteReader();
        int nr = 0;
        while (sdr.Read())
        {
            nr++;
        }
        conexiune.Close();
        if (nr == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
 
    private void culegeDate()
    {
        email = (string)Session["email"];
        nume_curs = numeCurs.Text;
    }
 
    private void selecteazaIdCurs()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT id_curs FROM Curs WHERE nume = '" + nume_curs + "';";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        int nr = int.Parse(sdr.GetValue(0).ToString());
        id_curs = nr;
        conexiune.Close();
    }
 
    private void selecteazaIdUtilizator()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT id_utilizator FROM Utilizator WHERE email = '" + email + "';";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        int nr = int.Parse(sdr.GetValue(0).ToString());
        id_utilizator = nr;
        conexiune.Close();
    }
 
    private void selecteazaVideoclipurile()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT nume, media_notelor FROM Videoclip WHERE id_curs = " + id_curs + " ;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            numeVideoclip.Add(sdr.GetValue(0).ToString());
            mediaNotelorVideoclip.Add(double.Parse(sdr.GetValue(1).ToString()));
        }
        conexiune.Close();
    }
 
    private void selecteazaTestele()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT nume, media_notelor FROM Test WHERE id_curs = " + id_curs + ";";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            numeTest.Add(sdr.GetValue(0).ToString());
            mediaNotelorTest.Add(double.Parse(sdr.GetValue(1).ToString()));
        }
        conexiune.Close();
    }
 
    private void afiseazaVideoclipurile()
    {
        for (int i = 0; i < numeVideoclip.Count; i++)
        {
            HyperLink hnf = new HyperLink();
            hnf.NavigateUrl = numeVideoclip[i] + ".aspx";
            hnf.Text = numeVideoclip[i];
 
            TableCell celula1 = new TableCell();
            celula1.Controls.Add(hnf);
            celula1.HorizontalAlign = HorizontalAlign.Center;
            celula1.Attributes.Add("style", "padding: 10px");
 
            TableCell celula2 = new TableCell();
            celula2.Text = mediaNotelorVideoclip[i].ToString();
            celula2.HorizontalAlign = HorizontalAlign.Center;
            celula2.Attributes.Add("style", "padding: 10px");
 
            TableRow rand = new TableRow();
            rand.Controls.Add(celula1);
            rand.Controls.Add(celula2);
 
            tabel_videoclipuri.Controls.Add(rand);
        }
    }
 
    private void afiseazaTestele()
    {
        for (int i = 0; i < numeTest.Count; i++)
        {
            HyperLink hnf = new HyperLink();
            hnf.NavigateUrl = numeTest[i] + ".aspx";
            hnf.Text = numeTest[i];
 
            TableCell celula1 = new TableCell();
            celula1.Controls.Add(hnf);
            celula1.HorizontalAlign = HorizontalAlign.Center;
            celula1.Attributes.Add("style", "padding: 10px");
 
            TableCell celula2 = new TableCell();
            celula2.Text = mediaNotelorTest[i].ToString();
            celula2.HorizontalAlign = HorizontalAlign.Center;
            celula2.Attributes.Add("style", "padding: 10px");
 
            TableRow rand = new TableRow();
            rand.Controls.Add(celula1);
            rand.Controls.Add(celula2);
 
            tabel_teste.Controls.Add(rand);
        }
    }
 
    protected void inscrie_Click(object sender, EventArgs e)
    {
        // Blocam butonul si schimbam textul;
        buton_inscrie.Text = "Inscris";
        buton_inscrie.Enabled = false;
 
        // Adaugam perechea utilizator - curs in baza de date;
        adaugaInBazaDeDate();
        selecteazaVideoclipurile();
        selecteazaTestele();
        afiseazaVideoclipurile();
        afiseazaTestele();
    }
 
    private void adaugaInBazaDeDate()
    {
        SqlCommand dbcommand = new SqlCommand();
        SqlConnection dbconnection;
        dbconnection = new SqlConnection(a.string_bazadedate);
        dbcommand = new SqlCommand();
        dbcommand.Connection = dbconnection;
        dbcommand.Connection.Open();
        dbcommand.CommandText = "Insert into [Utilizator_Curs] values (" + id_utilizator + ", " + id_curs + ",  CONVERT(VARCHAR(10), GETDATE(), 10), null);";
        dbcommand.ExecuteNonQuery();
        dbconnection.Close();
    }
 
}
