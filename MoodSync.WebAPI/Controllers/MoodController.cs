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

    public class MoodController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            MoodService moodService = CreateMoodService();
            var moods = moodService.GetMoods();
            return Ok(moods);
        }

        public IHttpActionResult Get(int id)
        {
            MoodService moodservice = CreateMoodService();
            var mood = moodservice.GetMoodById(id);
            return Ok(mood);
        }

        public IHttpActionResult Post(MoodCreate mood)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMoodService();

            if (!service.CreateMood(mood))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(MoodEdit mood)
        {
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateMoodService();

            if (!service.DeleteMood(id))
                return InternalServerError();

            return Ok();
        }

        private MoodService CreateMoodService()
        {
            var MoodService = new MoodService();
            return MoodService;
        }

    }

}
