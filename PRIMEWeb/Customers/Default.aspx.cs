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

        static Default()
        {
            dsCustomer = new CustomerDataSet();
            customerTableAdapter daCustomer = new customerTableAdapter();
            //customerTableAdapter daCustomer = new customerTableAdapter();
            //manufacturerTableAdapter daManufacturer = new manufacturerTableAdapter();
            //equip_typeTableAdapter daType = new equip_typeTableAdapter();

            try
            {
                daCustomer.Fill(dsCustomer.customer);
                //daCustomer.Fill(dsEquipment.customer);
                //daManufacturer.Fill(dsEquipment.manufacturer);
                //daType.Fill(dsEquipment.equip_type);
            }
            catch { }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Full Name");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Address");
            dt.Columns.Add("City");
            dt.Columns.Add("Postal");
            dt.Columns.Add("Email"); 

            foreach (DataRow r in dsCustomer.customer)
            {
                DataRow record = dt.NewRow();
                record[0] = r.ItemArray[1].ToString() + ' ' + r.ItemArray[2].ToString();
                record[1] = r.ItemArray[3].ToString();
                record[2] = r.ItemArray[4].ToString();
                record[3] = r.ItemArray[5].ToString();
                record[4] = r.ItemArray[6].ToString();
                record[5] = r.ItemArray[7].ToString();
                dt.Rows.Add(record);
            }

            this.gvCustomers.DataSource = dt;
            this.gvCustomers.DataBind();
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
            dt.Columns.Add("Address");
            dt.Columns.Add("City");
            dt.Columns.Add("Postal");
            dt.Columns.Add("Email");

            foreach (DataRow r in rows)
            {
                DataRow record = dt.NewRow();
                record[0] = r.ItemArray[1].ToString() + ' ' + r.ItemArray[2].ToString();
                record[1] = r.ItemArray[3].ToString();
                record[2] = r.ItemArray[4].ToString();
                record[3] = r.ItemArray[5].ToString();
                record[4] = r.ItemArray[6].ToString();
                record[5] = r.ItemArray[7].ToString();
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
    }
}