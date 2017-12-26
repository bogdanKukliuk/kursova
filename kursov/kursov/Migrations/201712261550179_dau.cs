namespace kursov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dau : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "Name", c => c.String(nullable: false, maxLength: 228));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logins", "Name");
        }
    }
}
