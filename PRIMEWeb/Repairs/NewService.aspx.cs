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
                DataRow service = RepairsDataSet.AllserviceData.NewRow();
                //update record with user's input
                service[1] = this.txtName.Text;
                service[2] = this.txtDescription.Text;
                service[3] = this.txtPrice.Text;
                RepairsDataSet.AllserviceData.Rows.Add(service);


                AllserviceDataTableAdapter daService = new AllserviceDataTableAdapter();
                daService.Update(service);
                RepairsDataSet.AcceptChanges();

                //Refresh the page to show the record being deleted
                Response.Redirect(Request.RawUrl);
                Label1.Text = "Created";
            }
            catch
            {
                Label1.Text = "Failed";

            }


        }
                                                                                            
        private void Save()
        {
            AllserviceDataTableAdapter daservices = new AllserviceDataTableAdapter();

            try
            {
                daservices.Update(RepairsDataSet.AllserviceData);
                RepairsDataSet.AcceptChanges();
                this.Label1.Text = "saved";
            }
            catch
            {
                RepairsDataSet.RejectChanges();
                this.Label1.Text = "not saved";

            }
            finally
            {
                Clear();
            }
        }

        private void Clear()
        {
            this.txtName.Text = "";
            this.txtDescription.Text = "";
            this.txtPrice.Text = "";
        }
    }
}