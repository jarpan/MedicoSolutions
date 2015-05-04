using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;

namespace MedicoSolutions.Entity
{
    public class invoice
    {
        public string invoiceid { get; set; }
        public DateTime invoicedate { get; set; }
        public string userid { get; set; }
        public decimal amount { get; set; }
        public decimal discount { get; set; }
        public decimal billamount { get; set; }

        SqlConnection con;

        public invoice()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        }

        public bool insertinvoice(string emailid, decimal totalamount, decimal discount, decimal amountafterDisountFinal,decimal profit_per_bill, string medDetails)
        {

            invoiceid = DateTime.Now.Ticks.ToString();
            DateTime d = DateTime.Now;

            SqlCommand cmd = new SqlCommand("insert into mst_invoice_master values('" + invoiceid + "','" + d + "','" + emailid + "'," + totalamount + "," + discount + "," + amountafterDisountFinal + "," + profit_per_bill + ")", con);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            List<mapinvoicedetails> mp = new JavaScriptSerializer().Deserialize<List<mapinvoicedetails>>(medDetails);
            mapinvoicedetails mp1 = new mapinvoicedetails();

            foreach (mapinvoicedetails item in mp)
            {
                mp1.invoice_id = invoiceid;
                mp1.Medicine_name = item.Medicine_name;
                mp1.Quantity = item.Quantity;
                mp1.expirydate = Convert.ToDateTime(item.expirydate);
                mp1.total = Convert.ToDecimal(item.total);
                SqlCommand cmd1 = new SqlCommand("insert into map_invoice_details values('" + mp1.invoice_id + "','" + mp1.Medicine_name + "','" + mp1.Quantity + "','" + mp1.expirydate + "','" + mp1.total + "')", con);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
            }
            //List<meddetails> mdd1 = new JavaScriptSerializer().Deserialize<List<meddetails>>(medicinedetails);
            //meddetails mdd2 = new meddetails();
            //foreach (meddetails item in mdd1)
            //{
            //    SqlCommand cmd2 = new SqlCommand("update medicine_master set Quantity='" + item.Quantity + "' where medicine_id='" + item.medicine_id + "'", con);
            //    con.Open();
            //    cmd2.ExecuteNonQuery();
            //    con.Close();
            //}

            if (i > 0)
                return true;
            else
                return false;


        }

        public List<InvoiceCustomer> getInvoice()
        {
            List<InvoiceCustomer> vd1 = new List<InvoiceCustomer>();
            SqlDataReader rd;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select invoice_date,billAmount,Invoice_id from mst_invoice_master,Login_email where user_id=Login_email_id; ";

            cmd.Connection = con;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                InvoiceCustomer v1 = new InvoiceCustomer();
                v1.invoice_date = Convert.ToDateTime(rd[0]);
                v1.billamount = Convert.ToDecimal(rd[1]);
                v1.invoice_id = Convert.ToString(rd[2]);

                vd1.Add(v1);
            }

            rd.Close();
            con.Close();
            return vd1;

        }


        public List<InvoicePrint> getInvoice(string invoiceid)
        {
            List<InvoicePrint> vd1 = new List<InvoicePrint>();
            SqlDataReader rd;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Medicine_Name,Quantity,ExpiryDate,Particular_Amount,amount,discount,billAmount from mst_invoice_master,map_invoice_details where mst_invoice_master.Invoice_id='" + invoiceid + "' and map_invoice_details.Invoice_id='"+invoiceid+"' ";

            cmd.Connection = con;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                InvoicePrint v1 = new InvoicePrint();
                v1.Medicine_name = Convert.ToString(rd[0]);
                v1.Quantity = Convert.ToString(rd[1]);
                v1.expirydate = Convert.ToDateTime(rd[2]);
                v1.particularamount = Convert.ToDecimal(rd[3]);
                v1.amount = Convert.ToDecimal(rd[4]);
                v1.discount = Convert.ToDecimal(rd[5]);
                v1.billamount = Convert.ToDecimal(rd[6]);
               

                vd1.Add(v1);
            }

            rd.Close();
            con.Close();
            return vd1;

        }
    }

    public class mapinvoicedetails
    {
        public int invoicedetail_id { get; set; }
        public string invoice_id { get; set; }
        public string Medicine_name { get; set; }
        public string Quantity { get; set; }
        public DateTime expirydate { get; set; }
        public decimal total { get; set; }
    }

    public class meddetails
    {
        public string medicine_id { get; set; }
        public string Quantity { get; set; }
    }

    public class InvoiceCustomer
    {
        public DateTime invoice_date { get; set; }
        public decimal billamount{ get; set; }
        public string invoice_id { get; set; }

    }
    public class InvoicePrint
    {
        public string Medicine_name { get; set; }
        public string Quantity { get; set; }
        public DateTime expirydate { get; set; }
        public decimal billamount { get; set; } 
        public decimal amount { get; set; }
        public decimal discount { get; set; }
        public decimal particularamount { get; set; }
    }
}