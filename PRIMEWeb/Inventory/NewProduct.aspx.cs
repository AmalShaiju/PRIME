﻿using PRIMELibrary;
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
    public partial class NewProduct : System.Web.UI.Page
    {
        static EmmasDataSet dsInventory = new EmmasDataSet();
        private static DataRow[] rows;
        static NewProduct()
        {
            dsInventory = new EmmasDataSet();
            InventoryLookUpTableAdapter daInventory = new InventoryLookUpTableAdapter();



        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {


                DataRow Inventorydata = dsInventory.product.NewRow(); // Create a new row of service_order table in memory
                                                                        //update record with user's input

                Inventorydata[1] = this.txtProduct.Text;
                Inventorydata[3] = this.ddlBrand.SelectedValue;

                Inventorydata[2] = this.txtDescription.Text;

                
                productTableAdapter ProductTable = new productTableAdapter();
                dsInventory.product.Rows.Add(Inventorydata); // add the rows to the dataset


                ProductTable.Update(Inventorydata);
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

        protected void cboHelp_CheckedChanged(object sender, EventArgs e)
        {
            lblIdHelp.Visible = lblDescHelp.Visible = lblBrandHelp.Visible = pnlProductssHelp.Visible = cboHelp.Checked;
        }
    }
}