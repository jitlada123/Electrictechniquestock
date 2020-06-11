using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Electrictechniquestock
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lbtnlogin_Click(object sender, EventArgs e) {

            DBConnect dbCenter = new DBConnect("Center");
            string sqlLogin = "SELECT * FROM Employee WHERE Username = '" + tbusername.Text + "' AND Password = '" + tbpassword.Text + "'";
            DataSet dslogin = dbCenter.DBSelect(sqlLogin);
            int countlogin = dslogin.Tables[0].Rows.Count;
            if (countlogin > 0)
            {
                Session["Emp_id"] = dslogin.Tables[0].Rows[0]["Emp_id"].ToString();
                //Session["branch_id"] = dslogin.Tables[0].Rows[0]["branch_id"].ToString();
                Session["Fname"] = dslogin.Tables[0].Rows[0]["Fname"].ToString();
                Session["Lname"] = dslogin.Tables[0].Rows[0]["Lname"].ToString();
                //Session["emp_position"] = dslogin.Tables[0].Rows[0]["emp_position"].ToString();
                //Session["role_Standard"] = dslogin.Tables[0].Rows[0]["role_Standard"].ToString();
                //Session["role_Register"] = dslogin.Tables[0].Rows[0]["role_Register"].ToString();
                //Session["role_Machine"] = dslogin.Tables[0].Rows[0]["role_Machine"].ToString();
                //Session["role_Model"] = dslogin.Tables[0].Rows[0]["role_Model"].ToString();
                //Session["role_Codestop"] = dslogin.Tables[0].Rows[0]["role_Codestop"].ToString();
                //Session["role_Plan_examiner"] = dslogin.Tables[0].Rows[0]["role_Plan_examiner"].ToString();
                //Session["role_Production_examiner_before"] = dslogin.Tables[0].Rows[0]["role_Production_examiner_before"].ToString();
                //Session["role_Production_examiner_after"] = dslogin.Tables[0].Rows[0]["role_Production_examiner_after"].ToString();
                //Session["role_DataEntry"] = dslogin.Tables[0].Rows[0]["role_DataEntry"].ToString();
                //Session["role_EditOrder"] = dslogin.Tables[0].Rows[0]["role_EditOrder"].ToString();
                //Session["role_CancelOrder"] = dslogin.Tables[0].Rows[0]["role_CancelOrder"].ToString();
                //Session["role_Sequence"] = dslogin.Tables[0].Rows[0]["role_Sequence"].ToString();
                //Session["role_Center"] = dslogin.Tables[0].Rows[0]["role_Center"].ToString();
                //Session["role_Department"] = dslogin.Tables[0].Rows[0]["role_Department"].ToString();
              //  bool ckhistory = WovenHistory.SaveHistory("Center", "Login", "ลงชื่อเข้าใช้", Session["emp_id"].ToString());
                Response.RedirectPermanent("Home.aspx");
            }
            else
            {
                lblError.Text = "*Uername หรือ Password ไม่ถูกต้อง";
            }
        }
    }
}