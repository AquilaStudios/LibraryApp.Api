using LibraryApp.DataAccess;

namespace LibraryApp.Resolver.Interfaces
{
    public interface IMapperResolver
    {
        string? ResolveItemType(Item source);

        string? ResolveCategoryName(Item source);

        string? ResolveConditionName(Item source);

        string? ResolveAuthorName(Item source);

        string? ResolvePublisherName(Item source);

    }
}
