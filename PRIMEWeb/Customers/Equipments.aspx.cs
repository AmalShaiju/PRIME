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
            customerTableAdapter daCustomer = new customerTableAdapter();
            equipmentTableAdapter daEquipment = new equipmentTableAdapter();
            manufacturerTableAdapter daManufacturer = new manufacturerTableAdapter();
            equip_typeTableAdapter daType = new equip_typeTableAdapter();

            try
            {
                daCustomer.Fill(dsEquipment.customer);
                daEquipment.Fill(dsEquipment.equipment);
                daManufacturer.Fill(dsEquipment.manufacturer);
                daType.Fill(dsEquipment.equip_type);
            }
            catch { }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
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
            this.lstResults.Items.Clear();
            //this.Clear();
            foreach (DataRow row in rows)
                this.lstResults.Items.Add(row.ItemArray[0].ToString() + ' ' + row.ItemArray[1].ToString()
                    + ' ' + row.ItemArray[2].ToString() + ' ' + row.ItemArray[3].ToString()
                    + ' ' + row.ItemArray[4].ToString() + ' ' + row.ItemArray[5].ToString());
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