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
    public partial class EditService : System.Web.UI.Page
    {

        static RepairsDataSet repairsDataSet;
        // private static DataRow[] rows;

        static EditService()
        {
            repairsDataSet = new RepairsDataSet();

        }

        private static int id = -1;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)  //if not logged in
                Response.Redirect("/");

            if (Request.Cookies["ID"] != null) // Request the cookies which contaions the ID Of thr record that was carried over from the index page
                Label1.Text = Request.Cookies["ID"].Value;

            id = Convert.ToInt32(Request.Cookies["ID"].Value);

            if (!IsPostBack)
                if (id != -1)
                {


                    try
                    {
                        serviceTableAdapter daservices = new serviceTableAdapter();
                        daservices.Fill(repairsDataSet.service);

                        DataRow Service = repairsDataSet.service.FindByid(id); // Find the related Record and fill the fields in the page with the data

                        if (Service != null)
                        {
                            this.txtName.Text = Service.ItemArray[1].ToString();
                            this.txtDescription.Text = Service.ItemArray[2].ToString();
                            this.txtPrice.Text = Service.ItemArray[3].ToString();

                        }
                        else
                        {
                            this.Label1.Visible = true;
                            Label1.Text = "Please Try Again";

                        }
                    }
                    catch
                    {
                        this.Label1.Visible = true;
                        Label1.Text = "&#x274C; Database Eror, Contact System Administrator";

                    }
                }
                else
                {
                    Servicevalidation();
                }



        }


        //Edit Button click
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //check a record has been selected
            if (id != -1 && Servicevalidation())
            {
                DataRow record = repairsDataSet.service.FindByid(id); // find the related Record



                try
                {
                    //update record with user's input
                    record[1] = this.txtName.Text;
                    record[2] = this.txtDescription.Text;
                    record[3] = Convert.ToDecimal(this.txtPrice.Text);
                    serviceTableAdapter daservice = new serviceTableAdapter();
                    daservice.Update(record); // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
                    repairsDataSet.AcceptChanges(); // Call accept method on the dataset so it update the chanmges to the database

                    this.Label1.Visible = true;
                    Label1.Text = "&#10004; Record Successfully Updated";
                    //  Response.Redirect("Services.aspx"); // Redirect the user to Edit page on btn click

                }
                catch
                {
                    this.Label1.ForeColor = Color.Red;
                    this.Label1.Visible = true;
                    Label1.Text = "&#x274C; Record Updation Failed";
                }


            }
        }

        //protected void cboHelp_CheckedChanged(object sender, EventArgs e)
        //{
        //    lblServiceDescription.Visible = lblServiceName.Visible = lblServicePrice.Visible
        //      = cboHelp.Checked;
        //}

        //method to validate fields
        private bool Servicevalidation()
        {
            bool control = true;

            if (!System.Text.RegularExpressions.Regex.IsMatch(Math.Round(Convert.ToDecimal(this.txtPrice.Text)).ToString(), "^[0-9]*$"))
            {
                this.lblPriceVal.Visible = true;
                this.lblPriceVal.Text = "* Please Enter a number (Eg: $24)";
                control = false;

            }
            else
            {
                this.lblPriceVal.Visible = false;
            }



            if (control == true)
            {
                this.Label1.Visible = false;
            }

            return control;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("/");
        }
    }
}