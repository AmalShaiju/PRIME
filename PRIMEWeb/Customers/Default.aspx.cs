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
            dt.Columns.Add("Full Name");
            dt.Columns.Add("Phone");
            dt.Columns.Add("City");
            dt.Columns.Add("Email");
            dt.Columns.Add();

            foreach (DataRow r in rows)
            {
                DataRow record = dt.NewRow();
                record[0] = r.ItemArray[1].ToString() + ' ' + r.ItemArray[2].ToString();
                record[1] = r.ItemArray[3].ToString();
                record[2] = r.ItemArray[5].ToString();
                record[3] = r.ItemArray[7].ToString();
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
                e.Row.Cells[4].Text = String.Empty;
                //Clear the header for Edit btn
                return;  //skip the header
            }

            //details btn
            Button btnDetail = new Button();  //create detail btn
            btnDetails.Add(btnDetail);  //the list index of the button will also be the row index
            btnDetail.CssClass = "btn btn-info";  //set css class
            btnDetail.Text = "Detail";
            btnDetail.Attributes.Add("aria-label", "Click to go to the detail page for this sale");
            //set aria label
            btnDetail.Attributes.Add("OnClick", "btnDetail_Click");  //click event handler
            e.Row.Cells[4].Controls.Add(btnDetail);  //add the btn

            //edit btn
            Button btnEdit = new Button();  //create edit btn
            btnEdits.Add(btnEdit);  //the list index of the button will also be the row index
            btnEdit.CssClass = "btn btn-dark";  //set css class
            btnEdit.Text = "Edit";
            btnEdit.Attributes.Add("aria-label", "Click to go to the edit page for this sale");
            //set aria label
            btnEdit.Attributes.Add("OnClick", "btnEdit_Click");  //click event handler
            e.Row.Cells[4].Controls.Add(btnEdit);  //add the btn

            //delete btn
            Button btnDelete = new Button();  //create delete btn
            btnDeletes.Add(btnDelete);  //the list index of the button will also be the row index
            btnDelete.CssClass = "btn btn-danger";  //set css class
            btnDelete.Text = "Delete";
            btnDelete.Attributes.Add("aria-label", "Click to delete this sale");
            //set aria label
            btnDelete.Attributes.Add("OnClick", "btnDelete_Click");  //click event handler

            ////if (not admin)
            //btnDelete.Visible = false;
            //btnDelete.Enabled = false;

            e.Row.Cells[4].Controls.Add(btnDelete);  //add the btn

            e.Row.Cells[4].Attributes["width"] = "295px";
        }
    }
}