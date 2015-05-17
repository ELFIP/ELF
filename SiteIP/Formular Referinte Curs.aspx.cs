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

    // Numele facultatilor care au deja referinta la cursul respectiv;
    List<Label> nume_referinte = new List<Label>();

    // Butoanele de stergere;
    List<Button> sterge_referinte = new List<Button>();

    // Id-urile facultatilor care deja au referinta la cursul respectiv;
    List<int> id_referinte = new List<int>();

    int id_curs;
    string nume_curs;

    protected void Page_Load(object sender, EventArgs e)
    {
        selecteazaNumeCurs();
        selecteazaIdCurs();
        selecteazaReferinteleDejaExistente();
        afiseazaReferinteleExistente();
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

    private int getID(String s)
    {
        int n = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if(s[i] >= '0' && s[i] <= '9') {
                n = n * 10 + (s[i] - '0');
            }
        }
        return n;
    }

    private void stergeReferinta(int id)
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "DELETE FROM Tag WHERE id_curs = " + id_curs + " AND id_facultate = " + id + ";";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }

    protected void stergeReferinta(object sender, EventArgs e)
    {
        int id_buton = getID(((Button)sender).ID);
        stergeReferinta(id_buton);
        Response.Redirect("Formular Referinte Curs.aspx?nume_curs=" + nume_curs);
    }

    private void selecteazaReferinteleDejaExistente()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT f.id_facultate, f.nume FROM Facultate f, Tag t WHERE f.id_facultate = t.id_facultate AND t.id_curs = " + id_curs + ";";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            // Inseram id-ul;
            int id = int.Parse(sdr.GetValue(0).ToString());
            id_referinte.Add(id);

            // Inseram un Label nou cu numele facultatii;
            Label aux1 = new Label();
            aux1.Text = sdr.GetValue(1).ToString();
            nume_referinte.Add(aux1);

            // Inseram un buton de stergere a referintei;
            Button aux2 = new Button();
            aux2.Text = "Sterge";
            aux2.ID = "buton" + id;
            aux2.Click += stergeReferinta;
            sterge_referinte.Add(aux2);
        }
        conexiune.Close();
    }

    private void afiseazaReferinteleExistente()
    {
        Table tabel_referinte = new Table();
        tabel_referinte.ID = "tabel_referinte";
        tabel_referinte.Width = new Unit("100%");

        for (int i = 0; i < id_referinte.Count; i++)
        {
            TableRow rand_referinta = new TableRow();
            TableCell celula_referinta = new TableCell();
            celula_referinta.HorizontalAlign = HorizontalAlign.Center;
            celula_referinta.Attributes.Add("style", "padding: 10px");
            celula_referinta.Width = new Unit("50%");

            TableCell celula_stergere = new TableCell();
            celula_stergere.HorizontalAlign = HorizontalAlign.Center;
            celula_stergere.Attributes.Add("style", "padding: 10px");
            celula_stergere.Width = new Unit("50%");

            celula_referinta.Controls.Add(nume_referinte[i]);
            celula_stergere.Controls.Add(sterge_referinte[i]);

            rand_referinta.Controls.Add(celula_referinta);
            rand_referinta.Controls.Add(celula_stergere);

            tabel_referinte.Controls.Add(rand_referinta);
        }

        deja_existente.Controls.Add(tabel_referinte);
    }

    private String getString(List<int> id)
    {
        String s = "(";
        for (int i = 0; i < id.Count - 1; i ++)
        {
            s += id[i] + ",";
        }
        if (id.Count > 0) {
            s += id[id.Count - 1];
        }
        s += ")";

        return s;
    }

    private void selecteazaFacultati()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        if (id_referinte.Count == 0)
        {
            // In cazul in care nu avem nicio referinta la cursul respectiv;
            comanda.CommandText = "SELECT id_facultate, nume FROM [Facultate];";
        }
        else
        {
            // In cazul in care avem referinte la cursul respectiv;
            comanda.CommandText = "SELECT id_facultate, nume FROM [Facultate] WHERE id_facultate NOT IN " + getString(id_referinte) + ";";
        }
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
        Response.Redirect("Formular Referinte Curs.aspx?nume_curs=" + nume_curs);
    }

}
