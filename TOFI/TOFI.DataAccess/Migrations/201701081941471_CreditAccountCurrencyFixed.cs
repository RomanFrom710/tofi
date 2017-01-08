namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditAccountCurrencyFixed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CreditAccounts", "AccountCurrency_Id", "dbo.CurrencyModels");
            AddForeignKey("dbo.CreditAccounts", "AccountCurrency_Id", "dbo.CurrencyModels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditAccounts", "AccountCurrency_Id", "dbo.CurrencyModels");
            AddForeignKey("dbo.CreditAccounts", "AccountCurrency_Id", "dbo.CurrencyModels", "Id");
        }
    }
}
