﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using LoginMVC.Models;

namespace LoginMVC.Controllers
{
    public class GenresController : ApiController
    {
        // GET api/<controller>

        // GET api/<controller>/5
        private Game_RentalEntities db = new Game_RentalEntities();
        // GET api/games
        public List<Genre> Get()
        {
            return db.Genres.ToList();
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}