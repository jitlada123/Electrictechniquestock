using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Threading;
using System.Globalization;

namespace Electrictechniquestock
{
    public partial class PLCGroup : System.Web.UI.Page
    {
        List<CheckBox> lstChckBox = new List<CheckBox>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Emp_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            //string branch_id = Session["branch_id"].ToString();

            if (!Page.IsPostBack)
            {
               
              //  Branch();
              //  ddlBranch.SelectedValue = branch_id;
              //  DDLShowmachine();
              //  DDLShowepeanumber();
              //  ShowmodelnumberAll();
            }
            //();
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
        private void showPLCgrouptor()
        {
            int num = 0  ;
            DBConnect dbBranch = new DBConnect("Center");
            string sqlstock = "SELECT st.group_name,st.st_id,st.Itemcode,st.Itemname,st.Itemtotal_amount" +
                              ",st.unit,st.storage_number,st.remark FROM [DBRDEngineering].[dbo].[Stock] as st ";
  
            DataSet dsstock = dbBranch.DBSelect(sqlstock);
            int countstock = dsstock.Tables[0].Rows.Count;
            if (countstock > 0)
            {
                for (int i = 0; i < countstock; i++)
                {
                    num = num + 1;
                    string st_id = dsstock.Tables[0].Rows[i]["st_id"].ToString();
                    string group_name = dsstock.Tables[0].Rows[i]["group_name"].ToString();
                    string Itemcode = dsstock.Tables[0].Rows[i]["Itemcode"].ToString();
                    string Itemname = dsstock.Tables[0].Rows[i]["Itemname"].ToString();

                    string Itemtotal_amount = dsstock.Tables[0].Rows[i]["Itemtotal_amount"].ToString();
                    string unit = dsstock.Tables[0].Rows[i]["unit"].ToString();

                    string storage_number = dsstock.Tables[0].Rows[i]["storage_number"].ToString();
                    string remark = dsstock.Tables[0].Rows[i]["remark"].ToString();

                    TableRow rowdata = new TableRow();
                    TableCell celldata = new TableCell();
                    CheckBox cbSpares = new CheckBox();
                    cbSpares.ID = st_id;
                    cbSpares.SkinID = Itemname;
                    cbSpares.Checked = false;
                    celldata.Controls.Add(cbSpares);
                    celldata.HorizontalAlign = HorizontalAlign.Center;
                    lstChckBox.Add(cbSpares);
                    rowdata.Cells.Add(celldata);

                    celldata = new TableCell();
                    celldata.Text = num.ToString();
                    rowdata.Cells.Add(celldata);

                    celldata = new TableCell();
                    celldata.Text = Itemcode;
                    rowdata.Cells.Add(celldata);

                    celldata = new TableCell();
                    celldata.Text = Itemname;
                    rowdata.Cells.Add(celldata);

                    celldata = new TableCell();
                    celldata.Text = group_name;
                    rowdata.Cells.Add(celldata);

                    celldata = new TableCell();
                    celldata.Text = storage_number;
                    rowdata.Cells.Add(celldata);

                    celldata = new TableCell();
                    celldata.Text = unit;
                    rowdata.Cells.Add(celldata);

                    celldata = new TableCell();
                    celldata.Text = Itemtotal_amount;
                    rowdata.Cells.Add(celldata);


                    //---------------------------//



                    //celldata = new TableCell();
                    //celldata.Text = meshTotalNumber;
                    //rowdata.Cells.Add(celldata);

                    //celldata = new TableCell();
                    //celldata.Text = eyeset_remainder_low;
                    //rowdata.Cells.Add(celldata);

                    //celldata = new TableCell();
                    //celldata.Text = eyeset_remainder_high;
                    //rowdata.Cells.Add(celldata);

                    //celldata = new TableCell();
                    //celldata.Text = meshremainder_percent;
                    //rowdata.Cells.Add(celldata);

                    //celldata = new TableCell();
                    //celldata.Text = inpem;
                    //rowdata.Cells.Add(celldata);

                    //celldata = new TableCell();
                    //celldata.Text = inpdate;
                    //rowdata.Cells.Add(celldata);

                    //if (role_id == true)
                    //{
                    celldata = new TableCell();
                    LinkButton lbtneditmeshcode = new LinkButton();
                    lbtneditmeshcode.Text = "<span class='glyphicon glyphicon-th-list' aria-hidden='true'></span> การรับ/จ่าย";
                    lbtneditmeshcode.ForeColor = System.Drawing.Color.DarkOrange;
                    lbtneditmeshcode.CommandArgument = st_id;
                    lbtneditmeshcode.Click += new EventHandler(modelOpedetailadddisbursestock_click);
                    celldata.Controls.Add(lbtneditmeshcode);
                    rowdata.Cells.Add(celldata);

                    //    celldata = new TableCell();
                    //    LinkButton lbtnmodaldel = new LinkButton();
                    //    lbtnmodaldel.Text = "<span class='glyphicon glyphicon-trash' aria-hidden='true'></span> ลบ";
                    //    lbtnmodaldel.ID = msd_id;
                    //    lbtnmodaldel.ForeColor = System.Drawing.Color.Red;
                    //    lbtnmodaldel.Click += new EventHandler(lbtndeletemeshtotalnumberstandard_Click);
                    //    celldata.Controls.Add(lbtnmodaldel);
                    //    rowdata.Cells.Add(celldata);
                    //}
                    //else
                    //{
                    //    celldata = new TableCell();
                    //    celldata.Text = "<span class='glyphicon glyphicon-edit' aria-hidden='true'></span> แก้ไข";
                    //    celldata.ForeColor = System.Drawing.Color.DarkOrange;
                    //    rowdata.Cells.Add(celldata);

                    //    celldata = new TableCell();
                    //    celldata.Text = "<span class='glyphicon glyphicon-trash' aria-hidden='true'></span> ลบ";
                    //    celldata.ForeColor = System.Drawing.Color.Red;
                    //    rowdata.Cells.Add(celldata);
                    //}

                    tblStock.Rows.Add(rowdata);
                }
            }
        }


        protected void modelOpedetailadddisbursestock_click(object sender, EventArgs e)
        {
            LinkButton source = (LinkButton)sender;   
            int num = 0;
            DBConnect dbBranch = new DBConnect("Center");
            string sqlstock = "SELECT sht.his_totalamount,sht.inpdate,sht.emp_id,sht.amount,sht.his_nametype,st.group_name,st.st_id,st.Itemcode,st.Itemname,st.Itemtotal_amount" +
                              ",st.unit,st.storage_number,st.remark FROM [DBRDEngineering].[dbo].[Stock] as st "+
                             "left JOIN [DBRDEngineering].[dbo].[History_stock] as sht ON sht.st_id = st.st_id "+
                             "where st.st_id = '" + source.CommandArgument + "' ";
            DataSet dsstock = dbBranch.DBSelect(sqlstock);
            int countstock = dsstock.Tables[0].Rows.Count;
            if (countstock > 0)
            {
                for (int i = 0; i < countstock; i++)
                {
                    num = num + 1;
                    string st_id = dsstock.Tables[0].Rows[i]["st_id"].ToString();
                    string group_name = dsstock.Tables[0].Rows[i]["group_name"].ToString();
                    string Itemcode = dsstock.Tables[0].Rows[i]["Itemcode"].ToString();
                    string Itemname = dsstock.Tables[0].Rows[i]["Itemname"].ToString();
                    string his_nametype = dsstock.Tables[0].Rows[i]["his_nametype"].ToString();
                    string amount = dsstock.Tables[0].Rows[i]["amount"].ToString();
                    string emp_id = dsstock.Tables[0].Rows[i]["emp_id"].ToString();
                    DateTime inpdate = new DateTime();
                    DateTime.TryParse(dsstock.Tables[0].Rows[i]["inpdate"].ToString(), out inpdate);

                    string Itemtotal_amount = dsstock.Tables[0].Rows[i]["Itemtotal_amount"].ToString();
                    string his_totalamount = dsstock.Tables[0].Rows[i]["his_totalamount"].ToString();
                    string unit = dsstock.Tables[0].Rows[i]["unit"].ToString();

                    string storage_number = dsstock.Tables[0].Rows[i]["storage_number"].ToString();
                    string remark = dsstock.Tables[0].Rows[i]["remark"].ToString();



                    TableRow rowdata = new TableRow();
                    TableCell celldata = new TableCell();


                    celldata = new TableCell();
                    celldata.Text = num.ToString();
                    rowdata.Cells.Add(celldata);

                    celldata = new TableCell();
                    celldata.Text = his_nametype;
                    rowdata.Cells.Add(celldata);

                    celldata = new TableCell();
                    celldata.Text = Itemname;
                    rowdata.Cells.Add(celldata);

                    celldata = new TableCell();
                    celldata.Text = group_name;
                    rowdata.Cells.Add(celldata);

                    celldata = new TableCell();
                    celldata.Text = storage_number;
                    rowdata.Cells.Add(celldata);

                    celldata = new TableCell();
                    celldata.Text = unit;
                    rowdata.Cells.Add(celldata);

                    celldata = new TableCell();
                    celldata.Text = amount;
                    rowdata.Cells.Add(celldata);

                    celldata = new TableCell();
                    celldata.Text = his_totalamount;
                    rowdata.Cells.Add(celldata);

                    celldata = new TableCell();
                    celldata.Text = emp_id;
                    rowdata.Cells.Add(celldata);

                    celldata = new TableCell();
                    celldata.Text = inpdate.ToString("dd/MM/yyyy HH:mm");
                    rowdata.Cells.Add(celldata);


                    //---------------------------//


                    tbldetailadddisbursestock.Rows.Add(rowdata);
                }
            }

             Page.ClientScript.RegisterStartupScript(GetType(), "Pop", "modeldetailadddisbursestock();", true);
        }

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            string setpp_id = "";
            string setpareparts_name = "";
            int count = 0;
            foreach (CheckBox item in lstChckBox)
            {
                if (item.Checked == true)
                {
                    setpp_id = item.ID;
                    count++;
                    setpareparts_name = item.SkinID;
                }
            }
            if (count == 1)
            {
                tbItemname.Text = setpareparts_name;
                tbstock_id.Text = setpp_id;
                Page.ClientScript.RegisterStartupScript(GetType(), "Pop", "modeldisbursestock();", true);
            }
            else
            {
                ShowMessage("กรุณาเลือกรายการที่ต้องการแก้ไข 1 รายการเท่านั้น", MessageType.Warning);
            }
        }
        protected void lbtnResetAll_Click(object sender, EventArgs e)
        {
            Response.RedirectPermanent("Stock.aspx");
        }
        protected void lbtnselectall_Click(object sender, EventArgs e)
        {
            foreach (CheckBox item in lstChckBox)
            {
                item.Checked = true;
            }
        }

        protected void lbtnSaveEdit_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            DBConnect dbBranch = new DBConnect("Center");
            string setpp_id = "";
            DateTime datenow = DateTime.Now;
            foreach (CheckBox item in lstChckBox)
            {
                if (item.Checked == true)
                {
                    setpp_id = item.ID;
                    break;
                }
            }
            if (setpp_id != "")
            {
                if (tbdisbursestcok.Text != "")
                {
                    string sqlstock = "SELECT st.group_name,st.st_id,st.Itemcode,st.Itemname,st.Itemtotal_amount," +
                                "st.unit,st.storage_number,st.remark FROM [DBRDEngineering].[dbo].[Stock] as st " +
                                "where st.st_id  ='" + tbstock_id.Text + "'";
                    DataSet dsstock = dbBranch.DBSelect(sqlstock);
                    int countstock = dsstock.Tables[0].Rows.Count;
                    if (countstock > 0)
                    {
                        for (int i = 0; i < countstock; i++)
                        {

                            string st_id = dsstock.Tables[0].Rows[i]["st_id"].ToString();
                            string Itemtotal_amount = dsstock.Tables[0].Rows[i]["Itemtotal_amount"].ToString();

                            // mcname = mcname.ToUpper();
                            if (tbdisbursestcok.Text != "" )
                            {
                                int add_amount = Convert.ToInt32(Itemtotal_amount) - Convert.ToInt32(tbdisbursestcok.Text);
                                string stock_add = "'" + st_id + "','จ่าย','" + tbdisbursestcok.Text + "','"+ add_amount + "','" + Session["Emp_id"].ToString() + "',Getdate()";

                                string sqlInsert = "INSERT History_stock(st_id,his_nametype,amount,his_totalamount,emp_id,inpdate) VALUES(" + stock_add + ")";
                                bool checkInsert = dbBranch.DBQuery(sqlInsert);

                                
                                if (checkInsert == true)
                                {

                                    string sqlupdate = "UPDATE Stock set Itemtotal_amount = '" + add_amount + "' where  st_id = '" + st_id + "'";
                                    bool checkupdate = dbBranch.DBQuery(sqlupdate);

                                    //bool ckhistory = WovenHistory.SaveHistory(ddlBranch.SelectedValue, "ข้อมูลเครื่องทอ", "เพิ่มเครื่องทอ " + mcname, Session["emp_id"].ToString());
                                    //if (ckhistory == false)
                                    //{
                                    //    ShowMessage("ไม่สามารถบันทึกประวัติการทำกิจกรรมได้ กรุณาติดต่อฝ่ายผลิตชิ้นส่วนและอุปกรณ์", MessageType.Warning);
                                    //}
                                    ShowMessage("บันทึกข้อมูลสำเร็จ", MessageType.Success);

                                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS", "setTimeout(function() { window.location.replace('Stock.aspx') }, 3000);", true);
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