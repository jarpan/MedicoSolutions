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
    public class feedback1
    {

        SqlConnection con;

        public feedback1()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        }

        #region insertfeedback1
        public bool insertfeedback1(string message, string email, string question1, string question2, string question3)
        {

            SqlCommand cmd = new SqlCommand("insert into feedback1 values('" + message + "','" + email + "','" + question1 + "','" + question2 + "','" + question3 + "')", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();




            con.Close();

            if (i > 0)
                return true;

            else
                return false;
        }
        #endregion

    }
}