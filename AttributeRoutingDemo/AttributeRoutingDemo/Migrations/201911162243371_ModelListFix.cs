namespace AttributeRoutingDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelListFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieActors", "Movie_MovieID", "dbo.Movies");
            DropForeignKey("dbo.MovieActors", "Actor_ActorID", "dbo.Actors");
            DropIndex("dbo.MovieActors", new[] { "Movie_MovieID" });
            DropIndex("dbo.MovieActors", new[] { "Actor_ActorID" });
            DropTable("dbo.MovieActors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        Movie_MovieID = c.Int(nullable: false),
                        Actor_ActorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_MovieID, t.Actor_ActorID });
            
            CreateIndex("dbo.MovieActors", "Actor_ActorID");
            CreateIndex("dbo.MovieActors", "Movie_MovieID");
            AddForeignKey("dbo.MovieActors", "Actor_ActorID", "dbo.Actors", "ActorID", cascadeDelete: true);
            AddForeignKey("dbo.MovieActors", "Movie_MovieID", "dbo.Movies", "MovieID", cascadeDelete: true);
        }
    }
}
