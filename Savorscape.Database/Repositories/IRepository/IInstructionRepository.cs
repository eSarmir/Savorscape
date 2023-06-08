using Savorscape.Database.Models;

namespace Savorscape.Database.Repositories.IRepository
{
    public interface IInstructionRepository : IRepository<Instruction>
    {
        IEnumerable<Instruction> GetAllRecipeInstructions(int recipeId);
    }
}
