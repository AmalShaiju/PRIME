using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using PRIMELibrary;
using PRIMELibrary.EquipmentDataSetTableAdapters;

namespace PRIMEWeb.Customers
{
    public partial class Equipments : System.Web.UI.Page
    {
        private static EquipmentDataSet dsEquipment;
        private static DataRow[] rows;
        private static bool flag = false; //indicate if the data loading failed
        private static int id = -1;
        static Equipments()
        {
            try
            {
                dsEquipment = new EquipmentDataSet();
                equipmentTableAdapter daEquipment = new equipmentTableAdapter();
                daEquipment.Fill(dsEquipment.equipment);
            }
            catch
            {
                flag = true; //loading failed
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (flag)
            {
                return;
            }

            //data loaded successfully

            //string criteria = GetEquipmentCriteria();
            rows = (Session["criteria"] != null) ? dsEquipment.equipment.Select(Session["criteria"].ToString())  //has criteria
                : dsEquipment.equipment.Select();  //select all
            DisplayEquipment();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (dsEquipment.equipment.Count > 0)
            {
                Session["criteria"] = GetEquipmentCriteria();
                rows = (Session["criteria"] != null) ? dsEquipment.equipment.Select(Session["criteria"].ToString()) : dsEquipment.equipment.Select();
                DisplayEquipment();
            }
            else
                this.lblStatus.Text = "No Equipment Records";
            this.lblSave.Text = "Ready";
            
        }

        //display
        private void DisplayEquipment()
        {
            this.gvEquipment.DataSource = null;
            this.gvEquipment.DataBind();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Model");
            dt.Columns.Add("Serial");
            dt.Columns.Add("Customer");
            dt.Columns.Add("Type");
            dt.Columns.Add("Manufacturer");
            dt.Columns.Add();

            foreach (DataRow r in rows)
            {
                DataRow record = dt.NewRow();
                record[0] = r.ItemArray[0].ToString();
                record[1] = r.ItemArray[1].ToString();
                record[2] = r.ItemArray[2].ToString();
                record[3] = r.ItemArray[6].ToString();
                record[4] = r.ItemArray[8].ToString();
                record[5] = r.ItemArray[7].ToString();
                dt.Rows.Add(record);
            }

            this.gvEquipment.DataSource = dt;
            this.gvEquipment.DataBind();

            lblStatus.Text = "Search Results: " + ((rows.Length > 0) ? rows.Length.ToString() : "0");
        }

        //criteria
        private string GetEquipmentCriteria()
        {
            string criteria = "";
            criteria = (this.txtModel.Text.Length > 0) ? "Model Like '%" + this.txtModel.Text + "%'" : "";
            criteria += (this.txtSerialNum.Text.Length > 0 && criteria.Length > 0) ? "And Serial Like '%" + this.txtSerialNum.Text + "%'"
                : (this.txtSerialNum.Text.Length > 0) ? "Serial Like '%" + this.txtSerialNum.Text + "%'" : "";
            criteria += (this.ddlCustomer.Text != "None" && criteria.Length > 0) ? "And CustomerID = " + this.ddlCustomer.SelectedValue.ToString()
                : (this.ddlCustomer.Text != "None") ? "CustomerID = " + this.ddlCustomer.SelectedValue.ToString() : "";
            criteria += (this.ddlType.Text != "None" && criteria.Length > 0) ? "And EquipmentID = " + this.ddlType.SelectedValue.ToString()
                : (this.ddlType.Text != "None") ? "EquipmentID = " + this.ddlType.SelectedValue.ToString() : "";
            criteria += (this.ddlManufacturer.Text != "None" && criteria.Length > 0) ? "And ManufacturerID = " + this.ddlManufacturer.SelectedValue.ToString()
                : (this.ddlManufacturer.Text != "None") ? "ManufacturerID = " + this.ddlManufacturer.SelectedValue.ToString() : "";
            return criteria;
        }

        protected void gvEquipment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == -1)
            {
                e.Row.Cells[6].Text = String.Empty;
                //Clear the header for Edit btn
                return;  //skip the header
            }

            //hiding id column
            this.gvEquipment.HeaderRow.Cells[0].Visible = false;
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[6].Attributes["width"] = "205px";


            //edit btn
            HtmlButton btnEdit = new HtmlButton();  //create edit btn
            btnEdit.Attributes.Add("class","btn btn-dark");  //set css class
            btnEdit.InnerText = "Edit";
            btnEdit.Attributes.Add("value", e.Row.Cells[0].Text);
            btnEdit.Attributes.Add("aria-label", "Click to go to the edit page for this equipment");//set aria label
            btnEdit.ServerClick += new EventHandler(btnEdit_Click);  //click event handler
            e.Row.Cells[6].Controls.Add(btnEdit);  //add the btn

            //delete btn
            HtmlButton btnDelete = new HtmlButton();  //create delete btn
            btnDelete.Attributes.Add("class", "btn btn-danger");  //set css class
            btnDelete.InnerText = "Delete";
            btnDelete.Attributes.Add("value", e.Row.Cells[0].Text);
            btnDelete.Attributes.Add("aria-label", "Click to delete this equipment");//set aria label
            btnDelete.ServerClick += new EventHandler(btnDelete_Click);  //click event handler
            e.Row.Cells[6].Controls.Add(btnDelete);  //add the btn
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
                    DataRow record = dsEquipment.equipment.FindByID(id); // Find and add the record to tbe record variable
                    record.Delete(); // Deletes the record in memory

                    equipmentCRUDTableAdapter daEquipmentCRUD = new equipmentCRUDTableAdapter(); // table adapter to service table (Service adapter)
                    daEquipmentCRUD.Update(record); // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
                    dsEquipment.AcceptChanges(); // Call accept method on the dataset so it update the chanmges to the database
                    //Refresh the page to show the record being deleted
                    lblSave.Text = "Record deleted";
                    Response.Redirect(Request.RawUrl);
                }
                catch
                {
                    lblSave.Text = "Record not deleted";
                }
            }
        }

        // Edit btn 
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            HtmlButton btnDelete = (HtmlButton)sender;
            id = Convert.ToInt32(btnDelete.Attributes["value"]);

            //Send Id using cookie
            HttpCookie cID = new HttpCookie("ID"); // Cokkie variable named cID to hold a value 
            cID.Value = id.ToString();
            Response.Cookies.Add(cID);
            Response.Redirect("EditEquipment.aspx"); // Redirect the user to Edit page on btn click
        }
    }
}