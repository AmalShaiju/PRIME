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
    public partial class EditRepair : System.Web.UI.Page
    {
        static RepairsDataSet repairsDataSet;

        static EditRepair()
        {
            repairsDataSet = new RepairsDataSet();
            service_orderTableAdapter daServiceOrder = new service_orderTableAdapter();

        }

        private static int id = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["ID"] != null) // Request the cookies which contaions the ID Of thr record that was carried over from the index page
                this.Label1.Text = Request.Cookies["ID"].Value;



            id = Convert.ToInt32(Request.Cookies["ID"].Value);
            if (!IsPostBack)
            {

                if (id != -1)
                {
                    try
                    {
                        service_orderTableAdapter daServiceOrder = new service_orderTableAdapter();
                        daServiceOrder.Fill(repairsDataSet.service_order);

                        DataRow ServiceOrder = repairsDataSet.service_order.FindByid(id); // Find the related Record and fill the fields in the page with the data

                        if (Service != null)
                        {
                            this.txtDateIn.Text = Convert.ToDateTime(ServiceOrder.ItemArray[1].ToString()).ToShortDateString();
                            this.txtDateOut.Text = Convert.ToDateTime(ServiceOrder.ItemArray[2].ToString()).ToShortDateString();
                            this.txtIssue.Text = ServiceOrder.ItemArray[3].ToString();
                            if (ServiceOrder.ItemArray[4].ToString() == "False")
                                this.radNoWarranty.Checked = true;
                            else
                                this.radInWarranty.Checked = true;
                            this.ddlReceipt.SelectedValue = ServiceOrder.ItemArray[5].ToString();
                            this.ddlService.SelectedValue = ServiceOrder.ItemArray[6].ToString();
                            this.ddlEquipment.SelectedValue = ServiceOrder.ItemArray[7].ToString();
                            this.ddlEmployee.SelectedValue = ServiceOrder.ItemArray[8].ToString();

                        }
                        else
                        {
                            // this.Clear();
                            this.Label1.Visible = true;
                            this.Label1.Text = "&#x274C; Please Try Again";

                        }
                    }
                    catch
                    {
                        this.Label1.Visible = true;
                        this.Label1.Text = "&#x274C; Database Eror, Contact System Administrator";

                    }
                }
            }
            else
            {
                Repairvalidation();
            }


        }

        //Edit btn
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //check a record has been selected
            if (id != -1 && Repairvalidation())
            {

                try
                {
                    DataRow record = repairsDataSet.service_order.FindByid(id); // find the related Record

                    //update the record with user's input
                    record[1] = this.txtDateIn.Text;
                    record[2] = this.txtDateOut.Text;
                    record[3] = this.txtIssue.Text;
                    if (this.radInWarranty.Checked)
                        record[4] = 1;
                    else
                        record[4] = 0;
                    record[5] = this.ddlReceipt.SelectedValue;
                    record[6] = this.ddlService.SelectedValue;
                    record[7] = this.ddlEquipment.SelectedValue;
                    record[8] = this.ddlEmployee.SelectedValue;

                    service_orderTableAdapter daServiceOrder = new service_orderTableAdapter();
                    daServiceOrder.Update(record); // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
                    repairsDataSet.AcceptChanges(); // Call accept method on the dataset so it update the chanmges to the database

                    //Send Id to details view
                    HttpCookie cID = new HttpCookie("ID"); // Cokkie variable named cID to hold a value 
                    cID.Value = id.ToString();
                    Response.Cookies.Add(cID);
                    Session["editRedirect"] = "true";// session for details view to see if its a redirect or not
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

        private bool Repairvalidation()
        {
            bool control = true;

            this.Label1.Visible = true;
            if (Convert.ToDateTime(this.txtDateIn.Text) > Convert.ToDateTime(this.txtDateOut.Text))
            {
                this.lblDateInVal.Visible = true;
                this.lblDateInVal.Text = "* The date In should be before date out";
                this.lblDateOutVal.Visible = true;
                this.lblDateOutVal.Text = "* The date out should be after date in";
                control = false;
            }
            else
            {
                this.lblDateInVal.Visible = false;
                this.lblDateOutVal.Visible = false;

            }

            if (this.ddlReceipt.SelectedValue == "None")
            {
                this.lblRecieotVal.Visible = true;
                this.lblRecieotVal.Text = "* Please choose a Reciept Number";
                control = false;

            }
            else
            {
                this.lblRecieotVal.Visible = false;
            }

            if (this.ddlService.SelectedValue == "None")
            {
                this.lblServiceVal.Visible = true;
                this.lblServiceVal.Text = "* Please choose a service";
                control = false;

            }
            else
            {
                this.lblServiceVal.Visible = false;
            }

            if (this.ddlEquipment.SelectedValue == "None")
            {
                this.lblEquipmentVal.Visible = true;
                this.lblEquipmentVal.Text = "* Please choose an Equipment";
                control = false;

            }
            else
            {
                this.lblEquipmentVal.Visible = false;

            }

            if (this.ddlEmployee.SelectedValue == "None")
            {
                this.lblEmployeeval.Visible = true;
                this.lblEmployeeval.Text = "* Please choose an Employee";
                control = false;

            }
            else
            {
                this.lblEmployeeval.Visible = false;


            }

            if (this.txtIssue.Text.Length >= 100)
            {
                this.lblIssueVal.Visible = true;
                this.lblIssueVal.Text = "* The isssue should be less than 100 characters";
                control = false;

            }
            else
            {
                this.lblIssueVal.Visible = false;

            }

            if (control == true)
            {
                this.Label1.Visible = false;
            }

            return control;
        }
    }

}
