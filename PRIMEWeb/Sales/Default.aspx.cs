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

                //if (not admin)
                btnStatus.Attributes.Add("disabled", "disabled");
                btnStatus.Attributes.Add("aria-label", "Click to set this sale as unpaid");
                //set aria label
            }
            else
            {
                btnStatus.InnerText = "Pay";
                btnStatus.Attributes.Add("aria-label", "Click to set this sale as paid");
                //set aria label
            }
            e.Row.Cells[3].Controls.Add(btnStatus);  //add the btn

            //details btn
            Button btnDetail = new Button();  //create detail btn
            btnDetail.CssClass = "btn btn-info";  //set css class
            btnDetail.Text = "Detail";
            btnDetail.Attributes.Add("aria-label", "Click to go to the detail page for this sale");
                //set aria label
            btnDetail.Attributes.Add("OnClick", "btnDetail_Click");  //click event handler

            //edit btn
            Button btnEdit = new Button();  //create edit btn
            btnEdit.CssClass = "btn btn-dark";  //set css class
            btnEdit.Text = "Edit";
            btnEdit.Attributes.Add("aria-label", "Click to go to the edit page for this sale");
                //set aria label
            btnEdit.Attributes.Add("OnClick", "btnEdit_Click");  //click event handler

            //delete btn
            HtmlButton btnDelete = new HtmlButton();  //create delete btn
            btnDelete.Attributes.Add("class", "btn btn-danger");  //set css class
            btnDelete.Attributes.Add("value", e.Row.Cells[4].Text);  //record receiptID as value
            btnDelete.Attributes.Add("runat", "server");  //run at server
            btnDelete.Attributes.Add("data-toggle", "modal");  //set data toggle
            btnDelete.Attributes.Add("data-target", "#deleteModal");  //set data target
            btnDelete.Attributes.Add("aria-label", "Click to display the confirmation window");
                //set aria label
            btnDelete.InnerText = "Delete";
            btnDelete.ServerClick += new EventHandler(btnDelete_ServerClick);  //click event handler

            /*
            //if (not admin)
            btnDelete.Visible = false;
            btnDelete.Attributes.Add("disabled", "disabled");
            */

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
            btnStatus.InnerText = "Paid";
            //if not admin
            btnStatus.Attributes.Add("disabled", "disabled");
        }

        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
            lblReceiptID.Text = ((HtmlButton)sender).Attributes["value"];
        }

        protected void btnDeleteConfirm_Click(object sender, EventArgs e)
        {
            DataRow sale = dsSales.Receipt.Select("id = " + lblReceiptID.Text)[0];
            DataRow[] orders = sale.GetChildRows("fk_orderline_receipt");
            DataRow[] repairs = sale.GetChildRows("fk_serord_receipt");
            foreach (DataRow o in orders)
                o.Delete();
            foreach (DataRow r in repairs)
                r.Delete();
            daOL.Update(dsSales.OrderLine);
            daServiceOrder.Update(dsSales.ServiceOrder);
            sale.Delete();
            daReceipt.Update(dsSales.Receipt);
            dsSales.AcceptChanges();
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
    }
}