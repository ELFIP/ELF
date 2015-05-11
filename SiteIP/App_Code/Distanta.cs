using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;
using System.Data;
using System.IO;
using System.Xml.XPath;
using System.Collections;
using System.Data.SqlClient;

public class Distanta
{
    int id_utilizator;
    String locatie_utilizator;
    String judet_utilizator;
    ArrayList listaLocatii = new ArrayList();
    ArrayList listaIdLocatii = new ArrayList();
    Auxiliare a = new Auxiliare();

    public Distanta(int id_utilizator, String locatie_utilizator, String judet)
    {
        this.id_utilizator = id_utilizator;
        this.locatie_utilizator = locatie_utilizator;
        this.judet_utilizator = judet;
    }

    private void aflaListaLocatii()
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        SqlDataReader sdr;
        comanda.CommandText = "SELECT id_locatie, oras FROM [Locatie];";
        sdr = comanda.ExecuteReader();
        while (sdr.Read())
        {
            listaIdLocatii.Add(sdr.GetValue(0));
            listaLocatii.Add(sdr.GetValue(1));
        }
        conexiune.Close();
    }

    public string DistanceMatrixRequest(string source, string destination)
    {
        string xmlResult = null;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + source + "&destinations=" + destination + "&mode=Car&language=us-en&sensor=false");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader resStream = new StreamReader(response.GetResponseStream());
        XmlDocument doc = new XmlDocument();
        xmlResult = resStream.ReadToEnd();
        doc.LoadXml(xmlResult);
        string output = "";

        if (doc.DocumentElement.SelectSingleNode("/DistanceMatrixResponse/row/element/status").InnerText.ToString().ToUpper() != "OK")
        {
            return "";
        }

        XmlNodeList xnList = doc.SelectNodes("/DistanceMatrixResponse");
        foreach (XmlNode xn in xnList)
        {
            if (xn["status"].InnerText.ToString() == "OK")
            {
                output = doc.DocumentElement.SelectSingleNode("/DistanceMatrixResponse/row/element/distance/text").InnerText;
            }
        }
        return output;
    }

    public int stringToInt(string s)
    {
        int n = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] >= '0' && s[i] <= '9')
            {
                n = n * 10 + (s[i] - '0');
            }
            else
            {
                return n;
            }
        }
        return n;
    }

    public void insereazaDistante()
    {
        aflaListaLocatii();
        for (int i = 0; i < listaIdLocatii.Count; i++)
        {
            int id_locatie;
            string destinatie;
            int distanta;

            id_locatie = (int)listaIdLocatii[i];
            destinatie = (string)listaLocatii[i];
            distanta = stringToInt(DistanceMatrixRequest(locatie_utilizator, destinatie));
            insereazaDestinatie(id_locatie, distanta);
        }
    }

    private void insereazaDestinatie(int id_locatie, int distanta)
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "Insert into [Distanta] values (" + id_utilizator + ", " + id_locatie + ", " + distanta + " );";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }

    public void actualizeazaDistante()
    {
        aflaListaLocatii();
        for (int i = 0; i < listaIdLocatii.Count; i++)
        {
            int id_locatie;
            string destinatie;
            int distanta;

            id_locatie = (int)listaIdLocatii[i];
            destinatie = (string)listaLocatii[i];
            distanta = stringToInt(DistanceMatrixRequest(locatie_utilizator, destinatie));
            actualizeazaDestinatie(id_locatie, distanta);
        }
    }

    private void actualizeazaDestinatie(int id_locatie, int distanta)
    {
        SqlCommand comanda = new SqlCommand();
        SqlConnection conexiune;
        conexiune = new SqlConnection(a.string_bazadedate);
        comanda = new SqlCommand();
        comanda.Connection = conexiune;
        comanda.Connection.Open();
        comanda.CommandText = "UPDATE Distanta SET distanta = " + distanta + " WHERE id_utilizator = " + id_utilizator + " AND id_locatie = " +id_locatie + ";";
        comanda.ExecuteNonQuery();
        conexiune.Close();
    }

}