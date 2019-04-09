using Moodsync.Services;
using MoodSync.Models;
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
        public IHttpActionResult GetById(int id)
        {
            SongService songService = CreateSongService();
            var song = songService.GetSongById(id);
            return Ok(song);
        }
        private SongService CreateSongService()
        {
            var SongService = new SongService();
            return SongService;
        }
    }
}