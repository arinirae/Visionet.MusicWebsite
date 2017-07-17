namespace Visionet.MusicWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_user_music : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Musics",
                c => new
                    {
                        IdMusic = c.Int(nullable: false, identity: true),
                        FavMusic = c.String(),
                        IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.IdMusic)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        User_IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.IdUser)
                .ForeignKey("dbo.Users", t => t.User_IdUser)
                .Index(t => t.User_IdUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Musics", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Users", "User_IdUser", "dbo.Users");
            DropIndex("dbo.Users", new[] { "User_IdUser" });
            DropIndex("dbo.Musics", new[] { "IdUser" });
            DropTable("dbo.Users");
            DropTable("dbo.Musics");
        }
    }
}
