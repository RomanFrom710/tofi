namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditAccountDuration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditAccounts", "TotalMonthDuration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CreditAccounts", "TotalMonthDuration");
        }
    }
}
