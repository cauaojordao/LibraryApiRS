using RSConnect.Api.Domain.Entities;
using RSConnect.Api.Infraestructure.DataAccess;
using RSConnect.Communication.Requests;
using RSConnect.Communication.Responses;

namespace RSConnect.Api.UseCases.Books.Filter
{
    public class FilterBookUseCase
    {
        public ResponseBooksJson Execute(RequestFilterBooksJson request)
        {
            var dbContext = new RSConnectDbContext();

            var books = dbContext.Books.ToList();

            return new ResponseBooksJson
            {
                Books = books.Select(book => new ResponseBookJson
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                }).ToList()

            };
        }
    }
}
