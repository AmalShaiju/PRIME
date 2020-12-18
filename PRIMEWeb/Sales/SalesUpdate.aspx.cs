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

    public partial class SalesUpdate : System.Web.UI.Page
    {
        private static SalesDataSet dsSales = new SalesDataSet();
        private static CustomerNameTableAdapter daCustomerNames = new CustomerNameTableAdapter();
        private static PaymentTableAdapter daPayments = new PaymentTableAdapter();
        private static EmployeeNameTableAdapter daEmployeeNames = new EmployeeNameTableAdapter();
        private static ProductTableAdapter daProducts = new ProductTableAdapter();
        private static InventoryTableAdapter daInventories = new InventoryTableAdapter();
        private static ReceiptTableAdapter daReceipts = new ReceiptTableAdapter();
        private static OrderLineTableAdapter daOL = new OrderLineTableAdapter();
        private static InventoryTableAdapter daInventory = new InventoryTableAdapter();
        private bool edit = false;
        private string receiptID = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)  //if not logged in
                Response.Redirect("/");

            if (Request.QueryString["Mode"] == "Edit")
            {
                edit = true;
                receiptID = Request.QueryString["ID"];

                if (!User.IsInRole("Admin") && ddlEmployee.SelectedValue != User.Identity.Name)
                    Response.Redirect("SaleRecord.aspx?ID=" + receiptID);
                //if not admin nor creator, redirect to details

                lblTitle.Text = "Edit Sale";
                btnModify.Text = "Save Changes";
                btnModify.Attributes["aria-label"] = "Save changes made for this sale along with the orders";
            }

            ScriptManager.RegisterStartupScript(Page, GetType(), "UiFix", "setHeight();", true);
            //use js to resize listbox

            if (IsPostBack) return;

            try
            {
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
                //prompt
                return;
            }

            txtDate.Text = DateTime.Today.ToShortDateString();

            DisplayCustomerList(receiptID);
            DisplayPaymentList(receiptID);
            DisplayEmployeeList();
            DisplayProductList();  //populate ddl

            if (edit)
            {
                DataRow sale = dsSales.Receipt.FindByid(Convert.ToInt32(receiptID));
                txtDate.Text = Convert.ToDateTime(sale.ItemArray[2]).ToShortDateString();

                DataRow[] orders = sale.GetChildRows("fk_orderline_receipt");  //get orders

                lsbOrders.Items.Clear();
                foreach (DataRow o in orders)
                {
                    DataRow product = o.GetParentRow("fk_orderline_inventory")  //inventory
                        .GetParentRow("fk_inventory_product");
                    string noteAppended = (o.ItemArray[4] == null) ? String.Empty :
                                            " - Note: " + o.ItemArray[4].ToString();
                    lsbOrders.Items.Add(
                        new ListItem(product.ItemArray[1].ToString() +
                                " (" + product.ItemArray[3].ToString() + ")" +
                                " x" + o.ItemArray[2].ToString() + noteAppended,
                            o.ItemArray[0].ToString())
                    );  //add to list box
                }
            }

            Session["newOrders"] = new Dictionary<int, Order>();  //init
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
            {
                txtPrice.Text = txtStock.Text = String.Empty;
                return;
            }
            DataRow[] inv = dsSales.Inventory.Select("productID = " + ddlProduct.SelectedValue);
            if (inv.Count() != 0)
            {
                txtPrice.Text = "Price: " + Convert.ToDecimal(inv[0].ItemArray[4]).ToString("C2");
                txtStock.Text = "Number in Stock: " + inv[0].ItemArray[1].ToString();
            }
            else
            {
                txtPrice.Text = String.Empty;
                txtStock.Text = "Not In Inventory";
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (ddlCustomer.SelectedValue == "" || ddlPayment.SelectedValue == "")
                return;

            Dictionary<int, Order> orders = (Dictionary<int, Order>)Session["newOrders"];  //get saved orders

            DataRow sale;
            if (Request.QueryString["Mode"] != "Edit")
            {
                DateTime now = DateTime.Now;
                sale = dsSales.Receipt.NewRow();
                sale["ordNumber"] = now.ToString("MMddHHmm");
                sale["ordPaid"] = false;
                sale["empID"] = ddlEmployee.SelectedValue;
            }
            else
                sale = dsSales.Receipt.FindByid(Convert.ToInt32(Request.QueryString["ID"]));

            sale["ordDate"] = txtDate.Text;
            sale["paymentID"] = ddlPayment.SelectedValue;
            sale["custID"] = ddlCustomer.SelectedValue;

            if (Request.QueryString["Mode"] != "Edit") dsSales.Receipt.Rows.Add(sale);
            daReceipts.Update(dsSales.Receipt);

            if (lsbOrders.Items.Count > 0)
                foreach (Order order in orders.Values)
                {
                    DataRow nrOrder = dsSales.OrderLine.NewRow();
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
                        //update inventory
                        inv["invQuantity"] = stock - order.qty;
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
                        //update inventory
                        inv["invQuantity"] = 0;
                    }
                }
            daOL.Update(dsSales.OrderLine);
            daInventory.Update(dsSales.Inventory);
            dsSales.AcceptChanges();
            Response.Redirect("SaleRecord.aspx?ID=" + sale.ItemArray[0].ToString());
        }

        protected void btnAddOrder_Click(object sender, EventArgs e)
        {
            if (ddlProduct.SelectedValue == "") return;

            Dictionary<int, Order> orders = (Dictionary<int, Order>)Session["newOrders"];  //get saved orders
            //get inventory record

            Order order;
            int key = orders.Count > 0 ? orders.Keys.Max() + 1 : 0;
            order.productID = Convert.ToInt32(ddlProduct.SelectedValue);
            order.qty = Convert.ToInt32(txtQty.Text);
            order.note = txtNote.Text;
            orders.Add(key, order);  //save order
            string noteAppended = String.IsNullOrEmpty(txtNote.Text) ? String.Empty :
                                    " - Note: " + txtNote.Text;
            lsbOrders.Items.Add(
                new ListItem(ddlProduct.SelectedItem.Text + " x" + txtQty.Text + noteAppended,
                        "-" + key.ToString()  //"-" identify newly added orders, followed by the key in the dict
                    )
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
            if (lsbOrders.SelectedValue.Contains("-"))  //newly added order
            {
                Dictionary<int, Order> orders = (Dictionary<int, Order>)Session["newOrders"];  //get saved orders
                int key = Convert.ToInt32(lsbOrders.SelectedValue.Substring(1));
                orders.Remove(key);  //remove the record
            }
            else  //in editing mode, selecting an existing order
                dsSales.OrderLine.FindByid(Convert.ToInt32(lsbOrders.SelectedValue)).Delete();
            lsbOrders.Items.RemoveAt(lsbOrders.SelectedIndex);  //remove the entry
        }

        protected void btnClearOrder_Click(object sender, EventArgs e)
        {
            ddlProduct.SelectedIndex = 0;
            txtQty.Text = txtNote.Text = txtPrice.Text = txtStock.Text = String.Empty;
        }


        //helpers
        private void DisplayCustomerList(string receiptID)
        {
            ddlCustomer.Items.Clear();
            ddlCustomer.Items.Add(new ListItem("Select a Customer", ""));
            foreach (DataRow r in dsSales.CustomerName.Rows)
                ddlCustomer.Items.Add(new ListItem(r[1].ToString(), r[0].ToString()));
            if (String.IsNullOrEmpty(receiptID))
                ddlCustomer.SelectedIndex = 0; //if creating make Select a Customer as default
            else
                ddlCustomer.SelectedValue =
                    dsSales.Receipt.FindByid(Convert.ToInt32(receiptID)).ItemArray[5].ToString();
                    //if editing select the customer as is on record
        }

        private void DisplayPaymentList(string receiptID)
        {
            ddlPayment.Items.Clear();
            ddlPayment.Items.Add(new ListItem("Select a Payment Method", ""));
            foreach (DataRow r in dsSales.Payment.Rows)
                ddlPayment.Items.Add(new ListItem(r[1].ToString(), r[0].ToString()));
            if (String.IsNullOrEmpty(receiptID))
                ddlPayment.SelectedIndex = 0; //if creating make Select a Payment Method as default
            else
                ddlPayment.SelectedValue =
                    dsSales.Receipt.FindByid(Convert.ToInt32(receiptID)).ItemArray[4].ToString();
                    //if editing select the customer as is on record
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

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("/");
        }
    }
}