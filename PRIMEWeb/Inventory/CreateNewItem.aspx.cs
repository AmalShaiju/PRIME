using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRIMEWeb.Inventory
{
    public partial class CreateNewItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            ddlProductName.SelectedIndex = 0;
            
        }

        protected void btnSaveItem_Click(object sender, EventArgs e)
        {
            
            ddlProductName.SelectedIndex = 0;
           
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}