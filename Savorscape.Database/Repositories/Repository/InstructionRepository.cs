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

        public Instruction? GetRecipeInstruction(int recipeId, int instructionId) 
        {
            return context.Instructions
                .SingleOrDefault(i => i.RecipeId == recipeId && i.InstructionID == instructionId);
        }

        public bool DeleteRecipeInstruction(int recipeId, int id)
        {
            var entity = GetRecipeInstruction(recipeId, id);

            if (entity == null)
                return false;

            Delete(entity);

            return true;
        }
    }
}
