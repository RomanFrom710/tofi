namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditRequest_Operator : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CreditRequests", name: "CashierApproved_Id", newName: "OperatorApproved_Id");
            RenameIndex(table: "dbo.CreditRequests", name: "IX_CashierApproved_Id", newName: "IX_OperatorApproved_Id");
            AddColumn("dbo.CreditRequests", "IsOperatorApproved", c => c.Boolean());
            AddColumn("dbo.CreditRequests", "OperatorComments", c => c.String());
            DropColumn("dbo.CreditRequests", "IsCashierApproved");
            DropColumn("dbo.CreditRequests", "CashierComments");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CreditRequests", "CashierComments", c => c.String());
            AddColumn("dbo.CreditRequests", "IsCashierApproved", c => c.Boolean());
            DropColumn("dbo.CreditRequests", "OperatorComments");
            DropColumn("dbo.CreditRequests", "IsOperatorApproved");
            RenameIndex(table: "dbo.CreditRequests", name: "IX_OperatorApproved_Id", newName: "IX_CashierApproved_Id");
            RenameColumn(table: "dbo.CreditRequests", name: "OperatorApproved_Id", newName: "CashierApproved_Id");
        }
    }
}
