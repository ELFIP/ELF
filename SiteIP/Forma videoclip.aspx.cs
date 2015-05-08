using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Forma_videoclip : System.Web.UI.Page
{
    Auxiliare a = new Auxiliare();
    int id_videoclip;
    int id_utilizator;
    int id_curs;
    int nota_data;
    double media_notelor_videoclip;
    private string email;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            culegeDate();
            selecteazaIdUtilizator();
            selecteazaIdVideoclip();
            selecteazaIdCurs();
            selecteazaNotaDataVideoclip();
            afiseazaNotaData();
        }

    }

    private void culegeDate()
    {
        email = (string)Session["email"];
    }

    private void afiseazaNotaData()
    {
        switch(nota_data) {
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

    private void selecteazaNotaDataVideoclip()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT nota_data FROM Utilizator_Videoclip WHERE id_utilizator = " + id_utilizator + " AND id_videoclip = " + id_videoclip + ";";
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

    private void selecteazaIdVideoclip()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT id_videoclip FROM Videoclip WHERE nume = '" + numeVideoclip.Text + "';";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        id_videoclip = int.Parse(sdr.GetValue(0).ToString());
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

    private void actualizeazaNotaDataVideoclip(int nota)
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "UPDATE [Utilizator_Videoclip] SET nota_data = " + nota + " WHERE id_utilizator = " + id_utilizator + " AND id_videoclip = " + id_videoclip + ";";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }

    private void selecteazaMediaNotelorVideoclip()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT AVG(nota_data) FROM Utilizator_Videoclip WHERE id_videoclip = " + id_videoclip + ";";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        media_notelor_videoclip = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
    }

    private void actualizeazaMediaNotelorVideoclip(int nota)
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "UPDATE [Videoclip] SET media_notelor = " + media_notelor_videoclip + " WHERE id_videoclip = " + id_videoclip + " AND id_curs = " + id_curs + ";";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }

    protected void selectare(object sender, EventArgs e)
    {
        if(id_nota1.Selected == true) {
            actualizeazaNotaDataVideoclip(1);
            selecteazaMediaNotelorVideoclip();
            actualizeazaMediaNotelorVideoclip(1);
        } else if(id_nota2.Selected == true) {
            actualizeazaNotaDataVideoclip(2);
            selecteazaMediaNotelorVideoclip();
            actualizeazaMediaNotelorVideoclip(2);
        } else if(id_nota3.Selected == true) {
            actualizeazaNotaDataVideoclip(3);
            selecteazaMediaNotelorVideoclip();
            actualizeazaMediaNotelorVideoclip(3);
        } else if (id_nota4.Selected == true) {
            actualizeazaNotaDataVideoclip(4);
            selecteazaMediaNotelorVideoclip();
            actualizeazaMediaNotelorVideoclip(4);
        } else {
            actualizeazaNotaDataVideoclip(5);
            selecteazaMediaNotelorVideoclip();
            actualizeazaMediaNotelorVideoclip(5);
        }
    }

}
