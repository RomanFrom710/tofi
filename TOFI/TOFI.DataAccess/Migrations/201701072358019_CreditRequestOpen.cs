namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditRequestOpen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditRequests", "IsOpen", c => c.Boolean());
            AddColumn("dbo.CreditRequests", "RequestOpener_Id", c => c.Int());
            CreateIndex("dbo.CreditRequests", "RequestOpener_Id");
            AddForeignKey("dbo.CreditRequests", "RequestOpener_Id", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditRequests", "RequestOpener_Id", "dbo.Employees");
            DropIndex("dbo.CreditRequests", new[] { "RequestOpener_Id" });
            DropColumn("dbo.CreditRequests", "RequestOpener_Id");
            DropColumn("dbo.CreditRequests", "IsOpen");
        }
    }
}
