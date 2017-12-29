using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCmsApi.Models;

namespace UCmsApi.Data
{
    public class InitDb
    {
        public static void Init(UCmsApiContext context)
        {
            context.Database.EnsureCreated();


            // Seed pages
            if (context.Pages.Any())
            {
                return;
            }

            var pages = new Page[]
            {
                new Page
                {
                    Title = "Home",
                    Slug = "home",
                    Content = "home content",
                    HasSidebar = "no"
                },
                new Page
                {
                    Title = "About",
                    Slug = "about",
                    Content = "about content",
                    HasSidebar = "no"
                },
                new Page
                {
                    Title = "Serivces",
                    Slug = "services",
                    Content = "services content",
                    HasSidebar = "no"
                },
                new Page
                {
                    Title = "Contact",
                    Slug = "contact",
                    Content = "contact content",
                    HasSidebar = "no"
                }
            };

            foreach (Page p in pages)
            {
                context.Pages.Add(p);
            }
            context.SaveChanges();

            // Seed sidebar
            var sidebar = new Sidebar
            {
                Content = "sidebar content"
            };

            context.Sidebar.Add(sidebar);

            context.SaveChanges();

            // Seed users
            var user = new User
            {
                Username = "admin",
                Password = "pass",
                IsAdmin = "yes"
            };

            context.Users.Add(user);

            context.SaveChanges();


        }
    }
}
