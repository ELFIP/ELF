using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["este_administrator"])
        {
            adaugaHyperLinkAdmin();
        }
        else
        {
            adaugaHyperLink();
        }

        adaugaLogOut();
    }

    private void adaugaLogOut()
    {
        HyperLink hyperlink_logout = new HyperLink();
        hyperlink_logout.ID = "hyperlink_logout";
        hyperlink_logout.NavigateUrl = "LogOut.aspx";
        hyperlink_logout.Text = "LogOut";

        panou_meniu.Controls.Add(hyperlink_logout);
    }

    private void adaugaHyperLinkAdmin()
    {
        HyperLink hyperlink_cursuri = new HyperLink();
        hyperlink_cursuri.ID = "hyperlink_cursuri";
        hyperlink_cursuri.NavigateUrl = "Cursuri_administrator.aspx";
        hyperlink_cursuri.Text = "Cursuri";

        HyperLink hyperlink_facultati = new HyperLink();
        hyperlink_facultati.ID = "hyperlink_facultati";
        hyperlink_facultati.NavigateUrl = "Pagina_facultati_administrator.aspx";
        hyperlink_facultati.Text = "Facultati";

        HyperLink hyperlink_profil = new HyperLink();
        hyperlink_profil.ID = "hyperlink_profil";
        hyperlink_profil.NavigateUrl = "Profil.aspx";
        hyperlink_profil.Text = "Profil";

        HyperLink hyperlink_administrare_utilizatori = new HyperLink();
        hyperlink_administrare_utilizatori.ID = "hyperlink_administrare_utilizatori";
        hyperlink_administrare_utilizatori.NavigateUrl = "Administrare_utilizator.aspx";
        hyperlink_administrare_utilizatori.Text = "Administrare Utilizator";

        HyperLink hyperlink_panou_recomandari = new HyperLink();
        hyperlink_panou_recomandari.ID = "hyperlink_panou_recomandari";
        hyperlink_panou_recomandari.NavigateUrl = "Panou de control recomandari.aspx";
        hyperlink_panou_recomandari.Text = "Panou Recomandari";

        panou_meniu.Controls.Add(hyperlink_cursuri);
        panou_meniu.Controls.Add(hyperlink_facultati);
        panou_meniu.Controls.Add(hyperlink_profil);
        panou_meniu.Controls.Add(hyperlink_administrare_utilizatori);
        panou_meniu.Controls.Add(hyperlink_panou_recomandari);
    }

    private void adaugaHyperLink()
    {
        HyperLink hyperlink_cursuri = new HyperLink();
        hyperlink_cursuri.ID = "hyperlink_cursuri";
        hyperlink_cursuri.NavigateUrl = "Cursuri.aspx";
        hyperlink_cursuri.Text = "Cursuri";

        HyperLink hyperlink_facultati = new HyperLink();
        hyperlink_facultati.ID = "hyperlink_facultati";
        hyperlink_facultati.NavigateUrl = "Pagina_facultati.aspx";
        hyperlink_facultati.Text = "Facultati";

        HyperLink hyperlink_profil = new HyperLink();
        hyperlink_profil.ID = "hyperlink_profil";
        hyperlink_profil.NavigateUrl = "Profil.aspx";
        hyperlink_profil.Text = "Profil";

        panou_meniu.Controls.Add(hyperlink_cursuri);
        panou_meniu.Controls.Add(hyperlink_facultati);
        panou_meniu.Controls.Add(hyperlink_profil);
    }

}
