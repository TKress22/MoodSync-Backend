using MoodSync.Models;
using MoodSync.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodsync.Services
{
    public class SongService
    {
        public bool CreateSong(SongCreate model)
        {
            var entity =
                new Song()
                {
                    SongId = model.SongId,
                    SongName = model.SongName,
                    GenreId = model.GenreId,
                    Album = model.Album,
                    Artist = model.Artist,
                    ChildFriendly = model.ChildFriendly
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Songs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public SongFetch GetSongById(int songId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongId == songId);
                return
                    new SongFetch
                    {
                        SongId = entity.SongId,
                        GenreId = entity.GenreId,
                        SongName = entity.SongName,
                        Album = entity.Album,
                        Artist = entity.Artist,
                        ChildFriendly = entity.ChildFriendly
                    };
            }
        }
        public IEnumerable<SongFetch> GetSongByGenre(int genreId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Songs
                        .Where(e => e.GenreId == genreId)
                        .Select(
                            e =>
                                new SongFetch
                                {
                                    SongId = e.SongId,
                                    GenreId = e.GenreId,
                                    SongName = e.SongName,
                                    Album = e.Album,
                                    Artist = e.Artist,
                                    ChildFriendly = e.ChildFriendly
                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<SongFetch> GetSongByArtist(string artist)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Songs
                        .Where(e => e.Artist == artist)
                        .Select(
                            e =>
                                new SongFetch
                                {
                                    SongId = e.SongId,
                                    GenreId = e.GenreId,
                                    SongName = e.SongName,
                                    Album = e.Album,
                                    Artist = e.Artist,
                                    ChildFriendly = e.ChildFriendly
                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<SongFetch> GetSongByAlbum(string album)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Songs
                        .Where(e => e.Album == album)
                        .Select(
                            e =>
                                new SongFetch
                                {
                                    SongId = e.SongId,
                                    GenreId = e.GenreId,
                                    SongName = e.SongName,
                                    Album = e.Album,
                                    Artist = e.Artist,
                                    ChildFriendly = e.ChildFriendly
                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<SongFetch> GetSongByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Songs
                        .Where(e => e.SongName == name)
                        .Select(
                            e =>
                                new SongFetch
                                {
                                    SongId = e.SongId,
                                    GenreId = e.GenreId,
                                    SongName = e.SongName,
                                    Album = e.Album,
                                    Artist = e.Artist,
                                    ChildFriendly = e.ChildFriendly
                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<SongFetch> GetSongByChildFriendly(bool friendly)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Songs
                        .Where(e => e.ChildFriendly == friendly)
                        .Select(
                            e =>
                                new SongFetch
                                {
                                    SongId = e.SongId,
                                    GenreId = e.GenreId,
                                    SongName = e.SongName,
                                    Album = e.Album,
                                    Artist = e.Artist,
                                    ChildFriendly = e.ChildFriendly
                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<SongFetch> GetSongs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Songs
                        .Select(
                            e =>
                                new SongFetch
                                {
                                    SongId = e.SongId,
                                    GenreId = e.GenreId,
                                    SongName = e.SongName,
                                    Album = e.Album,
                                    Artist = e.Artist,
                                    ChildFriendly = e.ChildFriendly
                                }
                        );

                return query.ToArray();
            }
        }
        public bool DeleteSong(int songId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongId == songId);

                ctx.Songs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        public bool UpdateSong(SongFetch model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongId == model.SongId);

                entity.SongName = model.SongName;
                entity.GenreId = model.GenreId;
                entity.Album = model.Album;
                entity.Artist = model.Artist;
                entity.ChildFriendly = model.ChildFriendly;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}