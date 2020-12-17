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
    public partial class Details : System.Web.UI.Page
    {
        static RepairsDataSet repairsDataSet;

        static Details()
        {
            repairsDataSet = new RepairsDataSet();


        }
        private static int id = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["ID"] != null) // Request the cookies which contaions the ID Of thr record that was carried over from the index page

                id = Convert.ToInt32(Request.Cookies["ID"].Value);


            if (Session["editRedirect"] != null)
            {
                this.redirectMsg.Text = "&#10004; Record Successfully Updated";
            }
            if (Session["createRedirect"] != null)
            {
                this.redirectMsg.Text = "&#10004; Record Successfully Created";
            }


            if (id != -1)
            {
                try
                {
                    RepairLookUpTableAdapter daRepair = new RepairLookUpTableAdapter();
                    daRepair.Fill(repairsDataSet.RepairLookUp);

                    DataRow record = repairsDataSet.RepairLookUp.FindByid(id); // Find the related Record and fill the fields in the page with the data

                    if (record != null)
                    {
                        this.lblDateIn.Text = Convert.ToDateTime(record.ItemArray[7].ToString()).ToShortDateString();
                        this.lblDateOut.Text = Convert.ToDateTime(record.ItemArray[8].ToString()).ToShortDateString();
                        this.lblssue.Text = record.ItemArray[1].ToString();
                        if (record.ItemArray[2].ToString() == "False")
                            this.lblWarranty.Text = "&#x274C;";
                        else
                            this.lblWarranty.Text = "&#10004;";
                        this.lblService.Text = record.ItemArray[3].ToString();
                        this.lblEmployee.Text = record.ItemArray[5].ToString();

                        this.lblEquipmentType.Text = record.ItemArray[6].ToString();
                        this.lblEquipmentModel.Text = record.ItemArray[10].ToString();
                        this.lblEquipmentSerial.Text = record.ItemArray[11].ToString();
                        this.lblEquipmentManufacturer.Text = record.ItemArray[19].ToString();

                        this.lblCustomerFirst.Text = record.ItemArray[12].ToString();
                        this.lblCustomerLast.Text = record.ItemArray[14].ToString();
                        this.lblCustomerPhone.Text = record.ItemArray[13].ToString();
                        this.lblCustomerEmail.Text = record.ItemArray[18].ToString();
                        this.lblCustomerAddress.Text = record.ItemArray[15].ToString();
                        this.lblCustomerCity.Text = record.ItemArray[16].ToString();
                        this.lblCustomerPostal.Text = record.ItemArray[17].ToString();

                    }
                    else
                    {
                        // this.Clear();
                        Label1.Text = "&#x274C; 5Please Try Again";

                    }
                }
                catch
                {
                    Label1.Text = "&#x274C; Database Eror, Contact System Administrator";

                }
            }

        }
    }
}