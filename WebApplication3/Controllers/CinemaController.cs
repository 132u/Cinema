using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cinema.Model;

namespace WebApplication3.Controllers
{
    public class CinemaController : ApiController
    {
        // GET api/<controller>
        public IList<Movy> Get()
        {
            using (var db = new CinemaDBEntities())
            {
                return db.Movies.ToList();
               
            }

        }

        // GET api/<controller>/5
        public Movy GetMovy(int id)
        {
            using (var db = new CinemaDBEntities())
            {

                return db.Movies.FirstOrDefault(m => m.Id == id);
            }

        }

        // POST api/<controller>
        public void PostMovie(Movy movie)
        {
            using (var db = new CinemaDBEntities())
            {
                db.Movies.Add(movie);
                db.SaveChanges();
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            using (var db = new CinemaDBEntities())
            {
                var film = db.Movies.FirstOrDefault(m => m.Id == id);
                db.Movies.Remove(film);
                db.SaveChanges();
            }
        }
    }
}
