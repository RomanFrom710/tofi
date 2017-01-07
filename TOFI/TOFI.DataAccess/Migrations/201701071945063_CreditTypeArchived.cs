namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditTypeArchived : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditTypes", "IsArchived", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CreditTypes", "IsArchived");
        }
    }
}
