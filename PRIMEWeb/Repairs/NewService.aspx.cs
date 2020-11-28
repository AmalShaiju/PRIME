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
    public partial class NewService : System.Web.UI.Page
    {

        static RepairsDataSet RepairsDataSet;
        //private static DataRow[] rows;


        static NewService()
        {
            RepairsDataSet = new RepairsDataSet();
            AllserviceDataTableAdapter daservices = new AllserviceDataTableAdapter();

            try
            {
                daservices.Fill(RepairsDataSet.AllserviceData);
            }
            catch { }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow service = RepairsDataSet.AllserviceData.NewRow(); // Create a new row of service table in memory
                //update record with user's input
                service[1] = this.txtName.Text;
                service[2] = this.txtDescription.Text;
                service[3] = this.txtPrice.Text;
                RepairsDataSet.AllserviceData.Rows.Add(service); // add the rows to the dataset


                AllserviceDataTableAdapter daService = new AllserviceDataTableAdapter();
                daService.Update(service); // Call update method on the service adapter so it updates the table in memory ( All changes made are applied - CRUD)
                RepairsDataSet.AcceptChanges();// Call accept method on the dataset so it update the chanmges to the database

                //Refresh the page to show the record being deleted
                Response.Redirect("Services.aspx"); // Redirect the user to dexpage on to show created data

                Label1.Text = "Created";
            }
            catch
            {
                Label1.Text = "Failed";

            }


        }
          
        // Usse this code if the page has multiple places updating the data
        //private void Save()
        //{
        //    AllserviceDataTableAdapter daservices = new AllserviceDataTableAdapter();

        //    try
        //    {
        //        daservices.Update(RepairsDataSet.AllserviceData);
        //        RepairsDataSet.AcceptChanges();
        //        this.Label1.Text = "saved";
        //    }
        //    catch
        //    {
        //        RepairsDataSet.RejectChanges();
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