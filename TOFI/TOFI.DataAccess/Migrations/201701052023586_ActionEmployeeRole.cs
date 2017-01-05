namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActionEmployeeRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaymentActions", "EmployeeRole", c => c.String());
            AddColumn("dbo.RequestActions", "EmployeeRole", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RequestActions", "EmployeeRole");
            DropColumn("dbo.PaymentActions", "EmployeeRole");
        }
    }
}
