using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Forma_Test : System.Web.UI.Page
{

    Auxiliare a = new Auxiliare();
    List<TextBox> intrebari = new List<TextBox>();
    List<TextBox> numarRaspunsuri = new List<TextBox>();
    List<List<CheckBox>> bifat = new List<List<CheckBox>>();
    List<List<TextBox>> raspunsuri = new List<List<TextBox>>();
    string nume_curs = null;
    int id_curs;

    protected void Page_Load(object sender, EventArgs e)
    {
        selecteazaNumeCurs();
        selecteazaIdCurs();

        if (IsPostBack)
        {
            adaugaTabel();
        }
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
        id_curs = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
    }

    private void selecteazaNumeCurs()
    {
        if (Request.QueryString["nume_curs"] != null)
        {
            nume_curs = Request.QueryString["nume_curs"].ToString();
        }
    }

    protected void genereazaIntrebari(object sender, EventArgs e)
    {

    }

    private void adaugaTabel()
    {
        Table tabel_intrebari = new Table();
        tabel_intrebari.ID = "tabel_intrebari";

        for (int i = 0; i < int.Parse(numarIntrebari.Text); i++)
        {
            TableRow rand_intrebare = new TableRow();
            TableCell celula_intrebare = new TableCell();
            celula_intrebare.HorizontalAlign = HorizontalAlign.Center;
            celula_intrebare.Attributes.Add("style", "padding: 10px");

            TableRow rand_numar_raspuns = new TableRow();
            TableCell celula_numar_raspuns = new TableCell();
            celula_numar_raspuns.HorizontalAlign = HorizontalAlign.Center;
            celula_numar_raspuns.Attributes.Add("style", "padding: 10px");

            TextBox intrebare = new TextBox();
            intrebare.ID = "intrebare" + i;
            intrebare.Attributes.Add("placeholder", "Intrebare");
            intrebare.Width = new Unit("500");
            intrebari.Add(intrebare);

            TextBox numar_raspunsuri = new TextBox();
            numar_raspunsuri.ID = "numar_raspunsuri" + i;
            numar_raspunsuri.Attributes.Add("placeholder", "Numar Raspunsuri");
            numar_raspunsuri.Width = new Unit("250");
            numarRaspunsuri.Add(numar_raspunsuri);

            celula_intrebare.Controls.Add(intrebare);
            celula_numar_raspuns.Controls.Add(numar_raspunsuri);

            rand_intrebare.Controls.Add(celula_intrebare);
            rand_numar_raspuns.Controls.Add(celula_numar_raspuns);

            tabel_intrebari.Controls.Add(rand_intrebare);
            tabel_intrebari.Controls.Add(rand_numar_raspuns);
        }

        TableRow rand_tabel = new TableRow();
        TableCell celula_tabel = new TableCell();
        celula_tabel.HorizontalAlign = HorizontalAlign.Center;
        celula_tabel.ColumnSpan = 2;
        celula_tabel.Attributes.Add("style", "padding: 10px");

        celula_tabel.Controls.Add(tabel_intrebari);
        rand_tabel.Controls.Add(celula_tabel);

        TableRow rand_buton_adaugare = new TableRow();
        TableCell celula_buton_creaza = new TableCell();
        celula_buton_creaza.HorizontalAlign = HorizontalAlign.Center;
        celula_buton_creaza.ColumnSpan = 2;
        celula_buton_creaza.Attributes.Add("style", "padding: 10px");

        Button buton_creazaSchelet = new Button();
        buton_creazaSchelet.Text = "Genereaza Raspunsuri";
        buton_creazaSchelet.ID = "buton_raspunsuri";
        buton_creazaSchelet.Click += genereazaRaspunsuri;

        celula_buton_creaza.Controls.Add(buton_creazaSchelet);
        rand_buton_adaugare.Controls.Add(celula_buton_creaza);

        tabel_generare.Controls.Add(rand_tabel);
        tabel_generare.Controls.Add(rand_buton_adaugare);
    }

    private void adaugaRaspunsuri()
    {
        Table tabel_intrebari = new Table();
        tabel_intrebari.ID = "tabel_intrebari_raspunsuri";

        for (int i = 0; i < int.Parse(numarIntrebari.Text); i++)
        {
            TableRow rand_intrebare = new TableRow();
            TableCell celula_intrebare = new TableCell();
            celula_intrebare.HorizontalAlign = HorizontalAlign.Center;
            celula_intrebare.Attributes.Add("style", "padding: 10px");

            TableRow rand_numar_raspuns = new TableRow();
            TableCell celula_numar_raspuns = new TableCell();
            celula_numar_raspuns.HorizontalAlign = HorizontalAlign.Center;
            celula_numar_raspuns.Attributes.Add("style", "padding: 10px");

            Label intrebare = new Label();
            intrebare.ID = "intrebare" + i + "'";
            intrebare.Attributes.Add("placeholder", "Intrebare");
            intrebare.Width = new Unit("500");
            intrebare.Text = intrebari[i].Text;

            Table tabel_raspunsuri = new Table();
            tabel_raspunsuri.ID = "tabel_raspunsuri"+i;

            bifat.Add(new List<CheckBox>());
            raspunsuri.Add(new List<TextBox>());

            for (int j = 0; j < int.Parse(numarRaspunsuri[i].Text); j++)
            {
                TableRow rand_raspuns = new TableRow();
                TableCell celula_raspuns = new TableCell();
                celula_raspuns.HorizontalAlign = HorizontalAlign.Center;
                celula_raspuns.Attributes.Add("style", "padding: 10px");

                CheckBox c = new CheckBox();
                c.ID = "checkbox" + i + "" + j;
                bifat[i].Add(c);

                TextBox raspuns = new TextBox();
                raspuns.ID = "raspuns" + i + "" + j;
                raspuns.Attributes.Add("placeholder", "Raspuns");
                raspuns.Width = new Unit("500");
                raspunsuri[i].Add(raspuns);

                celula_raspuns.Controls.Add(c);
                celula_raspuns.Controls.Add(raspuns);
                rand_raspuns.Controls.Add(celula_raspuns);
                tabel_raspunsuri.Controls.Add(rand_raspuns);
            }

            celula_intrebare.Controls.Add(intrebare);
            celula_numar_raspuns.Controls.Add(tabel_raspunsuri);

            rand_intrebare.Controls.Add(celula_intrebare);
            rand_numar_raspuns.Controls.Add(celula_numar_raspuns);

            tabel_intrebari.Controls.Add(rand_intrebare);
            tabel_intrebari.Controls.Add(rand_numar_raspuns);
        }

        TableRow rand_tabel = new TableRow();
        TableCell celula_tabel = new TableCell();
        celula_tabel.HorizontalAlign = HorizontalAlign.Center;
        celula_tabel.ColumnSpan = 2;
        celula_tabel.Attributes.Add("style", "padding: 10px");

        celula_tabel.Controls.Add(tabel_intrebari);
        rand_tabel.Controls.Add(celula_tabel);

        TableRow rand_buton_adaugare = new TableRow();
        TableCell celula_buton_creaza = new TableCell();
        celula_buton_creaza.HorizontalAlign = HorizontalAlign.Center;
        celula_buton_creaza.ColumnSpan = 2;
        celula_buton_creaza.Attributes.Add("style", "padding: 10px");

        Button buton_creazaSchelet = new Button();
        buton_creazaSchelet.Text = "Creaza Test";
        buton_creazaSchelet.ID = "buton_creaza";
        buton_creazaSchelet.Click += creazaTest;

        celula_buton_creaza.Controls.Add(buton_creazaSchelet);
        rand_buton_adaugare.Controls.Add(celula_buton_creaza);

        tabel_generare.Controls.Add(rand_tabel);
        tabel_generare.Controls.Add(rand_buton_adaugare);
    }

    protected void genereazaRaspunsuri(object sender, EventArgs e)
    {
        Button buton_adauga = (Button)sender;
        adaugaRaspunsuri();
    }

    private void adaugaInBazaDeDate()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "Insert into [Test] values (" + (maxIdTest() + 1) + ", " + id_curs + ", '" + numeTest.Text + "',  CONVERT(VARCHAR(10), GETDATE(), 10), 0 );";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }

    private int maxIdTest()
    {
        if (numarTeste() == 0)
        {
            return 0;
        }
        else
        {
            SqlCommand comanda = new SqlCommand();
            SqlConnection conexiune;
            conexiune = new SqlConnection(a.string_bazadedate);
            comanda.Connection = conexiune;
            comanda.Connection.Open();
            SqlDataReader sdr;
            comanda.CommandText = "Select MAX(id_test) from Test;";
            sdr = comanda.ExecuteReader();
            sdr.Read();
            int max = int.Parse(sdr.GetValue(0).ToString());
            conexiune.Close();
            return max;
        }
    }

    private int numarTeste()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "Select 1 from Test;";
        sdr = comanda.ExecuteReader();
        int i = 0;
        while (sdr.Read())
        {
            i++;
        }
        conexiune.Close();
        return i;
    }

    protected void creazaTest(object sender, EventArgs e)
    {
        adaugaInBazaDeDate();
    }

}
