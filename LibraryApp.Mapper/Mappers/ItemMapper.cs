using AutoMapper;
using LibraryApp.Models;
using LibraryApp.DataAccess;
using LibraryApp.Mapper.Resolvers;

namespace LibraryApp.Mapper.Mappers
{
    public class ItemMapper
    {
        private readonly IMapper _mapper;

        public ItemMapper(MapperResolver resolver)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, ItemDto>()
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                    .ForMember(dest => dest.ItemType, opt => opt.MapFrom(src => resolver.ResolveItemType(src)))
                    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => resolver.ResolveCategoryName(src)))
                    .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => resolver.ResolveConditionName(src)))
                    .ForMember(dest => dest.Author, opt => opt.MapFrom(src => resolver.ResolveAuthorName(src)))
                    .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => resolver.ResolvePublisherName(src)))
                    .ForMember(dest => dest.PublicationDate, opt => opt.MapFrom(src => src.PublicationDate != null ? src.PublicationDate.Value.ToString("MM/dd/yyyy") : null));
            });

            _mapper = config.CreateMapper();
        }


        public ItemDto Map(Item item)
        {
            return _mapper.Map<Item, ItemDto>(item);
        }



    }
}