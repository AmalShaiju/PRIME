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
    public partial class NewService : System.Web.UI.Page
    {

        static RepairsDataSet RepairsDataSet;
        //private static DataRow[] rows;
        private static bool flag = false;


        static NewService()
        {
            RepairsDataSet = new RepairsDataSet();
            serviceTableAdapter daservices = new serviceTableAdapter();

            try
            {
                daservices.Fill(RepairsDataSet.service);
            }
            catch 
            {
                flag = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (flag)
            {
                this.Label1.Visible = true;
                this.Label1.Text = "Database Error, Please Contact The system Administrator";
                this.Label1.ForeColor = Color.Red;
            }

            if (IsPostBack)
            {
                Servicevalidation();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if(Servicevalidation())
                try
                {
                    DataRow service = RepairsDataSet.service.NewRow(); // Create a new row of service table in memory
                    //update record with user's input
                    service[1] = this.txtName.Text;
                    service[2] = this.txtDescription.Text;
                    service[3] = this.txtPrice.Text;
                    RepairsDataSet.service.Rows.Add(service); // add the rows to the dataset


                    serviceTableAdapter daService = new serviceTableAdapter();
                    daService.Update(service); // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
                    RepairsDataSet.AcceptChanges();// Call accept method on the dataset so it update the chanmges to the database

                    //Refresh the page to show the record being deleted
                    // Response.Redirect("Services.aspx"); // Redirect the user to dexpage on to show created data
                    this.Label1.Visible = true;
                    this.Label1.Text = "&#10004; Record Successfully Created";
                    this.Label1.ForeColor = Color.Green;

                }
                catch
                {
                    this.Label1.Visible = true;
                    this.Label1.Text = "&#x274C; Record Creation Failed";
                    this.Label1.ForeColor = Color.Red;


                }


        }

      

        //method to validate fields
        private bool Servicevalidation()
        {
            bool control = true;
            if (this.txtPrice.Text != "")
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(Math.Round(Convert.ToDecimal(this.txtPrice.Text)).ToString(), "^[0-9]*$"))
                {
                    this.lblPriceVal.Visible = true;
                    this.lblPriceVal.Text = "*  Please Enter a number (Eg: $24)";
                    control = false;

                }
                else
                {
                    this.lblPriceVal.Visible = false;
                }
            }

            if (control == true)
            {
                this.Label1.Visible = false;
            }

            return control;
        }

        protected void cboHelp_CheckedChanged(object sender, EventArgs e)
        {
            this.lblServiceName.Visible = this.lblServiceDesc.Visible = this.lblServicePrice.Visible = cboHelp.Checked;
        }
    }
}