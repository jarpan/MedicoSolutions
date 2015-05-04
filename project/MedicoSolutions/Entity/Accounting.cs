using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace MedicoSolutions.Entity
{

    
    public class Accounting
    {
        SqlConnection con;

        public Accounting()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        }

        public List<AccountingDetails> getAccount()
        {
            List<AccountingDetails> vd1 = new List<AccountingDetails>();
            SqlDataReader rd;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select invoice_date,profit_per_bill,amount from mst_invoice_master";

            cmd.Connection = con;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                AccountingDetails v1 = new AccountingDetails();
                v1.invoice_date = Convert.ToDateTime(rd[0]);
                v1.profit=Convert.ToDecimal(rd[1]);
                v1.sales = Convert.ToDecimal(rd[2]);
              
                vd1.Add(v1);
            }
            
            rd.Close();
            con.Close();
            return vd1;

        }


    }

    public class AccountingDetails
    {
        public decimal profit { get; set; }
        public DateTime invoice_date { get; set; }
        public decimal sales { get; set; }
    }
}