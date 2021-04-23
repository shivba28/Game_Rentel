using LoginMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoginMVC.Controllers
{
    public class GamesController : ApiController
    {
        private Game_RentalEntities3 db = new Game_RentalEntities3();
        // GET api/games
        public List<Game> Get()
        {
            return db.Games.ToList();
        }
       
        // GET api/games/1
        public Game Get(int id)
        {
            var game = db.Games.Find(id);
            return game;
        }

        [HttpPost]
        public HttpResponseMessage PostGame([FromBody] Game game)
        {
            try
            {
                db.Games.Add(game);
                db.SaveChanges();
                //return "Data added to database";
                var msg = Request.CreateResponse(HttpStatusCode.Created,game);
                return msg;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,e);
            }
           
        }

        public void Delete(int id)
        {
            var data = db.Games.Find(id);
            db.Games.Remove(data);
            db.SaveChanges();
        }
        public void Put(int id, [FromBody] Game game)
        {
            var data = db.Games.Find(id);
            if (data != null)
            {
                // db.Games.Add(game);
                data.availability = game.availability;
                data.game_price = game.game_price;
                db.SaveChanges();
            }

        }

    }
}

