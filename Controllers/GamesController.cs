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
        private GameRentalEntities1 db = new GameRentalEntities1();
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

        public string PostGame([FromBody] Game game)
        {
            db.Games.Add(game);
            db.SaveChanges();
            return "Data added to database";
        }

        public void Delete(int id)
        {
            var data = db.Games.Find(id);
            db.Games.Remove(data);
            db.SaveChanges();
        }

    }
}

