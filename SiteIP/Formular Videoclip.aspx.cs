using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formular_Videoclip : System.Web.UI.Page
{
    string s = null;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void buton_upload_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["nume_curs"] != null)
        {
            s = Request.QueryString["nume_curs"].ToString();
        }

        if (FileUpload1.HasFile)
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Cursuri/")+ s + "/" + numeVideoclip.Text + "." + format(FileUpload1.FileName));
            afiseaza.Src = "/Cursuri/" + s + "/" + numeVideoclip.Text + "." + format(FileUpload1.FileName);
        }
        else
        {
            lbl_debug.Text = "Selecteaza cursul pe care vrei sa-l urci !";
        }
    }

    protected void buton_creeaza_Click(object sender, EventArgs e)
    {
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
"                    <asp:Label ID=\"numeVideoclip\" runat=\"server\" placeholder=\"Nume videoclip\" Width=\"50%\" Text=\""+s+"\">",
"                   </asp:Label>",
"               </asp:TableHeaderCell>",
"            </asp:TableHeaderRow>",
"           <asp:TableRow>",
"               <asp:TableCell HorizontalAlign=\"Center\">",
"                   <iframe width=\"560\" ID=\"afiseaza\" height=\"315\" src=\""+"/Cursuri/" + s + "/" + numeVideoclip.Text + "." + format(FileUpload1.FileName)+"\" frameborder=\"0\" allowfullscreen runat=\"server\"></iframe>",
"              </asp:TableCell>",
"           </asp:TableRow>",
"          <asp:TableRow>",
"               <asp:TableCell HorizontalAlign=\"Center\">",
"               </asp:TableCell>",
"           </asp:TableRow>",
"        </asp:Table>",
"</asp:Content>",

                  
                             };
        System.IO.File.WriteAllLines(Server.MapPath("\\Cursuri\\" + s + "\\" + s + ".aspx"), aspxLines);
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

        System.IO.File.WriteAllLines(Server.MapPath("\\Cursuri\\" + s + "\\" + s + ".aspx.cs"), codeLines);
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
