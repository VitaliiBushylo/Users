namespace SPA_Users.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedActivities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserActivities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        Activity = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserActivities", "User_Id", "dbo.Users");
            DropIndex("dbo.UserActivities", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.UserActivities");
        }
    }
}
