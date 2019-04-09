using Moodsync.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoodSync.WebAPI.Controllers
{
    public class SongController : ApiController
    {

        private SongService CreateSongService()
        {
            var GenreService = new SongService();
            return GenreService;
        }
    }
}