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
        private OnlineGameRentalStoreEntities db = new OnlineGameRentalStoreEntities();
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

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = db.Games.Find(id);
                db.Games.Remove(data);
                db.SaveChanges();
                var msg = Request.CreateResponse(HttpStatusCode.Created, data);

                return msg;
            }
            catch (Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }

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

