using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace MedicoSolutions.Entity
{
    public class user
    {
        
        public string email { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public string password { get; set; }
        public int status { get; set; }
        public string phno { get; set; }

        public static string GenerateRandomPassword()
        {
            Math.Abs(DateTime.Now.Ticks);
            string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < 6; ++index)
                stringBuilder.Append(str.Substring(random.Next(str.Length), 1));
            return ((object)stringBuilder).ToString();
        }

        SqlConnection con;




        internal void Del_Email_row()
        {
            SqlCommand cmd = new SqlCommand("Delete from Login_email ", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

        }

        #region GetUserDetails
        public List<user> GetUserDetails()
        {
            List<user> vd = new List<user>();
            SqlDataReader rd;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from dbo.mst_user";

            cmd.Connection = con;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                user v1 = new user();
                v1.email = Convert.ToString(rd[0]);
                v1.name  = Convert.ToString(rd[1]);
                v1.date = Convert.ToDateTime(rd[2]);
                v1.password = Convert.ToString(rd[3]);
                v1.status = Convert.ToInt32(rd[4]);
                v1.phno = Convert.ToString(rd[5]);
                vd.Add(v1);
            }
            rd.Close();
            con.Close();
            return vd;

        }
        #endregion

        public user()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        }


        public bool login_email( string email)
        {
            DateTime date = DateTime.Now;
            status = 1;

            SqlCommand cmd = new SqlCommand("insert into Login_email values('" + email + "','" + date + "')", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
                return true;
            else
                return false;

        }


        public bool insertuser(string name, string email, string phoneno)
        {
            string password = GenerateRandomPassword();
            DateTime date =DateTime.Now;
            status = 1;

            SqlCommand cmd = new SqlCommand("insert into mst_user values('" + email + "','" + name + "','" + date + "','" + password + "','" + status + "','" + phoneno + "')", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
                return true;
            else
                return false;

        }

        public List<user> getdetails(string emailid)
        {
            List<user> l1 = new List<user>();

            SqlCommand cmd = new SqlCommand("select * from mst_user where Email_id='" + emailid + "'", con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
               user v1 = new user();
                v1.email = Convert.ToString(rd[0]);
                v1.name  = Convert.ToString(rd[1]);
                v1.date = Convert.ToDateTime(rd[2]);
                v1.password = Convert.ToString(rd[3]);
                v1.status = Convert.ToInt32(rd[4]);
                v1.phno = Convert.ToString(rd[5]);
                l1.Add(v1);
                
            }
            con.Close();
            return l1;
        }

        internal List<user> GetCustomers()
        {
            List<user> vd = new List<user>();
            SqlDataReader rd;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from mst_user where IsActive=1";

            cmd.Connection = con;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                user u1 = new user();
                u1.email = Convert.ToString(rd[0]);
                u1.name = Convert.ToString(rd[1]);
                u1.password = Convert.ToString(rd[3]);
                u1.phno = Convert.ToString(rd[5]);


                vd.Add(u1);
            }
            rd.Close();
            con.Close();
            return vd;
        }
        internal int userAuthenticAte(string email, string password)
        {

            //  SqlCommand cmd = new SqlCommand("select * from mst_user where Email_id='" + email + "'and Password='" + password + "'", con);
            con.Open();
            SqlDataAdapter rd = new SqlDataAdapter("select * from mst_user where Email_id='" + email + "'and Password='" + password + "'", con);
            DataSet dt = new DataSet();
            rd.Fill(dt);
            if (dt.Tables[0].Rows.Count == 1)
            {

                HttpContext.Current.Session["UserSession"] = dt;
                return 1;

            }

            else
                return -1;

        }
    }

   
}