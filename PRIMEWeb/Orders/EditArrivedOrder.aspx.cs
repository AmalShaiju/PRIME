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
    public partial class EditArrivedOrder : System.Web.UI.Page
    {

        static OrdersDataSet dsOrder;
        private static int id = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)  //if not logged in
                Response.Redirect("/");

            try
            {
                dsOrder = new OrdersDataSet();
                on_orderTableAdapter daOrder = new on_orderTableAdapter();
                daOrder.Fill(dsOrder.on_order);
                if (Request.Cookies["ID"] != null) // Request the cookies which contaions the ID Of thr record that was carried over from the index page
                    id = Convert.ToInt32(Request.Cookies["ID"].Value);
            }
            catch { return; }
            if (!IsPostBack)
            {
                if (id != -1)
                {
                    try
                    {
                        DataRow order = dsOrder.on_order.FindByid(id); // Find the related Record and fill the fields in the page with the data

                        if (order != null)
                        {
                            this.txtID.Text = order.ItemArray[0].ToString();
                            this.txtInvoiceNumber.Text = order.ItemArray[1].ToString();
                            this.txtArriveDate.Text = Convert.ToDateTime(order.ItemArray[2]).ToString("yyyy-MM-dd");
                            this.txtNumberInOrder.Text = order.ItemArray[3].ToString();
                            this.txtPrice.Text = order.ItemArray[4].ToString();
                            this.ddlInventoryID.SelectedValue = order.ItemArray[5].ToString();
                            this.ddlProdOrderID.SelectedValue = order.ItemArray[6].ToString();


                        }
                        else
                        {
                            lblStatus.Text = "Please Try Again";
                        }
                    }
                    catch
                    {
                        lblStatus.Text = "Database Error";
                    }
                }
            }


        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //check a record has been selected
            if (id != -1)
            {
                try
                {
                    //update record with user's input
                    dsOrder.on_order.FindByid(id).onordInvoiceNum = txtInvoiceNumber.Text.ToString();
                    dsOrder.on_order.FindByid(id).onordArriveDate = Convert.ToDateTime(this.txtArriveDate.Text);
                    dsOrder.on_order.FindByid(id).onordNumInOrder = Convert.ToInt32(txtNumberInOrder.Text);
                    dsOrder.on_order.FindByid(id).onordPrice = Convert.ToDecimal(txtPrice.Text);
                    dsOrder.on_order.FindByid(id).inventoryID = Convert.ToInt32(ddlInventoryID.SelectedValue);
                    dsOrder.on_order.FindByid(id).prodorderID = Convert.ToInt32(ddlProdOrderID.SelectedValue);

                    Save();
                }
                catch { lblStatus.Text = "Unable to Update Record"; }
            }
        }
        private void Save()
        {
            try
            {
                on_orderTableAdapter daOrder = new on_orderTableAdapter();
                daOrder.Update(dsOrder.on_order); // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
                dsOrder.AcceptChanges(); // Call accept method on the dataset so it update the chanmges to the database
                lblStatus.Text = "Record Successfully Updated";
            }
            catch
            {
                dsOrder.RejectChanges();
                lblStatus.Text = "Unable to Update Record";
            }
        }
        protected void cboHelp_CheckedChanged(object sender, EventArgs e)
        {
            lblDateHelp.Visible = lblArriveDateHelp.Visible = lblIdHelp.Visible = lblInvoiceNumlHelp.Visible =
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