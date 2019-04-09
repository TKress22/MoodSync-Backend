using MoodSync.Data;
using MoodSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodsync.Services
{
    public class GenreService
    {
        public bool CreateGenre(GenreCreate model)
        {
            var entity =
              new Genre()
              {
                  GenreId = model.GenreId,
                  GenreName = model.GenreName,
              };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Genres.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable <GenreListItem> GetGenre()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Genres
                        .Select(
                        e => new GenreListItem
                        {
                            GenreId = e.GenreId,
                            GenreName = e.GenreName,
                        }
                     );
                return query.ToArray();
            }
        }
        public GenreDetail GetGenreById(int genreId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Genres
                        .Single(e => e.GenreId == genreId);
                return
                    new GenreDetail
                    {
                        GenreId = entity.GenreId,
                        GenreName = entity.GenreName,
                    };
            }
        }
        public bool UpdateGenre(GenreEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Genres
                        .Single(e => e.GenreId == model.GenreId);
                entity.GenreId = model.GenreId;
                entity.GenreName = model.GenreName;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteGenre(int genreId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Genres
                        .Single(e => e.GenreId == genreId);
                ctx.Genres.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
