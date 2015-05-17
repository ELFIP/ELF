using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

public partial class Formular_Facultate : System.Web.UI.Page
{

    Auxiliare a = new Auxiliare();
    String format_imagine = "";
    String nume_facultate_ = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["format_imagine"] = "";
            Session["nume_facultate"] = "";
        }
        else
        {
            format_imagine = (String)Session["format_imagine"];
            nume_facultate_ = (String)Session["nume_facultate"];
        }
    }

    public string format(string nume)
    {
        string s = "";
        string[] rezultat = nume.Split('.');
        foreach (string word in rezultat)
        {
            s = word;
        }
        return s;
    }

    protected void Upload(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            if (nume_facultate.Text == "")
            {
                alerta_nume.Text = "Trebuie sa alegi un nume pentru facultate!";
            }
            else
            {
                alerta_nume.Text = "";
                lbl_debug.Text = "";
                format_imagine = format(FileUpload1.FileName);
                Session["format_imagine"] = format_imagine;
                Session["nume_facultate"] = nume_facultate.Text;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Imagini_facultati/") + nume_facultate.Text + "." + format_imagine);
                imagine_facultate.ImageUrl = "/Imagini_facultati/" + nume_facultate.Text + "." + format_imagine;
            }
        }
        else
        {
            lbl_debug.Text = "Selecteaza imaginea pe care vrei sa o adaugi!";
        }
    }

    protected void adauga_facultate_Click(object sender, EventArgs e)
    {
        adaugaInBazaDeDate();
        creazaPaginaNoua();
    }

    protected void adaugaInBazaDeDate()
    {
        insereazaFacultatea();
    }

    protected void creazaPaginaNoua()
    {
        String nume = nume_facultate.Text;
        String localitate = localitatea_facultatii.Text;
        creazaFolder();
        creazaASPX();
        creazaC();
        Response.Redirect("\\Facultati\\" + nume + " " + localitate + "\\" +  nume + " " + localitate + ".aspx");
    }

    private void creazaFolder()
    {
        var folder = Server.MapPath("~/Facultati/" + nume_facultate.Text + " " + localitatea_facultatii.Text);
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }
    }

    private void creazaASPX() {
        String nume = nume_facultate.Text;
        String localitate = localitatea_facultatii.Text;
        String adresa = adresa_facultatii.Text;
        String informatii = alte_informatii.Text;

        String[] aspxLines = {

        "<%@ Page Language='C#' AutoEventWireup='true' CodeFile='" + nume + " " + localitate + ".aspx.cs' Inherits='" + nume.Replace(" ", "_") + "_" + localitate.Replace(" ", "_") + "' MasterPageFile='~/MasterPage.master'%>",
        " ",
        "<asp:Content runat='server' ID='Content1' ContentPlaceHolderID='head'>",
        "</asp:Content>",
        "<asp:Content runat='server' ID='content' ContentPlaceHolderID='ContentPlaceHolder1'>",
        "    <asp:Panel ID=\"formular\" runat=\"server\" CssClass=\"formular_facultate\">",
        "        <asp:TextBox ID=\"nume_facultate\" runat=\"server\" Enabled=\"false\" CssClass=\"nume_facultate_formular\" Text=\"" + nume + "\">",
        " ",
        "        </asp:TextBox>",
        "        <asp:TextBox ID=\"localitatea_facultatii\" runat=\"server\" Enabled=\"false\" CssClass=\"localitate_facultate_formular\" Text=\"" + localitate + "\">",
        " ",
        "        </asp:TextBox>",
        "        <asp:TextBox ID=\"adresa_facultatii\" TextMode=\"multiline\" Enabled=\"false\" Columns=\"50\" Rows=\"5\" runat=\"server\" CssClass=\"adresa_facultate_formular\" Text=\"" + adresa + "\">" ,
        " ",
        "        </asp:TextBox>" ,
        "        <asp:TextBox ID=\"alte_informatii\" TextMode=\"multiline\" Enabled=\"false\" Columns=\"50\" Rows=\"5\" runat=\"server\" CssClass=\"alte_informatii_formular\" Text=\"" + informatii + "\"> ",
        " ",
        "       </asp:TextBox>",
        " ",
        "    </asp:Panel>",
        "</asp:Content>"
                             };
        System.IO.File.WriteAllLines(Server.MapPath("\\Facultati\\" + nume + " " + localitate + "\\" + nume + " " + localitate + ".aspx"), aspxLines);
    }

    private void creazaC() {
        String nume = nume_facultate.Text;
        String localitate = localitatea_facultatii.Text;
        String[] codeLines = {

            "using System;",
            "using System.Collections.Generic;",
            "using System.Linq;",
            "using System.Web;",
            "using System.Web.UI;",
            "using System.Web.UI.WebControls;",
            " ",
            "public partial class " + nume.Replace(" ", "_") + "_" + localitate.Replace(" ", "_") + " : System.Web.UI.Page",
            "{",
            " ",
            "    protected void Page_Load(object sender, EventArgs e)",
            "    {",
            "    }",
            "}"
                             };

        System.IO.File.WriteAllLines(Server.MapPath("\\Facultati\\" + nume + " " + localitate + "\\" + nume + " " + localitate + ".aspx.cs"), codeLines);
    }

    private void insereazaFacultatea()
    {
        SqlCommand dbcommand = new SqlCommand();
        SqlConnection dbconnection;
        dbconnection = new SqlConnection(a.string_bazadedate);
        dbcommand = new SqlCommand();
        dbcommand.Connection = dbconnection;
        dbcommand.Connection.Open();
        dbcommand.CommandText = "Insert into [Facultate] values (" + (maxIdFacultate() + 1) + ", '" + nume_facultate.Text +"', '" + adresa_facultatii.Text + "', '" + localitatea_facultatii.Text + "');";
        dbcommand.ExecuteNonQuery();
        dbconnection.Close();
    }

    private int maxIdFacultate()
    {
        if (numarFacultati() == 0) {
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
            comanda.CommandText = "Select MAX(id_facultate) from Facultate;";
            sdr = comanda.ExecuteReader();
            sdr.Read();
            int max = int.Parse(sdr.GetValue(0).ToString());
            conexiune.Close();
            return max;
        }
    }

    private int numarFacultati()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "Select 1 from Facultate;";
        sdr = comanda.ExecuteReader();
        int i = 0;
        while (sdr.Read())
        {
            i++;
        }
        conexiune.Close();
        return i;
    }

}
