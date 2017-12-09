namespace BookShop.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using BookShop.Data;
    using Models.Author;
    using Models.Book;
    using Microsoft.EntityFrameworkCore;

    public class AuthorService : IAuthorService
    {
        private readonly BookShopDbContext db;

        public AuthorService(BookShopDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(string firstName, string lastName)
        {
            var author = new AuthorDetailsServiceModel
            {
                FirstName = firstName,
                LastName = lastName
            };

            this.db.Add(author);
            await this.db.SaveChangesAsync();

            return author.Id;
        }

        public async Task<AuthorDetailsServiceModel> Details(int id)
            => await this.db
                .Authors
                .Where(a => a.Id == id)
                .ProjectTo<AuthorDetailsServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<BookWithCategoriesServiceModel>> Books(int authorId)
            => await this.db
                .Books
                .Where(b => b.AuthorId == authorId)
                .ProjectTo<BookWithCategoriesServiceModel>()
                .ToListAsync();

        public async Task<bool> Exists(int id)
            => await this.db.Authors.AnyAsync(a => a.Id == id);
    }
}
