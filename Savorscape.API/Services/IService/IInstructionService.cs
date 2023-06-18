using FluentResults;
using Savorscape.Database.Models;

namespace Savorscape.API.Services.IService
{
    public interface IInstructionService
    {
        Result<IEnumerable<Instruction>> GetAllRecipeInstructions(int recipeId);
        Result<Instruction> GetRecipeInstruction(int recipeId, int id);
        Result<Instruction> CreateRecipeInstruction(Instruction toCreate);
        Result<bool> UpdateRecipeInstruction(Instruction toUpdate);
        Result<bool> DeleteRecipeInstruction(int recipeId, int id);
    }
}
