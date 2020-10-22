namespace TAIClientSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 60),
                        FirstName = c.String(nullable: false, maxLength: 60),
                        Gender = c.String(nullable: false, maxLength: 6),
                        DateOfBirth = c.DateTime(nullable: false),
                        Company = c.String(nullable: false, maxLength: 60),
                        PolicyNumber = c.String(nullable: false, maxLength: 60),
                        IssueState = c.String(nullable: false, maxLength: 10),
                        FaceAmount = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clients");
        }
    }
}
