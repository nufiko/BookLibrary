namespace Rekcja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Author = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Isbn = c.String(maxLength: 13),
                        BorrowDate = c.DateTime(),
                        BorrowerID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Borrower", t => t.BorrowerID)
                .Index(t => t.BorrowerID);
            
            CreateTable(
                "dbo.Borrower",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "BorrowerID", "dbo.Borrower");
            DropIndex("dbo.Book", new[] { "BorrowerID" });
            DropTable("dbo.Borrower");
            DropTable("dbo.Book");
        }
    }
}
