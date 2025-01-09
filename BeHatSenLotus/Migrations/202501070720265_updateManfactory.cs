namespace BeHatSenLotus.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updateManfactory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Manfactories", "manfactoryName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Manfactories", "manfactoryName", c => c.Int(nullable: false));
        }
    }
}
