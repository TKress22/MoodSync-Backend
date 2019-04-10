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
    public class GenreController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            GenreService genreService = CreateGenreService();
            var moods = genreService.GetGenre();
            return Ok(moods);
        }

        public IHttpActionResult Get(int id)
        {
            GenreService genreService = CreateGenreService();
            var genre = genreService.GetGenreById(id);
            return Ok(genre);
        }
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult Post(GenreCreate genre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGenreService();

            if (!service.CreateGenre(genre))
                return InternalServerError();

            return Ok();
        }
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult Put(GenreEdit genre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGenreService();

            if (!service.UpdateGenre(genre))
                return InternalServerError();

            return Ok();
        }
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateGenreService();

            if (!service.DeleteGenre(id))
                return InternalServerError();

            return Ok();
        }

        private GenreService CreateGenreService()
        {
            var GenreService = new GenreService();
            return GenreService;
        }

    }

}

