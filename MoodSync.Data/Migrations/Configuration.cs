namespace MoodSync.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MoodSync.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MoodSync.Data.ApplicationDbContext";
        }

        protected override void Seed(MoodSync.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var adminGenre = context.Users.First();
            context.Genres.AddOrUpdate(x => x.GenreId,
               new Genre() { GenreId = 1, GenreName = "Rock" },
               new Genre() { GenreId = 2, GenreName = "Alternative" },
               new Genre() { GenreId = 3, GenreName = "Classical" },
               new Genre() { GenreId = 4, GenreName = "Hip Hop" },
               new Genre() { GenreId = 5, GenreName = "Blues" },
               new Genre() { GenreId = 6, GenreName = "Pop" },
               new Genre() { GenreId = 7, GenreName = "Jazz" },
               new Genre() { GenreId = 8, GenreName = "R&B" },
               new Genre() { GenreId = 9, GenreName = "Death Metal" },
               new Genre() { GenreId = 10, GenreName = "Country" }
                );

            var adminMood = context.Users.First();
            context.Moods.AddOrUpdate(x => x.MoodId,
            new Mood() { MoodId = 1, MoodName = "Happy" },
            new Mood() { MoodId = 2, MoodName = "Sad" },
            new Mood() { MoodId = 3, MoodName = "Angry" },
            new Mood() { MoodId = 4, MoodName = "Romantic" },
            new Mood() { MoodId = 5, MoodName = "Scatter Brained" },
            new Mood() { MoodId = 6, MoodName = "Exhausted" },
            new Mood() { MoodId = 7, MoodName = "Excited" },
            new Mood() { MoodId = 8, MoodName = "Moody" },
            new Mood() { MoodId = 9, MoodName = "Hangry" },
            new Mood() { MoodId = 10, MoodName = "Optimistic" }

            );

            var adminSong = context.Users.First();
            context.Songs.AddOrUpdate(x => x.SongId,
                new Song() { SongId = 1, SongName = "Happy", Artist = "Pharell Williams", Album = "G I R L", GenreId = 6, ChildFriendly = true },
                new Song() { SongId = 2, SongName = "Sweet Caroline", Artist = "Neil Diamond", Album = "Greatest Hits", GenreId = 6, ChildFriendly = true },
                new Song() { SongId = 3, SongName = "Hot in Herre", Artist = "Nelly", Album = "Nellyville", GenreId = 4, ChildFriendly = false },
                new Song() { SongId = 4, SongName = "Ricky, Don't Lose that Number", Artist = "Steely Dan", Album = "A Decade of Steely Dan", GenreId = 1, ChildFriendly = true },
                new Song() { SongId = 5, SongName = "Sand in My Sheets", Artist = "Tommy Green Jr.", Album = "Tommy Green Jr.", GenreId = 6, ChildFriendly = true }
                );

            var adminPlaylist = context.Users.First();
            context.Playlists.AddOrUpdate(x => x.PlaylistId,
            new Playlist() { PlaylistId = 1, UserId = new Guid(adminPlaylist.Id), PlaylistName = "Happy", SongList = "1, 2, 4" },
            new Playlist() { PlaylistId = 2, UserId = new Guid(adminPlaylist.Id), PlaylistName = "Optimistic", SongList = "1, 2, 4, 5" }
            );


        }
    }
}