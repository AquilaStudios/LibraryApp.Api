using LibraryApp.DataAccess;
using LibraryApp.Repositories.Interfaces;
using LibraryApp.Resolver.Interfaces;

namespace LibraryApp.Resolver
{
    public class MapperResolver : IMapperResolver
    {
        private readonly IUnitOfWork _unitOfWork;

        public MapperResolver(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string? ResolveItemType(Item source)
        {
            return _unitOfWork.ItemTypes.GetItemTypeById(source.ItemTypeId);
        }

        public string? ResolveCategoryName(Item source)
        {
            return _unitOfWork.Categories.GetCategoryNameById(source.CategoryId);
        }

        public string? ResolveConditionName(Item source)
        {
            return _unitOfWork.Conditions.GetConditionNameById(source.ConditionId);
        }

        public string? ResolveAuthorName(Item source)
        {
            return _unitOfWork.Authors.GetAuthorNameById(source.AuthorId);
        }

        public string? ResolvePublisherName(Item source)
        {
            return _unitOfWork.Publishers.GetPublisherNameById(source.PublisherId);
        }
    }
}