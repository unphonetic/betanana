namespace betaNana.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Contact = c.String(maxLength: 250),
                        SendTaxCertificate = c.Boolean(nullable: false),
                        Taxable = c.Boolean(nullable: false),
                        Discount = c.Int(nullable: false),
                        OrderNumber = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuoteDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuoteId = c.Int(nullable: false),
                        SampleText = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quotes", t => t.QuoteId, cascadeDelete: true)
                .Index(t => t.QuoteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuoteDetails", "QuoteId", "dbo.Quotes");
            DropIndex("dbo.QuoteDetails", new[] { "QuoteId" });
            DropTable("dbo.QuoteDetails");
            DropTable("dbo.Quotes");
        }
    }
}
