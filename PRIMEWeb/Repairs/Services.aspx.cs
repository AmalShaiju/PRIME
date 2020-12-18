using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using PRIMELibrary;
using PRIMELibrary.RepairsDataSetTableAdapters;
using System.Drawing;

namespace PRIMEWeb.Repairs
{
    public partial class Services : System.Web.UI.Page
    {
        // Static Dataset so all users see the same data ( IF some one deletes one record everyone sees that change )
        static RepairsDataSet RepairsDataSet;
        private static DataRow[] rows; // Data rows to load more than one record ( doesnt need to be static ) // Not Sure


        static Services()
        {
            RepairsDataSet = new RepairsDataSet();
        }

        private static int id = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //refresh the dataset, so the newly created record is shown in index
                serviceTableAdapter daservices = new serviceTableAdapter();
                daservices.Fill(RepairsDataSet.service);
            }
            catch
            {
                this.Label1.Text = "Failed to load Data, Please Contact the system administrator";
                this.Label1.ForeColor = Color.Red;
                return;
            }
            Session["RepairCriteria"] = null;

            if (Session["deleteMsg"] != null)
                if (Session["deleteMsg"].ToString() == "true")
                {
                    this.lblDeleteMsg.Visible = true;
                    this.lblDeleteMsg.Text = "&#10004; Record deleted Successfully";
                    Session["deleteMsg"] = null;
                    this.pnlDeleteConfirm.Visible = false;

                }
                else
                {
                    this.lblDeleteMsg.Visible = true;
                    this.lblDeleteMsg.Text = "&#x274C; Record not deleted, please check if this service is related to any repairs";
                    Session["deleteMsg"] = null;
                    this.lblDeleteMsg.ForeColor = Color.Red;
                    this.pnlDeleteConfirm.Visible = false;

                }

            //get records
            rows = (Session["ServiceCriteria"] != null) ? RepairsDataSet.service.Select(Session["ServiceCriteria"].ToString())  //has criteria
                 : RepairsDataSet.service.Select();  //select all

            DisplayServiceTable();

        }

        // Filter Search Btn
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (RepairsDataSet.service.Count > 0)
            {
                string criteria = FilterCriteria();
                Session["ServiceCriteria"] = FilterCriteria();
                rows = (criteria.Length > 0) ? RepairsDataSet.service.Select(criteria) : RepairsDataSet.service.Select(); // Data satisfying the conditions is saved in rows
                DisplayServiceTable();
            }
            else
            {
                this.Label1.Text = "Database Error, Please Contact The System Administarator";
                this.Label1.ForeColor = Color.Red;
            }

        }

        // Edit btn 
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            // Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            //Get rowindex
            int rowindex = gvr.RowIndex;


            //Send Id using cookie, more seecure I presume
            HttpCookie cID = new HttpCookie("ID"); // Cokkie variable named cID to hold a value 
            cID.Value = rows[rowindex].ItemArray[0].ToString();
            Response.Cookies.Add(cID);
            Response.Redirect("EditService.aspx"); // Redirect the user to Edit page on btn click


        }

        // Delete btn 
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Get the button that raised the event
            Button btn = (Button)sender;

            ////Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            ////Get rowindex
            int rowindex = gvr.RowIndex;

            rows[rowindex].ItemArray[0].ToString();
            id = Convert.ToInt32(rows[rowindex].ItemArray[0].ToString());

            this.pnlDeleteConfirm.Visible = true;

        }

        // Method to add edit and delete btn 
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) // Method adding the btns to the table
        {
            try
            {
                if (e.Row.RowIndex == -1)
                {
                    //Clear the header for Detail Edit Delete btn
                    e.Row.Cells[3].Text = String.Empty;
                    return;  //skip the header
                }

                // Edit btn
                Button btnEdit = new Button();  //create edit btn
                btnEdit.CssClass = "btn btn-dark";  //set css class
                btnEdit.Text = "Edit";
                btnEdit.Attributes.Add("aria-label", "Click to go to the edit page for this sale");
                btnEdit.Click += new EventHandler(btnEdit_Click);// Set button click event
                e.Row.Cells[3].Controls.Add(btnEdit);  //add the btn



                // Delete btn
                Button btnDelete = new Button();  //create delete btn
                btnDelete.CssClass = "btn btn-danger";  //set css class
                btnDelete.Text = "Delete";
                btnDelete.Attributes.Add("aria-label", "Click to delete this sale");
                btnDelete.Click += new EventHandler(btnDelete_Click);// Set button click event          
                e.Row.Cells[3].Controls.Add(btnDelete);  //add the btn
            }
            catch
            {
                this.Label1.Text = "Records Found : " + rows.Length;

            }


        }

        // Filter criteria
        private string FilterCriteria()
        {
            string criteria = "";

            criteria = (this.txtName.Text.Length > 0) ? " serName Like '%" + this.txtName.Text + "%' " : "";

            criteria += (this.txtDescription.Text.Length > 0 && criteria.Length > 0) ? "and serDescription Like '%" + this.txtDescription.Text + "%' "
                 : (this.txtDescription.Text.Length > 0) ? "serDescription Like '%" + this.txtDescription.Text + "%' " : "";

            criteria += (this.txtPrice.Text.Length > 0 && criteria.Length > 0) ? "and serPrice >=" + this.txtPrice.Text
                : (this.txtPrice.Text.Length > 0) ? "serPrice >=" + this.txtPrice.Text : "";

            return criteria;
        }

        //Display Method to fill tables
        private void DisplayServiceTable()
        {
            //no record after filter
            if (rows.Length <= 0)
                this.Label1.Text = "No reecords Found";

            this.Label1.Text = "Records Found : " + rows.Length;

            DataTable dt = new DataTable();
            dt.Columns.Add("Service");
            dt.Columns.Add("Description");
            dt.Columns.Add("Price");
            dt.Columns.Add(""); // column for Edit and Delete btn


            DataRow dr = dt.NewRow();


            foreach (DataRow r in rows) // loop through the static DataRow[] row since the records from filter are saved in them.
            {
                DataRow nr = dt.NewRow();
                nr[0] = r.ItemArray[1].ToString();
                nr[1] = r.ItemArray[2].ToString();
                nr[2] = r.ItemArray[3].ToString();

                dt.Rows.Add(nr);
            }

            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();


        }

        protected void btnDeleteConfirm_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                try
                {
                    DataRow record = RepairsDataSet.service.FindByid(id); // Find and add the record to tbe record variable

                    record.Delete(); // Deletes the record in memory

                    serviceTableAdapter daservice = new serviceTableAdapter(); // table adapter to service table (Service adapter)
                    daservice.Update(record); // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
                    RepairsDataSet.AcceptChanges(); // Call accept method on the dataset so it update the chanmges to the database

                    //Refresh the page to show the record being deleted
                    Session["deleteMsg"] = "true";
                    this.Label1.Text = "Record Deleted Successfully";


                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("constraint"))
                    {
                        Session["deleteMsg"] = "false";

                    }
                    else
                    {
                        this.Label1.Text = "Record Deletion Failed";
                        this.Label1.ForeColor = Color.Red;

                    }

                }
                finally
                {
                    Response.Redirect(Request.RawUrl);

                }

            }
        }
    }
}

