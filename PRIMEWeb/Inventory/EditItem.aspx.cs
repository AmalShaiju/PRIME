using PRIMELibrary;
using PRIMELibrary.EmmasDataSetTableAdapters;
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
        private static int id = -1;
        static EmmasDataSet dsInventory = new EmmasDataSet();
        private static DataRow[] rows;
        static EditItem()
        {
            dsInventory = new EmmasDataSet();

            try
            {
                inventoryTableAdapter daInventory = new inventoryTableAdapter();
                daInventory.Fill(dsInventory.inventory);
            }
            catch { }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)  //if not logged in
                Response.Redirect("/");

            InventoryLookUpTableAdapter dainventoryLookUpTable = new InventoryLookUpTableAdapter();
            dainventoryLookUpTable.Fill(dsInventory.InventoryLookUp);
            id = Convert.ToInt32(Session["InventoryId"]);
            Label1.Text = Session["InventoryId"].ToString();
            if(! IsPostBack)

                if (id != -1)
                {
                    try
                    {
                        DataRow ServiceOrder = dsInventory.InventoryLookUp.FindByid(id); // Find the related Record and fill the fields in the page with the data

                   
                    
                            this.txtDescription.Text = ServiceOrder.ItemArray[6].ToString();
                            this.txtQuantity.Text = ServiceOrder.ItemArray[1].ToString();
                            this.txtPrice.Text = ServiceOrder.ItemArray[3].ToString();
                            this.txtBrand.Text = ServiceOrder.ItemArray[5].ToString();

                            this.txtSize.Text = ServiceOrder.ItemArray[2].ToString();

                            this.ddlMeasures.SelectedValue = ServiceOrder.ItemArray[8].ToString();
                            this.ddlProducts.SelectedValue = ServiceOrder.ItemArray[0].ToString();
                       
                    

                   }
                   catch { }
                    }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
           
            
                if (id != -1)
                {
                   // try
                    //{
                        DataRow record = dsInventory.inventory.FindByid(id); // Find the related Record and fill the fields in the page with the data

                        if (record != null)
                        {
                        //record[5] = this.ddlProducts.SelectedValue;
                        record[3] = this.ddlMeasures.SelectedValue;
                        record[1] = this.txtQuantity.Text;
                        record[2] = this.txtSize.Text;
                        record[4] = this.txtPrice.Text;

                      // dsInventory.inventory.Rows.Add(record); // add the rows to the dataset

                            inventoryTableAdapter daInventory = new inventoryTableAdapter();
                            daInventory.Update(record);
                            // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
                            dsInventory.AcceptChanges();

                        Response.Redirect("Default.aspx");


                        }

                    //}
                    //catch
                    //{
                        // this.Label1.Visible = true;
                        // this.Label1.Text = "Database Error";

                    //}
                }
            
        }

        protected void cboHelp_CheckedChanged(object sender, EventArgs e)
        {
             lblMeasuerHelp.Visible = lblProducthelp.Visible = lblQuantityuHelp.Visible = lblSizeHelp.Visible = lblPriceHelp.Visible = cboHelp.Checked;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("/");
        }
    }
}