namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditAccountClosed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditAccounts", "IsClosed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CreditAccounts", "IsClosed");
        }
    }
}
