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
            Session["nume_facultate_"] = "";
        }
        else
        {
            format_imagine = (String)Session["format_imagine"];
            nume_facultate_ = (String)Session["nume_facultate_"];
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
                Session["nume_facultate_"] = nume_facultate.Text + localitatea_facultatii.Text;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Imagini_facultati/") + (nume_facultate.Text + localitatea_facultatii.Text) + "." + format_imagine);
                imagine_facultate.ImageUrl = "~/Imagini_facultati/" + (nume_facultate.Text + localitatea_facultatii.Text) + "." + format_imagine;
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
        Session.Remove("format_imagine");
        Session.Remove("nume_facultate_");
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
"<link rel='stylesheet' type='text/css' href=\"/Resources/css/facultati_each.css\" />",
"</asp:Content>",
"<asp:Content runat='server' ID='content' ContentPlaceHolderID='ContentPlaceHolder1'>",
"    <asp:Table ID=\"formularFacultate\" runat=\"server\" Width=\"80%\" Style=\"margin-left: 10%\">",
"        <asp:TableRow Width=\"100%\">",
"            <asp:TableCell HorizontalAlign=\"Center\" Style=\"padding: 10px\" Width=\"20%\">",
"                <asp:Image ID=\"imagine_facultate\" runat=\"server\" Width=\"100px\" Height=\"100px\" ImageUrl=\"" + "~/Imagini_facultati/" + nume_facultate_ + "." + format_imagine  + "\" />",
"            </asp:TableCell>",
"            <asp:TableCell HorizontalAlign=\"Center\" Style=\"padding: 10px\" Width=\"50%\">",
"                <asp:Label ID=\"nume_facultate\" runat=\"server\" Text=\"" + nume + "\" CssClass=\"nume_facultate_formular\" Width=\"50%\">",
"                </asp:Label>",
"            </asp:TableCell>",
"        </asp:TableRow>",
"        <asp:TableRow>",
"            <asp:TableCell HorizontalAlign=\"Center\" Style=\"padding: 10px\" ColumnSpan=\"2\" Width=\"30%\">",
"                <asp:Label ID=\"localitatea_facultatii\" runat=\"server\" Text=\"" + localitate + "\" Width=\"30%\">",
" ",
"                </asp:Label>",
"            </asp:TableCell>",
"        </asp:TableRow>",
"        <asp:TableRow>",
"            <asp:TableCell HorizontalAlign=\"Center\" Style=\"padding: 10px\" ColumnSpan=\"2\" Width=\"100%\">",
"                <asp:Label ID=\"adresa_facultatii\" TextMode=\"MultiLine\" Rows=\"3\" Text=\"" + adresa + "\" runat=\"server\"  Width=\"100%\">",
" ",
"                </asp:Label>",
"            </asp:TableCell>",
"        </asp:TableRow>",
"        <asp:TableRow>",
"            <asp:TableCell HorizontalAlign=\"Center\" Style=\"padding: 10px\" ColumnSpan=\"2\" Width=\"100%\">",
"                <asp:Label ID=\"alte_informatii\" TextMode=\"MultiLine\" Rows=\"5\" Text=\"" + informatii + "\" runat=\"server\" Width=\"100%\">",
"                </asp:Label>",
"            </asp:TableCell>",
"        </asp:TableRow>",
"    </asp:Table>",
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
        dbcommand.CommandText = "Insert into [Facultate] values (" + (maxIdFacultate() + 1) + ", '" + nume_facultate.Text +"', '" + adresa_facultatii.Text + "', '" + localitatea_facultatii.Text + "' , '" + nume_facultate_ + "." + format_imagine + "');";
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
