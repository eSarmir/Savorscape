using FluentResults;
using Savorscape.API.Services.IService;
using Savorscape.Database.Models;
using Savorscape.Database.Repositories.IRepository;

namespace Savorscape.API.Services.Service
{
    public class InstructionService : IInstructionService
    {
        private readonly IInstructionRepository instructionRepository;

        public InstructionService(IInstructionRepository instructionRepository)
        {
            this.instructionRepository = instructionRepository;
        }

        public Result<IEnumerable<Instruction>> GetAllRecipeInstructions(int recipeId)
        {
            return Result.Ok(instructionRepository.GetAllRecipeInstructions(recipeId));
        }

        public Result<Instruction> GetRecipeInstruction(int recipeId, int id)
        {
            var instruction = instructionRepository.GetRecipeInstruction(recipeId, id);

            if (instruction is null)
            {
                return Result.Fail(GetInstructionNotFoundErrorMessage(recipeId, id));
            }

            return instruction;
        }

        public Result<Instruction> CreateRecipeInstruction(Instruction toCreate)
        {
            var instruction = instructionRepository.Create(toCreate);

            instructionRepository.SaveChanges();

            return instruction;
        }

        public Result<bool> UpdateRecipeInstruction(Instruction toUpdate)
        {
            var instruction = instructionRepository.GetRecipeInstruction(toUpdate.RecipeId, toUpdate.InstructionID);

            if (instruction is null)
            {
                return Result.Fail(GetInstructionNotFoundErrorMessage(toUpdate.RecipeId, toUpdate.InstructionID));
            }

            instructionRepository.Update(toUpdate);

            instructionRepository.SaveChanges();

            return true;
        }

        public Result<bool> DeleteRecipeInstruction(int recipeId, int id)
        {
            var wasDeleted = instructionRepository.DeleteRecipeInstruction(recipeId, id);
            
            if (wasDeleted is false) 
            {
                return Result.Fail(GetInstructionNotFoundErrorMessage(recipeId, id));
            }

            instructionRepository.SaveChanges();

            return true;
        }

        private static string GetInstructionNotFoundErrorMessage(int recipeId, int id)
        {
            return $"The instruction with ID {id} in recipe with ID {recipeId} was not found!";
        }
    }
}
