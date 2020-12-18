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
            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>();
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);
            var admin = new IdentityRole("Admin");
            var ordering = new IdentityRole("Ordering");
            var technician = new IdentityRole("Technician");
            var sales = new IdentityRole("Sales");
            roleManager.Create(admin);
            roleManager.Create(ordering);
            roleManager.Create(technician);
            roleManager.Create(sales);

            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);
            var admin1 = new IdentityUser("admin1");
            var admin2 = new IdentityUser("admin2");
            var order1 = new IdentityUser("order1");
            var tech01 = new IdentityUser("tech01");
            var tech02 = new IdentityUser("tech02");
            var sales1 = new IdentityUser("sales1");
            var sales2 = new IdentityUser("sales2");
            manager.Create(admin1, "admin1");
            manager.Create(admin2, "admin2");
            manager.Create(order1, "order1");
            manager.Create(tech01, "tech01");
            manager.Create(tech02, "tech02");
            manager.Create(sales1, "sales1");
            manager.Create(sales2, "sales2");


            var admin1Role = new IdentityUserRole();
            admin1Role.UserId = admin1.Id;
            admin1Role.RoleId = admin.Id;
            admin1.Roles.Add(admin1Role);

            var admin2Role = new IdentityUserRole();
            admin2Role.UserId = admin2.Id;
            admin2Role.RoleId = admin.Id;
            admin2.Roles.Add(admin2Role);

            var order1Role = new IdentityUserRole();
            order1Role.UserId = order1.Id;
            order1Role.RoleId = ordering.Id;
            order1.Roles.Add(order1Role);

            var tech01Role = new IdentityUserRole();
            tech01Role.UserId = tech01.Id;
            tech01Role.RoleId = technician.Id;
            tech01.Roles.Add(tech01Role);

            var tech02Role = new IdentityUserRole();
            tech02Role.UserId = tech02.Id;
            tech02Role.RoleId = technician.Id;
            tech02.Roles.Add(tech02Role);

            var sales1Role = new IdentityUserRole();
            sales1Role.UserId = sales1.Id;
            sales1Role.RoleId = sales.Id;
            sales1.Roles.Add(sales1Role);

            var sales2Role = new IdentityUserRole();
            sales2Role.UserId = sales2.Id;
            sales2Role.RoleId = sales.Id;
            sales2.Roles.Add(sales2Role);
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
                lblMessage.Visible = true;
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