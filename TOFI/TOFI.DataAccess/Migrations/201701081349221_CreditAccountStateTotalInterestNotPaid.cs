namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditAccountStateTotalInterestNotPaid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditAccountStates", "TotalInterestSumNotPaid_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.CreditAccountStates", "TotalInterestSumNotPaid_Id");
            AddForeignKey("dbo.CreditAccountStates", "TotalInterestSumNotPaid_Id", "dbo.PriceModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditAccountStates", "TotalInterestSumNotPaid_Id", "dbo.PriceModels");
            DropIndex("dbo.CreditAccountStates", new[] { "TotalInterestSumNotPaid_Id" });
            DropColumn("dbo.CreditAccountStates", "TotalInterestSumNotPaid_Id");
        }
    }
}
