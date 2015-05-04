using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ASPSnippets.SmsAPI;

namespace MedicoSolutions.Entity
{
    public class sms
    {
        SqlConnection con;

        public sms()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        }
        public bool message(string phnno,string msg)
        {
            //List<smsdetails> vd1 = new List<smsdetails>();
            SqlDataReader rd;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Email_id,Password from mst_user where Phone_no='"+phnno+"'";

            cmd.Connection = con;
            rd = cmd.ExecuteReader();
            smsdetails v1 = new smsdetails();

            while (rd.Read())
            {
                v1.Email_id = Convert.ToString(rd[0]);
                v1.password = Convert.ToString(rd[1]);
               
            }
            msg = "User Id :-" + v1.Email_id + " "+"Password :-"  +v1.password;
            rd.Close();
            con.Close();
       

            SMS.APIType = SMSGateway.Site2SMS;
            SMS.MashapeKey = "kB4ZwUJ5dLmshMMRo0yuI6XVEYH8p1MyFW9jsnB3yJwQTpBKiU";
            SMS.Username = "9999926075";
            SMS.Password = "1032766";
            if (phnno.IndexOf(",") == -1)
            {
                //Single SMS
                SMS.SendSms(phnno, msg);
                return true;
            }
            else
            {
                //Multiple SMS
                List<string> numbers = phnno.Split(',').ToList();
                SMS.SendSms(numbers, msg);
                return false;
            }
        }
    }
    public class smsdetails
    {
        public string Email_id { get; set; }
        public string password { get; set; }
  
    }
}