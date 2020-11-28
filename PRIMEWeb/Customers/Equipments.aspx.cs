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

        static Equipments()
        {
            dsEquipment = new EquipmentDataSet();
            equipmentTableAdapter daEquipment = new equipmentTableAdapter();
            //customerTableAdapter daCustomer = new customerTableAdapter();
            //manufacturerTableAdapter daManufacturer = new manufacturerTableAdapter();
            //equip_typeTableAdapter daType = new equip_typeTableAdapter();

            try
            {
                daEquipment.Fill(dsEquipment.equipment);
                //daCustomer.Fill(dsEquipment.customer);
                //daManufacturer.Fill(dsEquipment.manufacturer);
                //daType.Fill(dsEquipment.equip_type);
            }
            catch { }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Model");
            dt.Columns.Add("Serial");
            dt.Columns.Add("Customer");
            dt.Columns.Add("Type");
            dt.Columns.Add("Manufacturer");

            foreach (DataRow r in dsEquipment.equipment)
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
    }
}