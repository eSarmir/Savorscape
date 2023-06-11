using Microsoft.AspNetCore.Mvc;
using Savorscape.API.Contracts.Requests.Instruction;
using Savorscape.API.Contracts.Responses;
using Savorscape.API.Contracts.Responses.Instructions;
using Savorscape.API.Extensions;
using Savorscape.API.Services.IService;
using Savorscape.Database.Models;

namespace Savorscape.API.Controllers
{
    [Route("api/recipes/{recipeId}")]
    [ApiController]
    public class InstructionsController : ControllerBase
    {
        private readonly IInstructionService instructionService;

        public InstructionsController(IInstructionService instructionService)
        {
            this.instructionService = instructionService;
        }

        [HttpGet("instructions/{id}")]
        [ProducesResponseType(typeof(InstructionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int recipeId, int id)
        {
            var result = instructionService.GetRecipeInstruction(recipeId, id);

            return result
                .MatchToActionResult(
                    instruction => Ok(ResponseMappingHelper.MapInstructionToInstructionResponse(instruction)),
                    err => NotFound(ResponseMappingHelper.MapStringToClientErrorResponse(err.Message))
                );
        }

        [HttpGet("instructions")]
        [ProducesResponseType(typeof(IEnumerable<InstructionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll(int recipeId)
        {
            var result = instructionService.GetAllRecipeInstructions(recipeId);

            return result
                .MatchToActionResult(
                    instructions => Ok(instructions.Select(ResponseMappingHelper.MapInstructionToInstructionResponse)),
                    err => NotFound(ResponseMappingHelper.MapStringToClientErrorResponse(err.Message))
                );
        }

        [HttpPost("instructions")]
        [ProducesResponseType(typeof(InstructionResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(int recipeId, CreateInstructionRequest request)
        {
            var result = instructionService.CreateRecipeInstruction(new Instruction()
            {
                Order = request.Order,
                Description = request.Description,
                RecipeId = recipeId
            });

            return result
                .MatchToActionResult(
                    instruction => CreatedAtAction(
                        nameof(Get),
                        new { RecipeId = recipeId, Id = instruction.InstructionID },
                        ResponseMappingHelper.MapInstructionToInstructionResponse(instruction)),
                    err => BadRequest()
                );
        }

        [HttpPut("instructions/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ClientErrorResponse), StatusCodes.Status404NotFound)]
        public IActionResult Update(int id, UpdateInstructionRequest request)
        {
            var result = instructionService.UpdateRecipeInstruction(new Instruction()
            {
                InstructionID = id,
                Order = request.Order,
                Description = request.Description,
                RecipeId = request.RecipeID
            });

            return result
                .MatchToActionResult(
                    wasUpdated => NoContent(),
                    err => NotFound(ResponseMappingHelper.MapStringToClientErrorResponse(err.Message))
                );
        }

        [HttpDelete("instructions/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int recipeId, int id)
        {
            var result = instructionService.DeleteRecipeInstruction(recipeId, id);

            return result
                .MatchToActionResult(
                    wasDeleted => NoContent(),
                    err => NotFound(ResponseMappingHelper.MapStringToClientErrorResponse(err.Message))
                );
        }
    }
}
