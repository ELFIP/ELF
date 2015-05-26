using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
 
public partial class Testul_1 : System.Web.UI.Page
{
    Auxiliare a = new Auxiliare();
    int id_test;
    int id_utilizator;
    int id_curs;
    int nota_data;
    int numar_note = 0;
    int numar_raspunsuri = 0;
    int numar_raspunsuri_corecte = 0;
    double nota_obtinuta;
    double media_notelor_test;
    private string email;
    List<List<CheckBox>> bifat = new List<List<CheckBox>>();
    List<string> intrebari = new List<string>  { "Cu referire la conturile saptamanale publicate de Fed, care din urmatoarele elemente surprinde cel mai bine conceptul de lichiditate rezervate pentru banca centrala a Statelor Unite?", "Care a fost cea mai mare diferenta intre sistemul bancar national si Rezervele Federale?", "Care dintre urmatoarele afirmatii NU este o caracterizare corecta a opiniilor lui Minsky?", "De ce bancile au suspendat convertibilitatea dupa Salmon P. Chase care a retras incasarile de imprumut?", "Care din urmatoarele afirmatii despre finantele Razboiului civil nu este adevarata?", "Potrivit Selon Minsky, o companie de start-up din Silicon Valley care asteapta sa depaseasca actualele incasari curente de cheltuieli pentru urmatorii cinci ani este angajata in ..." };
    List<List<string>> raspunsuri = new List<List<string>>  { new List<string> {  " SDR + Aur + valuta", "Aur", "Moneda", " Drepturi Speciale de Tragere" },  new List<string> {  " Sistemul FR a instituit rezerve minime obligatorii pentru a adauga disciplina sistemului", " Disciplina versus Elasticitate", " Standardul de aur fata de bani Fiat", " Sistemul NB a avut o elasticitate mai mare, deoarece bancile au fost autorizate sa-si incheie evaluare lor proprie" },  new List<string> {  " Fiecare agent din economie - firme, gospodarii, guverne - poate fi considerata ca un fel de banca, echilibrand fluxul de numerar si fluxul de iesiri", " Speculatia este rea si ar trebui interzisa", " O banca centrala care actioneaza in calitate de imprumutator de ultima instanta poate pune o podea sub criza financiara", "Firmele finantate speculativ au intrari de numerar mai mari decat angajamentele de fluxuri de numerar" },  new List<string> {  " Bancherii a vrut sa devalorizeze dolarul pentru a profita din exploatatiile de schimb valutar", " Bancherii a vrut sa pedepseasca guvernul pentru pacalirea lor", " Bancile nu au putut in mod credibil sa promita a plati aur pentru a solutiona balanta platilor externe ", " Retragerea de aur au facut bancile insolvabile" },  new List<string> {  " Finantarea de bani a fost o masura de disperare, in ultima instanta", " Prin emiterea bancnotelor, guvernul a platit mult mai putin in cele din urma pentru achizitiile din razboi", "Incertitudinea cu privire la eventuala paritatea a aurului a ofertelor legale au provocat rata de schimb dolar sa scada", " Rezultatul bancnotelor ca plata pentru materiale de razboi au determinat o crestere a cererii agregate in general, care a condus la cresterea preturilor" },  new List<string> {  " tiparirea de bani", " practica de afaceri standard", " munca de caritate", " fondurile speculative, daca au capital de risc, au angajamente suficiente pentru a acoperi pierderile" }  } ;
    List<List<bool>> raspunsuri_corecte = new List<List<bool>>  { new List<bool> {  true, false, false, false },  new List<bool> {  false, true, false, false },  new List<bool> {  false, true, false, false },  new List<bool> {  true, false, false, false },  new List<bool> {  false, false, true, false },  new List<bool> {  false, true, false, false }  } ;
    Table tabel_intrebari_raspunsuri = new Table();
    Button buton_evalueaza = new Button();
    public bool testInceput = false;
 
    // Timp de rezolvare;
    int timp_rezolvare;
 
    // Cate minute dureaza testul;
    public int minute_bazaDeDate = 0;
 
    // Cate ore dureaza testul;
    public int ore_bazaDeDate = 0;
 
    DateTime Start;
    DateTime End;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        afiseazaIntrebarileSiRaspunsurile();
        culegeDate();
        selecteazaIdUtilizator();
        selecteazaIdCurs();
        selecteazaIdTest();
        selecteazaTimpTest();
        timpTest();
        afiseazaTimpRezolvare();
        if (!IsPostBack) {
           numarNote();
           selecteazaNotaDataTest();
           afiseazaNotaData();
           Session["Test_inceput"] = false;
        }
    }
 
     private void numarNote()
     {
         SqlCommand comanda = new SqlCommand();
         SqlConnection conexiune;
         conexiune = new SqlConnection(a.string_bazadedate);
         comanda.Connection = conexiune;
         comanda.Connection.Open();
         SqlDataReader sdr;
         comanda.CommandText = "SELECT 1 FROM Utilizator_Test WHERE id_utilizator = " + id_utilizator + " AND id_test = " + id_test + ";";
         sdr = comanda.ExecuteReader();
         while(sdr.Read()) {
             numar_note++;
         }
         conexiune.Close();
     }
 
    private void afiseazaIntrebarileSiRaspunsurile() {
        //Table tabel_intrebari_raspunsuri = new Table();
        tabel_intrebari_raspunsuri.ID = "tabel_intrebari_raspunsuri";
        tabel_intrebari_raspunsuri.Style.Add("display", "none");
 
        for (int i = 0; i < intrebari.Count; i++)
        {
            TableRow rand_intrebare = new TableRow();
            TableCell celula_intrebare = new TableCell();
            celula_intrebare.HorizontalAlign = HorizontalAlign.Center;
            celula_intrebare.Attributes.Add("style", "padding: 10px");
 
            TableRow rand_raspuns = new TableRow();
            TableCell celula_raspuns = new TableCell();
            celula_raspuns.HorizontalAlign = HorizontalAlign.Center;
            celula_raspuns.Attributes.Add("style", "padding: 10px");
 
            Label intrebare = new Label();
            intrebare.ID = "intrebare" + i;
            intrebare.Width = new Unit("500");
            intrebare.Text = intrebari[i];
 
            Table tabel_raspunsuri = new Table();
            tabel_raspunsuri.ID = "tabel_raspunsuri" + i;
 
            bifat.Add(new List<CheckBox>());
 
            for (int j = 0; j < raspunsuri[i].Count; j++)
            {
                TableRow rand_raspuns_i = new TableRow();
                TableCell celula_raspuns_i = new TableCell();
                celula_raspuns_i.HorizontalAlign = HorizontalAlign.Center;
                celula_raspuns_i.Attributes.Add("style", "padding: 10px");
 
                CheckBox c = new CheckBox();
                c.ID = "checkbox" + i + "" + j;
                bifat[i].Add(c);
 
                Label raspuns = new Label();
                raspuns.ID = "raspuns" + i + "" + j;
                raspuns.Width = new Unit("500");
                raspuns.Text = raspunsuri[i][j];
 
                celula_raspuns_i.Controls.Add(c);
                celula_raspuns_i.Controls.Add(raspuns);
                rand_raspuns_i.Controls.Add(celula_raspuns_i);
                tabel_raspunsuri.Controls.Add(rand_raspuns_i);
            }
 
            celula_intrebare.Controls.Add(intrebare);
            celula_raspuns.Controls.Add(tabel_raspunsuri);
 
            rand_intrebare.Controls.Add(celula_intrebare);
            rand_raspuns.Controls.Add(celula_raspuns);
 
            tabel_intrebari_raspunsuri.Controls.Add(rand_intrebare);
            tabel_intrebari_raspunsuri.Controls.Add(rand_raspuns);
        }
 
        TableRow rand_tabel = new TableRow();
        TableCell celula_tabel = new TableCell();
        celula_tabel.HorizontalAlign = HorizontalAlign.Center;
        celula_tabel.ColumnSpan = 2;
        celula_tabel.Attributes.Add("style", "padding: 10px");
 
        celula_tabel.Controls.Add(tabel_intrebari_raspunsuri);
        rand_tabel.Controls.Add(celula_tabel);
 
        TableRow rand_buton_evaluare = new TableRow();
        TableCell celula_buton_evaluare = new TableCell();
        celula_buton_evaluare.HorizontalAlign = HorizontalAlign.Center;
        celula_buton_evaluare.ColumnSpan = 2;
        celula_buton_evaluare.Attributes.Add("style", "padding: 10px");
 
        //Button buton_evalueaza = new Button();
        buton_evalueaza.Text = "Evalueaza";
        buton_evalueaza.ID = "buton_evalueaza";
        buton_evalueaza.Click += evalueazaTest;
 
        celula_buton_evaluare.Controls.Add(buton_evalueaza);
        rand_buton_evaluare.Controls.Add(celula_buton_evaluare);
 
        celula_test.Controls.Add(rand_tabel);
        celula_test.Controls.Add(rand_buton_evaluare);
   }
 
    private void obtineRezultat() {
        for(int i = 0; i < bifat.Count; i++) {
            for(int j = 0; j < bifat[i].Count; j++) {
                numar_raspunsuri ++;
                if(bifat[i][j].Checked == raspunsuri_corecte[i][j]) {
                    numar_raspunsuri_corecte ++;
                }
            }
        }
        nota_obtinuta = (double)numar_raspunsuri_corecte / (double)numar_raspunsuri;
    }
 
    private void actualizeazaLabel() {
        celula_rezultat.Text = " Rezultat: " + nota_obtinuta;
    }
 
    private void insereazaRezultatInBazaDeDate() {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "Insert into [Utilizator_Test] values (" + id_utilizator + ", " + id_test + ", CONVERT(VARCHAR(10), GETDATE(), 10), " + nota_obtinuta + "  , 0 );";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }
    protected void evalueazaTest(object sender, EventArgs e)
    {
        // Testul s-a terminat;
        testInceput = false;
 
        obtineRezultat();
        actualizeazaLabel();
        insereazaRezultatInBazaDeDate();
 
        // Stergem variabilele de sesiune;
        Session.Remove("Test_inceput");
    }
 
    private void culegeDate()
    {
        email = (string)Session["email"];
    }
 
    private void afiseazaNotaData()
    {
        switch (nota_data)
        {
            case 1:
                id_nota1.Selected = true;
                break;
            case 2:
                id_nota2.Selected = true;
                break;
            case 3:
                id_nota3.Selected = true;
                break;
            case 4:
                id_nota4.Selected = true;
                break;
            case 5:
                id_nota5.Selected = true;
                break;
        }
    }
 
    private void selecteazaNotaDataTest()
    {
        if (numar_note == 0) {
            nota_data = 0;
        }
        else
        {
            SqlCommand comanda = new SqlCommand();
            SqlConnection conexiune;
            conexiune = new SqlConnection(a.string_bazadedate);
            comanda.Connection = conexiune;
            comanda.Connection.Open();
            SqlDataReader sdr;
            comanda.CommandText = "SELECT nota_data FROM Utilizator_Test WHERE id_utilizator = " + id_utilizator + " AND id_test = " + id_test + ";";
            sdr = comanda.ExecuteReader();
            sdr.Read();
            nota_data = int.Parse(sdr.GetValue(0).ToString());
            conexiune.Close();
        }
    }
 
    private void selecteazaIdCurs()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT id_curs FROM Curs WHERE nume = '" + numeCurs.Text + "';";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        id_curs = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
    }
 
    private void selecteazaIdTest()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT id_test FROM Test WHERE nume = '" + numeTest.Text + "' AND id_curs = " + id_curs + ";";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        id_test = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
    }
 
    private void timpTest()
    {
        minute_bazaDeDate = timp_rezolvare % 60;
        ore_bazaDeDate = timp_rezolvare / 60;
    }
 
    private void afiseazaTimpRezolvare()
    {
        id_timp_rezolvare.Text = "Timp rezolvare: " + ore_bazaDeDate + " ore " + minute_bazaDeDate + " minute ";
    }
 
    private void selecteazaTimpTest()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT timp_rezolvare FROM Test WHERE id_test = " + id_test + ";";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        timp_rezolvare = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
    }
 
    private void selecteazaIdUtilizator()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT id_utilizator FROM Utilizator WHERE email = '" + email + "';";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        id_utilizator = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
    }
 
    private void actualizeazaNotaDataTest(int nota)
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "UPDATE [Utilizator_Test] SET nota_data = " + nota + " WHERE id_utilizator = " + id_utilizator + " AND id_test = " + id_test + ";";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }
 
    private void selecteazaMediaNotelorTest()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT AVG(nota_data) FROM Utilizator_Test WHERE id_test = " + id_test + ";";
        sdr = comanda.ExecuteReader();
        sdr.Read();
        media_notelor_test = int.Parse(sdr.GetValue(0).ToString());
        conexiune.Close();
    }
 
    private void actualizeazaMediaNotelorTest(int nota)
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "UPDATE [Test] SET media_notelor = " + media_notelor_test + " WHERE id_test = " + id_test + " AND id_curs = " + id_curs + ";";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }
 
    protected void selectare(object sender, EventArgs e)
    {
        if (id_nota1.Selected == true)
        {
            actualizeazaNotaDataTest(1);
            selecteazaMediaNotelorTest();
            actualizeazaMediaNotelorTest(1);
        }
        else if (id_nota2.Selected == true)
        {
            actualizeazaNotaDataTest(2);
            selecteazaMediaNotelorTest();
            actualizeazaMediaNotelorTest(2);
        }
        else if (id_nota3.Selected == true)
        {
            actualizeazaNotaDataTest(3);
            selecteazaMediaNotelorTest();
            actualizeazaMediaNotelorTest(3);
        }
        else if (id_nota4.Selected == true)
        {
            actualizeazaNotaDataTest(4);
            selecteazaMediaNotelorTest();
            actualizeazaMediaNotelorTest(4);
        }
        else
        {
            actualizeazaNotaDataTest(5);
            selecteazaMediaNotelorTest();
            actualizeazaMediaNotelorTest(5);
        }
    }
 
    protected void incepeTest(object sender, EventArgs e)
    {
        buton_start.Enabled = false;
        tabel_intrebari_raspunsuri.Style.Add("display", "inline-table");
        buton_evalueaza.Style.Add("display", "inline-table");
        Session["Test_inceput"] = true;
        testInceput = (bool)Session["Test_inceput"];
    }
}
 
