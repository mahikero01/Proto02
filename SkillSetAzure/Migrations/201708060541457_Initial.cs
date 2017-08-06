namespace SkillSetAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.set_group",
                c => new
                    {
                        grp_id = c.String(nullable: false, maxLength: 128),
                        grp_name = c.String(),
                        grp_desc = c.String(),
                        created_date = c.DateTime(),
                    })
                .PrimaryKey(t => t.grp_id);
            
            CreateTable(
                "dbo.set_group_access",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        grp_id = c.String(),
                        mod_id = c.String(),
                        can_view = c.Boolean(nullable: false),
                        can_add = c.Boolean(nullable: false),
                        can_edit = c.Boolean(nullable: false),
                        can_delete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.set_module",
                c => new
                    {
                        mod_id = c.String(nullable: false, maxLength: 128),
                        mod_name = c.String(),
                        mod_desc = c.String(),
                        created_date = c.DateTime(),
                    })
                .PrimaryKey(t => t.mod_id);
            
            CreateTable(
                "dbo.set_user",
                c => new
                    {
                        user_id = c.String(nullable: false, maxLength: 128),
                        user_name = c.String(),
                        user_last_name = c.String(),
                        user_first_name = c.String(),
                        user_middle_name = c.String(),
                        can_PROD = c.Boolean(),
                        can_UAT = c.Boolean(),
                        can_PEER = c.Boolean(),
                        can_DEV = c.Boolean(),
                        created_date = c.DateTime(),
                    })
                .PrimaryKey(t => t.user_id);
            
            CreateTable(
                "dbo.set_user_access",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        user_id = c.String(),
                        grp_id = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SS_AssociateDepartmentSkillsets",
                c => new
                    {
                        AssociateDepartmentSkillsetID = c.Int(nullable: false, identity: true),
                        AssociateID = c.Int(nullable: false),
                        DepartmentSkillsetID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssociateDepartmentSkillsetID);
            
            CreateTable(
                "dbo.SS_Associates",
                c => new
                    {
                        AssociateID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        PhoneNumber = c.String(),
                        VPN = c.Boolean(nullable: false),
                        DepartmentID = c.Short(nullable: false),
                        LocationID = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AssociateID);
            
            CreateTable(
                "dbo.SS_Departments",
                c => new
                    {
                        DepartmentID = c.Short(nullable: false, identity: true),
                        DepartmentDescr = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.SS_DepartmentSkillsets",
                c => new
                    {
                        DepartmentSkillsetID = c.Int(nullable: false, identity: true),
                        DepartmentID = c.Short(nullable: false),
                        SkillsetID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentSkillsetID);
            
            CreateTable(
                "dbo.SS_Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        LocationDescr = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.SS_Skillsets",
                c => new
                    {
                        SkillsetID = c.Int(nullable: false, identity: true),
                        SkillsetDescr = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SkillsetID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SS_Skillsets");
            DropTable("dbo.SS_Locations");
            DropTable("dbo.SS_DepartmentSkillsets");
            DropTable("dbo.SS_Departments");
            DropTable("dbo.SS_Associates");
            DropTable("dbo.SS_AssociateDepartmentSkillsets");
            DropTable("dbo.set_user_access");
            DropTable("dbo.set_user");
            DropTable("dbo.set_module");
            DropTable("dbo.set_group_access");
            DropTable("dbo.set_group");
        }
    }
}
