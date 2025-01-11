namespace BeHatSenLotus.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updataAccountTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "avartar", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "avartar");
        }
    }
}
