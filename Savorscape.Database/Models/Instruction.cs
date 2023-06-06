namespace Savorscape.Database.Models
{
    public class Instruction
    {
        public int InstructionID { get; set; }
        public int Order { get; set; }
        public required string Description { get; set; }
        public int RecipeId { get; set; }
        public required Recipe Recipe { get; set; }
    }
}
