using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using PRIMELibrary;
using PRIMELibrary.InventoryDataSetTableAdapters;
using System.Web.UI.HtmlControls;

namespace PRIMEWeb.Inventory
{
    public partial class Default : System.Web.UI.Page
    {
        private static InventoryDataSet dsInventory = new InventoryDataSet();
        private static InventoryTableAdapter daInventory = new InventoryTableAdapter();
        private static InventoryLookUpTableAdapter daInvLookUp = new InventoryLookUpTableAdapter();
        private DataRow[] rows;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)  //if not logged in
                Response.Redirect("/");

            try
            {
                dsInventory.Clear();
                daInventory.Fill(dsInventory.Inventory);
                daInvLookUp.Fill(dsInventory.InventoryLookUp);
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Failed to load data.";
                return;
            }

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
                nr[5] = Convert.ToDecimal(r.ItemArray[3]).ToString("C2");
                dt.Rows.Add(nr);
            }
            gvInventory.DataSource = dt;
            gvInventory.DataBind();
        }

        protected void gvInventory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;  //hide ID
            if (e.Row.RowIndex == -1)
            {
                e.Row.Cells[6].Text = String.Empty;
                //Clear the header for Detail Edit Delete btn
                return;  //skip the header
            }

            //edit btn
            HtmlAnchor btnEdit = new HtmlAnchor();
            btnEdit.Attributes.Add("type", "button");  //set as button
            btnEdit.Attributes.Add("class", "btn btn-dark");  //set css class
            btnEdit.Attributes.Add("aria-label", "Click to go to the edit page for this inventory entry");
            //set aria label
            btnEdit.InnerText = "Edit";  //set text
            btnEdit.HRef = "EditItem.aspx?ID=" + e.Row.Cells[0].Text;
            //redirect to edit page

            //delete btn
            HtmlAnchor btnDelete = new HtmlAnchor();
            btnDelete.Attributes.Add("type", "button");  //set as button
            btnDelete.Attributes.Add("class", "btn btn-danger");  //set css class
            btnDelete.Attributes.Add("aria-label", "Click to go to deleting confirmation page");
            //set aria label
            btnDelete.InnerText = "Delete";  //set text
            btnDelete.HRef = "DeleteItem.aspx?ID=" + e.Row.Cells[0].Text;
            //redirect to delete page

            if (!User.IsInRole("Admin"))
            {
                btnDelete.Visible = false;
                btnDelete.Attributes.Add("disabled", "disabled");
            }

            e.Row.Cells[6].Controls.Add(btnEdit);  //add the btn
            e.Row.Cells[6].Controls.Add(btnDelete);  //add the btn
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
                lblMessage.Text = "No Records Found";
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("/");
        }
    }

}