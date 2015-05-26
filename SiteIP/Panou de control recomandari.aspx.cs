using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Panou_de_control_recomandari : System.Web.UI.Page
{
    Auxiliare a = new Auxiliare();
    int v_date_colectate;
    int v_curs;
    int v_judet;
    int v_note;
    int v_videoclipuri;
    int v_teste;
    int v_nota_data_videoclip;
    int v_videoclipuri_vazute;
    int v_teste_date;
    int v_nota_data_test;
    int v_nota_test;

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void actualizeaza_recomandarile_Click(object sender, EventArgs e)
    {
        aflaParametriiDeRecomandare();
        actualizeazaBazaDeDate();
    }

    private void aflaParametriiDeRecomandare()
    {
        v_date_colectate = int.Parse(date_colectate.Text);
        v_curs = int.Parse(curs.Text);
        v_judet = int.Parse(judet.Text);
        v_note = int.Parse(note.Text);
        v_videoclipuri = int.Parse(videoclipuri.Text);
        v_teste = int.Parse(teste.Text);
        v_nota_data_videoclip = int.Parse(nota_data_videoclipuri.Text);
        v_videoclipuri_vazute = int.Parse(numar_videoclipuri_vazute.Text);
        v_nota_data_test = int.Parse(nota_data_teste.Text);
        v_nota_test = int.Parse(nota_test.Text);
    }

    private void actualizeazaBazaDeDate()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "UPDATE Recomandari SET date_colectate = " + v_date_colectate + ", curs = " + v_curs + ", judet =" + v_judet + ", note =" + v_note + ", videoclipuri =" + v_videoclipuri + ", teste = " + v_teste + ", nota_curs =" + v_teste_date + ", nota_data_videoclip = " + v_nota_data_videoclip + ", videoclipuri_vazute = " + v_videoclipuri_vazute + ", nota_data_test = " + v_nota_data_test + ", nota_test = " + v_nota_test + " WHERE id_recomandare = 1;";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }
}
