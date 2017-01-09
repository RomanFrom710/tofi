namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditRequestAssigned : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditRequests", "LatestEmployeeHandledBy_Id", c => c.Int());
            CreateIndex("dbo.CreditRequests", "LatestEmployeeHandledBy_Id");
            AddForeignKey("dbo.CreditRequests", "LatestEmployeeHandledBy_Id", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditRequests", "LatestEmployeeHandledBy_Id", "dbo.Employees");
            DropIndex("dbo.CreditRequests", new[] { "LatestEmployeeHandledBy_Id" });
            DropColumn("dbo.CreditRequests", "LatestEmployeeHandledBy_Id");
        }
    }
}
