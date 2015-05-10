using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Formular_Referinte_Curs : System.Web.UI.Page
{
    Auxiliare a = new Auxiliare();
    List<int> lista_id_facultati = new List<int>();
    List<string> lista_nume_facultati = new List<string>();
    List<CheckBox> checkbox_facultati = new List<CheckBox>();
    List<TextBox> nume_tag = new List<TextBox>();
    int id_curs;
    string nume_curs;

    protected void Page_Load(object sender, EventArgs e)
    {
        selecteazaNumeCurs();
        selecteazaIdCurs();
        selecteazaFacultati();
        adaugaTabel();
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

    private void selecteazaFacultati()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT id_facultate, nume FROM [Facultate];";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            lista_id_facultati.Add(int.Parse(sdr.GetValue(0).ToString()));
            lista_nume_facultati.Add(sdr.GetValue(1).ToString());
        }
        conexiune.Close();
    }

    private void adaugaTabel()
    {
        Table tabel_facultati = new Table();
        tabel_facultati.ID = "tabel_facultati";
        tabel_facultati.Width = new Unit("100%");

        for (int i = 0; i < lista_nume_facultati.Count; i++)
        {
            TableRow rand_facultate = new TableRow();
            TableCell celula_facultate = new TableCell();
            celula_facultate.HorizontalAlign = HorizontalAlign.Center;
            celula_facultate.Attributes.Add("style", "padding: 10px");
            celula_facultate.Width = new Unit("50%");

            TableCell celula_tag = new TableCell();
            celula_tag.HorizontalAlign = HorizontalAlign.Center;
            celula_tag.Attributes.Add("style", "padding: 10px");
            celula_tag.Width = new Unit("50%");

            CheckBox c = new CheckBox();
            c.ID = "facultate" + lista_id_facultati[i];
            c.Text = lista_nume_facultati[i];
            checkbox_facultati.Add(c);

            TextBox tag = new TextBox();
            tag.ID = "id_tag" + lista_id_facultati[i];
            tag.Attributes.Add("placeholder", "Tag");
            nume_tag.Add(tag);

            celula_facultate.Controls.Add(c);
            celula_tag.Controls.Add(tag);

            rand_facultate.Controls.Add(celula_facultate);
            rand_facultate.Controls.Add(celula_tag);

            tabel_facultati.Controls.Add(rand_facultate);
        }

        tabel_facultati_taguri.Controls.Add(tabel_facultati);
    }

    private void insereazaReferinte()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        for (int i = 0; i < checkbox_facultati.Count; i ++ )
        {
            if(checkbox_facultati[i].Checked) {
                comanda.CommandText = "Insert into [Tag] values (" + id_curs + ", " + lista_id_facultati[i] + ", '" + nume_tag[i].Text + "');";
                comanda.ExecuteNonQuery();
            }
        }
        conexiune.Close();
    }

    protected void adauga_referinte_Click(object sender, EventArgs e)
    {
        insereazaReferinte();
    }

}
