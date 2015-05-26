using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
 
public partial class Statistical_Thermodynamics_administrator : System.Web.UI.Page
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
    private List<Button> sterge_videoclip = new List<Button>();
    private List<Button> sterge_test = new List<Button>();
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(bool)Session["este_administrator"])
        {
             Response.Redirect("Statistical Thermodynamics.aspx");
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
        comanda.CommandText = "SELECT id_videoclip, nume, media_notelor FROM Videoclip WHERE id_curs = " + id_curs + ";";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            int id = int.Parse(sdr.GetValue(0).ToString());
            numeVideoclip.Add(sdr.GetValue(1).ToString());
            mediaNotelorVideoclip.Add(double.Parse(sdr.GetValue(2).ToString()));
 
            // Cream buton de stergere a videoclipului;
            Button buton = new Button();
            buton.Text = "Sterge";
            buton.ID = "videoclip" + id;
            buton.Click += stergeVideoclip;
            sterge_videoclip.Add(buton);
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
        comanda.CommandText = "SELECT id_test, nume, media_notelor FROM Test WHERE id_curs = " + id_curs + ";";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            int id = int.Parse(sdr.GetValue(0).ToString());
            numeTest.Add(sdr.GetValue(1).ToString());
            mediaNotelorTest.Add(double.Parse(sdr.GetValue(2).ToString()));
 
            // Cream buton de stergere a videoclipului;
            Button buton = new Button();
            buton.Text = "Sterge";
            buton.ID = "test" + id;
            buton.Click += stergeTest;
            sterge_test.Add(buton);
        }
        conexiune.Close();
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
 
    private void stergeVideoclip(int id)
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "DELETE FROM Videoclip WHERE id_curs = " + id_curs + " AND id_videoclip = " + id + ";";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }
 
    protected void stergeVideoclip(object sender, EventArgs e)
    {
        int id_buton = getID(((Button)sender).ID);
        stergeVideoclip(id_buton);
        Response.Redirect("Statistical Thermodynamics_administrator.aspx");
    }
 
    private void stergeTest(int id)
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "DELETE FROM Test WHERE id_curs = " + id_curs + " AND id_test = " + id + ";";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }
 
    protected void stergeTest(object sender, EventArgs e)
    {
        int id_buton = getID(((Button)sender).ID);
        stergeTest(id_buton);
        Response.Redirect("Statistical Thermodynamics_administrator.aspx");
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
 
            TableCell celula3 = new TableCell();
            celula3.HorizontalAlign = HorizontalAlign.Center;
            celula3.Attributes.Add("style", "padding: 10px");
            celula3.Controls.Add(sterge_videoclip[i]);
 
            TableRow rand = new TableRow();
            rand.Controls.Add(celula1);
            rand.Controls.Add(celula2);
            rand.Controls.Add(celula3);
 
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
 
            TableCell celula3 = new TableCell();
            celula3.HorizontalAlign = HorizontalAlign.Center;
            celula3.Attributes.Add("style", "padding: 10px");
            celula3.Controls.Add(sterge_test[i]);
 
            TableRow rand = new TableRow();
            rand.Controls.Add(celula1);
            rand.Controls.Add(celula2);
            rand.Controls.Add(celula3);
 
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
 
    protected void adauga_test_click(object sender, EventArgs e)
    {
           Response.Redirect("..\\..\\Formular Test.aspx?nume_curs=" + numeCurs.Text );
    }
 
    protected void adauga_videoclip_click(object sender, EventArgs e)
    {
           Response.Redirect("..\\..\\Formular Videoclip.aspx?nume_curs=" + numeCurs.Text );
    }
}
