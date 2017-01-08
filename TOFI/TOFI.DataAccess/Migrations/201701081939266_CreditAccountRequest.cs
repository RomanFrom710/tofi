namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditAccountRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditAccounts", "CreditRequest_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.CreditAccounts", "CreditRequest_Id");
            AddForeignKey("dbo.CreditAccounts", "CreditRequest_Id", "dbo.CreditRequests", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditAccounts", "CreditRequest_Id", "dbo.CreditRequests");
            DropIndex("dbo.CreditAccounts", new[] { "CreditRequest_Id" });
            DropColumn("dbo.CreditAccounts", "CreditRequest_Id");
        }
    }
}
