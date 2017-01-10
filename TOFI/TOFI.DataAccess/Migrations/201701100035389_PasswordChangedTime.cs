namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasswordChangedTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AuthData", "PasswordChangedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AuthData", "PasswordChangedUtc");
        }
    }
}
