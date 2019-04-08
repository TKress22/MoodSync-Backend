using MoodSync.Models.Song;
using MoodSync.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodsync.Services
{
    class SongService
    {
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