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

        }

        protected void btnCreate_Click(object sender, EventArgs e)
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

                //Refresh the page to show the record being deleted
                Response.Redirect("Default.aspx"); // Redirect the user to dexpage on to show created data

                Label1.Text = "Created";
            }
            catch
            {
                Label1.Text = "Failed";

            }
        }
    }
}