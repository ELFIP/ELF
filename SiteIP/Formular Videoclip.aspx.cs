using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formular_Videoclip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void buton_upload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Cursuri/") + FileUpload1.FileName); 
        }
        else
        {
            lbl_debug.Text = "Selecteaza cursul pe care vrei sa-l urci !";
        }
    }
}
