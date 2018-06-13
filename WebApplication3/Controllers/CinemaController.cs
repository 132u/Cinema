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
        public IList<Actor> Get()
        {
            using (var db = new CinemaDBEntities())
            {
                return db.Actors.ToList();
               
            }

        }

        // GET api/<controller>/5
        public Actor GetActor(int id)
        {
            using (var db = new CinemaDBEntities())
            {

                return db.Actors.FirstOrDefault(m => m.Id == id);
            }

        }

        // POST api/<controller>
        public void PostActor(Actor actor)
        {
            using (var db = new CinemaDBEntities())
            {
                db.Actors.Add(actor);
                db.SaveChanges();
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
            using (var db = new CinemaDBEntities())
            {
                //var a =db.Actors.FirstOrDefault(value);
                //db.Actors.
                //db.SaveChanges();
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            using (var db = new CinemaDBEntities())
            {
                var film = db.Actors.Single(m => m.Id == id);
                if (film != null)
                {
                    db.Actors.Remove(film);
                    db.SaveChanges();
                }
            }
        }
    }
}
