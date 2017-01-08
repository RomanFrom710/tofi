namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditAccountStateTotalDebt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CreditAccountStates", "TotalDebt_Id", "dbo.PriceModels");
            DropIndex("dbo.CreditAccountStates", new[] { "TotalDebt_Id" });
            DropColumn("dbo.CreditAccountStates", "TotalDebt_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CreditAccountStates", "TotalDebt_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.CreditAccountStates", "TotalDebt_Id");
            AddForeignKey("dbo.CreditAccountStates", "TotalDebt_Id", "dbo.PriceModels", "Id");
        }
    }
}
