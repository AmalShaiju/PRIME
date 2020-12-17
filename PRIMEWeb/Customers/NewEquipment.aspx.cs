using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRIMELibrary.EquipmentDataSetTableAdapters;
using PRIMELibrary;

namespace PRIMEWeb.Customers
{
    public partial class NewEquipment : System.Web.UI.Page
    {
        static EquipmentDataSet dsEquipment = new EquipmentDataSet();
        
        static NewEquipment()
        {
            equipmentCRUDTableAdapter daEquipment = new equipmentCRUDTableAdapter();

            try
            {
                daEquipment.Fill(dsEquipment.equipmentCRUD);
            }
            catch { }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            DataRow equipment = dsEquipment.equipmentCRUD.NewRow();

            //update record with user's input
            equipment[1] = this.txtModel.Text;
            equipment[2] = this.txtSerialNum.Text;
            equipment[3] = Convert.ToInt32(this.ddlCustomer.SelectedValue);
            equipment[4] = Convert.ToInt32(this.ddlType.SelectedValue);
            equipment[5] = Convert.ToInt32(this.ddlManufacturer.SelectedValue);
            dsEquipment.equipmentCRUD.Rows.Add(equipment);
            Save();
        }

        private void Save()
        {
            equipmentCRUDTableAdapter daEquipment = new equipmentCRUDTableAdapter();

            try
            {
                daEquipment.Update(dsEquipment.equipmentCRUD);
                dsEquipment.AcceptChanges();
                this.lblStatus.Text = "Equipment Created";
                Clear();
            }
            catch
            {
                dsEquipment.RejectChanges();
                this.lblStatus.Text = "Failed";
            }
        }

        private void Clear()
        {
            this.txtModel.Text = "";
            this.txtSerialNum.Text = "";
            this.ddlCustomer.SelectedIndex = 0;
            this.ddlManufacturer.SelectedIndex = 0;
            this.ddlType.SelectedIndex = 0;
        }

        protected void cboHelp_CheckedChanged(object sender, EventArgs e)
        {
            lblCustomer.Visible = lblManufacturer.Visible = lblModelHelp.Visible =
            lblSerialHelp.Visible = lblType.Visible =
            pnlEquipmentsHelp.Visible = cboHelp.Checked;
        }
    }
}