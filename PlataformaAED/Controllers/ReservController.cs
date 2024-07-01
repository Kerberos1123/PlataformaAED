using Microsoft.AspNetCore.Mvc;
using PlataformaAED.data.Repositories;
using PlataformaAED.model;

namespace PlataformaAED.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class ReservController : ControllerBase
    {

        //Global repo var
        private readonly IReservRepository _reservRepository;

        public ReservController(IReservRepository reservRepository)
        {
            _reservRepository = reservRepository;
        }

        //GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAllReserv()
        {
            return Ok(await _reservRepository.GetAllReserv());
        }

        //GET by ID
        [HttpGet("id")]
        public async Task<IActionResult> GetReserv(int id)
        {
            return Ok(await _reservRepository.GetReservById(id));
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> PostReserv([FromBody] Reserv reserv)
        {
            if (reserv == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _reservRepository.PostReserv(reserv);
            return Created("created", created);

        }

        //PUT
        [HttpPut]
        public async Task<IActionResult> PutReserv([FromBody] Reserv reserv)
        {
            if (reserv == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _reservRepository.PutReserv(reserv);
            return NoContent();
        }

        //DELETE
        [HttpDelete]
        public async Task<IActionResult> DeleteReserv(int id)
        {

            return Ok(await _reservRepository.DelReserv(id));

        }

    }
}
