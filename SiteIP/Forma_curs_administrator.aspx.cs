using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Forma_curs_administrator : System.Web.UI.Page
{
    Auxiliare a = new Auxiliare();
    private string nume_curs;
    private string email;
    private int id_utilizator;
    private int id_curs;
    private List<string> numeVideoclip = new List<string>();
    private List<string> numeTest = new List<string>();
    private List<int> notaDataVideoclip = new List<int>();
    private List<double> mediaNotelorVideoclip = new List<double>();
    private List<int> notaDataTest = new List<int>();
    private List<double> mediaNotelorTest = new List<double>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            culegeDate();
            selecteazaIdCurs();
            selecteazaIdUtilizator();
            selecteazaVideoclipurile();
            selecteazaTestele();
            afiseazaVideoclipurile();
            afiseazaTestele();
            if (este_inscris())
            {
                buton_inscrie.Text = "Inscris";
                buton_inscrie.Enabled = false;
            }
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
        comanda.CommandText = "SELECT v.nume, v.media_notelor, uv.nota_data FROM Videoclip v, Utilizator_Videoclip uv WHERE uv.id_videoclip = v.id_videoclip AND v.id_curs = " + id_curs + " AND uv.id_utilizator = " + id_utilizator + ";";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            numeVideoclip.Add(sdr.GetValue(0).ToString());
            mediaNotelorVideoclip.Add(double.Parse(sdr.GetValue(1).ToString()));
            notaDataVideoclip.Add(int.Parse(sdr.GetValue(2).ToString()));
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
        comanda.CommandText = "SELECT t.nume, t.media_notelor, ut.nota_data FROM Test t, Utilizator_Test ut WHERE ut.id_test = t.id_test AND t.id_curs = " + id_curs + " AND ut.id_utilizator = " + id_utilizator + ";";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            numeTest.Add(sdr.GetValue(0).ToString());
            mediaNotelorTest.Add(double.Parse(sdr.GetValue(1).ToString()));
            notaDataTest.Add(int.Parse(sdr.GetValue(2).ToString()));
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

            TableCell celula2 = new TableCell();
            celula2.Text = notaDataVideoclip[i].ToString();

            TableCell celula3 = new TableCell();
            celula3.Text = mediaNotelorVideoclip[i].ToString();

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

            TableCell celula2 = new TableCell();
            celula2.Text = notaDataTest[i].ToString();

            TableCell celula3 = new TableCell();
            celula3.Text = mediaNotelorTest[i].ToString();

            TableRow rand = new TableRow();
            rand.Controls.Add(celula1);
            rand.Controls.Add(celula2);
            rand.Controls.Add(celula3);

            tabel_videoclipuri.Controls.Add(rand);
        }
    }

    protected void inscrie_Click(object sender, EventArgs e)
    {
        // Blocam butonul si schimbam textul;
        buton_inscrie.Text = "Inscris";
        buton_inscrie.Enabled = false;

        // Adaugam perechea utilizator - curs in baza de date;
        adaugaInBazaDeDate();
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