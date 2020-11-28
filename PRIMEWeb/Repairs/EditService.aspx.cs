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
    public partial class EditService : System.Web.UI.Page
    {

        static RepairsDataSet repairsDataSet;
       // private static DataRow[] rows;


        static EditService()
        {
            repairsDataSet = new RepairsDataSet();
            AllserviceDataTableAdapter daservices = new AllserviceDataTableAdapter();

            try
            {
                daservices.Fill(repairsDataSet.AllserviceData);
            }
            catch { }
        }


        private static int id = -1;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["ID"] != null) // Reuest the cookies which contaions the ID Of thr record that was carried over from the index page
                Label1.Text = Request.Cookies["ID"].Value;

            id = Convert.ToInt32(Request.Cookies["ID"].Value);
            
            if(id != 1)
            {
                try
                {
                    DataRow Service = repairsDataSet.AllserviceData.FindByid(id); // Find the related Record and fill the fields in the page with the data

                    if (Service != null)
                    {
                        this.txtName.Text = Service.ItemArray[1].ToString();
                        this.txtDescription.Text = Service.ItemArray[2].ToString();
                        this.txtPrice.Text = Service.ItemArray[3].ToString();

                    }
                    else
                    {
                        this.Clear();
                        Label1.Text = "Please Try Again";

                    }
                }
                catch
                {
                    Label1.Text = "Database Error";

                }
            }



        }


        //Edit Button click
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //check a record has been selected
            if (id != -1)
            {
              
                try
                {
                    DataRow sevice = repairsDataSet.AllserviceData.FindByid(id); // find the related Record

                    //update record with user's input
                    sevice[1] = this.txtName.Text;
                    sevice[2] = this.txtDescription.Text;
                    sevice[3] = Convert.ToDecimal(this.txtPrice.Text);

                    AllserviceDataTableAdapter daservice = new AllserviceDataTableAdapter();
                    daservice.Update(sevice); // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
                    repairsDataSet.AcceptChanges(); // Call accept method on the dataset so it update the chanmges to the database

                    Label1.Text = "Record Successfully Updated";
                }
                catch { Label1.Text = "Unable to Update Record"; }


                //try
                //{
                //    //retrieve the record from Dataset Service table
                //    DataRow Service = repairsDataSet.AllserviceData.FindByid(id);
                //    AllserviceDataTableAdapter daservice = new AllserviceDataTableAdapter();


                //    //update record with user's input
                //    repairsDataSet.AllserviceData.FindByid(id).serName = this.txtName.Text;
                //    repairsDataSet.AllserviceData.FindByid(id).serDescription = this.txtDescription.Text;
                //    repairsDataSet.AllserviceData.FindByid(id).serPrice = Convert.ToDecimal(this.txtPrice.Text);

                //    daservice.Update(repairsDataSet.AllserviceData);
                //    repairsDataSet.AcceptChanges();

                //    //save back to the database
                //   // Save();
                //}
               // catch { Label1.Text = "Unable to Update Record"; }
            }
        }

        // Uopdate/Cretea Method
        //private void Save()
        //{
        //    AllserviceDataTableAdapter daservice= new AllserviceDataTableAdapter();

        //    try
        //    {
        //        daservice.Update(repairsDataSet.AllserviceData);
        //        repairsDataSet.AcceptChanges();
        //        this.Label1.Text = "saved";
        //    }
        //    catch
        //    {
        //        repairsDataSet.RejectChanges();
        //        this.Label1.Text = "not saved";

        //    }
        //    finally
        //    {
        //        Clear();
        //    }
        //}


        private void Clear()
        {
            this.txtName.Text = "";
            this.txtDescription.Text = "";
            this.txtPrice.Text = "";
        }

    }
}