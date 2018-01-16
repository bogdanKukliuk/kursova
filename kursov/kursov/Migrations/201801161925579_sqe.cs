namespace kursov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sqe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetailsClasses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameDetalClass = c.String(nullable: false, maxLength: 200),
                        BrendCar_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BrendCars", t => t.BrendCar_ID)
                .Index(t => t.BrendCar_ID);
            
            CreateTable(
                "dbo.Detals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameDetal = c.String(nullable: false, maxLength: 200),
                        DetailsClass_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DetailsClasses", t => t.DetailsClass_ID)
                .Index(t => t.DetailsClass_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Detals", "DetailsClass_ID", "dbo.DetailsClasses");
            DropForeignKey("dbo.DetailsClasses", "BrendCar_ID", "dbo.BrendCars");
            DropIndex("dbo.Detals", new[] { "DetailsClass_ID" });
            DropIndex("dbo.DetailsClasses", new[] { "BrendCar_ID" });
            DropTable("dbo.Detals");
            DropTable("dbo.DetailsClasses");
        }
    }
}
