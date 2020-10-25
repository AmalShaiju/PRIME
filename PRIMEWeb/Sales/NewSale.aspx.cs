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

        }

        protected void btnAddOrder_Click(object sender, EventArgs e)
        {
            pnlBtnSales.Visible = false;
            pnlOrder.Visible = true;
        }

        protected void btnSaveOrder_Click(object sender, EventArgs e)
        {
            pnlBtnSales.Visible = true;
            pnlOrder.Visible = false;
            ddlProduct.SelectedIndex = 0;
            txtQty.Text = txtNote.Text = String.Empty;
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}