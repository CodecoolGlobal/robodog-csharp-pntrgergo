using Microsoft.AspNetCore.Mvc;
using RoboDogApplication.Data.Services;
using RoboDogApplication.Models;

namespace RoboDogApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogsController : Controller
    {
        private readonly IDogsService _service;

        public DogsController(IDogsService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Dog> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("GetRandomDog")]
        public Dog GetRandomDog()
        {
            return _service.CreateRandomDog();
        }

        [HttpPost("AddDogByName")]
        public ActionResult AddDog([FromBody] Dog tempDog)
        {
            _service.Add(tempDog);
            return Created("Created a new dog",tempDog);
        }

        [HttpPut("{name}")]
        public ActionResult UpdateDog(string name, Dog tempDog)
        {
            if (name != tempDog.Name)
            {
                return BadRequest();
            }
            _service.Update(tempDog);
            return Ok($"{tempDog.Name} successfully updated");
        }
    }
}