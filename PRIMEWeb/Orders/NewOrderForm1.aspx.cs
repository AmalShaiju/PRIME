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
    public partial class NewOrderForm1 : System.Web.UI.Page
    {
        static OrdersDataSet dsOrder = new OrdersDataSet();

        static NewOrderForm1()
        {
            prod_orderTableAdapter daOrder = new prod_orderTableAdapter();

            try
            {
                daOrder.Fill(dsOrder.prod_order);
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
            DataRow order = dsOrder.prod_order.NewRow();

            //update record with user's input
            order[1] = this.txtProdNumber.Text;
            order[2] = Convert.ToDateTime(this.txtDate.Text);
            order[3] = Convert.ToBoolean(this.cbo_Paid.Checked);
            dsOrder.prod_order.Rows.Add(order);
            
            Save();
        }
        private void Save()
        {
            prod_orderTableAdapter daOrder = new prod_orderTableAdapter();

            try
            {
                daOrder.Update(dsOrder.prod_order);
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
            this.txtDate.Text = "";
            this.txtProdNumber.Text = "";
            cbo_Paid.Checked = false;
            
        }
        protected void cboHelp_CheckedChanged(object sender, EventArgs e)
        {
            lblDateHelp.Visible = lblPaidHelp.Visible = lblProdlHelp.Visible =
                  cboHelp.Checked;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("/");
        }
    }
}