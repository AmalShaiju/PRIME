using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRIMEWeb
{
    public partial class Default : System.Web.UI.Page
    {
        static Default()
        {
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

            manager.Create(new IdentityUser("admin1"), "admin1");
            manager.Create(new IdentityUser("admin2"), "admin2");
            manager.Create(new IdentityUser("order1"), "order1");
            manager.Create(new IdentityUser("tech01"), "tech01");
            manager.Create(new IdentityUser("tech02"), "tech02");
            manager.Create(new IdentityUser("sales1"), "sales1");
            manager.Create(new IdentityUser("sales2"), "sales2");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
                Response.Redirect("/Landing.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);
            IdentityUser user = manager.Find(txtUser.Text, txtPass.Text);
            if (user == null)
            {
                lblMessage.Text = "Username or password is not correct";
            }
            else
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(userIdentity);
                Response.Redirect("/Landing.aspx");
            }
        }
    }
}