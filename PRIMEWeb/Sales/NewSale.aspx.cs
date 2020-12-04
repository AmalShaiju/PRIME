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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CustomerNameTableAdapter daCustomerNames = new CustomerNameTableAdapter();
                PaymentTableAdapter daPayments = new PaymentTableAdapter();
                EmployeeNameTableAdapter daEmployeeNames = new EmployeeNameTableAdapter();
                ProductTableAdapter daProducts = new ProductTableAdapter();
                InventoryTableAdapter daInventories = new InventoryTableAdapter();
                ReceiptTableAdapter daReceipts = new ReceiptTableAdapter();
                OrderLineTableAdapter daOL = new OrderLineTableAdapter();
                dsSales.Clear();
                daCustomerNames.Fill(dsSales.CustomerName);
                daPayments.Fill(dsSales.Payment);
                daEmployeeNames.Fill(dsSales.EmployeeName);
                daProducts.Fill(dsSales.Product);
                daInventories.Fill(dsSales.Inventory);
                daReceipts.Fill(dsSales.Receipt);
                daOL.Fill(dsSales.OrderLine);
            }
            catch (Exception ex)
            {
                //prompt data load failure
                return;
            }

            if (IsPostBack) return;
            txtDate.Text = DateTime.Today.ToShortDateString();

            DisplayCustomerList();
            DisplayPaymentList();
            DisplayEmployeeList();
            DisplayProductList();  //populate ddl

            Session["orders"] = new List<Order>();  //init
        }

        protected void cboHelp_CheckedChanged(object sender, EventArgs e)
        {
            lblCustomerHelp.Visible = lblDateHelp.Visible = lblEmployeeHelp.Visible =
                lblNoteHelp.Visible = lblPaymentHelp.Visible = lblPriceHelp.Visible =
                lblProductHelp.Visible = lblQtyHelp.Visible = lblStockHelp.Visible =
                pnlOrdersHelp.Visible = cboHelp.Checked;
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsbOrders.SelectedIndex = -1;
            if (ddlProduct.SelectedValue == "")
                txtPrice.Text = txtStock.Text = String.Empty;
            else
            {
                DataRow[] inv = dsSales.Inventory.Select("productID = " + ddlProduct.SelectedValue);
                txtPrice.Text = "Price: " + Convert.ToDecimal(inv[0].ItemArray[4]).ToString("C2");
                txtStock.Text = "Number in Stock: " + inv[0].ItemArray[1].ToString();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (ddlCustomer.SelectedValue == "")
            {
                //prompt user to select customer
                return;
            }

            if (ddlPayment.SelectedValue == "")
            {
                //prompt user to select payment method
                return;
            }

            List<Order> orders = (List<Order>)Session["orders"];  //get saved orders

            if (orders.Count == 0)
            {
                //prompt user to add orders
                return;
            }

            DataRow sale = dsSales.Receipt.NewRow();
            sale["ordNumber"] = dsSales.Receipt.Rows.Count + 1;
            sale["ordDate"] = txtDate.Text;
            sale["ordPaid"] = false;
            sale["paymentID"] = ddlPayment.SelectedValue;
            sale["custID"] = ddlCustomer.SelectedValue;
            sale["empID"] = ddlEmployee.SelectedValue;

            dsSales.Receipt.Rows.Add(sale);
            new ReceiptTableAdapter().Update(dsSales.Receipt);
            dsSales.AcceptChanges();

            foreach (Order order in orders)
            {
                DataRow nrOrder = dsSales.OrderLine.NewRow();
                OrderLineTableAdapter daOL = new OrderLineTableAdapter();
                InventoryTableAdapter daInventory = new InventoryTableAdapter();
                DataRow inv = dsSales.Inventory.Select("productID = " + order.productID)[0];
                int stock = Convert.ToInt32(inv.ItemArray[1]);
                double invPrice = Convert.ToDouble(inv.ItemArray[4]);
                int inventoryID = Convert.ToInt32(inv.ItemArray[0]);

                if (order.qty <= stock)
                {
                    nrOrder["orlPrice"] = invPrice * order.qty * 1.11;  //price +10% +1%
                    nrOrder["orlQuantity"] = order.qty;  //quantity
                    nrOrder["orlOrderReq"] = false;  //not new order
                    nrOrder["orlNote"] = order.note;  //note
                    nrOrder["inventoryID"] = inventoryID;  //inventoryID
                    nrOrder["receiptID"] = sale.ItemArray[0];  //receiptID

                    //update orderline
                    dsSales.OrderLine.Rows.Add(nrOrder);
                    daOL.Update(dsSales.OrderLine);
                    //update inventory
                    inv["invQuantity"] = stock - order.qty;
                    daInventory.Update(dsSales.Inventory);
                    dsSales.AcceptChanges();
                }
                else
                {
                    //in stock part
                    nrOrder["orlPrice"] = invPrice * stock * 1.11;  //price (in stock part) +10% +1%
                    nrOrder["orlQuantity"] = stock;  //quantity (in stock part)
                    nrOrder["orlOrderReq"] = false;  //in stock part
                    nrOrder["orlNote"] = order.note + " (In Stock)";  //note
                    nrOrder["inventoryID"] = inventoryID;  //inventoryID
                    nrOrder["receiptID"] = sale.ItemArray[0];  //receiptID

                    //update db
                    dsSales.OrderLine.Rows.Add(nrOrder);

                    //Order New part
                    DataRow orderNew = dsSales.OrderLine.NewRow();
                    orderNew["orlPrice"] = invPrice * (order.qty - stock) * 1.01;  //price (Order New part) +1%
                    orderNew["orlQuantity"] = order.qty - stock;  //quantity (Order New part)
                    orderNew["orlOrderReq"] = true;  //Order New part
                    orderNew["orlNote"] = order.note + " (Order New)";  //note
                    orderNew["inventoryID"] = inventoryID;  //inventoryID
                    orderNew["receiptID"] = sale.ItemArray[0];  //receiptID

                    //update orderline
                    dsSales.OrderLine.Rows.Add(orderNew);
                    daOL.Update(dsSales.OrderLine);
                    //update inventory
                    inv["invQuantity"] = 0;
                    daInventory.Update(dsSales.Inventory);
                    dsSales.AcceptChanges();
                }
            }
        }

        protected void btnAddOrder_Click(object sender, EventArgs e)
        {
            if (ddlProduct.SelectedValue == "")
            {
                //prompt user to select a product
                return;
            }

            List<Order> orders = (List<Order>)Session["orders"];  //get saved orders
            //get inventory record

            Order order;
            order.productID = Convert.ToInt32(ddlProduct.SelectedValue);
            order.qty = Convert.ToInt32(txtQty.Text);
            order.note = txtNote.Text;
            orders.Add(order);  //save order
            lsbOrders.Items.Add(
                new ListItem(ddlProduct.SelectedItem.Text + " x" + txtQty.Text +
                    " - Note: " + txtNote.Text)
            );  //add to list box

            //reset form
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

        protected void btnClearOrder_Click(object sender, EventArgs e)
        {
            ddlProduct.SelectedIndex = 0;
            txtQty.Text = txtNote.Text = txtPrice.Text = txtStock.Text = String.Empty;
        }


        //helpers
        private void DisplayCustomerList()
        {
            ddlCustomer.Items.Clear();
            ddlCustomer.Items.Add(new ListItem("Select a Customer", ""));
            foreach (DataRow r in dsSales.CustomerName.Rows)
                ddlCustomer.Items.Add(new ListItem(r[1].ToString(), r[0].ToString()));
            ddlCustomer.SelectedIndex = 0; //make Select a Customer as default
        }

        private void DisplayPaymentList()
        {
            ddlPayment.Items.Clear();
            ddlPayment.Items.Add(new ListItem("Select a Payment Method", ""));
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
            ddlProduct.Items.Add(new ListItem("Select a Product", ""));
            foreach (DataRow r in dsSales.Product.Rows)
                ddlProduct.Items.Add(
                    new ListItem(r[1].ToString() + " (" + r[3].ToString() + ")",
                        r[0].ToString())
                );
            ddlProduct.SelectedIndex = 0; //make Select a Product as default
        }
    }
}