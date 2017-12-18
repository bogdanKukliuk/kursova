namespace kursov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class team : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NymeProdukt = c.String(nullable: false, maxLength: 200),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
            
            AddColumn("dbo.DetailsClasses", "Name", c => c.Int(nullable: false));
            AddColumn("dbo.DetailsClasses", "Details_ID", c => c.Int());
            AlterColumn("dbo.BrandCars", "NameBrand", c => c.Int(nullable: false));
            CreateIndex("dbo.DetailsClasses", "Details_ID");
            AddForeignKey("dbo.DetailsClasses", "Details_ID", "dbo.Details", "ID");
            DropColumn("dbo.DetailsClasses", "NameClass");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DetailsClasses", "NameClass", c => c.String(nullable: false, maxLength: 200));
            DropForeignKey("dbo.DetailsClasses", "Details_ID", "dbo.Details");
            DropForeignKey("dbo.BrandCarDetailsClasses", "DetailsClass_ID", "dbo.DetailsClasses");
            DropForeignKey("dbo.BrandCarDetailsClasses", "BrandCar_Id", "dbo.BrandCars");
            DropForeignKey("dbo.DetailsBins", "Bin_ID", "dbo.Bins");
            DropForeignKey("dbo.DetailsBins", "Details_ID", "dbo.Details");
            DropIndex("dbo.BrandCarDetailsClasses", new[] { "DetailsClass_ID" });
            DropIndex("dbo.BrandCarDetailsClasses", new[] { "BrandCar_Id" });
            DropIndex("dbo.DetailsBins", new[] { "Bin_ID" });
            DropIndex("dbo.DetailsBins", new[] { "Details_ID" });
            DropIndex("dbo.DetailsClasses", new[] { "Details_ID" });
            AlterColumn("dbo.BrandCars", "NameBrand", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.DetailsClasses", "Details_ID");
            DropColumn("dbo.DetailsClasses", "Name");
            DropTable("dbo.BrandCarDetailsClasses");
            DropTable("dbo.DetailsBins");
            DropTable("dbo.Details");
            DropTable("dbo.Bins");
        }
    }
}
