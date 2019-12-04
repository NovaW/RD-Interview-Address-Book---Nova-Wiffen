namespace AddressBookEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactNumber",
                c => new
                    {
                        ContactNumberId = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Contact_ContactId = c.Int(),
                    })
                .PrimaryKey(t => t.ContactNumberId)
                .ForeignKey("dbo.Contact", t => t.Contact_ContactId)
                .Index(t => t.Contact_ContactId);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.EmailAddress",
                c => new
                    {
                        EmailAddressId = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Contact_ContactId = c.Int(),
                    })
                .PrimaryKey(t => t.EmailAddressId)
                .ForeignKey("dbo.Contact", t => t.Contact_ContactId)
                .Index(t => t.Contact_ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmailAddress", "Contact_ContactId", "dbo.Contact");
            DropForeignKey("dbo.ContactNumber", "Contact_ContactId", "dbo.Contact");
            DropIndex("dbo.EmailAddress", new[] { "Contact_ContactId" });
            DropIndex("dbo.ContactNumber", new[] { "Contact_ContactId" });
            DropTable("dbo.EmailAddress");
            DropTable("dbo.Contact");
            DropTable("dbo.ContactNumber");
        }
    }
}
