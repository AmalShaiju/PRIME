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
    public partial class NewItem : System.Web.UI.Page
    {
       
        static InventoryDataSet dsInventory = new InventoryDataSet();
        private static DataRow[] rows;
        static NewItem()
        {
            dsInventory = new InventoryDataSet();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)  //if not logged in
                Response.Redirect("/");

            if (this.IsPostBack)
            {
                return;
            }
            InventoryLookUpTableAdapter daInventory = new InventoryLookUpTableAdapter();
            ProductTableAdapter daProduct= new ProductTableAdapter();

            daInventory.Fill(dsInventory.InventoryLookUp);
            daProduct.Fill(dsInventory.Product);
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow Inventorydata = dsInventory.Inventory.NewRow(); // Create a new row of service_order table in memory
                //update record with user's input
                Inventorydata[5] = this.ddlProducts.SelectedValue;
                Inventorydata[3] = this.ddlMeasures.SelectedValue;
                Inventorydata[1] = this.txtQuantity.Text;
                Inventorydata[2] = this.txtSize.Text;
                Inventorydata[4] = this.txtPrice.Text;

                ProductTableAdapter daProduct = new ProductTableAdapter();
                InventoryTableAdapter inventoryTable = new InventoryTableAdapter();
                dsInventory.Inventory.Rows.Add(Inventorydata); // add the rows to the dataset


                inventoryTable.Update(Inventorydata);
                // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
                dsInventory.AcceptChanges();
                // Call accept method on the dataset so it update the chanmges to the database
                Label1.Text = "Created 1";

                //Refresh the page to show the record being deleted
                Response.Redirect("Default.aspx"); // Redirect the user to dexpage on to show created data

                Label1.Text = "Created";

            }
            catch
            {
                Label1.Text = "Failed";
            }
        }
        private static int id;
        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.ddlProducts.SelectedValue=="new_item")
            {
                Response.Redirect("NewProduct.aspx");
            }

            ProductTableAdapter daInventory = new ProductTableAdapter();

            id = Convert.ToInt32( this.ddlProducts.SelectedValue);

            rows = dsInventory.Product.Select();

            foreach (DataRow r in rows)
            {
                if(Convert.ToInt32(r.ItemArray[0].ToString())==id)
                {
                    this.txtBrand.Text = r.ItemArray[3].ToString();
                    this.txtDescription.Text = r.ItemArray[2].ToString();
                }
            }
        }

        protected void cboHelp_CheckedChanged(object sender, EventArgs e)
        {
            lblPriceHelp.Visible = lblBrandHelp.Visible = lblDescriptionHelp.Visible = lblMeasuerHelp.Visible = lblProducthelp.Visible = lblQuantityuHelp.Visible= lblSizeHelp.Visible = cboHelp.Checked;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("/");
        }
    }
}