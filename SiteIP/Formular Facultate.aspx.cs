using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Formular_Facultate : System.Web.UI.Page
{

    Auxiliare a = new Auxiliare();

    protected void Page_Load(object sender, EventArgs e)
    {
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
        creazaASPX();
        creazaC();
        Response.Redirect(nume_facultate.Text + ".aspx");
    }

    private void creazaASPX() {
        String nume = nume_facultate.Text;
        String localitate = localitatea_facultatii.Text;
        String adresa = adresa_facultatii.Text;
        String informatii = alte_informatii.Text;

        String[] aspxLines = { 

        "<%@ Page Language='C#' AutoEventWireup='true' CodeFile='" + nume + ".aspx.cs' Inherits='" + nume.Replace(" ", "_") + "' MasterPageFile='~/MasterPage.master'%>",
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
        System.IO.File.WriteAllLines(Server.MapPath(nume + ".aspx"), aspxLines);
    }

    private void creazaC() {
        String nume = nume_facultate.Text;
        String[] codeLines = {

            "using System;",
            "using System.Collections.Generic;",
            "using System.Linq;",
            "using System.Web;",
            "using System.Web.UI;",
            "using System.Web.UI.WebControls;",
            " ",
            "public partial class " + nume.Replace(" ","_") + " : System.Web.UI.Page",
            "{",
            " ",
            "    protected void Page_Load(object sender, EventArgs e)",
            "    {",
            "    }",
            "}"
                             };

        System.IO.File.WriteAllLines(Server.MapPath(nume + ".aspx.cs"), codeLines);
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