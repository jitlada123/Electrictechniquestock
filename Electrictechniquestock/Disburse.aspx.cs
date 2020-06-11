using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Threading;

namespace Electrictechniquestock
{
    public partial class Disburse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Emp_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            //string branch_id = Session["branch_id"].ToString();

            if (!Page.IsPostBack)
            {
                 Stock_group();
                //ddlBranch.SelectedValue = branch_id;
                //  DDLShowmachine();
                //  DDLShowepeanumber();
                //  ShowmodelnumberAll();
            }
          
            // bool role_Model = new bool();
            // bool.TryParse(Session["role_Model"].ToString(), out role_Model);

            // string mcepeanumber_id = Request.QueryString["mcepea_id"];
            // if (mcepeanumber_id != "Null")
            // {
            ////     showmcepeanumber(mcepeanumber_id, role_Model);
            // }

            // bool role_Machine = new bool();
            // bool.TryParse(Session["role_Machine"].ToString(), out role_Machine);
            //// lbtnOpenAdd.Visible = role_Machine;
            // Machine(ddlBranch.SelectedValue, role_Machine);

            // if (Session["role_Center"].ToString() == "True")
            // {
            //     ddlBranch.Enabled = true;
            // }
            // else
            // {
            //     ddlBranch.Enabled = false;
            // }
        }

        private void Stock_group()
        {
            DBConnect dbBranch = new DBConnect("Center");
            string sqlStock_group = "SELECT stg_id,group_name  FROM Stock_group";
            DataSet dsStock_group = dbBranch.DBSelect(sqlStock_group);
            int countStock_group = dsStock_group.Tables[0].Rows.Count;
            ddlstockgroup.Items.Clear();
            if (countStock_group > 0)
            {
                for (int i = 0; i < countStock_group; i++)
                {
                        if (i == 0)
                        {
                           ddlstockgroup.Items.Add(new ListItem("---- เลือก ----", ""));
                        }
                    string stg_id = dsStock_group.Tables[0].Rows[i]["stg_id"].ToString();
                    string group_name = dsStock_group.Tables[0].Rows[i]["group_name"].ToString();
                    ddlstockgroup.Items.Add(new ListItem(group_name, group_name));
                }           
            }
        }

        protected void Addnamestockgroup(object sender, EventArgs e)
        {
            DBConnect dbBranch = new DBConnect("Center");
            //string mcnum = tbaddnum.Text;
            //string mcname = tbaddmachine.Text;
            //string mcmodalname = tbaddmodelmc.Text;
            //string epeaid = ddladdepeamodel.SelectedValue;
            //string mcbobbin = tbaddbobbin.Text;
            //string mcfronbacklength = tbaddfronbacklength.Text;

            // mcname = mcname.ToUpper();
            if (txt_Groupname.Text != "" )
            {
                string sqlInsert = "INSERT Stock_group(group_name) VALUES('" + txt_Groupname.Text +  "')";
                bool checkInsert = dbBranch.DBQuery(sqlInsert);
                if (checkInsert == true)
                {
                    //bool ckhistory = WovenHistory.SaveHistory(ddlBranch.SelectedValue, "ข้อมูลเครื่องทอ", "เพิ่มเครื่องทอ " + mcname, Session["emp_id"].ToString());
                    //if (ckhistory == false)
                    //{
                    //    ShowMessage("ไม่สามารถบันทึกประวัติการทำกิจกรรมได้ กรุณาติดต่อฝ่ายผลิตชิ้นส่วนและอุปกรณ์", MessageType.Warning);
                    //}
                    ShowMessage("บันทึกข้อมูลสำเร็จ", MessageType.Success);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS", "setTimeout(function() { window.location.replace('Add.aspx') }, 3000);", true);
                }
                else
                {
                    ShowMessage("ไม่สามารถบันทึกข้อมูลได้ กรุณาลองใหม่อีกครั้งหรือติดต่อฝ่ายผลิตชิ้นส่วนและอุปกรณ์", MessageType.Error);
                }
            }
            else
            {
                ShowMessage("กรุณากรอกข้อมูลให้ครบ", MessageType.Warning);
            }
        }
        protected void lbtnsearch_Itemname(object sender, EventArgs e)
        {
            // Page.ClientScript.RegisterStartupScript(GetType(), "Pop", "modelAddnamestockgroup();", true);

            //string script = "alert(\"wwwwwwwwwwwwwwwww\");";
            //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            DBConnect dbBranch = new DBConnect("Center");
            string sqlstock;
            if (TxItemcode.Text != "" && TxItemname.Text == "")
            {
                sqlstock = "SELECT st.group_name,st.st_id,st.Itemcode,st.Itemname,st.Itemtotal_amount," +
                                 "st.unit,st.storage_number,st.remark FROM [DBRDEngineering].[dbo].[Stock] as st " +
                                 "where st.Itemcode  ='" + TxItemcode.Text + "'";
            }
            else if (TxItemname.Text != "" && TxItemcode.Text == "")
            {
                sqlstock = "SELECT st.group_name,st.st_id,st.Itemcode,st.Itemname,st.Itemtotal_amount," +
                         "st.unit,st.storage_number,st.remark FROM [DBRDEngineering].[dbo].[Stock] as st " +
                          "where st.Itemname = '" + TxItemname.Text + "' ";
            }
            else {
                sqlstock = "SELECT st.group_name,st.st_id,st.Itemcode,st.Itemname,st.Itemtotal_amount," +
                           "st.unit,st.storage_number,st.remark FROM [DBRDEngineering].[dbo].[Stock] as st " +
                           "where st.Itemcode  ='" + TxItemcode.Text + "' and st.Itemname = '" + TxItemname.Text + "' ";

            }
            DataSet dsstock = dbBranch.DBSelect(sqlstock);
            int countstock = dsstock.Tables[0].Rows.Count;
            if (countstock > 0)
            {
                TXsearch.Text = "กำลังจ่ายรายการอุปกรณ์";
                for (int i = 0; i < countstock; i++)
                {

                    string st_id = dsstock.Tables[0].Rows[i]["st_id"].ToString();
                    string group_name = dsstock.Tables[0].Rows[i]["group_name"].ToString();
                    string Itemcode = dsstock.Tables[0].Rows[i]["Itemcode"].ToString();
                    string Itemname = dsstock.Tables[0].Rows[i]["Itemname"].ToString();

                    string Itemtotal_amount = dsstock.Tables[0].Rows[i]["Itemtotal_amount"].ToString();
                    string unit = dsstock.Tables[0].Rows[i]["unit"].ToString();

                    string storage_number = dsstock.Tables[0].Rows[i]["storage_number"].ToString();
                    string remark = dsstock.Tables[0].Rows[i]["remark"].ToString();

                    tbst_id.Text = st_id;
                    ddlstockgroup.SelectedValue = group_name;
                    TxItemname.Text = Itemname;
                    ddlunit.SelectedValue = unit;
                    Txstorage_number.Text = storage_number;
                    Txremark.Text = remark;
                    TxItemtotal_amount.Text = Itemtotal_amount;

                }
            }
            else {

                TXsearch.Text = "ไม่พบอุปกรณ์ ทำการสร้างรายการอุปกรณ์ใหม่";

                // TxItemcode.Text = string.Empty;
                // TxItemname.Text = string.Empty;
                Txamount_disburse.Text = string.Empty;
                Txstorage_number.Text = string.Empty;
                TxItemtotal_amount.Text = string.Empty;
                Txremark.Text = string.Empty;
                ddlstockgroup.SelectedValue = string.Empty;
                ddlunit.SelectedValue = string.Empty;
            }

          }
        protected void lbtnOpenAddnamestockgroup(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "Pop", "modelAddnamestockgroup();", true);
        }

        protected void lbtncancelstock(object sender, EventArgs e)
        {
            TxItemcode.Text = string.Empty;
            TxItemname.Text = string.Empty;
            Txamount_disburse.Text = string.Empty;
            Txstorage_number.Text = string.Empty;
            Txremark.Text = string.Empty;
          
        }

        protected void lbtAddstock_Click(object sender, EventArgs e)
        {
            DBConnect dbBranch = new DBConnect("Center");
            string Itemcode = TxItemcode.Text;
            string stockgroup = ddlstockgroup.SelectedValue;
            string Itemname = TxItemname.Text;
            string amount = Txamount_disburse.Text;
            string unit = ddlunit.SelectedValue ;
            string storage_number = Txstorage_number.Text;
            string remark = Txremark.Text;

 
            string sqlstock = "SELECT st.group_name,st.st_id,st.Itemcode,st.Itemname,st.Itemtotal_amount," +
                              "st.unit,st.storage_number,st.remark FROM [DBRDEngineering].[dbo].[Stock] as st " +
                              "where st.st_id  ='" + tbst_id.Text + "'";
            DataSet dsstock = dbBranch.DBSelect(sqlstock);
            int countstock = dsstock.Tables[0].Rows.Count;
            if (countstock > 0)
            {
                for (int i = 0; i < countstock; i++)
                {

                    string st_id = dsstock.Tables[0].Rows[i]["st_id"].ToString();
                    string Itemtotal_amount = dsstock.Tables[0].Rows[i]["Itemtotal_amount"].ToString();

                    // mcname = mcname.ToUpper();
                    if ( Txamount_disburse.Text != "" && TxItemname.Text != "" && Convert.ToInt32(amount) < Convert.ToInt32(Itemtotal_amount))
                    {
                        int add_amount = Convert.ToInt32(Itemtotal_amount) - Convert.ToInt32(amount);
                        string stock_add = "'" + st_id + "','จ่าย','" + amount + "','"+ add_amount + "','" + Session["Emp_id"].ToString() + "',Getdate()";

                        string sqlInsert = "INSERT History_stock(st_id,his_nametype,amount,his_totalamount,emp_id,inpdate) VALUES(" + stock_add + ")";
                        bool checkInsert = dbBranch.DBQuery(sqlInsert);

                       
                        if (checkInsert == true)
                        {

                            string sqlupdate = "UPDATE Stock set Itemtotal_amount = '"+ add_amount + "' where  st_id = '" + st_id + "'";
                            bool checkupdate = dbBranch.DBQuery(sqlupdate);

                            //bool ckhistory = WovenHistory.SaveHistory(ddlBranch.SelectedValue, "ข้อมูลเครื่องทอ", "เพิ่มเครื่องทอ " + mcname, Session["emp_id"].ToString());
                            //if (ckhistory == false)
                            //{
                            //    ShowMessage("ไม่สามารถบันทึกประวัติการทำกิจกรรมได้ กรุณาติดต่อฝ่ายผลิตชิ้นส่วนและอุปกรณ์", MessageType.Warning);
                            //}
                            ShowMessage("บันทึกข้อมูลสำเร็จ", MessageType.Success);

                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS", "setTimeout(function() { window.location.replace('Add.aspx') }, 3000);", true);
                        }
                        else
                        {
                            ShowMessage("ไม่สามารถบันทึกข้อมูลได้ กรุณาลองใหม่อีกครั้งหรือติดต่อฝ่ายผลิตชิ้นส่วนและอุปกรณ์", MessageType.Error);
                        }
                    }
                    else
                    {
                        ShowMessage("กรุณากรอกข้อมูลให้ครบ", MessageType.Warning);
                    }

                }
                //    History_stock
            }
            else
            {
                // mcname = mcname.ToUpper();
                if (Itemname != "" && stockgroup != "" && amount != "" )
                {

                    string stock = "'" + stockgroup + "','" + Itemcode + "','" + Itemname + "','" + amount + "','" + unit + "','" + storage_number + "','" + remark + "'";
                    //string script = "alert(\"" + stock + "\");";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    string sqlInsert = "INSERT Stock(group_name,Itemcode,Itemname,Itemtotal_amount,unit,storage_number,remark) VALUES(" + stock + ")";
                    bool checkInsert = dbBranch.DBQuery(sqlInsert);
                    if (checkInsert == true)
                    {
                        //bool ckhistory = WovenHistory.SaveHistory(ddlBranch.SelectedValue, "ข้อมูลเครื่องทอ", "เพิ่มเครื่องทอ " + mcname, Session["emp_id"].ToString());
                        //if (ckhistory == false)
                        //{
                        //    ShowMessage("ไม่สามารถบันทึกประวัติการทำกิจกรรมได้ กรุณาติดต่อฝ่ายผลิตชิ้นส่วนและอุปกรณ์", MessageType.Warning);
                        //}
                        ShowMessage("บันทึกข้อมูลสำเร็จ", MessageType.Success);

                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS", "setTimeout(function() { window.location.replace('Add.aspx') }, 3000);", true);
                    }
                    else
                    {
                        ShowMessage("ไม่สามารถบันทึกข้อมูลได้ กรุณาลองใหม่อีกครั้งหรือติดต่อฝ่ายผลิตชิ้นส่วนและอุปกรณ์", MessageType.Error);
                    }
                }
                else
                {
                    ShowMessage("กรุณากรอกข้อมูลให้ครบ", MessageType.Warning);
                }
            }

        }

        public enum MessageType { Success, Error, Info, Warning };
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

    }
}