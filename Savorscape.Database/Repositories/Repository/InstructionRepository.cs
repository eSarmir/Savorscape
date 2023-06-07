using Savorscape.Database.Models;
using Savorscape.Database.Repositories.IRepository;

namespace Savorscape.Database.Repositories.Repository
{
    public class InstructionRepository : Repository<Instruction>, IInstructionRepository
    {
        public InstructionRepository(SavorscapeDbContext context) : base(context)
        {
        }
    }
}
