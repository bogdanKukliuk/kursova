namespace kursov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qrw1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Logins", newName: "Users");
            RenameTable(name: "dbo.RegisterLogins", newName: "RegisterUsers");
            RenameTable(name: "dbo.RoleLogins", newName: "RoleUsers");
            RenameColumn(table: "dbo.RegisterUsers", name: "Login_ID", newName: "User_ID");
            RenameColumn(table: "dbo.RoleUsers", name: "Login_ID", newName: "User_ID");
            RenameColumn(table: "dbo.Detals", name: "Login_ID", newName: "User_ID");
            RenameIndex(table: "dbo.Detals", name: "IX_Login_ID", newName: "IX_User_ID");
            RenameIndex(table: "dbo.RegisterUsers", name: "IX_Login_ID", newName: "IX_User_ID");
            RenameIndex(table: "dbo.RoleUsers", name: "IX_Login_ID", newName: "IX_User_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.RoleUsers", name: "IX_User_ID", newName: "IX_Login_ID");
            RenameIndex(table: "dbo.RegisterUsers", name: "IX_User_ID", newName: "IX_Login_ID");
            RenameIndex(table: "dbo.Detals", name: "IX_User_ID", newName: "IX_Login_ID");
            RenameColumn(table: "dbo.Detals", name: "User_ID", newName: "Login_ID");
            RenameColumn(table: "dbo.RoleUsers", name: "User_ID", newName: "Login_ID");
            RenameColumn(table: "dbo.RegisterUsers", name: "User_ID", newName: "Login_ID");
            RenameTable(name: "dbo.RoleUsers", newName: "RoleLogins");
            RenameTable(name: "dbo.RegisterUsers", newName: "RegisterLogins");
            RenameTable(name: "dbo.Users", newName: "Logins");
        }
    }
}
