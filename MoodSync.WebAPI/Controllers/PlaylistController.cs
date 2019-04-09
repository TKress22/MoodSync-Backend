using Microsoft.AspNet.Identity;
using Moodsync.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoodSync.WebAPI.Controllers
{
    [Authorize]
    public class PlaylistController : ApiController
    {
        public IHttpActionResult Get()
        {
            PlaylistService playlistService = CreatePlaylistService();
            var playlists = playlistService.GetPlaylist();
            return Ok(playlists);
        }
        private PlaylistService CreatePlaylistService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var playlistService = new PlaylistService(userId);
            return playlistService;
        }
    }
}
