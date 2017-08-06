namespace SkillSetAzure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SkillSetAzure.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SkillSetAzure.Models.SkillSetAzureContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SkillSetAzure.Models.SkillSetAzureContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.set_group.AddOrUpdate(x => x.grp_id,
                   new set_group() { 
                       grp_id = "GRP-2017626-001" ,
                       grp_name = "Admin",
                       grp_desc = "",
                       created_date = DateTime.Parse("2017-06-26 01:06:07.840")
                   },
                   new set_group() { 
                       grp_id = "GRP-2017626-002" ,
                       grp_name = "User",
                       grp_desc = "",
                       created_date = DateTime.Parse("2017-06-26 01:06:33.107")
                   }
            );

            context.set_group_access.AddOrUpdate(x => x.Id,
                   new set_group_access()
                   {
                       Id = 1,
                       grp_id = "GRP-2017626-001",
                       mod_id = "MOD-2017626-001",
                       can_view = true,
                       can_add = false,
                       can_edit = false,
                       can_delete = false
                   }
            );

            context.set_module.AddOrUpdate(x => x.mod_id,
                   new set_module()
                   {
                       mod_id = "MOD-2017626-001",
                       mod_name = "Skillset",
                       mod_desc = "",
                       created_date = DateTime.Parse("2017-06-26 01:05:46.457")
                   }
            );

            context.set_user.AddOrUpdate(x => x.user_id,
                   new set_user()
                   {
                       user_id = "USER-2017626-001",
                       user_name = "sarmife",
                       user_last_name = "Sarmiento",
                       user_first_name = "Federico",
                       user_middle_name = "MOD-2017626-001",
                       can_PROD = false,
                       can_UAT = false,
                       can_PEER = false,
                       can_DEV = false,
                       created_date = DateTime.Parse("2017-06-26 01:06:53.277")
                   }
            );

            context.set_user_access.AddOrUpdate(x => x.Id,
                   new set_user_access()
                   {
                       Id = 1,
                       user_id = "USER-2017626-001",
                       grp_id = "GRP-2017626-001"
                   },
                   new set_user_access()
                   {
                       Id = 2,
                       user_id = "USER-2017626-001",
                       grp_id = "GRP-2017626-002"
                   }
            );
        }
    }
}
