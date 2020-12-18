using PRIMELibrary;
using PRIMELibrary.SalesDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRIMEWeb.Sales
{
    public partial class SaleRecord : System.Web.UI.Page
    {
        private static SalesDataSet dsSales = new SalesDataSet();
        private static ReceiptTableAdapter daReceipt = new ReceiptTableAdapter();
        private static CustomerInfoTableAdapter daCustomerInfo = new CustomerInfoTableAdapter();
        private static EmployeeNameTableAdapter daEmployeeNames = new EmployeeNameTableAdapter();
        private static OrderLineTableAdapter daOL = new OrderLineTableAdapter();
        private static ServiceOrderTableAdapter daServiceOrder = new ServiceOrderTableAdapter();
        private static InventoryTableAdapter daInventory = new InventoryTableAdapter();
        private static ProductTableAdapter daProduct = new ProductTableAdapter();
        private static PaymentTableAdapter daPayment = new PaymentTableAdapter();
        private static ServiceTableAdapter daService = new ServiceTableAdapter();
        private static EquipmentModelTableAdapter daEquipmentModel = new EquipmentModelTableAdapter();
        private string receiptID;
        private DataRow sale;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)  //if not logged in
                Response.Redirect("/");

            receiptID = Request.QueryString["ID"];
            if (receiptID == null)
                Response.Redirect("~/Sales/");

            try
            {
                dsSales.Clear();
                daReceipt.Fill(dsSales.Receipt);
                daCustomerInfo.Fill(dsSales.CustomerInfo);
                daEmployeeNames.Fill(dsSales.EmployeeName);
                daOL.Fill(dsSales.OrderLine);
                daServiceOrder.Fill(dsSales.ServiceOrder);
                daInventory.Fill(dsSales.Inventory);
                daProduct.Fill(dsSales.Product);
                daPayment.Fill(dsSales.Payment);
                daService.Fill(dsSales.Service);
                daEquipmentModel.Fill(dsSales.EquipmentModel);
                sale = dsSales.Receipt.FindByid(Convert.ToInt32(receiptID));
            }
            catch (Exception ex)
            {
                //prompt users the failure
                return;
            }

            if (sale == null)
            {
                lblTitle.Text = "Record Not Found";
                pnlInfo.Visible = false;
                return;
            }

            if (Request.QueryString["Delete"] == "1" && User.IsInRole("Admin"))
            {
                pnlDeleteConfirm.Visible = true;
                lblTitle.Text = "Delete Sale";
            }

            DisplayCustomer();
            DisplaySale();
            DisplayOrders();
            DisplayRepairs();
        }

        protected void btnDeleteConfirm_Click(object sender, EventArgs e)
        {
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
            Response.Redirect("~/Sales/");
        }

        //helpers
        private void DisplayCustomer()
        {
            DataRow cust = sale.GetParentRow("fk_receipt_custInfo");
            lblCustName.Text = cust.ItemArray[1].ToString();
            string number = cust.ItemArray[2].ToString();
            lblCustNo.Text = "(" + number.Substring(0, 3) + ") " +
                number.Substring(3, 3) + "-" + number.Substring(6, 4);
            lblCustAddress.Text = cust.ItemArray[3].ToString();
            lblCustCity.Text = cust.ItemArray[4].ToString();
            lblCustPostal.Text = cust.ItemArray[5].ToString();
            lblCustEmail.Text = cust.ItemArray[6].ToString();
        }

        private void DisplaySale()
        {
            lblSaleNo.Text = sale.ItemArray[1].ToString();
            lblSaleDate.Text = Convert.ToDateTime(sale.ItemArray[2]).ToShortDateString();
            if (sale.ItemArray[3] != null && (bool)sale.ItemArray[3])
                lblSalePaid.Text = "Paid";
            else if (sale.ItemArray[3] != null)
                lblSalePaid.Text = "Unpaid";
            lblSalePayment.Text = sale.GetParentRow("fk_receipt_payment").ItemArray[1].ToString();
            lblSaleEmp.Text = sale.GetParentRow("fk_receipt_empName").ItemArray[1].ToString();

            double total = 0.0;
            foreach (DataRow o in sale.GetChildRows("fk_orderline_receipt"))
                total += Convert.ToDouble(o.ItemArray[1]) * Convert.ToInt32(o.ItemArray[2]);
            foreach (DataRow r in sale.GetChildRows("fk_serord_receipt"))
                if (r.ItemArray[4] == null || !(bool)r.ItemArray[4])
                {
                    DataRow service = r.GetParentRow("fk_serord_service");
                    total += Convert.ToDouble(service.ItemArray[3]);
                }
            lblSaleAmount.Text = total.ToString("C2");
        }

        private void DisplayOrders()
        {
            DataTable dtOrders = new DataTable();
            dtOrders.Columns.Add("Product");
            dtOrders.Columns.Add("Description");
            dtOrders.Columns.Add("Quantity");
            dtOrders.Columns.Add("Price");
            dtOrders.Columns.Add("Subtotal");
            dtOrders.Columns.Add("Source");
            dtOrders.Columns.Add("Note");

            DataRow[] orders = sale.GetChildRows("fk_orderline_receipt");

            switch (orders.Length)
            {
                case 0:
                    lblOrder.Text = "No " + lblOrder.Text + " Found";
                    break;
                case 1:
                    lblOrder.Text = "1 " + lblOrder.Text;
                    break;
                default:
                    lblOrder.Text = orders.Length.ToString() + " " + lblOrder.Text + "s";
                    break;
            }

            double ordersTotal = 0.0;

            foreach (DataRow o in orders)
            {
                DataRow product = o.GetParentRow("fk_orderline_inventory")  //Inventory
                                    .GetParentRow("fk_inventory_product");

                string prodField = product.ItemArray[1].ToString() + " (" +
                    product.ItemArray[3].ToString() + ")";
                int qty = Convert.ToInt32(o.ItemArray[2]);
                double price = Convert.ToDouble(o.ItemArray[1]);
                string sourceField = o.ItemArray[3] == null ? "N/A" : (  //if null
                    (bool)o.ItemArray[3] ? "Supplier" : "Inventory" );  //not null

                dtOrders.Rows.Add(prodField,  //Product
                    product.ItemArray[2],  //Description
                    qty,  //Quantity
                    price.ToString("C2"),  //Price
                    (qty * price).ToString("C2"),  //Subtotal
                    sourceField,  //Source
                    o.ItemArray[4]  //Note
                );

                ordersTotal += qty * price;
            }
            
            if (ordersTotal > 0.0) lblOrder.Text += ": " + ordersTotal.ToString("C2");

            gvOrders.DataSource = dtOrders;
            gvOrders.DataBind();
        }

        private void DisplayRepairs()
        {
            DataTable dtRepairs = new DataTable();
            dtRepairs.Columns.Add("Service");
            dtRepairs.Columns.Add("Description");
            dtRepairs.Columns.Add("Price");
            dtRepairs.Columns.Add("Issue");
            dtRepairs.Columns.Add("Equipment");
            dtRepairs.Columns.Add("Warranty Status");
            dtRepairs.Columns.Add("Date");
            dtRepairs.Columns.Add("Repaird By");

            DataRow[] repairs = sale.GetChildRows("fk_serord_receipt");

            switch (repairs.Length)
            {
                case 0:
                    lblRepairs.Text = "No " + lblRepairs.Text + " Found";
                    break;
                case 1:
                    lblRepairs.Text = "1 " + lblRepairs.Text;
                    break;
                default:
                    lblRepairs.Text = repairs.Length.ToString() + " " + lblRepairs.Text + "s";
                    break;
            }

            double repairsTotal = 0.0;

            foreach (DataRow r in repairs)
            {
                DataRow service = r.GetParentRow("fk_serord_service");

                double price = Convert.ToDouble(service.ItemArray[3]);
                string warranty = r.ItemArray[4] == null ? "N/A" : (  //if null
                    (bool)r.ItemArray[4] ? "In Warranty" : "Expired");  //not null

                DateTime dateIn = Convert.ToDateTime(r.ItemArray[1]),
                    dateOut = Convert.ToDateTime(r.ItemArray[2]);
                string date;
                if (dateIn == null)
                    date = "To be started";
                else if (dateOut == null)
                    date = "Started on " + dateIn.ToShortDateString();
                else if (dateIn.ToShortDateString() == dateOut.ToShortDateString())
                    date = dateIn.ToShortDateString();
                else
                    date = dateIn.ToShortDateString() + " - " + dateOut.ToShortDateString();

                dtRepairs.Rows.Add(service.ItemArray[1],  //Service
                    service.ItemArray[2],  //Description
                    price.ToString("C2"),  //Price
                    r.ItemArray[3],  //Issue
                    r.GetParentRow("fk_serord_equipModel").ItemArray[1],  //Equipment
                    warranty,  //Warranty Status
                    date,  //Date
                    dsSales.EmployeeName.FindByid(Convert.ToInt32(r.ItemArray[8])).ItemArray[1]  //Repaird By
                );

                if (warranty != "In Warranty") repairsTotal += price;
            }

            if (repairsTotal > 0.0) lblRepairs.Text += ": " + repairsTotal.ToString("C2");

            gvRepairs.DataSource = dtRepairs;
            gvRepairs.DataBind();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("/");
        }
    }
}