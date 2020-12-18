using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using PRIMELibrary;
using PRIMELibrary.EmmasDataSetTableAdapters;

namespace PRIMEWeb.Inventory
{
    public partial class Default : System.Web.UI.Page
    {
        private static int id;
        static EmmasDataSet dsInventory = new EmmasDataSet();
        static InventoryLookUpTableAdapter daInventory = new InventoryLookUpTableAdapter();
        static bool flag = false;
        private static DataRow[] rows;

        ////static Default()
        ////{
        ////    try
        ////    {

        ////    }
        ////    catch
        ////    {
        ////        flag = true;
        ////    }
        ////}


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)  //if not logged in
                Response.Redirect("/");

            productTableAdapter daProduct = new productTableAdapter();
            InventoryLookUpTableAdapter inventoryTable = new InventoryLookUpTableAdapter();
            inventoryTableAdapter inventoryCRUD = new inventoryTableAdapter();

            inventoryCRUD.Fill(dsInventory.inventory);

            // No data loaded
            if (flag)
                return;
            daInventory.Fill(dsInventory.InventoryLookUp);

            rows = dsInventory.InventoryLookUp.Select();
            DisplayTable();

        }


        private void DisplayTable()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Size");
            dt.Columns.Add("Brand");
            dt.Columns.Add("Price");
            dt.Columns.Add(""); 

            DataRow dr = dt.NewRow();


            foreach (DataRow r in rows) 
            {
                DataRow nr = dt.NewRow();
                nr[0] = r.ItemArray[0].ToString();
                nr[1] = r.ItemArray[4].ToString();
                nr[2] = r.ItemArray[1].ToString();
                nr[3] = r.ItemArray[2].ToString();
                nr[4] = r.ItemArray[5].ToString();
                nr[5] = r.ItemArray[3].ToString();

                dt.Rows.Add(nr);

            }
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try // if the table has no row
            {
                if (e.Row.RowIndex == -1)
                {
                    e.Row.Cells[6].Text = String.Empty;
                    //Clear the header for Detail Edit Delete btn
                    return;  //skip the header
                }

                this.GridView1.HeaderRow.Cells[0].Visible = false;
                e.Row.Cells[0].Visible = false;

               


                // Edit btn
                Button btnEdit = new Button();  //create edit btn
                                                // btnEdits.Add(btnEdit);  //the list index of the button will also be the row index
                btnEdit.CssClass = "btn btn-dark";  //set css class
                btnEdit.Text = "Edit";
                btnEdit.Attributes.Add("aria-label", "Click to go to the edit page for this sale");

                //set aria label
                btnEdit.Attributes.Add("OnClick", "btnEdit_Click");  //click event handler

                btnEdit.Click += new EventHandler(btnEdit_Click);// Set button click event
                e.Row.Cells[6].Controls.Add(btnEdit);  //add the btn



                // Delete btn
                Button btnDelete = new Button();  //create delete btn
                                                  // btnDetails.Add(btnDelete);  //the list index of the button will also be the row index
                btnDelete.CssClass = "btn btn-danger";  //set css class
                btnDelete.Text = "Delete";
                btnDelete.Attributes.Add("aria-label", "Click to delete this sale");

               
                //set aria label
                 btnDelete.Attributes.Add("OnClick", "btnDelete_Click");  //click event handler
                      btnDelete.Click += new EventHandler(btnDelete_Click);// Set button click event


                //if (not admin)
                //btnDelete.Visible = false;
                //btnDelete.Enabled = false;

                e.Row.Cells[6].Controls.Add(btnDelete);  //add the btn
            }
            catch
            {
                
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            // Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            //Get rowindex
            int rowindex = gvr.RowIndex;


            //Send Id using cookie, more seecure I presume
            // Cokkie variable named cID to hold a value 
            Session["InventoryId"] = rows[rowindex].ItemArray[0].ToString();
           
            Response.Redirect("EditItem.aspx"); // Redirect the user to Edit page on btn click


        }

       
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Get the button that raised the event
            Button btn = (Button)sender;

            ////Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            ////Get rowindex
            int rowindex = gvr.RowIndex;

            this.Label1.Text = rowindex.ToString();
            rows = dsInventory.InventoryLookUp.Select();

            id = Convert.ToInt32(rows[rowindex].ItemArray[0].ToString());

            //get confirmation from client side
            // call js script 
            // get the return bool
            // use bool to execute the below code

            // do this after geting confirmation from client side
           // if (id != -1)

            //{

               // try
                //{
                    DataRow record = dsInventory.inventory.FindByid(id); // Find the requested record 
                    record.Delete(); // Deletes the record in memory

                    inventoryTableAdapter inventoryTable = new inventoryTableAdapter();
                    // No data lo // table adapter to Repair table (Repair adapter)
                    inventoryTable.Update(record); // Call update method on the Repair adapter so it updates the table in memory ( All changes made are applied - CRUD)
                    dsInventory.AcceptChanges(); // Call accept method on the dataset so it update the chanmges to the database
                    Label1.Text = "deleted";

                    //Refresh the page to show the record being deleted
                    Response.Redirect("Default.aspx");

              //   }
                // catch
               /// {
                   //  Label1.Text = "not deleted";
                //}
           // }
        }

        private string FilterCriteria()
        {
            string criteria = "";

            criteria = (this.txtItemName.Text.Length > 0) ? " prodName Like '%" + this.txtItemName.Text + "%' " : "";

            criteria += (this.txtFromPrice.Text.Length > 0 && criteria.Length > 0) ? "and invPrice >=" + this.txtFromPrice.Text
                 : (this.txtFromPrice.Text.Length > 0) ? "invPrice >=" + this.txtFromPrice.Text : "";

            criteria += (this.txtToPrice.Text.Length > 0 && criteria.Length > 0) ? "and invPrice <=" + this.txtToPrice.Text
                : (this.txtToPrice.Text.Length > 0) ? "invPrice >=" + this.txtToPrice.Text : "";

            criteria += (this.ddlBrands.Text != "None" && criteria.Length > 0) ? "And productID = " + this.ddlBrands.SelectedValue.ToString()
               : (this.ddlBrands.Text != "None") ? "productID = " + this.ddlBrands.SelectedValue.ToString() : "";
          

            return criteria;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (dsInventory.InventoryLookUp.Count > 0)
            {
                string criteria = FilterCriteria();
                rows = (criteria.Length > 0) ? dsInventory.InventoryLookUp.Select(criteria) : dsInventory.InventoryLookUp.Select(); 
                DisplayTable();
            }
            else
                this.Label1.Text = "No Records Found";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("/");
        }
    }

}