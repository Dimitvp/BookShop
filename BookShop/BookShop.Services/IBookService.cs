namespace BookShop.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BookShop.Services.Models.Book;

    public interface IBookService
    {
        Task<int> Create(
            string title,
            string description,
            decimal price,
            int copies,
            int? edition,
            int? ageRestriction,
            DateTime releaseDate,
            int authorId,
            string categories);

        Task<IEnumerable<BookListingServiceModel>> All(string searchText);

        Task<BookDetailsServiceModel> Details(int id);
    }
}
