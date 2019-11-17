namespace AttributeRoutingDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ActorID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieID = c.Int(nullable: false, identity: true),
                        MovieTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MovieID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
            DropTable("dbo.Actors");
        }
    }
}
