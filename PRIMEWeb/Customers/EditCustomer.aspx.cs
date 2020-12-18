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
    public partial class EditCustomer : System.Web.UI.Page
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
            }
            catch { return; }

            if (!IsPostBack)
            {
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
                            lblStatus.Text = "Please Try Again";
                        }
                    }
                    catch
                    {
                        lblStatus.Text = "Database Error";
                    }
                }
            }
        }

        //Edit Button click
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //check a record has been selected
            if (id != -1)
            {
                try
                {
                    //update record with user's input
                    dsCustomer.customer.FindByID(id).First = txtFName.Text.ToString();
                    dsCustomer.customer.FindByID(id).Last = txtLName.Text.ToString();
                    dsCustomer.customer.FindByID(id).Phone = txtPhone.Text.ToString();
                    dsCustomer.customer.FindByID(id).Address = txtAddress.Text.ToString();
                    dsCustomer.customer.FindByID(id).City = txtCity.Text.ToString();
                    dsCustomer.customer.FindByID(id).Postal = txtPCode.Text.ToString();
                    dsCustomer.customer.FindByID(id).Email = txtEmail.Text.ToString();
                    Save();
                }
                catch { lblStatus.Text = "Unable to Update Record"; }
            }
        }

        private void Save()
        {
            try
            {
                customerTableAdapter daCustomer = new customerTableAdapter();
                daCustomer.Update(dsCustomer.customer); // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
                dsCustomer.AcceptChanges(); // Call accept method on the dataset so it update the chanmges to the database
                lblStatus.Text = "Record Successfully Updated";
            }
            catch
            {
                dsCustomer.RejectChanges();
                lblStatus.Text = "Unable to Update Record";
            }
        }
        protected void cboHelp_CheckedChanged(object sender, EventArgs e)
        {
            lblAddressHelp.Visible = lblCityHelp.Visible = lblEmailHelp.Visible =
                lblFirstlHelp.Visible = lblLastHelp.Visible = lblPhoneHelp.Visible = lblIdHelp.Visible =
                lblPostalHelp.Visible = pnlCustomerHelp.Visible = cboHelp.Checked;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("/");
        }
    }
}