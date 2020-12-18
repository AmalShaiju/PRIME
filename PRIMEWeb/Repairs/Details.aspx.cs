using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PRIMELibrary;
using PRIMELibrary.RepairsDataSetTableAdapters;
using System.Drawing;

namespace PRIMEWeb.Repairs
{
    public partial class Details : System.Web.UI.Page
    {
        static RepairsDataSet repairsDataSet;

        static Details()
        {
            repairsDataSet = new RepairsDataSet();


        }
        private static int id = -1;
        private static int deleteId = -1;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["ID"] != null)
            {

                // Request the cookies which contaions the ID Of thr record that was carried over from the index page
                id = Convert.ToInt32(Request.Cookies["ID"].Value);
            }
            if (Session["deleteId"] != null)
            {
                deleteId = Convert.ToInt32(Session["deleteId"]);
                this.pnlDeleteConfirm.Visible = true;

            }



            if (Session["editRedirect"] != null)
            {
                this.redirectMsg.Visible = true;

                if (Session["editRedirect"].ToString() == "true")
                {
                    this.redirectMsg.Text = "&#10004; Record Successfully Updated";
                }
                else if (Session["editRedirect"].ToString() == "repairStarted")
                {
                    this.redirectMsg.Text = "&#10004; Repair Timer Started";
                }
                else if (Session["editRedirect"].ToString() == "repairPaused")
                {
                    this.redirectMsg.Text = "&#10004; Repair Timer Started";
                }
                else if (Session["editRedirect"].ToString() == "repairResumed")
                {
                    this.redirectMsg.Text = "&#10004; Repair Timer Resumed";
                }
                else
                {
                    this.redirectMsg.Text = "&#10004; Repair Timer Stoped";
                }
            }


            if (Session["createRedirect"] != null)
            {
                this.redirectMsg.Visible = true;
                this.redirectMsg.ForeColor = Color.Green;
                this.redirectMsg.Text = "&#10004; Record Successfully Created";
            }


            if (id != -1)
            {
                try
                {
                    RepairLookUpTableAdapter daRepair = new RepairLookUpTableAdapter();
                    daRepair.Fill(repairsDataSet.RepairLookUp);

                    service_orderTableAdapter daServiceOrder = new service_orderTableAdapter();

                    daRepair.Fill(repairsDataSet.RepairLookUp);
                    daServiceOrder.Fill(repairsDataSet.service_order);

                    DataRow record = repairsDataSet.RepairLookUp.FindByid(id); // Find the related Record and fill the fields in the page with the data

                    if (record != null)
                    {

                        if (record.ItemArray[8].ToString() != "")
                        {
                            this.lblDateIn.Text = Convert.ToDateTime(record.ItemArray[7].ToString()).ToString("dddd, dd MMMM yyyy");
                            this.lblDateOut.Text = Convert.ToDateTime(record.ItemArray[8].ToString()).ToString("dddd, dd MMMM yyyy");
                            this.lblStatus.Text = "Repair Finished";
                            this.lblStatus.ForeColor = Color.Green;

                            //display none of the btn if finished
                            this.btnStop.Visible = false;
                            this.btnStart.Visible = false;
                            this.btnPause.Visible = false;
                            this.btnResume.Visible = false;


                            this.lblStart.Text = Convert.ToDateTime(record.ItemArray[7]).ToString("dddd, dd MMMM yyyy hh:mm tt");
                            this.lblStop.Text = Convert.ToDateTime(record.ItemArray[8]).ToString("dddd, dd MMMM yyyy hh:mm tt");
                            if (Session["Resumed"] != null)
                            {
                                this.lblpaused.Text = Session["Resumed"].ToString();
                                this.Label15.Visible = true;
                                this.lblpaused.Visible = true;
                            }
                            if (Session["Paused"] != null)
                            {
                                this.lblResumed.Text = Session["Paused"].ToString();
                                this.Label19.Visible = true;
                                this.lblResumed.Visible = true;
                            }

                            this.Label20.Visible = true;
                            this.lblStart.Visible = true;


                            this.Label21.Visible = true;
                            this.lblStop.Visible = true;

                        }
                        else if ((record.ItemArray[8].ToString() == "") && (record.ItemArray[7].ToString() != ""))
                        {
                            this.lblDateIn.Text = Convert.ToDateTime(record.ItemArray[7].ToString()).ToShortDateString();
                            this.lblStart.Text = Convert.ToDateTime(record.ItemArray[7]).ToString("dddd, dd MMMM yyyy hh:mm tt");
                            this.lblDateOut.Text = "Repari in progress";
                            this.lblStatus.Text = "Repari in progress";
                            this.lblStatus.ForeColor = Color.Orange;


                            this.btnStart.Visible = false;
                            this.btnResume.Visible = false;
                            this.btnStop.Visible = true;
                            this.btnPause.Visible = true;


                            this.Label20.Visible = true;
                            this.lblStart.Visible = true;


                            if (Session["Paused"] != null)
                            {
                                this.btnPause.Visible = false;

                                //display pasue and stop btns if in progress
                                this.btnResume.Visible = true;

                                this.lblStatus.Text = "Repair Paused";
                                this.lblpaused.Text = Session["Paused"].ToString();


                                this.Label15.Visible = true;
                                this.lblpaused.Visible = true;

                            }

                            if (Session["Resumed"] != null)
                            {
                                this.btnStart.Visible = false;
                                this.btnPause.Visible = false;
                                this.btnResume.Visible = false;

                                this.btnStop.Visible = true;

                                this.Label19.Visible = true;
                                this.lblResumed.Visible = true;


                                this.lblStatus.Text = "Reparir in progress";
                                this.lblResumed.Text = Session["Paused"].ToString();

                            }

                        }
                        else
                        {
                            this.lblDateIn.Text = "Repair not started";
                            this.lblDateOut.Text = "Repair not started";
                            this.lblStatus.Text = "Repair not started";
                            this.lblStatus.ForeColor = Color.Red;
                            this.btnResume.Visible = false;
                            this.btnPause.Visible = false;
                            this.btnStop.Visible = false;
                            this.btnStart.Visible = true;

                            this.Label20.Visible = false;
                            this.lblStart.Visible = false;

                            this.Label15.Visible = false;
                            this.lblpaused.Visible = false;

                            this.Label19.Visible = false;
                            this.lblResumed.Visible = false;

                            this.Label21.Visible = false;
                            this.lblStop.Visible = false;

                        }


                        this.lblssue.Text = record.ItemArray[1].ToString();
                        if (record.ItemArray[2].ToString() == "False")
                            this.lblWarranty.Text = "&#x274C;";
                        else
                            this.lblWarranty.Text = "&#10004;";
                        this.lblService.Text = record.ItemArray[3].ToString();
                        this.lblEmployee.Text = record.ItemArray[5].ToString();

                        this.lblEquipmentType.Text = record.ItemArray[6].ToString();
                        this.lblEquipmentModel.Text = record.ItemArray[10].ToString();
                        this.lblEquipmentSerial.Text = record.ItemArray[11].ToString();
                        this.lblEquipmentManufacturer.Text = record.ItemArray[19].ToString();

                        this.lblCustomerFirst.Text = record.ItemArray[12].ToString();
                        this.lblCustomerLast.Text = record.ItemArray[14].ToString();
                        this.lblCustomerPhone.Text = record.ItemArray[13].ToString();
                        this.lblCustomerEmail.Text = record.ItemArray[18].ToString();
                        this.lblCustomerAddress.Text = record.ItemArray[15].ToString();
                        this.lblCustomerCity.Text = record.ItemArray[16].ToString();
                        this.lblCustomerPostal.Text = record.ItemArray[17].ToString();

                    }
                    else
                    {
                        // this.Clear();
                        Label1.Text = "&#x274C; Please Try Again";

                    }
                }
                catch
                {
                    Label1.Text = "&#x274C; Database Eror, Contact System Administrator";

                }

            }

        }

        protected void btnStart_Click(object sender, EventArgs e)
        {

            if (id != -1)
            {
                //   try
                // {
                service_orderTableAdapter daService_order = new service_orderTableAdapter();
                daService_order.Fill(repairsDataSet.service_order);
                DataRow record = repairsDataSet.service_order.FindByid(id); // find the related Record

                //update the record with user's input
                record[1] = (DateTime.Now).ToString();

                service_orderTableAdapter daServiceOrder = new service_orderTableAdapter();
                daServiceOrder.Update(record); // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
                repairsDataSet.AcceptChanges(); // Call accept method on the dataset so it update the chanmges to the database

                //Send Id to details view
                HttpCookie cID = new HttpCookie("ID"); // Cokkie variable named cID to hold a value 
                cID.Value = id.ToString();
                Response.Cookies.Add(cID);
                Session["editRedirect"] = "repairStarted";// session for details view to see if its a redirect or not
                Response.Redirect("details.aspx"); // Redirect the user to Edit page on btn click

                //  }
                //catch
                //{
                //    this.Label1.Visible = true;
                //    this.Label1.Text = "&#x274C; Record Updation Failed";
                //    this.Label1.ForeColor = Color.Red;

                //}
            }
        }

        protected void btnStop_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                try
                {
                    service_orderTableAdapter daService_order = new service_orderTableAdapter();
                    daService_order.Fill(repairsDataSet.service_order);
                    DataRow record = repairsDataSet.service_order.FindByid(id); // find the related Record

                    //update the record with user's input
                    record[2] = (DateTime.Now).ToString();

                    service_orderTableAdapter daServiceOrder = new service_orderTableAdapter();
                    daServiceOrder.Update(record); // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
                    repairsDataSet.AcceptChanges(); // Call accept method on the dataset so it update the chanmges to the database

                    //Send Id to details view
                    HttpCookie cID = new HttpCookie("ID"); // Cokkie variable named cID to hold a value 
                    cID.Value = id.ToString();
                    Response.Cookies.Add(cID);
                    Session["editRedirect"] = "repairStoped";// session for details view to see if its a redirect or not
                    Response.Redirect("details.aspx"); // Redirect the user to Edit page on btn click

                }
                catch
                {
                    this.Label1.Visible = true;
                    this.Label1.Text = "&#x274C; Record Updation Failed";
                    this.Label1.ForeColor = Color.Red;

                }
            }
        }

        protected void btnPause_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                Session["Paused"] = DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm tt");
                Response.Redirect("details.aspx");
            }
        }

        protected void btnResume_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                Session["Resumed"] = DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm tt");
                Response.Redirect("details.aspx");

            }
        }

        protected void btnDeleteConfirm_Click(object sender, EventArgs e)
        {
            if (deleteId != -1)

            {

                try
                {
                    DataRow record = repairsDataSet.service_order.FindByid(deleteId); // Find the requested record 
                    record.Delete(); // Deletes the record in memory

                    service_orderTableAdapter daServiceOrder = new service_orderTableAdapter(); // table adapter to Repair table (Repair adapter)
                    daServiceOrder.Update(record); // Call update method on the Repair adapter so it updates the table in memory ( All changes made are applied - CRUD)
                    repairsDataSet.AcceptChanges(); // Call accept method on the dataset so it update the chanmges to the database
                    redirectMsg.Text = "&#10004; Record deleted";
                    //Refresh the page to show the record being deleted
                    Session["deleteMsg"] = "true";

                }
                catch
                {
                    Session["deleteMsg"] = "false";

                    redirectMsg.Text = "&#x274C; Record not deleted";
                    this.redirectMsg.ForeColor = Color.Red;



                }
                finally
                {
                    Response.Redirect("default.aspx");

                }

            }
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {

            Session["deleteId"] = id;
            Response.Redirect("Details.aspx"); // Redirect the user to Edit page on btn click
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Send Id using cookie, more seecure I presume
            HttpCookie cID = new HttpCookie("ID"); // Cokkie variable named cID to hold a value 
            cID.Value = id.ToString();
            Response.Cookies.Add(cID);
            Response.Redirect("EditRepair.aspx"); // Redirect the user to Edit page on btn click
        }
    }
}