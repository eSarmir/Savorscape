using Microsoft.AspNetCore.Mvc;
using Savorscape.API.Contracts.Requests.Instruction;
using Savorscape.API.Contracts.Responses.Instructions;
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
        [ProducesResponseType(typeof(InstructionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int recipeId, int id)
        {
            var ingredient = instructionRepository.GetRecipeInstruction(recipeId, id);

            if (ingredient == null)
            {
                return NotFound();
            }

            InstructionResponse response = ResponseMappingHelper.MapInstructionToInstructionResponse(ingredient);

            return Ok(response);
        }

        [HttpGet("instructions")]
        [ProducesResponseType(typeof(IEnumerable<InstructionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll(int recipeId)
        {
            var ingredients = instructionRepository.GetAllRecipeInstructions(recipeId);

            if (!ingredients.Any())
            {
                return NotFound();
            }

            IEnumerable<InstructionResponse> response = ingredients.Select(ResponseMappingHelper.MapInstructionToInstructionResponse);

            return Ok(response);
        }

        [HttpPost("instructions")]
        [ProducesResponseType(typeof(InstructionResponse), StatusCodes.Status201Created)]
        public IActionResult Create(int recipeId, CreateInstructionRequest request)
        {
            var ingredient = instructionRepository.Create(new Database.Models.Instruction()
            {
                Order = request.Order,
                Description = request.Description,
                RecipeId = recipeId
            });

            instructionRepository.SaveChanges();

            InstructionResponse response = ResponseMappingHelper.MapInstructionToInstructionResponse(ingredient);

            return CreatedAtAction(
                nameof(Get),
                new { RecipeId = recipeId, Id = response.InstructionID },
                response);
        }

        [HttpPut("instructions/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Update(int id, UpdateInstructionRequest request)
        {
            instructionRepository.Update(new Database.Models.Instruction()
            {
                InstructionID = id,
                Order = request.Order,
                Description = request.Description,
                RecipeId = request.RecipeID
            });

            instructionRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("instructions/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int recipeId, int id)
        {
            var wasDeleted = instructionRepository.DeleteRecipeInstruction(recipeId, id);

            if (wasDeleted == false)
            {
                return NotFound();
            }

            instructionRepository.SaveChanges();

            return NoContent();
        }
    }
}
