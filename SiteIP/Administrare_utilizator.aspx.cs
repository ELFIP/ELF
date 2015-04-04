using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Administrare_utilizator : System.Web.UI.Page
{

    private String[] email = new String[200];
    private String[] nume = new String[200];
    private String[] prenume = new String[200];
    private String[] parola = new String[200];
    private int[] este_admin = new int[200];
    Auxiliare a = new Auxiliare();

    int numar_utilizatori = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        adaugaUtilizatori();
        afiseazaUtilizatori();
    }

    private void adaugaUtilizatori()
    {
        numar_utilizatori = 0;
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT email, nume, prenume, parola, este_administrator FROM Utilizator ORDER BY email;";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            email[numar_utilizatori] = sdr.GetValue(0).ToString();
            nume[numar_utilizatori] = sdr.GetValue(1).ToString();
            prenume[numar_utilizatori] = sdr.GetValue(2).ToString();
            parola[numar_utilizatori] = sdr.GetValue(3).ToString();
            este_admin[numar_utilizatori] = int.Parse(sdr.GetValue(4).ToString());
            numar_utilizatori++;
        }
        conexiune.Close();
    }

    public void afiseazaUtilizatori()
    {
        tabel_utilizatori.Rows.Clear();

        adaugaHeader();

        for (int i = 0; i < numar_utilizatori; i ++ )
        {
            
            Button sterge = new Button();
            sterge.Text = "Sterge";
            sterge.CssClass = "butoane_administrare";
            sterge.ID = "sterge" + i;
            sterge.Click += new EventHandler(stergeUtilizator);

            Button admin = new Button();
            admin.Text = "Admin";
            admin.ID = "admin" + i;
            admin.Click += new EventHandler(modificaAdmin);
            if(este_admin[i] == 1) {
                admin.CssClass = "admin";
            }
            else
            {
                admin.CssClass = "noadmin";
            }

            TableCell celula1 = new TableCell();
            celula1.CssClass = "celula_rand";
            celula1.Controls.Add(sterge);
            celula1.Controls.Add(admin);

            TableCell celula2 = new TableCell();
            celula2.Text = email[i];
            celula2.CssClass = "celula_rand";

            TableCell celula3 = new TableCell();
            celula3.Text = nume[i];
            celula3.CssClass = "celula_rand";

            TableCell celula4 = new TableCell();
            celula4.Text = prenume[i];
            celula4.CssClass = "celula_rand";

            TableRow rand = new TableRow();
            rand.Controls.Add(celula1);
            rand.Controls.Add(celula2);
            rand.Controls.Add(celula3);
            rand.Controls.Add(celula4);
            tabel_utilizatori.Controls.Add(rand);
        }
    }

    private void adaugaHeader()
    {
        TableHeaderRow header = new TableHeaderRow();
        header.CssClass = "header";

        TableHeaderCell header_celula1 = new TableHeaderCell();
        header_celula1.Text = "Optiuni";
        header_celula1.CssClass = "celula_header";

        TableHeaderCell header_celula2 = new TableHeaderCell();
        header_celula2.Text = "Email";
        header_celula2.CssClass = "celula_header";

        TableHeaderCell header_celula3 = new TableHeaderCell();
        header_celula3.Text = "Nume";
        header_celula3.CssClass = "celula_header";

        TableHeaderCell header_celula4 = new TableHeaderCell();
        header_celula4.Text = "Prenume";
        header_celula4.CssClass = "celula_header";

        header.Controls.Add(header_celula1);
        header.Controls.Add(header_celula2);
        header.Controls.Add(header_celula3);
        header.Controls.Add(header_celula4);

        tabel_utilizatori.Controls.Add(header);
    }

    private int getInt(String s)
    {
        int n = 0;
        for (int i = 0; i < s.Length; i++ )
        {
            if(s[i] >= '0' && s[i] <= '9') {
                n = n * 10 + (s[i] - '0' );
            }
        }
        return n;
    }

    protected void stergeUtilizator(object sender, EventArgs e)
    {
        if (sender.GetType() == typeof(Button))
        {
            Button buton = (Button)sender;
            String s = buton.ID;
            int i = getInt(s);
            SqlCommand comanda = new SqlCommand();
            SqlConnection conexiune;
            conexiune = new SqlConnection(a.string_bazadedate);
            comanda = new SqlCommand();
            comanda.Connection = conexiune;
            comanda.Connection.Open();
            comanda.CommandText = "DELETE FROM Utilizator WHERE email = '" + email[i] + "';";
            comanda.ExecuteNonQuery();
            conexiune.Close();
            Page_Load(null, EventArgs.Empty);
        }
    }

    protected void modificaAdmin(object sender, EventArgs e)
    {
        if(sender.GetType() == typeof(Button)) {
            Button buton = (Button)sender;
            String s = buton.ID;
            int i = getInt(s);
            if (este_admin[i] == 1)
            {
                SqlCommand comanda = new SqlCommand();
                SqlConnection conexiune;
                conexiune = new SqlConnection(a.string_bazadedate);
                comanda = new SqlCommand();
                comanda.Connection = conexiune;
                comanda.Connection.Open();
                comanda.CommandText = "UPDATE Utilizator SET este_administrator = 0 WHERE email = '" + email[i] + "';";
                comanda.ExecuteNonQuery();
                conexiune.Close();
                ((Button)sender).CssClass = "noadmin";
            }
            else
            {
                if(numarAdmini() <= 100) {
                    SqlCommand comanda = new SqlCommand();
                    SqlConnection conexiune;
                    conexiune = new SqlConnection(a.string_bazadedate);
                    comanda = new SqlCommand();
                    comanda.Connection = conexiune;
                    comanda.Connection.Open();
                    comanda.CommandText = "UPDATE Utilizator SET este_administrator = 1 WHERE email = '" + email[i] + "';";
                    comanda.ExecuteNonQuery();
                    conexiune.Close();
                    ((Button)sender).CssClass = "admin";
                }
                else
                {
                    string message = "Nu pot exista mai mult de 100 de administratori.";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                }
            }
        }
    }

    private int numarAdmini()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "Select COUNT(1) FROM Utilizator WHERE este_administrator = 1;";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        int count = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
        return count;
    }

}
