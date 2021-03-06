﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PRIMELibrary.OrdersDataSetTableAdapters;
using PRIMELibrary;
using System.Web.UI.HtmlControls;

namespace PRIMEWeb.Orders
{
    public partial class ArrivedOrderDefaultPage : System.Web.UI.Page
    {
        static OrdersDataSet dsOrder;
        private static DataRow[] rows; 

        private static int id = -1;
        protected void Page_Load(object sender, EventArgs e)
        {

            

                dsOrder = new OrdersDataSet();
            // on_orderTableAdapter daOrder = new on_orderTableAdapter();
                on_orderCRUDTableAdapter daOrder = new on_orderCRUDTableAdapter();
                
                daOrder.Fill(dsOrder.on_orderCRUD);
                rows = (Session["criteria"] != null) ? dsOrder.on_orderCRUD.Select(Session["criteria"].ToString()) : dsOrder.on_orderCRUD.Select();
                DisplayOn_Order();
            
            
        }
        private void DisplayOn_Order()
        {
            this.gv_Orders.DataSource = null;
            this.gv_Orders.DataBind();

            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("Invoice Number");
            dt.Columns.Add("Arrived Date");
            //dt.Columns.Add("Number in Order");
            //dt.Columns.Add("Price");
            dt.Columns.Add("Product Name and Brand");
            dt.Columns.Add("Product Order ID");
            dt.Columns.Add();

            foreach (DataRow r in rows)
            {
                DataRow record = dt.NewRow();
                record[0] = r.ItemArray[0].ToString();
                record[1] = r.ItemArray[1].ToString();
                record[2] = Convert.ToDateTime(r.ItemArray[2].ToString()).ToShortDateString();
                //record[3] = r.ItemArray[3].ToString();
                //record[4] = Convert.ToDecimal(r.ItemArray[4].ToString()) + "$";
                record[3] = r.ItemArray[7].ToString();
                record[4] = r.ItemArray[6].ToString();
                

                dt.Rows.Add(record);
            }

            this.gv_Orders.DataSource = dt;
            this.gv_Orders.DataBind();

            lbl_Status.Text = "Search Results: " + ((rows.Length > 0) ? rows.Length.ToString() : "0");
        }
        private string GetOrderCriteria()
        {
            string criteria = "";




            criteria = (this.txtInvoiceNumber.Text.Length > 0) ? "onordInvoiceNum = " + this.txtInvoiceNumber.Text : "";

            criteria += (this.txtDateAttived.Text.Length > 0 && criteria.Length > 0) ? " And onordArriveDate ='" + this.txtDateAttived.Text + "'"
                 : (this.txtDateAttived.Text.Length > 0) ? "onordArriveDate ='" + this.txtDateAttived.Text + "' " : "";


            criteria += (this.ddlInventoryID.Text != "None" && criteria.Length > 0) ? " And inventoryID = " + this.ddlInventoryID.SelectedValue.ToString()
               : (this.ddlInventoryID.Text != "None") ? "inventoryID = " + this.ddlInventoryID.SelectedValue.ToString() : "";


            //criteria += (this.ddlProdOrderID.Text != "None" && criteria.Length > 0) ? " And prodorderID = " + this.ddlProdOrderID.SelectedValue.ToString()
            //   : (this.ddlProdOrderID.Text != "None") ? "prodorderID = " + this.ddlProdOrderID.SelectedValue.ToString() : "";




            //criteria += (this.txtPrice.Text != "" && criteria.Length > 0) ? " And onordPrice = " + this.txtPrice.Text
            //: (this.txtPrice.Text != "") ? "onordPrice = " + this.txtPrice.Text : "";

            //criteria += (this.txtNumberInOrder.Text != "" && criteria.Length > 0) ? " And onordNumInOrder = " + this.txtNumberInOrder.Text
            // : (this.txtNumberInOrder.Text != "") ? "onordNumInOrder = " + this.txtNumberInOrder.Text : "";


           


            return criteria;
        }
        

            protected void gv_Orders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == -1)
            {
                e.Row.Cells[5].Text = String.Empty;
                //Clear the header for Edit btn
                return;  //skip the header
            }

            //hiding id column
            this.gv_Orders.HeaderRow.Cells[0].Visible = false;
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[5].Attributes["width"] = "310px";



            //edit btn
            HtmlButton btnEdit = new HtmlButton();  //create edit btn
            btnEdit.Attributes.Add("class", "btn btn-dark");  //set css class
            btnEdit.InnerText = "Edit";
            btnEdit.Attributes.Add("value", e.Row.Cells[0].Text);
            btnEdit.Attributes.Add("aria-label", "Click to go to the edit page for this Order"); //set aria label
            btnEdit.ServerClick += new EventHandler(btnEdit_Click);  //click event handler
            e.Row.Cells[5].Controls.Add(btnEdit);  //add the btn

            //delete btn
            HtmlButton btnDelete = new HtmlButton();  //create delete btn
            btnDelete.Attributes.Add("class", "btn btn-danger");  //set css class
            btnDelete.InnerText = "Delete";
            btnDelete.Attributes.Add("value", e.Row.Cells[0].Text);
            btnDelete.Attributes.Add("aria-label", "Click to delete this Order"); //set aria label
            btnDelete.ServerClick += new EventHandler(btnDelete_Click);  //click event handler
            e.Row.Cells[5].Controls.Add(btnDelete);  //add the btn
            //details btn

            HtmlButton btnDetail = new HtmlButton();  //create detail btn
            btnDetail.Attributes.Add("class", "btn btn-info");  //set css class
            btnDetail.InnerText = "Detail";
            btnDetail.Attributes.Add("value", e.Row.Cells[0].Text);
            btnDetail.Attributes.Add("aria-label", "Click to go to the detail page for this sale"); //set aria label
            btnDetail.ServerClick += new EventHandler(btnDetail_Click);  //click event handler
            e.Row.Cells[5].Controls.Add(btnDetail);  //add the btn

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (dsOrder.on_orderCRUD.Count > 0)
            {
                Session["criteria"] = GetOrderCriteria();
                rows = (Session["criteria"] != null) ? dsOrder.on_orderCRUD.Select(Session["criteria"].ToString()) : dsOrder.on_orderCRUD.Select();
                DisplayOn_Order();
            }
            else
                this.lbl_Status.Text = "No Customer Records";
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
                    DataRow record = dsOrder.on_orderCRUD.FindByid(id); // Find and add the record to tbe record variable
                    
                                     //Send Id using cookie, more seecure I presume
                    HttpCookie cID = new HttpCookie("ID"); // Cokkie variable named cID to hold a value 
                    cID.Value = id.ToString();

                    HttpCookie action = new HttpCookie("Action"); // Cokkie variable named cID to hold a value 
                    action.Value = "Delete";

                    Response.Cookies.Add(action);
                    Response.Cookies.Add(cID);
                     // Redirect the user to Edit page on btn click

                    on_orderTableAdapter daOrder = new on_orderTableAdapter(); // table adapter to service table (Service adapter)
                   
                    //Refresh the page to show the record being deleted
                    //Response.Redirect(Request.RawUrl);
                    Response.Redirect("DeleteConfirmation.aspx");
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
                Response.Redirect("EditArrivedOrder.aspx"); // Redirect the user to Edit page on btn click
            }
        }

        protected void btnDetail_Click(object sender, EventArgs e)
        {
            HtmlButton btnDelete = (HtmlButton)sender;
            id = Convert.ToInt32(btnDelete.Attributes["value"]);
            if (id != -1)
            {
                //Send Id using cookie, more seecure I presume
                HttpCookie cID = new HttpCookie("ID"); // Cokkie variable named cID to hold a value 
                
                cID.Value = id.ToString();

                HttpCookie action = new HttpCookie("Action"); // Cokkie variable named cID to hold a value 
                action.Value = "Details";

                Response.Cookies.Add(action);
                
                
                cID.Value = id.ToString();
                Response.Cookies.Add(cID);
                Response.Redirect("DetailsArrivedOrder.aspx"); // Redirect the user to Edit page on btn click
            }
        }

    }
}