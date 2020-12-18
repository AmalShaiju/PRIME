using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRIMELibrary;
using PRIMELibrary.OrdersDataSetTableAdapters;
using System.Data;

namespace PRIMEWeb.Orders
{
    public partial class ArrivedOrder : System.Web.UI.Page
    {
        static OrdersDataSet dsOrder = new OrdersDataSet();

        static ArrivedOrder()
        {
            on_orderTableAdapter daOrder = new on_orderTableAdapter();

            try
            {
                daOrder.Fill(dsOrder.on_order);
            }
            catch { }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)  //if not logged in
                Response.Redirect("/");
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            DataRow order = dsOrder.on_order.NewRow();

            //update record with user's input
            order[1] = this.txtInvoiceNum.Text;
            order[2] = Convert.ToDateTime(this.txtArriveDate.Text);
            order[3] = this.txtNumInOrder.Text;
            order[4] = this.txtPrice.Text ;
            order[5] = Convert.ToInt32(this.ddlInventoryID.SelectedValue);
            order[6] = Convert.ToInt32(this.ddlProdOrderID.SelectedValue);
            dsOrder.on_order.Rows.Add(order);

            Save();
        }

        
        private void Save()
        {
            on_orderTableAdapter daOrder = new on_orderTableAdapter();

            try
            {
                daOrder.Update(dsOrder.on_order);
                dsOrder.AcceptChanges();
                this.lblStatus.Text = "Order Created";
                Clear();
            }
            catch
            {
                dsOrder.RejectChanges();
                this.lblStatus.Text = "Failed";
            }
        }

        private void Clear()
        {
            this.txtArriveDate.Text = "";
            this.txtInvoiceNum.Text = "";
            this.txtNumInOrder.Text = "";
            this.txtPrice.Text = "";


        }
        protected void cboHelp_CheckedChanged(object sender, EventArgs e)
        {
            lblDateHelp.Visible = lblInventoryHelp.Visible = lblInvoiceNumHelp.Visible = 
                lblNumInOrderHelp.Visible= lblPriceHelp.Visible = lblProdOrderID.Visible = pnlHelp.Visible =
                  cboHelp.Checked;
        }


        protected void btnClear_Click(object sender, EventArgs e)
        {
            ddlInventoryID.SelectedIndex = 0;
            ddlProdOrderID.SelectedIndex = 0;
            txtArriveDate.Text = txtInvoiceNum.Text = txtPrice.Text = txtNumInOrder.Text = String.Empty;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("/");
        }
    }
}