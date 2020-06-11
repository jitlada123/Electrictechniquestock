using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Electrictechniquestock
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Profile();
        }

        private void Profile()
        {
          //  lbtnregister.Visible = false;
            //lbtnproduction.Visible = false;
            //lbtnplan.Visible = false;
            DBConnect dbCenter = new DBConnect("Center");
            string emp_id = Session["Emp_id"].ToString();
            string sqlemp = "SELECT * FROM Employee WHERE Emp_id = '" + emp_id + "'";
            DataSet dsemp = dbCenter.DBSelect(sqlemp);
            int countemp = dsemp.Tables[0].Rows.Count;
            if (countemp > 0)
            {
                string emp_fname = dsemp.Tables[0].Rows[0]["Fname"].ToString();
                string emp_lname = dsemp.Tables[0].Rows[0]["Lname"].ToString();
                //bool role_Register = new bool();
                //bool.TryParse(dsemp.Tables[0].Rows[0]["role_Register"].ToString(), out role_Register);
             //   lbtnregister.Visible = role_Register;
                //string branch_id = dsemp.Tables[0].Rows[0]["branch_id"].ToString();
                lbluser_id.Text = emp_id;
                lbluser_name.Text = "คุณ" + emp_fname + " " + emp_lname;
                //lblbranch.Text = "สาขา " + branch_id;
                lblname.Text = "คุณ" + emp_fname + " " + emp_lname;
            }
            else
            {
                Session.Clear();
                Session.Abandon();
                Response.RedirectPermanent("Login.aspx");
            }
        }

        protected void lbtnsign_out_Click(object sender, EventArgs e)
        {
          //  bool ckhistory = WovenHistory.SaveHistory("Center", "Logout", "ออกจากระบบ", Session["emp_id"].ToString());
            Session.Clear();
            Session.Abandon();
            Response.RedirectPermanent("Login.aspx");
        }
    }
}