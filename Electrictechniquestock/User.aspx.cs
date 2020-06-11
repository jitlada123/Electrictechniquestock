using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace Electrictechniquestock
{
    public partial class User : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect("Center");

            if (!Page.IsPostBack)
            {
                if (Session["Emp_id"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                if (!Page.IsPostBack)
                {
                    Rrole();

                }
                
            }

        }

        private void Rrole()
        {
            DBConnect db = new DBConnect("Center");
            DataSet dsRrole = new DataSet();
            string sqlRrole = "SELECT role_name ,role_id  FROM Rrole";
            dsRrole = db.DBSelect(sqlRrole);
            int countRole = dsRrole.Tables[0].Rows.Count;
            ddlRole.Items.Clear();
            if (countRole > 0)
            {
                for (int i = 0; i < countRole; i++)
                {
                    if (i == 0)
                    {
                        ddlRole.Items.Add(new ListItem("---- เลือก ----", ""));
                    }
                    // string role_id = dsRrole.Tables[0].Rows[i]["role_id"].ToString();
                    string role_name = dsRrole.Tables[0].Rows[i]["role_name"].ToString();
                    string role_id = dsRrole.Tables[0].Rows[i]["role_id"].ToString();
                    ddlRole.Items.Add(new ListItem(role_name, role_id));
                }
            }

        }



        protected void btAdduser_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect("Center");
            string[] str = new string[8];
            str[0] = TxtEmp_id.Text;
            str[1] = txtFname.Text;
            str[2] = txtLname.Text;
            str[3] = txtPosition.Text;
            str[4] = ddlRole.SelectedItem.Value;
            str[5] = txtUsername.Text;
            str[6] = txtPassword.Text;
            bool checknull = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == "")
                {
                    checknull = true;
                }
            }
            if (checknull == true)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "alertWornNull();", true);
            }
            else
            {
                
                    DataSet dsEmp = new DataSet();
                    string sqlEmp = "SELECT * FROM Employee";
                    dsEmp = db.DBSelect(sqlEmp);
                    int countEmp = dsEmp.Tables[0].Rows.Count;
                    bool checkDup = false;
                    for (int j = 0; j < countEmp; j++)
                    {
                        if (dsEmp.Tables[0].Rows[j]["Emp_id"].ToString() == str[0])
                        {
                            checkDup = true;
                        }
                    }
                    if (checkDup == true)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "alertWornDup();", true);

                    }
                    else
                    {
                        String sqlEmpIS = "INSERT INTO Employee([Emp_id],[Fname],[Lname],"
                                        + "[Position],[role_id],[Username],[Password]) "
                                        + "VALUES('" + str[0] + "','" + str[1] + "','"
                                        + str[2] + "','" + str[3] + "','" + str[4] + "','" + str[5]
                                        + "','" + str[6] + "');";
                        bool checkEmpIS = db.DBQuery(sqlEmpIS);
                        if (checkEmpIS == true)
                        {
                            TxtEmp_id.Text = "";
                            txtFname.Text = "";
                            txtLname.Text = "";
                            txtPosition.Text = "";
                            txtUsername.Text = "";
                            txtPassword.Text = "";

                        }
                    }
                }
            }

        }
    }

        
        
    




