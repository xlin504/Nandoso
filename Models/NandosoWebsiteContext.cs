﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;

namespace NandosoWebsite.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class NandosoWebsiteContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public class MyConfiguration : DbMigrationsConfiguration<NandosoWebsiteContext>
        {
            public MyConfiguration()
            {
                this.AutomaticMigrationsEnabled = true;
            }

            protected override void Seed(NandosoWebsiteContext context)
            {
                var comments = new List<Comments>
            {
                new Comments {
                    Name = "Klevin",
                    Email = "klau@somewhere.com",
                    Feedback = "I almost love this place more than my gf",
                    CommentDate = new DateTime()
                }
               };

                comments.ForEach(s => context.Comments.AddOrUpdate(p => p.Feedback, s));
                context.SaveChanges();
            }

        }

        public NandosoWebsiteContext() : base("name=NandosoWebsiteContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NandosoWebsiteContext, MyConfiguration>());
        }

        public System.Data.Entity.DbSet<NandosoWebsite.Models.Comments> Comments { get; set; }
    }
}
