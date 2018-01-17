namespace kursov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "Logins");
            RenameTable(name: "dbo.RegisterUsers", newName: "RegisterLogins");
            RenameTable(name: "dbo.RoleUsers", newName: "RoleLogins");
            DropForeignKey("dbo.Detals", "User_ID", "dbo.Users");
            DropIndex("dbo.Detals", new[] { "User_ID" });
            RenameColumn(table: "dbo.RegisterLogins", name: "User_ID", newName: "Login_ID");
            RenameColumn(table: "dbo.RoleLogins", name: "User_ID", newName: "Login_ID");
            RenameIndex(table: "dbo.RegisterLogins", name: "IX_User_ID", newName: "IX_Login_ID");
            RenameIndex(table: "dbo.RoleLogins", name: "IX_User_ID", newName: "IX_Login_ID");
            AddColumn("dbo.DetailsClasses", "Picture", c => c.Binary());
            DropColumn("dbo.Detals", "Price");
            DropColumn("dbo.Detals", "User_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Detals", "User_ID", c => c.Int());
            AddColumn("dbo.Detals", "Price", c => c.Single(nullable: false));
            DropColumn("dbo.DetailsClasses", "Picture");
            RenameIndex(table: "dbo.RoleLogins", name: "IX_Login_ID", newName: "IX_User_ID");
            RenameIndex(table: "dbo.RegisterLogins", name: "IX_Login_ID", newName: "IX_User_ID");
            RenameColumn(table: "dbo.RoleLogins", name: "Login_ID", newName: "User_ID");
            RenameColumn(table: "dbo.RegisterLogins", name: "Login_ID", newName: "User_ID");
            CreateIndex("dbo.Detals", "User_ID");
            AddForeignKey("dbo.Detals", "User_ID", "dbo.Users", "ID");
            RenameTable(name: "dbo.RoleLogins", newName: "RoleUsers");
            RenameTable(name: "dbo.RegisterLogins", newName: "RegisterUsers");
            RenameTable(name: "dbo.Logins", newName: "Users");
        }
    }
}
