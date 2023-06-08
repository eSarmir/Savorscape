using Savorscape.Database.Models;
using Savorscape.Database.Repositories.IRepository;

namespace Savorscape.Database.Repositories.Repository
{
    public class InstructionRepository : Repository<Instruction>, IInstructionRepository
    {
        public InstructionRepository(SavorscapeDbContext context) : base(context)
        {
        }

        public IEnumerable<Instruction> GetAllRecipeInstructions(int recipeId)
        {
            return context.Instructions
                .Where(i => i.RecipeId == recipeId);
        }
    }
}
