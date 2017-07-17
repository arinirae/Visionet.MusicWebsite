namespace Visionet.MusicWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Musics", "IdUser", "dbo.Users");
            DropIndex("dbo.Musics", new[] { "IdUser" });
            CreateTable(
                "dbo.UserMusics",
                c => new
                    {
                        User_IdUser = c.Int(nullable: false),
                        Music_IdMusic = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_IdUser, t.Music_IdMusic })
                .ForeignKey("dbo.Users", t => t.User_IdUser, cascadeDelete: true)
                .ForeignKey("dbo.Musics", t => t.Music_IdMusic, cascadeDelete: true)
                .Index(t => t.User_IdUser)
                .Index(t => t.Music_IdMusic);
            
            DropColumn("dbo.Musics", "IdUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Musics", "IdUser", c => c.Int());
            DropForeignKey("dbo.UserMusics", "Music_IdMusic", "dbo.Musics");
            DropForeignKey("dbo.UserMusics", "User_IdUser", "dbo.Users");
            DropIndex("dbo.UserMusics", new[] { "Music_IdMusic" });
            DropIndex("dbo.UserMusics", new[] { "User_IdUser" });
            DropTable("dbo.UserMusics");
            CreateIndex("dbo.Musics", "IdUser");
            AddForeignKey("dbo.Musics", "IdUser", "dbo.Users", "IdUser");
        }
    }
}
