using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
{
    Auxiliare a = new Auxiliare();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_trimite_Click(object sender, EventArgs e)
    {
        int id_max = maxId() + 1;
        SqlCommand dbcommand = new SqlCommand();
        SqlConnection dbconnection;
        dbconnection = new SqlConnection(a.string_bazadedate);
        dbcommand = new SqlCommand();
        dbcommand.Connection = dbconnection;
        dbcommand.Connection.Open();
        dbcommand.CommandText = "Insert into [Utilizator] values (" + id_max + ", '" + tb_email.Text + "', '" + tb_parola.Text + "',  '" + tb_nume.Text + "', '" + tb_prenume.Text + "', '01/01/2000', '" + DateTime.Now + "', " + int.Parse(tb_mediaNotelor.Text) + ", '" + tb_adresa.Text + "', " + 1 + " );";
        dbcommand.ExecuteNonQuery();
        dbconnection.Close();

        Distanta d = new Distanta(id_max, tb_adresa.Text, "");
        d.insereazaDistante();
    }

    private int maxId()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "Select MAX(id_utilizator) from [Utilizator]";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        int max = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
        return max;
    }
}