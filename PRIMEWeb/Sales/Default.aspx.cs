using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using PRIMELibrary;
using PRIMELibrary.SalesDataSetTableAdapters;

namespace PRIMEWeb.Sales
{
    public partial class Default : System.Web.UI.Page
    {
        private static SalesDataSet dsSales = new SalesDataSet();
        private DataRow[] rows;
        private static ReceiptTableAdapter daReceipt = new ReceiptTableAdapter();
        private static CustomerNameTableAdapter daCustomerNames = new CustomerNameTableAdapter();
        private static EmployeeNameTableAdapter daEmployeeNames = new EmployeeNameTableAdapter();
        private static OrderLineTableAdapter daOL = new OrderLineTableAdapter();
        private static ServiceOrderTableAdapter daServiceOrder = new ServiceOrderTableAdapter();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)  //if not logged in
                Response.Redirect("/");

            try
            {
                dsSales.Clear();
                daReceipt.Fill(dsSales.Receipt);
                daCustomerNames.Fill(dsSales.CustomerName);
                daEmployeeNames.Fill(dsSales.EmployeeName);
                daOL.Fill(dsSales.OrderLine);
                daServiceOrder.Fill(dsSales.ServiceOrder);
            }
            catch (Exception ex)
            {
                //prompt users the failure
                return;
            }

            //data loaded successfully

            rows = dsSales.Receipt.Select("", "ordDate DESC"); //get records
            DisplaySales();  //display records
            if (IsPostBack) return;
            DisplayCustomerList();
            DisplayEmployeeList();  //populate ddl
        }

        protected void gvSales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == -1)
            {
                e.Row.Cells[4].Text = String.Empty;
                //Clear the header for Detail Edit Delete btn
                return;  //skip the header
            }

            //status btn
            HtmlButton btnStatus = new HtmlButton();  //create status btn
            btnStatus.Attributes.Add("class", "btn btn-success");  //set css class
            btnStatus.Attributes.Add("value", e.Row.Cells[4].Text);  //record receiptID as value
            btnStatus.Attributes.Add("runat", "server");  //run at server
            btnStatus.ServerClick += new EventHandler(btnStatus_Click);  //click event handler

            if (e.Row.Cells[3].Text == "True")  //paid or not
            {
                btnStatus.InnerText = "Paid";

                if (!User.IsInRole("Admin"))
                {
                    btnStatus.Attributes.Add("disabled", "disabled");
                    btnStatus.Attributes.Add("aria-label", "Click to set this sale as unpaid");
                    //set aria label
                }
            }
            else
            {
                btnStatus.InnerText = "Pay";
                btnStatus.Attributes.Add("aria-label", "Click to set this sale as paid");
                //set aria label
            }
            e.Row.Cells[3].Controls.Add(btnStatus);  //add the btn

            //details btn
            HtmlAnchor btnDetail = new HtmlAnchor();
            btnDetail.Attributes.Add("type", "button");  //set as button
            btnDetail.Attributes.Add("class", "btn btn-info");  //set css class
            btnDetail.Attributes.Add("aria-label", "Click to go to the detail page for this sale");
            //set aria label
            btnDetail.InnerText = "Detail";  //set text
            btnDetail.HRef = "SaleRecord.aspx?ID=" + e.Row.Cells[4].Text;
            //redirect to details page

            //edit btn
            HtmlAnchor btnEdit = new HtmlAnchor();
            btnEdit.Attributes.Add("type", "button");  //set as button
            btnEdit.Attributes.Add("class", "btn btn-dark");  //set css class
            btnEdit.Attributes.Add("aria-label", "Click to go to the edit page for this sale");
            //set aria label
            btnEdit.InnerText = "Edit";  //set text
            btnEdit.HRef = "SalesUpdate.aspx?Mode=Edit&ID=" + e.Row.Cells[4].Text;
            //redirect to edit page

            //delete btn
            HtmlAnchor btnDelete = new HtmlAnchor();
            btnDelete.Attributes.Add("type", "button");  //set as button
            btnDelete.Attributes.Add("class", "btn btn-danger");  //set css class
            btnDelete.Attributes.Add("aria-label", "Click to go to deleting confirmation page");
                //set aria label
            btnDelete.InnerText = "Delete";  //set text
            btnDelete.HRef = "SaleRecord.aspx?ID=" + e.Row.Cells[4].Text + "&Delete=1";
                //redirect to delete page
                
            if (!User.IsInRole("Admin"))
            {
                btnDelete.Visible = false;
                btnDelete.Attributes.Add("disabled", "disabled");
            }

            e.Row.Cells[4].Controls.Add(btnDetail);  //add the btn
            e.Row.Cells[4].Controls.Add(btnEdit);  //add the btn
            e.Row.Cells[4].Controls.Add(btnDelete);  //add the btn
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> searchCmds = new List<string>(); //list of the filters
            if (txtSaleNum.Text != String.Empty)
                searchCmds.Add("id = " + txtSaleNum.Text);
            if (ddlCustomer.SelectedValue != "-1")
                searchCmds.Add("custID = " + ddlCustomer.SelectedValue);
            if (txtDate.Text != String.Empty)
                searchCmds.Add("ordDate = #" + txtDate.Text + "#");
            if (ddlEmployee.SelectedValue != "-1")
                searchCmds.Add("empID = " + ddlEmployee.SelectedValue);
            if (radPaid.Checked)
                searchCmds.Add("ordPaid = True");
            else if (radUnpaid.Checked)
                searchCmds.Add("ordPaid = False");
            //populate commands

            string cmd;

            if (searchCmds.Count == 0)
                rows = dsSales.Receipt.Select("", "ordDate DESC"); //get all records
            else
            {
                cmd = searchCmds[0];
                for (int i = 1; i < searchCmds.Count; i++)
                    cmd += " And " + searchCmds[i];
                rows = dsSales.Receipt.Select(cmd, "ordDate DESC"); //get needed records
            }

            DisplaySales();
        }

        protected void btnStatus_Click(object sender, EventArgs e)
        {
            HtmlButton btnStatus = (HtmlButton)sender;
            string receiptID = btnStatus.Attributes["value"];
            DataRow sale = dsSales.Receipt.Select("id = " + receiptID)[0];
            if (!(bool)sale.ItemArray[3])  //if not paid
            {
                sale["ordPaid"] = true;
                daReceipt.Update(dsSales.Receipt);
                dsSales.AcceptChanges();
            }
            else if (User.IsInRole("Admin"))
            {
                sale["ordPaid"] = false;
                daReceipt.Update(dsSales.Receipt);
                dsSales.AcceptChanges();
            }
            btnStatus.InnerText = "Paid";
            if (!User.IsInRole("Admin"))  //if not admin
                btnStatus.Attributes.Add("disabled", "disabled");
        }

        //helpers
        private void DisplayCustomerList()
        {
            ddlCustomer.Items.Clear();
            ddlCustomer.Items.Add(new ListItem("All Customers", "-1"));
            foreach (DataRow r in dsSales.CustomerName.Rows)
                ddlCustomer.Items.Add(new ListItem(r[1].ToString(), r[0].ToString()));
            ddlCustomer.SelectedIndex = 0; //select All Customers by default
        }

        private void DisplayEmployeeList()
        {
            ddlEmployee.Items.Clear();
            ddlEmployee.Items.Add(new ListItem("All Employees", "-1"));
            foreach (DataRow r in dsSales.EmployeeName.Rows)
                ddlEmployee.Items.Add(new ListItem(r[1].ToString(), r[0].ToString()));
            ddlEmployee.SelectedIndex = 0; //select All Employees by default
        }

        private void DisplaySales()
        {
            DataTable dtSales = new DataTable();
            dtSales.Columns.Add("Sale Number");
            dtSales.Columns.Add("Date");
            dtSales.Columns.Add("Customer");
            dtSales.Columns.Add("Status");
            dtSales.Columns.Add();  //Details Edit Delete

            foreach (DataRow r in rows)
            {
                dtSales.Rows.Add(r.ItemArray[1], ((DateTime)r.ItemArray[2]).ToShortDateString(),
                    r.GetParentRow("fk_receipt_custName")[1],
                    r.ItemArray[3], r.ItemArray[0]); //Sale#, Date, Name, Status, ID
            }
            gvSales.DataSource = dtSales;
            gvSales.DataBind();
            switch (gvSales.Rows.Count)
            {
                case 0:
                    lblCount.Text = "No records found.";
                    break;
                case 1:
                    lblCount.Text = "1 record found.";
                    break;
                default:
                    lblCount.Text = gvSales.Rows.Count.ToString() + " records found.";
                    break;
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