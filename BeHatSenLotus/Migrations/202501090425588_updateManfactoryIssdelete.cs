namespace BeHatSenLotus.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updateManfactoryIssdelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Manfactories", "isDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Manfactories", "isDelete");
        }
    }
}
