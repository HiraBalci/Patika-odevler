using FluentValidation;

namespace WebApi.BookOperations.GetByIdBook
{
    public class GetByIdBookQueryValidator : AbstractValidator<GetByIdBookQuery>
    {

        public GetByIdBookQueryValidator()
        {
            RuleFor(query=>query.bookId).GreaterThan(0);
            
        }

    }

}