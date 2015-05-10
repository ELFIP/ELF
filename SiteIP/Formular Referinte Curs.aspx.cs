using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formular_Referinte_Curs : System.Web.UI.Page
{
    List<Label> lista_facultati = new List<Label>();
    List<CheckBox> checkbox_facultati = new List<CheckBox>();
    List<TextBox> nume_tag = new List<TextBox>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack) {

        }
    }

    protected void adauga_referinte_Click(object sender, EventArgs e)
    {

    }
}
