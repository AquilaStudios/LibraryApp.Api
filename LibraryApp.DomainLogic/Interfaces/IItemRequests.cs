using LibraryApp.DataAccess;
using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DomainLogic.Interfaces
{
    public interface IItemRequests
    {

        List<ItemDto> GetAllItems();
        List<ItemDto> GetItemsByTitle(string title);

        List<ItemDto> GetItemsByAuthor(string author);

        List<ItemDto> GetItemsByPublisher(string publisher);

        List<ItemDto> GetItemByDeweyDecimal(string deweyDecimal);

        ItemDto GetItemByIsbn(string isbn);

    }
}
