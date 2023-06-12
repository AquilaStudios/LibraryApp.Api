using LibraryApp.Models;
using LibraryApp.DomainLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers
{
    [Route("items/v1")]
    public class ItemsController : Controller
    {

        private readonly IItemRequests _item;
        
        public ItemsController(IItemRequests item)
        {
            _item = item;
        }

        [HttpGet]
        [Route("GetAllItems")]
        public ActionResult<List<ItemDto>> GetAllItems()
        {
            try
            {
                List<ItemDto> itemDtos = _item.GetAllItems();
                return Ok(itemDtos);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }

        }

        [HttpGet]
        [Route("GetItemsByTitle")]
        public ActionResult<List<ItemDto>> GetItemsByTitle(string title)
        {

            try
            {
                var itemDtos = _item.GetItemsByTitle(title);
                return Ok(itemDtos);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }


        }

        [HttpGet]
        [Route("GetItemsByAuthor")]

        public ActionResult<List<ItemDto>> GetItemsByAuthor(string author)
        {
            try
            {
                var itemDtos = _item.GetItemsByAuthor(author);
                return Ok(itemDtos);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("GetItemsByPublisher")]

        public ActionResult<List<ItemDto>> GetItemsByPublisher(string publisher)
        {
            try
            {
                var itemDtos = _item.GetItemsByPublisher(publisher);
                return Ok(itemDtos);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("GetItemsByDeweyDecimal")]
        public ActionResult<List<ItemDto>> GetItemsByDeweyDecimal(string deweyDecimal)
        {
            try
            {
                var itemDtos = _item.GetItemByDeweyDecimal(deweyDecimal);
                return Ok(itemDtos);
            }
            catch( Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("GetItemsByIsbn")]
        public ActionResult<List<ItemDto>> GetItemsByIsbn(string isbn)
        {
            try
            {
                var itemDto = _item.GetItemByIsbn(isbn); 
                return Ok(itemDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
