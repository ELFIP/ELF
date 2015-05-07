using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Formular_Videoclip : System.Web.UI.Page
{
    Auxiliare a = new Auxiliare();
    string nume_curs = null;
    int id_curs;

    protected void Page_Load(object sender, EventArgs e)
    {

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

    protected void buton_upload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Cursuri/") + nume_curs + "/" + numeVideoclip.Text + "." + format(FileUpload1.FileName));
            afiseaza.Src = "/Cursuri/" + nume_curs + "/" + numeVideoclip.Text + "." + format(FileUpload1.FileName);
        }
        else
        {
            lbl_debug.Text = "Selecteaza cursul pe care vrei sa-l urci !";
        }
    }

    private void adaugaInBazaDeDate()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "Insert into [Videoclip] values (" + (maxIdVideoclip() + 1) + ", " + id_curs + ", '" + numeVideoclip.Text + "',  CONVERT(VARCHAR(10), GETDATE(), 10), null );";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }

    private int maxIdVideoclip()
    {
        if (numarVideoclipuri() == 0)
        {
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
            comanda.CommandText = "Select MAX(id_videoclip) from Videoclip;";
            sdr = comanda.ExecuteReader();
            sdr.Read();
            int max = int.Parse(sdr.GetValue(0).ToString());
            conexiune.Close();
            return max;
        }
    }

    private int numarVideoclipuri()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "Select 1 from Videoclip;";
        sdr = comanda.ExecuteReader();
        int i = 0;
        while (sdr.Read())
        {
            i++;
        }
        conexiune.Close();
        return i;
    }

    protected void buton_creeaza_Click(object sender, EventArgs e)
    {
        adaugaInBazaDeDate();
        creazaASPX();
        creazaC();
    }

    private void creazaASPX()
    {

        String[] aspxLines = {
"<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeFile=\""+numeVideoclip.Text+".aspx.cs\" Inherits=\""+numeVideoclip.Text+"\" MasterPageFile=\"~/MasterPage.master\"%>",
"",
"<asp:Content runat=\"server\" ID=\"Content1\" ContentPlaceHolderID=\"head\">",
"</asp:Content>",
"",
"<asp:Content runat=\"server\" ID=\"content\" ContentPlaceHolderID=\"ContentPlaceHolder1\">",
"       <asp:Table ID=\"formular\" runat=\"server\" Width=\"80%\" style=\"margin-left: 10%\">",
"            <asp:TableHeaderRow Width=\"100%\" >",
"                <asp:TableHeaderCell HorizontalAlign=\"Center\" style=\"padding:10px\">",
"                    <asp:Label ID=\"numeVideoclip\" runat=\"server\" placeholder=\"Nume videoclip\" Width=\"50%\" Text=\"" + numeVideoclip.Text + "\">",
"                   </asp:Label>",
"               </asp:TableHeaderCell>",
"            </asp:TableHeaderRow>",
"           <asp:TableRow>",
"               <asp:TableCell HorizontalAlign=\"Center\">",
"                   <iframe width=\"560\" ID=\"afiseaza\" height=\"315\" src=\""+"/Cursuri/" + nume_curs + "/" + numeVideoclip.Text + "." + format(FileUpload1.FileName)+"\" frameborder=\"0\" allowfullscreen runat=\"server\"></iframe>",
"              </asp:TableCell>",
"           </asp:TableRow>",
"          <asp:TableRow>",
"               <asp:TableCell HorizontalAlign=\"Center\">",
"               </asp:TableCell>",
"           </asp:TableRow>",
"        </asp:Table>",
"</asp:Content>",

                  
                             };
        System.IO.File.WriteAllLines(Server.MapPath("\\Cursuri\\" + nume_curs + "\\" + numeVideoclip.Text + ".aspx"), aspxLines);
    }

    private void creazaC()
    {

        String[] codeLines = {
"using System;",
"using System.Collections.Generic;",
"using System.Linq;",
"using System.Web;",
"using System.Web.UI;",
"using System.Web.UI.WebControls;",

"public partial class "+numeVideoclip.Text+" : System.Web.UI.Page",
"{",
"    protected void Page_Load(object sender, EventArgs e)",
"    {",
"",
"    }",
"",
"",
"}",
                             };

        System.IO.File.WriteAllLines(Server.MapPath("\\Cursuri\\" + nume_curs + "\\" + numeVideoclip.Text + ".aspx.cs"), codeLines);
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
}
