using Microsoft.AspNetCore.Mvc;
using Savorscape.API.Contracts.Requests.Instruction;
using Savorscape.API.Contracts.Responses.Instructions;
using Savorscape.Database.Models;
using Savorscape.Database.Repositories.IRepository;

namespace Savorscape.API.Controllers
{
    [Route("api/recipes/{recipeId}")]
    [ApiController]
    public class InstructionsController : ControllerBase
    {
        private readonly IInstructionRepository instructionRepository;

        public InstructionsController(IInstructionRepository instructionRepository)
        {
            this.instructionRepository = instructionRepository;
        }

        [HttpGet("instructions/{id}")]
        [ProducesResponseType(typeof(InstructionsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var ingredient = instructionRepository.GetByID(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            InstructionsResponse response = MapInstructionToInstructionResponse(ingredient);

            return Ok(response);
        }

        [HttpGet("instructions")]
        [ProducesResponseType(typeof(IEnumerable<InstructionsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll(int recipeId)
        {
            var ingredients = instructionRepository.GetAllRecipeInstructions(recipeId);

            if (!ingredients.Any())
            {
                return NotFound();
            }

            IEnumerable<InstructionsResponse> response = ingredients.Select(MapInstructionToInstructionResponse);

            return Ok(response);
        }

        [HttpPost("instructions")]
        [ProducesResponseType(typeof(InstructionsResponse), StatusCodes.Status201Created)]
        public IActionResult Create(int recipeId, CreateInstructionRequest request)
        {
            var ingredient = instructionRepository.Create(new Instruction()
            {
                Order = request.Order,
                Description = request.Description,
            });

            instructionRepository.SaveChanges();

            InstructionsResponse response = MapInstructionToInstructionResponse(ingredient);

            return CreatedAtAction(
                nameof(Get),
                new { RecipeId = recipeId, Id = response.InstructionID },
                response);
        }

        [HttpPut("instructions/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Update(int id, UpdateInstructionRequest request)
        {
            instructionRepository.Update(new Instruction()
            {
                InstructionID = id,
                Order = request.Order,
                Description = request.Description,
                RecipeId = request.RecipeID
            });

            return NoContent();
        }

        [HttpDelete("instructions/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            var wasDeleted = instructionRepository.Delete(id);

            if (wasDeleted == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        private static InstructionsResponse MapInstructionToInstructionResponse(Instruction ingredient)
        {
            return new InstructionsResponse(
                ingredient.InstructionID,
                ingredient.Order,
                ingredient.Description,
                ingredient.RecipeId
                );
        }
    }
}
