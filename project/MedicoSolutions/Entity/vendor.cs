using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Threading;

namespace MedicoSolutions.Entity
{
    public class vendor
    {

        SqlConnection con;

        public vendor()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        }

        #region insertvendor
        public bool insertvendor(string name, string phno, string company, string email, DateTime date, string status, string Address)
        {
            int stat = Convert.ToInt32(status);
            string vendorid = DateTime.Now.Ticks.ToString();
            SqlCommand cmd = new SqlCommand("insert into mst_vendor values('" + vendorid + "','" + name + "','" + phno + "','" + Address + "','" + email + "','" + date + "'," + stat + ")", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();

            List<map_vendor_company> list = new JavaScriptSerializer().Deserialize<List<map_vendor_company>>(company);

            map_vendor_company mvc = new map_vendor_company();
            foreach (map_vendor_company item in list)
            {
                Thread.Sleep(20);
                string id = DateTime.Now.Ticks.ToString();
                mvc.company_id = item.company_id;
                SqlCommand cmd1 = new SqlCommand(" insert into map_vendor_company values('" + id + "','" + vendorid + "','" + mvc.company_id + "')", con);
                cmd1.ExecuteNonQuery();
            }

            con.Close();

            if (i > 0)
                return true;

            else
                return false;
        }
        #endregion

        #region getvendor
        public List<Vendor1> getvendor()
        {
            List<Vendor1> vd = new List<Vendor1>();
            SqlDataReader rd;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from mst_vendor";

            cmd.Connection = con;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Vendor1 v1 = new Vendor1();
                v1.vendor_id = Convert.ToString(rd[0]);
                v1.name = Convert.ToString(rd[1]);
                v1.phno = Convert.ToString(rd[2]);
                v1.IsActive = Convert.ToString(rd[6]);
                vd.Add(v1);
            }
            rd.Close();
            con.Close();
            return vd;

        }
        #endregion

        #region deletevendor
        public bool delvendor(string vendorid)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from mst_vendor where vendor_id='" + vendorid + "'", con);
            int i = cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("Delete from map_vendor_company where vendor_id='" + vendorid + "'", con);
            int j = cmd1.ExecuteNonQuery();
            con.Close();
            bool b;
            if (i > 0 && j > 0)
                b = true;
            else
                b = false;
            return b;

        }
        #endregion

        #region showvendordetails
        public List<Vendor1> showvendordetails(string vendorid)
        {
            List<Vendor1> v1 = new List<Vendor1>();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from mst_vendor where vendor_id='" + vendorid + "'", con);
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Vendor1 v2 = new Vendor1();
                v2.vendor_id = sdr[0].ToString();
                v2.name = sdr[1].ToString();
                v2.phno = sdr[2].ToString();
                v2.IsActive = sdr[6].ToString();
                v2.address = sdr[3].ToString();
                v2.email = sdr[4].ToString();
                v2.date = Convert.ToDateTime(sdr[5]);
                v1.Add(v2);

            }

            return v1;

        }
        #endregion


        #region vendor company
        public List<map_vendor_company> showvendorcompanies(string vendorid)
        {
            List<map_vendor_company> v1 = new List<map_vendor_company>();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from map_vendor_company where vendor_id='" + vendorid + "'", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                map_vendor_company m = new map_vendor_company();
                m.company_id = sdr[2].ToString(); ;
                v1.Add(m);

            }

            return v1;
        }
        #endregion

        public List<Vendor1> GetVendorNameForMedicine(string vid)
        {
            List<Vendor1> v1 = new List<Vendor1>();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from mst_vendor where vendor_id='" + vid + "'", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Vendor1 m = new Vendor1();
                m.name = sdr[2].ToString(); ;
                v1.Add(m);
            }
            return v1;
        }

        #region updatevendor
        public bool UpdateVendordata(string name, string phno, string company, string email, DateTime date, string status, string Address, string vendorid)
        {
            SqlCommand cmd = new SqlCommand("update mst_vendor set name='" + name + "',phno='" + phno + "',email='" + email + "',IsActive='" + status + "',address='" + Address + "' where vendor_id='" + vendorid + "' ", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand("Delete from map_vendor_company where vendor_id='" + vendorid + "'", con);
            int j = cmd1.ExecuteNonQuery();

            List<map_vendor_company> list = new JavaScriptSerializer().Deserialize<List<map_vendor_company>>(company);

            map_vendor_company mvc = new map_vendor_company();
            foreach (map_vendor_company item in list)
            {
                string id = DateTime.Now.Ticks.ToString();
                mvc.company_id = item.company_id;
                SqlCommand cmd2 = new SqlCommand(" insert into map_vendor_company values('" + id + "','" + vendorid + "','" + mvc.company_id + "')", con);
                cmd2.ExecuteNonQuery();
            }

            con.Close();

            if (i > 0)
                return true;

            else
                return false;
        }

        #endregion

        #region close
        public void close()
        {
            con.Close();
        }

        #endregion
    }
    public class Vendor1
    {
        public string vendor_id { get; set; }
        public string name { get; set; }
        public string phno { get; set; }
        public string IsActive { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public DateTime date { get; set; }
    }

    public class map_vendor_company
    {
        public string company_id { get; set; }
    }
}