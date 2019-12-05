namespace AddressBookEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class external_contact_id : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "ExternalId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contact", "ExternalId");
        }
    }
}
