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
    public partial class Default : System.Web.UI.Page
    {
        // Static Dataset so all users see the same data ( IF some one deletes one record everyone sees that change )
        static RepairsDataSet RepairsDataSet;
        private static DataRow[] rows; // Data rows to load more than one record ( doesnt need to be static ) // Not Sure

        static Default()
        {
            RepairsDataSet = new RepairsDataSet();
        }

        private static int id = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Refresh the dataset so all updates are shown on page refresh 
                RepairLookUpTableAdapter daRepair = new RepairLookUpTableAdapter();
                service_orderTableAdapter daServiceOrder = new service_orderTableAdapter();

                daRepair.Fill(RepairsDataSet.RepairLookUp);
                daServiceOrder.Fill(RepairsDataSet.service_order);
            }
            catch
            {
                this.Label1.Text = " &#x274C; Failed to load Data, Please Contact the system administrator";
                this.Label1.ForeColor = Color.Red;
                return;
            }

            // Set the criteria so that the grid is refreshed 
            Session["ServiceCriteria"] = null;
            Session["editRedirect"] = null;
            Session["createRedirect"] = null;


            //get records
            rows = (Session["RepairCriteria"] != null) ? RepairsDataSet.RepairLookUp.Select(Session["RepairCriteria"].ToString())  //has criteria
                  : RepairsDataSet.RepairLookUp.Select();  //select all


            DisplayRepairTable();
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


            //Send Id using cookie, more seecure I presume
            HttpCookie cID = new HttpCookie("ID"); // Cokkie variable named cID to hold a value 
            cID.Value = rows[rowindex].ItemArray[0].ToString();
            Response.Cookies.Add(cID);
            Response.Redirect("EditRepair.aspx"); // Redirect the user to Edit page on btn click


        }

        //detail btn
        protected void btnDetail_Click(object sender, EventArgs e)
        {
            // Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            //Get rowindex
            int rowindex = gvr.RowIndex;


            // Not too secure sending value through query string
            //Response.Redirect("EditService.aspx?ID=" + GridView1.Rows[e.NewEditIndex].Cells[1].Text

            //Send Id using cookie, more seecure I presume
            HttpCookie cID = new HttpCookie("ID"); // Cokkie variable named cID to hold a value 
            cID.Value = rows[rowindex].ItemArray[0].ToString();
            Response.Cookies.Add(cID);
            Response.Redirect("Details.aspx"); // Redirect the user to Edit page on btn click


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

            id = Convert.ToInt32(rows[rowindex].ItemArray[0].ToString());

            
            
            // do this after geting confirmation from client side
            if (id != -1)

            {

                try
                {
                    DataRow record = RepairsDataSet.service_order.FindByid(id); // Find the requested record 
                    record.Delete(); // Deletes the record in memory

                    service_orderTableAdapter daServiceOrder = new service_orderTableAdapter(); // table adapter to Repair table (Repair adapter)
                    daServiceOrder.Update(record); // Call update method on the Repair adapter so it updates the table in memory ( All changes made are applied - CRUD)
                    RepairsDataSet.AcceptChanges(); // Call accept method on the dataset so it update the chanmges to the database
                    Label1.Text = "&#10004; Record deleted";
                    //Refresh the page to show the record being deleted
                    Response.Redirect(Request.RawUrl);

                }
                catch
                {
                    Label1.Text = "&#x274C; Record not deleted";
                    this.Label1.ForeColor = Color.Red;

                }
            }
        }

        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e) // Method adding the btns to the table
        {
            try // if the table has no row
            {
                if (e.Row.RowIndex == -1)
                {
                    e.Row.Cells[5].Text = String.Empty;
                    //Clear the header for Detail Edit Delete btn
                    return;  //skip the header
                }

                //this.GridView1.HeaderRow.Cells[0].Visible = false;
                //e.Row.Cells[0].Visible = false;

                //delete Btn
                Button btnDetail = new Button();  //create detail btn
                btnDetail.CssClass = "btn btn-info";  //set css class
                btnDetail.Text = "Detail";
                btnDetail.Attributes.Add("aria-label", "Click to go to the detail page for this sale");
                btnDetail.ToolTip = "Details";
                btnDetail.Click += new EventHandler(btnDetail_Click);// Set button click event
                e.Row.Cells[5].Controls.Add(btnDetail);  //add the btn


                // Edit btn
                Button btnEdit = new Button();  //create edit btn
                btnEdit.CssClass = "btn btn-dark";  //set css class
                btnEdit.Text = "Edit";
                btnEdit.Attributes.Add("aria-label", "Click to go to the edit page for this sale");
                btnEdit.ToolTip = "Edit";
                btnEdit.Click += new EventHandler(btnEdit_Click);// Set button click event
                e.Row.Cells[5].Controls.Add(btnEdit);  //add the btn



                // Delete btn
                Button btnDelete = new Button();  //create delete btn
                btnDelete.CssClass = "btn btn-danger";  //set css class
                btnDelete.Text = "Delete";
                btnDelete.Attributes.Add("aria-label", "Click to delete this sale");
                btnDelete.ToolTip = "Delete";
                btnDelete.OnClientClick = "return confirm('Do you want to delete it? Click OK to proceed.');"; // client side call
                btnDelete.Click += new EventHandler(btnDelete_Click);// Set button click event
                e.Row.Cells[5].Controls.Add(btnDelete);  //add the btn
            }
            catch
            {
                this.Label1.Text = "No reecords Found";
            }


        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (RepairsDataSet.RepairLookUp.Count > 0)
            {
                string criteria = FilterCriteria();
                // Save the criteria in the session, so that when filtered the rows contains the filtered records instead of the fresh table
                Session["RepairCriteria"] = FilterCriteria();
                rows = (criteria.Length > 0) ? RepairsDataSet.RepairLookUp.Select(criteria) : RepairsDataSet.RepairLookUp.Select(); // Data satisfying the conditions is saved in rows
                DisplayRepairTable();
            }
            else
            {
                this.Label1.Text = "No Records Matching The Filter Was Found";
                this.Label1.ForeColor = Color.Red;

            }
        }

        //Display Method to fill tables
        private void DisplayRepairTable()
        {
            // no record after filter
            if (rows.Length == 0)
            {

                this.Label1.Text = "&#x274C; No reecords Found";
                this.Label1.ForeColor = Color.Red;
            }

            this.Label1.Text = "Records Found : " + rows.Length;
            DataTable dt = new DataTable();
            dt.Columns.Add("DateIn");
            dt.Columns.Add("DateOut");
            dt.Columns.Add("Issue");
            dt.Columns.Add("InWarrenty");
            dt.Columns.Add("Equipment");
            dt.Columns.Add(""); // column for Edit and Delete btn


            DataRow dr = dt.NewRow();


            foreach (DataRow r in rows) // loop through the static DataRow[] row since the records from filter are saved in them.
            {
                DataRow nr = dt.NewRow();
                nr[0] = Convert.ToDateTime(r.ItemArray[7].ToString()).ToShortDateString();
                nr[1] = Convert.ToDateTime(r.ItemArray[8].ToString()).ToShortDateString();
                nr[2] = r.ItemArray[1].ToString();
                if (r.ItemArray[2].ToString() == "True")
                    nr[3] = "Yes";
                else
                    nr[3] = "No";
                nr[4] = r.ItemArray[6].ToString();

                dt.Rows.Add(nr);
            }

            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }


        // Filter criteria
        private string FilterCriteria()
        {
            string criteria = "";

            criteria = (this.txtDateIn.Text.Length > 0) ? " DateIn = '" + this.txtDateIn.Text + "'" : "";


            criteria += (this.txtDateOut.Text.Length > 0 && criteria.Length > 0) ? "and DateOut ='" + this.txtDateOut.Text + "'"
                 : (this.txtDateOut.Text.Length > 0) ? "DateOut ='" + this.txtDateOut.Text + "' " : "";


            criteria += (this.ddlServices.Text != "None" && criteria.Length > 0) ? "And id = " + this.ddlServices.SelectedValue.ToString()
               : (this.ddlServices.Text != "None") ? "id = " + this.ddlServices.SelectedValue.ToString() : "";


            criteria += (this.ddlEquipments.Text != "None" && criteria.Length > 0) ? "And equipID = " + this.ddlEquipments.SelectedValue.ToString()
               : (this.ddlEquipments.Text != "None") ? "equipID = " + this.ddlEquipments.SelectedValue.ToString() : "";


            criteria += (this.ddlEmployee.Text != "None" && criteria.Length > 0) ? "And empID = " + this.ddlEmployee.SelectedValue.ToString()
            : (this.ddlEmployee.Text != "None") ? "empID = " + this.ddlEmployee.SelectedValue.ToString() : "";


            criteria += (this.ddlCustomer.Text != "None" && criteria.Length > 0) ? "And cusID = " + this.ddlCustomer.SelectedValue.ToString()
            : (this.ddlCustomer.Text != "None") ? "cusID = " + this.ddlCustomer.SelectedValue.ToString() : "";

            criteria += (this.radNoWarranty.Checked && criteria.Length > 0) ? "And serordWarranty =" + 0
           : (this.radNoWarranty.Checked) ? "serordWarranty =" + 0 : "";

            criteria += (this.radInWarranty.Checked && criteria.Length > 0) ? "And serordWarranty =" + 1
          : (this.radInWarranty.Checked) ? "serordWarranty =" + 1 : "";


            return criteria;
        }

        
    }
}