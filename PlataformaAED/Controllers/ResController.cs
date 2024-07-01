using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PlataformaAED.data.Repositories;
using PlataformaAED.model;

namespace PlataformaAED.Controllers
{

    [ApiController]
    [Route("api/[controller]")] //URL route. [controller] -> name of the controller class, excluding the "Controller" suffix.

    public class ResController : ControllerBase // ControllerBase = controller is intended for a Web API http requests.
    {
        //Global repo var
        private readonly IResRepository _resRepository; 

        public ResController(IResRepository resRepository)
        {
            _resRepository = resRepository;
        }

        //GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAllRes()
        {
            return Ok(await _resRepository.GetAllReservations());
        }

        //GET by ID
        [HttpGet("id")]
        public async Task<IActionResult> GetRes(int id)
        {
            return Ok(await _resRepository.GetRes(id));
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> PostRes([FromBody]Reservation reservation)
        {
            if (reservation == null)
                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _resRepository.PostRes(reservation);
            return Created("created", created);
        }

        //PUT
        [HttpPut]
        public async Task<IActionResult> UpdateRes([FromBody] Reservation reservation)
        {
            if (reservation == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _resRepository.UpdateRes(reservation);
            return NoContent();
        }

        //DELETE
        [HttpDelete]
        public async Task<IActionResult> DeleteRes(int id)
        {

            return Ok(await _resRepository.DeleteRes(id));

        }

    }
}
