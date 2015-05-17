using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Cursuri_administrator : System.Web.UI.Page
{

    List<HyperLink> nume_cursuri = new List<HyperLink>();
    List<CheckBox> nume_taguri = new List<CheckBox>();
    List<Button> lista_butoane = new List<Button>();
    Auxiliare a = new Auxiliare();

    protected void CheckBox_CheckChanged(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
        Response.Write(((CheckBox)sender).ClientID);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if ((bool)Session["este_administrator"])
        //{
        //    Response.Redirect("Cursuri_administrator.aspx" );
        // }
        if (!IsPostBack)
        {
            selecteazaCursurile();
            afiseazaCursurile();
            selecteazaTagurile();
            afiseazaTagurile();
            Session["lista_taguri"] = nume_taguri;
        }
        else
        {
            nume_taguri = (List<CheckBox>)Session["lista_taguri"];
            //Response.Redirect("login.aspx?n=" + nume_taguri[0].Checked);
            afiseazaTagurile();
            selecteazaCursurileCautate();
            afiseazaCursurile();
        }
    }

    private List<String> getList(List<CheckBox> tag)
    {
        List<String> s = new List<String>();
        for (int i = 0; i < tag.Count; i++)
        {
            if (tag[i].Checked == true)
            {
                s.Add(tag[i].Text);
            }
        }
        return s;
    }

    private String getString(List<String> id)
    {
        String s = "(";
        for (int i = 0; i < id.Count - 1; i++)
        {
            s += "'" + id[i] + "'" + ",";
        }
        if (id.Count > 0)
        {
            s += "'" + id[id.Count - 1] + "'";
        }
        s += ")";

        return s;
    }

    protected void selecteazaCursurileCautate()
    {
        List<String> taguri_selectate = getList(nume_taguri);
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        if(taguri_selectate.Count == 0) {
            comanda.CommandText = "SELECT id_curs, nume FROM Curs WHERE nume LIKE '%" + cauta_curs.Text + "%';";
        }
        else
        {
            comanda.CommandText = "SELECT c.id_curs, c.nume FROM Curs c, Tag t WHERE c.nume LIKE '%" + cauta_curs.Text + "%' AND c.id_curs = t.id_curs AND t.nume IN " + getString(taguri_selectate) + ";";
        }
        
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            int id = int.Parse(sdr.GetValue(0).ToString());
            String nume_curs = sdr.GetValue(1).ToString();

            // Cream Hyperlink catre curs;
            HyperLink curs = new HyperLink();
            curs.NavigateUrl = "Cursuri/" + nume_curs + "/" + nume_curs + ".aspx";
            curs.Text = nume_curs;
            nume_cursuri.Add(curs);

            // Cream buton de stergere a cursului;
            Button buton = new Button();
            buton.Text = "Sterge";
            buton.ID = "buton" + id;
            buton.Click += stergeCurs;
            lista_butoane.Add(buton);
        }
        conexiune.Close();
    }

    protected void selecteazaCursurile()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT id_curs, nume FROM Curs;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            int id = int.Parse(sdr.GetValue(0).ToString());
            String nume_curs = sdr.GetValue(1).ToString();

            // Cream Hyperlink catre curs;
            HyperLink curs = new HyperLink();
            curs.NavigateUrl = "Cursuri/" + nume_curs + "/" + nume_curs + ".aspx";
            curs.Text = nume_curs;
            nume_cursuri.Add(curs);

            // Cream buton de stergere a cursului;
            Button buton = new Button();
            buton.Text = "Sterge";
            buton.ID = "buton" + id;
            buton.Click += stergeCurs;
            lista_butoane.Add(buton);

        }
        conexiune.Close();
    }

    public void afiseazaCursurile()
    {
        for (int i = 0; i < nume_cursuri.Count; i++)
        {
            TableCell celula_curs = new TableCell();
            celula_curs.HorizontalAlign = HorizontalAlign.Center;
            celula_curs.Attributes.Add("style", "padding: 10px");
            celula_curs.Controls.Add(nume_cursuri[i]);

            TableCell celula_buton = new TableCell();
            celula_buton.HorizontalAlign = HorizontalAlign.Center;
            celula_buton.Attributes.Add("style", "padding: 10px");
            celula_buton.Controls.Add(lista_butoane[i]);

            TableRow rand = new TableRow();
            rand.Controls.Add(celula_curs);
            rand.Controls.Add(celula_buton);

            tabel_cursuri.Controls.Add(rand);
        }
    }

    protected void selecteazaTagurile()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT DISTINCT nume FROM Tag;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            string nume_tag = sdr.GetValue(0).ToString();

            // Cream checkbox-uri pentru taguri; 
            CheckBox tag = new CheckBox();
            tag.CssClass = "checkbox";
            tag.Text = nume_tag;
            tag.ID = nume_tag;
            tag.Checked = false;
            nume_taguri.Add(tag);

        }
        conexiune.Close();
    }

    protected void filtrare(object sender, EventArgs e)
    {
        Session["lista_taguri"] = nume_taguri;
    }

    public void afiseazaTagurile()
    {
        for (int i = 0; i < nume_taguri.Count; i++)
        {
            TableCell celula1 = new TableCell();
            celula1.Controls.Add(nume_taguri[i]);

            TableRow rand = new TableRow();
            rand.Controls.Add(celula1);

            tabel_checkbox.Controls.Add(rand);
        }

        Button buton_filtrare = new Button();
        buton_filtrare.Text = "Filtrare";
        buton_filtrare.Click += filtrare;

        TableCell celula_buton_filtrare = new TableCell();
        celula_buton_filtrare.HorizontalAlign = HorizontalAlign.Center;
        celula_buton_filtrare.Attributes.Add("style", "padding: 10px");
        celula_buton_filtrare.Controls.Add(buton_filtrare);

        TableRow rand_buton_filtrare = new TableRow();
        rand_buton_filtrare.Controls.Add(celula_buton_filtrare);

        tabel_checkbox.Controls.Add(rand_buton_filtrare);
    }

    private void stergeCurs(int id)
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "DELETE FROM Curs WHERE id_curs = " + id + ";";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }

    protected void stergeCurs(object sender, EventArgs e)
    {
        int id_buton = getID(((Button)sender).ID);
        stergeCurs(id_buton);
        Response.Redirect("Cursuri_administrator.aspx");
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

}
