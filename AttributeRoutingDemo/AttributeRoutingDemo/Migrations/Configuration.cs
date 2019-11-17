namespace AttributeRoutingDemo.Migrations

{
    using AttributeRoutingDemo.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AttributeRoutingDemo.Models.MovieDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AttributeRoutingDemo.Models.MovieDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            
            

            Movie Shawshank = new Movie() { MovieID = 1, MovieTitle = "The Shawshank Redemption", Actors = new List<Actor>() };

            Actor TimRobbins = new Actor() { ActorID = 1, FirstName = "Tim", LastName = "Robbins", Movies = new List<Movie>() };
            Actor MorganFreeman = new Actor() { ActorID = 2, FirstName = "Morgan", LastName = "Freeman", Movies = new List<Movie>() };
            Actor BobGunton = new Actor() { ActorID = 3, FirstName = "Bob", LastName = "Gunton", Movies = new List<Movie>() };

            Shawshank.Actors.Add(TimRobbins);
            Shawshank.Actors.Add(MorganFreeman);
            Shawshank.Actors.Add(BobGunton);

            TimRobbins.Movies.Add(Shawshank);
            MorganFreeman.Movies.Add(Shawshank);
            BobGunton.Movies.Add(Shawshank);

            Movie BruceAlmighty = new Movie() { MovieID = 2, MovieTitle = "Bruce Almighty", Actors = new List<Actor>() };

            Actor JimCarrey = new Actor() { ActorID = 4, FirstName = "Jim", LastName = "Carrey", Movies = new List<Movie>() };
            Actor JenniferAniston = new Actor() { ActorID = 5, FirstName = "Jennifer", LastName = "Aniston", Movies = new List<Movie>() };

            BruceAlmighty.Actors.Add(JimCarrey);
            BruceAlmighty.Actors.Add(MorganFreeman);
            BruceAlmighty.Actors.Add(JenniferAniston);

            JimCarrey.Movies.Add(BruceAlmighty);
            MorganFreeman.Movies.Add(BruceAlmighty);
            JenniferAniston.Movies.Add(BruceAlmighty);

            Movie SpotleessMind = new Movie() { MovieID = 3, MovieTitle = "Eternal Sunshine of the Spotless Mind", Actors = new List<Actor>() };

            Actor KateWinslet = new Actor() { ActorID = 6, FirstName = "Kate", LastName = "Winslet", Movies = new List<Movie>() };
            Actor ElijahWood = new Actor() { ActorID = 7, FirstName = "Elijah", LastName = "Wood", Movies = new List<Movie>() };

            SpotleessMind.Actors.Add(JimCarrey);
            SpotleessMind.Actors.Add(KateWinslet);
            SpotleessMind.Actors.Add(ElijahWood);

            JimCarrey.Movies.Add(SpotleessMind);
            KateWinslet.Movies.Add(SpotleessMind);
            ElijahWood.Movies.Add(SpotleessMind);

            context.Movies.AddOrUpdate(Shawshank, BruceAlmighty, SpotleessMind);
            context.Actors.AddOrUpdate(TimRobbins, MorganFreeman, BobGunton, JimCarrey, JenniferAniston, KateWinslet, ElijahWood);
        }
    }
}
