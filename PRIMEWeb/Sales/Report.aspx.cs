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
    public partial class Report : System.Web.UI.Page
    {
        private static SalesDataSet dsSales = new SalesDataSet();
        private static ReceiptTableAdapter daReceipt = new ReceiptTableAdapter();
        private static CustomerNameTableAdapter daCustomerNames = new CustomerNameTableAdapter();
        private static EmployeeNameTableAdapter daEmployeeNames = new EmployeeNameTableAdapter();
        private static OrderLineTableAdapter daOL = new OrderLineTableAdapter();
        private static ServiceOrderTableAdapter daServiceOrder = new ServiceOrderTableAdapter();
        private static InventoryTableAdapter daInventory = new InventoryTableAdapter();
        private static ProductTableAdapter daProduct = new ProductTableAdapter();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
                    //if not admin or even not logged in
                Response.Redirect("/");

            try
            {
                dsSales.Clear();
                daReceipt.Fill(dsSales.Receipt);
                daCustomerNames.Fill(dsSales.CustomerName);
                daEmployeeNames.Fill(dsSales.EmployeeName);
                daOL.Fill(dsSales.OrderLine);
                daServiceOrder.Fill(dsSales.ServiceOrder);
                daInventory.Fill(dsSales.Inventory);
                daProduct.Fill(dsSales.Product);
            }
            catch (Exception ex)
            {
                //prompt users the failure
                return;
            }

            //data loaded successfully

            DateTime lastWeek = DateTime.Today - new TimeSpan(7, 0, 0, 0);
            DataRow[] sales = dsSales.Receipt.Select(
                "ordDate > #" + lastWeek.ToShortDateString() + "# AND ordPaid = True"
            );


            switch (sales.Length)
            {
                case 0:
                    lblSales.Text = "No records found.";
                    break;
                case 1:
                    lblSales.Text = "1 paid sale displayed.";
                    break;
                default:
                    lblSales.Text = sales.Length.ToString() + " paid sales displayed.";
                    break;
            }
            DataTable dtSales = new DataTable();
            dtSales.Columns.Add("Sale Number");
            dtSales.Columns.Add("Date");
            dtSales.Columns.Add("Customer");
            dtSales.Columns.Add("Sales Rep");
            dtSales.Columns.Add("Amount");
            foreach (DataRow sale in sales)
            {
                DataRow nrSale = dtSales.NewRow();
                nrSale["Sale Number"] = sale.ItemArray[1];  //Sale Number
                nrSale["Date"] = ((DateTime)sale.ItemArray[2]).ToShortDateString();  //Date
                nrSale["Customer"] = sale.GetParentRow("fk_receipt_custName").ItemArray[1];  //Customer
                nrSale["Sales Rep"] = sale.GetParentRow("fk_receipt_empName").ItemArray[1];  //Sales Rep

                double total = 0.0;
                foreach (DataRow o in sale.GetChildRows("fk_orderline_receipt"))
                    total += Convert.ToDouble(o.ItemArray[1]) * Convert.ToInt32(o.ItemArray[2]);
                foreach (DataRow r in sale.GetChildRows("fk_serord_receipt"))
                    if (r.ItemArray[4] == null || !(bool)r.ItemArray[4])
                    {
                        DataRow service = r.GetParentRow("fk_serord_service");
                        total += Convert.ToDouble(service.ItemArray[3]);
                    }
                nrSale["Amount"] = total.ToString("C2");  //Amount

                dtSales.Rows.Add(nrSale);
            }
            gvSales.DataSource = dtSales;
            gvSales.DataBind();


            DataTable dtBreakDown = new DataTable();
            dtBreakDown.Columns.Add(" ");
            dtBreakDown.Columns.Add("Count");
            dtBreakDown.Columns.Add("Amount");
            dtBreakDown.Columns.Add("Emma's 2%");

            DataRow nrRepair = dtBreakDown.NewRow();
            DataRow nrOrder = dtBreakDown.NewRow();
            DataRow nrAll = dtBreakDown.NewRow();

            nrRepair[0] = "Repair Records";
            nrOrder[0] = "Orders";
            nrAll[0] = "All Records";

            int cntRepair = 0, cntOrder = 0;
            double amtRepair = 0.0, amtOrder = 0.0;
            foreach (DataRow sale in sales)
            {
                cntRepair += sale.GetChildRows("fk_serord_receipt").Length;
                foreach (DataRow repair in sale.GetChildRows("fk_serord_receipt"))
                    if (repair.ItemArray[4] != null && !(bool)repair.ItemArray[4])
                        amtRepair += Convert.ToDouble(repair.GetParentRow("fk_serord_service").ItemArray[3]);

                cntOrder += sale.GetChildRows("fk_orderline_receipt").Length;
                foreach (DataRow order in sale.GetChildRows("fk_orderline_receipt"))
                    amtOrder += Convert.ToDouble(order.ItemArray[1]);
            }

            nrRepair[1] = cntRepair;
            nrOrder[1] = cntOrder;
            nrAll[1] = cntRepair + cntOrder;
            nrRepair[2] = amtRepair.ToString("C2");
            nrOrder[2] = amtOrder.ToString("C2");
            nrAll[2] = (amtRepair + amtOrder).ToString("C2");
            nrRepair[3] = (amtRepair * 0.02).ToString("C2");
            nrOrder[3] = (amtOrder * 0.02).ToString("C2");
            nrAll[3] = ((amtRepair + amtOrder) * 0.02).ToString("C2");

            dtBreakDown.Rows.Add(nrRepair);
            dtBreakDown.Rows.Add(nrOrder);
            dtBreakDown.Rows.Add(nrAll);

            gvBreakDown.DataSource = dtBreakDown;
            gvBreakDown.DataBind();


            DataTable dtOrdered = new DataTable();
            dtOrdered.Columns.Add("Inventory ID");
            dtOrdered.Columns.Add("Product");
            dtOrdered.Columns.Add("Inventory Usage");
            dtOrdered.Columns.Add("# Ordered");
            dtOrdered.Columns.Add("Amount for Inventory");
            dtOrdered.Columns.Add("Amount for the Ordered");
            dtOrdered.Columns.Add("Total Amount");

            foreach (DataRow inv in dsSales.Inventory.Rows)
            {
                int cntInv = 0, cntOrdered = 0;
                double amtInv = 0.0, amtOrdered = 0.0;
                foreach (DataRow order in inv.GetChildRows("fk_orderline_inventory"))
                    if (Convert.ToDateTime(order.GetParentRow("fk_orderline_receipt")[2]) > lastWeek)
                        if (order[3] != null && (bool)order[3])
                        {
                            cntOrdered += Convert.ToInt32(order[2]);
                            amtOrdered += Convert.ToDouble(order[1]);
                        }
                        else
                        {
                            cntInv += Convert.ToInt32(order[2]);
                            amtInv += Convert.ToDouble(order[1]);
                        }
                if (cntInv + cntOrdered == 0) continue;

                DataRow nrOrdered = dtOrdered.NewRow();
                nrOrdered[0] = inv[0];
                nrOrdered[1] = inv.GetParentRow("fk_inventory_product")[1];
                nrOrdered[2] = cntInv;
                nrOrdered[3] = cntOrdered;
                nrOrdered[4] = amtInv.ToString("C2");
                nrOrdered[5] = amtOrdered.ToString("C2");
                nrOrdered[6] = (amtInv + amtOrdered).ToString("C2");
                dtOrdered.Rows.Add(nrOrdered);
            }
            gvOrdered.DataSource = dtOrdered;
            gvOrdered.DataBind();
            switch (dtBreakDown.Rows.Count)
            {
                case 0:
                    lblOrdered.Text = "No records found.";
                    break;
                case 1:
                    lblOrdered.Text = "1 record displayed.";
                    break;
                default:
                    lblOrdered.Text = dtBreakDown.Rows.Count.ToString() + " records displayed.";
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