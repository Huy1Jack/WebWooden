namespace WebWooden.Utilities
{
    public class Function
    {
        public static string TitleSulgGenerationAlias(string title)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(title);
        }
    }
}
