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
        static EmmasDataSet dsInventory = new EmmasDataSet();
        static InventoryLookUpTableAdapter daInventory = new InventoryLookUpTableAdapter();
        static bool flag = false;
        private static DataRow[] rows;

        static Default()
        {
            try
            {
                daInventory.Fill(dsInventory.InventoryLookUp);

            }
            catch
            {
                flag = true;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            // No data loaded
            if (flag)
                return;

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
                nr[1] = r.ItemArray[6].ToString();
                nr[2] = r.ItemArray[1].ToString();
                nr[3] = r.ItemArray[2].ToString();
                nr[4] = r.ItemArray[7].ToString();
                nr[5] = r.ItemArray[4].ToString();

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

                // Detail btn
                Button btnDeail = new Button();  //create edit btn
                                                 // btnEdits.Add(btnEdit);  //the list index of the button will also be the row index
                btnDeail.CssClass = "btn btn-info";  //set css class
                btnDeail.Text = "Detail";
                btnDeail.Attributes.Add("aria-label", "Click to go to the edit page for this sale");
                e.Row.Cells[6].Controls.Add(btnDeail);  //add the btn



                // Edit btn
                Button btnEdit = new Button();  //create edit btn
                                                // btnEdits.Add(btnEdit);  //the list index of the button will also be the row index
                btnEdit.CssClass = "btn btn-dark";  //set css class
                btnEdit.Text = "Edit";
                btnEdit.Attributes.Add("aria-label", "Click to go to the edit page for this sale");

                //set aria label
                // btnEdit.Attributes.Add("OnClick", "btnEdit_Click");  //click event handler

               // btnEdit.Click += new EventHandler(btnEdit_Click);// Set button click event
                e.Row.Cells[6].Controls.Add(btnEdit);  //add the btn



                // Delete btn
                Button btnDelete = new Button();  //create delete btn
                                                  // btnDetails.Add(btnDelete);  //the list index of the button will also be the row index
                btnDelete.CssClass = "btn btn-danger";  //set css class
                btnDelete.Text = "Delete";
                btnDelete.Attributes.Add("aria-label", "Click to delete this sale");
                //set aria label
                // btnDelete.Attributes.Add("OnClick", "btnDelete_Click");  //click event handler
              //  btnDelete.Click += new EventHandler(btnDelete_Click);// Set button click event


                //if (not admin)
                //btnDelete.Visible = false;
                //btnDelete.Enabled = false;

                e.Row.Cells[6].Controls.Add(btnDelete);  //add the btn
            }
            catch
            {
                
            }
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
    }

}