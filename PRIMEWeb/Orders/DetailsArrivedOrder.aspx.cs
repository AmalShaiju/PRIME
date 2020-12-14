using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRIMELibrary.OrdersDataSetTableAdapters;
using PRIMELibrary;
using System.Data;

namespace PRIMEWeb.Orders
{
    public partial class DetailsArrivedOrder : System.Web.UI.Page
    {
        static OrdersDataSet dsOrder;
        private static int id = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                dsOrder = new OrdersDataSet();
                on_orderTableAdapter daCustomer = new on_orderTableAdapter();
                daCustomer.Fill(dsOrder.on_order);


                if (Request.Cookies["ID"] != null) // Request the cookies which contaions the ID Of thr record that was carried over from the index page
                    id = Convert.ToInt32(Request.Cookies["ID"].Value);
            }
            catch { return; }
            if (id != -1)
            {
                try
                {
                    DataRow customer = dsOrder.on_order.FindByid(id); // Find the related Record and fill the fields in the page with the data

                    if (customer != null)
                    {
                        this.txtID.Text = customer.ItemArray[0].ToString();
                        this.txtInvoiceNum.Text = customer.ItemArray[1].ToString();
                        this.txtArriveDate.Text = customer.ItemArray[2].ToString();
                        this.txtNumInOrder.Text = customer.ItemArray[3].ToString();
                        this.txtPrice.Text = customer.ItemArray[4].ToString();
                        this.txtInventoryID.Text = customer.ItemArray[5].ToString();
                        this.txtProdOrderID.Text = customer.ItemArray[6].ToString();
                       
                    }
                    else
                    {
                        lblStatus.Text = "Record doesn't exist";
                    }
                }
                catch
                {
                    lblStatus.Text = "Database Error";
                }
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                HttpCookie cID = new HttpCookie("ID"); // Cokkie variable named cID to hold a value 
                cID.Value = id.ToString();
                Response.Cookies.Add(cID);
                Response.Redirect("EditArrivedOrder.aspx"); // Redirect the user to Edit page on btn click
            }
        }
    }
}