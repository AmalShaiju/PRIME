using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRIMELibrary;
using PRIMELibrary.SalesDataSetTableAdapters;

namespace PRIMEWeb.Sales
{
    public partial class Default : System.Web.UI.Page
    {
        private static SalesDataSet dsSales = new SalesDataSet();
        private DataRow[] rows;
        private static bool flag = false; //indicate if the data loading failed
        private static List<Button> btnStatuses = new List<Button>(); //list of the pay/paid btns
        private static List<Button> btnDetails = new List<Button>(); //list of the detail btns
        private static List<Button> btnEdits = new List<Button>(); //list of the edit btns
        private static List<Button> btnDeletes = new List<Button>(); //list of the delete btns

        static Default()
        {
            try
            {
                SalesIndexTableAdapter daSalesIndex = new SalesIndexTableAdapter();
                dsSales.Clear();
                daSalesIndex.Fill(dsSales.SalesIndex);
            }
            catch (Exception ex)
            {
                flag = true; //loading failed
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (flag)
            {
                //prompt users the failure
                return;
            }

            //data loaded successfully

            rows = dsSales.SalesIndex.Select(); //get records
            DisplaySales();
        }

        private void DisplaySales()
        {
            DataTable dtSales = new DataTable();
            dtSales.Columns.Add("Sale Number");
            dtSales.Columns.Add("Date");
            dtSales.Columns.Add("Customer");
            dtSales.Columns.Add("Status");
            dtSales.Columns.Add();  //Details Edit Delete


            foreach (DataRow r in rows)
            {
                dtSales.Rows.Add(r.ItemArray[0], ((DateTime)r.ItemArray[1]).ToShortDateString(),
                    r.ItemArray[3], r.ItemArray[2]); //ID, Date, Name, Status
            }
            gvSales.DataSource = dtSales;
            btnStatuses.Clear();  //clear the list
            gvSales.DataBind();
        }

        protected void gvSales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == -1)
            {
                e.Row.Cells[4].Text = String.Empty;
                //Clear the header for Detail Edit Delete btn
                return;  //skip the header
            }

            //status btn
            Button btnStatus = new Button();  //create status btn
            btnStatuses.Add(btnStatus);  //the list index of the button will also be the row index
            btnStatus.CssClass = "btn btn-success";  //set css class
            if (e.Row.Cells[3].Text == "True")  //paid or not
            {
                //if (not admin)
                btnStatus.Enabled = false;

                btnStatus.Text = "Paid";

                //if (not admin)
                btnStatus.Attributes.Add("aria-label", "Click to set this sale as unpaid");
                //set aria label
            }
            else
            {
                btnStatus.Text = "Pay";
                btnStatus.Attributes.Add("aria-label", "Click to set this sale as paid");
                //set aria label
            }
            btnStatus.Attributes.Add("OnClick", "btnStatus_Click");  //click event handler
            e.Row.Cells[3].Controls.Add(btnStatus);  //add the btn

            //details btn
            Button btnDetail = new Button();  //create detail btn
            btnDetails.Add(btnDetail);  //the list index of the button will also be the row index
            btnDetail.CssClass = "btn btn-info";  //set css class
            btnDetail.Text = "Detail";
            btnDetail.Attributes.Add("aria-label", "Click to go to the detail page for this sale");
            //set aria label
            btnDetail.Attributes.Add("OnClick", "btnDetail_Click");  //click event handler
            e.Row.Cells[4].Controls.Add(btnDetail);  //add the btn

            //edit btn
            Button btnEdit = new Button();  //create edit btn
            btnEdits.Add(btnEdit);  //the list index of the button will also be the row index
            btnEdit.CssClass = "btn btn-dark";  //set css class
            btnEdit.Text = "Edit";
            btnEdit.Attributes.Add("aria-label", "Click to go to the edit page for this sale");
            //set aria label
            btnEdit.Attributes.Add("OnClick", "btnEdit_Click");  //click event handler
            e.Row.Cells[4].Controls.Add(btnEdit);  //add the btn

            //delete btn
            Button btnDelete = new Button();  //create delete btn
            btnDetails.Add(btnDelete);  //the list index of the button will also be the row index
            btnDelete.CssClass = "btn btn-danger";  //set css class
            btnDelete.Text = "Delete";
            btnDelete.Attributes.Add("aria-label", "Click to delete this sale");
            //set aria label
            btnDelete.Attributes.Add("OnClick", "btnDelete_Click");  //click event handler

            //if (not admin)
            btnDelete.Visible = false;
            btnDelete.Enabled = false;

            e.Row.Cells[4].Controls.Add(btnDelete);  //add the btn
        }

        protected void btnStatus_Click(object sender, EventArgs e)
        {

        }
    }
}