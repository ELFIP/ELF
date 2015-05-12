using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Cursuri : System.Web.UI.Page
{
    List<HyperLink> nume_cursuri = new List<HyperLink>();
    List<CheckBox> nume_taguri = new List<CheckBox>();
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
            //Response.Redirect("login.aspx?n=" + nume_taguri.Count);
            afiseazaTagurile();
            selecteazaCursurileCautate();
            afiseazaCursurile();
        }
    }

    protected void selecteazaCursurileCautate()
    {
        for (int i = 0; i < nume_taguri.Count; i++)
        {
            if (nume_taguri[i].Checked == true)
            {
                SqlCommand comanda = new SqlCommand();
                SqlConnection conexiune;
                conexiune = new SqlConnection(a.string_bazadedate);
                comanda.Connection = conexiune;
                comanda.Connection.Open();
                SqlDataReader sdr;
                comanda.CommandText = "SELECT c.nume FROM Curs c, Tag t WHERE t.id_curs = c.id_curs AND t.nume = '" + nume_taguri[i].Text + "' AND c.nume LIKE '%" + cauta_curs.Text + "%';";
                sdr = comanda.ExecuteReader();
                while (sdr.Read())
                {
                    string nume_curs = sdr.GetValue(0).ToString();
                    HyperLink curs = new HyperLink();
                    curs.NavigateUrl = "Cursuri/" + nume_curs + "/" + nume_curs + ".aspx";
                    curs.Text = nume_curs;
                    nume_cursuri.Add(curs);
                }
                conexiune.Close();
            }
        }
    }

    protected void selecteazaCursurile()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT nume FROM Curs;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            string nume_curs = sdr.GetValue(0).ToString();
            HyperLink curs = new HyperLink();
            curs.NavigateUrl = "Cursuri/" + nume_curs + "/" + nume_curs + ".aspx";
            curs.Text = nume_curs;
            nume_cursuri.Add(curs);
        }
        conexiune.Close();
    }

    public void afiseazaCursurile()
    {
        for (int i = 0; i < nume_cursuri.Count; i++)
        {
            TableCell celula = new TableCell();
            celula.Controls.Add(nume_cursuri[i]);

            TableRow rand = new TableRow();
            rand.Controls.Add(celula);

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
            CheckBox tag = new CheckBox();
            tag.CssClass = "checkbox";
            tag.Text = nume_tag;
            tag.ID = nume_tag;
            tag.Checked = false;
            tag.CausesValidation = false;
            tag.CheckedChanged += new EventHandler(CheckBox_CheckChanged);
            tag.AutoPostBack = true;
            nume_taguri.Add(tag);
        }
        conexiune.Close();
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

}