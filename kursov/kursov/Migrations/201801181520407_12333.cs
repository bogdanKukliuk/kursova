namespace kursov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12333 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.DetailsClasses", name: "BrendCar_ID_ID", newName: "BrendCar_ID");
            RenameIndex(table: "dbo.DetailsClasses", name: "IX_BrendCar_ID_ID", newName: "IX_BrendCar_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.DetailsClasses", name: "IX_BrendCar_ID", newName: "IX_BrendCar_ID_ID");
            RenameColumn(table: "dbo.DetailsClasses", name: "BrendCar_ID", newName: "BrendCar_ID_ID");
        }
    }
}
