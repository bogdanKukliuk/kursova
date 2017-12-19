namespace kursov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class te : DbMigration
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
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Logins", t => t.ID)
                .Index(t => t.ID);
            
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
                    })
                .PrimaryKey(t => t.ID);
            
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
                "dbo.DetailsBins",
                c => new
                    {
                        Details_ID = c.Int(nullable: false),
                        Bin_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Details_ID, t.Bin_ID })
                .ForeignKey("dbo.Details", t => t.Details_ID, cascadeDelete: true)
                .ForeignKey("dbo.Bins", t => t.Bin_ID, cascadeDelete: true)
                .Index(t => t.Details_ID)
                .Index(t => t.Bin_ID);
            
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
                "dbo.LoginBrandCars",
                c => new
                    {
                        Login_ID = c.Int(nullable: false),
                        BrandCar_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Login_ID, t.BrandCar_Id })
                .ForeignKey("dbo.Logins", t => t.Login_ID, cascadeDelete: true)
                .ForeignKey("dbo.BrandCars", t => t.BrandCar_Id, cascadeDelete: true)
                .Index(t => t.Login_ID)
                .Index(t => t.BrandCar_Id);
            
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
            
            CreateTable(
                "dbo.DetailsClassDetails",
                c => new
                    {
                        DetailsClass_ID = c.Int(nullable: false),
                        Details_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DetailsClass_ID, t.Details_ID })
                .ForeignKey("dbo.DetailsClasses", t => t.DetailsClass_ID, cascadeDelete: true)
                .ForeignKey("dbo.Details", t => t.Details_ID, cascadeDelete: true)
                .Index(t => t.DetailsClass_ID)
                .Index(t => t.Details_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bins", "ID", "dbo.Logins");
            DropForeignKey("dbo.DetailsClassDetails", "Details_ID", "dbo.Details");
            DropForeignKey("dbo.DetailsClassDetails", "DetailsClass_ID", "dbo.DetailsClasses");
            DropForeignKey("dbo.RoleLogins", "Login_ID", "dbo.Logins");
            DropForeignKey("dbo.RoleLogins", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.LoginBrandCars", "BrandCar_Id", "dbo.BrandCars");
            DropForeignKey("dbo.LoginBrandCars", "Login_ID", "dbo.Logins");
            DropForeignKey("dbo.BrandCarDetailsClasses", "DetailsClass_ID", "dbo.DetailsClasses");
            DropForeignKey("dbo.BrandCarDetailsClasses", "BrandCar_Id", "dbo.BrandCars");
            DropForeignKey("dbo.DetailsBins", "Bin_ID", "dbo.Bins");
            DropForeignKey("dbo.DetailsBins", "Details_ID", "dbo.Details");
            DropIndex("dbo.DetailsClassDetails", new[] { "Details_ID" });
            DropIndex("dbo.DetailsClassDetails", new[] { "DetailsClass_ID" });
            DropIndex("dbo.RoleLogins", new[] { "Login_ID" });
            DropIndex("dbo.RoleLogins", new[] { "Role_ID" });
            DropIndex("dbo.LoginBrandCars", new[] { "BrandCar_Id" });
            DropIndex("dbo.LoginBrandCars", new[] { "Login_ID" });
            DropIndex("dbo.BrandCarDetailsClasses", new[] { "DetailsClass_ID" });
            DropIndex("dbo.BrandCarDetailsClasses", new[] { "BrandCar_Id" });
            DropIndex("dbo.DetailsBins", new[] { "Bin_ID" });
            DropIndex("dbo.DetailsBins", new[] { "Details_ID" });
            DropIndex("dbo.Bins", new[] { "ID" });
            DropTable("dbo.DetailsClassDetails");
            DropTable("dbo.RoleLogins");
            DropTable("dbo.LoginBrandCars");
            DropTable("dbo.BrandCarDetailsClasses");
            DropTable("dbo.DetailsBins");
            DropTable("dbo.Roles");
            DropTable("dbo.Logins");
            DropTable("dbo.BrandCars");
            DropTable("dbo.DetailsClasses");
            DropTable("dbo.Details");
            DropTable("dbo.Bins");
        }
    }
}
