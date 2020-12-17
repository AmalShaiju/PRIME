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
    public partial class NewRepair : System.Web.UI.Page
    {
        static RepairsDataSet RepairsDataSet;
        static NewRepair()
        {
            RepairsDataSet = new RepairsDataSet();
            service_orderTableAdapter daServiceOrder= new service_orderTableAdapter();

            try
            {
                daServiceOrder.Fill(RepairsDataSet.service_order);
            }
            catch { }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ServiceCriteria"] = null;
            Session["RepairCriteria"] = null;

            if (IsPostBack)
            {
                Repairvalidation();

            }
           

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (Repairvalidation())
            {


                try
                {
                    DataRow serviceOrder = RepairsDataSet.service_order.NewRow(); // Create a new row of service_order table in memory
                                                                                  //update record with user's input
                    serviceOrder[1] = this.txtDateIn.Text;
                    serviceOrder[2] = this.txtDateOut.Text;
                    serviceOrder[3] = this.txtIssue.Text;
                    if (this.radInWarranty.Checked)
                        serviceOrder[4] = 1;
                    else
                        serviceOrder[4] = 0;
                    serviceOrder[5] = this.ddlReceipt.SelectedValue;
                    serviceOrder[6] = this.ddlService.SelectedValue;
                    serviceOrder[7] = this.ddlEquipment.SelectedValue;
                    serviceOrder[8] = this.ddlEmployee.SelectedValue;

                    RepairsDataSet.service_order.Rows.Add(serviceOrder); // add the rows to the dataset


                    service_orderTableAdapter daSericeOrder = new service_orderTableAdapter();
                    daSericeOrder.Update(serviceOrder); // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
                    RepairsDataSet.AcceptChanges();// Call accept method on the dataset so it update the chanmges to the database

                    //Send Id to details view to show added record
                    HttpCookie cID = new HttpCookie("ID"); // Cokkie variable named cID to hold a value 
                    cID.Value = serviceOrder[0].ToString(); // get the id of the newly added row/record 
                    Response.Cookies.Add(cID);
                    Session["createRedirect"] = true;// session for details view to see if its a redirect or not
                    Response.Redirect("details.aspx");
                }
                catch
                {
                    this.lblStatus.Visible = true;
                    this.lblStatus.Text = "&#x274C; Record Creation Failed";

                }
            }
        }

        //protected void cboHelp_CheckedChanged(object sender, EventArgs e)
        //{
        //    lblDateIn.Visible = lblDateOut.Visible = lblEmployee.Visible =
        //       lblEquipment.Visible = lblIssue.Visible = lblRecipet.Visible =
        //       lblService.Visible =  cboHelp.Checked;

               
        //}

        //method to validate fields
        private bool Repairvalidation()
        {
            bool control = true;

            this.Label1.Visible = true;
            if(Convert.ToDateTime(this.txtDateIn.Text) > Convert.ToDateTime(this.txtDateOut.Text))
            {
                this.lblDateInVal.Visible = true;
                this.lblDateInVal.Text = "* The date In should be before date out";
                this.lblDateOutVal.Visible = true;
                this.lblDateOutVal.Text = "* The date out should be after date in";
                control = false;
            }
            else
            {
                this.lblDateOutVal.Visible = false;

                this.lblDateInVal.Visible = false;
            }

           if(this.ddlReceipt.SelectedValue == "None")
            {
                this.lblRecieotVal.Visible = true;
                this.lblRecieotVal.Text = "* Please choose a Reciept Number";
                control = false;

            }
            else
            {
                this.lblRecieotVal.Visible = false ;
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