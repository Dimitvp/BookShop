namespace BookShop.Services
{
    using System.Threading.Tasks;
    using BookShop.Services.Models.Author;

    public interface IAuthorService
    {
        Task<AuthorDetailsServiceModel> Details(int id);

        Task<int> Create(string firstName, string lastName);
    }
}
