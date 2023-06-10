namespace Savorscape.API.Contracts
{
    internal static class RecipeConstraints
    {
        public const int TitleMaxLength = 100;
        public const int DescriptionMaxLength = 300;
    }

    internal static class InstructionConstraints
    {
        public const int DescriptionMaxLength = 500;
    }

    internal static class IngredientConstraints
    {
        public const int NameMaxLength = 50;
        public const int UnitMaxLength = 5;
    }
}
