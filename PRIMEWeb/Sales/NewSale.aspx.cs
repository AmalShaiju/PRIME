using PRIMELibrary;
using PRIMELibrary.SalesDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PRIMEWeb.Sales
{
    public struct Order
    {
        public int productID, qty;
        public string note;
    }

    public partial class NewSale : System.Web.UI.Page
    {
        private static SalesDataSet dsSales = new SalesDataSet();
        private static bool flag = false; //indicate if the data loading failed

        static NewSale()
        {
            try
            {
                CustomerNameTableAdapter daCustomerNames = new CustomerNameTableAdapter();
                PaymentTableAdapter daPayments = new PaymentTableAdapter();
                EmployeeNameTableAdapter daEmployeeNames = new EmployeeNameTableAdapter();
                ProductTableAdapter daProducts = new ProductTableAdapter();
                InventoryTableAdapter daInventories = new InventoryTableAdapter();
                dsSales.Clear();
                daCustomerNames.Fill(dsSales.CustomerName);
                daPayments.Fill(dsSales.Payment);
                daEmployeeNames.Fill(dsSales.EmployeeName);
                daProducts.Fill(dsSales.Product);
                daInventories.Fill(dsSales.Inventory);
            }
            catch (Exception ex)
            {
                flag = true; //loading failed
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            txtDate.Text = DateTime.Today.ToShortDateString();

            DisplayCustomerList();
            DisplayPaymentList();
            DisplayEmployeeList();
            DisplayProductList();  //populate ddl

            Session["orders"] = new List<Order>();
        }

        private void DisplayCustomerList()
        {
            ddlCustomer.Items.Clear();
            ddlCustomer.Items.Add(new ListItem("Select a Customer", "-1"));
            foreach (DataRow r in dsSales.CustomerName.Rows)
                ddlCustomer.Items.Add(new ListItem(r[1].ToString(), r[0].ToString()));
            ddlCustomer.SelectedIndex = 0; //make Select a Customer as default
        }

        private void DisplayPaymentList()
        {
            ddlPayment.Items.Clear();
            ddlPayment.Items.Add(new ListItem("Select a Payment Method"));
            foreach (DataRow r in dsSales.Payment.Rows)
                ddlPayment.Items.Add(new ListItem(r[1].ToString(), r[0].ToString()));
            ddlPayment.SelectedIndex = 0; //make Select a Payment Method as default
        }

        private void DisplayEmployeeList()
        {
            ddlEmployee.Items.Clear();
            foreach (DataRow r in dsSales.EmployeeName.Rows)
                ddlEmployee.Items.Add(new ListItem(r[1].ToString(), r[0].ToString()));

            ddlEmployee.SelectedIndex = 0; //change this code after login applied
            //select the employee who's currently logged in
        }

        private void DisplayProductList()
        {
            ddlProduct.Items.Clear();
            ddlProduct.Items.Add(new ListItem("Select a Product", "-1"));
            foreach (DataRow r in dsSales.Product.Rows)
                ddlProduct.Items.Add(
                    new ListItem(r[1].ToString() + " (" + r[3].ToString() + ")",
                        r[0].ToString())
                );
            ddlProduct.SelectedIndex = 0; //make Select a Product as default
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsbOrders.SelectedIndex = -1;
            if (ddlProduct.SelectedValue == "-1")
                txtPrice.Text = txtStock.Text = String.Empty;
            else
            {
                DataRow[] inv = dsSales.Inventory.Select("productID = " + ddlProduct.SelectedValue);
                txtPrice.Text = "Price: " + Convert.ToDecimal(inv[0].ItemArray[4]).ToString("C2");
                txtStock.Text = "Number in Stock: " + inv[0].ItemArray[1].ToString();
            }
        }

        protected void btnAddOrder_Click(object sender, EventArgs e)
        {
            int productID = Convert.ToInt32(ddlProduct.SelectedValue);
            if (productID == -1)
            {
                //prompt user to select a product
                return;
            }

            List<Order> orders = (List<Order>)Session["orders"];  //get saved orders
            int qty = Convert.ToInt32(txtQty.Text);  //quantity needed

            Order order;
            order.productID = productID;
            order.qty = qty;
            order.note = txtNote.Text;
            orders.Add(order);
            lsbOrders.Items.Add(
                new ListItem(ddlProduct.SelectedItem.Text + " x" + txtQty.Text +
                    " - Note: " + txtNote.Text)
            );


            /*
            DataRow[] inv = dsSales.Inventory.Select("productID = " + ddlProduct.SelectedValue);
            DataRow order = dsSales.OrderLine.NewRow();
            int qty = Convert.ToInt32(txtQty.Text);
            int stock = Convert.ToInt32(inv[0].ItemArray[1]);
            double price = Convert.ToDouble(inv[0].ItemArray[4]);
            
            if (qty <= stock)
            {
                order.ItemArray[1] = price * qty * 1.11;  //price +10% +1%
                order.ItemArray[2] = qty;  //quantity
                order.ItemArray[3] = 0;  //not new order
                order.ItemArray[4] = txtNote.Text;  //note
                order.ItemArray[5] = Convert.ToInt32(inv[0].ItemArray[0]);  //inventoryID
                order.ItemArray[6] = -1;  //receiptID
                orders.Add(lsbOrders.Items.Count, order);  //save order
                lsbOrders.Items.Add(new ListItem(ddlProduct.SelectedItem.Text + " x" + txtQty.Text));
                //add to listbox
            }
            else
            {
                order.ItemArray[1] = price * stock * 1.11;  //price (in stock part) +10% +1%
                order.ItemArray[2] = stock;  //quantity (in stock part)
                order.ItemArray[3] = false;  //in stock part
                order.ItemArray[4] = txtNote.Text + " (In Stock)";  //note
                order.ItemArray[5] = Convert.ToInt32(inv[0].ItemArray[0]);  //inventoryID
                orders.Add(lsbOrders.Items.Count, order);  //save order (in stock part)
                lsbOrders.Items.Add(new ListItem(
                    ddlProduct.SelectedItem.Text + " x" + stock.ToString() + " (In Stock)")
                );  //add to listbox

                DataRow orderNew = dsSales.OrderLine.NewRow();
                orderNew.ItemArray[1] = price * (stock - qty) * 1.01;  //price (Order New part) +1%
                orderNew.ItemArray[2] = stock - qty;  //quantity (Order New part)
                orderNew.ItemArray[3] = true;  //Order New part
                orderNew.ItemArray[4] = txtNote.Text + " (Order New)";  //note
                orderNew.ItemArray[5] = Convert.ToInt32(inv[0].ItemArray[0]);  //inventoryID
                orders.Add(lsbOrders.Items.Count, orderNew);  //save order (Order New part)
                lsbOrders.Items.Add(new ListItem(
                    ddlProduct.SelectedItem.Text + " x" + (stock - qty).ToString() + " (Order New)")
                );  //add to listbox
            }
            */

            ddlProduct.SelectedIndex = 0;
            lsbOrders.SelectedIndex = -1;
            txtQty.Text = txtNote.Text = txtPrice.Text = txtStock.Text = String.Empty;
        }

        protected void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (lsbOrders.SelectedIndex == -1)
            {
                //prompt user
                return;
            }
            List<Order> orders = (List<Order>)Session["orders"];  //get saved orders
            orders.RemoveAt(lsbOrders.SelectedIndex);  //remove the record
            lsbOrders.Items.RemoveAt(lsbOrders.SelectedIndex);  //remove the entry
        }

        protected void cboHelp_CheckedChanged(object sender, EventArgs e)
        {
            lblCustomerHelp.Visible = lblDateHelp.Visible = lblEmployeeHelp.Visible =
                lblNoteHelp.Visible = lblPaymentHelp.Visible = lblPriceHelp.Visible =
                lblProductHelp.Visible = lblQtyHelp.Visible = lblStockHelp.Visible =
                pnlOrdersHelp.Visible = cboHelp.Checked;
        }
    }
}