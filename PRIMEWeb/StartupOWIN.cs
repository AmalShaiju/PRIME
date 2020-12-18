using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(PRIMEWeb.StartupOWIN))]

namespace PRIMEWeb
{
    public class StartupOWIN
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                CookieName = "AuthCookie",
                LoginPath = new PathString("/"),
                LogoutPath = new PathString("/"),
                ExpireTimeSpan = TimeSpan.FromMinutes(5)
            }
            );

            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>();
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);
            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new IdentityRole("Admin"));
                roleManager.Create(new IdentityRole("Ordering"));
                roleManager.Create(new IdentityRole("Technician"));
                roleManager.Create(new IdentityRole("Sales"));
            }

            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);
            if (manager.Users.Count() == 0)
            {
                var admin1 = new IdentityUser("admin1");
                var admin2 = new IdentityUser("admin2");
                var order1 = new IdentityUser("order1");
                var tech01 = new IdentityUser("tech01");
                var tech02 = new IdentityUser("tech02");
                var sales1 = new IdentityUser("sales1");
                var sales2 = new IdentityUser("sales2");
                manager.Create(admin1, "admin1");
                manager.AddToRole(admin1.Id, "Admin");
                manager.Create(admin2, "admin2");
                manager.AddToRole(admin2.Id, "Admin");
                manager.Create(order1, "order1");
                manager.AddToRole(order1.Id, "Ordering");
                manager.Create(tech01, "tech01");
                manager.AddToRole(tech01.Id, "Technician");
                manager.Create(tech02, "tech02");
                manager.AddToRole(tech02.Id, "Technician");
                manager.Create(sales1, "sales1");
                manager.AddToRole(sales1.Id, "Sales");
                manager.Create(sales2, "sales2");
                manager.AddToRole(sales2.Id, "Sales");
            }
        }
    }
}
