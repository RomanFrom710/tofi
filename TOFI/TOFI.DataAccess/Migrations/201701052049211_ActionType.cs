namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActionType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaymentActions", "ActionType", c => c.String());
            AddColumn("dbo.RequestActions", "ActionType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RequestActions", "ActionType");
            DropColumn("dbo.PaymentActions", "ActionType");
        }
    }
}
