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
    int id_test;
    int id_utilizator;
    int id_curs;
    int nota_data;
    double media_notelor_test;
    private string email;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            culegeDate();
            selecteazaIdUtilizator();
            selecteazaIdTest();
            selecteazaIdCurs();
            selecteazaNotaDataTest();
            afiseazaNotaData();
        }
    }

    private void culegeDate()
    {
        email = (string)Session["email"];
    }

    private void afiseazaNotaData()
    {
        switch (nota_data)
        {
            case 1:
                id_nota1.Selected = true;
                break;
            case 2:
                id_nota2.Selected = true;
                break;
            case 3:
                id_nota3.Selected = true;
                break;
            case 4:
                id_nota4.Selected = true;
                break;
            case 5:
                id_nota5.Selected = true;
                break;
        }
    }

    private void selecteazaNotaDataTest()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT nota_data FROM Utilizator_Test WHERE id_utilizator = " + id_utilizator + " AND id_test = " + id_test + ";";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        nota_data = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
    }

    private void selecteazaIdCurs()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT id_curs FROM Curs WHERE nume = '" + numeCurs.Text + "';";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        id_curs = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
    }

    private void selecteazaIdTest()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT id_videoclip FROM Videoclip WHERE nume = '" + numeTest.Text + "';";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        id_test = int.Parse(sdr.GetValue(0).ToString());
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
        id_utilizator = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
    }

    private void actualizeazaNotaDataTest(int nota)
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "UPDATE [Utilizator_Test] SET nota_data = " + nota + " WHERE id_utilizator = " + id_utilizator + " AND id_test = " + id_test + ";";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }

    private void selecteazaMediaNotelorTest()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT AVG(nota_data) FROM Utilizator_Test WHERE id_test = " + id_test + ";";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        media_notelor_test = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
    }

    private void actualizeazaMediaNotelorTest(int nota)
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "UPDATE [Test] SET media_notelor = " + media_notelor_test + " WHERE id_test = " + id_test + " AND id_curs = " + id_curs + ";";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }

    protected void selectare(object sender, EventArgs e)
    {
        if (id_nota1.Selected == true)
        {
            actualizeazaNotaDataTest(1);
            selecteazaMediaNotelorTest();
            actualizeazaMediaNotelorTest(1);
        }
        else if (id_nota2.Selected == true)
        {
            actualizeazaNotaDataTest(2);
            selecteazaMediaNotelorTest();
            actualizeazaMediaNotelorTest(2);
        }
        else if (id_nota3.Selected == true)
        {
            actualizeazaNotaDataTest(3);
            selecteazaMediaNotelorTest();
            actualizeazaMediaNotelorTest(3);
        }
        else if (id_nota4.Selected == true)
        {
            actualizeazaNotaDataTest(4);
            selecteazaMediaNotelorTest();
            actualizeazaMediaNotelorTest(4);
        }
        else
        {
            actualizeazaNotaDataTest(5);
            selecteazaMediaNotelorTest();
            actualizeazaMediaNotelorTest(5);
        }
    }

}
