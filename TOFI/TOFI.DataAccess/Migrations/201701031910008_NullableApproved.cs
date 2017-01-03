namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableApproved : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CreditRequests", "IsSecurityApproved", c => c.Boolean());
            AlterColumn("dbo.CreditRequests", "IsCreditCommitteeApproved", c => c.Boolean());
            AlterColumn("dbo.CreditRequests", "IsCreditDepartmentApproved", c => c.Boolean());
            AlterColumn("dbo.CreditRequests", "IsCashierApproved", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CreditRequests", "IsCashierApproved", c => c.Boolean(nullable: false));
            AlterColumn("dbo.CreditRequests", "IsCreditDepartmentApproved", c => c.Boolean(nullable: false));
            AlterColumn("dbo.CreditRequests", "IsCreditCommitteeApproved", c => c.Boolean(nullable: false));
            AlterColumn("dbo.CreditRequests", "IsSecurityApproved", c => c.Boolean(nullable: false));
        }
    }
}
