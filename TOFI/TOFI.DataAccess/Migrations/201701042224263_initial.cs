namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PasswordHash = c.String(),
                        Salt = c.String(),
                        SecurityStamp = c.String(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCnt = c.Int(nullable: false),
                        LockoutDateUtc = c.DateTimeOffset(precision: 7),
                        AccessGrantedTotal = c.Int(nullable: false),
                        LastAccessGrantedDateUtc = c.DateTimeOffset(precision: 7),
                        AccessFailedTotal = c.Int(nullable: false),
                        LastAccessFailedDateUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Key = c.String(),
                        Auth_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuthData", t => t.Auth_Id)
                .Index(t => t.Auth_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        TelephoneNumber = c.String(),
                        PassportNumber = c.String(),
                        PassportId = c.String(),
                        Authority = c.String(),
                        IssueDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Sex = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.CreditRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsOperatorApproved = c.Boolean(),
                        IsSecurityApproved = c.Boolean(),
                        IsCreditCommitteeApproved = c.Boolean(),
                        IsCreditDepartmentApproved = c.Boolean(),
                        OperatorComments = c.String(),
                        SecurityComments = c.String(),
                        CreditCommitteeComments = c.String(),
                        CreditDepartmentComments = c.String(),
                        MonthDuration = c.Int(nullable: false),
                        CreditPurpose = c.String(),
                        Client_Id = c.Int(nullable: false),
                        CreditCommitteeApproved_Id = c.Int(),
                        CreditDepartmentApproved_Id = c.Int(),
                        CreditSum_Id = c.Int(nullable: false),
                        CreditType_Id = c.Int(nullable: false),
                        OperatorApproved_Id = c.Int(),
                        SecurityApproved_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.CreditCommitteeApproved_Id)
                .ForeignKey("dbo.Employees", t => t.CreditDepartmentApproved_Id)
                .ForeignKey("dbo.PriceModels", t => t.CreditSum_Id)
                .ForeignKey("dbo.CreditTypes", t => t.CreditType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.OperatorApproved_Id)
                .ForeignKey("dbo.Employees", t => t.SecurityApproved_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.CreditCommitteeApproved_Id)
                .Index(t => t.CreditDepartmentApproved_Id)
                .Index(t => t.CreditSum_Id)
                .Index(t => t.CreditType_Id)
                .Index(t => t.OperatorApproved_Id)
                .Index(t => t.SecurityApproved_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rights = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.CreditPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                        CreditAccount_Id = c.Int(nullable: false),
                        PaymentSum_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditAccounts", t => t.CreditAccount_Id, cascadeDelete: true)
                .ForeignKey("dbo.PriceModels", t => t.PaymentSum_Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.CreditAccount_Id)
                .Index(t => t.PaymentSum_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.CreditAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreditAgreementNumber = c.String(),
                        Description = c.String(),
                        InterestRate = c.Double(nullable: false),
                        CreditType_Id = c.Int(nullable: false),
                        FinesForOverdue_Id = c.Int(nullable: false),
                        RemainDebt_Id = c.Int(nullable: false),
                        TotalDebt_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditTypes", t => t.CreditType_Id, cascadeDelete: true)
                .ForeignKey("dbo.PriceModels", t => t.FinesForOverdue_Id)
                .ForeignKey("dbo.PriceModels", t => t.RemainDebt_Id)
                .ForeignKey("dbo.PriceModels", t => t.TotalDebt_Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.CreditType_Id)
                .Index(t => t.FinesForOverdue_Id)
                .Index(t => t.RemainDebt_Id)
                .Index(t => t.TotalDebt_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.CreditTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        InterestRate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CreditConditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MonthDurationFrom = c.Int(nullable: false),
                        MonthDurationTo = c.Int(nullable: false),
                        MaxCreditSum_Id = c.Int(nullable: false),
                        MinCreditSum_Id = c.Int(nullable: false),
                        CreditType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PriceModels", t => t.MaxCreditSum_Id)
                .ForeignKey("dbo.PriceModels", t => t.MinCreditSum_Id)
                .ForeignKey("dbo.CreditTypes", t => t.CreditType_Id, cascadeDelete: true)
                .Index(t => t.MaxCreditSum_Id)
                .Index(t => t.MinCreditSum_Id)
                .Index(t => t.CreditType_Id);
            
            CreateTable(
                "dbo.PriceModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CurrencyModels", t => t.Currency_Id, cascadeDelete: true)
                .Index(t => t.Currency_Id);
            
            CreateTable(
                "dbo.CurrencyModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CreditRequirements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ExpectedValue = c.String(),
                        CreditType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditTypes", t => t.CreditType_Id, cascadeDelete: true)
                .Index(t => t.CreditType_Id);
            
            CreateTable(
                "dbo.PaymentActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Signature = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        CreditPayment_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditPayments", t => t.CreditPayment_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.CreditPayment_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.RequestActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Signature = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        CreditRequest_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditRequests", t => t.CreditRequest_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.CreditRequest_Id)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Auth_Id", "dbo.AuthData");
            DropForeignKey("dbo.Employees", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Clients", "User_Id", "dbo.Users");
            DropForeignKey("dbo.CreditRequests", "SecurityApproved_Id", "dbo.Employees");
            DropForeignKey("dbo.CreditRequests", "OperatorApproved_Id", "dbo.Employees");
            DropForeignKey("dbo.CreditRequests", "CreditType_Id", "dbo.CreditTypes");
            DropForeignKey("dbo.CreditRequests", "CreditSum_Id", "dbo.PriceModels");
            DropForeignKey("dbo.CreditRequests", "CreditDepartmentApproved_Id", "dbo.Employees");
            DropForeignKey("dbo.CreditRequests", "CreditCommitteeApproved_Id", "dbo.Employees");
            DropForeignKey("dbo.RequestActions", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.RequestActions", "CreditRequest_Id", "dbo.CreditRequests");
            DropForeignKey("dbo.PaymentActions", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.PaymentActions", "CreditPayment_Id", "dbo.CreditPayments");
            DropForeignKey("dbo.CreditPayments", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.CreditPayments", "PaymentSum_Id", "dbo.PriceModels");
            DropForeignKey("dbo.CreditAccounts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.CreditAccounts", "TotalDebt_Id", "dbo.PriceModels");
            DropForeignKey("dbo.CreditAccounts", "RemainDebt_Id", "dbo.PriceModels");
            DropForeignKey("dbo.CreditPayments", "CreditAccount_Id", "dbo.CreditAccounts");
            DropForeignKey("dbo.CreditAccounts", "FinesForOverdue_Id", "dbo.PriceModels");
            DropForeignKey("dbo.CreditRequirements", "CreditType_Id", "dbo.CreditTypes");
            DropForeignKey("dbo.CreditConditions", "CreditType_Id", "dbo.CreditTypes");
            DropForeignKey("dbo.CreditConditions", "MinCreditSum_Id", "dbo.PriceModels");
            DropForeignKey("dbo.CreditConditions", "MaxCreditSum_Id", "dbo.PriceModels");
            DropForeignKey("dbo.PriceModels", "Currency_Id", "dbo.CurrencyModels");
            DropForeignKey("dbo.CreditAccounts", "CreditType_Id", "dbo.CreditTypes");
            DropForeignKey("dbo.CreditRequests", "Client_Id", "dbo.Clients");
            DropIndex("dbo.RequestActions", new[] { "Employee_Id" });
            DropIndex("dbo.RequestActions", new[] { "CreditRequest_Id" });
            DropIndex("dbo.PaymentActions", new[] { "Employee_Id" });
            DropIndex("dbo.PaymentActions", new[] { "CreditPayment_Id" });
            DropIndex("dbo.CreditRequirements", new[] { "CreditType_Id" });
            DropIndex("dbo.PriceModels", new[] { "Currency_Id" });
            DropIndex("dbo.CreditConditions", new[] { "CreditType_Id" });
            DropIndex("dbo.CreditConditions", new[] { "MinCreditSum_Id" });
            DropIndex("dbo.CreditConditions", new[] { "MaxCreditSum_Id" });
            DropIndex("dbo.CreditAccounts", new[] { "User_Id" });
            DropIndex("dbo.CreditAccounts", new[] { "TotalDebt_Id" });
            DropIndex("dbo.CreditAccounts", new[] { "RemainDebt_Id" });
            DropIndex("dbo.CreditAccounts", new[] { "FinesForOverdue_Id" });
            DropIndex("dbo.CreditAccounts", new[] { "CreditType_Id" });
            DropIndex("dbo.CreditPayments", new[] { "Employee_Id" });
            DropIndex("dbo.CreditPayments", new[] { "PaymentSum_Id" });
            DropIndex("dbo.CreditPayments", new[] { "CreditAccount_Id" });
            DropIndex("dbo.Employees", new[] { "User_Id" });
            DropIndex("dbo.CreditRequests", new[] { "SecurityApproved_Id" });
            DropIndex("dbo.CreditRequests", new[] { "OperatorApproved_Id" });
            DropIndex("dbo.CreditRequests", new[] { "CreditType_Id" });
            DropIndex("dbo.CreditRequests", new[] { "CreditSum_Id" });
            DropIndex("dbo.CreditRequests", new[] { "CreditDepartmentApproved_Id" });
            DropIndex("dbo.CreditRequests", new[] { "CreditCommitteeApproved_Id" });
            DropIndex("dbo.CreditRequests", new[] { "Client_Id" });
            DropIndex("dbo.Clients", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "Auth_Id" });
            DropTable("dbo.RequestActions");
            DropTable("dbo.PaymentActions");
            DropTable("dbo.CreditRequirements");
            DropTable("dbo.CurrencyModels");
            DropTable("dbo.PriceModels");
            DropTable("dbo.CreditConditions");
            DropTable("dbo.CreditTypes");
            DropTable("dbo.CreditAccounts");
            DropTable("dbo.CreditPayments");
            DropTable("dbo.Employees");
            DropTable("dbo.CreditRequests");
            DropTable("dbo.Clients");
            DropTable("dbo.Users");
            DropTable("dbo.AuthData");
        }
    }
}
