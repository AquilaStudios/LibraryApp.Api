using LibraryApp.DomainLogic.Interfaces;
using LibraryApp.Repositories.Interfaces;
using LibraryApp.Models;
using LibraryApp.Mapper.Mappers;


namespace LibraryApp.DomainLogic
{

    public class ItemRequests : IItemRequests
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ItemMapper _itemMapper;

        public ItemRequests(IUnitOfWork unitOfWork, ItemMapper itemMapper)
        {
            _unitOfWork = unitOfWork;
            _itemMapper = itemMapper;
        }    

        public List<ItemDto> GetAllItems()
        {
            var items = _unitOfWork.Items.GetAll();

            List<ItemDto> itemDtos = new List<ItemDto>();

            foreach (var item in items)
            {
                ItemDto itemDto = _itemMapper.Map(item);
                itemDtos.Add(itemDto);
            }

            return itemDtos;
        }

        public List<ItemDto> GetItemsByTitle(string title)
        {

                var items = _unitOfWork.Items.Find(i => i.Title == title);

                List<ItemDto> itemDtos = new List<ItemDto>();

                foreach (var item in items)
                {
                    var itemDto = _itemMapper.Map(item);
                    itemDtos.Add(itemDto);
                }

                return itemDtos;

        }


        public List<ItemDto> GetItemsByAuthor(string author)
        {
            var items = _unitOfWork.Items.Find(i => i.Author.Name == author);

            List<ItemDto> itemDtos = new List<ItemDto>();

            foreach (var item in items)
            {
                var itemDto = _itemMapper.Map(item);
                itemDtos.Add(itemDto);
            }

            return itemDtos;
        }

        public List<ItemDto> GetItemsByPublisher(string publisher)
        {
            var items = _unitOfWork.Items.Find(i => i.Publisher.Name == publisher);

            List<ItemDto> itemDtos = new List<ItemDto>();

            foreach (var item in items)
            {
                var itemDto = _itemMapper.Map(item);
                itemDtos.Add(itemDto);
            }

            return itemDtos;
        }

        public List<ItemDto> GetItemByDeweyDecimal(string deweyDecimal)
        {
            var items = _unitOfWork.Items.Find(i => i.DeweyDecimal == deweyDecimal);

            List<ItemDto> itemDtos = new List<ItemDto>();

            foreach (var item in items)
            {
                var itemDto = _itemMapper.Map(item);
                itemDtos.Add(itemDto);
            }

            return itemDtos;

        }

        public ItemDto GetItemByIsbn(string isbn)
        {
            var items = _unitOfWork.Items.Find(i => i.ISBN == isbn);

            ItemDto itemDto = new ItemDto();

            foreach(var item in items)
            {
                itemDto = _itemMapper.Map(item);
            }

            return itemDto;
        }
    }

        

}
