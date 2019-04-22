using MoodSync.Data;
using MoodSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodsync.Services
{
    public class PlaylistService
    {
        private readonly Guid _userId;

        public PlaylistService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePlaylist(PlaylistCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var playlist = new Playlist()
                {
                    PlaylistName = model.PlaylistName,
                    SongList = model.SongList,
                };
                ctx.Playlists.Add(playlist);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PlaylistListItem> GetPlaylist()
        {
            Guid AdminId = new Guid("c64823e1-4799-4dd0-887b-b9aba7e60ee2");
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Playlists
                    .Where(e => e.UserId == _userId || e.UserId == AdminId)
                    .Select(
                        e =>
                        new PlaylistListItem
                        {
                            UserId = e.UserId,
                            PlaylistId = e.PlaylistId,
                            PlaylistName = e.PlaylistName,
                            SongList = e.SongList,
                        }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<PlaylistListItem> AdminGetPlaylist()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Playlists
                    .Select(
                        e =>
                        new PlaylistListItem
                        {
                            UserId = e.UserId,
                            PlaylistId = e.PlaylistId,
                            PlaylistName = e.PlaylistName,
                            SongList = e.SongList,
                        }
                        );
                return query.ToArray();
            }
        }
        public PlaylistDetail GetPlaylistById(int playlistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Playlists
                    .Single(e => e.PlaylistId == playlistId && e.UserId == _userId);
                return
                    new PlaylistDetail
                    {
                        UserId = entity.UserId,
                        PlaylistId = entity.PlaylistId,
                        PlaylistName = entity.PlaylistName,
                        SongList = entity.SongList,
                    };
            }
        }
        public bool UpdatePlaylist(PlaylistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Playlists
                    .Single(e => e.PlaylistId == model.PlaylistId && e.UserId == _userId);
                entity.PlaylistName = model.PlaylistName;
                entity.SongList = model.SongList;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePlaylist(int playlistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Playlists
                    .Single(e => e.PlaylistId == playlistId && e.UserId == _userId);

                ctx.Playlists.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}


