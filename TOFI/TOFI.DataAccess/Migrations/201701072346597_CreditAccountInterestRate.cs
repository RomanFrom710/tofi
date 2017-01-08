namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditAccountInterestRate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CreditAccounts", "InterestRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CreditAccounts", "InterestRate", c => c.Double(nullable: false));
        }
    }
}
