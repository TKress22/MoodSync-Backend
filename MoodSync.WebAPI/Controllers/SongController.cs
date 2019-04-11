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
    [Authorize]
    public class SongController : ApiController
    {
        //public IHttpActionResult GetSongBy(object o)
        //{
        //    SongService service = CreateSongService();
        //    Dictionary<string, dynamic> values = new Dictionary<string, dynamic>();
        //    foreach (var p in o.GetType().GetProperties())
        //    {
        //        values.Add(p.Name, p.GetValue(o));
        //    }
        //    switch (values["type"])
        //    {
        //        case "Id":
        //            return Ok(service.GetSongById(values["type"]));
        //        case "genre":
        //            return Ok(service.GetSongById(values["type"]));
        //    }
        //    return InternalServerError();
        //}
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult Post(SongCreate song)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSongService();

            if (!service.CreateSong(song))
                return InternalServerError();

            return Ok();
        }
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult Put(SongFetch song)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSongService();

            if (!service.UpdateSong(song))
                return InternalServerError();

            return Ok();
        }
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateSongService();

            if (!service.DeleteSong(id))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult GetSongBy(string type, string inp)
        {
            SongService service = CreateSongService();
            switch (type.ToLower())
            {
                case "all":
                    return Ok(service.GetSongs());
                case "id":
                    return Ok(service.GetSongById(int.Parse(inp)));
                case "genre":
                    return Ok(service.GetSongByGenre(int.Parse(inp)));
                case "name":
                    return Ok(service.GetSongByName(inp));
                case "artist":
                    return Ok(service.GetSongByArtist(inp));
                case "album":
                    return Ok(service.GetSongByAlbum(inp));
                case "child":
                    return Ok(service.GetSongByChildFriendly(bool.Parse(inp)));
            }
            return Ok();
        }
        private SongService CreateSongService()
        {
            var SongService = new SongService();
            return SongService;
        }
    }
}