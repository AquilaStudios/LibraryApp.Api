using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using LibraryApp.DomainLogic;
using LibraryApp.Models;

namespace LibraryApp.Console
{


    class LibraryConsoleUI
    {

        static void Main()
        {
            var customerDtoModel = new NewCustomerDto()
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "test@test",
                CellPhone = "1234567891",
                HomePhone = "1234567891"

            };


            var libraryItemDtoModel = new NewLibraryItemDto()
            {
                Title = "Test",
                Type = "Book",
                Category = "Fiction",
                Condition = "Mint",
                Rarity = "Limited Edition",
                Author = "Test",
                Publisher = "Test",
                PublicationDate = DateTime.Now,
                ISBN = "Test",
                DeweyDecimal = "Test",
            };



            DomainLogic.CustomerService.AddCustomer(customerDtoModel);
            DomainLogic.LibraryItemService.AddLibraryItem(libraryItemDtoModel);

        }
    }

}