namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditAccountStateMainDebt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditAccountStates", "MainDebtRemain_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.CreditAccountStates", "MainDebtRemain_Id");
            AddForeignKey("dbo.CreditAccountStates", "MainDebtRemain_Id", "dbo.PriceModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditAccountStates", "MainDebtRemain_Id", "dbo.PriceModels");
            DropIndex("dbo.CreditAccountStates", new[] { "MainDebtRemain_Id" });
            DropColumn("dbo.CreditAccountStates", "MainDebtRemain_Id");
        }
    }
}
