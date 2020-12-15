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
    public partial class EditOrdersForm : System.Web.UI.Page
    {
        static OrdersDataSet dsOrder;
        private static int id = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                dsOrder = new OrdersDataSet();
                prod_orderTableAdapter daOrder = new prod_orderTableAdapter();
                daOrder.Fill(dsOrder.prod_order);
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
                        DataRow order = dsOrder.prod_order.FindByid(id); // Find the related Record and fill the fields in the page with the data

                        if (order != null)
                        {
                            this.txtID.Text = order.ItemArray[0].ToString();
                            this.txtProdNumber.Text = order.ItemArray[1].ToString();
                            this.txtDate.Text = order.ItemArray[2].ToString();
                            this.cbo_Paid.Text = order.ItemArray[3].ToString();
                            
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


        //Edit Button click
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //check a record has been selected
            if (id != -1)
            {
                try
                {
                    //update record with user's input
                    dsOrder.prod_order.FindByid(id).pordNumber = txtProdNumber.Text.ToString();
                    dsOrder.prod_order.FindByid(id).pordDateOrdered = Convert.ToDateTime(this.txtDate.Text);
                    dsOrder.prod_order.FindByid(id).pordPaid = Convert.ToBoolean(this.cbo_Paid.Checked);
                    
                    Save();
                }
                catch { lblStatus.Text = "Unable to Update Record"; }
            }
        }

        private void Save()
        {
            try
            {
                prod_orderTableAdapter daOrder = new prod_orderTableAdapter();
                daOrder.Update(dsOrder.prod_order); // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
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
            lblDateHelp.Visible = lblPaidHelp.Visible = lblProdlHelp.Visible = lblIdHelp.Visible =
                  cboHelp.Checked;
        }
    }
}