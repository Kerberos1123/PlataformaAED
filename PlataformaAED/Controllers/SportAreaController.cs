using Microsoft.AspNetCore.Mvc;
using PlataformaAED.data.Repositories;
using PlataformaAED.model;

namespace PlataformaAED.Controllers
{

    [ApiController]
    [Route("api/[controller]")] //URL route. [controller] -> name of the controller class, excluding the "Controller" suffix.
    public class SportAreaController : ControllerBase
    {
        //Global repo var
        private readonly ISportAreaRepository _saRepository;

        public SportAreaController(ISportAreaRepository saRepository)
        {
            _saRepository = saRepository;
        }

        //GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAllSA()
        {
            return Ok(await _saRepository.GetAllSportAreas());
        }

        //GET by ID
        [HttpGet("id")]
        public async Task<IActionResult> GetSA(int id)
        {
            return Ok(await _saRepository.GetSportAreaById(id));
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> PostSA([FromBody]SportArea sportArea)
        {
            if (sportArea == null) 
                return BadRequest();
            if(!ModelState.IsValid)
                    return BadRequest(ModelState);
            var created = await _saRepository.PostSportArea(sportArea);
            return Created("created", created);

        }

        //PUT
        [HttpPut]
        public async Task<IActionResult> UpdateSA([FromBody] SportArea sportArea)
        {
            if (sportArea == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _saRepository.PutSportArea(sportArea);
            return NoContent();
        }

        //DELETE
        [HttpDelete]
        public async Task<IActionResult> DeleteSA(int id)
        {

            return Ok(await _saRepository.DelSportArea(id));

        }


    }
}
