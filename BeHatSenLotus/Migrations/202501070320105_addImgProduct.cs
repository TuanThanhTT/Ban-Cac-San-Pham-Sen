namespace BeHatSenLotus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImgProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "imgs", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "imgs");
        }
    }
}
