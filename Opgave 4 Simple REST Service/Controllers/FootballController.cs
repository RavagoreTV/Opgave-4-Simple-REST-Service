using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opgave_1_Csharp;
using Opgave_4_Simple_REST_Service.Mangers;

namespace Opgave_4_Simple_REST_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballController : ControllerBase
    {
        private FootballplayerManger footballplayerManger = new FootballplayerManger();

        [HttpGet]
        public IEnumerable<FootballPlayer> GetAll([FromQuery] string substring)
        {
            return footballplayerManger.GetAll(substring);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<FootballPlayer> Get(int id)
        {
            FootballPlayer player = footballplayerManger.GetById(id);
            if (player == null)
            {
                return NotFound("No such item, id: " + id);
            }
            else
            {
                return Ok(player);
            }

        }

        [HttpPost]
        public FootballPlayer Post([FromBody] FootballPlayer value)
        {
            return footballplayerManger.Add(value);
        }

        [HttpPut("{id}")]
        public FootballPlayer Put(int id, [FromBody] FootballPlayer value)
        {
            return footballplayerManger.Update(id, value);
        }

        
        [HttpDelete("{id}")]
        public FootballPlayer Delete(int id)
        {
            return footballplayerManger.Delete(id);
        }
    }
}
