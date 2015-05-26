using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Sterge_curs : System.Web.UI.Page
{
    Auxiliare a = new Auxiliare();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id_curs"] != null)
        {
            stergeCurs(int.Parse(Request.QueryString["id_curs"].ToString()));
            Response.Redirect("Cursuri_administrator.aspx");
        }
    }

    private void stergeCurs(int id)
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "DELETE FROM Curs WHERE id_curs = " + id + ";";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }

    private int getID(String s)
    {
        int n = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] >= '0' && s[i] <= '9')
            {
                n = n * 10 + (s[i] - '0');
            }
        }
        return n;
    }
}