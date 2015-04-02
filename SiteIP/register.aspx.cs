using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_trimite_Click(object sender, EventArgs e)
    {
        SqlCommand dbcommand = new SqlCommand();
        SqlConnection dbconnection;
        dbconnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Mihai Alexandru\Dropbox\Facultate\Anul 3\Semestrul II\Ingineria programarii\Site - repository\ELF1\ELF\SiteIP\App_Data\Database.mdf';Integrated Security=True");
        dbcommand = new SqlCommand();
        dbcommand.Connection = dbconnection;
        dbcommand.Connection.Open();
        dbcommand.CommandText = "Insert into [Utilizator] values (" + (dbSize() + 1) + ", '" + tb_email.Text + "', '" + tb_parola.Text + "',  '" + tb_nume.Text + "', '" + tb_prenume.Text + "', '01/01/2000', '" + DateTime.Now + "', " + int.Parse(tb_mediaNotelor.Text) + ", '" + tb_adresa.Text + "', " + 1 + " );";
        dbcommand.ExecuteNonQuery();
        dbconnection.Close();
    }
    private int dbSize()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Mihai Alexandru\Dropbox\Facultate\Anul 3\Semestrul II\Ingineria programarii\Site - repository\ELF1\ELF\SiteIP\App_Data\Database.mdf';Integrated Security=True");
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "Select * from [Utilizator]";
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