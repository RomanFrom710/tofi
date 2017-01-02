namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditPayment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                        PaymentSum_Id = c.Int(nullable: false),
                        CreditAccount_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PriceModels", t => t.PaymentSum_Id)
                .ForeignKey("dbo.CreditAccounts", t => t.CreditAccount_Id, cascadeDelete: true)
                .Index(t => t.PaymentSum_Id)
                .Index(t => t.CreditAccount_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditPayments", "CreditAccount_Id", "dbo.CreditAccounts");
            DropForeignKey("dbo.CreditPayments", "PaymentSum_Id", "dbo.PriceModels");
            DropIndex("dbo.CreditPayments", new[] { "CreditAccount_Id" });
            DropIndex("dbo.CreditPayments", new[] { "PaymentSum_Id" });
            DropTable("dbo.CreditPayments");
        }
    }
}
