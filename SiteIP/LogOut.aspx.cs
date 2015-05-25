using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LogOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Remove("id_utilizator");
        Session.Remove("email");
        Session.Remove("parola");
        Session.Remove("nume");
        Session.Remove("prenume");
        Session.Remove("data_nasterii");
        Session.Remove("data_inregistrarii");
        Session.Remove("media_notelor");
        Session.Remove("domiciliu");
        Session.Remove("este_administrator");
        Session.Remove("Cursuri");
        Session.Remove("NumeCursuri");
        Session.Remove("VideoclipuriVazute");
        Session.Remove("TesteDate");
        Session.Remove("FacultatiRecomandate");
        Session.Remove("NumeFacultatiRecomandate");
        Response.Redirect("login.aspx");
    }
}