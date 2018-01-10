namespace kursov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class der : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 228),
                        Password = c.String(nullable: false, maxLength: 228),
                        Name = c.String(nullable: false, maxLength: 228),
                        Money = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Registers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 200),
                        Password = c.String(nullable: false, maxLength: 200),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RegisterLogins",
                c => new
                    {
                        Register_ID = c.Int(nullable: false),
                        Login_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Register_ID, t.Login_ID })
                .ForeignKey("dbo.Registers", t => t.Register_ID, cascadeDelete: true)
                .ForeignKey("dbo.Logins", t => t.Login_ID, cascadeDelete: true)
                .Index(t => t.Register_ID)
                .Index(t => t.Login_ID);
            
            CreateTable(
                "dbo.RoleLogins",
                c => new
                    {
                        Role_ID = c.Int(nullable: false),
                        Login_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_ID, t.Login_ID })
                .ForeignKey("dbo.Roles", t => t.Role_ID, cascadeDelete: true)
                .ForeignKey("dbo.Logins", t => t.Login_ID, cascadeDelete: true)
                .Index(t => t.Role_ID)
                .Index(t => t.Login_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleLogins", "Login_ID", "dbo.Logins");
            DropForeignKey("dbo.RoleLogins", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.RegisterLogins", "Login_ID", "dbo.Logins");
            DropForeignKey("dbo.RegisterLogins", "Register_ID", "dbo.Registers");
            DropIndex("dbo.RoleLogins", new[] { "Login_ID" });
            DropIndex("dbo.RoleLogins", new[] { "Role_ID" });
            DropIndex("dbo.RegisterLogins", new[] { "Login_ID" });
            DropIndex("dbo.RegisterLogins", new[] { "Register_ID" });
            DropTable("dbo.RoleLogins");
            DropTable("dbo.RegisterLogins");
            DropTable("dbo.Roles");
            DropTable("dbo.Registers");
            DropTable("dbo.Logins");
        }
    }
}
