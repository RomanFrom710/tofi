namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditPurpose : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditRequests", "CreditPurpose", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CreditRequests", "CreditPurpose");
        }
    }
}
