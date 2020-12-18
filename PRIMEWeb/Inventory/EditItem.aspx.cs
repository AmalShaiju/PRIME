using PRIMELibrary;
using PRIMELibrary.InventoryDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRIMEWeb.Inventory
{
    public partial class EditItem : System.Web.UI.Page
    {
        private static InventoryDataSet dsInventory = new InventoryDataSet();
        private static InventoryTableAdapter daInventory = new InventoryTableAdapter();
        private static InventoryLookUpTableAdapter daInvLookUp = new InventoryLookUpTableAdapter();
        private static ProductTableAdapter daProduct = new ProductTableAdapter();
        private int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)  //if not logged in
                Response.Redirect("/");

            if (String.IsNullOrEmpty(Request.QueryString["ID"]))
                Response.Redirect("/Inventory");

            try
            {
                dsInventory.Clear();
                daInventory.Fill(dsInventory.Inventory);
                daInvLookUp.Fill(dsInventory.InventoryLookUp);
                daProduct.Fill(dsInventory.Product);
            }
            catch { }

            if (IsPostBack) return;

            try
            {
                id = Convert.ToInt32(Request.QueryString["ID"]);
                DataRow ServiceOrder = dsInventory.InventoryLookUp.FindByid(id); // Find the related Record and fill the fields in the page with the data

                txtDescription.Text = ServiceOrder.ItemArray[6].ToString();
                txtQuantity.Text = ServiceOrder.ItemArray[1].ToString();
                txtPrice.Text = ServiceOrder.ItemArray[3].ToString();
                txtBrand.Text = ServiceOrder.ItemArray[5].ToString();

                txtSize.Text = ServiceOrder.ItemArray[2].ToString();

                ddlMeasures.SelectedValue = ServiceOrder.ItemArray[8].ToString();
                ddlProducts.SelectedValue = ServiceOrder.ItemArray[0].ToString();
            }
            catch (Exception)
            {
                lblMessage.Text = "Unable to load data";
                lblMessage.Visible = true;
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow prod = dsInventory.Product.FindByid(Convert.ToInt32(ddlProducts.SelectedValue));
            txtDescription.Text = prod[2].ToString();
            txtBrand.Text = prod[3].ToString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["ID"]);
            DataRow record = dsInventory.Inventory.FindByid(id);
            // Find the related Record and fill the fields in the page with the data


            try
            {
                record[1] = txtQuantity.Text;
                record[2] = txtSize.Text;
                record[5] = ddlProducts.SelectedValue;
                record[3] = ddlMeasures.SelectedValue;
                record[4] = txtPrice.Text;

                daInventory.Update(record);
                // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
                dsInventory.AcceptChanges();
                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Failed to update";
                lblMessage.Visible = true;
            }
        }

        protected void cboHelp_CheckedChanged(object sender, EventArgs e)
        {
            lblMeasureHelp.Visible = lblProducthelp.Visible =
                lblBrandHelp.Visible = lblDescHelp.Visible =
                lblPriceHelp.Visible = lblQtyHelp.Visible =
                lblSizeHelp.Visible = cboHelp.Checked;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("/");
        }
    }
}