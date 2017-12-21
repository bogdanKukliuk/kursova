namespace kursov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nigger : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Details", "Description", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Logins", "Money", c => c.Int(nullable: false));
            DropColumn("dbo.Logins", "Mony");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logins", "Mony", c => c.Int(nullable: false));
            DropColumn("dbo.Logins", "Money");
            DropColumn("dbo.Details", "Description");
        }
    }
}
