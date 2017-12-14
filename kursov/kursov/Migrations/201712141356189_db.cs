namespace kursov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BrandCars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameBrand = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetailsClasses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameClass = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 228),
                        Password = c.String(nullable: false, maxLength: 228),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RoleLogins",
                c => new
                    {
                        Role_ID = c.Int(nullable: false),
                        Login_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_ID, t.Login_ID })
                .ForeignKey("dbo.Roles", t => t.Role_ID, cascadeDelete: true)
                .ForeignKey("dbo.Logins", t => t.Login_ID, cascadeDelete: true)
                .Index(t => t.Role_ID)
                .Index(t => t.Login_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleLogins", "Login_ID", "dbo.Logins");
            DropForeignKey("dbo.RoleLogins", "Role_ID", "dbo.Roles");
            DropIndex("dbo.RoleLogins", new[] { "Login_ID" });
            DropIndex("dbo.RoleLogins", new[] { "Role_ID" });
            DropTable("dbo.RoleLogins");
            DropTable("dbo.Roles");
            DropTable("dbo.Logins");
            DropTable("dbo.DetailsClasses");
            DropTable("dbo.BrandCars");
        }
    }
}
