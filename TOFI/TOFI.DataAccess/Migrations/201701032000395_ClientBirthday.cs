namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientBirthday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Birthday", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "Birthday");
        }
    }
}
