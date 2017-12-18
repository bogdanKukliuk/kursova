namespace kursov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class der : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bins",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        NymeProdukt = c.String(nullable: false, maxLength: 200),
                        Price = c.Int(nullable: false),
                        details_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Details", t => t.details_ID)
                .ForeignKey("dbo.Logins", t => t.ID)
                .Index(t => t.ID)
                .Index(t => t.details_ID);
            
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameDetal = c.String(nullable: false, maxLength: 200),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DetailsClasses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Details_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Details", t => t.Details_ID)
                .Index(t => t.Details_ID);
            
            CreateTable(
                "dbo.BrandCars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameBrand = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 228),
                        Password = c.String(nullable: false, maxLength: 228),
                        Mony = c.Int(nullable: false),
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
                "dbo.BrandCarDetailsClasses",
                c => new
                    {
                        BrandCar_Id = c.Int(nullable: false),
                        DetailsClass_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BrandCar_Id, t.DetailsClass_ID })
                .ForeignKey("dbo.BrandCars", t => t.BrandCar_Id, cascadeDelete: true)
                .ForeignKey("dbo.DetailsClasses", t => t.DetailsClass_ID, cascadeDelete: true)
                .Index(t => t.BrandCar_Id)
                .Index(t => t.DetailsClass_ID);
            
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
            DropForeignKey("dbo.Bins", "ID", "dbo.Logins");
            DropForeignKey("dbo.RoleLogins", "Login_ID", "dbo.Logins");
            DropForeignKey("dbo.RoleLogins", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.DetailsClasses", "Details_ID", "dbo.Details");
            DropForeignKey("dbo.BrandCarDetailsClasses", "DetailsClass_ID", "dbo.DetailsClasses");
            DropForeignKey("dbo.BrandCarDetailsClasses", "BrandCar_Id", "dbo.BrandCars");
            DropForeignKey("dbo.Bins", "details_ID", "dbo.Details");
            DropIndex("dbo.RoleLogins", new[] { "Login_ID" });
            DropIndex("dbo.RoleLogins", new[] { "Role_ID" });
            DropIndex("dbo.BrandCarDetailsClasses", new[] { "DetailsClass_ID" });
            DropIndex("dbo.BrandCarDetailsClasses", new[] { "BrandCar_Id" });
            DropIndex("dbo.DetailsClasses", new[] { "Details_ID" });
            DropIndex("dbo.Bins", new[] { "details_ID" });
            DropIndex("dbo.Bins", new[] { "ID" });
            DropTable("dbo.RoleLogins");
            DropTable("dbo.BrandCarDetailsClasses");
            DropTable("dbo.Roles");
            DropTable("dbo.Logins");
            DropTable("dbo.BrandCars");
            DropTable("dbo.DetailsClasses");
            DropTable("dbo.Details");
            DropTable("dbo.Bins");
        }
    }
}
