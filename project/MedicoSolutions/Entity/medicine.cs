using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace MedicoSolutions.Entity
{
    public class medicine
    {
        SqlConnection con;

        public medicine()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        }

        #region insertmedicine
        public bool insertmed(string name, string vendor, int MedicineType, decimal mrp, decimal cp, string qty, DateTime ExpDate)
        {
            string medicine_id = DateTime.Now.Ticks.ToString();
            SqlCommand cmd = new SqlCommand("insert into medicine_master  values('" + medicine_id + "','" + name + "','" + mrp + "'," + vendor + "," + MedicineType + "," + cp + ",'" + ExpDate + "', '" + qty + "')", con);

            con.Open();

            int i = cmd.ExecuteNonQuery();

            if (i > 0)
                return true;

            else
                return false;
        }
        #endregion

        #region update_quantity
        public bool updatequantity(string batch_no,string quantity)
        {
            SqlCommand cmd = new SqlCommand("update medicine_master set Quantity='" + quantity + "' where Batch_no='" + batch_no+ "'", con);

            con.Open();
            int i = cmd.ExecuteNonQuery();

            if (i > 0)
                return true;
            else
                return false;
        }
        #endregion


        public List<MedicineDetails> batchno(string medicine_name)
        {
            List<MedicineDetails> vd = new List<MedicineDetails>();
            SqlDataReader rd;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Batch_no from medicine_master where medicine_name='"+medicine_name+"'";

            cmd.Connection = con;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                MedicineDetails v1 = new MedicineDetails();
                v1.Batch_no = Convert.ToString(rd[0]);
                //v1.medicine_name = Convert.ToString(rd[0]);
                //v1.medicine_id = Convert.ToString(rd[7]);
                //v1.SuppliedBy = Convert.ToString(rd[1]);

                //v1.MedicineType = Convert.ToString(rd[16]);
                vd.Add(v1);
            }
            rd.Close();
            con.Close();
            return vd;

        }


        public List<MedicineDetails> getMedicine1()
        {
            List<MedicineDetails> vd = new List<MedicineDetails>();
            SqlDataReader rd;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from mst_vendor,medicine_master,dbo.mst_medicine_typeMaster where mst_vendor.vendor_id=medicine_master.SuppliedBy and medicine_master.MedicineType=mst_medicine_typeMaster.medicine_type_id";

            cmd.Connection = con;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                MedicineDetails v1 = new MedicineDetails();
                v1.medicine_name = Convert.ToString(rd[8]);
                v1.medicine_id = Convert.ToString(rd[7]);
                v1.SuppliedBy = Convert.ToString(rd[1]);

                v1.MedicineType = Convert.ToString(rd[17]);
                vd.Add(v1);
            }
            rd.Close();
            con.Close();
            return vd;

        }
        

        #region getmedicine
        public List<MedicineDetails> getMedicine()
        {
            List<MedicineDetails> vd = new List<MedicineDetails>();
            SqlDataReader rd;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select distinct medicine_name from medicine_master where Batch_no>' "+1000 +"'";

            cmd.Connection = con;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                MedicineDetails v1 = new MedicineDetails();
                v1.medicine_name = Convert.ToString(rd[0]);
                //v1.medicine_id = Convert.ToString(rd[7]);
                //v1.SuppliedBy = Convert.ToString(rd[1]);
                
                //v1.MedicineType = Convert.ToString(rd[16]);
                vd.Add(v1);
            }
            rd.Close();
            con.Close();
            return vd;

        }
        #endregion



        #region getmedtype
        public List<medicinetypemaster> getmedtype()
        {
             List<medicinetypemaster> md =new List<medicinetypemaster>();
            SqlDataReader rd;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from mst_medicine_typeMaster";
           
            cmd.Connection = con;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                medicinetypemaster m1 = new medicinetypemaster();
                
                m1.id=rd[0].ToString();
                m1.type=rd[1].ToString();
                md.Add(m1);
            }
            rd.Close();
            con.Close();
            return md;
        }
        #endregion

        #region getmed details
        public List<MedicineDetails> getmedicinedetails(string medid)
        {
            List<MedicineDetails> v1 = new List<MedicineDetails>();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from medicine_master where Batch_no ='" + medid + "'", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                MedicineDetails m = new MedicineDetails();
                m.medicine_name = Convert.ToString(sdr[1]);
                m.mrp = Convert.ToDecimal(sdr[2]);
                m.SuppliedBy = Convert.ToString(sdr[3]);
                m.MedicineType = Convert.ToString(sdr[4]);
                m.costprice = Convert.ToDecimal(sdr[5]);
                m.Quantity = Convert.ToString(sdr[6]);
                m.Batch_no = Convert.ToString(sdr[7]);
                m.ExpiryDate = Convert.ToDateTime(sdr[8]);
             
                v1.Add(m);
            }
            return v1;
        }

        public bool UpdateMedicinedata(string name, string vendor, int MedicineType, decimal mrp, decimal cp, string mid, string qty)
        {
            SqlCommand cmd = new SqlCommand("update medicine_master set medicine_name='" + name + "',mrp='" + mrp + "',SuppliedBy='" + vendor + "',MedicineType='" + MedicineType + "',costprice='" + cp + "', Quantity='"+qty+"' where medicine_id='" + mid + "' ", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();

            if (i > 0)
                return true;
            else 
                return false;
        }
        #endregion


        #region deletemed
        public bool DeleteMedicine(string medicineid)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from medicine_master where medicine_id='"+medicineid+"' ", con);
            int i = cmd.ExecuteNonQuery();
          
            con.Close();
            bool b;
            if (i > 0 )
                b = true;
            else
                b = false;
            return b;
        }
#endregion

        public decimal getmrp(string medid)
        {
            decimal mrp=0;
            SqlCommand cmd = new SqlCommand("select mrp,ExpiryDate,costprice from medicine_master where medicine_id='" + medid + "'", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                MedicineDetails md = new MedicineDetails();
                md.mrp = Convert.ToDecimal(sdr[0]);
                md.ExpiryDate = Convert.ToDateTime(sdr[1]);
                md.costprice = Convert.ToDecimal(sdr[2]);

                mrp =Convert.ToDecimal( md.mrp);
            }
            sdr.Close();
            con.Close();
            return mrp;
           
        }

        #region close
        public void close()
        {
            con.Close();
        }
        
        #endregion
    }

    public class medicinetypemaster
    {
        public string id{get;set;}
        public string type{get;set;}
    }

    public class MedicineDetails
    {
        public string medicine_id { get; set; }
        public string medicine_name { get; set; }
        public decimal mrp { get; set; }
        public string SuppliedBy { get; set; }
        public string  MedicineType { get; set; }
        public decimal costprice { get; set; }
        public string Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Batch_no { get; set; }
    }
}
