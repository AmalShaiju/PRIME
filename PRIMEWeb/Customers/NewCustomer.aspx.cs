using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRIMELibrary;
using PRIMELibrary.CustomerDataSetTableAdapters;
using System.Data;

namespace PRIMEWeb.Customers
{
    public partial class NewCustomer : System.Web.UI.Page
    {
        static CustomerDataSet dsCustomer = new CustomerDataSet();

        static NewCustomer()
        {
            customerTableAdapter daCustomer = new customerTableAdapter();

            try
            {
                daCustomer.Fill(dsCustomer.customer);
            }
            catch { }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)  //if not logged in
                Response.Redirect("/");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            DataRow customer = dsCustomer.customer.NewRow();

            //update record with user's input
            customer[1] = this.txtFName.Text;
            customer[2] = this.txtLName.Text;
            customer[3] = Convert.ToInt64(this.txtPhone.Text).ToString();
            customer[4] = this.txtAddress.Text;
            customer[5] = this.txtCity.Text;
            customer[6] = this.txtPCode.Text;
            customer[7] = this.txtEmail.Text;
            dsCustomer.customer.Rows.Add(customer);
            Save();
        }
        private void Save()
        {
            customerTableAdapter daCustomer = new customerTableAdapter();

            try
            {
                daCustomer.Update(dsCustomer.customer);
                dsCustomer.AcceptChanges();
                this.lblStatus.Text = "Customer Created";
                Clear();
            }
            catch
            {
                dsCustomer.RejectChanges();
                this.lblStatus.Text = "Failed";
            }
        }

        private void Clear()
        {
            this.txtFName.Text = "";
            this.txtLName.Text = "";
            this.txtPCode.Text = "";
            this.txtPhone.Text = "";
            this.txtCity.Text = "";
            this.txtAddress.Text = "";
            this.txtEmail.Text = "";
        }
        protected void cboHelp_CheckedChanged(object sender, EventArgs e)
        {
            lblAddressHelp.Visible = lblCityHelp.Visible = lblEmailHelp.Visible =
                lblFirstlHelp.Visible = lblLastHelp.Visible = lblPhoneHelp.Visible =
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