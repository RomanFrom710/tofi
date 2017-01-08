namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditAccountCurrency : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditAccounts", "AccountCurrency_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.CreditAccounts", "AccountCurrency_Id");
            AddForeignKey("dbo.CreditAccounts", "AccountCurrency_Id", "dbo.CurrencyModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditAccounts", "AccountCurrency_Id", "dbo.CurrencyModels");
            DropIndex("dbo.CreditAccounts", new[] { "AccountCurrency_Id" });
            DropColumn("dbo.CreditAccounts", "AccountCurrency_Id");
        }
    }
}
