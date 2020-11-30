using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PRIMELibrary;
using PRIMELibrary.RepairsDataSetTableAdapters;

namespace PRIMEWeb.Repairs
{
    public partial class EditRepair : System.Web.UI.Page
    {
        static RepairsDataSet repairsDataSet;

        static EditRepair()
        {
            repairsDataSet = new RepairsDataSet();
            service_orderTableAdapter daServiceOrder = new service_orderTableAdapter();

            try
            {
                daServiceOrder.Fill(repairsDataSet.service_order);
            }
            catch { }
        }

        private static int id = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["ID"] != null) // Request the cookies which contaions the ID Of thr record that was carried over from the index page
                Label1.Text = Request.Cookies["ID"].Value;

            id = Convert.ToInt32(Request.Cookies["ID"].Value);

            if (id != -1)
            {
                try
                {
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
                        Label1.Text = "Please Try Again";

                    }
                }
                catch
                {
                    Label1.Text = "Database Error";

                }
            }

        }

        //Edit btn
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //check a record has been selected
            if (id != -1)
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

                    Label1.Text = "Record Successfully Updated";
                    //Response.Redirect("Default.aspx"); // Redirect the user to Edit page on btn click

                }
                catch { Label1.Text = "Unable to Update Record"; }
            }
        }
    }
}