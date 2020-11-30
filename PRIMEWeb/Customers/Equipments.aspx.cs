using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
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
        private static List<Button> btnEdits = new List<Button>(); //list of the edit btns
        private static List<Button> btnDeletes = new List<Button>(); //list of the delete btns

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

            rows = dsEquipment.equipment.Select(); //get records
            DisplayEquipment();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (dsEquipment.equipment.Count > 0)
            {
                string criteria = GetEquipmentCriteria();
                rows = (criteria.Length > 0) ? dsEquipment.equipment.Select(criteria) : dsEquipment.equipment.Select();
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
            dt.Columns.Add("Model");
            dt.Columns.Add("Serial");
            dt.Columns.Add("Customer");
            dt.Columns.Add("Type");
            dt.Columns.Add("Manufacturer");
            dt.Columns.Add();

            foreach (DataRow r in rows)
            {
                DataRow record = dt.NewRow();
                record[0] = r.ItemArray[1].ToString();
                record[1] = r.ItemArray[2].ToString();
                record[2] = r.ItemArray[6].ToString();
                record[3] = r.ItemArray[8].ToString();
                record[4] = r.ItemArray[7].ToString();
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
                e.Row.Cells[5].Text = String.Empty;
                //Clear the header for Edit btn
                return;  //skip the header
            }

            //edit btn
            Button btnEdit = new Button();  //create edit btn
            btnEdits.Add(btnEdit);  //the list index of the button will also be the row index
            btnEdit.CssClass = "btn btn-dark";  //set css class
            btnEdit.Text = "Edit";
            btnEdit.Attributes.Add("aria-label", "Click to go to the edit page for this sale");
            //set aria label
            btnEdit.Attributes.Add("OnClick", "btnEdit_Click");  //click event handler
            btnEdit.CommandName = "EditRow";
            e.Row.Cells[5].Controls.Add(btnEdit);  //add the btn

            //delete btn
            Button btnDelete = new Button();  //create delete btn
            btnDeletes.Add(btnDelete);  //the list index of the button will also be the row index
            btnDelete.CssClass = "btn btn-danger";  //set css class
            btnDelete.Text = "Delete";
            btnDelete.Attributes.Add("aria-label", "Click to delete this sale");//set aria label
            btnDelete.Attributes.Add("OnClick", "btnDelete_Click");  //click event handler
            //btnDelete.CommandName = "DeleteRow";
            //btnDelete.CommandArgument = "<%# ((GridViewRow) Container).RowIndex %>";
            //btnDelete.CommandArgument = "<%# ((GridViewRow) Container).RowIndex %>";
            //ID="addbtn" runat="server"  Text="save" CommandName="SAVE" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"

            ////if (not admin)
            //btnDelete.Visible = false;
            //btnDelete.Enabled = false;

            e.Row.Cells[5].Controls.Add(btnDelete);  //add the btn
            e.Row.Cells[5].Attributes["width"] = "205px";
        }

        //protected void gvCustomers_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "DeleteRow")
        //    {
        //        int index = Convert.ToInt32(e.CommandArgument);
        //        //string deltequer = "delete from yourtablename where id='" + id + "'";
        //        //lblSave.Text = "Index: " + index.ToString() + "; ID: " + id.ToString();
        //        lblSave.Text = "INDEX " + index.ToString();
        //    }
        //    else if (e.CommandName == "EditRow")
        //    {

        //    }
        //}
    }
}