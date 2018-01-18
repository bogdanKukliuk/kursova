namespace kursov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdfasdf : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetailsClasses", "BrendCar_ID", "dbo.BrendCars");
            DropIndex("dbo.DetailsClasses", new[] { "BrendCar_ID" });
            RenameColumn(table: "dbo.DetailsClasses", name: "BrendCar_ID", newName: "BrendCarId");
            AlterColumn("dbo.DetailsClasses", "BrendCarId", c => c.Int(nullable: false));
            CreateIndex("dbo.DetailsClasses", "BrendCarId");
            AddForeignKey("dbo.DetailsClasses", "BrendCarId", "dbo.BrendCars", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetailsClasses", "BrendCarId", "dbo.BrendCars");
            DropIndex("dbo.DetailsClasses", new[] { "BrendCarId" });
            AlterColumn("dbo.DetailsClasses", "BrendCarId", c => c.Int());
            RenameColumn(table: "dbo.DetailsClasses", name: "BrendCarId", newName: "BrendCar_ID");
            CreateIndex("dbo.DetailsClasses", "BrendCar_ID");
            AddForeignKey("dbo.DetailsClasses", "BrendCar_ID", "dbo.BrendCars", "ID");
        }
    }
}
