using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MedicoSolutions.Entity
{
    public class Searchmedicine
    {
        SqlConnection con;

        public Searchmedicine()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        }


        public List<SearchmedicineDetails> search(string medicine)
        {
            List<SearchmedicineDetails> vd1 = new List<SearchmedicineDetails>();
            SqlDataReader rd;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Search_medicine where Medicine_Name = '"+medicine+"'";

            cmd.Connection = con;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                SearchmedicineDetails v1 = new SearchmedicineDetails();
                v1.medicinename = Convert.ToString(rd[0]);
                v1.shopname = Convert.ToString(rd[1]);
                v1.address = Convert.ToString(rd[2]);
                v1.phone_no = Convert.ToString(rd[3]);
                vd1.Add(v1);
            }

            rd.Close();
            con.Close();
            return vd1;

        }

        public List<search_medicinedetails> gets()
        {
            List<search_medicinedetails> vd = new List<search_medicinedetails>();
            SqlDataReader rd;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select distinct Medicine_Name from Search_Medicine ";

            cmd.Connection = con;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                search_medicinedetails v1 = new search_medicinedetails();
                v1.medicinename = Convert.ToString(rd[0]);
               
                vd.Add(v1);
            }
            rd.Close();
            con.Close();
            return vd;

        }

    }
    public class SearchmedicineDetails
    {
        public string medicinename { get; set; }
        public string shopname { get; set; }
        public string address { get; set; }
        public string phone_no { get; set; }
    }
    public class search_medicinedetails
    {
        public string medicinename { get; set; }
    }
}