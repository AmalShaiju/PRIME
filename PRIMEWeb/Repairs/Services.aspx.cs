using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using PRIMELibrary;
using PRIMELibrary.RepairsDataSetTableAdapters;

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
            AllserviceDataTableAdapter daservices = new AllserviceDataTableAdapter();


            try
            {
                daservices.Fill(RepairsDataSet.AllserviceData);
            }
            catch { }
        }

        private static int id = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            //refresh the dataset, so the newly created record is shown in index
            AllserviceDataTableAdapter daservices = new AllserviceDataTableAdapter();
            RepairsDataSet.Reset();
            daservices.Fill(RepairsDataSet.AllserviceData);

            rows = RepairsDataSet.AllserviceData.Select(); //get records
            DisplayServiceTable();

        }

        //trial code to check if the id waa being pulled
        //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.GridView1.EditIndex != -1)
        //        this.Label1.Text = GridView1.SelectedRow.Cells[1].Text;
        //}

        // Filter Seach Btn
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (RepairsDataSet.AllserviceData.Count > 0)
            {
                string criteria = FilterCriteria();
                rows = (criteria.Length > 0) ? RepairsDataSet.AllserviceData.Select(criteria) : RepairsDataSet.AllserviceData.Select(); // Data satisfying the conditions is saved in rows
                DisplayServiceTable();
            }
            else
                this.Label1.Text = "No Records Found";
        }

        // Edit btn clcik
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            // Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            //Get rowindex
            int rowindex = gvr.RowIndex;

            this.Label1.Text = rowindex.ToString();

            // Not too secure sending value through query string
            //Response.Redirect("EditService.aspx?ID=" + GridView1.Rows[e.NewEditIndex].Cells[1].Text

            //Send Id using cookie, more seecure I presume
            HttpCookie cID = new HttpCookie("ID"); // Cokkie variable named cID to hold a value 
            cID.Value = GridView1.Rows[rowindex].Cells[1].Text;
            Response.Cookies.Add(cID);
            Response.Redirect("EditService.aspx"); // Redirect the user to Edit page on btn click


        }

        // Delete btn click
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Get the button that raised the event
            Button btn = (Button)sender;

            ////Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            ////Get rowindex
            int rowindex = gvr.RowIndex;

            this.Label1.Text = rowindex.ToString();

            id = Convert.ToInt32(GridView1.Rows[rowindex].Cells[1].Text);

            if (id != 1)
            {
                try
                {
                    DataRow record = RepairsDataSet.AllserviceData.FindByid(id); // Find and add the record to tbe record variable

                    record.Delete(); // Deletes the record in m,emory

                    AllserviceDataTableAdapter daservice = new AllserviceDataTableAdapter(); // table adapter to service table (Service adapter)
                    daservice.Update(record); // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
                    RepairsDataSet.AcceptChanges(); // Call accept method on the dataset so it update the chanmges to the database
                    Label1.Text = "deleted";

                    //Refresh the page to show the record being deleted
                    Response.Redirect(Request.RawUrl);

                }
                catch
                {
                    Label1.Text = "not deleted";
                }
            }
            }

        // Filer Clear btn
        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.txtName.Text = "";
            this.txtDescription.Text = "";
            this.txtPrice.Text = "";
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
            this.Label1.Text = "ready";

            //HyperLinkField hp = new HyperLinkField();
            //hp.Text = "Edit";
            //hp.NavigateUrl = "~/Default.aspx";
            //hp  .Visible = true;

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Service");
            dt.Columns.Add("Description");
            dt.Columns.Add("Price");
            dt.Columns.Add(""); // column for Edit and Delete btn


            DataRow dr = dt.NewRow();


            foreach (DataRow r in rows) // loop through the static DataRow[] row since the records from filter are saved in them.
            {
                DataRow nr = dt.NewRow();
                nr[0] = r.ItemArray[0].ToString();
                nr[1] = r.ItemArray[1].ToString();
                nr[2] = r.ItemArray[2].ToString();
                nr[3] = r.ItemArray[3].ToString();

                dt.Rows.Add(nr);
                //this.GridView1.Columns.Add(hp);
            }

            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }

        // Method that edits the record 
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Not too secure sending value through query string
            //Response.Redirect("EditService.aspx?ID=" + GridView1.Rows[e.NewEditIndex].Cells[1].Text

            //Send Id using cookie, more seecure I presume
            HttpCookie cID = new HttpCookie("ID"); // Cokkie variable named cID to hold a value 
            cID.Value = GridView1.Rows[e.NewEditIndex].Cells[1].Text;
            Response.Cookies.Add(cID);
            Response.Redirect("EditService.aspx"); // Redirect the user to Edit page on btn click
        }

        //Method that deletes the record
        protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[1].Text);

            if (id != 1)
            {
                try
                {
                    DataRow record = RepairsDataSet.AllserviceData.FindByid(id); // Find and add the record to tbe record variable

                    record.Delete(); // Deletes the record in memory

                    AllserviceDataTableAdapter daservice = new AllserviceDataTableAdapter(); // table adapter to service table (Service adapter)
                    daservice.Update(record); // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
                    RepairsDataSet.AcceptChanges(); // Call accept method on the dataset so it update the chanmges to the database
                    Label1.Text = "deleted";

                    //Refresh the page to show the record being deleted
                    Response.Redirect(Request.RawUrl);

                }
                catch
                {
                    Label1.Text = "not deleted";
                }

            }
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) // Method adding the btns to the table
        {
            if (e.Row.RowIndex == -1)
            {
                e.Row.Cells[4].Text = String.Empty;
                //Clear the header for Detail Edit Delete btn
                return;  //skip the header
            }

            // Edit btn
            Button btnEdit = new Button();  //create edit btn
                                            // btnEdits.Add(btnEdit);  //the list index of the button will also be the row index
            btnEdit.CssClass = "btn btn-dark";  //set css class
            btnEdit.Text = "Edit";
            btnEdit.Attributes.Add("aria-label", "Click to go to the edit page for this sale");

            //set aria label
            // btnEdit.Attributes.Add("OnClick", "btnEdit_Click");  //click event handler

            btnEdit.Click += new EventHandler(btnEdit_Click);// Set button click event
            e.Row.Cells[4].Controls.Add(btnEdit);  //add the btn



            // Delete btn
            Button btnDelete = new Button();  //create delete btn
                                              // btnDetails.Add(btnDelete);  //the list index of the button will also be the row index
            btnDelete.CssClass = "btn btn-danger";  //set css class
            btnDelete.Text = "Delete";
            btnDelete.Attributes.Add("aria-label", "Click to delete this sale");
            //set aria label
            // btnDelete.Attributes.Add("OnClick", "btnDelete_Click");  //click event handler
            btnDelete.Click += new EventHandler(btnDelete_Click);// Set button click event


            //if (not admin)
            //btnDelete.Visible = false;
            //btnDelete.Enabled = false;

            e.Row.Cells[4].Controls.Add(btnDelete);  //add the btn

        }

        protected void btnSearch_Command(object sender, CommandEventArgs e)
        {

        }

  
    }
}

