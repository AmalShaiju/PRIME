using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRIMELibrary.CustomerDataSetTableAdapters;
using PRIMELibrary;
using System.Data;

namespace PRIMEWeb.Customers
{
    public partial class Default : System.Web.UI.Page
    {
        private static CustomerDataSet dsCustomer;
        private static DataRow[] rows;
        private static bool flag = false; //indicate if the data loading failed
        private static List<Button> btnEdits = new List<Button>(); //list of the edit btns
        private static List<Button> btnDeletes = new List<Button>(); //list of the delete btns
        private static List<Button> btnDetails = new List<Button>(); //list of the detail btns
        private static int id = -1;
        static Default()
        {
            try
            {
                dsCustomer = new CustomerDataSet();
                customerTableAdapter daCustomer = new customerTableAdapter();
                daCustomer.Fill(dsCustomer.customer);
            }
            catch 
            {
                flag = true; //loading failed
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (flag)
            {
                return;
            }

            //data loaded successfully

            rows = dsCustomer.customer.Select(); //get records
            DisplayCustomer();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (dsCustomer.customer.Count > 0)
            {
                string criteria = GetCustomerCriteria();
                rows = (criteria.Length > 0) ? dsCustomer.customer.Select(criteria) : dsCustomer.customer.Select();
                DisplayCustomer();
            }
            else
                this.lblStatus.Text = "No Customer Records";
            this.lblSave.Text = "Ready";
        }

        //display
        private void DisplayCustomer()
        {
            this.gvCustomers.DataSource = null;
            this.gvCustomers.DataBind();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Full Name");
            dt.Columns.Add("Phone");
            dt.Columns.Add("City");
            dt.Columns.Add("Email");
            dt.Columns.Add();

            foreach (DataRow r in rows)
            {
                DataRow record = dt.NewRow();
                record[0] = r.ItemArray[0].ToString();
                record[1] = r.ItemArray[1].ToString() + ' ' + r.ItemArray[2].ToString();
                record[2] = r.ItemArray[3].ToString();
                record[3] = r.ItemArray[5].ToString();
                record[4] = r.ItemArray[7].ToString();
                dt.Rows.Add(record);
            }

            this.gvCustomers.DataSource = dt;
            this.gvCustomers.DataBind();

            lblStatus.Text = "Search Results: " + ((rows.Length > 0) ? rows.Length.ToString() : "0");
        }

        //criteria
        private string GetCustomerCriteria()
        {
            string criteria = "";
            criteria = (this.txtFName.Text.Length > 0) ? "First Like '%" + this.txtFName.Text + "%'" : "";
            criteria += (this.txtLName.Text.Length > 0 && criteria.Length > 0) ? "And Last Like '%" + this.txtLName.Text + "%'"
                : (this.txtLName.Text.Length > 0) ? "Last Like '%" + this.txtLName.Text + "%'" : "";
            criteria += (this.txtPhone.Text.Length > 0 && criteria.Length > 0) ? "And Phone Like '%" + this.txtPhone.Text + "%'"
                : (this.txtPhone.Text.Length > 0) ? "Phone Like '%" + this.txtPhone.Text + "%'" : "";
            criteria += (this.txtCity.Text.Length > 0 && criteria.Length > 0) ? "And City Like '%" + this.txtCity.Text + "%'"
                : (this.txtCity.Text.Length > 0) ? "City Like '%" + this.txtCity.Text + "%'" : "";
            criteria += (this.txtEmail.Text.Length > 0 && criteria.Length > 0) ? "And Email Like '%" + this.txtEmail.Text + "%'"
                : (this.txtEmail.Text.Length > 0) ? "Email Like '%" + this.txtEmail.Text + "%'" : "";
            return criteria;
        }

        protected void gvCustomers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == -1)
            {
                e.Row.Cells[5].Text = String.Empty;
                //Clear the header for Edit btn
                return;  //skip the header
            }

            //hiding id column
            this.gvCustomers.HeaderRow.Cells[0].Visible = false;
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[5].Attributes["width"] = "295px";

            //details btn
            Button btnDetail = new Button();  //create detail btn
            btnDetails.Add(btnDetail);  //the list index of the button will also be the row index
            btnDetail.CssClass = "btn btn-info";  //set css class
            btnDetail.Text = "Detail";
            btnDetail.Attributes.Add("aria-label", "Click to go to the detail page for this sale");
            //set aria label
            btnDetail.Click += new EventHandler(btnDetail_Click);  //click event handler
            e.Row.Cells[5].Controls.Add(btnDetail);  //add the btn

            //edit btn
            Button btnEdit = new Button();  //create edit btn
            btnEdits.Add(btnEdit);  //the list index of the button will also be the row index
            btnEdit.CssClass = "btn btn-dark";  //set css class
            btnEdit.Text = "Edit";
            btnEdit.Attributes.Add("aria-label", "Click to go to the edit page for this sale");
            //set aria label
            btnEdit.Click += new EventHandler(btnEdit_Click);  //click event handler
            e.Row.Cells[5].Controls.Add(btnEdit);  //add the btn

            //delete btn
            Button btnDelete = new Button();  //create delete btn
            btnDeletes.Add(btnDelete);  //the list index of the button will also be the row index
            btnDelete.CssClass = "btn btn-danger";  //set css class
            btnDelete.Text = "Delete";
            btnDelete.Attributes.Add("aria-label", "Click to delete this sale");
            //set aria label
            btnDelete.Click += new EventHandler(btnDelete_Click);  //click event handler

            e.Row.Cells[5].Controls.Add(btnDelete);  //add the btn

        }

        // Delete btn 
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            //Get rowindex
            int rowindex = gvr.RowIndex;

            this.lblSave.Text = rowindex.ToString();

            id = Convert.ToInt32(gvCustomers.Rows[rowindex].Cells[0].Text);

            if (id != -1)
            {
                try
                {
                    DataRow record = dsCustomer.customer.FindByID(id); // Find and add the record to tbe record variable
                    record.Delete(); // Deletes the record in memory

                    customerTableAdapter daCustomer = new customerTableAdapter(); // table adapter to service table (Service adapter)
                    daCustomer.Update(record); // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
                    dsCustomer.AcceptChanges(); // Call accept method on the dataset so it update the chanmges to the database
                    //Refresh the page to show the record being deleted
                    lblSave.Text = "Record deleted";
                    Response.Redirect(Request.RawUrl);
                }
                catch
                {
                    lblSave.Text = "Record not deleted";
                }
            }
        }

        // Edit btn 
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            // Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            //Get rowindex
            int rowindex = gvr.RowIndex;

            this.lblSave.Text = rowindex.ToString();

            // Not too secure sending value through query string
            //Response.Redirect("EditService.aspx?ID=" + GridView1.Rows[e.NewEditIndex].Cells[1].Text

            //Send Id using cookie, more seecure I presume
            HttpCookie cID = new HttpCookie("ID"); // Cokkie variable named cID to hold a value 
            cID.Value = this.gvCustomers.Rows[rowindex].Cells[0].Text;
            Response.Cookies.Add(cID);
            Response.Redirect("EditCustomer.aspx"); // Redirect the user to Edit page on btn click
        }

        // Details btn 
        protected void btnDetail_Click(object sender, EventArgs e)
        {
            // Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            //Get rowindex
            int rowindex = gvr.RowIndex;

            this.lblSave.Text = rowindex.ToString();

            // Not too secure sending value through query string
            //Response.Redirect("EditService.aspx?ID=" + GridView1.Rows[e.NewEditIndex].Cells[1].Text

            //Send Id using cookie, more seecure I presume
            HttpCookie cID = new HttpCookie("ID"); // Cokkie variable named cID to hold a value 
            cID.Value = this.gvCustomers.Rows[rowindex].Cells[0].Text;
            Response.Cookies.Add(cID);
            Response.Redirect("DetailsCustomer.aspx"); // Redirect the user to Edit page on btn click
        }
    }
}