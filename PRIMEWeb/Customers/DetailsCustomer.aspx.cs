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
    public partial class DetailsCustomer : System.Web.UI.Page
    {
        static CustomerDataSet dsCustomer;
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


                if (Request.Cookies["ID"] != null) // Request the cookies which contaions the ID Of thr record that was carried over from the index page
                    id = Convert.ToInt32(Request.Cookies["ID"].Value);
                if (Request.Cookies["Action"] != null && Request.Cookies["Action"].Value == "Delete")
                {
                    pnlDeleteConfirm.Visible = true;
                    lblTitle.Text = "Delete Customer";
                }
                else
                {
                    pnlDeleteConfirm.Visible = false;
                }
            }
            catch { return; }

            if (id != -1)
            {
                try
                {
                    DataRow customer = dsCustomer.customer.FindByID(id); // Find the related Record and fill the fields in the page with the data

                    if (customer != null)
                    {
                        this.txtID.Text = customer.ItemArray[0].ToString();
                        this.txtFName.Text = customer.ItemArray[1].ToString();
                        this.txtLName.Text = customer.ItemArray[2].ToString();
                        this.txtPhone.Text = customer.ItemArray[3].ToString();
                        this.txtAddress.Text = customer.ItemArray[4].ToString();
                        this.txtCity.Text = customer.ItemArray[5].ToString();
                        this.txtPCode.Text = customer.ItemArray[6].ToString();
                        this.txtEmail.Text = customer.ItemArray[7].ToString();
                    }
                    else
                    {
                        lblStatus.Text = "Record doesn't exist";
                    }
                }
                catch
                {
                    lblStatus.Text = "Database Error";
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                HttpCookie cID = new HttpCookie("ID"); // Cokkie variable named cID to hold a value 
                cID.Value = id.ToString();
                Response.Cookies.Add(cID);
                Response.Redirect("EditCustomer.aspx"); // Redirect the user to Edit page on btn click
            }
        }

        protected void btnDeleteConfirm_Click(object sender, EventArgs e)
        {
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
                    Response.Redirect("Default.aspx");
                }
                catch
                {
                    lblStatus.Text = "Delete failed. The customer has an equipment asigned.";
                }
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