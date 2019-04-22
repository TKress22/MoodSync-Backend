using MoodSync.Data;
using MoodSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodsync.Services
{
    public class MoodService
    {
        public bool CreateMood(MoodCreate model)
        {
            var entity =
              new Mood()
              {
                  MoodName = model.MoodName,
              };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Moods.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MoodListItem> GetMoods()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Moods
                        .Select(
                        e => new MoodListItem
                        {
                            MoodId = e.MoodId,
                            MoodName = e.MoodName,
                        }
                     );
                return query.ToArray();
            }
        }
        public MoodDetail GetMoodById(int moodId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Moods
                        .Single(e => e.MoodId == moodId);
                return
                    new MoodDetail
                    {
                        MoodId = entity.MoodId,
                        MoodName = entity.MoodName,
                    };
            }
        }
        public bool UpdateMood(MoodEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Moods
                        .Single(e => e.MoodId == model.MoodId);
                entity.MoodId = model.MoodId;
                entity.MoodName = model.MoodName;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteMood(int moodId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Moods
                        .Single(e => e.MoodId == moodId);
                ctx.Moods.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}