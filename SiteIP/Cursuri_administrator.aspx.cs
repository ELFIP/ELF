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
    List<Image> lista_imagini = new List<Image>();
    Auxiliare a = new Auxiliare();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            selecteazaCursurile();
            afiseazaCursurile();
            selecteazaTagurile();
            afiseazaTagurile();
            Session["nume_taguri"] = nume_taguri;
        }
        else
        {
            nume_cursuri.Clear();
            nume_taguri = ( List < CheckBox > )Session["nume_taguri"];
            //selecteazaTagurile();
            afiseazaTagurile();
          //  afiseazaTagurile();
         //   selecteazaCursurileCautate();
         //   afiseazaCursurile();
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
        if (taguri_selectate.Count == 0)
        {
            comanda.CommandText = "SELECT id_curs, nume, imagine FROM Curs WHERE nume LIKE '%" + cauta_curs.Text + "%';";
        }
        else
        {
            comanda.CommandText = "SELECT DISTINCT c.id_curs, c.nume, c.imagine FROM Curs c, Tag t WHERE c.nume LIKE '%" + cauta_curs.Text + "%' AND c.id_curs = t.id_curs AND t.nume IN " + getString(taguri_selectate) + ";";
        }

        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            int id = int.Parse(sdr.GetValue(0).ToString());
            String nume_curs = sdr.GetValue(1).ToString();

            Image imagine = new Image();
            imagine.AlternateText = "No image";
            imagine.ImageUrl = "~/Imagini_cursuri/" + sdr.GetValue(2).ToString();

            imagine.Width = 100;
            imagine.Height = 100;

            lista_imagini.Add(imagine);

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
        comanda.CommandText = "SELECT id_curs, nume,imagine FROM Curs;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            int id = int.Parse(sdr.GetValue(0).ToString());
            String nume_curs = sdr.GetValue(1).ToString();
            Image imagine = new Image();
            imagine.AlternateText = "No image";
            imagine.ImageUrl = "~/Imagini_cursuri/" + sdr.GetValue(2).ToString();

            imagine.Width=100;
            imagine.Height = 100;
   
            lista_imagini.Add(imagine);

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
            TableCell celula_imagine = new TableCell();
            celula_imagine.HorizontalAlign = HorizontalAlign.Center;
            celula_imagine.Attributes.Add("style", "padding: 10px");
            celula_imagine.Controls.Add(lista_imagini[i]);

            TableCell celula_curs = new TableCell();
            celula_curs.HorizontalAlign = HorizontalAlign.Center;
            celula_curs.Attributes.Add("style", "padding: 10px");
            celula_curs.Controls.Add(nume_cursuri[i]);

            TableCell celula_buton = new TableCell();
            celula_buton.HorizontalAlign = HorizontalAlign.Center;
            celula_buton.Attributes.Add("style", "padding: 10px");
            celula_buton.Controls.Add(lista_butoane[i]);

            TableRow rand = new TableRow();
            rand.Controls.Add(celula_imagine);
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
        nume_cursuri.Clear();
        selecteazaCursurileCautate();
        afiseazaCursurile();
      //  Response.Redirect("login.aspx?o=1");
        //ViewState["lista_taguri"] = nume_taguri;
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
