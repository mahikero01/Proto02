using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SkillSetAzure.Models
{
    public class SkillSetAzureContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SkillSetAzureContext() : base("name=SkillSetAzureContext")
        {
        }

        public System.Data.Entity.DbSet<SkillSetAzure.Models.set_group> set_group { get; set; }

        public System.Data.Entity.DbSet<SkillSetAzure.Models.set_group_access> set_group_access { get; set; }

        public System.Data.Entity.DbSet<SkillSetAzure.Models.set_module> set_module { get; set; }

        public System.Data.Entity.DbSet<SkillSetAzure.Models.set_user> set_user { get; set; }

        public System.Data.Entity.DbSet<SkillSetAzure.Models.set_user_access> set_user_access { get; set; }

        public System.Data.Entity.DbSet<SkillSetAzure.Models.SS_AssociateDepartmentSkillsets> SS_AssociateDepartmentSkillsets { get; set; }

        public System.Data.Entity.DbSet<SkillSetAzure.Models.SS_Associates> SS_Associates { get; set; }

        public System.Data.Entity.DbSet<SkillSetAzure.Models.SS_Departments> SS_Departments { get; set; }

        public System.Data.Entity.DbSet<SkillSetAzure.Models.SS_DepartmentSkillsets> SS_DepartmentSkillsets { get; set; }

        public System.Data.Entity.DbSet<SkillSetAzure.Models.SS_Locations> SS_Locations { get; set; }

        public System.Data.Entity.DbSet<SkillSetAzure.Models.SS_Skillsets> SS_Skillsets { get; set; }
    
    }
}
