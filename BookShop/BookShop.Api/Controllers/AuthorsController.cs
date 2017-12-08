namespace BookShop.Api.Controllers
{
    using System.Threading.Tasks;
    using BookShop.Api.Infrastructure.Extencions;
    using BookShop.Api.Models.Authors;
    using BookShop.Services;
    using Microsoft.AspNetCore.Mvc;

    using static WebConstants;

    public class AuthorsController : BaseController
    {
        public readonly IAuthorService authors;

        public AuthorsController(IAuthorService author)
        {
            this.authors = author;
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.authors.Details(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AuthorRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = await this.authors.Create(
                model.FirstName,
                model.LastName);

            return Ok(id);
        }
    }
}
