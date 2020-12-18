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
    public partial class DeleteConfirmationPOrders : System.Web.UI.Page
    {
        static OrdersDataSet dsOrder;
        private static int id = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)  //if not logged in
                Response.Redirect("/");

            try
            {
                dsOrder = new OrdersDataSet();
                prod_orderTableAdapter daOrder = new prod_orderTableAdapter();

                daOrder.Fill(dsOrder.prod_order);


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

                    prod_orderTableAdapter daOrder = new prod_orderTableAdapter();
                    daOrder.Fill(dsOrder.prod_order);
                    DataRow record = dsOrder.prod_order.FindByid(id); // Find and add the record to tbe record variable
                    record.Delete(); // Deletes the record in memory

                     // table adapter to service table (Service adapter)
                    daOrder.Update(record); // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
                    dsOrder.AcceptChanges(); // Call accept method on the dataset so it update the chanmges to the database
                                             //Refresh the page to show the record being deleted
                    Response.Redirect("Default.aspx");
                }
                catch
                {
                    lblStatus.Text = "Delete failed. Probably this Order assigned to some arrived Order in Database.";
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("/");
        }
    }
}