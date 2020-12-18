using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRIMELibrary;
using PRIMELibrary.InventoryDataSetTableAdapters;

namespace PRIMEWeb.Inventory
{
    public partial class DeleteItem : System.Web.UI.Page
    {
        private static InventoryDataSet dsInventory = new InventoryDataSet();
        private static InventoryLookUpTableAdapter daInvLookUp = new InventoryLookUpTableAdapter();
        private static InventoryTableAdapter daInventory = new InventoryTableAdapter();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)  //if not logged in
                Response.Redirect("/");
            if (String.IsNullOrEmpty(Request.QueryString["ID"]))
                Response.Redirect("/Inventory");  //no id passed in
            try
            {
                dsInventory.Clear();
                daInventory.Fill(dsInventory.Inventory);
                daInvLookUp.Fill(dsInventory.InventoryLookUp);
                int id = Convert.ToInt32(Request.QueryString["ID"]);
                DataRow record = dsInventory.InventoryLookUp.FindByid(id); // Find the requested record
                lblInvName.Text = record[4].ToString();
                lblInvQty.Text = record[1].ToString();
                lblInvSize.Text = record[2].ToString();
                lblInvBrand.Text = record[5].ToString();
                lblInvPrice.Text = Convert.ToDecimal(record[3]).ToString("C2");
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Failed to load data";
            }
        }

        protected void btnDeleteConfirm_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            try
            {
                DataRow record = dsInventory.Inventory.FindByid(id); // Find the requested record 
                record.Delete(); // Deletes the record in memory\
                daInventory.Update(record); // Call update method on the Repair adapter so it updates the table in memory ( All changes made are applied - CRUD)
                dsInventory.AcceptChanges(); // Call accept method on the dataset so it update the chanmges to the database
                Response.Redirect("/Inventory");
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Failed: " + ex.Message;
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