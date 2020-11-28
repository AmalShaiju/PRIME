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
    public partial class Services : System.Web.UI.Page
    {

        static RepairsDataSet dsEmmmas;
        private static DataRow[] rows;
                                                                                                    

        static Services()
        {
            dsEmmmas = new RepairsDataSet();
            AllserviceDataTableAdapter daservices = new AllserviceDataTableAdapter();

            try
            {
                daservices.Fill(dsEmmmas.AllserviceData);
            }
            catch { }
        }

        private static int id = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            //refresh the dataset, so the newly created record is shown in index
            AllserviceDataTableAdapter daservices = new AllserviceDataTableAdapter();
            dsEmmmas.Reset();
            daservices.Fill(dsEmmmas.AllserviceData);


            this.Label1.Text = "ready";
            
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Service");
            dt.Columns.Add("Description");
            dt.Columns.Add("Price");

            DataRow dr = dt.NewRow();


            foreach (DataRow r in dsEmmmas.AllserviceData)
            {
                DataRow nr = dt.NewRow();
                nr[0] = r.ItemArray[0].ToString();
                nr[1] = r.ItemArray[1].ToString();
                nr[2] = r.ItemArray[2].ToString();
                nr[3] = r.ItemArray[3].ToString();
                dt.Rows.Add(nr);
            }


            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.GridView1.EditIndex != -1)
                this.Label1.Text = GridView1.SelectedRow.Cells[1].Text;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (dsEmmmas.AllserviceData.Count > 0)
            {
                string criteria = FilterCriteria();
                rows = (criteria.Length > 0) ? dsEmmmas.AllserviceData.Select(criteria) : dsEmmmas.AllserviceData.Select();
                DisplayServiceByFilter();
            }
            else
                this.Label1.Text = "No Records Found";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.txtName.Text = "";
            this.txtDescription.Text = "";
            this.txtPrice.Text = "";
        }

        //Filter criteria
        private string FilterCriteria()
        {
            string criteria = "";

            criteria = (this.txtName.Text.Length > 0) ? " serName Like '%" + this.txtName.Text + "%' " : "";

            criteria += (this.txtDescription.Text.Length > 0 && criteria.Length > 0) ? "and serDescription Like '%" +this.txtDescription.Text+"%' " 
                 : (this.txtDescription.Text.Length > 0) ? "serDescription Like '%" + this.txtDescription.Text + "%' " : ""; 

            criteria += (this.txtPrice.Text.Length > 0 && criteria.Length > 0) ? "and serPrice >=" +this.txtPrice.Text
                : (this.txtPrice.Text.Length > 0) ? "serPrice >=" + this.txtPrice.Text : "";

            return criteria; 
        }

        //Display methord
        private void DisplayServiceByFilter()
        {
            this.Label1.Text = "ready";

            //HyperLinkField hp = new HyperLinkField();
            //hp.Text = "Edit";
            //hp.NavigateUrl = "~/Default.aspx";
            //hp  .Visible = true;

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Service");
            dt.Columns.Add("Description");
            dt.Columns.Add("Price");
            //dt.Columns.Add("");
         

            DataRow dr = dt.NewRow();


            foreach (DataRow r in rows)
            {
                DataRow nr = dt.NewRow();
                nr[0] = r.ItemArray[0].ToString();
                nr[1] = r.ItemArray[1].ToString();
                nr[2] = r.ItemArray[2].ToString();
                nr[3] = r.ItemArray[3].ToString();
               
                dt.Rows.Add(nr);
                //this.GridView1.Columns.Add(hp);
            }

            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Not too secure sending value through query string
            //Response.Redirect("EditService.aspx?ID=" + GridView1.Rows[e.NewEditIndex].Cells[1].Text

            //Send Id using cookie, more seecure I presume
            HttpCookie cID = new HttpCookie("ID");
            cID.Value = GridView1.Rows[e.NewEditIndex].Cells[1].Text;
            Response.Cookies.Add(cID);
            Response.Redirect("EditService.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[1].Text);

            if (id != 1)
            {
                try
                {
                    DataRow record = dsEmmmas.AllserviceData.FindByid(id);

                    record.Delete();

                    AllserviceDataTableAdapter daservice = new AllserviceDataTableAdapter();
                    daservice.Update(record);
                    dsEmmmas.AcceptChanges();
                    Label1.Text = "deleted";

                    //Refresh the page to show the record being deleted
                    Response.Redirect(Request.RawUrl);

                }
                catch
                {
                    Label1.Text = "not deleted";
                }

            }
        }
    }
}

