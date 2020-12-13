using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRIMELibrary.OrdersDataSetTableAdapters;
using PRIMELibrary;
using System.Data;
using System.Web.UI.HtmlControls;


namespace PRIMEWeb.Orders
{
    public partial class Default : System.Web.UI.Page
    {

        private static OrdersDataSet dsOrder;
        private static DataRow[] rows;
        private static int id = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                dsOrder = new OrdersDataSet();
                prod_orderTableAdapter daOrder = new prod_orderTableAdapter();
                daOrder.Fill(dsOrder.prod_order);
                rows = (Session["criteria"] != null) ? dsOrder.prod_order.Select(Session["criteria"].ToString()) : dsOrder.prod_order.Select();
                DisplayOrder();
            }
            catch(Exception ex)
            {

            }
            //data loaded successfully
        }
        //display
        private void DisplayOrder()
        {
            this.gvOrders.DataSource = null;
            this.gvOrders.DataBind();

            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("prodNumber");
            dt.Columns.Add("prodDateOrdered");
            dt.Columns.Add("prodPaid");
            dt.Columns.Add();

            foreach (DataRow r in rows)
            {
                DataRow record = dt.NewRow();
                record[0] = r.ItemArray[0].ToString();
                record[1] = r.ItemArray[1].ToString();
                record[2] = Convert.ToDateTime(r.ItemArray[2].ToString()).ToShortDateString();
                record[3] = r.ItemArray[3].ToString();
                record[4] = String.Empty;

                dt.Rows.Add(record);
            }

            this.gvOrders.DataSource = dt;
            this.gvOrders.DataBind();

            lblStatus.Text = "Search Results: " + ((rows.Length > 0) ? rows.Length.ToString() : "0");
        }
        protected void gvOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == -1)
            {
                e.Row.Cells[4].Text = String.Empty;
                //Clear the header for Edit btn
                return;  //skip the header
            }

            //hiding id column
            this.gvOrders.HeaderRow.Cells[0].Visible = false;
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[4].Attributes["width"] = "235px"; 

            

            //edit btn
            HtmlButton btnEdit = new HtmlButton();  //create edit btn
            btnEdit.Attributes.Add("class", "btn btn-dark");  //set css class
            btnEdit.InnerText = "Edit";
            btnEdit.Attributes.Add("value", e.Row.Cells[0].Text);
            btnEdit.Attributes.Add("aria-label", "Click to go to the edit page for this Order"); //set aria label
            btnEdit.ServerClick += new EventHandler(btnEdit_Click);  //click event handler
            e.Row.Cells[4].Controls.Add(btnEdit);  //add the btn

            //delete btn
            HtmlButton btnDelete = new HtmlButton();  //create delete btn
            btnDelete.Attributes.Add("class", "btn btn-danger");  //set css class
            btnDelete.InnerText = "Delete";
            btnDelete.Attributes.Add("value", e.Row.Cells[0].Text);
            btnDelete.Attributes.Add("aria-label", "Click to delete this Order"); //set aria label
            btnDelete.ServerClick += new EventHandler(btnDelete_Click);  //click event handler
            e.Row.Cells[4].Controls.Add(btnDelete);  //add the btn

        }
        
        //criteria
        private string GetOrderCriteria()
        {
            string criteria = "";
            criteria = (this.txtProdNumber.Text.Length > 0) ? "Product Number Like '%" + this.txtProdNumber.Text + "%'" : "";
           // criteria += (this.txtDateOrdered.Text.Length > 0 && criteria.Length > 0) ? "And  Like '%" + this.txtDateOrdered.Text + "%'"
           //     : (this.txtDateOrdered.Text.Length > 0) ? " Like '%" + this.txtDateOrdered.Text + "%'" : "";
           // criteria += (this.txtPaid.Text.Length > 0 && criteria.Length > 0) ? "And paid option Like '%" + this.txtPaid.Text + "%'"
            //    : (this.txtPaid.Text.Length > 0) ? "paid option Like '%" + this.txtPaid.Text + "%'" : "";
            
            return criteria;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (dsOrder.prod_order.Count > 0)
            {
                Session["criteria"] = GetOrderCriteria();
                rows = (Session["criteria"] != null) ? dsOrder.prod_order.Select(Session["criteria"].ToString()) : dsOrder.prod_order.Select();
                DisplayOrder();
            }
            else
                this.lblStatus.Text = "No Customer Records";
        }
        // Delete btn 
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            HtmlButton btnDelete = (HtmlButton)sender;
            id = Convert.ToInt32(btnDelete.Attributes["value"]);

            if (id != -1)
            {
                try
                {
                    DataRow record = dsOrder.prod_order.FindByid(id); // Find and add the record to tbe record variable
                    record.Delete(); // Deletes the record in memory

                    prod_orderTableAdapter daOrder = new prod_orderTableAdapter(); // table adapter to service table (Service adapter)
                    daOrder.Update(record); // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
                    dsOrder.AcceptChanges(); // Call accept method on the dataset so it update the chanmges to the database
                    //Refresh the page to show the record being deleted
                    Response.Redirect(Request.RawUrl);
                }
                catch
                {

                }
            }
        }

        // Edit btn 
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            HtmlButton btnDelete = (HtmlButton)sender;
            id = Convert.ToInt32(btnDelete.Attributes["value"]);
            if (id != -1)
            {
                //Send Id using cookie, more seecure I presume
                HttpCookie cID = new HttpCookie("ID"); // Cokkie variable named cID to hold a value 
                cID.Value = id.ToString();
                Response.Cookies.Add(cID);
                Response.Redirect("EditOrder.aspx"); // Redirect the user to Edit page on btn click
            }
        }

        
       
    }
}
    
