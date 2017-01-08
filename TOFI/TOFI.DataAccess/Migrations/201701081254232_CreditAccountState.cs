namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditAccountState : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CreditAccounts", "FinesForOverdue_Id", "dbo.PriceModels");
            DropForeignKey("dbo.CreditAccounts", "RemainDebt_Id", "dbo.PriceModels");
            DropForeignKey("dbo.CreditAccounts", "TotalDebt_Id", "dbo.PriceModels");
            DropIndex("dbo.CreditAccounts", new[] { "FinesForOverdue_Id" });
            DropIndex("dbo.CreditAccounts", new[] { "RemainDebt_Id" });
            DropIndex("dbo.CreditAccounts", new[] { "TotalDebt_Id" });
            CreateTable(
                "dbo.CreditAccountStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Month = c.Int(nullable: false),
                        CreditAccount_Id = c.Int(nullable: false),
                        FinesForOverdue_Id = c.Int(nullable: false),
                        InterestCounted_Id = c.Int(nullable: false),
                        RemainDebt_Id = c.Int(nullable: false),
                        TotalDebt_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditAccounts", t => t.CreditAccount_Id)
                .ForeignKey("dbo.PriceModels", t => t.FinesForOverdue_Id)
                .ForeignKey("dbo.PriceModels", t => t.InterestCounted_Id)
                .ForeignKey("dbo.PriceModels", t => t.RemainDebt_Id)
                .ForeignKey("dbo.PriceModels", t => t.TotalDebt_Id)
                .Index(t => t.CreditAccount_Id)
                .Index(t => t.FinesForOverdue_Id)
                .Index(t => t.InterestCounted_Id)
                .Index(t => t.RemainDebt_Id)
                .Index(t => t.TotalDebt_Id);
            
            AddColumn("dbo.CreditAccounts", "AgreementDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.CreditAccounts", "FinesForOverdue_Id");
            DropColumn("dbo.CreditAccounts", "RemainDebt_Id");
            DropColumn("dbo.CreditAccounts", "TotalDebt_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CreditAccounts", "TotalDebt_Id", c => c.Int(nullable: false));
            AddColumn("dbo.CreditAccounts", "RemainDebt_Id", c => c.Int(nullable: false));
            AddColumn("dbo.CreditAccounts", "FinesForOverdue_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.CreditAccountStates", "TotalDebt_Id", "dbo.PriceModels");
            DropForeignKey("dbo.CreditAccountStates", "RemainDebt_Id", "dbo.PriceModels");
            DropForeignKey("dbo.CreditAccountStates", "InterestCounted_Id", "dbo.PriceModels");
            DropForeignKey("dbo.CreditAccountStates", "FinesForOverdue_Id", "dbo.PriceModels");
            DropForeignKey("dbo.CreditAccountStates", "CreditAccount_Id", "dbo.CreditAccounts");
            DropIndex("dbo.CreditAccountStates", new[] { "TotalDebt_Id" });
            DropIndex("dbo.CreditAccountStates", new[] { "RemainDebt_Id" });
            DropIndex("dbo.CreditAccountStates", new[] { "InterestCounted_Id" });
            DropIndex("dbo.CreditAccountStates", new[] { "FinesForOverdue_Id" });
            DropIndex("dbo.CreditAccountStates", new[] { "CreditAccount_Id" });
            DropColumn("dbo.CreditAccounts", "AgreementDate");
            DropTable("dbo.CreditAccountStates");
            CreateIndex("dbo.CreditAccounts", "TotalDebt_Id");
            CreateIndex("dbo.CreditAccounts", "RemainDebt_Id");
            CreateIndex("dbo.CreditAccounts", "FinesForOverdue_Id");
            AddForeignKey("dbo.CreditAccounts", "TotalDebt_Id", "dbo.PriceModels", "Id");
            AddForeignKey("dbo.CreditAccounts", "RemainDebt_Id", "dbo.PriceModels", "Id");
            AddForeignKey("dbo.CreditAccounts", "FinesForOverdue_Id", "dbo.PriceModels", "Id");
        }
    }
}
