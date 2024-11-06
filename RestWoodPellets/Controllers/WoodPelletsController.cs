using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WoodPelletsLib;

namespace RestWoodPellets.Controllers
{
    //husk at man vælger navnet på linket her:
    // https://restwoodpellets20241021104246.azurewebsites.net/Api/woodpellets
    [Route("[controller]")]
    [ApiController]
    public class WoodPelletsController : ControllerBase
    {
        private readonly WoodPelletRepository _repository;

        public WoodPelletsController(WoodPelletRepository repository)
        {
            _repository = repository;

        }
        //[HttpGet]
        public IEnumerable<WoodPellet> Get()
        {
            //return new string[] { "value1", "value2" };
            return _repository.GetAll();
        }
        // GETBYID: api/<WoodPelletsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<WoodPellet>? GetById(int id)
        {

            //return _repository.GetById(id);
            WoodPellet woodpellet = _repository.GetById(id);

            if (woodpellet == null) return NotFound("No such class, id: " + id);
            return Ok(woodpellet);
        }
        //[ProducesResponseType(StatusCodes.Status200OK)]

        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Route("Name/{substring}")]
        //[HttpGet]
        //public IEnumerable<WoodPellet>? GetSubstring([FromQuery] string substring)
        //{

        //    //return _repository.GetById(id);
        //    return _repository.GetAll().Where(woodpellet => woodpellet.Brand.Contains(substring));
        //}
        // POST api/<WoodPelletsController>
        [ProducesResponseType(StatusCodes.Status201Created)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public ActionResult<WoodPellet>? Post([FromBody] WoodPellet value)
        {
            if (value == null)
            {
                return NotFound("No such class, woodpellet: " + value);
            }

            _repository.Add(value);
            // Assuming you have a route or action to get the trophy by id.
            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }
        // PUT api/<TrophiesController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<WoodPellet> Put(int id, [FromBody] WoodPellet value)
        {
            if (value == null) return NotFound("No such class, woodpellet: " + value);
            var updatedwoodpellet = _repository.Update(id, value);

            return Ok(updatedwoodpellet);
        }

        // Opgave 9, A, B???
        //[HttpGet]
        // CHANGE to SEARCH to make it work cos else it thinks im tryna use the wrong method.
        [HttpGet("search")]
        public ActionResult<IEnumerable<WoodPellet>> Get([FromQuery] int? quality = null, [FromQuery] string? brand = null, [FromQuery] string? orderBy = null)
        {
            var woodPellets = _repository.Get(quality, brand, orderBy);
            return Ok(woodPellets);
        }
        [HttpGet("FilterWP")]
        public IEnumerable<WoodPellet> FilterWP([FromQuery] string brand)
        {
            return _repository.GetAll().Where(woodpellet => woodpellet.Brand.Contains(brand));
        }
        // ^Ikke helt optimal men efter opgaven
        // DELETE api/<WoodPelletsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<WoodPellet>? Delete(int id)
        {

            return _repository.Remove(id);
        }
    }
}
