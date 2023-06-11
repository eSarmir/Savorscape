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

            if (instruction == null) 
            {
                return Result.Fail($"The instruction with ID {id} in recipe with ID {recipeId} was not found!");
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

            if (instruction == null)
            {
                return Result.Fail($"The instruction with ID {toUpdate.InstructionID} in recipe with ID {toUpdate.RecipeId} was not found!");
            }

            instructionRepository.Update(toUpdate);

            instructionRepository.SaveChanges();

            return true;
        }

        public Result<bool> DeleteRecipeInstruction(int recipeId, int id)
        {
            var wasDeleted = instructionRepository.DeleteRecipeInstruction(recipeId, id);
            
            if (wasDeleted == false) 
            {
                return Result.Fail($"The instruction with ID {id} in recipe with ID {recipeId} was not found!");
            }

            return true;
        }
    }
}
