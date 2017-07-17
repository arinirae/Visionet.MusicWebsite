namespace Visionet.MusicWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetManyToManyUsrs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "User_IdUser", "dbo.Users");
            DropIndex("dbo.Users", new[] { "User_IdUser" });
            CreateTable(
                "dbo.UserUsers",
                c => new
                    {
                        User_IdUser = c.Int(nullable: false),
                        User_IdUser1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_IdUser, t.User_IdUser1 })
                .ForeignKey("dbo.Users", t => t.User_IdUser)
                .ForeignKey("dbo.Users", t => t.User_IdUser1)
                .Index(t => t.User_IdUser)
                .Index(t => t.User_IdUser1);
            
            DropColumn("dbo.Users", "User_IdUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "User_IdUser", c => c.Int());
            DropForeignKey("dbo.UserUsers", "User_IdUser1", "dbo.Users");
            DropForeignKey("dbo.UserUsers", "User_IdUser", "dbo.Users");
            DropIndex("dbo.UserUsers", new[] { "User_IdUser1" });
            DropIndex("dbo.UserUsers", new[] { "User_IdUser" });
            DropTable("dbo.UserUsers");
            CreateIndex("dbo.Users", "User_IdUser");
            AddForeignKey("dbo.Users", "User_IdUser", "dbo.Users", "IdUser");
        }
    }
}
