using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRIMELibrary.CustomerDataSetTableAdapters;
using PRIMELibrary;
using System.Data;
using System.Web.UI.HtmlControls;

namespace PRIMEWeb.Customers
{
    public partial class Default : System.Web.UI.Page
    {
        private static CustomerDataSet dsCustomer;
        private static DataRow[] rows;
        private static int id = -1;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)  //if not logged in
                Response.Redirect("/");

            try
            {
                dsCustomer = new CustomerDataSet();
                customerTableAdapter daCustomer = new customerTableAdapter();
                daCustomer.Fill(dsCustomer.customer);
                rows = (Session["criteria"] != null) ? dsCustomer.customer.Select(Session["criteria"].ToString()) : dsCustomer.customer.Select();
                DisplayCustomer();
            }
            catch
            {

            }
            //data loaded successfully
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (dsCustomer.customer.Count > 0)
            {
                Session["criteria"] = GetCustomerCriteria();
                rows = (Session["criteria"] != null) ? dsCustomer.customer.Select(Session["criteria"].ToString()) : dsCustomer.customer.Select();
                DisplayCustomer();
            }
            else
                this.lblStatus.Text = "No Customer Records";
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
            HtmlButton btnDetail = new HtmlButton();  //create detail btn
            btnDetail.Attributes.Add("class", "btn btn-info");  //set css class
            btnDetail.InnerText = "Detail";
            btnDetail.Attributes.Add("value", e.Row.Cells[0].Text);
            btnDetail.Attributes.Add("aria-label", "Click to go to the detail page for this sale"); //set aria label
            btnDetail.ServerClick += new EventHandler(btnDetail_Click);  //click event handler
            e.Row.Cells[5].Controls.Add(btnDetail);  //add the btn

            //edit btn
            HtmlButton btnEdit = new HtmlButton();  //create edit btn
            btnEdit.Attributes.Add("class", "btn btn-dark");  //set css class
            btnEdit.InnerText = "Edit";
            btnEdit.Attributes.Add("value", e.Row.Cells[0].Text);
            btnEdit.Attributes.Add("aria-label", "Click to go to the edit page for this sale"); //set aria label
            btnEdit.ServerClick += new EventHandler(btnEdit_Click);  //click event handler
            e.Row.Cells[5].Controls.Add(btnEdit);  //add the btn

            //delete btn

            HtmlButton btnDelete = new HtmlButton();  //create delete btn
            btnDelete.Attributes.Add("class", "btn btn-danger");  //set css class
            btnDelete.InnerText = "Delete";
            btnDelete.Attributes.Add("value", e.Row.Cells[0].Text);
            btnDelete.Attributes.Add("aria-label", "Click to delete this sale"); //set aria label
            btnDelete.ServerClick += new EventHandler(btnDelete_Click);  //click event handler
            e.Row.Cells[5].Controls.Add(btnDelete);  //add the btn
        }

        //Delete btn
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            HtmlButton btnDelete = (HtmlButton)sender;
            id = Convert.ToInt32(btnDelete.Attributes["value"]);
            if (id != -1)
            {
                //Send Id using cookie, more seecure I presume
                HttpCookie cID = new HttpCookie("ID"); // Cokkie variable named cID to hold a value 
                cID.Value = id.ToString();

                HttpCookie action = new HttpCookie("Action"); // Cokkie variable named cID to hold a value 
                action.Value = "Delete";
                
                Response.Cookies.Add(action);
                Response.Cookies.Add(cID);
                Response.Redirect("DetailsCustomer.aspx"); // Redirect the user to Edit page on btn click
            }
        }

        // Edit btn 
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            HtmlButton btnDelete = (HtmlButton)sender;
            id = Convert.ToInt32(btnDelete.Attributes["value"]);
            if (id != -1)
            {
                //Send Id using cookie, more seecure I presume
                HttpCookie cID = new HttpCookie("ID"); // Cokkie variable named cID to hold a value 
                cID.Value = id.ToString();
                Response.Cookies.Add(cID);
                Response.Redirect("EditCustomer.aspx"); // Redirect the user to Edit page on btn click
            }
        }

        // Details btn 
        protected void btnDetail_Click(object sender, EventArgs e)
        {
            HtmlButton btnDelete = (HtmlButton)sender;
            id = Convert.ToInt32(btnDelete.Attributes["value"]);
            if (id != -1)
            {
                //Send Id using cookie, more seecure I presume
                HttpCookie cID = new HttpCookie("ID"); // Cokkie variable named cID to hold a value 
                cID.Value = id.ToString();

                HttpCookie action = new HttpCookie("Action"); // Cokkie variable named cID to hold a value 
                action.Value = "Details";

                Response.Cookies.Add(action);
                Response.Cookies.Add(cID);
                Response.Redirect("DetailsCustomer.aspx"); // Redirect the user to Edit page on btn click
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