namespace kursov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetailsBins", "Details_ID", "dbo.Details");
            DropForeignKey("dbo.DetailsBins", "Bin_ID", "dbo.Bins");
            DropForeignKey("dbo.BrandCarDetailsClasses", "BrandCar_Id", "dbo.BrandCars");
            DropForeignKey("dbo.BrandCarDetailsClasses", "DetailsClass_ID", "dbo.DetailsClasses");
            DropForeignKey("dbo.LoginBrandCars", "Login_ID", "dbo.Logins");
            DropForeignKey("dbo.LoginBrandCars", "BrandCar_Id", "dbo.BrandCars");
            DropForeignKey("dbo.DetailsClassDetails", "DetailsClass_ID", "dbo.DetailsClasses");
            DropForeignKey("dbo.DetailsClassDetails", "Details_ID", "dbo.Details");
            DropForeignKey("dbo.Bins", "ID", "dbo.Logins");
            DropIndex("dbo.Bins", new[] { "ID" });
            DropIndex("dbo.DetailsBins", new[] { "Details_ID" });
            DropIndex("dbo.DetailsBins", new[] { "Bin_ID" });
            DropIndex("dbo.BrandCarDetailsClasses", new[] { "BrandCar_Id" });
            DropIndex("dbo.BrandCarDetailsClasses", new[] { "DetailsClass_ID" });
            DropIndex("dbo.LoginBrandCars", new[] { "Login_ID" });
            DropIndex("dbo.LoginBrandCars", new[] { "BrandCar_Id" });
            DropIndex("dbo.DetailsClassDetails", new[] { "DetailsClass_ID" });
            DropIndex("dbo.DetailsClassDetails", new[] { "Details_ID" });
            DropTable("dbo.Bins");
            DropTable("dbo.Details");
            DropTable("dbo.DetailsClasses");
            DropTable("dbo.BrandCars");
            DropTable("dbo.DetailsBins");
            DropTable("dbo.BrandCarDetailsClasses");
            DropTable("dbo.LoginBrandCars");
            DropTable("dbo.DetailsClassDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DetailsClassDetails",
                c => new
                    {
                        DetailsClass_ID = c.Int(nullable: false),
                        Details_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DetailsClass_ID, t.Details_ID });
            
            CreateTable(
                "dbo.LoginBrandCars",
                c => new
                    {
                        Login_ID = c.Int(nullable: false),
                        BrandCar_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Login_ID, t.BrandCar_Id });
            
            CreateTable(
                "dbo.BrandCarDetailsClasses",
                c => new
                    {
                        BrandCar_Id = c.Int(nullable: false),
                        DetailsClass_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BrandCar_Id, t.DetailsClass_ID });
            
            CreateTable(
                "dbo.DetailsBins",
                c => new
                    {
                        Details_ID = c.Int(nullable: false),
                        Bin_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Details_ID, t.Bin_ID });
            
            CreateTable(
                "dbo.BrandCars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameBrand = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetailsClasses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameDetal = c.String(nullable: false, maxLength: 200),
                        Price = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Bins",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        NymeProdukt = c.String(nullable: false, maxLength: 200),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.DetailsClassDetails", "Details_ID");
            CreateIndex("dbo.DetailsClassDetails", "DetailsClass_ID");
            CreateIndex("dbo.LoginBrandCars", "BrandCar_Id");
            CreateIndex("dbo.LoginBrandCars", "Login_ID");
            CreateIndex("dbo.BrandCarDetailsClasses", "DetailsClass_ID");
            CreateIndex("dbo.BrandCarDetailsClasses", "BrandCar_Id");
            CreateIndex("dbo.DetailsBins", "Bin_ID");
            CreateIndex("dbo.DetailsBins", "Details_ID");
            CreateIndex("dbo.Bins", "ID");
            AddForeignKey("dbo.Bins", "ID", "dbo.Logins", "ID");
            AddForeignKey("dbo.DetailsClassDetails", "Details_ID", "dbo.Details", "ID", cascadeDelete: true);
            AddForeignKey("dbo.DetailsClassDetails", "DetailsClass_ID", "dbo.DetailsClasses", "ID", cascadeDelete: true);
            AddForeignKey("dbo.LoginBrandCars", "BrandCar_Id", "dbo.BrandCars", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoginBrandCars", "Login_ID", "dbo.Logins", "ID", cascadeDelete: true);
            AddForeignKey("dbo.BrandCarDetailsClasses", "DetailsClass_ID", "dbo.DetailsClasses", "ID", cascadeDelete: true);
            AddForeignKey("dbo.BrandCarDetailsClasses", "BrandCar_Id", "dbo.BrandCars", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DetailsBins", "Bin_ID", "dbo.Bins", "ID", cascadeDelete: true);
            AddForeignKey("dbo.DetailsBins", "Details_ID", "dbo.Details", "ID", cascadeDelete: true);
        }
    }
}
