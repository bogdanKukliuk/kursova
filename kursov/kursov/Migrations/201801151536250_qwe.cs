namespace kursov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qwe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetailsClasses", "BrendCar_ID", c => c.Int());
            CreateIndex("dbo.DetailsClasses", "BrendCar_ID");
            AddForeignKey("dbo.DetailsClasses", "BrendCar_ID", "dbo.BrendCars", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetailsClasses", "BrendCar_ID", "dbo.BrendCars");
            DropIndex("dbo.DetailsClasses", new[] { "BrendCar_ID" });
            DropColumn("dbo.DetailsClasses", "BrendCar_ID");
        }
    }
}
