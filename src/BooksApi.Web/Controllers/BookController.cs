using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Web.Controllers
{
    public class BookController : Controller
    {
        public async Task<IResult> GetBooks()
        {
            return Results.Ok("book");
        }
    }
}