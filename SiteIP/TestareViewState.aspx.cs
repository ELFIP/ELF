using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

[Serializable()]
public partial class TestareViewState : System.Web.UI.Page
{
    List<HyperLink> nume_cursuri = new List<HyperLink>();
    //List<CheckBox> nume_taguri = new List<CheckBox>();
    List<Button> lista_butoane = new List<Button>();
    Auxiliare a = new Auxiliare();

    protected int NumberOfControls
    {
        get { return (int)ViewState["NumControls"]; }
        set { ViewState["NumControls"] = value; }
    }

    public List<CheckBox> nume_taguri
    {
        get
        {
            if (ViewState["nume_taguri"] == null)
            {
                ViewState["nume_taguri"] = new List<CheckBox>();
            }

            return (List<CheckBox>)ViewState["nume_taguri"];
        }

        set
        {
            ViewState["nume_taguri"] = value;
        }
    }

    protected void CheckBox_CheckChanged(object sender, EventArgs e)
    {
        //Response.Redirect("login.aspx");
        Response.Write(((CheckBox)sender).ClientID);
    }

    void CheckBox1OnChecked(object sender, EventArgs e)
    {
        var cb = (CheckBox)sender;
        //CheckBox1Checked = cb.Checked;
    }

    private void createControls()
    {
        int count = this.NumberOfControls;

        for (int i = 0; i < count; i++)
        {
            TextBox tx = new TextBox();
            tx.ID = "ControlID_" + i.ToString();
            //Add the Controls to the container of your choice
            Panel1.Controls.Add(tx);
        }
    }

    // example of dynamic addition of controls
    // note the use of the ViewState variable
    private void addSomeControl()
    {
        TextBox tx = new TextBox();
        tx.ID = "ControlID_" + NumberOfControls.ToString();

        Page.Controls.Add(tx);
        this.NumberOfControls++;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if ((bool)Session["este_administrator"])
        //{
        //    Response.Redirect("Cursuri_administrator.aspx" );
        // }
        if (!Page.IsPostBack)
            //Initiate the counter of dynamically added controls
            this.NumberOfControls = 3;
        else
            //Controls must be repeatedly be created on postback
            this.createControls();

        /*
        if (!IsPostBack)
        {
          //  selecteazaCursurile();
          //  afiseazaCursurile();
            selecteazaTagurile();
            afiseazaTagurile();
        }
        else
        {
            //Response.Redirect("login.aspx?b=" + nume_taguri.Count);
            //selecteazaTagurile();
            afiseazaTagurile();
            Response.Redirect("login.aspx?b=" + nume_taguri[0].Checked);
          //  afiseazaTagurile();
         //   selecteazaCursurileCautate();
         //   afiseazaCursurile();
        }
         * */
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
            tag.AutoPostBack = true;
            tag.CheckedChanged += CheckBox_CheckChanged;
            nume_taguri.Add(tag);

        }
        conexiune.Close();
    }

    protected void filtrare(object sender, EventArgs e)
    {
        //Response.Redirect("login.aspx?o=1");
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

         //   tabel_checkbox.Controls.Add(rand);
        }
    }

}
