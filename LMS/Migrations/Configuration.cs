namespace LMS.Migrations
{
    using LMS.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;

    internal sealed class Configuration : DbMigrationsConfiguration<LMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "LMS.Models.ApplicationDbContext";
        }

        protected override void Seed(LMS.Models.ApplicationDbContext context)
        {
           //Systemet skall hantera tv�, och endast tv�, roller - teacher och student
           //F�rst skapas en Rolestore f�r att f�rvara de tv� rollerna
            var roleStore = new RoleStore<IdentityRole>(context);

            //Sedan skapas en rolemanager f�r att kunna tilldela Teacher respektive Student beh�righeter
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roleNames = new[] { Models.Roles.Teacher, Models.Roles.Student };
            foreach (var roleName in roleNames)
            {
                if (context.Roles.Any(r => r.Name == roleName)) continue;

                // Create role
                var role = new IdentityRole { Name = roleName };
                var result = roleManager.Create(role);
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join("\n", result.Errors));
                }
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var originalUsers = new[] {
                new ApplicationUser {  FirstName = "Georgios", LastName = "Rastapopulous" , Email = "badguy@tintin.com", NickName = "Archvillain", UserName = "badguy@tintin.com"},
                new ApplicationUser {  FirstName = "Francois", LastName = "Haddock" , Email = "kapten@tintin.com", NickName = "Kapten", UserName = "kapten@tintin.com"},
                new ApplicationUser {  FirstName = "Karl", LastName = "Kalkyl", Email = "kalkyl@tintin.com", NickName = "Professorn", UserName = "kalkyl@tintin.com"},
                new ApplicationUser {  FirstName = "Johannes", LastName = "Gabrielsson", Email = "johannes@gmail.com", NickName = "The Worm", UserName = "johannes@gmail.com"},
                new ApplicationUser {  FirstName = "Rikard", LastName = "Nystr�m", Email = "LittleBunny@uu.se", NickName = "Dog with rabies", UserName = "LittleBunny@uu.se"},
                new ApplicationUser {  FirstName = "William", LastName = "Smith", Email = "VilleViking@live.se", NickName = "Tjommen", UserName = "VilleViking@live.se"},
                new ApplicationUser {  FirstName = "Anna", LastName = "Holmstr�m", Email = "Anna_Virrpanna@gmail.com", NickName = "Please help me", UserName = "Anna_Virrpanna@gmail.com"},
                new ApplicationUser {  FirstName = "Fredrik", LastName = "Nyqvist", Email = "lapinkultaMums@gmail.com", NickName = "Mamas Boy", UserName = "lapinkultaMums@gmail.com"},
            };

            

            for (int i = 0; i < originalUsers.Length; i++)
            {
               // if (context.Users.Any(u => u.UserName == originalUsers[i].UserName)) continue;
                // Create user d�r alla har samma l�senord          
                var result = userManager.Create(originalUsers[i], "student");
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join("\n", result.Errors));
                }
                userManager.AddToRole(originalUsers[i].Id, Models.Roles.Student);
            }
            

            var originalTeachers = new[] {
                new ApplicationUser {  FirstName = "Adrian", LastName = "Lozano" , Email = "zano@lexicon.se", NickName = "Wannabe", UserName = "zano@lexicon.se"},
                 new ApplicationUser {  FirstName = "Dmitris", LastName = "Bj�rlingh", Email = "dimitris@lexicon.se", NickName = "The Beard", UserName = "dimitris@lexicon.se"}
                            };


            for (int i = 0; i < originalTeachers.Length; i++)
            {
                // Create user d�r alla har samma l�senord          
                var result = userManager.Create(originalTeachers[i], "teacher");
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join("\n", result.Errors));
                }
                userManager.AddToRole(originalTeachers[i].Id, Models.Roles.Teacher);
            }

           


        }
    }
}
