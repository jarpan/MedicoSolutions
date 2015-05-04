using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace MedicoSolutions.Entity
{
    public class company
    {
        SqlConnection con;
        public company()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        }

        public List<companydata> getcompname()
        {
            List<companydata> cd = new List<companydata>();
            SqlDataReader rd;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from mst_companyMaster";

            cmd.Connection = con;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                companydata c1 = new companydata();

                c1.id = rd[0].ToString();
                c1.name= rd[1].ToString();
                cd.Add(c1);
            }
            rd.Close();
            con.Close();
            return cd;
        }
    }


    public class companydata
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    }