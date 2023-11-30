using Microsoft.AspNetCore.Mvc;
using Application.Dtos;
using MediatR;
using Application.Commands.Birds.DeleteBird;
using Application.Commands.Birds.UpdateBird;
using Application.Queries.Birds.GetAll;
using Application.Queries.Birds.GetById;
using Application.Commands.Birds.AddBird;


namespace API.Controllers.Birdscontroller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : Controller
    {
        internal readonly IMediator _mediator;
        public BirdsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get all Birds from Db
        [HttpGet]
        [Route("getAllBirds")]
        public async Task<IActionResult> GetAllBirds()
        {
            return Ok(await _mediator.Send(new GetAllBirdsQuery()));
            // Return Ok(Get All Birds)
        }

        // Get Bird By Id
        [HttpGet]
        [Route("getBirdById/{birdId}")]
        public async Task<IActionResult> GetBirdById(Guid birdId)
        {
            return Ok(await _mediator.Send(new GetBirdByIdQuery(birdId)));
        }
        // Create a new Bird
        [HttpPost]
        [Route("addNewBird")]
        public async Task<IActionResult> AddBird([FromBody] BirdDto newBird)
        {
            return Ok(await _mediator.Send(new AddBirdCommand(newBird)));

        }
        // Update a specific Bird
        [HttpPut]
        [Route("updateBird/{updateBirdId}")]
        public async Task<IActionResult> UpdateBird([FromBody] BirdDto updatedBird, Guid updateBirdId)
        {
            return Ok(await _mediator.Send(new UpdateBirdByIdCommand(updatedBird, updateBirdId)));
        }

        // Delete a specific Bird
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBirdById(Guid id)
        {
            var bird = await _mediator.Send(new DeleteBirdByIdCommand(id));
            if (bird != null)
            {
                return NoContent();
            }
            return NotFound();
        }





    }


}
