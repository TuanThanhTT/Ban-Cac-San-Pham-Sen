namespace BeHatSenLotus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateV5 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Accounts", new[] { "EmployAccountID" });
            DropIndex("dbo.Accounts", new[] { "UserAccountID" });
            AlterColumn("dbo.Accounts", "EmployAccountId", c => c.Int());
            AlterColumn("dbo.Accounts", "UserAccountId", c => c.Int());
            CreateIndex("dbo.Employees", "EmployAccountId");
            CreateIndex("dbo.Users", "UserAccountId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "UserAccountId" });
            DropIndex("dbo.Employees", new[] { "EmployAccountId" });
            AlterColumn("dbo.Accounts", "UserAccountId", c => c.Int(nullable: false));
            AlterColumn("dbo.Accounts", "EmployAccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.Accounts", "UserAccountID");
            CreateIndex("dbo.Accounts", "EmployAccountID");
        }
    }
}
