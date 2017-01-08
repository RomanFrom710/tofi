namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditAccountClient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CreditAccounts", "User_Id", "dbo.Users");
            DropIndex("dbo.CreditAccounts", new[] { "User_Id" });
            AddColumn("dbo.CreditAccounts", "Client_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.CreditAccounts", "Client_Id");
            AddForeignKey("dbo.CreditAccounts", "Client_Id", "dbo.Clients", "Id", cascadeDelete: true);
            DropColumn("dbo.CreditAccounts", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CreditAccounts", "User_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.CreditAccounts", "Client_Id", "dbo.Clients");
            DropIndex("dbo.CreditAccounts", new[] { "Client_Id" });
            DropColumn("dbo.CreditAccounts", "Client_Id");
            CreateIndex("dbo.CreditAccounts", "User_Id");
            AddForeignKey("dbo.CreditAccounts", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
