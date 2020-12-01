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
    public partial class WarrantyReport : System.Web.UI.Page
    {
        // Static Dataset so all users see the same data ( IF some one deletes one record everyone sees that change )
        static RepairsDataSet RepairsDataSet;
        private static DataRow[] rows; // Data rows to load more than one record ( doesnt need to be static ) // Not Sure

        static WarrantyReport()
        {
            RepairsDataSet = new RepairsDataSet();
            DetailWarrantyLookUpTableAdapter daWarrenty = new DetailWarrantyLookUpTableAdapter();


            try
            {
                daWarrenty.Fill(RepairsDataSet.DetailWarrantyLookUp);
            }
            catch { }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            //refresh the dataset, so the newly created record is shown in index
            DetailWarrantyLookUpTableAdapter daWarrenty = new DetailWarrantyLookUpTableAdapter();
            RepairsDataSet.Reset();
            daWarrenty.Fill(RepairsDataSet.DetailWarrantyLookUp);

            rows = RepairsDataSet.DetailWarrantyLookUp.Select(); //get records
            DisplayWarrentyeTable();
        }

        // Filter Search btn 
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string criteria = FilterCriteria();
            rows = (criteria.Length > 0) ? RepairsDataSet.DetailWarrantyLookUp.Select(criteria) : RepairsDataSet.DetailWarrantyLookUp.Select(); // Data satisfying the conditions is saved in rows
            DisplayWarrentyeTable();
        }


        // Filter criteria
        private string FilterCriteria()
        {
            string criteria = "";

            criteria = (this.txtFromDate.Text.Length > 0) ? " serordDateIn >= '" + this.txtFromDate.Text + "'" : "";

            criteria += (this.txtToDate.Text.Length > 0 && criteria.Length > 0) ? "and serordDateIn <='" + this.txtToDate.Text + "'"
                : (this.txtToDate.Text.Length > 0) ? "serordDateIn ='" + this.txtToDate.Text + "' " : "";

            criteria += (this.ddlManufacturer.Text != "None" && criteria.Length > 0) ? "And ManID=" + this.ddlManufacturer.SelectedValue.ToString()
            : (this.ddlManufacturer.Text != "None") ? "ManID=" + this.ddlManufacturer.SelectedValue.ToString() : "";

            return criteria;
        }

        //Display Method to fill tables
        private void DisplayWarrentyeTable()
        {
            this.Label1.Text = "ready";

            //HyperLinkField hp = new HyperLinkField();
            //hp.Text = "Edit";
            //hp.NavigateUrl = "~/Default.aspx";
            //hp  .Visible = true;

            DataTable dt = new DataTable();
            dt.Columns.Add("Manufacturer");
            dt.Columns.Add("Type");
            dt.Columns.Add("Model");
            dt.Columns.Add("Serial"); 
            dt.Columns.Add("Issue"); 
            dt.Columns.Add("Price");


            DataRow dr = dt.NewRow();


            foreach (DataRow r in rows) // loop through the static DataRow[] row since the records from filter are saved in them.
            {
                DataRow nr = dt.NewRow();
                nr[0] = r.ItemArray[0].ToString();
                nr[3] = r.ItemArray[2].ToString();
                nr[2] = r.ItemArray[1].ToString();
                nr[1] = r.ItemArray[3].ToString();
                nr[4] = r.ItemArray[4].ToString();
                nr[5] = r.ItemArray[5].ToString();

                dt.Rows.Add(nr);
                //this.GridView1.Columns.Add(hp);
            }

            this.DetailGrid.DataSource = dt;
            this.DetailGrid.DataBind();
        }

       
    }
}