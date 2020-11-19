using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRIMEWeb.Sales
{
    public partial class NewSale : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            txtDate.Text = DateTime.Today.ToShortDateString();
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSaveOrder_Click(object sender, EventArgs e)
        {
            lsbOrders.Items.Add(new ListItem(ddlProduct.SelectedItem.Text, txtQty.Text));
            ddlProduct.SelectedIndex = 0;
            txtQty.Text = txtNote.Text = String.Empty;
            txtPrice.Text = "Price";
            txtStock.Text = "Number in Stock...";
        }

        protected void btnDeleteOrder_Click(object sender, EventArgs e)
        {

        }

        protected void lsbOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQty.Text = lsbOrders.SelectedValue;
        }
    }
}