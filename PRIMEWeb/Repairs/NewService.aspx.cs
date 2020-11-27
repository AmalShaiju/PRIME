using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using PRIMELibrary;
using PRIMELibrary.EmmasDataSetTableAdapters;

namespace PRIMEWeb.Repairs
{
    public partial class NewService : System.Web.UI.Page
    {

        static EmmasDataSet dsEmmmas = new EmmasDataSet();
        private static DataRow[] rows;


        static NewService()
        {

            AllserviceDataTableAdapter daservices = new AllserviceDataTableAdapter();

            try
            {
                daservices.Fill(dsEmmmas.AllserviceData);
            }
            catch { }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            DataRow service = dsEmmmas.AllserviceData.NewRow();
            //update record with user's input
            service[1] = this.txtName.Text; 
            service[2] = this.txtDescription.Text;
            service[3] = this.txtPrice.Text;
            dsEmmmas.AllserviceData.Rows.Add(service);
            Save();
           
        }
                                                                                            
        private void Save()
        {
            AllserviceDataTableAdapter daservices = new AllserviceDataTableAdapter();

            try
            {
                daservices.Update(dsEmmmas.AllserviceData);
                dsEmmmas.AcceptChanges();
                this.Label1.Text = "saved";
            }
            catch
            {
                dsEmmmas.RejectChanges();
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