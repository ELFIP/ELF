using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class resetpassword : System.Web.UI.Page
{
    private Auxiliare a = new Auxiliare();
    private string email = "";
    private string parola = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        email = Request.QueryString["email"];
        parola = Request.QueryString["parola"];

        Label1.Text = "Email: " + email;
        Label2.Text = "   Parola: " + parola;

        update_parola();
    }
    private void update_parola()
    {
        SqlCommand dbcommand = new SqlCommand();
        SqlConnection dbconnection;
        dbconnection = new SqlConnection(a.string_bazadedate);
        dbcommand = new SqlCommand();
        dbcommand.Connection = dbconnection;
        dbcommand.Connection.Open();
        dbcommand.CommandText = "UPDATE [Utilizator] SET parola = '" + parola + "' WHERE email = '" + email + "';";
        dbcommand.ExecuteNonQuery();
        dbconnection.Close();
        Response.Redirect("login.aspx");
    }
}