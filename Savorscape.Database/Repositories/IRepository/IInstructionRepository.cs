using Savorscape.Database.Models;

namespace Savorscape.Database.Repositories.IRepository
{
    public interface IInstructionRepository : IRepository<Instruction>
    {
        IEnumerable<Instruction> GetAllRecipeInstructions(int recipeId);
        Instruction? GetRecipeInstruction(int recipeId, int id);
        bool DeleteRecipeInstruction(int recipeId, int id); 
    }
}
