using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRIMELibrary.OrdersDataSetTableAdapters;
using PRIMELibrary;
using System.Data;

namespace PRIMEWeb.Orders
{
    public partial class DeleteConfirmation : System.Web.UI.Page
    {

        static OrdersDataSet dsOrder;
        private static int id = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                dsOrder = new OrdersDataSet();
                on_orderTableAdapter daOrder = new on_orderTableAdapter();
                
                daOrder.Fill(dsOrder.on_order);


                if (Request.Cookies["ID"] != null) // Request the cookies which contaions the ID Of thr record that was carried over from the index page
                    id = Convert.ToInt32(Request.Cookies["ID"].Value);
                if (Request.Cookies["Action"] != null && Request.Cookies["Action"].Value == "Delete")
                {
                    pnlDeleteConfirm.Visible = true;
                    lblTitle.Text = "Delete Sale";
                }
                else
                {
                    pnlDeleteConfirm.Visible = false;
                }
            }
            catch { return; }
        }

        protected void btnDeleteConfirm_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                try
                {

                    
                    DataRow record = dsOrder.on_order.FindByid(id); // Find and add the record to tbe record variable
                    record.Delete(); // Deletes the record in memory

                    on_orderTableAdapter daOrder = new on_orderTableAdapter(); // table adapter to service table (Service adapter)
                    daOrder.Update(record); // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
                    dsOrder.AcceptChanges(); // Call accept method on the dataset so it update the chanmges to the database
                                                //Refresh the page to show the record being deleted
                    Response.Redirect("ArrivedOrderDefaultPage.aspx");
                }
                catch
                {
                    lblStatus.Text = "Delete failed.";
                }
            }
        }
    }
}