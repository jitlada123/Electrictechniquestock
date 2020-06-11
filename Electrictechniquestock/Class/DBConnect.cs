using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;



namespace Electrictechniquestock
{
    public class DBConnect
    {
        protected SqlConnection con;
        private string branchSwitch;

        public DBConnect(string bbranch)
        {
            if (bbranch == "KKF")
            {
                branchSwitch = "ConnectionKKF";
            }
            else if (bbranch == "BWC")
            {
                branchSwitch = "ConnectionBWC";
            }
            else if (bbranch == "KC")
            {
                branchSwitch = "ConnectionKC";
            }
            else if (bbranch == "NR")
            {
                branchSwitch = "ConnectionNR";
            }
            else if (bbranch == "CY")
            {
                branchSwitch = "ConnectionCY";
            }
            else if (bbranch == "BS")
            {
                branchSwitch = "ConnectionBS";
            }
            else if (bbranch == "Center")
            {
                branchSwitch = "ConnectionCenter";
            }
            else
            {
                branchSwitch = "ConnectionCenter";
            }
        }

        public DataSet DBSelect(String sql)
        {
            string Connection = branchSwitch;
            con = new SqlConnection(@WebConfigurationManager.ConnectionStrings[Connection].ToString());
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
           
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "select");
                con.Close();                      
            return ds;
        }

        public bool DBQuery(String sql)
        {
            string Connection = branchSwitch;
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings[Connection].ToString());
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "tbIS");
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {                          
                return false;
            }
        }
    }
}