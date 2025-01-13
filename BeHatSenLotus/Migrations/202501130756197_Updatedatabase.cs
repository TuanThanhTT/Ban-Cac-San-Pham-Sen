namespace BeHatSenLotus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GioHangs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userId = c.Int(nullable: false),
                        GioHang_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.GioHang_UserId)
                .Index(t => t.GioHang_UserId);
            
            CreateTable(
                "dbo.ChiTietGioHangs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        productId = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        gioHangId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.GioHangs", t => t.gioHangId, cascadeDelete: true)
                .Index(t => t.gioHangId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GioHangs", "GioHang_UserId", "dbo.Users");
            DropForeignKey("dbo.ChiTietGioHangs", "gioHangId", "dbo.GioHangs");
            DropIndex("dbo.ChiTietGioHangs", new[] { "gioHangId" });
            DropIndex("dbo.GioHangs", new[] { "GioHang_UserId" });
            DropTable("dbo.ChiTietGioHangs");
            DropTable("dbo.GioHangs");
        }
    }
}
