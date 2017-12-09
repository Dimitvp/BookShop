namespace BookShop.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Author;
    using Models.Book;

    public interface IAuthorService
    {
        Task<AuthorDetailsServiceModel> Details(int id);

        Task<int> Create(string firstName, string lastName);

        Task<IEnumerable<BookWithCategoriesServiceModel>> Books(int authorId);

        Task<bool> Exists(int id);
    }
}
